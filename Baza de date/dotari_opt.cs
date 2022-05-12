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
    public partial class dotari_opt : Form
    {
        SqlConnection con;
        public dotari_opt()
        {   //Conectarea la baza de date
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-DFQ1M5I\SQLEXPRESS;Initial Catalog=Compania Mea Dealer Auto;Integrated Security=True; Connect Timeout=30");

            pictureBox1.BackgroundImage = Image.FromFile("search.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void dotari_opt_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   // Completarea coloanelor in mod automat atunci cand in tabela selectam o anumita informatie
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Nume_Dot_Opt"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["ID_Dot_Opt"].Value.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form meniu = new eLearning2018();
            meniu.Show();
            this.Close();
        }
        public void searchData(string valueToFind)
        {  // cautarea datelor in tabela Dotari_Opt
            string searchQuery = "SELECT * FROM Dotari_Opt WHERE CONCAT(Nume_Dot_Opt,ID_Dot_Opt) LIKE '%" + valueToFind + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {   //apelarea functiei pentru cautare
            searchData(textBox7.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {   //Inserarea datelor in tabela Dotari_Opt
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO Dotari_Opt (Nume_Dot_Opt,ID_Dot_Opt)VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Salvat cu succes !");
        }

        private void button2_Click(object sender, EventArgs e)
        {   //Actualizarea datelor in tabela Dotari_Opt
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("UPDATE Dotari_Opt SET ID_Dot_Opt='" + textBox2.Text + "' WHERE Nume_Dot_Opt= '" + textBox1.Text + "'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("S-a facut Update cu succes !");
        }

        private void button3_Click(object sender, EventArgs e)
        {   //Stergerea datelor in tabela Dotari_Opt
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("DELETE FROM Dotari_Opt WHERE ID_Dot_Opt= '" + textBox2.Text + "'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sters cu succes !");
        }

        private void button4_Click(object sender, EventArgs e)
        {   //Vizualizarea datelor in tabela Dotari_Opt
            dataGridView1.AutoGenerateColumns = true;
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM Dotari_Opt ", con);
            DataTable DATA = new DataTable();
            SDA.Fill(DATA);
            dataGridView1.DataSource = DATA;
            con.Close();
        }
    }
}
