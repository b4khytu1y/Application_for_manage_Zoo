using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Excel = Microsoft.Office.Interop.Excel;

namespace Zoopark
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            tabControl1.TabPages[0].Text = "Family";
            tabControl1.TabPages[1].Text = "Type";
            tabControl1.TabPages[2].Text = "Accommodation";
            tabControl1.TabPages[3].Text = "Placement";
            tabControl1.TabPages[4].Text = "Staff";
            tabControl1.TabPages[5].Text = "VeterinaryRecord";
            tabControl1.TabPages[6].Text = "VisitorInteraction";
 
        }
        private string connectionString = "Server=localhost\\MSSQLSERVER01; Database=ZooDB; Trusted_Connection=True;";
      
        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Create Button
        {
            string title = textBox1.Text; // Title
            string continent = textBox2.Text; // Continent
            string habitat = textBox3.Text; // Habitat

            using (SqlConnection con = GetConnection())
            {
                string query = "INSERT INTO Family (Title, Continent, Habitat) VALUES (@Title, @Continent, @Habitat)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Continent", continent);
                cmd.Parameters.AddWithValue("@Habitat", habitat);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Family added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding family: " + ex.Message);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e) // Read Button
        {
            using (SqlConnection con = GetConnection())
            {
                // Измененный запрос для включения ID
                string query = "SELECT FamilyID, Title, Continent, Habitat FROM Family";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Предположим, что у вас есть DataGridView с именем dataGridView1
                dataGridView1.DataSource = dt;
            }
        }



        private void button3_Click(object sender, EventArgs e) // Update Button
        {
            // Получаем значения из TextBox
            int familyId = int.Parse(textBox4.Text); // Предполагаем, что textBox4 это поле для ID
            string title = textBox1.Text; // Title
            string continent = textBox2.Text; // Continent
            string habitat = textBox3.Text; // Habitat

            using (SqlConnection con = GetConnection())
            {
                // Обновляем запрос, чтобы обновление шло по ID
                string query = "UPDATE Family SET Title=@Title, Continent=@Continent, Habitat=@Habitat WHERE FamilyID=@FamilyID";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FamilyID", familyId);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Continent", continent);
                cmd.Parameters.AddWithValue("@Habitat", habitat);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Family updated successfully.");
                    else
                        MessageBox.Show("No record found with the provided ID.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating family: " + ex.Message);
                }
            }
        }



        private void button4_Click(object sender, EventArgs e) // Delete Button
        {
            string title = textBox1.Text; // Title

            using (SqlConnection con = GetConnection())
            {
                string query = "DELETE FROM Family WHERE Title=@Title";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", title);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Family deleted successfully.");
                    else
                        MessageBox.Show("Family not found.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting family: " + ex.Message);
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Это может быть запрос на агрегацию, например, количество типов в каждой семье
            using (SqlConnection con = GetConnection())
            {
                string query = @"
        SELECT f.Title, COUNT(t.TypeID) AS TotalTypes
        FROM Family f
        INNER JOIN Type t ON f.FamilyID = t.FamilyID
        GROUP BY f.Title";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView2.DataSource = dt; // Отображаем агрегированные данные
            }
        }


        private void button8_Click(object sender, EventArgs e) // Delete Button for Type
        {
            int typeId = int.Parse(textBox5.Text); // Поле для TypeID

            using (SqlConnection con = GetConnection())
            {
                string query = "DELETE FROM Type WHERE TypeID=@TypeID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TypeID", typeId);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Type deleted successfully.");
                    else
                        MessageBox.Show("Type not found.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting type: " + ex.Message);
                }
            }
        }


        private void button5_Click(object sender, EventArgs e) // Create Button for Type
        {
            string title = textBox6.Text; // Предположим, что textBoxTitle - это поле для Title
            decimal dailyFeedIntake = decimal.Parse(textBox7.Text); // Поле для DailyFeedIntake
            int familyId = int.Parse(textBox8.Text); // Поле для FamilyID

            using (SqlConnection con = GetConnection())
            {
                string query = "INSERT INTO Type (Title, DailyFeedIntake, FamilyID) VALUES (@Title, @DailyFeedIntake, @FamilyID)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@DailyFeedIntake", dailyFeedIntake);
                cmd.Parameters.AddWithValue("@FamilyID", familyId);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Type added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding type: " + ex.Message);
                }
            }
        }


        private void button6_Click(object sender, EventArgs e) // Read Button for Type
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "SELECT TypeID, Title, DailyFeedIntake, FamilyID FROM Type";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView2.DataSource = dt; // Предположим, что dataGridViewType - это имя вашего DataGridView
            }
        }


        private void button7_Click(object sender, EventArgs e) // Update Button for Type
        {
            int typeId = int.Parse(textBox5.Text); // Поле для TypeID
            string title = textBox6.Text; // Предположим, что textBoxTitle - это поле для Title
            decimal dailyFeedIntake = decimal.Parse(textBox7.Text); // Поле для DailyFeedIntake
            int familyId = int.Parse(textBox8.Text); // Поле для FamilyID

            using (SqlConnection con = GetConnection())
            {
                string query = "UPDATE Type SET Title=@Title, DailyFeedIntake=@DailyFeedIntake, FamilyID=@FamilyID WHERE TypeID=@TypeID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TypeID", typeId);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@DailyFeedIntake", dailyFeedIntake);
                cmd.Parameters.AddWithValue("@FamilyID", familyId);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Type updated successfully.");
                    else
                        MessageBox.Show("Type not found.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating type: " + ex.Message);
                }
            }
        }


 


        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e) // Create Button for Accommodation
        {
            int typeId = int.Parse(textBox9.Text); // Предполагаем, что textBox9 - это поле для TypeID
            int amountOfAnimals = int.Parse(textBox10.Text); // Поле для AmountOfAnimals

            using (SqlConnection con = GetConnection())
            {
                string query = "INSERT INTO Accommodation (TypeID, AmountOfAnimals) VALUES (@TypeID, @AmountOfAnimals)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TypeID", typeId);
                cmd.Parameters.AddWithValue("@AmountOfAnimals", amountOfAnimals);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accommodation added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding accommodation: " + ex.Message);
                }
            }
        }


        private void button11_Click(object sender, EventArgs e) // Read Button for Accommodation
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "SELECT AccommodationID, TypeID, AmountOfAnimals FROM Accommodation";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView3.DataSource = dt; // Предполагаем, что dataGridView3 - это ваш DataGridView
            }
        }


        private void button12_Click(object sender, EventArgs e) // Update Button for Accommodation
        {
            int accommodationId = int.Parse(textBox11.Text); // Поле для AccommodationID
            int typeId = int.Parse(textBox9.Text);
            int amountOfAnimals = int.Parse(textBox10.Text);

            using (SqlConnection con = GetConnection())
            {
                string query = "UPDATE Accommodation SET TypeID=@TypeID, AmountOfAnimals=@AmountOfAnimals WHERE AccommodationID=@AccommodationID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AccommodationID", accommodationId);
                cmd.Parameters.AddWithValue("@TypeID", typeId);
                cmd.Parameters.AddWithValue("@AmountOfAnimals", amountOfAnimals);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Accommodation updated successfully.");
                    else
                        MessageBox.Show("Accommodation not found.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating accommodation: " + ex.Message);
                }
            }
        }


        private void button13_Click(object sender, EventArgs e) // Delete Button for Accommodation
        {
            int accommodationId = int.Parse(textBox11.Text); // Поле для AccommodationID

            using (SqlConnection con = GetConnection())
            {
                string query = "DELETE FROM Accommodation WHERE AccommodationID=@AccommodationID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AccommodationID", accommodationId);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Accommodation deleted successfully.");
                    else
                        MessageBox.Show("Accommodation not found.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting accommodation: " + ex.Message);
                }
            }
        }


        private void button14_Click(object sender, EventArgs e) // Button for Showing Accommodation with Type Information
        {
            using (SqlConnection con = GetConnection())
            {
                string query = @"
        SELECT a.AccommodationID, a.AmountOfAnimals, t.Title, t.DailyFeedIntake
        FROM Accommodation a
        JOIN Type t ON a.TypeID = t.TypeID";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView3.DataSource = dt; // Отображаем связанные данные
            }
        }
        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }



        private void button15_Click(object sender, EventArgs e) // Create Button for Placement
        {
            string name = textBox13.Text;
            if (!int.TryParse(textBox14.Text, out int noOfPlacement) ||
                !int.TryParse(textBox15.Text, out int accommodationId))
            {
                MessageBox.Show("Please enter valid numbers for No of Placement and Accommodation ID.");
                return;
            }

            bool presenceOfReservoir = checkBox1.Checked;
            bool presenceOfHeating = checkBox2.Checked;

            using (SqlConnection con = GetConnection())
            {
                string query = "INSERT INTO Placement (Name, NoOfPlacement, PresenceOfReservoir, PresenceOfHeating, AccommodationID) VALUES (@Name, @NoOfPlacement, @PresenceOfReservoir, @PresenceOfHeating, @AccommodationID)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@NoOfPlacement", noOfPlacement);
                cmd.Parameters.AddWithValue("@PresenceOfReservoir", presenceOfReservoir);
                cmd.Parameters.AddWithValue("@PresenceOfHeating", presenceOfHeating);
                cmd.Parameters.AddWithValue("@AccommodationID", accommodationId);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Placement added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding placement: " + ex.Message);
                }
            }
        }



        private void button16_Click(object sender, EventArgs e) // Read Button for Placement
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "SELECT PlacementID, Name, NoOfPlacement, PresenceOfReservoir, PresenceOfHeating, AccommodationID FROM Placement";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView4.DataSource = dt; // Предположим, что dataGridView4 - это ваш DataGridView
            }
        }




        private void button17_Click(object sender, EventArgs e) // Update Button for Placement
        {
            int placementId = int.Parse(textBox12.Text); // Поле для PlacementID
            string name = textBox13.Text;
            int noOfPlacement = int.Parse(textBox14.Text);
            bool presenceOfReservoir = checkBox1.Checked;
            bool presenceOfHeating = checkBox2.Checked;
            int accommodationId = int.Parse(textBox15.Text);

            using (SqlConnection con = GetConnection())
            {
                string query = "UPDATE Placement SET Name=@Name, NoOfPlacement=@NoOfPlacement, PresenceOfReservoir=@PresenceOfReservoir, PresenceOfHeating=@PresenceOfHeating, AccommodationID=@AccommodationID WHERE PlacementID=@PlacementID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PlacementID", placementId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@NoOfPlacement", noOfPlacement);
                cmd.Parameters.AddWithValue("@PresenceOfReservoir", presenceOfReservoir);
                cmd.Parameters.AddWithValue("@PresenceOfHeating", presenceOfHeating);
                cmd.Parameters.AddWithValue("@AccommodationID", accommodationId);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Placement updated successfully.");
                    else
                        MessageBox.Show("Placement not found.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating placement: " + ex.Message);
                }
            }
        }

        private void button18_Click(object sender, EventArgs e) // Delete Button for Placement
        {
            int placementId = int.Parse(textBox12.Text); // Поле для PlacementID

            using (SqlConnection con = GetConnection())
            {
                string query = "DELETE FROM Placement WHERE PlacementID=@PlacementID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PlacementID", placementId);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Placement deleted successfully.");
                    else
                        MessageBox.Show("Placement not found.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting placement: " + ex.Message);
                }
            }
        }


        private void button19_Click(object sender, EventArgs e) // Show Placement with Accommodation Info
        {
            using (SqlConnection con = GetConnection())
            {
                string query = @"
SELECT p.PlacementID, p.Name, p.NoOfPlacement, p.PresenceOfReservoir, p.PresenceOfHeating, a.TypeID
FROM Placement p
JOIN Accommodation a ON p.AccommodationID = a.AccommodationID
WHERE p.PresenceOfReservoir = 1 AND p.PresenceOfHeating = 1"; // Добавлено условие для фильтрации по обеим галочкам

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView4.DataSource = dt; // Отображаем связанные данные
            }
        }



        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox14_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView5_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверяем, что мы в правильной колонке (адаптируйте индекс колонки, если необходимо)
            if (dataGridView5.Columns[e.ColumnIndex].Name == "Picture" && e.Value != null)
            {
                byte[] bytes = (byte[])e.Value;
                using (var ms = new MemoryStream(bytes))
                {
                    e.Value = Image.FromStream(ms);
                }
            }
        }
        private void SetupDataGridView()
        {
            dataGridView5.AutoGenerateColumns = false; // Если вы используете автогенерацию, отключите её
            dataGridView5.Columns["Picture"].DefaultCellStyle.NullValue = null; // Обрабатываем null значения
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; // Авто-размер колонок
        }

        private void textBox16_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox19_TextChanged_1(object sender, EventArgs e)
        {

        }




        private void button20_Click(object sender, EventArgs e) // Add Staff
        {
            string firstName = textBox17.Text; // FirstName
            string lastName = textBox18.Text; // LastName
            bool role = radioButton1.Checked; // Hired if checked, Permanent otherwise
            string department = textBox19.Text; // Department
            byte[] picture = ImageToByte(pictureBox1.Image); // Convert image in PictureBox to byte array

            using (SqlConnection con = GetConnection())
            {
                string query = "INSERT INTO Staff (FirstName, LastName, Role, Department, Picture) VALUES (@FirstName, @LastName, @Role, @Department, @Picture)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@Department", department);
                cmd.Parameters.AddWithValue("@Picture", picture);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding staff: " + ex.Message);
                }
            }
        }

        private byte[] ImageToByte(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }


        private void button21_Click(object sender, EventArgs e) // Load Staff
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "SELECT StaffID, FirstName, LastName, Role, Department, Picture FROM Staff";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView5.DataSource = dt; // Assuming dataGridView5 is your DataGridView

                // Добавим колонку изображений, если она ещё не добавлена
                if (!dataGridView5.Columns.Contains("ImageColumn"))
                {
                    DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                    imgCol.Name = "ImageColumn";
                    imgCol.HeaderText = "Picture";
                    imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch; // Обеспечиваем, чтобы изображение растягивалось на весь размер ячейки
                    dataGridView5.Columns.Add(imgCol);
                }

                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    if (row.Cells["Picture"].Value != DBNull.Value)
                    {
                        try
                        {
                            byte[] bytes = (byte[])row.Cells["Picture"].Value;
                            using (var ms = new MemoryStream(bytes))
                            {
                                row.Cells["ImageColumn"].Value = Image.FromStream(ms);
                            }
                        }
                        catch
                        {
                            row.Cells["ImageColumn"].Value = null; // В случае ошибки не отображаем ничего
                        }
                    }
                }

                // Скрываем столбец с байтами
                dataGridView5.Columns["Picture"].Visible = false;
            }
        }


        private void button22_Click(object sender, EventArgs e) // Update Staff
        {
            int staffId = int.Parse(textBox16.Text); // StaffID
            string firstName = textBox17.Text;
            string lastName = textBox18.Text;
            bool role = radioButton1.Checked;
            string department = textBox19.Text;
            byte[] picture = ImageToByte(pictureBox1.Image);

            using (SqlConnection con = GetConnection())
            {
                string query = "UPDATE Staff SET FirstName=@FirstName, LastName=@LastName, Role=@Role, Department=@Department, Picture=@Picture WHERE StaffID=@StaffID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StaffID", staffId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@Department", department);
                cmd.Parameters.AddWithValue("@Picture", picture);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Staff updated successfully.");
                    else
                        MessageBox.Show("Staff not found.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating staff: " + ex.Message);
                }
            }
        }


        private void button23_Click(object sender, EventArgs e) // Delete Staff
        {
            int staffId = int.Parse(textBox16.Text); // StaffID

            using (SqlConnection con = GetConnection())
            {
                string query = "DELETE FROM Staff WHERE StaffID=@StaffID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StaffID", staffId);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Staff deleted successfully.");
                    else
                        MessageBox.Show("Staff not found.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting staff: " + ex.Message);
                }
            }
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Загрузка изображения в PictureBox
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить изображение: " + ex.Message);
                }
            }
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT AccommodationID FROM Accommodation", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox1.DisplayMember = "AccommodationID"; // Теперь используется для отображения
                comboBox1.ValueMember = "AccommodationID";   // Используется для значения
                comboBox1.DataSource = dt;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT StaffID FROM Staff", con); // Изменено для выборки только StaffID
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox2.DisplayMember = "StaffID";  // Теперь отображаем только ID сотрудника
                comboBox2.ValueMember = "StaffID";    // Используем ID в качестве значения
                comboBox2.DataSource = dt;
            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            int animalId = Convert.ToInt32(comboBox1.SelectedValue);  // Предполагаем, что comboBox1 связан с AnimalID
            int staffId = Convert.ToInt32(comboBox2.SelectedValue);  // Предполагаем, что comboBox2 связан с StaffID
            string diagnosis = textBox21.Text;
            string treatment = textBox22.Text;
            DateTime treatmentDate = dateTimePicker1.Value;

            using (SqlConnection con = GetConnection())
            {
                string query = @"INSERT INTO VeterinaryRecord (AnimalID, StaffID, Diagnosis, Treatment, TreatmentDate)
                         VALUES (@AnimalID, @StaffID, @Diagnosis, @Treatment, @TreatmentDate)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AnimalID", animalId);
                cmd.Parameters.AddWithValue("@StaffID", staffId);
                cmd.Parameters.AddWithValue("@Diagnosis", diagnosis);
                cmd.Parameters.AddWithValue("@Treatment", treatment);
                cmd.Parameters.AddWithValue("@TreatmentDate", treatmentDate);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add record: " + ex.Message);
                }
            }
        }


        private void button26_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "SELECT * FROM VeterinaryRecord";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView6.DataSource = dt;
            }
        }


        private void button27_Click(object sender, EventArgs e)
        {
            int recordId = int.Parse(textBox20.Text);
            int animalId = Convert.ToInt32(comboBox1.SelectedValue);
            int staffId = Convert.ToInt32(comboBox2.SelectedValue);
            string diagnosis = textBox21.Text;
            string treatment = textBox22.Text;
            DateTime treatmentDate = dateTimePicker1.Value;

            using (SqlConnection con = GetConnection())
            {
                string query = @"UPDATE VeterinaryRecord 
                         SET AnimalID = @AnimalID, StaffID = @StaffID, Diagnosis = @Diagnosis, Treatment = @Treatment, TreatmentDate = @TreatmentDate
                         WHERE RecordID = @RecordID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RecordID", recordId);
                cmd.Parameters.AddWithValue("@AnimalID", animalId);
                cmd.Parameters.AddWithValue("@StaffID", staffId);
                cmd.Parameters.AddWithValue("@Diagnosis", diagnosis);
                cmd.Parameters.AddWithValue("@Treatment", treatment);
                cmd.Parameters.AddWithValue("@TreatmentDate", treatmentDate);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Record updated successfully.");
                    else
                        MessageBox.Show("No record found with the specified ID.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update record: " + ex.Message);
                }
            }
        }


        private void button28_Click(object sender, EventArgs e)
        {
            int recordId = int.Parse(textBox20.Text);

            using (SqlConnection con = GetConnection())
            {
                string query = "DELETE FROM VeterinaryRecord WHERE RecordID = @RecordID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RecordID", recordId);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Record deleted successfully.");
                    else
                        MessageBox.Show("No record found with the specified ID.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete record: " + ex.Message);
                }
            }
        }


        private void button29_Click(object sender, EventArgs e)
        {
            // Очистка всех полей формы
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox21.Clear();
            textBox22.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }


        private void button30_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i < dataGridView6.Columns.Count; i++)
            {
                xlWorkSheet.Cells[1, i + 1] = dataGridView6.Columns[i].HeaderText;
            }

            for (int i = 0; i < dataGridView6.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView6.Columns.Count; j++)
                {
                    xlWorkSheet.Cells[i + 2, j + 1] = dataGridView6.Rows[i].Cells[j].Value?.ToString() ?? "";
                }
            }

            xlApp.Visible = true;

        }


        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e) // Create button
        {
            int visitorId = int.Parse(textBox24.Text); // Предполагаем, что textBox24 связан с VisitorID
            int placementId = int.Parse(textBox25.Text); // Предполагаем, что textBox25 связан с PlacementID
            string comments = textBox26.Text; // Комментарии
            DateTime interactionDate = dateTimePicker2.Value; // Дата взаимодействия

            using (SqlConnection con = GetConnection())
            {
                string query = "INSERT INTO VisitorInteraction (VisitorID, PlacementID, Comments, InteractionDate) VALUES (@VisitorID, @PlacementID, @Comments, @InteractionDate)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@VisitorID", visitorId);
                cmd.Parameters.AddWithValue("@PlacementID", placementId);
                cmd.Parameters.AddWithValue("@Comments", comments);
                cmd.Parameters.AddWithValue("@InteractionDate", interactionDate);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Interaction added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add interaction: " + ex.Message);
                }
            }
        }


        private void button32_Click(object sender, EventArgs e) // Read button
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "SELECT * FROM VisitorInteraction";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView7.DataSource = dt; // Предположим, что dataGridView7 - это ваш DataGridView
            }
        }


        private void button33_Click(object sender, EventArgs e) // Update button
        {
            int interactionId = int.Parse(textBox23.Text); // Предполагаем, что textBox23 связан с InteractionID
            int visitorId = int.Parse(textBox24.Text);
            int placementId = int.Parse(textBox25.Text);
            string comments = textBox26.Text;
            DateTime interactionDate = dateTimePicker2.Value;

            using (SqlConnection con = GetConnection())
            {
                string query = "UPDATE VisitorInteraction SET VisitorID = @VisitorID, PlacementID = @PlacementID, Comments = @Comments, InteractionDate = @InteractionDate WHERE InteractionID = @InteractionID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@InteractionID", interactionId);
                cmd.Parameters.AddWithValue("@VisitorID", visitorId);
                cmd.Parameters.AddWithValue("@PlacementID", placementId);
                cmd.Parameters.AddWithValue("@Comments", comments);
                cmd.Parameters.AddWithValue("@InteractionDate", interactionDate);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Interaction updated successfully.");
                    else
                        MessageBox.Show("No interaction found with the specified ID.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update interaction: " + ex.Message);
                }
            }
        }


        private void button34_Click(object sender, EventArgs e) // Delete button
        {
            int interactionId = int.Parse(textBox23.Text); // Предполагаем, что textBox23 связан с InteractionID

            using (SqlConnection con = GetConnection())
            {
                string query = "DELETE FROM VisitorInteraction WHERE InteractionID = @InteractionID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@InteractionID", interactionId);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Interaction deleted successfully.");
                    else
                        MessageBox.Show("No interaction found with the specified ID.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete interaction: " + ex.Message);
                }
            }
        }


        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click_1(object sender, EventArgs e) // Create button
        {
            int visitorId = int.Parse(textBox24.Text); // Предполагаем, что textBox24 связан с VisitorID
            int placementId = int.Parse(textBox25.Text); // Предполагаем, что textBox25 связан с PlacementID
            string comments = textBox26.Text; // Комментарии
            DateTime interactionDate = dateTimePicker2.Value; // Дата взаимодействия

            using (SqlConnection con = GetConnection())
            {
                string query = "INSERT INTO VisitorInteraction (VisitorID, PlacementID, Comments, InteractionDate) VALUES (@VisitorID, @PlacementID, @Comments, @InteractionDate)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@VisitorID", visitorId);
                cmd.Parameters.AddWithValue("@PlacementID", placementId);
                cmd.Parameters.AddWithValue("@Comments", comments);
                cmd.Parameters.AddWithValue("@InteractionDate", interactionDate);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Interaction added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add interaction: " + ex.Message);
                }
            }
        }


        private void button32_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "SELECT * FROM VisitorInteraction";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView7.DataSource = dt; // Предположим, что dataGridView7 - это ваш DataGridView
            }
        }

        private void button33_Click_1(object sender, EventArgs e)
        {
            int interactionId = int.Parse(textBox23.Text); // Предполагаем, что textBox23 связан с InteractionID
            int visitorId = int.Parse(textBox24.Text);
            int placementId = int.Parse(textBox25.Text);
            string comments = textBox26.Text;
            DateTime interactionDate = dateTimePicker2.Value;

            using (SqlConnection con = GetConnection())
            {
                string query = "UPDATE VisitorInteraction SET VisitorID = @VisitorID, PlacementID = @PlacementID, Comments = @Comments, InteractionDate = @InteractionDate WHERE InteractionID = @InteractionID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@InteractionID", interactionId);
                cmd.Parameters.AddWithValue("@VisitorID", visitorId);
                cmd.Parameters.AddWithValue("@PlacementID", placementId);
                cmd.Parameters.AddWithValue("@Comments", comments);
                cmd.Parameters.AddWithValue("@InteractionDate", interactionDate);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Interaction updated successfully.");
                    else
                        MessageBox.Show("No interaction found with the specified ID.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update interaction: " + ex.Message);
                }
            }
        }

        private void button34_Click_1(object sender, EventArgs e)
        {
            int interactionId = int.Parse(textBox23.Text); // Предполагаем, что textBox23 связан с InteractionID

            using (SqlConnection con = GetConnection())
            {
                string query = "DELETE FROM VisitorInteraction WHERE InteractionID = @InteractionID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@InteractionID", interactionId);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Interaction deleted successfully.");
                    else
                        MessageBox.Show("No interaction found with the specified ID.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete interaction: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            // Получаем текст из textBox27
            string filterText = textBox27.Text;

            // Предположим, что dt - это DataTable, связанный с вашим dataGridView1
            DataTable dt = dataGridView1.DataSource as DataTable;

            if (dt != null)
            {
                // Применяем фильтр
                if (string.IsNullOrWhiteSpace(filterText))
                {
                    // Если строка поиска пуста, сброс фильтра
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";
                }
                else
                {
                    // Фильтрация по Title
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Title LIKE '%{0}%'", filterText.Replace("'", "''")); // Заменяем одинарные кавычки для безопасности SQL
                }
            }
        }

    }
}
