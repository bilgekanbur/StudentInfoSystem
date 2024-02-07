
--200709008 BÝLGE SENA KANBUR
use StudentInfoSystem


--Ýsim soyisim ve öðrenci numarasýndan okul epostasý oluþturma
CREATE FUNCTION CreateSchollMail(@name nvarchar(50),@surname nvarchar(50), @studentNumber bigint)
RETURNS NVARCHAR(100)
AS
BEGIN
DECLARE @schollMail nvarchar(100)
SET @schollMail = CONCAT(@name, '.', @surname, LEFT(CONVERT(NVARCHAR(20), @studentNumber), 2), '@atauni.edu.tr')
RETURN @schollMail
END

SELECT dbo.CreateSchollMail(name, surname, studentNumber) AS SchoolMail
FROM Tbl_RecordStudentt

-------------------------------------------------------------------------------------------------
--girilen vize ve final notlarýna göre ortalama hesaplar
CREATE FUNCTION CalculateAverage(@midterm int,@final int)
RETURNS INT
AS
BEGIN
DECLARE @average int
set @average= (@midterm*0.4)+ (@final *0.6)
RETURN @average
END

SELECT dbo.CalculateAverage(midterm,final)
FROM Tbl_StudentExamGrade


--------------------------------------------------------------------------------------------------
--Determines the class of the newly added student
create function DetermineClass(@studentNumber bigint, @dateOfRegistration date)
RETURNS INT
as
begin
declare @class int
set @class = DATEDIFF(YEAR, @dateOfRegistration, GETDATE()) + 1;
return @class
end

select dbo.DetermineClass(studentNumber,dateOfRegistration) from Tbl_RecordStudentt

select * from Tbl_RecordStudentt


---------------------------------------------------------------------------------------------------

CREATE TRIGGER trg_AfterInsert_Tbl_RecordStudentt
ON [dbo].[Tbl_RecordStudentt]
AFTER INSERT
AS
BEGIN
    
    DECLARE @name NVARCHAR(50), @surname NVARCHAR(50), @studentNumber bigint;

    SELECT @name = [name], @surname = surname, @studentNumber = studentNumber
    FROM inserted;

    -- updating school mail
    UPDATE [dbo].[Tbl_RecordStudentt]
    SET schollMail = dbo.CreateSchollMail(@name, @surname, @studentNumber)
    WHERE studentNumber = @studentNumber;
END;


---------------------------------------------------------------------------------------------------------
CREATE TRIGGER trg_Tbl_RecordStudentt_UpdatePhoneNumberOrPassword
ON Tbl_RecordStudentt
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tc bigint, @studentNumber bigint ;

    -- if the phone number or password column is updating 
    IF UPDATE(phoneNumber) OR UPDATE(password)
    BEGIN
        -- take the student number
        SELECT @tc=tc , @studentNumber=studentNumber FROM inserted;

        -- add record to tbl_Durummmmm
        INSERT INTO Tbl_Durummmm (message)
        VALUES (
		('Student Number: '+ CAST(@studentNumber AS NVARCHAR(50)) + ' is updating.'+ 
		CAST(GETDATE() AS NVARCHAR(20))));
    END
END;
drop trigger trg_Tbl_RecordStudentt_UpdatePhoneNumberOrPassword
drop table Tbl_Durummm

delete from Tbl_RecordStudentt
select * from Tbl_RecordStudentt
select * from Tbl_Durummmm
-----------------------------------------------------------------------------------------------
--The student can choose the semester she wants and take the courses of that semester.
create procedure up_ViewLessons
@tc bigint,
@term nvarchar(20)
as
begin
SELECT
    o.department,
    l.lessonCode,
    l.lessonName,
    l.term
FROM
    Tbl_RecordStudentt o
INNER JOIN
    Tbl_ComputerEngineerLessonEng l ON o.department = l.department
where
	tc=@tc and term=@term

end

