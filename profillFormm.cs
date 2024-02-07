using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace ogrenci_bilgi_sistemi_pc
{
    public partial class profillFormm : Form
    {

        private string tcno;

        SqlConnection baglanti = new SqlConnection("Data Source=SENA;Initial Catalog=StudentInfoSystem;Integrated Security=True");
        private SqlDataAdapter dataAdapter;

        public profillFormm(string tcno)
        {
            InitializeComponent();
            this.tcno = tcno;


            KullaniciBilgileriniGoster();

        }
        // Giriş formundan alınacak TC kimlik numarası

        private void KullaniciBilgileriniGoster()
        {
            baglanti.Open();
            SqlCommand com = new SqlCommand("SELECT name,surname,situation,carrier,studentNumber,department,faculty FROM Tbl_RecordStudentt WHERE tc= @tcno", baglanti);
            com.Parameters.AddWithValue("@tcno", tcno);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                string ad = reader["name"].ToString();
                string soyad = reader["surname"].ToString();
                string situation = reader["situation"].ToString();
                string carrier = reader["carrier"].ToString();
                string studentNumber = reader["studentNumber"].ToString();
                string department = reader["department"].ToString();
                string faculty = reader["faculty"].ToString();


                label1.Text = ad;
                label2.Text = soyad;
                label4.Text = ad;
                label5.Text = soyad;
                label7.Text = carrier;
                label6.Text = situation;
                label8.Text = faculty;
                label9.Text = department;
                label10.Text = studentNumber;



            }


            baglanti.Close();


        }

        private void profillFormm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentInfoSystemDataSet.vw_choosingLessons' table. You can move, or remove it, as needed.
            this.vw_choosingLessonsTableAdapter.Fill(this.studentInfoSystemDataSet.vw_choosingLessons);
            // TODO: This line of code loads data into the 'studentInfoSystemDataSet.Tbl_StudentClubs' table. You can move, or remove it, as needed.
            this.tbl_StudentClubsTableAdapter.Fill(this.studentInfoSystemDataSet.Tbl_StudentClubs);
            // TODO: This line of code loads data into the 'studentInfoSystemDataSet.Tbl_ComputerEngineerLessonEng' table. You can move, or remove it, as needed.
            this.tbl_ComputerEngineerLessonEngTableAdapter.Fill(this.studentInfoSystemDataSet.Tbl_ComputerEngineerLessonEng);



        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            panel7.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;



            panel5.Visible = false;
            label12.Visible = false;
            comboBox3.Visible = false;
            button5.Visible = false;
            dataGridView2.Visible = false;


            panel6.Visible = false;
            dataGridView3.Visible = false;
            
            panel4.Visible = true;
            label11.Visible = true;
            comboBox1.Visible = true;
            dataGridView1.Visible = true;
            button3.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)

        {
            panel5.Visible = true;
            label12.Visible = true;
            comboBox3.Visible = true;
            button5.Visible = true;
            dataGridView2.Visible = true;

            panel7.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;


            panel6.Visible = false;
            dataGridView3.Visible = false;

            panel4.Visible = false;
            label11.Visible = false;
            comboBox1.Visible = false;
            dataGridView1.Visible = false;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;

            panel4.Visible = false;
            label11.Visible = false;
            comboBox1.Visible = false;
            dataGridView1.Visible = false;

            panel5.Visible = false;
            label12.Visible = false;
            comboBox3.Visible = false;
            button5.Visible = false;
            dataGridView2.Visible = false;

            panel6.Visible = true;
            dataGridView3.Visible = true;

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.vw_choosingLessons where tc=@tcno", baglanti);
            cmd.Parameters.AddWithValue("@tcno", tcno);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable3 = new DataTable();
            adapter.Fill(dataTable3);
            dataGridView3.DataSource = dataTable3;
            cmd.ExecuteNonQuery();
            baglanti.Close();

        }
        private void button6_Click(object sender, EventArgs e)
        {
            
            panel4.Visible = false;
            label11.Visible = false;
            
            comboBox1.Visible = false;
            dataGridView1.Visible = false;

            panel5.Visible = false;
            label12.Visible = false;
            comboBox3.Visible = false;
            button5.Visible = false;
            dataGridView2.Visible = false;

            panel6.Visible = false;
            dataGridView3.Visible = false;

            panel7.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;




            baglanti.Open();
            
            SqlCommand com = new SqlCommand("SELECT name,surname,situation,carrier,studentNumber,department,faculty,schollMail FROM Tbl_RecordStudentt WHERE tc= @tcno", baglanti);
            com.Parameters.AddWithValue("@tcno", tcno);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                string ad = reader["name"].ToString();
                string soyad = reader["surname"].ToString();
                string situation = reader["situation"].ToString();
                string carrier = reader["carrier"].ToString();
                string studentNumber = reader["studentNumber"].ToString();
                string department = reader["department"].ToString();
                string faculty = reader["faculty"].ToString();
                string schollMail = reader["schollMail"].ToString();

                textBox1.Text = ad;
                textBox2.Text = soyad;
                textBox3.Text = carrier;
                textBox4.Text = situation;
                textBox5.Text = faculty;
                textBox6.Text = department;
                textBox7.Text = studentNumber;
                textBox8.Text = schollMail;

                baglanti.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            string selectedTerm = comboBox1.Text;

            SqlCommand cmd = new SqlCommand("exec up_ViewLessons @tc=@u3,@term=@u4", baglanti);
            cmd.Parameters.AddWithValue("@u3", tcno);
            cmd.Parameters.AddWithValue("@u4", selectedTerm);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }



        private void button5_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            string selectedfaculty = comboBox2.Text;

            SqlCommand com = new SqlCommand("exec up_ViewStudentClub @faculty=@u2", baglanti);
            com.Parameters.AddWithValue("@u2", selectedfaculty);
            MessageBox.Show(selectedfaculty);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable dataTable2 = new DataTable();
            adapter.Fill(dataTable2);
            dataGridView2.DataSource = dataTable2;
            com.ExecuteNonQuery();
            baglanti.Close();

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            baglanti.Open();
            string selectedTerm = comboBox1.Text;

            SqlCommand cmd = new SqlCommand("exec up_ViewLessons @tc=@u3,@term=@u4", baglanti);
            cmd.Parameters.AddWithValue("@u3", tcno);
            cmd.Parameters.AddWithValue("@u4", selectedTerm);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            string selectedfaculty = comboBox3.Text;

            SqlCommand com = new SqlCommand("exec up_ViewStudentClub @faculty=@u2", baglanti);
            com.Parameters.AddWithValue("@u2", selectedfaculty);
            MessageBox.Show(selectedfaculty);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable dataTable2 = new DataTable();
            adapter.Fill(dataTable2);
            dataGridView2.DataSource = dataTable2;
            com.ExecuteNonQuery();
            baglanti.Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

