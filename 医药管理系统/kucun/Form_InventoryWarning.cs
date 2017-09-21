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
    public partial class Form_InventoryWarning :XtraTabPage
    {
        public Form_InventoryWarning()
        {
            InitializeComponent();
            InitdataGridView1();
            InitColor();
        }

        private void InitdataGridView1()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * From commodity where num < 10", M);
            this.dataGridView1.ReadOnly = true;
            DataSet Ds = new DataSet();
            sda.Fill(Ds, "commodity");
            this.dataGridView1.AutoGenerateColumns = false;
            //使用DataSet绑定时，必须同时指明DateMember 
            this.dataGridView1.DataSource = Ds;
            this.dataGridView1.DataMember = "commodity";
        }

        private void InitColor()
        {
            //根据每一种货物的剩余数量进行预警
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                String Num1 = null;
                int Num2 = 0;
                Num1 = dataGridView1.Rows[i].Cells[6].Value.ToString();
                Num2 = int.Parse(Num1);
                if (Num2 < 10)
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}

