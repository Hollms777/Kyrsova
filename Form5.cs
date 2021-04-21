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
    public partial class Form5 : Form
    {
        private SqlConnection sqlConnection = null;

        private SqlDataAdapter adapter = null;

        private DataTable table = null;


        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3();
            newForm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            newForm.Show();
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (label3.Visible)
                label3.Visible = false;

            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\University\C#\Курсова\Курсова\Kyrsova\Database.mdf;Integrated Security=True");

            sqlConnection.Open();

            adapter = new SqlDataAdapter("SELECT * FROM [finance]", sqlConnection);

            table = new DataTable();

            adapter.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {          
            table.Clear();


            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }


        private void button6_Click(object sender, EventArgs e)
        {
           var adapter2 = new SqlDataAdapter("SELECT SUM(Сума_за_день) FROM [finance]", sqlConnection);

            DataSet ds = new DataSet();

            adapter2.Fill(ds);


            try
            {

                richTextBox1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private async void button7_Click(object sender, EventArgs e)
        {

            if (label3.Visible)
                label3.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [finance] (Дата,Сума_за_день) VALUES(@Дата,@Сума_за_день)", sqlConnection);

                command.Parameters.AddWithValue("Дата", monthCalendar1.SelectionStart);
                command.Parameters.AddWithValue("Сума_за_день", textBox1.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {

                label3.Visible = true;

                label3.Text = "Поля форми повинні бути заповнені!";
            }
            
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            if (label4.Visible)
                label4.Visible = false;

            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [finance] SET [Дата]=@Дата, [Сума_за_день]=@Сума_за_день WHERE [ID]=@ID", sqlConnection);

                command.Parameters.AddWithValue("Дата", monthCalendar2.SelectionStart);
                command.Parameters.AddWithValue("Сума_за_день", textBox2.Text);
                command.Parameters.AddWithValue("ID", textBox3.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {

                label4.Visible = true;

                label4.Text = "Поля форми повинні бути заповнені!";
            }
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            if (label8.Visible)
                label8.Visible = false;

            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [finance] WHERE [ID]=@ID", sqlConnection);
                
                
                command.Parameters.AddWithValue("ID", textBox4.Text);

                
                await command.ExecuteNonQueryAsync();
            }
            else
            {

                label8.Visible = true;

                label8.Text = "Поля форми повинні бути заповнені!";
            }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            
        }
    }
}
