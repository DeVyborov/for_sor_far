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
using vyborov_test_1.Classes;

namespace vyborov_test_1.Forms
{
    public partial class user_info : Form
    {
        public user_info()
        {
            InitializeComponent();
        }

        private void user_info_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateData()
        {
            SQLclass.OpenConnection();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM auth", SQLclass.str);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            SQLclass.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedIndex != -1)
                {
                    SQLclass.OpenConnection();

                    SqlCommand cmd = new SqlCommand("INSERT INTO auth(login,password,role) VALUES ('"+textBox1.Text+"', '"+textBox2.Text+"', '"+(comboBox1.SelectedIndex+1)+"')", SQLclass.str);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Новый пользователь успешно добавлен!");

                    SQLclass.CloseConnection();

                    UpdateData();
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
