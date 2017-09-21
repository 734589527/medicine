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
    public partial class selectCommodity : Form
    {
        List<spe> spes = new List<spe>();
        List<unit> units = new List<unit>();
       
        public selectCommodity()
        {
            MySqlConnection con = null;
            MySqlDataReader dr = null;
            InitializeComponent();
            try
            {
                init();
                init2();
                this.dataGridView1.MultiSelect = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.GotFocus += new EventHandler(select);
                dataGridView1.LostFocus += new EventHandler(lost);
                button1.Enabled = false;
                con = new sql_conn().getconn();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select *  from commodity ", con);
                dr= cmd.ExecuteReader();
                while (dr.Read())
                {
                    int i = dataGridView1.RowCount;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr[1].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = spes[int.Parse(dr[2].ToString()) - 1].getSpe();
                    dataGridView1.Rows[i].Cells[2].Value = dr[7].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = units[int.Parse(dr[3].ToString()) - 1].getUn();
                    dataGridView1.Rows[i].Cells[4].Value = dr[5].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr[8].ToString();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("数据获取失败");
                MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void select(Object o, EventArgs E)
        {
            button1.Enabled = true;
        }
        public void lost(Object o, EventArgs E)
        {
            if (dataGridView1.SelectedRows == null)
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void init()
        {
            MySqlConnection mysql = new sql_conn().getconn();
            MySqlDataReader reader = null;
            try
            {
                //comboBox1.Items.Clear();
                mysql.Open();
                MySqlCommand cmd = new MySqlCommand("select * from unit", mysql);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    unit u = new unit();
                    u.setId(int.Parse(reader[0].ToString()));
                    u.setUn(reader[1].ToString());
                    units.Add(u);
                }
            }
            catch
            {
                MessageBox.Show("网络连接失败，错误代码1");
            }
            finally
            {
                mysql.Close();
                reader.Close();
            }
        }
        private void init2()
        {
            MySqlConnection mysql = new sql_conn().getconn();
            MySqlDataReader reader = null;
            try
            {
                //comboBox1.Items.Clear();
                mysql.Open();
                MySqlCommand cmd = new MySqlCommand("select * from specification", mysql);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    spe s = new spe();
                    s.setId(int.Parse(reader[0].ToString()));
                    s.setSpe(reader[1].ToString());
                    spes.Add(s);
                }
            }
            catch
            {
                MessageBox.Show("网络连接失败，错误代码1");
            }
            finally
            {
                mysql.Close();
                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("1");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = null;
            try
            {
                init();
                init2();
                dataGridView1.Rows.Clear();
                this.dataGridView1.MultiSelect = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.GotFocus += new EventHandler(select);
                dataGridView1.LostFocus += new EventHandler(lost);
                button1.Enabled = false;
                con = new sql_conn().getconn();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select *  from commodity where Name like binary '%" + textBox1.Text + "%' or Approval like binary '%" + textBox1.Text + "%'", con);
                MySqlDataReader dr1 =null;
                dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    int i = dataGridView1.RowCount;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr1[1].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = spes[int.Parse(dr1[2].ToString()) - 1].getSpe();
                    dataGridView1.Rows[i].Cells[2].Value = dr1[7].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = units[int.Parse(dr1[3].ToString()) - 1].getUn();
                    dataGridView1.Rows[i].Cells[4].Value = dr1[5].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr1[8].ToString();
                }
                dr1.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show("数据获取失败");
                MessageBox.Show(e1.Message.ToString());
            }
            finally
            {
                con.Close();
                
            }
        }
    }
}
