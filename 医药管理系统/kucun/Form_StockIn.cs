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
    public partial class Form_StockIn :XtraTabPage
    {
        private DataGridViewCell clickedCell;
        public Form_StockIn()
        {
            InitializeComponent();
            InitComboBox2();
            InitComboBox3();
        }
        int iRowIndex = 0;//dataGridView1添加的数据行数
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = true;//用来区别
            textBox1.ReadOnly = true;
            int mark = 0;
            if (iRowIndex != 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (comboBox2.Text.Equals(dataGridView1.Rows[i].Cells[0].Value))
                    {
                        flag = false;
                        mark = i;
                        break;
                    }
                }
            }
            if (flag == true)
            {
                dataGridView1.Rows.Add(1);
                this.dataGridView1["商品名称", iRowIndex].Value = comboBox2.Text;
                this.dataGridView1["有效期", iRowIndex].Value = textBox5.Text;
                this.dataGridView1["批准文号", iRowIndex].Value = textBox4.Text;
                this.dataGridView1["件数", iRowIndex].Value = textBox7.Text;
                this.dataGridView1["包装", iRowIndex].Value = textBox10.Text;
                this.dataGridView1["数量", iRowIndex].Value = textBox13.Text;
                this.dataGridView1["金额", iRowIndex].Value = textBox9.Text;
                this.dataGridView1["操作", iRowIndex].Value = "删除";

                iRowIndex++;//添加一次就增加一这样才能不断增加
            }
            else
            {
                String jianshu = dataGridView1.Rows[mark].Cells[3].Value.ToString();
                String jine = dataGridView1.Rows[mark].Cells[4].Value.ToString();
                this.dataGridView1["件数", mark].Value = int.Parse(textBox7.Text) + int.Parse(jianshu);
                this.dataGridView1["金额", mark].Value = int.Parse(textBox9.Text) + int.Parse(jine);
            }
        }
        //初始化下拉菜单,商品名称
        public void InitComboBox2()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * From commodity", M);
            //Adapter是database与Dataset或DataTable之间的接口，
            //它从数据库中get数据并填充至Dataset或Data table，这样就可以实现离线处理数据的能力。
            //一旦adapter对象将数据填充或提交完毕，它和所填充的Dataset对象就没有了任何联系。
            DataSet Ds = new DataSet();
            sda.Fill(Ds, "commodity");//填充DataSet的时候，存进去的表是有名字的
            DataTable dtSource = Ds.Tables["commodity"];//声明一个数据表 从DataSet抓取数据的时候，取出来的数据表也是有名字的
            this.comboBox2.DataSource = dtSource;
            this.comboBox2.ValueMember = "ID";
            this.comboBox2.DisplayMember = "name";
        }
        //初始化下拉菜单,经办人
        private void InitComboBox3()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * From staff", M);
            //Adapter是database与Dataset或DataTable之间的接口，
            //它从数据库中get数据并填充至Dataset或Data table，这样就可以实现离线处理数据的能力。
            //一旦adapter对象将数据填充或提交完毕，它和所填充的Dataset对象就没有了任何联系。
            DataSet Ds = new DataSet();
            sda.Fill(Ds, "staff");//填充DataSet的时候，存进去的表是有名字的
            DataTable dtSource = Ds.Tables["staff"];//声明一个数据表 从DataSet抓取数据的时候，取出来的数据表也是有名字的
            this.comboBox6.DataSource = dtSource;
            this.comboBox6.ValueMember = "name";
            this.comboBox6.DisplayMember = "name";
        }
        private void button2_Click(object sender, EventArgs e)
        {//确认按钮
            //点击确定按钮以后,首先改变仓库中货物的数量
            try
            {
                DBHelper D = new DBHelper();
                MySqlConnection M = D.getconn();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    M.Open();
                    String Num = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    String Sql = "update commodity set Num = Num + " + int.Parse(Num) + " where Name = '" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    MySqlCommand cmd = new MySqlCommand(Sql, M);
                    int j = cmd.ExecuteNonQuery();
                    if (j == 1)
                    {

                    }
                    M.Close();
                }
                //其次计入库出库表

                //添加到入库表1****************************************************************
                //获得本地时间
                DateTime dt = DateTime.Now;
                String datetime = dt.ToLocalTime().ToString();
                String id = textBox1.Text;
                M.Open();
                String Sql1 = "insert into stockin1 values('" + id + "','" + datetime + "','" + comboBox6.Text + "','1')";
                MySqlCommand cmd1 = new MySqlCommand(Sql1, M);
                int k = cmd1.ExecuteNonQuery();
                if (k == 1)
                {

                }
                M.Close();
                //******************************************************************************
                //添加到入库表2*****************************************************************
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    M.Open();
                    String Num1 = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    String Sql2 = "insert into stockin2 values('" + id + "','" + dataGridView1.Rows[i].Cells[0].Value + "'," + Num1 + ")";
                    MySqlCommand cmd2 = new MySqlCommand(Sql2, M);
                    int l = cmd2.ExecuteNonQuery();
                    if (l == 1)
                    {

                    }
                    M.Close();
                }
                MessageBox.Show("添加成功");
            }
            catch
            {
                MessageBox.Show("添加失败，入库单已存在");
            }
            //******************************************************************************
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            String com1 = comboBox2.Text;
            String Sql = "select * from commodity where name = '" + com1 + "'";
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
                    textBox11.Text = reader[2].ToString();//规格
                    textBox10.Text = reader[7].ToString();//包装
                    textBox12.Text = reader[3].ToString();//单位
                    textBox6.Text = reader[6].ToString();//剩余库存
                    textBox8.Text = reader[5].ToString();//单价
                }

            }
            catch (Exception ex) { }
            finally
            {
                reader.Close();
                M.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!textBox7.Text.Equals(""))
            {

                if (!textBox8.Text.Equals(""))
                {
                    float textBox = float.Parse(textBox7.Text) * float.Parse(textBox10.Text);
                    textBox13.Text = textBox + "";
                    float textBox01 = float.Parse(textBox13.Text) * float.Parse(textBox8.Text);
                    textBox9.Text = textBox01 + "";
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//如果是左键点击了格子
            {
                DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);//获取鼠标点击坐标
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    clickedCell = dataGridView1.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                    if (clickedCell.ColumnIndex == 7)
                    {//上边括号内是为了确定点击的是有按钮的那一行，而且删除操作点击
                        DataGridViewRow row = dataGridView1.Rows[clickedCell.RowIndex];
                        dataGridView1.Rows.Remove(row);
                        iRowIndex--;
                    }
                }
            }
        }

        private void Form_StockIn_Load(object sender, EventArgs e)
        {

        }

        selectCommodity sc;
        private void button3_Click(object sender, EventArgs e)
        {
            sc = new selectCommodity();
            sc.button1.Click += new EventHandler(select_add);
            sc.dataGridView1.DoubleClick += new EventHandler(select_add);
            sc.ShowDialog();

        }
        private void select_add(Object o, EventArgs E)
        {
            //MessageBox.Show("点击");
            try
            {
                comboBox2.Text = sc.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                sc.Close();
            }
            catch
            {
                MessageBox.Show("选择错误");
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox1.Text = "1";
            dataGridView1.Rows.Clear();
            iRowIndex = 0;
        }
    }
}

