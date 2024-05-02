using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Zoopark
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            string username = textBox4.Text; // Используем textBox4 для имени пользователя
            string password = textBox3.Text; // Используем textBox3 для пароля

            bool success = RegisterUser(username, password);
            if (success)
            {
                // Если регистрация прошла успешно, переходим на Form1
                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Hide(); // Скрываем текущую форму (Form2)
            }
            else
            {
                // Если регистрация не удалась, показываем сообщение об ошибке
                MessageBox.Show("Registration failed. Please check the data and try again.");
            }
        }

        private bool RegisterUser(string username, string password)
        {
            string connectionString = "Server=localhost\\MSSQLSERVER01; Database=ZooDB; Trusted_Connection=True;";
            string query = "INSERT INTO authorize (login, password) VALUES (@username, @hashedPassword)";
            bool isRegistered = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@hashedPassword", ComputeSha256Hash(password));

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0) // Если запрос добавил одну строку, значит регистрация прошла успешно
                    {
                        isRegistered = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during registration: " + ex.Message);
                    isRegistered = false;
                }
            }
            return isRegistered;
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

        
    }
}
