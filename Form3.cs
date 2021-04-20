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
    public partial class Form3 : Form
    {
        private SqlConnection sqlConnection = null;

        private SqlDataAdapter adapter = null;

        private DataTable table = null;

        public Form3()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            table.Clear();


            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\University\C#\Курсова\Курсова\Database.mdf;Integrated Security=True");

            sqlConnection.Open();

            adapter = new SqlDataAdapter("SELECT * FROM [catalogue]", sqlConnection);

            table = new DataTable();
            
            
            adapter.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            Application.Exit();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (label9.Visible)
                label9.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [catalogue] (Назва_товару,Кількість_товару,Ціна_за_одиницю,Номер_поставщика)VALUES(@Назва_товару,@Кількість_товару,@Ціна_за_одиницю,@Номер_поставщика)", sqlConnection);

                command.Parameters.AddWithValue("Назва_товару", textBox1.Text);
                command.Parameters.AddWithValue("Кількість_товару", textBox2.Text);
                command.Parameters.AddWithValue("Ціна_за_одиницю", textBox3.Text);
                command.Parameters.AddWithValue("Номер_поставщика", textBox9.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label9.Visible = true;

                label9.Text = "Поля форми повинні бути заповнені!";
            }

            
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (label10.Visible)
                label10.Visible = false;


            if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text))
                
             {
                SqlCommand command = new SqlCommand("UPDATE [catalogue] SET [Назва_товару]=@Назва_товару,[Кількість_товару]=@Кількість_товару,[Ціна_за_одиницю]=@Ціна_за_одиницю,[Номер_поставщика]=@Номер_поставщика WHERE [ID]=@ID", sqlConnection);

                command.Parameters.AddWithValue("Назва_товару", textBox6.Text);
                command.Parameters.AddWithValue("Кількість_товару", textBox5.Text);
                command.Parameters.AddWithValue("Ціна_за_одиницю", textBox4.Text);
                command.Parameters.AddWithValue("Номер_поставщика", textBox10.Text);
                command.Parameters.AddWithValue("ID",textBox7.Text);

                await command.ExecuteNonQueryAsync();
             }
            else if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
             {
                label10.Visible = true;

                label10.Text = "Поле ID повинне бути заповнено!";
             }
            else
             {
                label10.Visible = true;

                label10.Text = "Поля форми повинні бути заповнені!";
             }
        }

        private async void button8_Click(object sender, EventArgs e)
        {

            if (label10.Visible)
                label10.Visible = false;


            if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [catalogue] WHERE [ID]=@ID", sqlConnection);

                command.Parameters.AddWithValue("ID", textBox8.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label10.Visible = true;

                label10.Text = "Поле ID повинне бути заповнено!";
            }   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            newForm.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form5 newForm = new Form5();
            newForm.Show();
            this.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();

            
        }
    }
}

