using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagentSystem.Helper
{
    class DButil
    {
        public MySqlConnection getConnection()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password= ;database=yygl;pooling=false;CharSet=utf8;");
                return conn;
            }
            catch
            {
                Application.Exit();
                return null;
            }
        }
    }
}
