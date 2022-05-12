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
    public partial class masina : Form
    {
        SqlConnection con;
        public masina()
        {   //Conectarea la baza de date 
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-DFQ1M5I\SQLEXPRESS;Initial Catalog=Compania Mea Dealer Auto;Integrated Security=True; Connect Timeout=30");
            //Introducerea imaginilor 
            pictureBox1.BackgroundImage = Image.FromFile("search.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form meniu = new eLearning2018();
            meniu.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Vizualizarea datelor in tabela Masina
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT *FROM Masina", con);
            DataTable DATA = new DataTable();
            SDA.Fill(DATA);
            dataGridView1.DataSource = DATA;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {   //Inserarea datelor in tabela Masina
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO Masina (ID_Masina,Model,Motor,Putere,Carburant,Pret,Culoare)VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox8.Text + "','" + textBox7.Text + "','" + textBox6.Text + "')", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Salvat cu succes !");
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {   //Actualizarea datelor in tabela Masina
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("UPDATE Masina SET Model='" + textBox2.Text + "',Motor='" + textBox3.Text + "',Putere='" + textBox4.Text + "',Carburant='" + textBox8.Text + "',Pret='" + textBox7.Text + "',Culoare='" + textBox6.Text + "' WHERE ID_Masina= '" + textBox1.Text + "'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("S-a facut Update cu succes !");
        }

        private void button3_Click(object sender, EventArgs e)
        {   //Stergerea datelor in tabela Masina

            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("DELETE FROM Masina WHERE ID_Masina= '" + textBox1.Text + "'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sters cu succes !");
        }
        public void searchData(string valueToFind)
        {  // cautarea datelor in tabela Masina
            string searchQuery = "SELECT * FROM Masina WHERE CONCAT(ID_Masina,Model,Motor,Putere,Carburant,Pret,Culoare) LIKE '%" + valueToFind + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {// Completarea coloanelor in mod automat atunci cand in tabela selectam o anumita informatie
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ID_Masina"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Model"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Motor"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Putere"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["Carburant"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["Pret"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["Culoare"].Value.ToString();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        { //Accesarea functiei de cautare
            searchData(textBox5.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
