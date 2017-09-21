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
using 医药管理系统.bean;
namespace 医药管理系统
{
    public partial class sale :XtraTabPage
    {
        List<Sales_class> list = new List<Sales_class>();
        int nowPage, sumPage, sum,nowsum=5;
        public sale()
        {
            InitializeComponent();
            textBox1.GotFocus += new EventHandler(text_Focus);
            textBox1.LostFocus += new EventHandler(text_lostFocus);
            String sql = "select sale1.id,sale1.date,sale1.customer,sale1.manager,sale1.sum,sale1.state,sale1.remark,customer.address,customer.phoneNumber from sale1 join customer where sale1.customer=customer.name group by sale1.id";
            DataInit(sql);
            
        }
        public void DataInit(String sql)
        {
            list.Clear();
            MySqlConnection mysql = new sql_conn().getconn();
            MySqlDataReader reader = null;
            try
            {
                mysql.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mysql);
                reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    Sales_class s = new Sales_class();
                    s.s1 = reader[0].ToString();
                    s.s2 = reader[1].ToString();
                    s.s3 = reader[4].ToString();
                    s.s4 = reader[2].ToString();
                    s.s5 = reader[7].ToString();
                    s.s6 = reader[8].ToString();
                    s.s7 = reader[3].ToString();
                    s.s8 = reader[5].ToString();
                    s.s9 = reader[8].ToString();
                    list.Add(s);
                }
                DataGridInit();
            }
            catch
            {
                MessageBox.Show("加载失败");
            }

        }
        public void DataGridInit()
        {
            dataGridViewX1.Rows.Clear();
            nowPage = 1;
            sum = list.Count;
            if (sum % nowsum == 0)
            {
                sumPage = sum / nowsum;
            }
            else
            {
                sumPage = sum / nowsum + 1;
            }
            if (sum == 0)
            {
                sumPage = 1;
            }
            if (sum <= nowsum)
            {
                label3.Text = "1/1";
                for (int i = 0; i < sum; i++)
                {
                    dataGridViewX1.Rows.Add();
                    dataGridViewX1.Rows[i].Cells[0].Value = list[i].s1;
                    dataGridViewX1.Rows[i].Cells[1].Value = list[i].s2;
                    dataGridViewX1.Rows[i].Cells[2].Value = list[i].s3;
                    dataGridViewX1.Rows[i].Cells[3].Value = list[i].s4;
                    dataGridViewX1.Rows[i].Cells[4].Value = list[i].s5;
                    dataGridViewX1.Rows[i].Cells[5].Value = list[i].s6;
                    dataGridViewX1.Rows[i].Cells[6].Value = list[i].s7;
                    dataGridViewX1.Rows[i].Cells[7].Value = list[i].s8;
                    dataGridViewX1.Rows[i].Cells[8].Value = list[i].s9;
                }
            }
            else
            {
                label3.Text = "1/"+sumPage;
                for (int i = 0; i < nowsum; i++)
                {
                    dataGridViewX1.Rows.Add();
                    dataGridViewX1.Rows[i].Cells[0].Value = list[i].s1;
                    dataGridViewX1.Rows[i].Cells[1].Value = list[i].s2;
                    dataGridViewX1.Rows[i].Cells[2].Value = list[i].s3;
                    dataGridViewX1.Rows[i].Cells[3].Value = list[i].s4;
                    dataGridViewX1.Rows[i].Cells[4].Value = list[i].s5;
                    dataGridViewX1.Rows[i].Cells[5].Value = list[i].s6;
                    dataGridViewX1.Rows[i].Cells[6].Value = list[i].s7;
                    dataGridViewX1.Rows[i].Cells[7].Value = list[i].s8;
                    dataGridViewX1.Rows[i].Cells[8].Value = list[i].s9;
                }
            }
            button_click();
        }
        public void button_click()
        {

            if (nowPage == sumPage)
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
            if (nowPage == 1)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }
        public void text_Focus(object o,EventArgs e)
        {
            if (textBox1.Text == "请输入订单号/客户/订单状态/负责人")
            {
                textBox1.Text = "";
            }
        }
        public void text_lostFocus(object o, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "请输入订单号/客户/订单状态/负责人";
            }
        }
        public void fanye()
        {
            dataGridViewX1.Rows.Clear();
            if (nowPage*nowsum>=sum)
            {
                label3.Text = nowPage.ToString()+"/"+sumPage.ToString();
                for (int i = (nowPage-1) * nowsum; i < sum; i++)
                {
                    dataGridViewX1.Rows.Add();
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[0].Value = list[i].s1;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[1].Value = list[i].s2;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[2].Value = list[i].s3;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[3].Value = list[i].s4;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[4].Value = list[i].s5;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[5].Value = list[i].s6;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[6].Value = list[i].s7;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[7].Value = list[i].s8;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[8].Value = list[i].s9;
                }
            }
            else
            {
                label3.Text = nowPage.ToString() + "/" + sumPage.ToString();
                for (int i = (nowPage - 1) * nowsum; i < (nowPage) * nowsum; i++)
                {
                    dataGridViewX1.Rows.Add();
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[0].Value = list[i].s1;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[1].Value = list[i].s2;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[2].Value = list[i].s3;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[3].Value = list[i].s4;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[4].Value = list[i].s5;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[5].Value = list[i].s6;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[6].Value = list[i].s7;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[7].Value = list[i].s8;
                    dataGridViewX1.Rows[i - (nowPage - 1) * nowsum].Cells[8].Value = list[i].s9;
                }
            }
            button_click();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            nowPage++;
            fanye();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && textBox1.Text == "请输入订单号/客户/订单状态/负责人")
            {
                String sql = "select  sale1.id,sale1.date,sale1.customer,sale1.manager,sale1.sum,sale1.state,sale1.remark,customer.address,customer.phoneNumber from sale1 join customer where sale1.customer=customer.name group by sale1.id";
                DataInit(sql);
            }
            if (checkBox1.Checked == false && textBox1.Text == "请输入订单号/客户/订单状态/负责人")
            {
                String sql = "select  sale1.id,sale1.date,sale1.customer,sale1.manager,sale1.sum,sale1.state,sale1.remark,customer.address,customer.phoneNumber from sale1 join customer where sale1.customer=customer.name and date(str_to_date(sale1.date,'%Y-%m-%d')) between '" + dateTimePicker1.Value.Date.ToShortDateString() + "' and '" + dateTimePicker2.Value.Date.ToShortDateString() + "' group by sale1.id";
                DataInit(sql);
            }
            if (checkBox1.Checked == false && textBox1.Text != "请输入订单号/客户/订单状态/负责人")
            {
                String sql = "select  sale1.id,sale1.date,sale1.customer,sale1.manager,sale1.sum,sale1.state,sale1.remark,customer.address,customer.phoneNumber from sale1 join customer where sale1.customer=customer.name and date(str_to_date(sale1.date,'%Y-%m-%d')) between '" + dateTimePicker1.Value.Date.ToShortDateString() + "' and '" + dateTimePicker2.Value.Date.ToShortDateString() + "' and sale1.id like '%" + textBox1.Text + "%' or sale1.customer like '%" + textBox1.Text + "%' or sale1.manager like '%" + textBox1.Text + "%' or sale1.state like '%" + textBox1.Text + "%' group by sale1.id";
                DataInit(sql);
            }
            if (checkBox1.Checked == true && textBox1.Text != "请输入订单号/客户/订单状态/负责人")
            {
                String sql = "select  sale1.id,sale1.date,sale1.customer,sale1.manager,sale1.sum,sale1.state,sale1.remark,customer.address,customer.phoneNumber from sale1 join customer where sale1.customer=customer.name  and sale1.id like '%" + textBox1.Text + "%' or sale1.customer like '%" + textBox1.Text + "%' or sale1.manager like '%" + textBox1.Text + "%' or sale1.state like '%" + textBox1.Text + "%' group by sale1.id";
                DataInit(sql);
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nowPage--;
            fanye();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox3.Text) > 0)
                {
                    nowsum = int.Parse(textBox3.Text);
                    DataGridInit();
                }
                else
                {
                    MessageBox.Show("请输入正整数");
                }
            }
            catch
            {
                MessageBox.Show("请输入正整数");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox2.Text) <= sumPage && int.Parse(textBox2.Text)>0)
                {
                    nowPage = int.Parse(textBox2.Text);
                    fanye();
                }
                else
                {
                    MessageBox.Show("页数错误");
                }
            }
            catch
            {
                MessageBox.Show("请输入整数");
            }
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
