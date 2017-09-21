using DevExpress.XtraTab;
using InventoryManagentSystem;
using InventoryManagentSystem.bean;
using InventoryManagentSystem.load;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 医药管理系统.drug
{
    public partial class queryDrug :XtraTabPage
    {
        private static int pageCount0 = 2;
        private DataGridViewCell clickedCell;
        public queryDrug()
        {
            InitializeComponent();
            commDao info = new commDao();
            Commodity commodity = null;
            this.pageDeal(commodity, Convert.ToInt32(pageNo.Text));
        }

        private void pageDeal(Commodity commodity, int pageNo1)
        {
            commDao info = new commDao();
            if (info.getCount(info.getSql(commodity)) != 0)
            {
                Paging page = new Paging(info.getCount(info.getSql(commodity)), pageCount0, pageNo1);
                //MessageBox.Show(info.getSql(commodity));
                //MessageBox.Show(info.getCount(info.getSql(commodity)).ToString());
                if (pageNo1 <= 1)
                {
                    lastPage.Enabled = false;
                    pageNo1 = 1;
                }
                else
                {
                    lastPage.Enabled = true;
                }
                if (pageNo1 >= page.getPageNum())
                {
                    nextPage.Enabled = false;
                    pageNo1 = page.getPageNum();
                }
                else
                {
                    nextPage.Enabled = true;
                }
                if (page.getPageNum() == 1)
                {
                    lastPage.Enabled = false;
                    nextPage.Enabled = false;
                }
                //更新控件
                pageNo.Text = pageNo1.ToString();
                noTbx.Text = pageNo1.ToString();
                countTbx.Text = pageCount0.ToString();
                pageNum.Text = page.getPageNum().ToString();
                Paging page1 = new Paging(info.getCount(info.getSql(commodity)), pageCount0, pageNo1);
                List<Commodity> list = info.getCommBySelect(info.getSql(commodity, page1.getRecordStart(), pageCount0));
                info.showDgv(dgv, list);
            }
            else
            {
                dgv.Rows.Clear();
                pageNo.Text = "1";
                noTbx.Text = "1";
                countTbx.Text = "1";
                pageNum.Text = "1";
                lastPage.Enabled = false;
                nextPage.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            addDrug add = new addDrug();
            add.Show();
        }

        private Commodity getCommodity()
        {
            Commodity commodity = new Commodity();
            try
            {
                commodity.setName(tbxname.Text);
                commodity.setBid(bidtbx.Text);
                commodity.setPrice(pricetbx.Text);
                commodity.setUnit(unittbx.Text);
                commodity.setSpecification(specificationtbx.Text);
                commodity.setNum(numtbx.Text);
                commodity.setPacking(packingtbx.Text);
                commodity.setApproval(approvaltbx.Text);
            }
            catch { }
            return commodity;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.pageDeal(this.getCommodity(), Convert.ToInt32(pageNo.Text));
        }

        private void dgv_MouseDown(object sender, MouseEventArgs e)
        {
            commDao info = new commDao();
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo hit = dgv.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    clickedCell = dgv.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                    if (clickedCell.ColumnIndex == 9)
                    {
                        Commodity commodity = new Commodity();
                        commodity.setId(Convert.ToInt32(dgv.Rows[clickedCell.RowIndex].Cells[0].Value));
                        commodity.setName(dgv.Rows[clickedCell.RowIndex].Cells[1].Value.ToString());
                        commodity.setSpecification(dgv.Rows[clickedCell.RowIndex].Cells[2].Value.ToString());
                        commodity.setBid(dgv.Rows[clickedCell.RowIndex].Cells[3].Value.ToString());
                        commodity.setPrice(dgv.Rows[clickedCell.RowIndex].Cells[4].Value.ToString());
                        commodity.setUnit(dgv.Rows[clickedCell.RowIndex].Cells[5].Value.ToString());
                        commodity.setPacking(dgv.Rows[clickedCell.RowIndex].Cells[6].Value.ToString());
                        commodity.setNum(dgv.Rows[clickedCell.RowIndex].Cells[7].Value.ToString());
                        commodity.setApproval(dgv.Rows[clickedCell.RowIndex].Cells[8].Value.ToString());
                        updateDrug u = new updateDrug(commodity, clickedCell.RowIndex);
                        u.ShowDialog();
                        List<Commodity> list = info.getCommBySelect(info.getSql(commodity.getId()));
                        dgv.Rows[clickedCell.RowIndex].Cells[0].Value = list[0].getId().ToString();
                        dgv.Rows[clickedCell.RowIndex].Cells[1].Value = list[0].getName();
                        dgv.Rows[clickedCell.RowIndex].Cells[2].Value = list[0].getSpecification();
                        dgv.Rows[clickedCell.RowIndex].Cells[3].Value = list[0].getBid();
                        dgv.Rows[clickedCell.RowIndex].Cells[4].Value = list[0].getPrice();
                        dgv.Rows[clickedCell.RowIndex].Cells[5].Value = list[0].getUnit();
                        dgv.Rows[clickedCell.RowIndex].Cells[6].Value = list[0].getPacking();
                        dgv.Rows[clickedCell.RowIndex].Cells[7].Value = list[0].getNum();
                        dgv.Rows[clickedCell.RowIndex].Cells[8].Value = list[0].getApproval();

                    }
                    if (clickedCell.ColumnIndex == 10)
                    {

                        if (MessageBox.Show("是否删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (info.DeleteCommodity(Convert.ToInt32(dgv.Rows[clickedCell.RowIndex].Cells[0].Value)))
                            {
                                MessageBox.Show("删除成功!");
                            }
                            else
                            {
                                MessageBox.Show("删除失败!");
                            }
                            this.pageDeal(this.getCommodity(), Convert.ToInt32(pageNo.Text));
                        }
                    }
                }
            }
        }
        private void lastPage_Click(object sender, EventArgs e)
        {
            this.pageDeal(this.getCommodity(), Convert.ToInt32(pageNo.Text) - 1);
        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            this.pageDeal(this.getCommodity(), Convert.ToInt32(pageNo.Text) + 1);
        }

        private void goTo_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(noTbx.Text);
            }
            catch
            {
                noTbx.Text = pageNo.Text.ToString();
            }
            this.pageDeal(this.getCommodity(), Convert.ToInt32(noTbx.Text));
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                queryDrug.pageCount0 = Convert.ToInt32(countTbx.Text);
            }
            catch
            {
                countTbx.Text = pageCount0.ToString();
            }
            this.pageDeal(this.getCommodity(), 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbxname.Text = "";
            bidtbx.Text = "";
            pricetbx.Text = "";
            numtbx.Text = "";
            packingtbx.Text = "";
            specificationtbx.Text = "";
            unittbx.Text = "";
            approvaltbx.Text = "";
        }

        private void bidtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            if ((int)e.KeyChar == 46)//小数点
            {
                if (bidtbx.Text.Length <= 0)

                    e.Handled = true; //小数点不能在第一位

                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(bidtbx.Text, out oldf);
                    b2 = float.TryParse(bidtbx.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void pricetbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            if ((int)e.KeyChar == 46)//小数点
            {
                if (pricetbx.Text.Length <= 0)

                    e.Handled = true; //小数点不能在第一位

                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(pricetbx.Text, out oldf);
                    b2 = float.TryParse(pricetbx.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void packingtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)

                e.Handled = true;
            else
                e.Handled = false;
        }

        private void numtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)

                e.Handled = true;
            else
                e.Handled = false;
        }

    }
}

