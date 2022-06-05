using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //poliklinik
        {

            Poliklinik p1=new Poliklinik();
            this.Hide();
            p1.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)  //hastalar
        {
            Hastalar h1= new Hastalar();
            this.Hide();
            h1.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)  //raporlar
        {
            Raporlar rapor=new Raporlar();
            this.Hide();
            rapor.Show();
        }

        private void button2_Click(object sender, EventArgs e) //doktorlar
        {
            Doktorlar d1= new Doktorlar();
            this.Hide();  
            d1.Show();
            
        }
    }
}
