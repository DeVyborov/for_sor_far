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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            StaticVars.panel = this.panel1;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Autorization autorization = new Autorization(); 
            autorization.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorization autorization = new Autorization();
            autorization.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            try
            {
                panel1.Controls.Clear();
                catalog_form catalog_Form = new catalog_form() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panel1.Controls.Add(catalog_Form);
                catalog_Form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            user_info user_Info = new user_info() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel1.Controls.Add(user_Info);
            user_Info.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            backet_form backet_Form = new backet_form() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panel1.Controls.Add(backet_Form);
            backet_Form.Show();

            label1.Visible = true;
            button5.Visible = true;

            label1.Text = StaticVars.itog_summ.ToString() + "руб.";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Формирование заказа!");
        }
    }
}
