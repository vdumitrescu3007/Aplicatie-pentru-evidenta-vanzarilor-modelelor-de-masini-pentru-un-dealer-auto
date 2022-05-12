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
    
    public partial class Angajat : Form
    {
        SqlConnection con;
        public Angajat()
        {
            InitializeComponent();
            //Conectarea la baza de date
            con = new SqlConnection(@"Data Source=DESKTOP-DFQ1M5I\SQLEXPRESS;Initial Catalog=Compania Mea Dealer Auto;Integrated Security=True; Connect Timeout=30");


            pictureBox1.BackgroundImage = Image.FromFile("search.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void button2_Click(object sender, EventArgs e)
        {   //Inserarea  datelor in tabela Angajat
            con.Open();
            SqlDataAdapter SDA= new SqlDataAdapter("INSERT INTO Angajat (ID_Angajat,Nume,Prenume,CNP,Oras,Salariu,Data_Angajarii,ParolaUtilizator,EmailUtilizator )VALUES ('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox9.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')",con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Salvat cu succes !");
        }

        private void button5_Click(object sender, EventArgs e)
        {   //Actualizarea datelor in tabela Angajat
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("UPDATE Angajat SET Nume='" + textBox2.Text + "',Prenume='" + textBox9.Text + "',CNP='" + textBox3.Text + "',Oras='" + textBox4.Text + "',Salariu='" + textBox5.Text + "',Data_Angajarii='" + textBox6.Text + "',ParolaUtilizator='" + textBox7.Text + "',EmailUtilizator ='" + textBox8.Text + "' WHERE ID_Angajat= '" + textBox1.Text + "'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("S-a facut Update cu succes !");
        }

        private void button6_Click(object sender, EventArgs e)
        {   //Vizalizarea datelor in tabela Angajat
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT *FROM Angajat", con);
            DataTable DATA = new DataTable();
            SDA.Fill(DATA);
            dataGridView1.DataSource = DATA;
            con.Close();
            
            
        }

        private void Angajat_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {   //Atribuirea datelor din textBox cu coloanele din dataGridView
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {   //Stergerea datelor in tabela Angajat
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("DELETE FROM Angajat WHERE ID_Angajat= '" + textBox1.Text+"'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sters cu succes !");
        }

        public void searchData(string valueToFind)
        {  // cautarea datelor in tabela Angajat
            string searchQuery = "SELECT * FROM Angajat WHERE CONCAT(ID_Angajat,Nume,Prenume,CNP,Oras,Salariu,Data_Angajarii,ParolaUtilizator,EmailUtilizator) LIKE '%" + valueToFind + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(searchQuery,con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource= table;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form meniu = new eLearning2018();
            meniu.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Completarea coloanelor in mod automat atunci cand in tabela selectam o anumita informatie
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ID_Angajat"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Nume"].Value.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["Prenume"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["CNP"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Oras"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Salariu"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["Data_Angajarii"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["EmailUtilizator"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["ParolaUtilizator"].Value.ToString();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            searchData(textBox10.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
