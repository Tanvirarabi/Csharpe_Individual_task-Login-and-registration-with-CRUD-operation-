using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-P294E5N;Initial Catalog=Loginapp;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string query = "SELECT COUNT(*) FROM loginapp WHERE username=@username AND password=@password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", txtUser.Text);
            cmd.Parameters.AddWithValue("@password", txtPass.Text);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            if (count > 0)
            {
                MessageBox.Show("login sucessfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);


    }
            else
            {
                MessageBox.Show("error in login");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
            Registration f2 = new Registration();
            f2.Show();
            Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
