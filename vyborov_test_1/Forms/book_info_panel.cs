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

        public book_info_panel(string login_info_form, string password_info_form, int form_id, string user_role_form)
        {
            InitializeComponent();

            login_info = login_info_form;
            password_info = password_info_form;
            user_role = user_role_form;
            id = form_id;

            label1.Text = "Товар: " + login_info;
            label2.Text = "Цена:" + password_info + "руб.";

            if(user_role == "0" || user_role == "1") // гость and покупатель
            {
                button1.Visible = false;
            }

            button1.Text = "Редактировать: " + id.ToString();
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
            Backet_Logic(id, count_backet);
        }

        public void DeleteBacket()
        {
            MessageBox.Show("Товар под номером " + id.ToString() + " убран из корзины");
            btn_add.Text = "В корзину";
            btn_add.BackColor = Color.AliceBlue;
            count_backet = 0;
            textBox1.Text = count_backet.ToString();
            Backet_Logic(id, count_backet);
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
                Backet_Logic(id, count_backet);
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
                Backet_Logic(id, count_backet);
            }
        }

        public void Backet_Logic(int id_tovar, int count_tovar)
        {
            //if(count_tovar == 0)
            //{
            //    if(StaticVars.basket_tovar_one_count == count_tovar && StaticVars.basket_tovar_one_id == id_tovar)
            //    {
            //        StaticVars.basket_tovar_one_id = 0;
            //        StaticVars.basket_tovar_one_count = 0;
            //    }
            //    else if (StaticVars.basket_tovar_two_count == count_tovar && StaticVars.basket_tovar_two_id == id_tovar)
            //    {
            //        StaticVars.basket_tovar_two_id = 0;
            //        StaticVars.basket_tovar_two_count = 0;
            //    }
            //    else if (StaticVars.basket_tovar_three_count == count_tovar && StaticVars.basket_tovar_three_id == id_tovar)
            //    {
            //        StaticVars.basket_tovar_three_id = 0;
            //        StaticVars.basket_tovar_three_count = 0;
            //    }
            //}
            //else 
            //{
            //    if (StaticVars.basket_tovar_one_id == 0)
            //    {
            //        StaticVars.basket_tovar_one_id = id_tovar;
            //        StaticVars.basket_tovar_one_count = count_tovar;
            //    }
            //    else if (StaticVars.basket_tovar_one_id != 0 && StaticVars.basket_tovar_two_id == 0)
            //    {
            //        StaticVars.basket_tovar_two_id = id_tovar;
            //        StaticVars.basket_tovar_two_count = count_tovar;
            //    }
            //    else if (StaticVars.basket_tovar_two_id != 0 && StaticVars.basket_tovar_three_id == 0)
            //    {
            //        StaticVars.basket_tovar_three_id = id_tovar;
            //        StaticVars.basket_tovar_three_count = count_tovar;
            //    }              
            //    else
            //    {
            //        MessageBox.Show(StaticVars.basket_tovar_one_id.ToString() + "\n" + StaticVars.basket_tovar_one_count.ToString() + "\n" +
            //            StaticVars.basket_tovar_two_id.ToString() + "\n" + StaticVars.basket_tovar_two_count.ToString() + "\n" +
            //            StaticVars.basket_tovar_three_id.ToString() + "\n" + StaticVars.basket_tovar_three_count.ToString());
            //    }
            //}           
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
