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
    public partial class CepTelNoGuncelle : Form
    {
        public CepTelNoGuncelle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();  // form2 göster diyoruz
            this.Hide();
        }


    
        SqlConnection baglanti = new SqlConnection("Data Source=SENA;Initial Catalog=StudentInfoSystem;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            string tc = textBox1.Text;
            string anneAdi= textBox2.Text;
            string babaAdi = textBox3.Text;
            string dogumTarihi = maskedTextBox1.Text;


            baglanti.Open();
            SqlCommand komut_update = new SqlCommand("update Tbl_RecordStudentt set phoneNumber=@u1 where tc=@u2 and motherName=@u3 and fatherName=@u4 and birthday=@u5" ,baglanti);
            komut_update.Parameters.AddWithValue("@u1","+"+comboBox1.Text+ maskedTextBox2.Text);
            komut_update.Parameters.AddWithValue("@u2", tc);
            komut_update.Parameters.AddWithValue("@u3", anneAdi);
            komut_update.Parameters.AddWithValue("@u4", babaAdi);
            komut_update.Parameters.AddWithValue("@u5", dogumTarihi);
            int affectedRows = komut_update.ExecuteNonQuery();

            baglanti.Close();

            if (affectedRows > 0)
            {
                MessageBox.Show("Telefon Numarası Güncellenmiştir.");
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
