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
    public partial class Sale_check : Form
    {
        public String StockOutRowId = null;
        public String butongguomark = "0";
        public String state;
        public Sale_check()
        {
            InitializeComponent();
        }

        private void Form_SOdetails_Load(object sender, EventArgs e)
        {
            Initdata();
        }

        private void Initdata()
        {
            list_();
          
            //初始化列表
            InitdataGridView1();          
            //初始化所有标签
            Initlabel();
            Initbutton();
            
        }

        //private MySqlConnection getConn()
        //{
        //    DBHelper D = new DBHelper();
        //    MySqlConnection M = D.getconn();
        //    return M;
        //}

        private void Initlabel()
        {
            //订单号
            label2.Text = StockOutRowId;
            //状态还有客户
            String zhuangtai =null;
            String kehu =null;
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            String Sql = "select * from sale1 where id = '" + StockOutRowId + "'";
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
                    zhuangtai = reader[6].ToString();//状态
                    kehu = custom;//客户
                }
                if(zhuangtai.Equals("1"))
                {
                    label4.Text = zhuangtai;//状态
                    label4.ForeColor = Color.Red;
                }
                else if (zhuangtai.Equals("0"))
                {
                    label4.Text = zhuangtai;//状态
                    label4.ForeColor = Color.Blue;
                }
                else 
                {
                    label4.Text = zhuangtai;//状态
                }
                label5.Text = kehu;//客户

            }
            catch (Exception ex) { }
            finally
            {
                reader.Close();
                M.Close();
            }
        }

        private void InitdataGridView1()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * From sale2 where id =  '"+StockOutRowId+"'", M);

            DataSet Ds = new DataSet();
            sda.Fill(Ds, "stockout2");

            //使用DataSet绑定时，必须同时指明DateMember 
            //this.dataGridView1.DataSource = Ds.Tables[0];
            //this.dataGridView1.DataMember = "stockout1";
            //将数据放到数据表中
            DataTable dt = Ds.Tables["stockout2"];
            //从数据表向datagridview添加数据
            for (int m = 0; m < dt.Rows.Count; m++)
            {
                //每数一行就添加一行空格
                this.dataGridView1.Rows.Add();;
                dataGridView1.Rows[m].Cells[0].Value = dt.Rows[m][0].ToString();
                dataGridView1.Rows[m].Cells[1].Value = dt.Rows[m][1].ToString();
                dataGridView1.Rows[m].Cells[2].Value = dt.Rows[m][9].ToString();
                dataGridView1.Rows[m].Cells[3].Value = dt.Rows[m][2].ToString();
                dataGridView1.Rows[m].Cells[4].Value = dt.Rows[m][3].ToString();
                dataGridView1.Rows[m].Cells[5].Value = dt.Rows[m][4].ToString();
                dataGridView1.Rows[m].Cells[6].Value = dt.Rows[m][5].ToString();
                dataGridView1.Rows[m].Cells[7].Value = dt.Rows[m][6].ToString();
                dataGridView1.Rows[m].Cells[8].Value = dt.Rows[m][7].ToString();
                dataGridView1.Rows[m].Cells[9].Value = dt.Rows[m][8].ToString();
                dataGridView1.Rows[m].Cells[10].Value = dt.Rows[m][12].ToString();

            }

        }

        //通过审核
        private void button1_Click(object sender, EventArgs e)
        {
            //如果已经点击不通过按钮
            if (butongguomark.Equals("1"))
            {
                DialogResult diagorel =
                    MessageBox.Show("您已点击不通过，正在等待您填写意见，如填写完毕请点击确定按钮，是否决定通过审核？确定后将自动关闭页面", "提示：", MessageBoxButtons.OKCancel);
                switch (diagorel)
                {
                    case DialogResult.OK:
                        OK();//如果点击ok那么就执行通过选项
                        this.Close();
                        break;
                    case DialogResult.Cancel:
                        break;
                }

            }
            else
            {
                DialogResult diagorel =
                    MessageBox.Show("确定通过审核？确定后将自动关闭页面", "提示：", MessageBoxButtons.OKCancel);
                switch (diagorel)
                {
                    case DialogResult.OK:
                        OK();//如果点击ok那么就执行通过选项
                        this.Close();
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
        }
        //通过审核操作数据库事件
        private void OK()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            String Sql = "update sale1 set remark = '退单' where id = '" + StockOutRowId + "'";
            MySqlCommand cmd = new MySqlCommand(Sql, M);
            int j = cmd.ExecuteNonQuery();
            if (state == "通过")
            {
                update();
            }
          /*  DialogResult diagorel =
                  MessageBox.Show("是否打印出库单", "提示：", MessageBoxButtons.OKCancel);
            switch (diagorel)
            {
                case DialogResult.OK:
                    printer();
                    break;
                case DialogResult.Cancel:
                    break;
            }*/
            M.Close();
        }
        List<sale_Commodity_class> list = new List<sale_Commodity_class>();
        public String custom, address, jsr, fzr,dh;
        private void list_()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            String Sql = "select * from sale1 where id =  '"+StockOutRowId+"'";
            MySqlCommand cmd = new MySqlCommand(Sql, M);
            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    custom = reader[2].ToString();
                }
            }
            catch
            { 
            }            
            DBHelper D2 = new DBHelper();
            MySqlConnection M2 = D2.getconn();
            M2.Open();
            String Sql2 = "select * from customer where name = '"+custom+"'";
            MySqlCommand cmd2 = new MySqlCommand(Sql2, M2);
            MySqlDataReader reader2 = null;
            try
            {
                reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    address = reader2[2].ToString();
                    dh = reader2[3].ToString();
                }
            }
            catch
            {
            }
            DBHelper D1 = new DBHelper();
            MySqlConnection M1 = D1.getconn();
            M1.Open();
            String Sql1 = "select * from sale2 where id = '" + StockOutRowId + "'";
            MySqlCommand cmd1 = new MySqlCommand(Sql1, M1);
            MySqlDataReader reader1 = null;
            try
            {
                reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    sale_Commodity_class commodity = new sale_Commodity_class();
                    commodity.Name = reader1[1].ToString();
                    commodity.Num = double.Parse(reader1[2].ToString());
                    commodity.Pack = reader1[3].ToString();
                    commodity.Price = double.Parse(reader1[4].ToString());
                    commodity.Ph = reader1[5].ToString();
                    commodity.Spe = reader1[7].ToString();
                    commodity.Sum = double.Parse(reader1[8].ToString());
                    commodity.Gg = reader1[8].ToString();
                    commodity.Unit = reader1[9].ToString();
                    list.Add(commodity);
                }
            }
            catch
            {
            }
        }
        public void update()
        {
            DBHelper D1 = new DBHelper();
            MySqlConnection M1 = D1.getconn();
            M1.Open();
            for (int i = 0; i < list.Count; i++)
            {
                String Sql1 = "update commodity set num = num + "+list[i].Num+" where Name = '"+list[i].Name+"'";
                MySqlCommand cmd1 = new MySqlCommand(Sql1, M1);
                cmd1.ExecuteNonQuery();
            }
           
        }

        //不通过审核操作数据库事件
        private void NO()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            String Sql = "update sale1 set remark = '' where id = '" + StockOutRowId + "'";
            MySqlCommand cmd = new MySqlCommand(Sql, M);
            int j = cmd.ExecuteNonQuery();
            if (j == 1)
            {
            }
            M.Close();
        }

        //不通过审核，初定意见
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            MessageBox.Show("如果不通过审核请填写审核意见！");
            butongguomark = "1";
        }

        //暂不处理
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //确定按钮
        private void button4_Click(object sender, EventArgs e)
        {
            if (butongguomark.Equals("1"))
            {
                DialogResult diagorel =
                    MessageBox.Show("将使此单不通过，请确定操作！确定后将自动关闭页面", "提示：", MessageBoxButtons.OKCancel);
                switch (diagorel)
                {
                    case DialogResult.OK:
                        NO();//如果点击ok那么就执行通过选项
                        this.Close();
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
        }

        private void Initbutton()
        {//如果是已经通过审核或者不通过的都没有这些权限
           /* if (!label4.Text.Equals("未通过审核"))
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            if (label4.Text.Equals("已通过审核"))
            {
                button5.Enabled = true;
            }*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            printer();
        }
        public void printer()
        {
           /* out_report out1=new out_report();
            out1.setKH(custom);
            out1.setjsr(jsr);
            out1.setfzr(fzr);
            out1.setdzdh(dh, address);
            out1.setDJ(StockOutRowId);
            out1.addCommodity(list);
            out1.PrintDialog();*/
        }
    }
}
