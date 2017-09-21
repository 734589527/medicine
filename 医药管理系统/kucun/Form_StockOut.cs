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
    public partial class Form_StockOut : XtraTabPage
    {
        public Form_StockOut()
        {
            InitializeComponent();
            init1();
            init2();
        }
        public void init1()
        {

            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            String com1 = comboBox1.Text;
            MySqlCommand cmd = new MySqlCommand("select * from sale1 where remark not like '%退单%' and state = '待出库'", M);
            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                comboBox2.Items.Clear();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0].ToString());
                }
            }
            catch
            {
            }
        }
        private void init2()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            String com1 = comboBox1.Text;
            MySqlCommand cmd = new MySqlCommand("select * from staff", M);
            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                comboBox1.Items.Clear();
                comboBox6.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[1].ToString());
                    comboBox6.Items.Add(reader[1].ToString());
                }
            }
            catch
            {
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sale1 where id = '" + comboBox2.Text + "'", M);
            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox2.Text = reader[2].ToString();
                    textBox9.Text = reader[4].ToString();
                    initdata();
                }
            }
            catch
            {
            }
        }
        private void initdata()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sale2 where id = '" + comboBox2.Text + "'", M);
            MySqlDataReader reader = null;
            float num = 0;
            try
            {
                reader = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    int count = dataGridView1.RowCount;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[count].Cells[0].Value = reader[1].ToString();
                    dataGridView1.Rows[count].Cells[1].Value = reader[6].ToString();
                    dataGridView1.Rows[count].Cells[2].Value = reader[3].ToString();
                    dataGridView1.Rows[count].Cells[3].Value = float.Parse(reader[2].ToString()) / float.Parse(reader[3].ToString());
                    dataGridView1.Rows[count].Cells[4].Value = reader[2].ToString();
                    dataGridView1.Rows[count].Cells[5].Value = reader[8].ToString();
                    dataGridView1.Rows[count].Cells[6].Value = reader[7].ToString();
                    if (reader[12].ToString().Contains("退货"))
                        dataGridView1.Rows[count].Cells[7].Value = reader[12].ToString() + "," + reader[13].ToString();
                    num = num + float.Parse(reader[2].ToString()) / float.Parse(reader[3].ToString());
                }
                textBox7.Text = num.ToString();
            }
            catch
            {
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            MySqlCommand cmd = new MySqlCommand("select * from customer where name = '" + textBox2.Text + "'", M);
            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox3.Text = reader[2].ToString();
                    textBox4.Text = reader[3].ToString();
                }
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            MySqlCommand cmd = null;
            try
            {
                cmd = new MySqlCommand("insert into stockout1 value ('" + textBox1.Text + "','出库中' , '" + DateTime.Now.ToShortDateString() + "','" + textBox2.Text + "','" + comboBox6.Text + "','" + comboBox1.Text + "'," + textBox9.Text + ",'" + comboBox2.Text + "'," + textBox7.Text + ")", M);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand("update sale1 set state = '出库中' where id = '" + comboBox2.Text + "'", M);
                cmd.ExecuteNonQuery();
                MessageBox.Show("出库成功，请等待审核");
                init1();
            }
            catch(Exception e1)
            {
                cmd = new MySqlCommand("delete stockout1 where id = '"+textBox1.Text+"," , M);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand("update sale1 set state = '待出库' where id = '" + comboBox2.Text + "'", M);
                cmd.ExecuteNonQuery();
                MessageBox.Show(e1.Message);
            }
            
        }

        sales_select2 s;
        private void button1_Click(object sender, EventArgs e)
        {
            s = new sales_select2();
            s.Show();
            s.dataGridView1.DoubleClick += new EventHandler(doubleclick);
            s.button2.Click += new EventHandler(doubleclick);
        }
        public void doubleclick(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Text = s.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                s.Close();
            }
            catch
            {
            }

        }
    }
}
