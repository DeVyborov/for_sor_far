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
    public partial class catalog_form : Form
    {
        public catalog_form()
        {
            InitializeComponent();
        }

        int count_books = 0;

        private void catalog_form_Load(object sender, EventArgs e)
        {
            try
            {
                SQLclass.OpenConnection();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(id) FROM books", SQLclass.str);
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    count_books = Convert.ToInt32(dr[0]);
                }
                dr.Close();

                int get_count = 0;
                string[] logins = new string[count_books];
                string[] password = new string[count_books];
                string[] ids = new string[count_books];

                SqlCommand cmd_get_info = new SqlCommand("SELECT * FROM books", SQLclass.str);
                SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                while (dr_get_info.Read())
                {
                    ids[get_count] = dr_get_info[0].ToString();
                    logins[get_count] = dr_get_info[1].ToString();
                    password[get_count] = dr_get_info[2].ToString();
                    get_count++;
                }
                dr_get_info.Close();

                for(int i = get_count-1; i >= 0; i--)
                {
                    book_info_panel book_Info_Panel = new book_info_panel(logins[i], password[i], Convert.ToInt32(ids[i]), StaticVars.user_role, "0", "") { Dock = DockStyle.Top};
                    panel1.Controls.Add(book_Info_Panel);
                }
                SQLclass.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
