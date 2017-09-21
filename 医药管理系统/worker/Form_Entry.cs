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
    public partial class Form_Entry : XtraTabPage
    {
        //属性******************************************************************************
        private int insert1 = 0;
        private int insert2 = 0;
        private int kongchong = 0;//姓名重复未填为1，正常为0
        private int kongchong2 = 0;//检查是否有必填项未填空为2，正常为0
        //系统事件**************************************************************************
        public Form_Entry()
        {
            InitializeComponent();
            InitComboBox1();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                checkKong();
                if (kongchong == 0 && kongchong2 == 0)
                {
                    insertuser();
                    insertstaff();
                    if (insert1 == 1 && insert2 == 1)
                    {
                        label7.Text = "添加成功！";
                        label7.ForeColor = Color.Black;
                    }
                }
            }
            catch
            {
                DBHelper D = new DBHelper();
                MySqlConnection M = D.getconn();
                M.Open();
                String Sql = "delete from user where username = '"+textBox1.Text+"'";
                MySqlCommand cmd = new MySqlCommand(Sql, M);
                MessageBox.Show("添加出错");
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {//检查姓名是否有重复
            int flag = 0;
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            String Sql = "select * from user ";
            MySqlCommand cmd = new MySqlCommand(Sql, M);
            MySqlDataReader reader = null;
            //获取查询结果代码：
            try
            {
                //打开连接
                M.Open();
                //执行查询，并将结果返回给读取器
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (textBox1.Text.Equals(reader[0].ToString()))
                    {
                        label8.Text = "已经有此用户名！";
                        label8.ForeColor = Color.Red;
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    label8.Text = "";
                    label8.ForeColor = Color.White;
                }
                kongchong = flag;

            }
            catch (Exception ex) { }
            finally
            {
                reader.Close();
                M.Close();
            }
        }
        //自定义函数****************************************************************************
        //初始化下拉菜单,客户名称
        public void InitComboBox1()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * From part", M);
            //Adapter是database与Dataset或DataTable之间的接口，
            //它从数据库中get数据并填充至Dataset或Data table，这样就可以实现离线处理数据的能力。
            //一旦adapter对象将数据填充或提交完毕，它和所填充的Dataset对象就没有了任何联系。
            DataSet Ds = new DataSet();
            sda.Fill(Ds, "part");//填充DataSet的时候，存进去的表是有名字的
            DataTable dtSource = Ds.Tables["part"];//声明一个数据表 从DataSet抓取数据的时候，取出来的数据表也是有名字的
            this.comboBox1.DataSource = dtSource;
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.DisplayMember = "name";

        }
        private void insertuser()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            String Sql = "insert into user values('" + textBox1.Text + "','" + textBox4.Text + "'," + comboBox1.SelectedValue.ToString() + ")";
            MySqlCommand cmd = new MySqlCommand(Sql, M);
            int j = cmd.ExecuteNonQuery();
            if (j == 1)
            {
                insert1 = 1;
            }
            M.Close();
        }

        private void insertstaff()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            String Sql = "insert into staff values('" + textBox1.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            MySqlCommand cmd = new MySqlCommand(Sql, M);
            int j = cmd.ExecuteNonQuery();
            if (j == 1)
            {
                insert2 = 1;
            }
            M.Close();
        }

        private void checkKong()
        {//检查是否为空
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals(""))
            {
                label7.Text = "图中所有空格为必填项！";
                label7.ForeColor = Color.Red;
                kongchong2 = 2;
            }
            else
            {
                label7.Text = "";
                label7.ForeColor = Color.White;
                kongchong2 = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
