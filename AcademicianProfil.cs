using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ogrenci_bilgi_sistemi_pc
{
    public partial class AcademicianProfil : Form
    { 
        private string tcno;
        public AcademicianProfil(string tcno)
        {
            InitializeComponent();
            this.tcno = tcno;
            ViewAcademicianInfo();
            
        }

        private void AcademicianProfil_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentInfoSystemDataSet.Tbl_StudentExamGrade' table. You can move, or remove it, as needed.
            this.tbl_StudentExamGradeTableAdapter.Fill(this.studentInfoSystemDataSet.Tbl_StudentExamGrade);
            // TODO: This line of code loads data into the 'studentInfoSystemDataSet5.Tbl_StudentExamGrade' table. You can move, or remove it, as needed.

        }


        SqlConnection con = new SqlConnection("Data Source=SENA;Initial Catalog=StudentInfoSystem ;Integrated Security=True");

        private void ViewAcademicianInfo()

        {
            con.Open();
            
            SqlCommand com = new SqlCommand("SELECT name,surname,situation,department,faculty, givingLessons FROM Tbl_AboutAcademician WHERE tc= @tc", con);
            com.Parameters.AddWithValue("@tc", tcno);
            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {
                string ad = reader["name"].ToString();
                string soyad = reader["surname"].ToString();
                string situation = reader["situation"].ToString();
                string department = reader["department"].ToString();
                string faculty = reader["faculty"].ToString();
                string lessons = reader["givingLessons"].ToString();

                MessageBox.Show("Hoşgeldiniz"+" "+ad+" "+soyad);


                label1.Text = ad;
                label2.Text = soyad;
                label4.Text = ad;
                label5.Text = soyad;
                label6.Text = situation;
                label7.Text = situation;
                label8.Text = faculty;

                label9.Text = department;
                string[] values = lessons.Split(',');
                foreach (string value in values)
                {
                    comboBox1.Items.Add(value);
                    comboBox2.Items.Add(value);

                }

            }
            con.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            comboBox2.Visible = true;
            button4.Visible = true;
            dataGridView2.Visible = true; 
            panel5.Visible = true;

            panel4.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button3.Visible = false;
            label14.Visible = false;
            comboBox3.Visible = false;
            dataGridView1.Visible = false;
        }
 

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            comboBox1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button3.Visible = true;
            label14.Visible = true;
            comboBox3.Visible = true;
            dataGridView1.Visible = true;

            dataGridView2.Visible = false;
            panel5.Visible = false;
            comboBox2.Visible = false;
            button4.Visible = false;   

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("exec up_CalculateLetterGrade @lessonName=@u1,@midterm=@u2,@final=@u3,@studentNumber=@u4,@term=@u5", con);
            
            cmd.Parameters.AddWithValue("@u1", comboBox1.Text);
            cmd.Parameters.AddWithValue("@u2", textBox2.Text);
            cmd.Parameters.AddWithValue("@u3", textBox3.Text);
            cmd.Parameters.AddWithValue("@u4",textBox1.Text);
            cmd.Parameters.AddWithValue("@u5",comboBox3.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("exec up_ListStudent @lessonName=@u1", con);
            cmd.Parameters.AddWithValue("@u1", comboBox2.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Close();
        }
    }
   }