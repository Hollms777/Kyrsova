using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсова
{
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection;

        public Form2()
        {
            InitializeComponent();

        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\University\C#\Курсова\Курсова\Database.mdf;Integrated Security=True";
            
            sqlConnection = new SqlConnection(connectionString);
            
            await sqlConnection.OpenAsync();
           
            SqlDataReader sqlReader = null;
           
            SqlCommand command = new SqlCommand("SELECT * FROM [поставщики]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync()) 
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["ID"]) + "     " + Convert.ToString(sqlReader["Імя"]) + "          " + Convert.ToString(sqlReader["Адреса"]) + "               " + Convert.ToString(sqlReader["Номер_телефону"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label10.Visible)
                label10.Visible = false;

            if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox4.Text)
                && !string.IsNullOrWhiteSpace(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [поставщики] SET [Імя]=@Імя, [Адреса]=@Адреса, [Номер_телефону]=@Номер_телефону WHERE [ID]=@ID", sqlConnection);
                command.Parameters.AddWithValue("ID",textBox7.Text);
                command.Parameters.AddWithValue("Імя",textBox6.Text);
                command.Parameters.AddWithValue("Адреса",textBox5.Text);
                command.Parameters.AddWithValue("Номер_телефону",textBox4.Text);

                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
            {

                label10.Visible = true;

                label10.Text = "Поле ID повинно бути заповненим!";
            }
            else
            {

                label10.Visible = true;

                label10.Text = "Поля форми повинні бути заповнені!";
            }
            }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label11.Visible)
                label11.Visible = false;

            if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [поставщики] WHERE [ID]=@ID", sqlConnection);

                command.Parameters.AddWithValue("ID", textBox8.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label11.Visible = true;

                label11.Text = "Поле ID повинно бути заповненим!";
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            Application.Exit();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
           
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label9.Visible)
                label9.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [поставщики] (Імя,Адреса,Номер_телефону)VALUES(@Імя,@Адреса,@Номер_телефону)", sqlConnection);

                command.Parameters.AddWithValue("@Імя", textBox1.Text);

                command.Parameters.AddWithValue("@Адреса", textBox2.Text);

                command.Parameters.AddWithValue("@Номер_телефону", textBox3.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label9.Visible = true;

                label9.Text = "Поля форми повинні бути заповнені!";
            }

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [поставщики]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["ID"]) + "     " + Convert.ToString(sqlReader["Імя"]) + "          " + Convert.ToString(sqlReader["Адреса"]) + "               " + Convert.ToString(sqlReader["Номер_телефону"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3();
            newForm.Show();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            newForm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form5 newForm = new Form5();
            newForm.Show();
            this.Close();
        }
    }
}
