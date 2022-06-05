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
    public partial class Hastalar : Form
    {
        

       
        SqlConnection con1 = new SqlConnection("Server=.;Database=Hastane;Integrated Security=true");

        public Hastalar()
        {
            InitializeComponent();
            Goster();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
            
        }

        private void Hastalar_Load(object sender, EventArgs e)
        {
            Goster();
            
            
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT * FROM Doktorlar";
            komut.Connection = con1;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            con1.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["DoktorNo"]);
            }

            con1.Close();
        }

        private void button4_Click(object sender, EventArgs e) //Güncelle
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;  
            komut.CommandText = "hastaUpdate";
            con1.Open();
            komut.Parameters.AddWithValue("hastaNo", textBox1.Text);
            komut.Parameters.AddWithValue("AdSoyad", textBox2.Text);
            komut.Parameters.AddWithValue("TC", textBox3.Text);
            komut.Parameters.AddWithValue("DogumTarihi", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("Boy", textBox5.Text);
            komut.Parameters.AddWithValue("yas", textBox4.Text);
            komut.Parameters.AddWithValue("recete", textBox6.Text);

            komut.Parameters.AddWithValue("raporDurumu", textBox11.Text);
            komut.Parameters.AddWithValue("RandevuTarih", dateTimePicker2.Text);
            komut.Parameters.AddWithValue("DoktorNo", comboBox1.SelectedItem);
            komut.ExecuteNonQuery();
            con1.Close();
            Goster();

        }

        private void button3_Click(object sender, EventArgs e) //ekle
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;    
            komut.CommandText = "hastaAdd";
            con1.Open();
            komut.Parameters.AddWithValue("AdSoyad", textBox2.Text);
            komut.Parameters.AddWithValue("TC", textBox3.Text);
            komut.Parameters.AddWithValue("DogumTarihi", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("Boy", textBox5.Text);
            komut.Parameters.AddWithValue("yas", textBox4.Text);
            komut.Parameters.AddWithValue("recete", textBox6.Text);

            komut.Parameters.AddWithValue("raporDurumu", textBox11.Text);
            komut.Parameters.AddWithValue("RandevuTarih", dateTimePicker2.Text);
            komut.Parameters.AddWithValue("DoktorNo", Convert.ToInt32(comboBox1.SelectedItem));

            komut.ExecuteNonQuery(); 
            con1.Close();
            Goster();
        }
        public void Goster()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure; 
            komut.CommandText = "hastaSelect";
            SqlDataAdapter dp = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();              
            dp.Fill(dt);
            dataGridView1.DataSource = dt;
        }
      
        private void button6_Click(object sender, EventArgs e)  //Sil
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;    
            komut.CommandText = "hastaDel";
            con1.Open();
            komut.Parameters.AddWithValue("hastaNo", textBox10.Text);

            komut.ExecuteNonQuery();
            con1.Close();
            Goster();
        }

        private void button5_Click(object sender, EventArgs e) //Ara
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;    
            komut.CommandText = "hastaSearch";
            komut.Parameters.AddWithValue("AdSoyad", textBox8.Text);
            komut.Parameters.AddWithValue("Tc", textBox9.Text);
            SqlDataAdapter dp = new SqlDataAdapter(komut); 
            DataTable dt = new DataTable();              
            dp.Fill(dt);
            dataGridView1.DataSource = dt;

            textBox8.Clear();
            textBox9.Clear();
        }

        private void button11_Click(object sender, EventArgs e)   //A to Z
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;    
            komut.CommandText = "hastaAtoZ";
            SqlDataAdapter dp = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();              
            dp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button12_Click(object sender, EventArgs e) //Z to A
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure; 
            komut.CommandText = "hastaZtoA";
            SqlDataAdapter dp = new SqlDataAdapter(komut); 
            DataTable dt = new DataTable();              
            dp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;  
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
            textBox11.Text = dataGridView1.Rows[secim].Cells[7].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[secim].Cells[8].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secim].Cells[9].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
