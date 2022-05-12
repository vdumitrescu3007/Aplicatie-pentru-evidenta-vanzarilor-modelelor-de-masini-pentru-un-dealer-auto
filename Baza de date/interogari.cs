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
    public partial class interogari : Form
    {
        SqlConnection con;
        public interogari()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-DFQ1M5I\SQLEXPRESS;Initial Catalog=Compania Mea Dealer Auto;Integrated Security=True; Connect Timeout=30");


        }

        public void cc()
        {
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Nume FROM Angajat";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Nume"].ToString());
            }
            con.Close();


        }
        public void dd()
        {
            comboBox2.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Model FROM Masina";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["Model"].ToString());
            }
            con.Close();
        }
        public void ee()
        {
            comboBox3.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Model FROM Masina";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox3.Items.Add(dr["Model"].ToString());
            }
            con.Close();
        }
        public void ff()
        {
            comboBox4.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Nume_Dot_Opt FROM Dotari_Opt";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox4.Items.Add(dr["Nume_Dot_Opt"].ToString());
            }
            con.Close();
        }
        public void gg()
        {
            comboBox5.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT DISTINCT Culoare FROM Masina";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox5.Items.Add(dr["Culoare"].ToString());
            }
            con.Close();
        }
        public void hh()
        {
            comboBox6.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Nume FROM Client";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox6.Items.Add(dr["Nume"].ToString());
            }
            con.Close();
        }
        public void jj()
        {
            comboBox7.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT DISTINCT Oras FROM Client";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox7.Items.Add(dr["Oras"].ToString());
            }
            con.Close();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void interogari_Load(object sender, EventArgs e)
        {
            // comenzi pentru combobox
            cc();
            dd();
            ee();
            ff();
            gg();
            hh();
            jj();
            
            
            pictureBox1.BackgroundImage = Image.FromFile("arata.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox2.BackgroundImage = Image.FromFile("arata.png");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox3.BackgroundImage = Image.FromFile("arata.png");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox4.BackgroundImage = Image.FromFile("arata.png");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox5.BackgroundImage = Image.FromFile("arata.png");
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox6.BackgroundImage = Image.FromFile("arata.png");
            pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox11.BackgroundImage = Image.FromFile("arata.png");
            pictureBox11.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox7.BackgroundImage = Image.FromFile("arata2.jpg");
            pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox8.BackgroundImage = Image.FromFile("arata2.jpg");
            pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox9.BackgroundImage = Image.FromFile("arata2.jpg");
            pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox10.BackgroundImage = Image.FromFile("arata2.jpg");
            pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;




        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form meniu = new eLearning2018();
            meniu.Show();
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Modelul cu cele mai scumpe dotari optionale    
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Model FROM Masina AS M INNER JOIN Dotari_Opt_Masina AS DOM ON DOM.ID_Masina=M.ID_Masina " +
                              "GROUP BY M.Model " +
                              "HAVING SUM(DOM.Pret)=(SELECT MAX(TABELA.SumaPreturi) AS SumaMaximaAPreturilor FROM " +
                              "(SELECT SUM(DOM1.Pret) AS SumaPreturi FROM Dotari_Opt_Masina AS DOM1 INNER JOIN Masina AS M1 ON M1.ID_Masina=DOM1.ID_Masina GROUP BY M1.ID_Masina) AS TABELA)";
            var x = cmd.ExecuteScalar();
            textBox2.Text = x.ToString();
            con.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {  // masina cu cele mai multe dotari optionale       
            con.Open();
     
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =   "SELECT M1.Model FROM Masina AS M1 " +
                                "WHERE M1.ID_Masina IN (SELECT TABELA.ID_Masina FROM (SELECT DOM.ID_Masina AS ID_Masina, COUNT(DOM.ID_Dot_Opt) AS NumarDotari FROM Dotari_Opt_Masina AS DOM " +
                                                                                    "INNER JOIN Masina M2 " +
                                                                                    "ON M2.ID_Masina=DOM.ID_Masina " +
                                                                                    "GROUP BY DOM.ID_Masina) AS TABELA " +
                                                       "WHERE TABELA.NumarDotari=(SELECT MAX(J.NRDOTARI) " +
                                                                                "FROM (SELECT ID_Masina, COUNT(ID_Dot_Opt) AS NRDOTARI FROM Dotari_Opt_Masina GROUP BY ID_Masina) AS J" +
                                                                                ")" +
                                                       ") ";
        
            var x = cmd.ExecuteScalar();
            textBox6.Text = x.ToString();
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //  Numarul total de masini vandute

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(Masina.ID_Masina) FROM Masina INNER JOIN Vanzare_Masina ON Masina.ID_Masina = Vanzare_Masina.ID_Masina";
            int x = (int)cmd.ExecuteScalar();
            textBox1.Text = x.ToString();
            con.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {   //castigul total al firmei= masina vanduta + dotari optionale masina 
            con.Open();
           

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT SUM(M.Pret) FROM Masina AS M INNER JOIN Vanzare_Masina AS VM ON M.ID_Masina=VM.ID_Masina";
            double x = (double)cmd.ExecuteScalar();
            textBox3.Text = x.ToString();
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {  
            //Cate masini a vandut angajatul X

            con.Open();
            string angajat = comboBox1.Text;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
           cmd.CommandText = " SELECT COUNT(VM.ID_Vanzare) FROM Vanzare_Masina AS VM " +
                              "INNER JOIN Angajat AS A " +
                              "ON A.ID_Angajat=VM.ID_Angajat " +
                              "WHERE A.Nume=@angajat";

            cmd.Parameters.Add("@angajat", SqlDbType.VarChar);
            cmd.Parameters["@angajat"].Value = angajat;

            int x = (int)cmd.ExecuteScalar();
            textBox5.Text = x.ToString();
            con.Close();
            
        }


        private void button4_Click(object sender, EventArgs e)
        {  // Numar masini vandute de tip ... exista in baza de date a dealer ului  _______________________________________
            con.Open();
            string model = comboBox2.Text;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
           
            cmd.CommandText =   "SELECT COUNT(M.ID_Masina) FROM Masina AS M  " +
                                "INNER JOIN Vanzare_Masina AS VM " +
                                "ON M.ID_Masina=VM.ID_Masina " +
                                "WHERE M.Model=@model";
            
            cmd.Parameters.Add("@model",SqlDbType.VarChar);
            cmd.Parameters["@model"].Value = model;
            int x = (int)cmd.ExecuteScalar();
            textBox4.Text = x.ToString();
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value.ToString();

            //Cate masini s-au vandut in data din calendar   ______________________________________________________
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(ID_Masina) FROM Vanzare_Masina " +
                               "WHERE Data_Achizitiei= @dateTimePicker1 ";   

            cmd.Parameters.Add("@dateTimePicker1", SqlDbType.DateTime);
           cmd.Parameters["@dateTimePicker1"].Value = dateTimePicker1.Value.Date;

            int x = (int)cmd.ExecuteScalar();
            textBox7.Text = x.ToString();
            con.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {  //CAte masini are proprietarul ____________________________________________________
            con.Open();
          
            string proprietar = comboBox6.Text;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(M.ID_Masina) FROM Masina AS M " +
                                "INNER JOIN Vanzare_Masina ON Vanzare_Masina.ID_Masina = M.ID_Masina " +
                                "INNER JOIN Client ON Vanzare_Masina.ID_Client=Client.ID_Client " +
                                "WHERE Client.Nume = @proprietar ";
            cmd.Parameters.Add("@proprietar", SqlDbType.VarChar);
            cmd.Parameters["@proprietar"].Value = proprietar;
            int x = (int)cmd.ExecuteScalar();
            textBox8.Text = x.ToString();
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {  // numarul masinilor de tip... care au dotarea optionala ... 
            con.Open();
            string tip = comboBox3.Text;
            string dotare = comboBox4.Text;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =   "SELECT COUNT(M.ID_Masina) FROM Masina AS M  " +
                                "INNER JOIN Dotari_Opt_Masina AS DO " +
                                "ON M.ID_Masina=DO.ID_Masina " +
                                "INNER JOIN Dotari_Opt AS DO1 " +
                                "ON DO1.ID_Dot_Opt =DO.ID_Dot_Opt " +
                                "WHERE M.Model=@tip AND DO1.Nume_Dot_Opt=@dotare " ; 
            cmd.Parameters.Add("@tip", SqlDbType.NVarChar);
            cmd.Parameters["@tip"].Value = tip;

            cmd.Parameters.Add("@dotare", SqlDbType.VarChar);
            cmd.Parameters["@dotare"].Value = dotare;

            int x = (int)cmd.ExecuteScalar();
            textBox9.Text = x.ToString();
            con.Close();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            con.Open();
            // var oras = comboBox7.SelectedValue;
            string oras = comboBox7.Text;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(TABELA.ID) FROM (SELECT Client.Oras, VM.ID_Masina AS ID FROM Vanzare_Masina AS VM " +
                                                            " INNER JOIN Client " +
                                                            "ON Client.ID_Client=VM.ID_Client) AS TABELA " +
                              "WHERE Oras=@oras";
            cmd.Parameters.Add("@oras", SqlDbType.VarChar);
            cmd.Parameters["@oras"].Value = oras;

            int x = (int)cmd.ExecuteScalar();
            textBox11.Text = x.ToString();
            con.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            con.Open();
            string culoare = comboBox5.Text;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(ID_Masina) FROM Masina WHERE ID_Masina IN (SELECT ID_Masina FROM Masina WHERE Culoare= @culoare)";
            cmd.Parameters.Add("@culoare", SqlDbType.VarChar);
            cmd.Parameters["@culoare"].Value = culoare;

            int x = (int)cmd.ExecuteScalar();
            textBox10.Text = x.ToString();
            con.Close();
        }
    }
}
