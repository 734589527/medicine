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

namespace 医药管理系统.kucun
{
    public partial class good_sale_delete :XtraTabPage
    {
        public good_sale_delete()
        {
            InitializeComponent();
            checkBox1.CheckState = CheckState.Checked;
            init();
        }
        public void init()
        {
            MySqlConnection con = new sql_conn().getconn();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            dataGridView1.Rows.Clear();
            try
            {
                String sql = "select * from sale1";
                con.Open();
                if (checkBox1.CheckState == CheckState.Checked)
                {
                    sql = sql + " where remark = '退单中'";
                }
                if (checkBox2.CheckState == CheckState.Checked && checkBox1.CheckState == CheckState.Unchecked)
                {
                    sql = sql + " where remark = '退货中'";
                }
                else if (checkBox2.CheckState == CheckState.Checked && checkBox1.CheckState == CheckState.Checked)
                {
                    sql = sql + " or remark = '退货中'";
                }
                if (checkBox2.CheckState == CheckState.Checked || checkBox1.CheckState == CheckState.Checked)
                {
                    cmd = new MySqlCommand(sql, con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int i = dataGridView1.RowCount;
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = reader[0].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = reader[6].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = reader[2].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = reader[5].ToString();
                        dataGridView1.Rows[i].Cells[4].Value = reader[1].ToString();
                        dataGridView1.Rows[i].Cells[5].Value = "审核";
                    }
                }
            }
            catch
            { 
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            init();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            init();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                 if(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()=="退单中")
                 {
                     Sale_check s = new Sale_check();
                     s.StockOutRowId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                     s.state = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                     s.Show();
                     s.FormClosing += new FormClosingEventHandler(re);
                 }
                 if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() == "退货中")
                 {
                     good_check s = new good_check();
                     s.StockOutRowId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                     s.state = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                     s.Show();
                     s.FormClosing += new FormClosingEventHandler(re);
                 }
            }
        }
        public void re(Object o, FormClosingEventArgs e)
        {
            init();
        }
    }
}
