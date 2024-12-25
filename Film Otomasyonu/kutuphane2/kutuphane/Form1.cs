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
        OleDbConnection yeni=new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\ÖĞRENCİ\\Desktop\\Muhammed Kerem Doğmuş\\Film Otomasyonu\\FİLM OTOMASYONU.mdb");
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

        private void button4_Click(object sender, EventArgs e)
        {
            yeni.Open();
            OleDbCommand komut = new OleDbCommand("Delete From Kullanıcı_adi Where KullanıcıAdı='" + textBox1.Text + "'", yeni);
            komut.ExecuteNonQuery();
            yeni.Close();
            göster();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
