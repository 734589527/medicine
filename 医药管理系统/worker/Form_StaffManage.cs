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
    public partial class Form_StaffManage : XtraTabPage
    {
        //属性******************************************************************************
        public int pageSize = 10;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页
        DataTable dtSource = new DataTable();//里面放的就是当前要处理的表格
        //系统事件**************************************************************************
        public Form_StaffManage()
        {
            InitializeComponent();
            InitdataGridView1();
        }

        private void Form_StaffManage_Load(object sender, EventArgs e)
        {

        }
        //跳转到后面的页面
        private void button2_Click(object sender, EventArgs e)
        {//下一页
            currentPage++;
            LoadPage();
        }
        //跳转到前边的页面
        private void button4_Click(object sender, EventArgs e)
        {
            currentPage--;
            LoadPage();
        }
        //跳转到制定页面
        private void button5_Click(object sender, EventArgs e)
        {
            if (shuzi(textBox3.Text))
            {
                currentPage = int.Parse(textBox3.Text);
                LoadPage();
            }
            else { MessageBox.Show("请输入数字！"); }
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
        //搜索事件
        private void button1_Click(object sender, EventArgs e)
        {
            re();
        }
        public void re()
        {
            dataGridView1.Rows.Clear();
            String tiaojian = null;
            if (comboBox1.Text.Equals("员工名称"))
            {
                tiaojian = "username";
            }
            else if (comboBox1.Text.Equals("手机号"))
            {
                tiaojian = "phonenumber";
            }
            else if (comboBox1.Text.Equals("员工年龄"))
            {
                tiaojian = "age";
            }

            String sql = "Select * From staff where " + tiaojian + " = '" + textBox1.Text + "'";
            //如果单选框没有进行选择就显示全部
            if (textBox1.Text.Equals("") || comboBox1.Text.Equals(""))
            {
                sql = "Select * From staff";
            }
            shujuku(sql);
            fenye();//分页
            LoadPage();//加载数据
        }
        //自定义函数****************************************************************************
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
        //初始化信息显示框
        public void InitdataGridView1()
        {
            this.dataGridView1.Rows.Clear();
            shujuku("Select * From staff");
            fenye();//分页
            LoadPage();//加载数据
        }
        //分页功能**********************************************************************************


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

            //加载之前先清空之前的表
            dataGridView1.Rows.Clear();
            //从数据表向datagridview添加数据
            for (int m = 0; m < dtTemp.Rows.Count; m++)
            {
                //每数一行就添加一行空格
                if (dataGridView1.Rows.Count < dtTemp.Rows.Count)
                {
                    this.dataGridView1.Rows.Add();
                }
                for (int n = 0; n <3 /*dtTemp.Columns.Count*/; n++)
                {//给每一行赋值
                    this.dataGridView1.Rows[m].Cells[n].Value = dtTemp.Rows[m][n+1].ToString();
                }
            }

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
            sda.Fill(Ds, "staff");
            //将数据放到数据表中
            dtSource = Ds.Tables["staff"];
        }
        private void fenye()    //str是sql语句
        {
            recordCount = dtSource.Rows.Count;

            pageCount = (recordCount / pageSize);
            if ((recordCount % pageSize) > 0)
            {
                pageCount++;
            }

            //默认第一页
            currentPage = 1;

            LoadPage();//调用加载数据的方法
        }


    }
}
