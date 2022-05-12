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
    public partial class eLearning2018 : Form
    {   SqlConnection con;
        public eLearning2018()
        {   //conectarea la baza de date
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-DFQ1M5I\SQLEXPRESS;Initial Catalog=Compania Mea Dealer Auto;Integrated Security=True; Connect Timeout=30");
            con.Open();
            }

        private void eLearning2018_Load(object sender, EventArgs e)
        {   // introducerea imaginilor
            pictureBox1.BackgroundImage = Image.FromFile("angajat.jpg");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            
            pictureBox2.BackgroundImage = Image.FromFile("clienti.png");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
           
            pictureBox3.BackgroundImage = Image.FromFile("masina3.jpg");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
           
            pictureBox4.BackgroundImage = Image.FromFile("logout.png");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox5.BackgroundImage = Image.FromFile("masina6.jpg");
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            
            pictureBox6.BackgroundImage = Image.FromFile("statistica.png");
            pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox7.BackgroundImage = Image.FromFile("dotari_opt.jpg");
            pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;

       }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   //crearea formei (design ul)
            Form meniu = new Form1();
            meniu.Show();
            this.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {    //selectarea informatiilor din table masina si accesarea/interiorul acesteia
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Masina ", this.con);

            var r = cmd.ExecuteReader();
            if (r.Read())
            {
                masina el = new masina();
                el.Show();
                this.Hide();
            }
            con.Close();
            r.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {  //selectarea informatiilor din tabla angajat si accesarea/interiorul acesteia

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Angajat ", this.con);

            var red = cmd.ExecuteReader();
            if (red.Read())
            {
                Angajat elev = new Angajat();
                elev.Show();
                this.Hide();
                }
            con.Close();
            red.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {  //selectarea informatiilor din tabla clienti si accesarea/interiorul acesteia
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Client ", this.con);

            var re = cmd.ExecuteReader();
            if (re.Read())
            {
                clienti elev10 = new clienti();
                elev10.Show();
                this.Hide();
            }
            con.Close();
            re.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {  //selectarea informatiilor din tabla Vanzare_Masina si accesarea/interiorul acesteia
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Vanzare_Masina ", this.con);

            var re = cmd.ExecuteReader();
            if (re.Read())
            {
                vanzare elev1 = new vanzare();
                elev1.Show();
                this.Hide();
            }

            con.Close();
            re.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //selectarea informatiilor din tabla Statistici si accesarea/interiorul acesteia
            interogari elev123 = new interogari();
                elev123.Show();
                this.Hide();
     
        }

        private void button6_Click(object sender, EventArgs e)
        {   //selectarea informatiilor din tabla Dotari_Opt_Masina si accesarea/interiorul acesteia
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Dotari_Opt_Masina ", this.con);

            var r = cmd.ExecuteReader();
            if (r.Read())
            {
                dotari_opt_masina el = new dotari_opt_masina();
                el.Show();
                this.Hide();
            }
            con.Close();
            r.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {   //selectarea informatiilor din tabla Dotari_Opt si accesarea/interiorul acesteia
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Dotari_Opt ", this.con);

            var r = cmd.ExecuteReader();
            if (r.Read())
            {
                dotari_opt el = new dotari_opt();
                el.Show();
                this.Hide();
            }
            con.Close();
            r.Close();
        }
    }
}
