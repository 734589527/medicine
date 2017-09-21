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

namespace 医药管理系统.drug
{
    public partial class Form_SpecificationManage : Form
    {
        public Form_SpecificationManage()
        {
            InitializeComponent();
            InitdataGridView1();
        }

        //确认添加
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                label5.Text = "请输入有效信息";
                label5.ForeColor = Color.Red;
            }
            else
            {
                String newunit = textBox1.Text.ToString();
                DBHelper D = new DBHelper();
                MySqlConnection M = D.getconn();
                M.Open();
                String Sql = "insert into specification(Name) values('" + newunit + "')";
                MySqlCommand cmd = new MySqlCommand(Sql, M);
                int j = cmd.ExecuteNonQuery();
                if (j == 1)
                {
                    textBox1.Clear();
                    InitdataGridView1();
                }
                M.Close();
            }
        }

        //确认修改
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                label5.Text = "请输入有效信息";
                label5.ForeColor = Color.Red;
            }
            else
            {
                String newunit = textBox2.Text;
                DBHelper D = new DBHelper();
                MySqlConnection M = D.getconn();
                M.Open();
                String Sql = "update  specification set Name = '" + newunit + "' where id = '" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value + "'";
                MySqlCommand cmd = new MySqlCommand(Sql, M);
                int j = cmd.ExecuteNonQuery();
                if (j == 1)
                {
                    InitdataGridView1();
                }
                M.Close();
            }
        }

        //删除
        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult diagorel =
                    MessageBox.Show("是否删除当前行？", "提示：", MessageBoxButtons.OKCancel);
            switch (diagorel)
            {
                case DialogResult.OK:
                    deleteCurrentRow();//如果点击ok那么就执行通过选项
                    InitdataGridView1();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        //刷新
        private void button4_Click(object sender, EventArgs e)
        {
            InitdataGridView1();
        }
        //自定义函数****************************************************************************
        //初始化信息显示框
        public void InitdataGridView1()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * From specification", M);

            DataSet Ds = new DataSet();
            sda.Fill(Ds, "specification");

            //将数据放到数据表中
            DataTable dt = Ds.Tables["specification"];
            //从数据表向datagridview添加数据
            for (int m = 0; m < dt.Rows.Count; m++)
            {
                //每数一行就添加一行空格
                if (dataGridView1.Rows.Count < dt.Rows.Count)
                {
                    this.dataGridView1.Rows.Add();
                }
                for (int n = 0; n < dt.Columns.Count; n++)
                {//给每一行赋值
                    this.dataGridView1.Rows[m].Cells[n].Value = dt.Rows[m][n].ToString();
                }
            }
        }

        //删除当前光标所在行执行函数
        private void deleteCurrentRow()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            String Sql = "delete from specification where id = ('" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value + "')";
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
        }

    }
}
