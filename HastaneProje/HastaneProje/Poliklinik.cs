using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneProje
{
    public partial class Poliklinik : Form
    {
        public Poliklinik()
        {
            InitializeComponent();
        }
        SqlConnection con1 = new SqlConnection("Server=.;Database=Hastane;Integrated Security=true");

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
        public void PoliklinikGoster()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "polSelect";   //AtoZ 
            SqlDataAdapter dp = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();            
            dp.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button4_Click(object sender, EventArgs e)  //Güncelle
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure; 
            komut.CommandText = "polUpdate";
            con1.Open();
            komut.Parameters.AddWithValue("PoliklinikNo", textBox1.Text);
            komut.Parameters.AddWithValue("PoliklinikAd", textBox2.Text);
            komut.Parameters.AddWithValue("UzmanSayi", textBox3.Text);
            komut.Parameters.AddWithValue("baskanAdSoyad", textBox4.Text);
            komut.Parameters.AddWithValue("bashemsireAdSoyad", textBox5.Text);
            komut.Parameters.AddWithValue("yataksayisi", textBox6.Text);

            komut.ExecuteNonQuery(); 
            con1.Close();
            PoliklinikGoster();
        }

        private void button3_Click(object sender, EventArgs e)  //Ekle
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;  
            komut.CommandText = "polAdd";
            con1.Open();
            
            komut.Parameters.AddWithValue("PoliklinikAd", textBox2.Text);
            komut.Parameters.AddWithValue("UzmanSayi", textBox3.Text);
            komut.Parameters.AddWithValue("baskanAdSoyad", textBox4.Text);
            komut.Parameters.AddWithValue("bashemsireAdSoyad", textBox5.Text);
            komut.Parameters.AddWithValue("yataksayisi", textBox6.Text);
           
            komut.ExecuteNonQuery(); 
            con1.Close();
            PoliklinikGoster();
        }

        private void button5_Click(object sender, EventArgs e)   //Arama Yap
        {
            SqlCommand cmd = new SqlCommand("polSearch", con1);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("poliklinikNo", textBox7.Text);
            cmd.Parameters.AddWithValue("poliklinikad", textBox8.Text);
            con1.Open();
            SqlDataAdapter adapter =new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con1.Close();
        }

        private void button6_Click(object sender, EventArgs e)   //Sil
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;    
            komut.CommandText = "polDel";
            con1.Open();
            komut.Parameters.AddWithValue("PoliklinikNo", textBox10.Text);

            komut.ExecuteNonQuery();
            con1.Close();
            PoliklinikGoster();
        }

        private void button11_Click(object sender, EventArgs e)  //A to Z
        {
            PoliklinikGoster();
        }

        private void button12_Click(object sender, EventArgs e)   //Z to A
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;   
            komut.CommandText = "polZtoA";
            SqlDataAdapter dp = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();           
            dp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Poliklinik_Load(object sender, EventArgs e)
        {
            PoliklinikGoster();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible= false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }
    }
}
