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

namespace 医药管理系统
{
    public partial class sales_select : Form
    {
        public sales_select()
        {
            InitializeComponent();
            textBox1.GotFocus += new EventHandler(text_Focus);
            textBox1.LostFocus += new EventHandler(text_lostFocus);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "请输入订单日期、客户、订单号、负责人")
            {
                dataGridView1.Rows.Clear();
                MySqlConnection con = new sql_conn().getconn();
                MySqlCommand cmd = null;
                MySqlDataReader reader = null;
                try
                {
                    con.Open();
                    cmd = new MySqlCommand("select * from sale1 where remark not like '%退单%'", con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int x = dataGridView1.RowCount;
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[x].Cells[0].Value = reader[0].ToString();
                        dataGridView1.Rows[x].Cells[1].Value = reader[1].ToString();
                        dataGridView1.Rows[x].Cells[2].Value = reader[2].ToString();
                        dataGridView1.Rows[x].Cells[3].Value = reader[3].ToString();
                        dataGridView1.Rows[x].Cells[4].Value = reader[4].ToString();
                        dataGridView1.Rows[x].Cells[5].Value = reader[5].ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("数据库连接失败");
                }
                finally
                {
                    con.Close();
                    reader.Close();
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlConnection con1 = new sql_conn().getconn();
                MySqlCommand cmd1 = null;
                
                try
                {
                    MySqlDataReader reader1 = null;
                    con1.Open();
                    cmd1 = new MySqlCommand("select * from sale1 where id like binary '%" + textBox1.Text + "%' or date like binary '%" + textBox1.Text + "%' or customer like binary '%" + textBox1.Text + "%' or manager like binary '%" + textBox1.Text + "%' or state like binary '%" + textBox1.Text + "%'", con1);
                    reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1[6].ToString().Contains("退单") == false)
                        {
                            int x = dataGridView1.RowCount;
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[x].Cells[0].Value = reader1[0].ToString();
                            dataGridView1.Rows[x].Cells[1].Value = reader1[1].ToString();
                            dataGridView1.Rows[x].Cells[2].Value = reader1[2].ToString();
                            dataGridView1.Rows[x].Cells[3].Value = reader1[3].ToString();
                            dataGridView1.Rows[x].Cells[4].Value = reader1[4].ToString();
                            dataGridView1.Rows[x].Cells[5].Value = reader1[5].ToString();
                        }
                    }
                    reader1.Close();
                }
                catch(Exception e1)
                {
                    MessageBox.Show("数据库连接失败");
                    MessageBox.Show(e1.Message);
                }
                finally
                {
                    con1.Close();
                }
            }
        }
        public void text_Focus(object o, EventArgs e)
        {
            if (textBox1.Text == "请输入订单日期、客户、订单号、负责人")
            {
                textBox1.Text = "";
            }
        }
        public void text_lostFocus(object o, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "请输入订单日期、客户、订单号、负责人";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

      
    }
}
