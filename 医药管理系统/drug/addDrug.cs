using DevExpress.XtraTab;
using InventoryManagentSystem.bean;
using InventoryManagentSystem.Helper;
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
    public partial class addDrug : XtraTabPage
    {
        public addDrug()
        {
            InitializeComponent();
            Win32Utility.SetCueText(name, "输入药品名");
            Win32Utility.SetCueText(specification, "选择规格");
            Win32Utility.SetCueText(unit, "选择记录单位");
            Win32Utility.SetCueText(bid, "输入药品进价");
            Win32Utility.SetCueText(price, "输入药品售价");
            Win32Utility.SetCueText(packing, "选择包装数量");
            Win32Utility.SetCueText(approval, "输入批准文号");
            specification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            commDao info = new commDao();
            List<Specification> specificationList = info.loadSpecification();
            for (int i = 0; i < specificationList.Count; i++)
            {
                specification.Items.Add(specificationList[i].getName());
            }
            List<Unit> unitList = info.loadUnit();
            for (int i = 0; i < unitList.Count; i++)
            {
                unit.Items.Add(unitList[i].getName());
            }
            List<String> packingList = info.loadPacking();
            for (int i = 0; i < packingList.Count; i++)
            {
                packing.Items.Add(packingList[i]);
            }
        }
        public void re()
        {
            specification.Items.Clear();
            unit.Items.Clear();
            commDao info = new commDao();
            List<Specification> specificationList = info.loadSpecification();
            for (int i = 0; i < specificationList.Count; i++)
            {
                specification.Items.Add(specificationList[i].getName());
            }
            List<Unit> unitList = info.loadUnit();
            for (int i = 0; i < unitList.Count; i++)
            {
                unit.Items.Add(unitList[i].getName());
            }
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            Commodity commodity = new Commodity();
            try
            {
                commodity.setName(name.Text);
                commodity.setBid(bid.Text);
                commodity.setPrice(price.Text);
                commodity.setPacking(packing.Text);
                commodity.setSpecification(specification.Text);
                commodity.setUnit(unit.Text);
                commodity.setApproval(approval.Text);
            }
            catch { }
            commDao info = new commDao();
            if (info.verification(commodity))
            {
                if (info.saveCommodity(commodity))
                {
                    MessageBox.Show("添加成功！");
                    name.Text = "";
                    bid.Text = "";
                    price.Text = "";
                    packing.Text = "";
                    specification.Text = "";
                    unit.Text = "";
                    approval.Text = "";
                }
                else
                    MessageBox.Show("添加失败!");
            }
        }

        private void bid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            if ((int)e.KeyChar == 46)//小数点
            {
                if (bid.Text.Length <= 0)

                    e.Handled = true; //小数点不能在第一位

                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(bid.Text, out oldf);
                    b2 = float.TryParse(bid.Text + e.KeyChar.ToString(), out f);
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

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            if ((int)e.KeyChar == 46)//小数点G:\vs2013\InventoryManagentSystem\InventoryManagentSystem\queryDrug.cs
            {
                if (price.Text.Length <= 0)

                    e.Handled = true; //小数点不能在第一位

                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(price.Text, out oldf);
                    b2 = float.TryParse(price.Text + e.KeyChar.ToString(), out f);
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

        private void addDrug_Load(object sender, EventArgs e)
        {

        }

        private void specification_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* specification.Items.Clear();
            commDao info = new commDao();
            List<Specification> specificationList = info.loadSpecification();
            for (int i = 0; i < specificationList.Count; i++)
            {
                specification.Items.Add(specificationList[i].getName());
            }*/
        }

        private void unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*unit.Items.Clear();
            commDao info = new commDao();
            List<Unit> unitList = info.loadUnit();
            for (int i = 0; i < unitList.Count; i++)
            {
                unit.Items.Add(unitList[i].getName());
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_UnitManage Form1 = new Form_UnitManage();
            Form1.Show();
            Form1.FormClosing += new FormClosingEventHandler(unit_re);
        }
        public void unit_re(Object o,FormClosingEventArgs e )
        {
            re();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_SpecificationManage Form1= new Form_SpecificationManage();
            Form1.Show();
            Form1.FormClosing += new FormClosingEventHandler(unit_re);
        }
    }
}

