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
namespace 医药管理系统
{
    public partial class 退单管理 : XtraTabPage
    {
        public 退单管理()
        {
            InitializeComponent();
            init();
            init1();
            comboBox1.Click += new EventHandler(refresh);
            dataGridView1.AllowUserToAddRows = false;
            
        }
        public void refresh(Object o, EventArgs e)
        {
            init();
            init1();
        }
        public void re()
        {
            init();
            init1();
        }
        private void init()
        {
            MySqlConnection con1 = new sql_conn().getconn();
            MySqlCommand cmd1 = null;
            MySqlDataReader reader1 = null;
            try
            {
                con1.Open();
                comboBox1.Items.Clear();
                cmd1 = new MySqlCommand("select * from sale1 where remark not like '%退单%'", con1);
                reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    comboBox1.Items.Add(reader1[0].ToString());
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message.ToString()); }
            finally
            {
                con1.Close();
                reader1.Close();
            }
        }
        private void init1()
        {
            MySqlConnection con1 = new sql_conn().getconn();
            MySqlCommand cmd1 = null;
            MySqlDataReader reader1 = null;
            try
            {
                con1.Open();
                comboBox2.Items.Clear();
                cmd1 = new MySqlCommand("select * from staff", con1);
                reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    comboBox2.Items.Add(reader1[1].ToString());
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message.ToString()); }
            finally
            {
                con1.Close();
                reader1.Close();
            }
        }
        sales_select s;
        private void button4_Click(object sender, EventArgs e)
        {
            s = new sales_select();
            s.Show();
            s.dataGridView1.DoubleClick += new EventHandler(doubleclick);
            s.button2.Click += new EventHandler(doubleclick);
        }
        public void doubleclick(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Text = s.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                s.Close();
            }
            catch
            { 
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new sql_conn().getconn();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                con.Open();
                cmd = new MySqlCommand("select * from sale1 where id = '" + comboBox1.Text + "'", con);
                reader = cmd.ExecuteReader();
                reader.Read();
                textBox4.Text = reader[4].ToString();
                textBox5.Text = reader[2].ToString();
                textBox5.ReadOnly = true;
            }
            catch { }
            finally
            {
                con.Close();
                reader.Close();
            }
            try
            {
                dataGridView1.Rows.Clear();
                con.Open();
                reader = null;
                cmd = new MySqlCommand("select * from sale2 where id = '" + comboBox1.Text + "'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int i = dataGridView1.RowCount;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = reader[0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = reader[1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = reader[9].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = reader[3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = (double.Parse(reader[3].ToString()) / double.Parse(reader[6].ToString()));
                    dataGridView1.Rows[i].Cells[5].Value = reader[10].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = reader[2].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = reader[4].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = reader[8].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = reader[11].ToString();
                }
            }
            catch { }
            finally
            {
                con.Close();
                reader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定退单？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MySqlConnection con = new sql_conn().getconn();
                MySqlCommand cmd = null;
                try
                {
                    con.Open();
                    cmd = new MySqlCommand("update sale1 set remark = '退单中' where id = '" + comboBox1.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    cmd = new MySqlCommand("update sale2 set remark = '退单中' where id = '" + comboBox1.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("退单成功，请等待审核");
                    con.Close();
                }
                catch
                {
                    MessageBox.Show("退单失败，请重试");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定重置？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                re();
                dataGridView1.Rows.Clear();
            }
        }
    }
}
