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
    public partial class edit_book : Form
    {
        string book_id = "0";
        public edit_book(string id_form)
        {
            InitializeComponent();

            book_id = id_form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text != "" && textBox2.Text != "")
                {
                    SQLclass.OpenConnection();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE books SET name = N'" + textBox1.Text + "', price = N'" + textBox2.Text + "' WHERE id = N'" + book_id + "'", SQLclass.str);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Данные успешно изменены!");
                    SQLclass.CloseConnection();

                    StaticVars.panel.Controls.Clear();
                    catalog_form catalog_Form = new catalog_form() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    StaticVars.panel.Controls.Add(catalog_Form);
                    catalog_Form.Show();
                }
                else
                {
                    MessageBox.Show("Пожалуйста укажите новые значения для изменения");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void edit_book_Load(object sender, EventArgs e)
        {
            try
            {
                SQLclass.OpenConnection();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM books WHERE id = N'" + book_id + "'", SQLclass.str);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while(reader.Read())
                {
                    textBox1.Text = reader[1].ToString();
                    textBox2.Text = reader[2].ToString();
                }
                reader.Close();
                SQLclass.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
