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
    public partial class Good_Del :XtraTabPage
    {
        public Good_Del()
        {
            InitializeComponent();
            init();
            init1();
            comboBox1.Click += new EventHandler(refresh);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(cellchange);
            
        }
        public void refresh(Object o, EventArgs e)
        {
            init();
            init1();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                comboBox3.Items.Clear();
                cmd1 = new MySqlCommand("select * from staff", con1);
                reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    comboBox3.Items.Add(reader1[1].ToString());
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message.ToString()); }
            finally
            {
                con1.Close();
                reader1.Close();
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
                textBox4.Text = reader[2].ToString();
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
                    if (reader[12].ToString().Contains("退货") == false)
                    {
                        int i = dataGridView1.RowCount;
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[1].Value = reader[0].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = reader[1].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = reader[9].ToString();
                        dataGridView1.Rows[i].Cells[4].Value = reader[3].ToString();
                        dataGridView1.Rows[i].Cells[5].Value = (double.Parse(reader[3].ToString()) / double.Parse(reader[6].ToString()));
                        dataGridView1.Rows[i].Cells[6].Value = reader[10].ToString();
                        dataGridView1.Rows[i].Cells[7].Value = reader[2].ToString();
                        dataGridView1.Rows[i].Cells[8].Value = reader[4].ToString();
                        dataGridView1.Rows[i].Cells[9].Value = reader[8].ToString();
                        dataGridView1.Rows[i].Cells[10].Value = reader[11].ToString();
                        dataGridView1.Rows[i].Cells[11].Value = "0";
                        dataGridView1.Rows[i].Cells[12].Value = "0";
                    }
                }
            }
            catch { }
            finally
            {
                con.Close();
                reader.Close();
            }
        }
        sales_select s;
        private void button7_Click(object sender, EventArgs e)
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
        public void js()
        {
            Double sum = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)     //查找被选择的数据行 
                {
                    Double d = Double.Parse(dataGridView1.Rows[i].Cells[12].Value.ToString());
                    sum = sum + d;
                }
            }
            textBox3.Text = sum.ToString();
        }
        private void cellchange(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                try
                {
                    dataGridView1.Rows[e.RowIndex].Cells[12].Value = (Double.Parse(dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString()) * Double.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString())).ToString();
                    if (double.Parse(dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString()) > double.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()))
                    {
                        MessageBox.Show("数量超出");
                        dataGridView1.Rows[e.RowIndex].Cells[11].Value = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    }
                }
                catch
                {
                    dataGridView1.Rows[e.RowIndex].Cells[12].Value = 0;
                    dataGridView1.Rows[e.RowIndex].Cells[11].Value = 0;
                }
            }
            js();

        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //if(dataGridView1.Rows[e.RowIndex].Cells[0].Value)
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new sql_conn().getconn();
            MySqlCommand cmd = null;
            con.Open();
            cmd = new MySqlCommand("update sale1 set remark = '退货中' where id = '" + comboBox1.Text + "' ",con);
            cmd.ExecuteNonQuery();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)     //查找被选择的数据行 
                {
                    cmd = new MySqlCommand("update sale2 set remark = '退货中',num =  " + dataGridView1.Rows[i].Cells[11].Value + " where id = '" + comboBox1.Text + "' and commodity = '" + dataGridView1.Rows[i].Cells[2].Value + "'", con);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("退货成功，请等待审核");
        }

    }
}
