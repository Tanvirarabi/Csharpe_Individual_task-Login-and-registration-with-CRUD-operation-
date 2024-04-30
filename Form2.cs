using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginApplication
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-P294E5N;Initial Catalog=userregcs;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO [dbo].[register]  
                    ([firstname],        
                    [lastname],        
                    [address],      
                    [gender],       
                    [email],      
                    [phone],        
                    [username],   
                    [password]) 
                VALUES      
                    (@firstname, @lastname, @address, @gender, @email, @phone, @username, @password)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@firstname", txtFname.Text);
                    cmd.Parameters.AddWithValue("@lastname", txtLname.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@username", txtUser.Text);
                    cmd.Parameters.AddWithValue("@password", txtPass.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Show Form1 after successful registration
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide(); // Hide the current registration form

            MessageBox.Show("Registered Successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}

