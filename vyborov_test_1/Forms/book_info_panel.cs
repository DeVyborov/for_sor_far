using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vyborov_test_1.Classes;

namespace vyborov_test_1.Forms
{
    public partial class book_info_panel : UserControl
    {
        public book_info_panel()
        {
            InitializeComponent();
        }

        string login_info;
        string password_info;
        string user_role;
        int id;
        int count_backet = 0;
        string type;
        string count_book;

        public book_info_panel(string login_info_form, string password_info_form, int form_id, string user_role_form, string type_form, string count_book_form)
        {
            InitializeComponent();

            login_info = login_info_form;
            password_info = password_info_form;
            user_role = user_role_form;
            id = form_id;
            type = type_form;
            count_book = count_book_form;

            if(type == "0") // каталог
            {
                label1.Text = "Товар: " + login_info;
                label2.Text = "Цена:" + password_info + "руб.";

                if (user_role == "0" || user_role == "1") // гость and покупатель
                {
                    button1.Visible = false;
                }

                button1.Text = "Редактировать: " + id.ToString();
            }
            else if (type == "1") // корзина
            {
                btn_add.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                textBox1.Visible = false;
                button3.Visible = false;

                label1.Text = "Товар: " + password_info_form;
                label2.Text = "Количество:" + count_book + "\n" + "Итоговая сумма: " + Convert.ToInt32(id) * Convert.ToInt32(count_book) + "руб.";
                StaticVars.itog_summ += Convert.ToInt32(id) * Convert.ToInt32(count_book);
            }          
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (user_role == "0")
            {
                MessageBox.Show("Пожалуйста войдите в учетную запись", "Данная возможность вам не доступна!");
            }
            else
            {
                if(btn_add.BackColor != Color.Red)
                {
                    AddBacket();
                }
                else
                {
                    DeleteBacket();
                }                                            
            }          
        }
    
        public void AddBacket()
        {
            MessageBox.Show("Товар под номером " + id.ToString() + " добавлен в корзину");
            btn_add.Text = "В корзине";
            btn_add.BackColor = Color.Red;
            count_backet++;
            textBox1.Text = count_backet.ToString();
            StaticVars.basket.Add(id.ToString());
            StaticVars.count_book[StaticVars.basket.IndexOf(id.ToString())] = count_backet; 
        }

        public void DeleteBacket()
        {
            MessageBox.Show("Товар под номером " + id.ToString() + " убран из корзины");
            btn_add.Text = "В корзину";
            btn_add.BackColor = Color.AliceBlue;
            count_backet = 0;
            textBox1.Text = count_backet.ToString();
            StaticVars.basket.Remove(id.ToString());
            StaticVars.count_book[StaticVars.basket.IndexOf(id.ToString())] = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(count_backet == 0)
            {
                AddBacket();
            }
            else if(count_backet >= 0 && count_backet <= 19)
            {
                count_backet++;
                textBox1.Text = count_backet.ToString();
                button2.Enabled = true;
                StaticVars.count_book[StaticVars.basket.IndexOf(id.ToString())] = count_backet;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(count_backet == 1)
            {
                DeleteBacket();
            }
            else if(count_backet > 0)
            {
                count_backet--;
                textBox1.Text = count_backet.ToString();
                StaticVars.count_book[StaticVars.basket.IndexOf(id.ToString())] = count_backet;
            }
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            StaticVars.panel.Controls.Clear();
            edit_book edit_Book = new edit_book(id.ToString()) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true};
            StaticVars.panel.Controls.Add(edit_Book);
            edit_Book.Show();
        }
    }
}
