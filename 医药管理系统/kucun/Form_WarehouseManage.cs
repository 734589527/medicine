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
using WindowsFormsApplication1;

namespace 医药管理系统.kucun
{
    public partial class Form_WarehouseManage :XtraTabPage
    {
        public Form_WarehouseManage()
        {
            InitializeComponent();
            try
            {
                initDataGridView1();
            }
            catch
            {
            }
            init();
            init2();
        }
        
        private void init()
        {
            comboBox1.Items.Clear();
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                cmd = new MySqlCommand("select * from specification", M);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[1].ToString());
                }
            }
            catch
            {

            }
        }
        private void init2()
        {
            comboBox2.Items.Clear();
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                cmd = new MySqlCommand("select * from unit", M);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[1].ToString());
                }
            }
            catch
            {


            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void initDataGridView1()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            try
            {
               String  Sql = "Select * From commodity";
                shujuku(Sql);
            }
            catch
            { 
            }
            //shujuku("Select * From commodity"); ;
            try
            {
                fenye();//分页
            }
            catch
            { 
            }
            try
            {
                LoadPage();//加载数据
            }
            catch
            { 
            }
        }

        //搜索功能
        private void button4_Click(object sender, EventArgs e)
        {
            String key3 = textBox3.Text;
            String key4 = textBox4.Text;
            String key5 = textBox5.Text;
            String key6 = textBox6.Text;
            String key7 = textBox7.Text;
            String key8 = textBox8.Text;
            String key9 = textBox9.Text;

            String key1 = comboBox1.Text;
            String key2 = comboBox2.Text;
            String Sql = "Select * From commodity where";
            //SELECT * FROM [user] WHERE u_name LIKE '%三%' 
            //3457689 combox1,2
            if (key3.Equals("") && key4.Equals("") && key5.Equals("") && key6.Equals("") && key7.Equals("") && key8.Equals("") && key9.Equals("") && key1.Equals("") && key2.Equals(""))
            {
                Sql = "Select * From commodity";
            }
            else
            {
                if (!key1.Equals(""))//如果规格不为空
                {
                    if (Sql.Equals("Select * From commodity where"))
                    {
                        Sql += " Specification in (select id from specification where Name = '" + key1 + "')";
                    }
                    else
                    {
                        Sql += " and Specification  in (select id from specification where Name = '" + key1 + "'";
                    }
                }
                if (!key2.Equals(""))//如果单位不为空
                {
                    if (Sql.Equals("Select * From commodity where"))
                    {
                        Sql += " Unit  in (select id from unit where Name = '" + comboBox2.Text + "')";
                    }
                    else
                    {
                        Sql += " and Unit in (select id from unit where Name = '" + comboBox2.Text + "')";
                    }
                }
                if (!key3.Equals(""))//如果名称不为空,模糊检索
                {
                    if (Sql.Equals("Select * From commodity where"))
                    {
                        Sql += " Name like binary '%" + key3 + "%'";
                    }
                    else
                    {
                        Sql += " and Name like binary '%" + key3 + "%'";
                    }
                }
                //*******************************************************************
                if (!key4.Equals(""))//如果库存数量存在最低限制
                {
                    if (Sql.Equals("Select * From commodity where"))
                    {
                        Sql += " Num >" + float.Parse(key4);
                    }
                    else
                    {
                        Sql += " and Num >" + float.Parse(key4);
                    }
                }
                if (!key5.Equals(""))//如果库存数量存在最高限制
                {
                    if (Sql.Equals("Select * From commodity where"))
                    {
                        Sql += " Num <" + float.Parse(key5);
                    }
                    else
                    {
                        Sql += " and Num <" + float.Parse(key5);
                    }
                }
                //*******************************************************************
                if (!key7.Equals(""))//如果进价存在最低限制
                {
                    if (Sql.Equals("Select * From commodity where"))
                    {
                        Sql += " Bid >" + float.Parse(key7);
                    }
                    else
                    {
                        Sql += " and Bid >" + float.Parse(key7);
                    }
                }
                if (!key6.Equals(""))//如果进价存在最高限制
                {
                    if (Sql.Equals("Select * From commodity where"))
                    {
                        Sql += " Bid <" + float.Parse(key6);
                    }
                    else
                    {
                        Sql += " and Bid <" + float.Parse(key6);
                    }
                }
                //*******************************************************************
                if (!key9.Equals(""))//如果售价存在最低限制
                {
                    if (Sql.Equals("Select * From commodity where"))
                    {
                        Sql += " Price >" + float.Parse(key9);
                    }
                    else
                    {
                        Sql += " and Price >" + float.Parse(key9);
                    }
                }
                if (!key8.Equals(""))//如果售价存在最高限制
                {
                    if (Sql.Equals("Select * From commodity where"))
                    {
                        Sql += " Price <" + float.Parse(key8);
                    }
                    else
                    {
                        Sql += " and Price <" + float.Parse(key8);
                    }
                }
            }
            //**********************************************************************
            shujuku(Sql);
            fenye();//分页
            LoadPage();//加载数据
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {//显示行号
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        //分页功能**********************************************************************************
        public int pageSize = 5;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页
        DataTable dtSource = new DataTable();//里面放的就是当前要处理的表格

        private void LoadPage()//加载页面
        {
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            int beginRecord;//当前页开始地址
            int endRecord;//当前页结束地址
            DataTable dtTemp;
            dtTemp = dtSource.Clone();

            beginRecord = pageSize * (currentPage - 1);
            if (currentPage == 1) beginRecord = 0;
            endRecord = pageSize * currentPage;//给两个地址赋值

            if (currentPage == pageCount) endRecord = recordCount;
            for (int i = beginRecord; i < endRecord; i++)
            {
                dtTemp.ImportRow(dtSource.Rows[i]);
            }
            dataGridView1.DataSource = dtTemp;  //datagridview控件名是tf_dgv1
            label14.Text = currentPage.ToString();//当前页
            label15.Text = pageCount.ToString();//总页数
            label18.Text = recordCount.ToString();//总记录数
        }
        //数据库操作函数
        private void shujuku(string str)
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            MySqlDataAdapter sda = new MySqlDataAdapter(str, M);
            DataSet Ds = new DataSet();
            try
            {
                sda.Fill(Ds, "commodity1");
            }
            catch
            {
                sda.Fill(Ds, "commodity1");
            }
            //使用DataSet绑定时，必须同时指明DateMember 
            dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = Ds;
            /*this.dataGridView1.DataMember = "commodity1";*/
          dtSource = Ds.Tables["commodity1"];
        }
        private void fenye()    //str是sql语句
        {
            recordCount = dtSource.Rows.Count;

            pageCount = (recordCount / pageSize);
            if ((recordCount % pageSize) > 0)
            {
                pageCount++;
            }
            if (recordCount == 0)
            {
                pageCount = 1;
            }

            //默认第一页
            currentPage = 1;

            LoadPage();//调用加载数据的方法
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        //跳转到后面的页面
        private void button2_Click(object sender, EventArgs e)
        {//下一页
            currentPage++;
            LoadPage();
        }
        //跳转到前边的页面
        private void button1_Click(object sender, EventArgs e)
        {
            currentPage--;
            LoadPage();
        }
        //跳转到制定页面
        private void button5_Click(object sender, EventArgs e)
        {
            if (shuzi(textBox1.Text))
            {
                currentPage = int.Parse(textBox1.Text);
                LoadPage();
            }
            else { MessageBox.Show("请输入数字！"); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //修改一个页面上显示数据条数
        private void button3_Click(object sender, EventArgs e)
        {
            if (shuzi(textBox2.Text))
            {
                pageSize = int.Parse(textBox2.Text);
                fenye();//重新分页
                LoadPage();
            }
            else { MessageBox.Show("请输入数字！"); }
        }
        private bool shuzi(string message)
        {//判断其是不是数字
            int result = 0;
            try
            {
                result = int.Parse(message);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
