using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        int id;

        public book_info_panel(string login_info_form, string password_info_form, int form_id)
        {
            InitializeComponent();

            login_info = login_info_form;
            password_info = password_info_form;
            id = form_id;

            label1.Text = login_info;
            label2.Text = password_info;

            button1.Text = "Редактировать: " + id.ToString();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Добавлено:" + id.ToString());
        }
    }
}
