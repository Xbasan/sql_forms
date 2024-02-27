using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;


namespace sql_forms
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql_forms.Properties.Settings.Database1ConnectionString"].ConnectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fio = f_fio.Text;
            string number = f_nomder.Text;  
            string email= f_email.Text;
            string comments = f_comments.Text;

            
            SqlCommand command = new SqlCommand($"INSERT INTO [teacher] (f_fio, f_phone, f_email, f_comment) VALUES ('{fio}', '{number}', '{email}', '{comments}');", sqlConnection);
            f_comments.Text = "";
            f_fio.Text = "";
            f_nomder.Text = "";
            f_email.Text = "";

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            sqlConnection.Open();
            if (textBox1.Text != "")
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM [dbo].[teacher] WHERE f_fio LiKE '%{textBox1.Text}%';", sqlConnection);
                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet);

                dataGridView2.DataSource = dataSet.Tables[0];
            }
            else
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM [dbo].[teacher]",sqlConnection);

                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet);

                dataGridView2.DataSource= dataSet.Tables[0];
            }
            sqlConnection.Close();
        }

        private void f_nomder_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
