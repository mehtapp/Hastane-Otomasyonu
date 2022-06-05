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
    public partial class Doktorlar : Form
    {
        public Doktorlar()
        {
            InitializeComponent();
        }
        SqlConnection con1 = new SqlConnection("Server=.;Database=Hastane;Integrated Security=true");

        private void button1_Click(object sender, EventArgs e) //geri git
        {
            Form1 anasayfa=new Form1();
            anasayfa.Show();
            this.Hide();
        }

        public void DoktorlarGoster()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;    
            komut.CommandText = "doktorSelectAtoZ";
            SqlDataAdapter dp = new SqlDataAdapter(komut); 
            DataTable dt = new DataTable();              
            dp.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button11_Click(object sender, EventArgs e) //A to Z
        {
            DoktorlarGoster();
        }

        private void button12_Click(object sender, EventArgs e) //Z to A
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "doktorZtoA";
            SqlDataAdapter dp = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e) //Guncelle
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "doktorUpdate";
            con1.Open();
            komut.Parameters.AddWithValue("doktorNo", textBox1.Text);
            komut.Parameters.AddWithValue("AdSoyad", textBox2.Text);
            komut.Parameters.AddWithValue("TC", textBox3.Text);
            komut.Parameters.AddWithValue("uzmanlikAlan", textBox4.Text);
            komut.Parameters.AddWithValue("Unvan", textBox5.Text);
            komut.Parameters.AddWithValue("telefon", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("adres", textBox6.Text);

            komut.Parameters.AddWithValue("DogumTar", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("PoliklinikNo", comboBox1.SelectedItem);

            komut.ExecuteNonQuery();
            con1.Close();
            DoktorlarGoster();
        }

        private void button3_Click(object sender, EventArgs e)  //Ekle
        {
            SqlCommand komut = new SqlCommand("doktorAdd",con1);
            komut.CommandType = CommandType.StoredProcedure;   
            con1.Open();
            komut.Parameters.AddWithValue("AdSoyad", textBox2.Text);
            komut.Parameters.AddWithValue("TC", textBox3.Text);
            komut.Parameters.AddWithValue("uzmanlikAlan", textBox4.Text);
            komut.Parameters.AddWithValue("Unvan", textBox5.Text);
            komut.Parameters.AddWithValue("telefon", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("adres", textBox6.Text);

            komut.Parameters.AddWithValue("DogumTar", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("PoliklinikNo", comboBox1.SelectedItem);

            komut.ExecuteNonQuery();
            con1.Close();
            DoktorlarGoster();
        }

        private void button5_Click(object sender, EventArgs e)  //Arama
        {
            SqlCommand cmd = new SqlCommand("doktorSearch", con1);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AdSoyad", textBox8.Text);
            cmd.Parameters.AddWithValue("tc",textBox9.Text);
            con1.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con1.Close();
        }

        private void button6_Click(object sender, EventArgs e)  //Silme
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;    
            komut.CommandText = "doktorDel";
            con1.Open();
            komut.Parameters.AddWithValue("DoktorNo", textBox10.Text);

            komut.ExecuteNonQuery();
            con1.Close();
            DoktorlarGoster();

        }

        private void Doktorlar_Load(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT * FROM Poliklinikler";
            komut.Connection = con1;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            con1.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["PoliklinikNo"]);
            }
            con1.Close();
            DoktorlarGoster();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible= true;
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
            textBox4.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[secim].Cells[7].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secim].Cells[8].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
