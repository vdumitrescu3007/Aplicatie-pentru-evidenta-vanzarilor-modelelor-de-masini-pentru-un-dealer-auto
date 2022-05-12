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

namespace Baza_de_date
{
    public partial class clienti : Form
    {
        SqlConnection con;
        public clienti()
        {   //Conectarea la baza de date
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-DFQ1M5I\SQLEXPRESS;Initial Catalog=Compania Mea Dealer Auto;Integrated Security=True; Connect Timeout=30");

            //Inserarea unei imagini background
            pictureBox1.BackgroundImage = Image.FromFile("search.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void clienti_Load(object sender, EventArgs e)
        { 

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   //Completarea coloanelor in mod automat atunci cand in tabela selectam o anumita informatie
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ID_Client"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Nume"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Prenume"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["CNP"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Oras"].Value.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form meniu = new eLearning2018();
            meniu.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {   //Inserarea datelor in tabela Clienti
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO Client (ID_Client,Nume,Prenume,CNP,Oras)VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Salvat cu succes !");
        }

        private void button2_Click(object sender, EventArgs e)
        {   //Update-ul datelor in tabela Clienti
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("UPDATE Client SET Nume='" + textBox2.Text + "',Prenume='" + textBox3.Text + "',CNP='" + textBox4.Text + "',Oras='" + textBox5.Text + "' WHERE ID_Client= '" + textBox1.Text + "'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("S-a facut Update cu succes !");
        }

        private void button3_Click(object sender, EventArgs e)
        {   //Stergerea datelor in tabela Clienti 
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("DELETE FROM Client WHERE ID_Client= '" + textBox1.Text + "'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sters cu succes !");
        }

        private void button4_Click(object sender, EventArgs e)
        {   //Vizualizarea  datelor in tabela Clienti 
            dataGridView1.AutoGenerateColumns = true;
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM Client", con);
            DataTable DATA = new DataTable();
            SDA.Fill(DATA);
            dataGridView1.DataSource = DATA;
            con.Close();
        }

        public void searchData(string valueToFind)
        {  // Cautarea datelor in tabela Clienti 
            string searchQuery = "SELECT * FROM Client WHERE CONCAT(ID_Client,Nume,Prenume,CNP,Oras) LIKE '%" + valueToFind + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {   //Apelarea functiei pentru sortare
            searchData(textBox7.Text);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
