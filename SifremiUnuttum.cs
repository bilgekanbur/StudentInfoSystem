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

namespace ogrenci_bilgi_sistemi_pc
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();  // form2 göster diyoruz
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CepTelNoGuncelle telNoGuncelle = new CepTelNoGuncelle();
            telNoGuncelle.Show();  // form2 göster diyoruz
            this.Hide();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=SENA;Initial Catalog=StudentInfoSystem;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            string tc = textBox1.Text;
            string anneAdi= textBox2.Text;
            string cepNo="+"+comboBox1.Text + maskedTextBox1.Text;
            baglanti.Open();
            SqlCommand komut_update = new SqlCommand("update Tbl_RecordStudentt set password=@u1 where tc=@u2 and motherName=@u3 and phoneNumber=@u4", baglanti);
            komut_update.Parameters.AddWithValue("@u1", textBox3.Text);
            komut_update.Parameters.AddWithValue("@u2", tc);
            komut_update.Parameters.AddWithValue("@u3", anneAdi);
            komut_update.Parameters.AddWithValue("@u4", cepNo);
            int affectedRows = komut_update.ExecuteNonQuery();

            baglanti.Close();

            if (affectedRows > 0)
            {
                MessageBox.Show("Şifre Güncellenmiştir.");
               

            }
            else
            {
                MessageBox.Show("Bu kişi bulunamamıştır, lütfen tekrardan inceleyiniz!");
            }

            baglanti.Close();
            Form1 anasayfa = new Form1();
            anasayfa.Show();  // form2 göster diyoruz
            this.Close();

        }
    }
}
