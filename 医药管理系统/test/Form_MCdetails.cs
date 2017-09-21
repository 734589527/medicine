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

namespace 医药管理系统.test
{
    public partial class Form_MCdetails : Form
    {
        public String MCId = null;
        //系统事件**************************************************************************
        public Form_MCdetails()
        {
            InitializeComponent();
        }

        private void Form_MCdetail_Load(object sender, EventArgs e)
        {
            InitdataGridView1();
            InitdataGridView1Kong();
        }
        //自定义事件************************************************************************
        private void InitdataGridView1Kong()
        {//如果表为空的提示信息
            if (dataGridView1.RowCount == 0)
            {
                label1.Text = "没有任何分析项目!";
                label1.BackColor = Color.DarkGray;
                label1.ForeColor = Color.White;
            }
        }
        private void InitdataGridView1()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            String Sql = "Select * From test2 where id = '" + MCId + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(Sql, M);
            //MessageBox.Show(Sql);
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
                this.dataGridView1.Rows.Add();
                for (int n = 0; n < dt.Columns.Count; n++)
                {//给每一行赋值
                    this.dataGridView1.Rows[m].Cells[n].Value = dt.Rows[m][n].ToString();
                }

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
