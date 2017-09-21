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
    public partial class Form_CustomerManage : XtraTabPage
    {
        public int pageSize = 15;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页
        DataTable dtSource = new DataTable();//里面放的就是当前要处理的表格
        private DataGridViewCell clickedCell;
        public Form_CustomerManage()
        {
            InitializeComponent();
            InitdataGridView1();

        }

        private void Form_CustomerManage_Load(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        //定义删除点击事件
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//如果是左键点击了格子
            {
                DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);//获取鼠标点击坐标
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    clickedCell = dataGridView1.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                    if (clickedCell.ColumnIndex == 5)//从0开头
                    {//上边括号内是为了确定点击的是有按钮的那一列，而且操作点击
                        DataGridViewRow row = dataGridView1.Rows[clickedCell.RowIndex];
                        int id = int.Parse(row.Cells[0].Value.ToString());

                        DialogResult diagorel =
                             MessageBox.Show("是否删除当前行？", "提示：", MessageBoxButtons.OKCancel);
                        switch (diagorel)
                        {
                            case DialogResult.OK:
                                deleteCurrentRow(id);//如果点击ok那么就执行通过选项
                                InitdataGridView1();
                                break;
                            case DialogResult.Cancel:
                                break;
                        }

                    }
                }
            }
        }

        //搜索事件
        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            String tiaojian = null;
            if (comboBox1.Text.Equals("编号"))
            {
                tiaojian = "id";
            }
            else if (comboBox1.Text.Equals("姓名"))
            {
                tiaojian = "name";
            }
            else if (comboBox1.Text.Equals("地址"))
            {
                tiaojian = "address";
            }
            else if (comboBox1.Text.Equals("电话号码"))
            {
                tiaojian = "phoneNumber";
            }
            else if (comboBox1.Text.Equals("简码"))
            {
                tiaojian = "brevityCode";
            }

            String sql = "Select * From customer where " + tiaojian + " = '" + textBox1.Text + "'";
            //如果单选框没有进行选择就显示全部
            if (textBox1.Text.Equals("") || comboBox1.Text.Equals(""))
            {
                sql = "Select * From customer";
            }
            shujuku(sql);
            fenye();//分页
            LoadPage();//加载数据
        }
        //跳转到后面的页面
        private void button2_Click_1(object sender, EventArgs e)
        {//下一页
            currentPage++;
            LoadPage();
        }
        //跳转到前边的页面
        private void button4_Click_1(object sender, EventArgs e)
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
        //自定义函数///////////////////////////////////////////////////////////////////////////////////////////
        //初始化信息显示框
        public void InitdataGridView1()
        {
            shujuku("Select * From customer");
            fenye();//分页
            LoadPage();//加载数据
        }

        private void deleteCurrentRow(int id)
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            String Sql = "delete from customer where id = ('" + id + "')";
            MySqlCommand cmd = new MySqlCommand(Sql, M);
            int j = 0;
            try
            { //为了避免被其他数据表占用的情况，因为是其他表的外码
                j = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("当前行已被其他数据占用！");
            }
            if (j == 1)
            {
                //删除成功之后，删除表中这一行
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
            M.Close();
            InitdataGridView1();
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
                for (int n = 0; n < dtTemp.Columns.Count; n++)
                {//给每一行赋值
                    this.dataGridView1.Rows[m].Cells[n].Value = dtTemp.Rows[m][n].ToString();
                }
                this.dataGridView1["删除", m].Value = "删除";
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
            sda.Fill(Ds, "customer");
            //将数据放到数据表中
            dtSource = Ds.Tables["customer"];
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
