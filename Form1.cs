using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography; 
using System.Text;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Zoopark
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Установка символа пароля на звездочку
            txtPassword.PasswordChar = '*';
        }

        private bool AuthenticateUser(string username, string password)
        {
            string connectionString = "Server=localhost\\MSSQLSERVER01; Database=ZooDB; Trusted_Connection=True;";
            string query = "SELECT password FROM authorize WHERE login = @username";
            bool isAuthenticated = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);

                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["password"].ToString();
                            isAuthenticated = VerifyHashedPassword(storedPassword, password);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    isAuthenticated = false;
                }
            }
            return isAuthenticated;
        }

        private bool VerifyHashedPassword(string storedPassword, string inputPassword)
        {
            string hashedInputPassword = ComputeSha256Hash(inputPassword);
            return storedPassword.Equals(hashedInputPassword);
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtLogin.Text;
            string password = txtPassword.Text;
            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Login successful!");

                // Закрываем текущую форму и открываем Form3
                Form3 form3 = new Form3(); // Создаем экземпляр Form3
                form3.Show(); // Показываем Form3
                this.Hide(); // Закрываем текущую форму (Form1)
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form2 registrationForm = new Form2();
            registrationForm.Show();
            this.Hide(); // Это скроет текущую форму (Form1), если вам нужно только показать Form2
        }

    }
}
