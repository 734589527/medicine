using DevExpress.XtraCharts;
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
using 医药管理系统.Dao;

namespace 医药管理系统.report
{
    public partial class out_reports : XtraTabPage
    {
        List<stockOut> list = new List<stockOut>();
        public out_reports()
        {
            InitializeComponent();
            this.comboBox1.Text = "全部";
            InitData("select commodity,amount from sale2 where id in (select SaleID from stockout1 ) and remark != '退单'");
            this.comboBox1.SelectedValueChanged += new EventHandler(value_change);
        }
        private void value_change(Object o, EventArgs e)
        {
            String sql = "select commodity,amount from stockin2 ";
            if (comboBox1.Text == "今天")
            {
                sql = "select commodity,amount from sale2 where id in (select SaleID from stockout1 where date(str_to_date(stockout1.date,'%Y-%m-%d')) between' " + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + "') and remark != '退单'";
            }
            else if (comboBox1.Text == "三天")
            {
                sql = "select commodity,amount from sale2 where id in (select SaleID from stockout1 where date(str_to_date(stockout1.date,'%Y-%m-%d')) between' " + DateTime.Now.AddDays(-3).ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + "') and remark != '退单'";
            }
            else if (comboBox1.Text == "本周")
            {
                sql = "select commodity,amount from sale2 where id in (select SaleID from stockout1 where date(str_to_date(stockout1.date,'%Y-%m-%d')) between' " + DateTime.Now.AddDays(Convert.ToDouble((0 - Convert.ToInt16(DateTime.Now.DayOfWeek)))).ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + "') and remark != '退单'";
            }
            else if (comboBox1.Text == "一个月")
            {
                sql = "select commodity,amount from sale2 where id in (select SaleID from stockout1 where date(str_to_date(stockout1.date,'%Y-%m-%d')) between' " + DateTime.Now.AddMonths(-1).ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + "') and remark != '退单'";
            }
            else if (comboBox1.Text == "三个月")
            {
                sql = "select commodity,amount from sale2 where id in (select SaleID from stockout1 where date(str_to_date(stockout1.date,'%Y-%m-%d')) between' " + DateTime.Now.AddMonths(-3).ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + "') and remark != '退单'";
            }
            else if (comboBox1.Text == "六个月")
            {
                sql = "select commodity,amount from sale2 where id in (select SaleID from stockout1 where date(str_to_date(stockout1.date,'%Y-%m-%d')) between' " + DateTime.Now.AddMonths(-6).ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + "') and remark != '退单'";
            }
            else if (comboBox1.Text == "12个月")
            {
                sql = "select commodity,amount from sale2 where id in (select SaleID from stockout1 where date(str_to_date(stockout1.date,'%Y-%m-%d')) between' " + DateTime.Now.AddYears(-1).ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + "') and remark != '退单'";
            }
            else if (comboBox1.Text == "全部")
            {
                sql = "select commodity,amount from sale2 where id in (select SaleID from stockout1 ) and remark != '退单'";
            }
            InitData(sql);
        }
        private void InitData(String sql)
        {
            try
            {
                list.Clear();
                MySqlConnection con = new sql_conn().getconn();
                con.Open();
                MySqlDataReader dr;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int flag = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].name == dr[0].ToString())
                        {
                            list[i].amount = list[i].amount + int.Parse(dr[1].ToString());
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        stockOut st = new stockOut();
                        st.name = dr[0].ToString();
                        st.amount = int.Parse(dr[1].ToString());
                        list.Add(st);

                    }
                }
                InitcharControls();
            }
            catch
            {
                MessageBox.Show("数据库链接失败，请重试");
            }

        }
        private void InitcharControls()
        {
            chartControl1.Series.Clear();
            for (int i = 0; i < list.Count; i++)
            {

                Series Series1 = new Series(list[i].name, ViewType.Bar);
                Series1.Points.Add(new SeriesPoint(list[i].name, list[i].amount));
                BarSeriesView bsv = (BarSeriesView)Series1.View;
                bsv.BarWidth = 0.2;
                chartControl1.Series.Add(Series1);
            }

        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }
    }
}
