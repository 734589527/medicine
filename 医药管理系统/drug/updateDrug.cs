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
    public partial class updateDrug : Form
    {
          private int id;
        private int row;
        public updateDrug(Commodity commodity,int row)
        {
            InitializeComponent();
            this.row = row;
            id = commodity.getId();
            name.Text=commodity.getName();
            specification.Text = commodity.getSpecification();
            unit.Text = commodity.getUnit();
            price.Text = commodity.getPrice();
            bid.Text = commodity.getBid();
            packing.Text = commodity.getPacking();
            approval.Text = commodity.getApproval();
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

        private void updateDrug_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void bid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            if ((int)e.KeyChar == 46)//小数点
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

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            if ((int)e.KeyChar == 46)//小数点
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

        private void btn_Click(object sender, EventArgs e)
        {
            Commodity commodity = new Commodity();
            commodity.setId(id);
            commodity.setName(name.Text);
            commodity.setSpecification(specification.Text);
            commodity.setUnit(unit.Text);
            commodity.setApproval(approval.Text);
            commodity.setBid(bid.Text);
            commodity.setPacking(packing.Text);
            commodity.setPrice(price.Text);
            commDao info = new commDao();
            info.verification(commodity);
            if (info.updateCommodity(commodity))
            {
                MessageBox.Show("修改成功!");
            }
            else
            {
                MessageBox.Show("修改失败!");
            }
         //   this.Close();
        }
    }
}
