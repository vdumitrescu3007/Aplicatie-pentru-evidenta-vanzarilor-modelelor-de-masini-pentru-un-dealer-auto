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
    public partial class vanzare : Form
    {   //declararea conexiunii la baza de date
        SqlConnection con;
        public vanzare()
        {   //Conectarea la baza de date
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-DFQ1M5I\SQLEXPRESS;Initial Catalog=Compania Mea Dealer Auto;Integrated Security=True; Connect Timeout=30");

            pictureBox1.BackgroundImage = Image.FromFile("search.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form meniu = new eLearning2018();
            meniu.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {   //Vizualizarea datelor in tabela Vanzare_Masina
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT *FROM Vanzare_Masina", con);
            DataTable DATA = new DataTable();
            SDA.Fill(DATA);
            dataGridView1.DataSource = DATA;
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public void searchData(string valueToFind)
        {  // cautarea datelor in tabela Vanzare_Masina
            string searchQuery = "SELECT * FROM Vanzare_Masina WHERE CONCAT(ID_Vanzare,Data_Achizitiei,Ora,ID_Client,ID_Masina,ID_Angajat) LIKE '%" + valueToFind + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }
        private void button2_Click(object sender, EventArgs e)
        {   //Inserarea datelor in tabela Vanzare_Masina
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO Vanzare_Masina (ID_Vanzare,Data_Achizitiei,Ora,ID_Client,ID_Masina,ID_Angajat)VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Salvat cu succes !");
        }

        private void button5_Click(object sender, EventArgs e)
        {   //Update-ul datelor in tabela Vanzare_Masina
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("UPDATE Vanzare_Masina SET Data_Achizitiei='" + textBox2.Text + "',Ora='" + textBox3.Text + "',ID_Client='" + textBox4.Text + "',ID_Masina='" + textBox5.Text + "',ID_Angajat='" + textBox6.Text + "' WHERE ID_Vanzare= '" + textBox1.Text + "'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("S-a facut Update cu succes !");
        }

        private void button3_Click(object sender, EventArgs e)
        {   //Stergerea datelor in tabela Vanzare_Masina
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("DELETE FROM Vanzare_Masina WHERE ID_Vanzare= '" + textBox1.Text + "'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sters cu succes !");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { // Completarea coloanelor in mod automat atunci cand in tabela selectam o anumita informatie
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ID_Vanzare"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Data_Achizitiei"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Ora"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["ID_Client"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["ID_Masina"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["ID_Angajat"].Value.ToString();
     
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {   //Accesarea functiei de cautare
            searchData(textBox7.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
