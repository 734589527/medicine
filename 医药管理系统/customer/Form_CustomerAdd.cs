using DevExpress.XtraTab;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form_CustomerAdd : XtraTabPage
    {
        public Form_CustomerAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkkong();
            if (textBox1.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals(""))
            {

            }
            else
            {
                DBHelper D = new DBHelper();
                MySqlConnection M = D.getconn();
                M.Open();
                String Sql = "insert into customer(name,address,phoneNumber,brevityCode) values('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "')";
                MySqlCommand cmd = new MySqlCommand(Sql, M);
                int j = cmd.ExecuteNonQuery();
                if (j == 1)
                {
                    label5.Text = "添加成功";
                    label5.ForeColor = Color.Black;
                }
                M.Close();
            }
        }
        private void checkkong()
        {
            if (textBox1.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals(""))
            {
                label5.Text = "姓名，地址，手机号不能为空！";
                label5.ForeColor = Color.Red;
            }
            else
            {
                label5.Text = "";
            }
        }
    }
}