drop procedure up_ViewLessons
exec up_ViewLessons @tc=12961135974, @term='5.Term'
------------------------------------------------------------------------------------------------
--The student can see the faculty and see the clubs in that faculty.
create Procedure up_ViewStudentClub
@faculty nvarchar(50)
as
begin
select * from [dbo].[Tbl_StudentClubs] where faculty=@faculty
end
drop procedure up_ViewStudentClub
exec up_ViewStudentClub @faculty='Edebiyat Fakültesi'
select * from [dbo].[Tbl_StudentClubs]
----------------------------------------------------------------------------------------
--Determines whether the person logging in is an academician or a student.
create procedure up_AcademicianOrStudent
@tc bigint, @password nvarchar(50)
as
BEGIN
    IF EXISTS (SELECT 1 FROM Tbl_RecordStudentt WHERE tc = @tc and [password]=@password)
    BEGIN
       
        SELECT * FROM Tbl_RecordStudentt WHERE tc = @tc and [password]=@password;
    END
    ELSE
    BEGIN
        
        SELECT * FROM Tbl_AboutAcademician WHERE tc = @tc and [password]=@password;
    END
END

exec up_AcademicianOrStudent @tc=12961135974, @password=sena1234

exec up_AcademicianOrStudent @tc=12345678999, @password=ahmet1234
------------------------------------------------------------------------------------------
--If the student is newly registered, he updates his class
create trigger trg_UpdateClass
ON Tbl_RecordStudentt
AFTER INSERT
AS
BEGIN
DECLARE @tc bigint, @class int,@dateOfRegistration date;

    SELECT @tc = tc, @dateOfRegistration=dateOfRegistration
    FROM inserted;

    
    UPDATE Tbl_RecordStudentt
    SET class = dbo.DetermineClass(@tc,@dateOfRegistration)
    WHERE tc= @tc and dateOfRegistration=@dateOfRegistration;
END;

drop trigger trg_UpdateClass
select * from Tbl_RecordStudentt
---------------------------------------------------------------------------


delete from Tbl_RecordStudentt
select * from Tbl_RecordStudentt

------------------------------------------------------------------------
--The student sees the announced exam grades here.
create view vw_choosingLessons
as
select p.tc ,p.studentNumber, p.department,p.class,e.lessonName,e.term,e.grade from Tbl_RecordStudentt p
inner join Tbl_StudentExamGrade e on p.studentNumber=e.studentNumber
where (class='1' and (term='1.Term' or term='2.Term')) OR (class = '2' AND (term = '3.Term' OR term = '4.Term'))
OR (class = '3' AND (term = '5.Term' OR term = '6.Term'))OR (class = '4' AND (term = '7.Term' OR term = '.Term'))

drop view vw_choosingLessons
select * from dbo.vw_choosingLessons

-------------------------------------------------------------------------------------------------------------
--By calling the calculate letter grade average function of the student, first the average 
--is calculated and then the letter grade is determined and assigned.
create procedure up_CalculateLetterGrade
@lessonName nvarchar(50),
@midterm int,
@final int,
@studentNumber bigint,
@term nvarchar(20)
AS
BEGIN
    DECLARE @average int, @grade nvarchar(20);
    
    SET @average = dbo.CalculateAverage(@midterm, @final);

    SET @grade = 
        CASE
            WHEN @average >= 90 THEN 'AA'
            WHEN @average >= 80 THEN 'BA'
            WHEN @average >= 70 THEN 'BB'
            WHEN @average >= 60 THEN 'CB'
            WHEN @average >= 50 THEN 'CC'
            WHEN @average > 45 THEN 'DC'
            WHEN @average = 45 THEN 'DD'
            ELSE 'F'
        END;


    insert into Tbl_StudentExamGrade VALUES(@studentNumber,CAST(@midterm AS nvarchar(10)),CAST(@final AS nvarchar(10)),@lessonName, @grade,@term)
	select * from Tbl_StudentExamGrade

end

drop procedure up_CalculateLetterGrade
exec up_CalculateLetterGrade @lessonName='Operating System',@midterm=31, @final=50,@studentNumber=985421959,@term='5.Term'
exec up_CalculateLetterGrade @lessonName='Software Engineering',@midterm=20, @final=85,@studentNumber=985421959,@term='5.Term'

delete from Tbl_StudentExamGrade
select * from Tbl_RecordStudentt
select * from Tbl_StudentExamGrade
----------------------------------------------------------------------------------------------------------------
--Returns students taking that course
create procedure up_ListStudent
@lessonName nvarchar(50)
as
begin
select * from Tbl_StudentExamGrade where lessonName=@lessonName
end
exec up_ListStudent @lessonName='R Programming'


select * from Tbl_Durummmm

select * from [dbo].[Tbl_ComputerEngineerLessonEng]

