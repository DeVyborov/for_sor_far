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
    public partial class backet_form : Form
    {
        public backet_form()
        {
            InitializeComponent();
        }

        int count_books = 0;

        private void backet_form_Load(object sender, EventArgs e)
        {
            try
            {
                for(int i = 0; i < StaticVars.basket.Count; i++)
                {
                    PublicData(StaticVars.basket[i], StaticVars.count_book[i]);
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PublicData(string book_id, int count_book)
        {
            SQLclass.OpenConnection();

            SqlCommand cmd_get_info = new SqlCommand("SELECT * FROM books WHERE id = '"+book_id+"'", SQLclass.str);
            SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

            int count = 0;
            string book_number = "";
            string book_name = "";
            string book_price = "";

            while (dr_get_info.Read())
            {
                book_number = dr_get_info[0].ToString();
                book_name = dr_get_info[1].ToString();
                book_price = dr_get_info[2].ToString();
                count++;
            }
            dr_get_info.Close();

            for (int i = count - 1; i >= 0; i--)
            {
                book_info_panel book_Info_Panel = new book_info_panel(book_number, book_name, Convert.ToInt32(book_price), StaticVars.user_role, "1", count_book.ToString()) { Dock = DockStyle.Top };
                panel1.Controls.Add(book_Info_Panel);
            }
            SQLclass.CloseConnection();
        }
    }
}
