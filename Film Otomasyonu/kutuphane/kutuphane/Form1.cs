using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace kutuphane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection yeni=new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\10-M\\Film Otomasyonu\\FİLM OTOMASYONU.mdb");
        public void göster() 
        {
            yeni.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Kullanıcı_adi", yeni);
            DataTable dt = new DataTable();
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            yeni.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            göster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 ileri = new Form2();
            ileri.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            yeni.Open();
            OleDbCommand Komut = new OleDbCommand("Insert into Kullanıcı_adi (KullanıcıAdı,Şifre,Yetkisi) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "')", yeni);
            Komut.ExecuteNonQuery();
            yeni.Close();
            göster();
        }
    }
}
