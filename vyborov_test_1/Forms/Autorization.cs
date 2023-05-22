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
using vyborov_test_1.Forms;

namespace vyborov_test_1
{
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }

        int check_true_user_login = 0;
        int check_true_user_password = 0;

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    SQLclass.OpenConnection();
                    SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM auth WHERE login = '"+textBox1.Text+"'",SQLclass.str);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while(reader.Read())
                    {
                        check_true_user_login = Convert.ToInt32(reader[0]);
                    }
                    reader.Close();

                    if(check_true_user_login == 1)
                    {
                        SqlCommand sqlCommand_password = new SqlCommand("SELECT COUNT(*) FROM auth WHERE login = '" + textBox1.Text + "' AND password = '"+textBox2.Text+"'", SQLclass.str);
                        SqlDataReader reader_password = sqlCommand_password.ExecuteReader();

                        while (reader_password.Read())
                        {
                            check_true_user_password = Convert.ToInt32(reader_password[0]);
                        }
                        reader_password.Close();

                        if(check_true_user_password == 1)
                        {
                            MessageBox.Show("Добро пожаловать!");

                            SqlCommand sqlCommand_info = new SqlCommand("SELECT * FROM auth WHERE login = '" + textBox1.Text + "'", SQLclass.str);
                            SqlDataReader reader_info = sqlCommand_info.ExecuteReader();

                            while (reader_info.Read())
                            {
                                StaticVars.user_id = reader_info[0].ToString();
                                StaticVars.user_role = reader_info[3].ToString();
                            }
                            reader_info.Close();

                            SQLclass.CloseConnection();
                            this.Hide();
                            MainWindow mainWindow = new MainWindow();   
                            mainWindow.Show();
                        }
                        else if (check_true_user_password == 0)
                        {
                            MessageBox.Show("Указанный пароль введен не верно!");
                            SQLclass.CloseConnection();
                        }
                    }
                    else if(check_true_user_login == 0) 
                    {
                        MessageBox.Show("Аккаунта с данным логином не существует в системе!");
                        SQLclass.CloseConnection();
                    }
                }
                else
                    MessageBox.Show("Пожалуйста введите данные в поля!","Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Autorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
