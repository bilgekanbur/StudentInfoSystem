using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Messaging;

namespace ogrenci_bilgi_sistemi_pc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        string tc;
        string sifre;
        
        SqlConnection baglanti = new SqlConnection("Data Source=SENA;Initial Catalog=StudentInfoSystem ;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = user_name.Text;
            string sifre =password.Text;

            if (giris_kontrol(kullaniciAdi, sifre))
            {
                // Giriş başarılı
                
            }
            else
            {
               //giriş başarısız
            }


        }

        public bool giris_kontrol(string tc, string sifre)
        {

            baglanti.Open();

            tc = user_name.Text;
            sifre = password.Text;


            SqlCommand giris = new SqlCommand("exec up_AcademicianOrStudent @tc=@tc, @password=@password", baglanti);

            giris.Parameters.AddWithValue("@tc", tc);
            giris.Parameters.AddWithValue("@password", sifre);
            SqlDataReader reader = giris.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Giriş Yapılıyor");

                user_name.Text = "";
                password.Text = "";

                string status= reader["situation"].ToString();

                if (status == "Student")
                {
                    profillFormm profilForm = new profillFormm(tc);
                    profilForm.Show();
                    this.Hide();
                }
                else
                {
                    AcademicianProfil academician = new AcademicianProfil(tc);
                    academician.Show();
                    this.Hide();
                }
                reader.Close();
                baglanti.Close();
                return true;
            }
            else
            {
                MessageBox.Show("Yanlış Giriş Yaptınız!!");
                baglanti.Close();
                return false;
            }

             
            

        }
        private void kayıt_ol_Click(object sender, EventArgs e)
        {
            kayitol kayitol = new kayitol();
            kayitol.Show();  // form2 göster diyoruz
            this.Hide();
        }


        private string varsayilanMetin = "T.C./User Name";
        private string varsayilanSifre = "Password";

        private void Form1_Load(object sender, EventArgs e)
        {
            user_name.Text = varsayilanMetin;
            password.Text= varsayilanSifre;

            
            user_name.Click += user_name_click;
            password.Click += password_click;
            password.PasswordChar = '*';
        }
        private void user_name_click(object sender, EventArgs e)
        {
            // TextBox'a tıklandığında, varsayılan metin kontrol edilir ve temizlenir
            if (user_name.Text == varsayilanMetin)
            {
                user_name.Text = string.Empty; // veya textBox1.Text = "";
            }

            // Bu olayı bir kere çağırarak, sonraki tıklamalarda tekrar çalışmasını önlüyoruz
            user_name.Click -= user_name_click;
        }
        private void password_click(object sender, EventArgs e)
        {
            // TextBox'a tıklandığında, varsayılan metin kontrol edilir ve temizlenir
            if (password.Text == varsayilanSifre)
            {
                password.Text = string.Empty; // veya textBox1.Text = "";
            }

            // Bu olayı bir kere çağırarak, sonraki tıklamalarda tekrar çalışmasını önlüyoruz
            password.Click -= password_click;
        }

        private void sifre_unut_Click(object sender, EventArgs e)
        {
            SifremiUnuttum sifreunut = new SifremiUnuttum();
            sifreunut.Show();  // form2 göster diyoruz
            this.Hide();
        }

       
        private void button3_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://birimler.atauni.edu.tr/ogrenci-isleri-daire-baskanligi/bilgi-rehberleri/");
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://obs.atauni.edu.tr/moduller/login/istatistik/index");
        }
    }
}
