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
    public partial class Form_StockOutCheck : XtraTabPage
    {
       
             private Form_SOdetails details;
        private DataGridViewCell clickedCell;
        String salesId;
        public Form_StockOutCheck()
        {
            InitializeComponent();
            InitdataGridView1();
            this.Show();
        }

        private void Form_StockOutCheck_Load(object sender, EventArgs e)
        {

        }

        public void InitdataGridView1()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * From stockout1 where states != '不通过' and states != '通过'", M);

            DataSet Ds = new DataSet();
            sda.Fill(Ds, "stockout1");

            //使用DataSet绑定时，必须同时指明DateMember 
            //this.dataGridView1.DataSource = Ds.Tables[0];
            //this.dataGridView1.DataMember = "stockout1";
            //将数据放到数据表中
            DataTable dt = Ds.Tables["stockout1"];
            //从数据表向datagridview添加数据
            for (int m = 0; m < dt.Rows.Count; m++)
            {
                //每数一行就添加一行空格
                this.dataGridView1.Rows.Add();
                for (int n = 0; n < dt.Columns.Count-1; n++)
                {//给每一行赋值
                    //状态如果是1那么就是未通过审核状态
                    if (n == 1)
                    {
                        if (dt.Rows[m][n].ToString().Equals("1"))
                        {
                            this.dataGridView1.Rows[m].Cells[n].Value = dt.Rows[m][n].ToString();
                            this.dataGridView1.Rows[m].Cells[n].Style.ForeColor = Color.Red;
                        }
                        else if (dt.Rows[m][n].ToString().Equals("0"))
                        {
                            this.dataGridView1.Rows[m].Cells[n].Value = dt.Rows[m][n].ToString();
                            this.dataGridView1.Rows[m].Cells[n].Style.ForeColor = Color.Blue;
                        }
                        else 
                        {
                            this.dataGridView1.Rows[m].Cells[n].Value = dt.Rows[m][n].ToString();
                        }
                    }
                    else
                    {
                        this.dataGridView1.Rows[m].Cells[n].Value = dt.Rows[m][n].ToString();
                    }
                }
                this.dataGridView1["查看详情", m].Value = "详情";
                    
            }
            
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//如果是左键点击了格子
            {
                DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);//获取鼠标点击坐标
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    clickedCell = dataGridView1.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                    if (clickedCell.ColumnIndex == 8)
                    {//上边括号内是为了确定点击的是有按钮的那一列，而且操作点击
                        DataGridViewRow row = dataGridView1.Rows[clickedCell.RowIndex];
                        details = new Form_SOdetails();
                        //将选中列id发送给显示详情界面
                        details.StockOutRowId = row.Cells[0].Value.ToString();
                        details.salesId = row.Cells[7].Value.ToString();
                        details.fzr = row.Cells[4].Value.ToString();
                        details.jsr = row.Cells[5].Value.ToString();
                        details.Show();
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            InitdataGridView1();
        }
    }
}

