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
    public partial class limitList : XtraTabPage
    {
        public limitList()
        {
            InitializeComponent();
            this.loadForm();
            LimitDao limitDao = new LimitDao();
            List<String> list = limitDao.getRoleList();
            roleCob.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                roleCob.Items.Add(list[i]);
            }
        }
        public limitList(Limit limit)
        {
            InitializeComponent();
            this.loadForm();
            roleCob.Items.Clear();
            LimitDao limitDao = new LimitDao();
            List<Limit> list = limitDao.getLimitList();
            for (int i = 0; i < list.Count; i++)
            {
                roleCob.Items.Add(list[i].getName());
                if (limit.getId() == list[i].getId())
                {
                    roleCob.SelectedIndex = i;
                }
            }
            this.show(list);
        }
        private void loadForm()
        {
            tbx.Hide();
            submitUp.Hide();
            roleCob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            /*LimitDao limitDao = new LimitDao();
            int flag = limitDao.IsLimit("updateRol", 13);
            if (flag == 0)
            {
                edeit.Enabled = false;
            }
            else
            {
                edeit.Enabled = true;
            }*/
            foreach (Control c in groupBox1.Controls)
            {
                if (c is CheckBox)
                {
                    c.Enabled = false;
                }
            }
        }

        private void roleCob_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimitDao limitDao = new LimitDao();
            List<Limit> list = limitDao.getLimitList();
            this.show(list);
        }

        //初始化查询数据
        private void show(List<Limit> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].getName() == roleCob.Text)
                {
                    idLab.Text = list[i].getId().ToString();
                    idLab.Hide();
                    if (list[i].getAddCus() == 1)
                    {
                        addCus.Checked = true;
                    }
                    else
                    {
                        addCus.Checked = false;
                    }
                    if (list[i].getUpdateCus() == 1)
                    {
                        updateCus.Checked = true;
                    }
                    else
                    {
                        updateCus.Checked = false;
                    }
                    if (list[i].getDeleteCus() == 1)
                    {
                        deleteCus.Checked = true;
                    }
                    else
                    {
                        deleteCus.Checked = false;
                    }
                    if (list[i].getCusInfo() == 1)
                    {
                        cusInfo.Checked = true;
                    }
                    else
                    {
                        cusInfo.Checked = false;
                    }
                    if (list[i].getAddCus() == 0 && list[i].getCusInfo() == 0)
                    {
                        customerManage.Checked = false;
                    }
                    else
                    {
                        customerManage.Checked = true;
                    }
                    if (list[i].getAddComm() == 1)
                    {
                        addComm.Checked = true;
                    }
                    else
                    {
                        addComm.Checked = false;
                    }
                    if (list[i].getUpdateComm() == 1)
                    {
                        updateComm.Checked = true;
                    }
                    else
                    {
                        updateComm.Checked = false;
                    }
                    if (list[i].getDeleteComm() == 1)
                    {
                        deleteComm.Checked = true;
                    }
                    else
                    {
                        deleteComm.Checked = false;
                    }
                    if (list[i].getCommInfo() == 1)
                    {
                        commInfo.Checked = true;
                    }
                    else
                    {
                        commInfo.Checked = false;
                    }
                    if (list[i].getAddComm() == 0 && list[i].getCommInfo() == 0)
                    {
                        commodityManage.Checked = false;
                    }
                    else
                    {
                        commodityManage.Checked = true;
                    }
                    if (list[i].getAddStf() == 1)
                    {
                        addStf.Checked = true;
                    }
                    else
                    {
                        addStf.Checked = false;
                    }
                    if (list[i].getUpdateStf() == 1)
                    {
                        updateStf.Checked = true;
                    }
                    else
                    {
                        updateStf.Checked = false;
                    }
                    if (list[i].getDeleteStf() == 1)
                    {
                        deleteStf.Checked = true;
                    }
                    else
                    {
                        deleteStf.Checked = false;
                    }
                    if (list[i].getStfInfo() == 1)
                    {
                        stfInfo.Checked = true;
                    }
                    else
                    {
                        stfInfo.Checked = false;
                    }
                    if (list[i].getAddStf() == 0 && list[i].getStfInfo() == 0)
                    {
                        staffManage.Checked = false;
                    }
                    else
                    {
                        staffManage.Checked = true;
                    }
                    if (list[i].getAddRol() == 1)
                    {
                        addRol.Checked = true;
                    }
                    else
                    {
                        addRol.Checked = false;
                    }
                    if (list[i].getUpdateRol() == 1)
                    {
                        updateRol.Checked = true;
                    }
                    else
                    {
                        updateRol.Checked = false;
                    }
                    if (list[i].getDeleteRol() == 1)
                    {
                        deleteRol.Checked = true;
                    }
                    else
                    {
                        deleteRol.Checked = false;
                    }
                    if (list[i].getRolInfo() == 1)
                    {
                        rolInfo.Checked = true;
                    }
                    else
                    {
                        rolInfo.Checked = false;
                    }
                    if (list[i].getAddRol() == 0 && list[i].getRolInfo() == 0)
                    {
                        roleManage.Checked = false;
                    }
                    else
                    {
                        roleManage.Checked = true;
                    }
                    if (list[i].getStoIn() == 1)
                    {
                        stoIn.Checked = true;
                    }
                    else
                    {
                        stoIn.Checked = false;
                    }
                    if (list[i].getStoOut() == 1)
                    {
                        stoOut.Checked = true;
                    }
                    else
                    {
                        stoOut.Checked = false;
                    }
                    if (list[i].getSelectSto() == 1)
                    {
                        selectSto.Checked = true;
                    }
                    else
                    {
                        selectSto.Checked = false;
                    }
                    if (list[i].getAdjustSto() == 1)
                    {
                        adjustSto.Checked = true;
                    }
                    else
                    {
                        adjustSto.Checked = false;
                    }
                    if (list[i].getStoWarn() == 1)
                    {
                        stoWarn.Checked = true;
                    }
                    else
                    {
                        stoWarn.Checked = false;
                    }
                    if (list[i].getReadyStoOut() == 1)
                    {
                        readyStoOut.Checked = true;
                    }
                    else
                    {
                        readyStoOut.Checked = false;
                    }
                    if (list[i].getStoIn() == 0 && list[i].getStoOut() == 0 && list[i].getSelectSto() == 0 && list[i].getStoWarn() == 0 && list[i].getReadyStoOut() == 0 && list[i].getAdjustSto() == 0)
                    {
                        stockManage.Checked = false;
                    }
                    else
                    {
                        stockManage.Checked = true;
                    }
                    if (list[i].getStoInGra() == 1)
                    {
                        stoInGra.Checked = true;
                    }
                    else
                    {
                        stoInGra.Checked = false;
                    }
                    if (list[i].getStoOutGra() == 1)
                    {
                        stoOutGra.Checked = true;
                    }
                    else
                    {
                        stoOutGra.Checked = false;
                    }
                    if (list[i].getSaleGra() == 1)
                    {
                        saleGra.Checked = true;
                    }
                    else
                    {
                        saleGra.Checked = false;
                    }
                    if (list[i].getReOrderGra() == 1)
                    {
                        reOrderGra.Checked = true;
                    }
                    else
                    {
                        reOrderGra.Checked = false;
                    }
                    if (list[i].getReGoodsGra() == 1)
                    {
                        reGoodsGra.Checked = true;
                    }
                    else
                    {
                        reGoodsGra.Checked = false;
                    }
                    if (list[i].getStoInGra() == 0 && list[i].getStoOutGra() == 0 && list[i].getSaleGra() == 0 && list[i].getReGoodsGra() == 0 && list[i].getReOrderGra() == 0)
                    {
                        graphManage.Checked = false;
                    }
                    else
                    {
                        graphManage.Checked = true;
                    }
                    if (list[i].getAddSale() == 1)
                    {
                        addSale.Checked = true;
                    }
                    else
                    {
                        addSale.Checked = false;
                    }
                    if (list[i].getSelectSale() == 1)
                    {
                        selectSale.Checked = true;
                    }
                    else
                    {
                        selectSale.Checked = false;
                    }
                    if (list[i].getReGoods() == 1)
                    {
                        reGoods.Checked = true;
                    }
                    else
                    {
                        reGoods.Checked = false;
                    }
                    if (list[i].getReOrder() == 1)
                    {
                        reOrder.Checked = true;
                    }
                    else
                    {
                        reOrder.Checked = false;
                    }
                    if (list[i].getAddSale() == 0 && list[i].getSelectSale() == 0 && list[i].getReOrder() == 0 && list[i].getReGoods() == 0)
                    {
                        saleManage.Checked = false;
                    }
                    else
                    {
                        saleManage.Checked = true;
                    }
                    if (list[i].getAddVerify() == 1)
                    {
                        addVerify.Checked = true;
                    }
                    else
                    {
                        addVerify.Checked = false;
                    }
                    if (list[i].getVerifyInfo() == 1)
                    {
                        VerifyInfo.Checked = true;
                    }
                    else
                    {
                        VerifyInfo.Checked = false;
                    }
                    if (list[i].getUpdateVerify() == 1)
                    {
                        updateVerify.Checked = true;
                    }
                    else
                    {
                        updateVerify.Checked = false;
                    }
                    if (list[i].getDeleteVerify() == 1)
                    {
                        deleteVerify.Checked = true;
                    }
                    else
                    {
                        deleteVerify.Checked = false;
                    }
                    if (list[i].getAddVerify() == 0 && list[i].getDeleteVerify() == 0 && list[i].getUpdateVerify() == 0 && list[i].getVerifyInfo() == 0)
                    {
                        verifyCommManage.Checked = false;
                    }
                    else
                    {
                        verifyCommManage.Checked = true;
                    }
                }
            }
        }
        private void customerManage_Click(object sender, EventArgs e)
        {
            if (customerManage.Checked == true)
            {
                addCus.Checked = true;
                cusInfo.Checked = true;
                addCus.Enabled = true;
                cusInfo.Enabled = true;
                deleteCus.Checked = true;
                updateCus.Checked = true;
                deleteCus.Enabled = true;
                updateCus.Enabled = true;
            }
            else
            {
                addCus.Checked = false;
                cusInfo.Checked = false;
                addCus.Enabled = false;
                cusInfo.Enabled = false;
                deleteCus.Checked = false;
                updateCus.Checked = false;
                deleteCus.Enabled = false;
                updateCus.Enabled = false;
            }
        }

        private void cusInfo_Click(object sender, EventArgs e)
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

        private void commodityManage_Click(object sender, EventArgs e)
        {
            if (commodityManage.Checked == true)
            {
                commInfo.Checked = true;
                addComm.Checked = true;
                commInfo.Enabled = true;
                addComm.Enabled = true;
                updateComm.Checked = true;
                deleteComm.Checked = true;
                updateComm.Enabled = true;
                deleteComm.Enabled = true;
            }
            else
            {
                commInfo.Checked = false;
                addComm.Checked = false;
                commInfo.Enabled = false;
                addComm.Enabled = false;
                updateComm.Checked = false;
                deleteComm.Checked = false;
                updateComm.Enabled = false;
                deleteComm.Enabled = false;
            }
        }

        private void commInfo_Click(object sender, EventArgs e)
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

        private void staffManage_Click(object sender, EventArgs e)
        {
            if (staffManage.Checked == true)
            {
                addStf.Checked = true;
                stfInfo.Checked = true;
                addStf.Enabled = true;
                stfInfo.Enabled = true;
                updateStf.Checked = true;
                deleteStf.Checked = true;
                updateStf.Enabled = true;
                deleteStf.Enabled = true;
            }
            else
            {
                addStf.Checked = false;
                stfInfo.Checked = false;
                addStf.Enabled = false;
                stfInfo.Enabled = false;
                updateStf.Checked = false;
                deleteStf.Checked = false;
                updateStf.Enabled = false;
                deleteStf.Enabled = false;
            }
        }

        private void stfInfo_Click(object sender, EventArgs e)
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

        private void roleManage_Click(object sender, EventArgs e)
        {
            if (roleManage.Checked == true)
            {
                addRol.Checked = true;
                rolInfo.Checked = true;
                addRol.Enabled = true;
                rolInfo.Enabled = true;
                updateRol.Checked = true;
                deleteRol.Checked = true;
                updateRol.Enabled = true;
                deleteRol.Enabled = true;
            }
            else
            {
                addRol.Checked = false;
                rolInfo.Checked = false;
                addRol.Checked = false;
                rolInfo.Checked = false;
                updateRol.Checked = false;
                deleteRol.Checked = false;
                updateRol.Enabled = false;
                deleteRol.Enabled = false;
            }
        }

        private void rolInfo_Click(object sender, EventArgs e)
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

        private void stockManage_Click(object sender, EventArgs e)
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
                stoWarn.Checked = false;
                stoIn.Enabled = false;
                stoOut.Enabled = false;
                selectSto.Enabled = false;
                adjustSto.Enabled = false;
                readyStoOut.Enabled = false;
                stoWarn.Enabled = false;
            }
        }

        private void graphManage_Click(object sender, EventArgs e)
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

        private void saleManage_Click(object sender, EventArgs e)
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
        private void verifyCommManage_Click(object sender, EventArgs e)
        {
            if (verifyCommManage.Checked == true)
            {
                addVerify.Checked = true;
                VerifyInfo.Checked = true;
                addVerify.Enabled = true;
                VerifyInfo.Enabled = true;
                deleteVerify.Checked = true;
                updateVerify.Checked = true;
                deleteVerify.Enabled = true;
                updateVerify.Enabled = true;
            }
            else
            {
                addVerify.Checked = false;
                VerifyInfo.Checked = false;
                addVerify.Enabled = false;
                VerifyInfo.Enabled = false;
                deleteVerify.Checked = false;
                updateVerify.Checked = false;
                deleteVerify.Enabled = false;
                updateVerify.Enabled = false;
            }
        }

        private void VerifyInfo_Click(object sender, EventArgs e)
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

        //编辑初始化
        private void readyEdit()
        {
            if (customerManage.Checked == true)
            {
                addCus.Enabled = true;
                cusInfo.Enabled = true;
            }
            else
            {
                addCus.Enabled = false;
                cusInfo.Enabled = false;
            }
            if (cusInfo.Checked == true)
            {
                deleteCus.Enabled = true;
                updateCus.Enabled = true;
            }
            else
            {
                deleteCus.Enabled = false;
                updateCus.Enabled = false;
            }
            if (commodityManage.Checked == true)
            {
                commInfo.Enabled = true;
                addComm.Enabled = true;
            }
            else
            {
                commInfo.Enabled = false;
                addComm.Enabled = false;
            }
            if (commInfo.Checked == true)
            {
                updateComm.Enabled = true;
                deleteComm.Enabled = true;
            }
            else
            {
                updateComm.Enabled = false;
                deleteComm.Enabled = false;
            }
            if (staffManage.Checked == true)
            {
                addStf.Enabled = true;
                stfInfo.Enabled = true;
            }
            else
            {
                addStf.Enabled = false;
                stfInfo.Enabled = false;
            }
            if (stfInfo.Checked == true)
            {
                updateStf.Enabled = true;
                deleteStf.Enabled = true;
            }
            else
            {
                updateStf.Enabled = false;
                deleteStf.Enabled = false;
            }
            if (roleManage.Checked == true)
            {
                addRol.Enabled = true;
                rolInfo.Enabled = true;
            }
            else
            {
                addRol.Enabled = false;
                rolInfo.Enabled = false;
            }
            if (rolInfo.Checked == true)
            {
                updateRol.Enabled = true;
                deleteRol.Enabled = true;
            }
            else
            {
                updateRol.Enabled = false;
                deleteRol.Enabled = false;
            }
            if (stockManage.Checked == true)
            {
                stoIn.Enabled = true;
                stoOut.Enabled = true;
                selectSto.Enabled = true;
                adjustSto.Enabled = true;
                readyStoOut.Enabled = true;
                stoWarn.Enabled = true;
            }
            else
            {
                stoIn.Enabled = false;
                stoOut.Enabled = false;
                selectSto.Enabled = false;
                adjustSto.Enabled = false;
                readyStoOut.Enabled = false;
                stoWarn.Enabled = false;
            }
            if (graphManage.Checked == true)
            {
                stoOutGra.Enabled = true;
                stoInGra.Enabled = true;
                saleGra.Enabled = true;
                reOrderGra.Enabled = true;
                reGoodsGra.Enabled = true;
            }
            else
            {
                stoOutGra.Enabled = false;
                stoInGra.Enabled = false;
                saleGra.Enabled = false;
                reOrderGra.Enabled = false;
                reGoodsGra.Enabled = false;
            }
            if (saleManage.Checked == true)
            {
                addSale.Enabled = true;
                selectSale.Enabled = true;
                reOrder.Enabled = true;
                reGoods.Enabled = true;
            }
            else
            {
                addSale.Enabled = false;
                selectSale.Enabled = false;
                reOrder.Enabled = false;
                reGoods.Enabled = false;
            }
            if (verifyCommManage.Checked == true)
            {
                addVerify.Enabled = true;
                VerifyInfo.Enabled = true;
                updateVerify.Enabled = true;
                deleteVerify.Enabled = true;
            }
            else
            {
                addVerify.Enabled = false;
                VerifyInfo.Enabled = false;
                updateVerify.Enabled = false;
                deleteVerify.Enabled = false;
            }
        }

        //编辑
        private void edeit_Click(object sender, EventArgs e)
        {
            if (roleCob.Text != "")
            {
                staffManage.Enabled = true;
                commodityManage.Enabled = true;
                roleManage.Enabled = true;
                customerManage.Enabled = true;
                stockManage.Enabled = true;
                graphManage.Enabled = true;
                saleManage.Enabled = true;
                verifyCommManage.Enabled = true;
                foreach (CheckBox c in groupBox1.Controls)
                {
                    if (c.Checked == true)
                    {
                        c.Enabled = true;
                    }
                }
                this.readyEdit();
                tbx.Show();
                tbx.Text = roleCob.Text;
                roleCob.Hide();
                edeit.Hide();
                delete.Hide();
                submitUp.Show();
            }
        }

        //修改提交
        private void submitUp_Click(object sender, EventArgs e)
        {
            LimitDao limitDao = new LimitDao();
            if (limitDao.updateLimit(this.getLimits()))
            {
                roleCob.Items.Clear();
                List<Limit> list = limitDao.getLimitList();
                for (int i = 0; i < list.Count; i++)
                {
                    roleCob.Items.Add(list[i].getName());
                    if (list[i].getId() == Convert.ToInt32(idLab.Text))
                    {
                        roleCob.SelectedIndex = i;
                    }
                }
                this.loadForm();
                roleCob.Show();
                edeit.Show();
                delete.Show();
                this.show(list);
            }
        }

        //组装对象
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
            if (stoInGra.Checked == true)
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
            limit.setId(Convert.ToInt32(idLab.Text));
            limit.setName(tbx.Text);
            return limit;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (roleCob.Text != "")
            {
                if (MessageBox.Show("是否删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    LimitDao limitDao = new LimitDao();
                    if (limitDao.deleteLimit(Convert.ToInt32(idLab.Text)))
                    {
                        roleCob.Items.Clear();
                        List<String> list = limitDao.getRoleList();
                        for (int i = 0; i < list.Count; i++)
                        {
                            roleCob.Items.Add(list[i]);
                        }
                        foreach (CheckBox c in groupBox1.Controls)
                        {
                            c.Enabled = false;
                            c.Checked = false;
                        }
                    }
                }
            }
        }
    }
}
