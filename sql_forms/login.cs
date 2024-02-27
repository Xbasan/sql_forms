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
using System.Configuration;
using System.Data.Common;

namespace sql_forms
{
    public partial class login : Form
    {

        private SqlConnection sqlConnection  = null;
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql_forms.Properties.Settings.Database1ConnectionString"].ConnectionString);
        
            sqlConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = Login_.Text;
            string password = Password.Text;

            DataTable dataTable = new DataTable();  

            SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM [login] WHERE l_user = '{login}' AND l_paswword = '{password}'",sqlConnection);

            dataAdapter.Fill(dataTable);


            if (dataTable.Rows.Count == 1)
            {
                Form1 form = new Form1();
                form.ShowDialog();
                sqlConnection.Close();
            }
            else
            {
                label3.Text = "нет такого пользователя";
            }
        }

    }
}
