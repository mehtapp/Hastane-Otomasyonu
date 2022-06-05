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
    public partial class Raporlar : Form
    {
        SqlConnection con1 = new SqlConnection("Server=.;Database=Hastane;Integrated Security=true");
        

        public Raporlar()
        {
            InitializeComponent();
        }

        private void Raporlar_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) //Poliklinik No'ya Göre Hasta/Doktor Bilgileri
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "polNoHasDokBilg1";
            SqlDataAdapter dp = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)  //Poliklinik Tablosuna Göre Sol Sorgu
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "polTabSolSorgu2";
            SqlDataAdapter dA=new SqlDataAdapter(komut);
            DataTable dB=new DataTable();

            dA.Fill(dB);
            dataGridView1.DataSource = dB;
            //polTabSolSorgu2
        }

        private void button2_Click(object sender, EventArgs e)   //Ortak Alanlara Göre Hasta Bilgileri
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "OrtAlGorHasBilg3";
            SqlDataAdapter dA = new SqlDataAdapter(komut);
            DataTable dB = new DataTable();

            dA.Fill(dB);
            dataGridView1.DataSource = dB;
            
        }

        private void button3_Click(object sender, EventArgs e)  //Poliklinik ve Hastalara Göre Doktor Bilgileri
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PolveHasGorDokBilg4";
            SqlDataAdapter dA = new SqlDataAdapter(komut);
            DataTable dB = new DataTable();

            dA.Fill(dB);
            dataGridView1.DataSource = dB;
            
        }

        private void button4_Click(object sender, EventArgs e)  //Doktor Ünvanına Göre Gruplandırma
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "dokUnvGoreGrup5";
            SqlDataAdapter dA = new SqlDataAdapter(komut);
            DataTable dB = new DataTable();

            dA.Fill(dB);
            dataGridView1.DataSource = dB;
        }

        private void button6_Click(object sender, EventArgs e)  //Rapor Durumuna Göre Yaş Ortalaması
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "rapdurYasOrt6";
            SqlDataAdapter sDa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sDa.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)  //Yaş Ortalaması 30'dan büyük olan Hastaların Boy Ortalaması
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "boyOrt7";
            SqlDataAdapter sDa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sDa.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)  //Boyu 160cm'den büyük olanların Yaş Ortalaması
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= con1;
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "yasort8";
            SqlDataAdapter sDa=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            sDa.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button9_Click(object sender, EventArgs e)  //İsme Göre Poliklinik Uzman Sayısı
        {
            SqlCommand cmd= new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ismGorePolUzmSayi9";
            SqlDataAdapter dA= new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            dA.Fill(dt);
            dataGridView1.DataSource=dt;
            
        }

        private void button10_Click(object sender, EventArgs e)  //Poliklinik Adına Göre Yatak Sayısı
        {
            SqlCommand cmd =new SqlCommand();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "polAdGoreYatSay10";
            cmd.Connection = con1;
            SqlDataAdapter dA= new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            dA.Fill(dt);
            dataGridView1.DataSource= dt;
        }

        private void button11_Click(object sender, EventArgs e)  //Doğum Tarihi ve Uzmanlık Alanı
        {
            SqlCommand cmd=new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DokDogTarvUzAl11";
            SqlDataAdapter dA= new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dA.Fill(dt);
            dataGridView1.DataSource= dt;
            //DokDogTarvUzAl11
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1(); //Form1= Anasayfa.cs
            frm.Show();this.Hide();
        }

        private void btn_ex_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
