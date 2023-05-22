using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vyborov_test_1.Classes
{
    public static class StaticVars
    {
        public static string user_id = "";
        public static string user_role = "";

        public static Panel panel = null;

        public static List<string> basket = new List<string>();
        public static int[] count_book = new int[100];

        public static int itog_summ = 0; 
    }
}
