using DevExpress.XtraTab;
using InventoryManagentSystem.bean;
using InventoryManagentSystem.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 医药管理系统.Limits
{
    public partial class addLimits :XtraTabPage
    {
         public addLimits()
        {
            InitializeComponent();
            foreach (Control c in groupBox1.Controls)
            {
                if (c is CheckBox)
                {
                    c.Enabled = false;
                }
            }
            staffManage.Enabled = true;
            commodityManage.Enabled = true;
            roleManage.Enabled = true;
            customerManage.Enabled = true;
            stockManage.Enabled = true;
            graphManage.Enabled = true;
            saleManage.Enabled = true;
            verifyCommManage.Enabled = true;
        }
        private void verifyCommManage_CheckedChanged(object sender, EventArgs e)
        {
            if (verifyCommManage.Checked == true)
            {
                addVerify.Checked = true;
                VerifyInfo.Checked = true;
                addVerify.Enabled = true;
                VerifyInfo.Enabled = true;
            }
            else
            {
                addVerify.Checked = false;
                VerifyInfo.Checked = false;
                addVerify.Enabled = false;
                VerifyInfo.Enabled = false;
            }
        }

        private void VerifyInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (VerifyInfo.Checked == true)
            {
                deleteVerify.Checked = true;
                updateVerify.Checked = true;
                deleteVerify.Enabled = true;
                updateVerify.Enabled = true;
            }
            else
            {
                deleteVerify.Checked = false;
                updateVerify.Checked = false;
                deleteVerify.Enabled = false;
                updateVerify.Enabled = false;
            }
        }
        private void customerManage_CheckedChanged(object sender, EventArgs e)
        {
            if (customerManage.Checked == true)
            {
                addCus.Checked = true;
                cusInfo.Checked = true;
                addCus.Enabled = true;
                cusInfo.Enabled = true;
            }
            else
            {
                addCus.Checked = false;
                cusInfo.Checked = false;
                addCus.Enabled = false;
                cusInfo.Enabled = false;
            }
        }

        private void cusInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (cusInfo.Checked == true)
            {
                deleteCus.Checked = true;
                updateCus.Checked = true;
                deleteCus.Enabled = true;
                updateCus.Enabled = true;
            }
            else
            {
                deleteCus.Checked = false;
                updateCus.Checked = false;
                deleteCus.Enabled = false;
                updateCus.Enabled = false;
            }
        }

        private void commodityManage_CheckedChanged(object sender, EventArgs e)
        {
            if (commodityManage.Checked == true)
            {
                commInfo.Checked = true;
                addComm.Checked = true;
                commInfo.Enabled = true;
                addComm.Enabled = true;
            }
            else
            {
                commInfo.Checked = false;
                addComm.Checked = false;
                commInfo.Enabled = false;
                addComm.Enabled = false;
            }
        }

        private void commInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (commInfo.Checked == true)
            {
                updateComm.Checked = true;
                deleteComm.Checked = true;
                updateComm.Enabled = true;
                deleteComm.Enabled = true;
            }
            else
            {
                updateComm.Checked = false;
                deleteComm.Checked = false;
                updateComm.Enabled = false;
                deleteComm.Enabled = false;
            }
        }

        private void staffManage_CheckedChanged(object sender, EventArgs e)
        {
            if (staffManage.Checked == true)
            {
                addStf.Checked = true;
                stfInfo.Checked = true;
                addStf.Enabled = true;
                stfInfo.Enabled = true;
            }
            else
            {
                addStf.Checked = false;
                stfInfo.Checked = false;
                addStf.Enabled = false;
                stfInfo.Enabled = false;
            }
        }

        private void stfInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (stfInfo.Checked == true)
            {
                updateStf.Checked = true;
                deleteStf.Checked = true;
                updateStf.Enabled = true;
                deleteStf.Enabled = true;
            }
            else
            {
                updateStf.Checked = false;
                deleteStf.Checked = false;
                updateStf.Enabled = false;
                deleteStf.Enabled = false;
            }
        }

        private void roleManage_CheckedChanged(object sender, EventArgs e)
        {
            if (roleManage.Checked == true)
            {
                addRol.Checked = true;
                rolInfo.Checked = true;
                addRol.Enabled = true;
                rolInfo.Enabled = true;
            }
            else
            {
                addRol.Checked = false;
                rolInfo.Checked = false;
                addRol.Checked = false;
                rolInfo.Checked = false;
            }
        }

        private void rolInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (rolInfo.Checked == true)
            {
                updateRol.Checked = true;
                deleteRol.Checked = true;
                updateRol.Enabled = true;
                deleteRol.Enabled = true;
            }
            else
            {
                updateRol.Checked = false;
                deleteRol.Checked = false;
                updateRol.Enabled = false;
                deleteRol.Enabled = false;
            }
        }

        private void stockManage_CheckedChanged(object sender, EventArgs e)
        {
            if (stockManage.Checked == true)
            {
                stoIn.Checked = true;
                stoOut.Checked = true;
                selectSto.Checked = true;
                adjustSto.Checked = true;
                readyStoOut.Checked = true;
                stoWarn.Checked = true;
                stoIn.Enabled = true;
                stoOut.Enabled = true;
                selectSto.Enabled = true;
                adjustSto.Enabled = true;
                readyStoOut.Enabled = true;
                stoWarn.Enabled = true;
            }
            else
            {
                stoIn.Checked = false;
                stoOut.Checked = false;
                selectSto.Checked = false;
                adjustSto.Checked = false;
                readyStoOut.Checked = false;
                stoWarn.Checked = false;
                stoWarn.Checked= false;
                stoIn.Enabled = false;
                stoOut.Enabled = false;
                selectSto.Enabled = false;
                adjustSto.Enabled = false;
                readyStoOut.Enabled = false;
                stoWarn.Enabled = false;
            }
        }

        private void Graph_CheckedChanged(object sender, EventArgs e)
        {
            if (graphManage.Checked == true)
            {
                stoOutGra.Checked = true;
                stoInGra.Checked = true;
                saleGra.Checked = true;
                reOrderGra.Checked = true;
                reGoodsGra.Checked = true;
                stoOutGra.Enabled = true;
                stoInGra.Enabled = true;
                saleGra.Enabled = true;
                reOrderGra.Enabled = true;
                reGoodsGra.Enabled = true;
            }
            else 
            {
                stoOutGra.Checked = false;
                stoInGra.Checked = false;
                saleGra.Checked = false;
                reOrderGra.Checked = false;
                reGoodsGra.Checked = false;
                stoOutGra.Enabled = false;
                stoInGra.Enabled = false;
                saleGra.Enabled = false;
                reOrderGra.Enabled = false;
                reGoodsGra.Enabled = false;
            }
        }

        private void saleManage_CheckedChanged(object sender, EventArgs e)
        {
            if (saleManage.Checked == true)
            {
                addSale.Checked = true;
                selectSale.Checked = true;
                reOrder.Checked = true;
                reGoods.Checked = true;
                addSale.Enabled = true;
                selectSale.Enabled = true;
                reOrder.Enabled = true;
                reGoods.Enabled = true;
            }
            else
            {
                addSale.Checked = false;
                selectSale.Checked = false;
                reOrder.Checked = false;
                reGoods.Checked = false;
                addSale.Enabled = false;
                selectSale.Enabled = false;
                reOrder.Enabled = false;
                reGoods.Enabled = false;
            }
        }

        private Limit getLimits()
        {
            Limit limit = new Limit();
            //客户管理
            if (addCus.Checked == true)
            {
                limit.setAddCus(1);
            }
            else
            {
                limit.setAddCus(0);
            }
            if (updateCus.Checked == true)
            {
                limit.setUpdateCus(1);
            }
            else
            {
                limit.setUpdateCus(0);
            }
            if (deleteCus.Checked == true)
            {
                limit.setDeleteCus(1);
            }
            else
            {
                limit.setDeleteCus(0);
            }
            if (cusInfo.Checked == true)
            {
                limit.setCusInfo(1);
            }
            else
            {
                limit.setCusInfo(0);
            }
            //角色管理
            if (addRol.Checked == true)
            {
                limit.setAddRol(1);
            }
            else 
            {
                limit.setAddRol(0);
            }
            if (updateRol.Checked == true)
            {
                limit.setUpdateRol(1);
            }
            else
            {
                limit.setUpdateRol(0);
            }
            if (deleteRol.Checked == true)
            {
                limit.setDeleteRol(1);
            }
            else
            {
                limit.setDeleteRol(0);
            }
            if (rolInfo.Checked == true)
            {
                limit.setRolInfo(1);
            }
            else
            {
                limit.setRolInfo(0);
            }
            //员工管理
            if (addStf.Checked == true)
            {
                limit.setAddStf(1);
            }
            else 
            {
                limit.setAddStf(0);
            }
            if (updateStf.Checked == true)
            {
                limit.setUpdateStf(1);
            }
            else
            {
                limit.setUpdateStf(0);
            }
            if (deleteStf.Checked == true)
            {
                limit.setDeleteStf(1);
            }
            else
            {
                limit.setDeleteStf(0);
            }
            if (stfInfo.Checked == true)
            {
                limit.setStfInfo(1);
            }
            else
            {
                limit.setStfInfo(0);
            }
            //商品管理
            if (addComm.Checked == true)
            {
                limit.setAddComm(1);
            }
            else
            {
                limit.setAddComm(0);
            }
            if (updateComm.Checked == true)
            {
                limit.setUpdateComm(1);
            }
            else
            {
                limit.setUpdateComm(0);
            }
            if (deleteComm.Checked == true)
            {
                limit.setDeleteComm(1);
            }
            else
            {
                limit.setDeleteComm(0);
            }
            if (commInfo.Checked == true)
            {
                limit.setCommInfo(1);
            }
            else
            {
                limit.setCommInfo(0);
            }
            //库存管理
            if (stoIn.Checked == true)
            {
                limit.setStoIn(1);
            }
            else
            {
                limit.setStoIn(0);
            }
            if (stoOut.Checked == true)
            {
                limit.setStoOut(1);
            }
            else 
            {
                limit.setStoOut(0);
            }
            if (selectSto.Checked == true)
            {
                limit.setSelectSto(1);
            }
            else
            {
                limit.setSelectSto(0);
            }
            if (adjustSto.Checked == true)
            {
                limit.setAdjustSto(1);
            }
            else 
            {
                limit.setAdjustSto(0);
            }
            if (readyStoOut.Checked == true)
            {
                limit.setReadyStoOut(1);
            }
            else
            {
                limit.setReadyStoOut(0);
            }
            if (stoWarn.Checked == true)
            {
                limit.setStoWarn(1);
            }
            else
            {
                limit.setStoWarn(0);
            }
            //统计报表
            if (stoInGra.Checked==true)
            {
                limit.setStoInGra(1);
            }
            else
            {
                limit.setStoInGra(0);
            }
            if (stoOutGra.Checked == true)
            {
                limit.setStoOutGra(1);
            }
            else
            {
                limit.setStoOutGra(0);
            }
            if (saleGra.Checked == true)
            {
                limit.setSaleGra(1);
            }
            else
            {
                limit.setSaleGra(0);
            }
            if (reOrderGra.Checked == true)
            {
                limit.setReOrderGra(1);
            }
            else
            {
                limit.setReOrderGra(0);
            }
            if (reGoodsGra.Checked == true)
            {
                limit.setReGoodsGra(1);
            }
            else
            {
                limit.setReGoodsGra(0);
            }
            //销售管理
            if (addSale.Checked == true)
            {
                limit.setAddSale(1);
            }
            else
            {
                limit.setAddSale(0);
            }
            if (selectSale.Checked == true)
            {
                limit.setSelectSale(1);
            }
            else
            {
                limit.setSelectSale(0);
            }
            if (reOrder.Checked == true)
            {
                limit.setReOrder(1);
            }
            else
            {
                limit.setReOrder(0);
            }
            if (reGoods.Checked == true)
            {
                limit.setReGoods(1);
            }
            else
            {
                limit.setReGoods(0);
            }
            //药品检验
            if (addVerify.Checked == true)
            {
                limit.setAddVerify(1);
            }
            else
            {
                limit.setAddVerify(0);
            }
            if (VerifyInfo.Checked == true)
            {
                limit.setVerifyInfo(1);
            }
            else
            {
                limit.setVerifyInfo(0);
            }
            if (updateVerify.Checked == true)
            {
                limit.setUpdateVerify(1);
            }
            else
            {
                limit.setUpdateVerify(0);
            }
            if (deleteVerify.Checked == true)
            {
                limit.setDeleteVerify(1);
            }
            else
            {
                limit.setDeleteVerify(0);
            }
            limit.setName(tbx.Text);
            return limit;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (tbx.Text == "")
            {
                MessageBox.Show("请输入角色名!");
            }
            else
            {
                LimitDao limitDao = new LimitDao();
                limitDao.add(this.getLimits());
                commodityManage.Checked = false;
                staffManage.Checked = false;
                roleManage.Checked = false;
                customerManage.Checked = false;
                stockManage.Checked = false;
                saleManage.Checked = false;
                verifyCommManage.Checked = false;
                graphManage.Checked = false;
                tbx.Text = "";
            }
        }
    }
}