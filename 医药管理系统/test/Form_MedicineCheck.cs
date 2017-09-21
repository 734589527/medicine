using DevExpress.XtraTab;
using DevExpress.XtraReports.UI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using 医药管理系统.Dao;
using 医药管理系统.report;

namespace 医药管理系统.test
{
   
    public partial class Form_MedicineCheck :XtraTabPage
    {
        //属性******************************************************************************
        private int flagone = 0;
        private int flagtwo = 0;
        List<jy_dao> list = new List<jy_dao>();
        //系统事件**************************************************************************
        public Form_MedicineCheck()
        {
            InitializeComponent();
            for (int i = 0; i < 6; i++)
            { 
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = "";
                dataGridView1.Rows[i].Cells[1].Value = "";
                dataGridView1.Rows[i].Cells[2].Value = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {//1 3 8 10 11 12 13 14
            //检验是否为空
            checkKong();
            if (flagone == 0 && flagtwo == 0)
            {
                //插入test1表
                test1Insert();
                //插入test2表
                test2Insert();
                jy_report jy = new jy_report();
                jy.init(textBox1.Text, dateTimePicker1.Text, textBox2.Text, dateTimePicker2.Text, textBox3.Text, dateTimePicker3.Text, textBox4.Text, textBox8.Text, textBox5.Text, textBox10.Text, textBox11.Text, textBox14.Text, textBox13.Text, textBox12.Text);
                for (int i = 0; i <5; i++)
                {
                    jy_dao j = new jy_dao();
                    j.fxxm = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    j.jszb = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    j.fxxj = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    list.Add(j);
                }
                jy.init2(list);
                jy.PrintDialog();

            }
            else if (flagone != 0 && flagtwo == 0)
            {
                label16.Text = "图中变红框体为必填！";
                label16.ForeColor = Color.Red;
            }
            else if (flagone == 0 && flagtwo != 0)
            {
                textBox4.BackColor = Color.Red;
                label16.Text = "图中变红框体必须填入整数！";
                label16.ForeColor = Color.Red;
            }
            else
            {
                label16.Text = "";
            }

        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {//检验其是不是数字
            if (shuzi(textBox4.Text))
            {
                flagtwo = 0;
                textBox4.BackColor = Color.White;
            }
            else
            {
                flagtwo = 1;
                textBox4.BackColor = Color.Red;
                label16.Text = "图中变红框体必须填入整数！";
                label16.ForeColor = Color.Red;
            }
        }
        //自定义函数****************************************************************************
        //检查必填项是否为空
        private void checkKong()
        {//1 3 8 10 11 12 13 14
            int flag1 = 0;
            int flag3 = 0;
            int flag4 = 0;
            int flag8 = 0;
            int flag10 = 0;
            int flag11 = 0;
            int flag12 = 0;
            int flag13 = 0;
            int flag14 = 0;
            if (textBox1.Text.Equals(""))
            {
                flag1 = 1;
                textBox1.BackColor = Color.Red;
            }
            else
            {
                textBox1.BackColor = Color.White;
            }

            if (textBox3.Text.Equals(""))
            {
                flag3 = 1;
                textBox3.BackColor = Color.Red;
            }
            else
            {
                textBox3.BackColor = Color.White;
            }

            if (textBox4.Text.Equals(""))
            {
                flag4 = 1;
                textBox4.BackColor = Color.Red;
            }
            else
            {
                textBox4.BackColor = Color.White;
            }

            if (textBox8.Text.Equals(""))
            {
                flag8 = 1;
                textBox8.BackColor = Color.Red;
            }
            else
            {
                textBox8.BackColor = Color.White;
            }

            if (textBox10.Text.Equals(""))
            {
                flag10 = 1;
                textBox10.BackColor = Color.Red;
            }
            else
            {
                textBox10.BackColor = Color.White;
            }

            if (textBox11.Text.Equals(""))
            {
                flag11 = 1;
                textBox11.BackColor = Color.Red;
            }
            else
            {
                textBox11.BackColor = Color.White;
            }

            if (textBox12.Text.Equals(""))
            {
                flag12 = 1;
                textBox12.BackColor = Color.Red;
            }
            else
            {
                textBox12.BackColor = Color.White;
            }

            if (textBox13.Text.Equals(""))
            {
                flag13 = 1;
                textBox13.BackColor = Color.Red;
            }
            else
            {
                textBox13.BackColor = Color.White;
            }

            if (textBox14.Text.Equals(""))
            {
                flag14 = 1;
                textBox14.BackColor = Color.Red;
            }
            else
            {
                textBox14.BackColor = Color.White;
            }
            //1 3 8 10 11 12 13 14
            if (flag1 == 0 && flag4 == 0 && flag3 == 0 && flag8 == 0 && flag10 == 0 && flag11 == 0 && flag12 == 0 && flag13 == 0 && flag14 == 0)
            {
                flagone = 0;
            }
            else
            {
                flagone = 1;
            }
        }

        private bool shuzi(string message)
        {//判断其是不是数字
            int result = 0;
            try
            {
                result = int.Parse(message);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void test1Insert()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            try
            {
                M.Open();
                MySqlCommand cmd = new MySqlCommand("insert into test1(name,department,specification,amount,packing,declarationInspectionDate,assayDate,reportDate,commodityBatchNumber,inspectionbasis,conclusion,assessor,analyst,laboratoryTechnician) values('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + float.Parse(this.textBox4.Text.Trim().ToString()) + "','" + textBox5.Text.Trim() + "','" + dateTimePicker1.Text.Trim() + "','" + dateTimePicker2.Text.Trim() + "','" + dateTimePicker3.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + textBox10.Text.Trim() + "','" + textBox11.Text.Trim() + "','" + textBox12.Text.Trim() + "','" + textBox13.Text.Trim() + "','" + textBox14.Text.Trim() + "')", M);
                //cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@name", this.textBox1.Text.Trim());
                //cmd.Parameters.AddWithValue("@department", this.textBox2.Text.Trim());
                //cmd.Parameters.AddWithValue("@specification", this.textBox3.Text.Trim());
                //cmd.Parameters.AddWithValue("@amount", float.Parse(this.textBox4.Text.Trim().ToString()));
                //cmd.Parameters.AddWithValue("@packing", this.textBox5.Text.Trim());
                //cmd.Parameters.AddWithValue("@declarationInspectionDate", this.dateTimePicker1.Text.Trim());
                //cmd.Parameters.AddWithValue("@assayDate", this.dateTimePicker2.Text.Trim());
                //cmd.Parameters.AddWithValue("@reportDate", this.dateTimePicker3.Text.Trim());
                //cmd.Parameters.AddWithValue("@commodityBatchNumber", this.textBox8.Text.Trim());
                //cmd.Parameters.AddWithValue("@inspectionbasis", this.textBox10.Text.Trim());
                //cmd.Parameters.AddWithValue("@conclusion", this.textBox11.Text.Trim());
                //cmd.Parameters.AddWithValue("@assessor", this.textBox14.Text.Trim());
                //cmd.Parameters.AddWithValue("@analyst", this.textBox13.Text.Trim());
                //cmd.Parameters.AddWithValue("@laboratoryTechnician", this.textBox12.Text.Trim());
                int j = cmd.ExecuteNonQuery();
                if (j == 1)
                {
                    MessageBox.Show("药品检验完成");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                M.Close();
            }
        }
        //通过name找到相应的id来为test2相应的字段输入id
        private String findId()
        {
            String id = "";
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            String Sql = "select * from test1 where name = '" + textBox1.Text.Trim() + "'";
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
                    id = reader[0].ToString();//规格
                }

            }
            catch (Exception ex) { }
            finally
            {
                reader.Close();
                M.Close();
            }
            return id;
        }

        private void test2Insert()
        {
            DBHelper D = new DBHelper();
            MySqlConnection M = D.getconn();
            M.Open();
            String analysisProject = "";
            String qualification = "";
            String conclusion = "";
            for (int m = 0; m < dataGridView1.Rows.Count - 1; m++)
            {
                analysisProject = dataGridView1.Rows[m].Cells[0].Value.ToString();
                qualification = dataGridView1.Rows[m].Cells[1].Value.ToString();
                conclusion = dataGridView1.Rows[m].Cells[2].Value.ToString();
                MySqlCommand cmd = new MySqlCommand("insert into test2(id,analysisProject,qualification,conclusion) values('" + findId() + "','" + analysisProject + "','" + qualification + "','" + conclusion + "')", M);
                int j = cmd.ExecuteNonQuery();
                if (j == 1)
                {
                }
            }
            M.Close();
        }
    }
}

