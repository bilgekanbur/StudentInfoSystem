using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ogrenci_bilgi_sistemi_pc
{
    public partial class kayitol : Form
    {

        public kayitol()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        SqlConnection baglanti = new SqlConnection("Data Source=SENA;Initial Catalog=StudentInfoSystem ;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            
            string department = comboBox5.Text;
            
          

            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into Tbl_RecordStudentt (tc,studentNumber,country,name,surname,motherName,fatherName,birthday,gender,phoneNumber,eMail,city," +
                "town,address,password,department,situation,carrier,faculty,dateOfRegistration) values( @tc,@studentNumber,@country,@name,@surname,@motherName,@fatherName,@birthday," +
                "   @gender,@phoneNumber,@eMail,@city,@town,@address,@password,@department,@situation,@carrier,@faculty,@dateOfRegistration)", baglanti);
            



            komut.Parameters.AddWithValue("@tc", Convert.ToInt64( textBox1.Text));
            komut.Parameters.AddWithValue("@studentNumber", GenerateOgrenciNumarasi());
            komut.Parameters.AddWithValue("@country", comboBox1.Text);
            komut.Parameters.AddWithValue("@name", textBox2.Text);
            komut.Parameters.AddWithValue("@surname", textBox3.Text);
            komut.Parameters.AddWithValue("@motherName", textBox4.Text);
            komut.Parameters.AddWithValue("@fatherName", textBox5.Text);
            komut.Parameters.AddWithValue("@birthday", Convert.ToDateTime(maskedTextBox1.Text));
            komut.Parameters.AddWithValue("@gender", comboBox2.Text);
            komut.Parameters.AddWithValue("@phoneNumber", "+" + comboBox4.Text + maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@eMail", textBox8.Text);
            komut.Parameters.AddWithValue("@city", comboBox3.Text);
            komut.Parameters.AddWithValue("@town", textBox6.Text);
            komut.Parameters.AddWithValue("@address", textBox10.Text);
            komut.Parameters.AddWithValue("@password", textBox11.Text);
            komut.Parameters.AddWithValue("@department", comboBox5.Text);
            komut.Parameters.AddWithValue("@situation", "Student");
            komut.Parameters.AddWithValue("@carrier", "devam ediyor");
            komut.Parameters.AddWithValue("@faculty", GetFacultyByDepartment(department));
            komut.Parameters.AddWithValue("@dateOfRegistration", DateTime.Now);

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kullanıcı başarılı bir şekilde oluşturuldu.");
            Form1 anasayfa = new Form1();
            anasayfa.Show();  // form2 göster diyoruz
            this.Hide();

        }
        static string GenerateOgrenciNumarasi()
        {
            // Rastgele bir 9 basamaklı sayı üret
            Random random = new Random();
            int studentNumber = random.Next(100000000, 999999999);

            return studentNumber.ToString();

        }

        static string GetFacultyByDepartment(string department)
        {
            string faculty = "";
            if (department == "Bilgisayar Mühendisliği" || department == "Bilgisayar Mühendisliği(İngilizce)" || department == "Bilgisayar Mühendisliği(İÖ)" || department == "Elektrik Elektronik Mühendisliği")
            {
                faculty = "Mühendislik Fakültesi";
            }
            if (department == "Tarih")
            {
                faculty = "Edebiyat Fakültesi";
            }
            if (department == "Mimarlık")
            {
                faculty = "Miamrlık ve Tasarım Fakültesi";
            }
            if (department == "Hemşirelik")
            {
                faculty = "Hemşirelik Fakültesi";
            }
            if (department == "Eczacılık")
            {
                faculty = "Eczacılık Fakültesi";
            }

            return faculty;
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
