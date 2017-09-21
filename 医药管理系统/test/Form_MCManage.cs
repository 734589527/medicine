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
using 医药管理系统.test;

namespace WindowsFormsApplication1
{
    public partial class Form_MCManage : XtraTabPage
    {
        //属性******************************************************************************
        private Form_MCdetails details;
        private DataGridViewCell clickedCell;
        public int pageSize = 15;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页
        DataTable dtSource = new DataTable();//里面放的就是当前要处理的表格
        //系统事件**************************************************************************
        public Form_MCManage()
        {
            InitializeComponent();
            InitdataGridView1();

        }

        private void Form_MCManage_Load(object sender, EventArgs e)
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
        //自定义函数****************************************************************************

        public void InitdataGridView1()
        {
            shujuku("Select * From test1");
            fenye();//分页
            LoadPage();//加载数据
        }
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
                for (int n = 0; n < dtTemp.Columns.Count; n++)
                {//给每一行赋值
                    this.dataGridView1.Rows[m].Cells[n].Value = dtTemp.Rows[m][n].ToString();
                }
                this.dataGridView1["详情", m].Value = "详情";
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
            sda.Fill(Ds, "test1");
            //将数据放到数据表中
            dtSource = Ds.Tables["test1"];
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

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//如果是左键点击了格子
            {
                DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);//获取鼠标点击坐标
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    clickedCell = dataGridView1.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                    if (clickedCell.ColumnIndex == 15)
                    {//上边括号内是为了确定点击的是有按钮的那一列，而且操作点击
                        DataGridViewRow row = dataGridView1.Rows[clickedCell.RowIndex];
                        details = new Form_MCdetails();
                        //将选中列id发送给显示详情界面
                        details.MCId = row.Cells[0].Value.ToString();
                        details.Show();
                    }
                }
            }
        }
    }
}
