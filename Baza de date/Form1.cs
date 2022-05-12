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
    public partial class Form1 : Form
    {
        SqlConnection con;
        public Form1()
        {   // conectarea la baza de date
            InitializeComponent();

            con = new SqlConnection(@"Data Source=DESKTOP-DFQ1M5I\SQLEXPRESS;Initial Catalog=Compania Mea Dealer Auto;Integrated Security=True; Connect Timeout=30");
            con.Open();
        }

       private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {   //Introducerea imaginilor 
            pictureBox1.BackgroundImage = Image.FromFile("login.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;


            pictureBox2.BackgroundImage = Image.FromFile("masina7.jpg");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Introducerea parolei si email ul utilizatorului , crearea unor expresii lambda pentru acestea
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Angajat WHERE EmailUtilizator = @email AND ParolaUtilizator = @parola", con);
            cmd.Parameters.AddWithValue("@email", textBox1.Text);
            cmd.Parameters.AddWithValue("@parola", textBox2.Text);
            
            var red=cmd.ExecuteReader();

            if (red.Read())
            {
                eLearning2018 elev = new eLearning2018(); 
                elev.Show();
                this.Hide();
                elev.FormClosed += (a, b) =>
                 {
                     this.Show();
                     textBox1.Text = textBox2.Text = "";
                 };
            }
            else MessageBox.Show("Eroare de autentificare!");
            red.Close();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {   // butonul de exit
            this.Close();
        }
    }
}
