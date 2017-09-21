using DevExpress.XtraReports.UI;
using DevExpress.XtraTab;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 医药管理系统
{
    public partial class sale_Add :XtraTabPage
    {
        List<spe> spes = new List<spe>();
        List<unit> units = new List<unit>();
        List<sale_Commodity_class> sales = new List<sale_Commodity_class>();
        String phone;
        public sale_Add()
        {
            InitializeComponent();
            Thread custom = new Thread(new ThreadStart(custon_load));
            textBox5.LostFocus += new EventHandler(text5_LostFocus);
            custom.Start();
            combobox3_load();
            this.dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            textBox9.LostFocus += new EventHandler(pack_Lost);
            textBox6.LostFocus += new EventHandler(num_Lost);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            init3();
            init(); 
            init2();

        }
        private void pack_Lost(Object O, EventArgs E)
        {
            try
            {
                if (comboBox5.Text != ""||textBox9.Text!="")
                {
                    textBox6.Text = (float.Parse(textBox9.Text) * float.Parse(comboBox5.Text)).ToString();
                    textBox8.Text = (float.Parse(textBox6.Text) * double.Parse(textBox7.Text)).ToString();
                }
                else
                {
                    if (comboBox6.Focused == false && textBox9.Text != "")
                        MessageBox.Show("请选择包装");
                }
            }
            catch
            { 
            }
        }
        private void num_Lost(Object O, EventArgs E)
        {
            try
            {
                if (comboBox5.Text != ""||textBox6.Text!="")
                {

                    textBox9.Text = (float.Parse(textBox6.Text) / float.Parse(comboBox5.Text)).ToString();
                    textBox8.Text = (float.Parse(textBox6.Text) * double.Parse(textBox7.Text)).ToString();
                }
                else
                {
                    if (comboBox6.Focused == false&&textBox6.Text!="")
                        MessageBox.Show("请选择包装");
                }
            }
            catch
            { 
            }
           
        }
        private void text5_LostFocus(Object o, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(text5_Lost));
            th.Start();
        }
        private void text5_Lost()
        {
            MySqlConnection mysql = new sql_conn().getconn();
            MySqlDataReader reader = null;
            try
            {
               /* comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();*/
                mysql.Open();
                MySqlCommand cmd = new MySqlCommand("select *  from commodity where  Approval = '" + textBox5.Text + "'", mysql);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {         
                    for (int i = 0; i < units.LongCount(); i++)
                    {
                        if (units[i].getId().ToString() == reader[3].ToString())
                        {
                            int a = 0;
                            comboBox4.Text = units[i].getUn().ToString();
                        }
                    }
                    for (int i = 0; i < spes.LongCount(); i++)
                    {
                        if (spes[i].getId().ToString() == reader[2].ToString())
                        {
                            int a = 0;
                            comboBox3.Text=spes[i].getSpe().ToString();
                        }
                    }
                    int a1 = 0;
                    comboBox2.Text = reader[1].ToString();
                    textBox7.Text = reader[5].ToString();
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
                    comboBox4.Items.Add(reader[1].ToString());
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
        private void init3()
        {
            MySqlConnection mysql = new sql_conn().getconn();
            MySqlDataReader reader = null;
            try
            {
                //comboBox1.Items.Clear();
                mysql.Open();
                MySqlCommand cmd = new MySqlCommand("select * from staff where Username in (select username from user)" /*where Part in (select ID from part where orderInsert = '1'))"*/, mysql);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox6.Items.Add(reader[1].ToString());
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
                   comboBox3.Items.Add(reader[1].ToString());
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX8_Click(object sender, EventArgs e)
        {

        }
        public void custon_load()
        {
            MySqlConnection mysql = new sql_conn().getconn();
            MySqlDataReader reader = null;
            try
            {
                comboBox1.Items.Clear();
                mysql.Open();
                MySqlCommand cmd = new MySqlCommand("select * from customer", mysql);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[1].ToString());
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
        public void custom_change()
        {
            MySqlConnection mysql = new sql_conn().getconn();
            MySqlDataReader reader = null;
            try
            {
                mysql.Open();
                MySqlCommand cmd = new MySqlCommand("select * from customer where name = '"+comboBox1.Text+"'", mysql);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox2.Text=reader[2].ToString();
                    phone = reader[3].ToString();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(custom_change));
            th.Start();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(combobox2_change));
            th.Start();
        }
        public void combobox2_change()
        {
            if (comboBox5.Text == "" && comboBox4.Text == "" && comboBox3.Text == "")
            {
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();
            }
            MySqlConnection mysql = new sql_conn().getconn();
            MySqlDataReader reader = null;
            try
            {
                
                mysql.Open();
                MySqlCommand cmd = new MySqlCommand("select *  from commodity where name = '" + comboBox2.Text + "'", mysql);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < units.LongCount(); i++)
                    {
                        if (units[i].getId().ToString() == reader[3].ToString() && comboBox4.Items.Contains(units[i].getUn().ToString()) == false)
                        {
                            comboBox4.Items.Add(units[i].getUn().ToString());
                        }
                    }
                    for (int i = 0; i < spes.LongCount(); i++)
                    {
                        if (spes[i].getId().ToString() == reader[2].ToString() && comboBox3.Items.Contains(spes[i].getSpe().ToString()) == false)
                        {
                            comboBox3.Items.Add(spes[i].getSpe().ToString());
                        }
                    }
                    if (comboBox5.Items.Contains(reader[7].ToString()) == false)
                        comboBox5.Items.Add ( reader[7].ToString());
                    textBox7.Text = reader[5].ToString();
                    textBox5.Text = reader[8].ToString();
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
        public void combobox3_load()
        {
             if (comboBox5.Text == "" && comboBox4.Text == "" && comboBox3.Text == "")
            {
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();
            }
                MySqlConnection mysql = new sql_conn().getconn();
                MySqlDataReader reader = null;
                try
                {
                    mysql.Open();
                    MySqlCommand cmd = new MySqlCommand("select *  from commodity ", mysql);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (comboBox2.Items.Contains(reader[1].ToString()) == false)
                            comboBox2.Items.Add(reader[1].ToString());
                        for (int i = 0; i < units.LongCount(); i++)
                        {
                            if (units[i].getId().ToString() == reader[3].ToString() && comboBox4.Items.Contains(units[i].getUn().ToString()) == false)
                            {
                                comboBox4.Items.Add(units[i].getUn().ToString());
                            }
                        }
                        for (int i = 0; i < spes.LongCount(); i++)
                        {
                            if (spes[i].getId().ToString() == reader[2].ToString() && comboBox3.Items.Contains(spes[i].getSpe().ToString()) == false)
                            {
                                comboBox3.Items.Add(spes[i].getSpe().ToString());
                            }
                        }
                        if (comboBox5.Items.Contains(reader[7].ToString()) == false)
                            comboBox5.Items.Add(reader[7].ToString());
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            sale_Commodity_class s = new sale_Commodity_class();
            try
            {
                if (textBox1.Text != "" && comboBox1.Text != "")
                {
                    if (MessageBox.Show("是否确定添加？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int i = dataGridView1.RowCount;
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = textBox1.Text;
                        textBox1.ReadOnly = true;
                        dataGridView1.Rows[i].Cells[1].Value = comboBox2.Text;
                        dataGridView1.Rows[i].Cells[2].Value = comboBox3.Text;
                        dataGridView1.Rows[i].Cells[3].Value = comboBox5.Text;
                        dataGridView1.Rows[i].Cells[4].Value = textBox9.Text;
                        dataGridView1.Rows[i].Cells[5].Value = comboBox4.Text;
                        dataGridView1.Rows[i].Cells[6].Value = textBox6.Text;
                        dataGridView1.Rows[i].Cells[7].Value = textBox7.Text;
                        dataGridView1.Rows[i].Cells[8].Value = textBox8.Text;
                        dataGridView1.Rows[i].Cells[9].Value = textBox3.Text;
                        dataGridView1.Rows[i].Cells[10].Value = textBox10.Text;
                        dataGridView1.Rows[i].Cells[11].Value = textBox4.Text;
                        comboBox1.Enabled = false;
                        textBox2.ReadOnly = true;
                        comboBox6.Enabled = false;
                        s.setID(textBox1.Text, comboBox1.Text, textBox2.Text, textBox3.Text, comboBox2.Text, textBox4.Text, textBox5.Text, comboBox3.Text, comboBox5.Text, comboBox4.Text, comboBox6.Text, Double.Parse(textBox6.Text), Double.Parse(textBox9.Text), Double.Parse(textBox8.Text), Double.Parse(textBox7.Text));
                        s.Sbph = textBox10.Text;
                        comboBox2.Text = "";
                        comboBox3.Text = "";
                        comboBox4.Text = "";
                        comboBox5.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("请将资料填写完整");
                }
            }
            catch
            {
            }
                sales.Add(s);
       

        }
        selectCommodity sc;
        private void button5_Click(object sender, EventArgs e)
        {
            sc = new selectCommodity();
            sc.button1.Click += new EventHandler(select_add);
            sc.dataGridView1.DoubleClick += new EventHandler(select_add);
            sc.ShowDialog();
            
        }
        private void select_add(Object o,EventArgs E)
        {
            //MessageBox.Show("点击");
            try
            {
                comboBox2.Text = sc.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                comboBox3.Text = sc.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox5.Text = sc.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox4.Text = sc.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox7.Text = sc.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox5.Text = sc.dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                sc.Close();
            }
            catch
            {
                MessageBox.Show("选择错误");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sales.Count > 0)
            {
                if (MessageBox.Show("是否确定添加？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    try
                    {
                        MySqlConnection mysql = new sql_conn().getconn();
                        mysql.Open();
                        Double sum = 0;
                        for (int i = 0; i < sales.Count; i++)
                        {
                            sum = sum + sales[i].Sum;
                        }
                        MySqlCommand cmd = new MySqlCommand("insert into sale1 values ('" + sales[0].ID1 + "','" + DateTime.Now.ToShortDateString() + "','" + sales[0].Custom + "','" + sales[0].Jsr + "'," + sum + ",'待出库','')", mysql);
                        cmd.ExecuteNonQuery();
                        for (int i = 0; i < sales.Count; i++)
                        {
                            cmd = new MySqlCommand("insert into sale2 values ('" + sales[i].ID1 + "','" + sales[i].Name + "'," + sales[i].Num + "," + sales[i].Pack + "," + sales[i].Price + ",'" + sales[i].Ph + "','" + sales[i].Data + "','" + sales[i].Spe + "'," + sales[i].Sum + ",'" + sales[i].Gg + "','" + sales[i].Unit + "','" + sales[i].Sbph + "','','')", mysql);
                            cmd.ExecuteNonQuery();
                        }
                        mysql.Close();
                        MessageBox.Show("添加成功");
                    }
                    catch (Exception f)
                    {
                        MessageBox.Show("销售单号已存在");
                        MySqlConnection mysql = new sql_conn().getconn();
                        mysql.Open();
                        MySqlCommand cmd = new MySqlCommand("delete from sale1 where id = '"+sales[0].ID1+"'", mysql);
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            else
            {
                MessageBox.Show("销售单内无商品");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认清空？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox2.Enabled = true;
                comboBox1.Enabled = true;
                textBox2.ReadOnly = false;
                textBox1.ReadOnly = false;
                comboBox6.Enabled = true;
                dataGridView1.Rows.Clear();
                sales.Clear();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                sales.RemoveAt(dataGridView1.SelectedRows[0].Index);
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XtraReport1 x = new XtraReport1();
            x.addCommodity(sales);
            x.setDJ (textBox1.Text);
            x.setKH(comboBox1.Text);
            x.rq("1");
            x.setjsr(comboBox6.Text);
            x.setdzdh(phone, textBox2.Text);
            x.PrintDialog();
        }
    }
}
