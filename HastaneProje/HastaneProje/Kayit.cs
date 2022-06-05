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
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
            
        }
        SqlConnection con1 = new SqlConnection("Server=.;Database=Hastane;Integrated Security=true");

        private void lnk_signUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void btn_login_Click(object sender, EventArgs e) 
        {

            if (login())
            {
                Form1 anasayfa = new Form1();
                anasayfa.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş. Tekrar Deneyiniz.");
                textBox1.Clear();
                textBox2.Clear();
            }
            con1.Close();
        }
        public bool UserKontrol()
        {
            try
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = con1;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "kullaniciUserNameKontrol";
                komut.Parameters.AddWithValue("kulAd", txt_newUserName.Text );
                con1.Open();
                SqlDataReader dr;
                dr = komut.ExecuteReader();
                if (dr.HasRows)
                {
                    return true;
                }
                
                    return false;
            }catch (Exception)
            {
                return false;
            }
            finally
            {
                con1.Close();
            }
                
                
        }
        private void btn_userAdd_Click(object sender, EventArgs e) 
        {
            if (UserKontrol())
            {
                MessageBox.Show("Bu kullanıcı adı alınmış. Başka bir kullanıcı adı giriniz.");
            }
            else
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = con1;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "kulKayit";
                con1.Open();
                komut.Parameters.AddWithValue("KulAd", txt_newUserName.Text);
                komut.Parameters.AddWithValue("Sifre", txt_newUserPswrd.Text);
                komut.Parameters.AddWithValue("mail", txt_newUsermail.Text);
                komut.Parameters.AddWithValue("telefon", txt_newUserPhone.Text);

                komut.ExecuteNonQuery();
                con1.Close();
                MessageBox.Show("Kayıt Başarılı");
            }
            
            
        }
       public bool login()
        {
            try { 
            SqlCommand komut = new SqlCommand();
            komut.Connection = con1;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "kullaniciList";
            komut.Parameters.AddWithValue("kulAd", textBox1.Text);
            komut.Parameters.AddWithValue("sifre", textBox2.Text);
            con1.Open();
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            else
                return false;
            }catch (Exception)
            {
                return false;
            }
            finally {con1.Close(); }
            
        }
    }
}
