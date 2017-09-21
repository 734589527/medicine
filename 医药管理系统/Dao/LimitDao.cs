using InventoryManagentSystem.bean;
using InventoryManagentSystem.Helper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagentSystem.Dao
{
    class LimitDao
    {
        private String sql;
        public Boolean add(Limit limit)
        {
            if (this.isExist(limit.getName()) == false)
            {
                MessageBox.Show("该角色名已存在!");
                return false;
            }
            Boolean flag = false;
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            try
            {
                DButil db = new DButil();
                conn = db.getConnection();
                conn.Open();
                String sql = "insert into part(name,addCus,deleteCus,updateCus,cusInfo,addComm,deleteComm,updateComm,commInfo,addStf,deleteStf,updateStf,stfInfo,addRol,deleteRol,updateRol,rolInfo,stoIn,stoOut,selectSto,adjustSto,stoWarn,readyStoOut,stoInGra,stoOutGra,saleGra,reOrderGra,reGoodsGra,addSale,selectSale,reGoods,reOrder,addVerify,verifyInfo,updateVerify,deleteVerify)"
                    + "values('" + limit.getName() + "','" + limit.getAddCus() + "','" + limit.getDeleteCus() + "','" + limit.getUpdateCus() + "','" + limit.getCusInfo() + "'"
                    + ",'" + limit.getAddComm() + "','" + limit.getDeleteComm() + "','" + limit.getUpdateComm() + "','" + limit.getCommInfo() + "'"
                    + ",'" + limit.getAddStf() + "','" + limit.getDeleteStf() + "','" + limit.getUpdateStf() + "','" + limit.getStfInfo() + "'"
                    + ",'" + limit.getAddRol() + "','" + limit.getDeleteRol() + "','" + limit.getUpdateRol() + "','" + limit.getRolInfo() + "'"
                    + ",'" + limit.getStoIn() + "','" + limit.getStoOut() + "','" + limit.getSelectSto() + "','" + limit.getAdjustSto() + "','" + limit.getStoWarn() + "','" + limit.getReadyStoOut() + "'"
                    + ",'" + limit.getStoInGra() + "','" + limit.getStoOutGra() + "','" + limit.getSaleGra() + "','" + limit.getReOrderGra() + "','" + limit.getReGoodsGra() + "'"
                    + ",'" + limit.getAddSale() + "','" + limit.getSelectSale() + "','" + limit.getReGoods() + "','" + limit.getReOrder() + "'"
                    + ",'" + limit.getAddVerify() + "','" + limit.getVerifyInfo() + "','" + limit.getUpdateVerify() + "','" + limit.getDeleteVerify() + "')";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteScalar();
                MessageBox.Show("添加成功!");
                flag = true;
            }
            catch
            {
                MessageBox.Show("添加失败!");
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public List<Limit> getLimitList()
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            DButil db = new DButil();
            conn = db.getConnection();
            List<Limit> list = new List<Limit>();
            try
            {
                conn.Open();
                String sql = "select * from part";
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Limit limit = new Limit();
                    limit.setId(reader.GetInt32(0));
                    limit.setName(reader.GetString(1));
                    limit.setAddCus(reader.GetInt32(2));
                    limit.setDeleteCus(reader.GetInt32(3));
                    limit.setUpdateCus(reader.GetInt32(4));
                    limit.setCusInfo(reader.GetInt32(5));
                    limit.setAddComm(reader.GetInt32(6));
                    limit.setDeleteComm(reader.GetInt32(7));
                    limit.setUpdateComm(reader.GetInt32(8));
                    limit.setCommInfo(reader.GetInt32(9));
                    limit.setAddStf(reader.GetInt32(10));
                    limit.setDeleteStf(reader.GetInt32(11));
                    limit.setUpdateStf(reader.GetInt32(12));
                    limit.setStfInfo(reader.GetInt32(13));
                    limit.setAddRol(reader.GetInt32(14));
                    limit.setDeleteRol(reader.GetInt32(15));
                    limit.setUpdateRol(reader.GetInt32(16));
                    limit.setRolInfo(reader.GetInt32(17));
                    limit.setStoIn(reader.GetInt32(18));
                    limit.setStoOut(reader.GetInt32(19));
                    limit.setSelectSto(reader.GetInt32(20));
                    limit.setAdjustSto(reader.GetInt32(21));
                    limit.setStoWarn(reader.GetInt32(22));
                    limit.setReadyStoOut(reader.GetInt32(23));
                    limit.setStoInGra(reader.GetInt32(24));
                    limit.setStoOutGra(reader.GetInt32(25));
                    limit.setSaleGra(reader.GetInt32(26));
                    limit.setReOrderGra(reader.GetInt32(27));
                    limit.setReGoodsGra(reader.GetInt32(28));
                    limit.setAddSale(reader.GetInt32(29));
                    limit.setSelectSale(reader.GetInt32(30));
                    limit.setReGoods(reader.GetInt32(31));
                    limit.setReOrder(reader.GetInt32(32));
                    limit.setAddVerify(reader.GetInt32(33));
                    limit.setVerifyInfo(reader.GetInt32(34));
                    limit.setUpdateVerify(reader.GetInt32(35));
                    limit.setDeleteVerify(reader.GetInt32(36));
                    list.Add(limit);
                }
            }
            catch
            {
                MessageBox.Show("加载角色信息失败!");
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        public List<String> getRoleList()
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            DButil db = new DButil();
            conn = db.getConnection();
            List<String> list = new List<String>();
            try
            {
                conn.Open();
                String sql = "select name from part";
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
            }
            catch
            {
                MessageBox.Show("加载角色信息失败!");
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public Boolean updateLimit(Limit limit)
        {
            Boolean flag = false;
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            DButil db = new DButil();
            conn = db.getConnection();
            try
            {
                conn.Open();
                String sql = "update part set name='" + limit.getName() + "',addCus='" + limit.getAddCus() + "',deleteCus='" + limit.getDeleteCus() + "',updateCus='" + limit.getUpdateCus() + "',cusInfo='" + limit.getCusInfo() + "',"
                + "addComm='" + limit.getAddComm() + "',deleteComm='" + limit.getDeleteComm() + "',updateComm='" + limit.getUpdateComm() + "',commInfo='" + limit.getCommInfo() + "',"
                + "addStf='" + limit.getAddStf() + "',deleteStf='" + limit.getDeleteStf() + "',updateStf='" + limit.getUpdateStf() + "',stfInfo='" + limit.getStfInfo() + "',"
                + "addRol='" + limit.getAddRol() + "',deleteRol='" + limit.getDeleteRol() + "',updateRol='" + limit.getUpdateRol() + "',rolInfo='" + limit.getRolInfo() + "',"
                + "stoIn='" + limit.getStoIn() + "',stoOut='" + limit.getStoOut() + "',selectSto='" + limit.getSelectSto() + "',adjustSto='" + limit.getAdjustSto() + "',stoWarn='" + limit.getStoWarn() + "',readyStoOut='" + limit.getReadyStoOut() + "',"
                + "stoInGra='" + limit.getStoInGra() + "',stoOutGra='" + limit.getStoOutGra() + "',saleGra='" + limit.getSaleGra() + "',reOrderGra='" + limit.getReOrderGra() + "',reGoodsGra='" + limit.getReGoodsGra() + "',"
                + "addSale='" + limit.getAddSale() + "',selectSale='" + limit.getSelectSale() + "',reGoods='" + limit.getReGoods() + "',reOrder='" + limit.getReOrder() + "',"
                + "addVerify='" + limit.getAddVerify() + "',verifyInfo='" + limit.getVerifyInfo() + "',deleteVerify='" + limit.getDeleteVerify() + "',updateVerify='" + limit.getUpdateVerify() + "'where id='" + limit.getId() + "'";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteScalar();
                MessageBox.Show("修改成功");
                flag = true;
            }
            catch
            {
                MessageBox.Show("修改失败");
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public Boolean deleteLimit(int id)
        {
            Boolean flag = false;
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            DButil db = new DButil();
            conn = db.getConnection();
            try
            {
                conn.Open();
                String sql = "delete from part where id='" + id + "'";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteScalar();
                MessageBox.Show("删除成功!");
                flag = true;
            }
            catch
            {
                MessageBox.Show("删除失败!");
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }

        private Boolean isExist(String name)
        {
            MessageBox.Show(name);
            int count = 0;
            Boolean flag = false;
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            DButil db = new DButil();
            conn = db.getConnection();
            try
            {
                conn.Open();
                String sql = "select Count(*) count from part where name='" + name + "'";
                this.sql = sql;
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
            }
            catch
            { }
            finally
            {
                conn.Close();
            }
            if (count == 0)
            {
                flag = true;
            }
            return flag;
        }

        public int isManage(String[] firstLevel, int partId)
        {
            Boolean flag = false;
            int count = 0;
            for (int i = 0; i < firstLevel.Length; i++)
            {
                if (this.IsLimit(firstLevel[i], partId) == 1)
                {
                    flag = flag || true;
                }
            }
            if (flag)
            {
                count = 1;
            }
            return count;
        }

        public int IsLimit(String type, int userPart)
        {
            int flag = 0;
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            DButil db = new DButil();
            conn = db.getConnection();
            try
            {
                conn.Open();
                String sql = "select " + type + " from part where id='" + userPart + "'";
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flag = reader.GetInt32(0);
                }
            }
            catch
            {
                MessageBox.Show("加载角色信息失败!");
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
    }
}
