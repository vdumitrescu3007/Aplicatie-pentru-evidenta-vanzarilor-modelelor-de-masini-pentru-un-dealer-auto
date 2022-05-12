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
    public partial class dotari_opt_masina : Form
    {
        SqlConnection con;
        public dotari_opt_masina()
        {   //conectarea la baza de date
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-DFQ1M5I\SQLEXPRESS;Initial Catalog=Compania Mea Dealer Auto;Integrated Security=True; Connect Timeout=30");
            //introducerea imaginii pentru butonul search
            pictureBox1.BackgroundImage = Image.FromFile("search.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {// Completarea coloanelor in mod automat atunci cand in tabela selectam o anumita informatie
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ID_Dot_Opt"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["ID_Masina"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Pret"].Value.ToString();
                
            }
        }

        private void dotari_opt_masina_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form meniu = new eLearning2018();
            meniu.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {   //Inserarea  datelor in tabela Dot_Opt_Masina
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO Dotari_Opt_Masina (ID_Dot_Opt,ID_Masina,Pret)VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Salvat cu succes !");
        }

        private void button2_Click(object sender, EventArgs e)
        {   //Actualizarea datelor in tabela Dot_Opt_Masina
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("UPDATE Dotari_Opt_Masina SET ID_Masina='" + textBox2.Text + "',Pret='" + textBox3.Text + "' WHERE ID_Dot_Opt= '" + textBox1.Text + "'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("S-a facut Update cu succes !");
        }

        private void button3_Click(object sender, EventArgs e)
        {   //Stergerea  datelor in tabela Dot_Opt_Masina
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("DELETE FROM Dotari_Opt_Masina WHERE ID_Dot_Opt= '" + textBox1.Text + "'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sters cu succes !");
        }

        private void button4_Click(object sender, EventArgs e)
        {   //Vizalizarea  datelor in tabela Dot_Opt_Masina
            dataGridView1.AutoGenerateColumns = true;
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM Dotari_Opt_Masina ", con);
            DataTable DATA = new DataTable();
            SDA.Fill(DATA);
            // MessageBox.Show(DATA.Rows.Count.ToString());
            dataGridView1.DataSource = DATA;
            con.Close();
        }

        public void searchData(string valueToFind)
        {  // cautarea datelor in tabela Dot_Opt_Masina
            string searchQuery = "SELECT * FROM Dotari_Opt_Masina WHERE CONCAT(ID_Dot_Opt,ID_Masina,Pret) LIKE '%" + valueToFind + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {//Apelarea functiei de cautare 
            searchData(textBox7.Text);
        }
    }
}
