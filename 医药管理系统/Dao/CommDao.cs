using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagentSystem.Helper;
using System.Windows.Forms;
using InventoryManagentSystem.bean;

namespace InventoryManagentSystem.load
{
    class commDao
    {
        private static String sql = "SELECT * FROM commodity c,Specification s ,unit u where c.specification=s.id and c.unit=u.id order by c.id asc";
        public String getSql()
        {
            return sql;
        }
        //加载规格信息
        public List<Specification> loadSpecification()
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<Specification> specification = new List<Specification>();
            try
            {
                DButil db = new DButil();
                conn = db.getConnection();
                conn.Open();
                cmd = new MySqlCommand("select * from specification", conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Specification sp = new Specification();
                    sp.setId(Convert.ToInt32(reader.GetString(0)));
                    sp.setName(reader.GetString(1));
                    specification.Add(sp);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("加载规格失败!" + e);
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return specification;
        }

        //添加药品
        public Boolean saveCommodity(Commodity commodity)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            try
            {
                DButil db = new DButil();
                conn = db.getConnection();
                conn.Open();
                String sql = "insert into commodity (name,specification,unit,bid,price,num,packing,approval)"
                + " values ('" + commodity.getName() + "','" + this.getSnameById(commodity.getSpecification()) + "','" + this.getUnameById(commodity.getUnit()) + "','" + Convert.ToSingle(commodity.getBid()) + "','" + Convert.ToSingle(commodity.getPrice()) + "','0'"
                + ",'" + Convert.ToSingle(commodity.getPacking()) + "','" + commodity.getApproval() + "')";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteScalar();
            }
            catch
            {
                MessageBox.Show("添加失败!");
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        //加载记录单位
        public List<Unit> loadUnit()
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<Unit> unit = new List<Unit>();
            try
            {
                DButil db = new DButil();
                conn = db.getConnection();
                conn.Open();
                cmd = new MySqlCommand("select * from unit", conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Unit ut = new Unit();
                    ut.setId(Convert.ToInt32(reader.GetString(0)));
                    ut.setName(reader.GetString(1));
                    unit.Add(ut);
                }
            }
            catch
            {
                MessageBox.Show("加载记录单位失败!");
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return unit;
        }

        //加载包装数量
        public List<String> loadPacking()
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<String> packing = new List<string>();
            try
            {
                DButil db = new DButil();
                conn = db.getConnection();
                conn.Open();
                cmd = new MySqlCommand("select * from packing", conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    packing.Add(reader[0].ToString());
                }
            }
            catch
            {
                MessageBox.Show("加载包装数量失败!");
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return packing;
        }

        //初始化datagridview,显示药品信息
        public List<Commodity> loadCommodity(int start, int count)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<Commodity> list = new List<Commodity>();
            try
            {
                String sql = "SELECT * FROM commodity  ORDER BY C.ID ASC limit " + start + "," + count + "";
                DButil db = new DButil();
                conn = db.getConnection();
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Commodity com = new Commodity();
                    com.setId(reader.GetInt32(0));
                    com.setName(reader.GetString(1));
                    com.setSpecification(this.getSpecificationName(reader.GetInt32(2)));
                    com.setUnit(this.getUnitName(reader.GetInt32(3)));
                    com.setBid(reader.GetString(4));
                    com.setPrice(reader.GetString(5));
                    com.setNum(reader.GetString(6));
                    com.setPacking(reader.GetString(7));
                    com.setApproval(reader.GetString(8));
                    list.Add(com);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("加载出错!" + exception);
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return list;
        }

        public String getSql(Commodity commodity, int start, int count)
        {
            String sql = "SELECT * FROM commodity where id!= 0 ";
            if (commodity != null)
            {
                if (commodity.getName().Trim() != "")
                {
                    sql = sql + " and name like '%" + commodity.getName().Trim() + "%'";
                }
                if (commodity.getSpecification().Trim() != "")
                {
                    List<int> id = this.getSpecificationId(commodity.getSpecification().Trim());
                    if (id.Count == 1)
                    {
                        sql = sql + " and specification = " + id[0] + "";
                    }
                    else if (id.Count > 1)
                    {
                        sql = sql + " and (";
                        for (int i = 0; i < id.Count; i++)
                        {
                            if (i == 0)
                            {
                                sql = sql + "specification = " + id[i] + "";
                            }
                            else
                            {
                                sql = sql + " or specification = " + id[i] + " ";
                            }
                        }
                        sql = sql + ")";
                    }
                    else
                    {
                        sql = sql + " and specification= 0";
                    }

                }
                if (commodity.getUnit() != "")
                {
                    List<int> id = this.getUnitId(commodity.getUnit().Trim());

                    if (id.Count == 1)
                    {
                        sql = sql + " and unit = " + id[0] + "";
                    }
                    else if (id.Count > 1)
                    {
                        sql = sql + " and (";
                        for (int i = 0; i < id.Count; i++)
                        {
                            if (i == 0)
                            {
                                sql = sql + "unit = " + id[i] + "";
                            }
                            else
                            {
                                sql = sql + " or unit = " + id[i] + "";
                            }
                        }
                        sql = sql + ")";
                    }
                    else
                    {
                        sql = sql + " and unit='0'";
                    }
                }
                if (commodity.getNum().Trim() != "")
                {
                    sql = sql + " and num like '%" + Convert.ToSingle(commodity.getNum().Trim()) + "%'";
                }
                if (commodity.getBid().Trim() != "")
                {
                    sql = sql + " and bid = " + Convert.ToSingle(commodity.getBid().Trim()) + "";
                }
                if (commodity.getPrice().Trim() != "")
                {
                    sql = sql + " and price =" + Convert.ToSingle(commodity.getPrice().Trim()) + "";
                }
                if (commodity.getPacking().Trim() != "")
                {
                    sql = sql + " and packing = " + Convert.ToSingle(commodity.getPacking().Trim()) + "";
                }
                if (commodity.getApproval().Trim() != "")
                {
                    sql = sql + " and approval like '%" + commodity.getApproval().Trim() + "%'";
                }
            }
            sql = sql + " order by id asc limit " + start + "," + count + "";
            
            return sql;
        }

        public String getSql(Commodity commodity)
        {
            String sql = "SELECT count(*) count  FROM commodity where id!= 0 ";
            if (commodity != null)
            {
                if (commodity.getName().Trim() != "")
                {
                    sql = sql + " and name like '%" + commodity.getName().Trim() + "%'";
                }
                if (commodity.getSpecification().Trim() != "")
                {
                    List<int> id = this.getSpecificationId(commodity.getSpecification().Trim());
                    if (id.Count == 1)
                    {
                        sql = sql + " and specification = " + id[0] + "";
                    }
                    else if (id.Count > 1)
                    {
                        sql = sql + " and (";
                        for (int i = 0; i < id.Count; i++)
                        {
                            if (i == 0)
                            {
                                sql = sql + "specification = " + id[i] + "";
                            }
                            else
                            {
                                sql = sql + " or specification = '" + id[i] + "' ";
                            }
                        }
                        sql = sql + ")";
                    }
                    else
                    {
                        sql = sql + " and specification=0";
                    }

                }
                if (commodity.getUnit() != "")
                {
                    List<int> id = this.getUnitId(commodity.getUnit().Trim());

                    if (id.Count == 1)
                    {
                        sql = sql + " and unit = " + id[0] + "";
                    }
                    else if (id.Count > 1)
                    {
                        sql = sql + " and (";
                        for (int i = 0; i < id.Count; i++)
                        {
                            if (i == 0)
                            {
                                sql = sql + " unit = " + id[i] + "";
                            }
                            else
                            {
                                sql = sql + " or unit = " + id[i] + " ";
                            }
                        }
                        sql = sql + ")";
                    }
                    else
                    {
                        sql = sql + " and unit='0'";
                    }
                }
                if (commodity.getNum().Trim() != "")
                {
                    sql = sql + " and num like '%" + Convert.ToSingle(commodity.getNum().Trim()) + "%'";
                }
                if (commodity.getBid().Trim() != "")
                {
                    sql = sql + " and bid =" + Convert.ToSingle(commodity.getBid().Trim()) + "";
                }
                if (commodity.getPrice().Trim() != "")
                {
                    sql = sql + " and price =" + Convert.ToSingle(commodity.getPrice().Trim()) + "";
                }
                if (commodity.getPacking().Trim() != "")
                {
                    sql = sql + " and packing =" + Convert.ToSingle(commodity.getPacking().Trim()) + "";
                }
                if (commodity.getApproval().Trim() != "")
                {
                    sql = sql + " and approval like '%" + commodity.getApproval().Trim() + "%'";
                }
            }
            return sql;
        }
        //查询
        public List<Commodity> getCommBySelect(String sql)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<Commodity> list = new List<Commodity>();
            try
            {
                DButil db = new DButil();
                conn = db.getConnection();
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Commodity com = new Commodity();
                    com.setId(reader.GetInt32(0));
                    com.setName(reader.GetString(1));
                    com.setSpecification(this.getSpecificationName(reader.GetInt32(2)));
                    com.setUnit(this.getUnitName(reader.GetInt32(3)));
                    com.setBid(reader.GetString(4));
                    com.setPrice(reader.GetString(5));
                    com.setNum(reader.GetString(6));
                    com.setPacking(reader.GetString(7));
                    com.setApproval(reader.GetString(8));
                    list.Add(com);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("查询出错!" + e);
            }
            finally
            {
               
            }
            return list;
        }

        //填充datagridview
        public void showDgv(DataGridView dgv, List<Commodity> list)
        {
            dgv.Rows.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                i = dgv.Rows.Add();
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
                dgv.Rows[i].Cells[0].Value = list[i].getId().ToString();
                dgv.Rows[i].Cells[1].Value = list[i].getName();
                dgv.Rows[i].Cells[2].Value = list[i].getSpecification();
                dgv.Rows[i].Cells[3].Value = list[i].getBid();
                dgv.Rows[i].Cells[4].Value = list[i].getPrice();
                dgv.Rows[i].Cells[5].Value = list[i].getUnit();
                dgv.Rows[i].Cells[6].Value = list[i].getPacking();
                dgv.Rows[i].Cells[7].Value = list[i].getNum();
                dgv.Rows[i].Cells[8].Value = list[i].getApproval();
                dgv.Rows[i].Cells[9].Value = "修改";
                dgv.Rows[i].Cells[10].Value = "删除";
            }
        }

        //验证输入
        public Boolean verification(Commodity commdity)
        {
            if (commdity.getName().Trim() == "")
            {
                MessageBox.Show("请输入药品名!");
            }
            else if (commdity.getSpecification().Trim() == "")
            {
                MessageBox.Show("请输入药品规格!");
            }
            else if (commdity.getUnit().Trim() == "")
            {
                MessageBox.Show("请输入记录单位!");
            }
            else if (commdity.getBid().Trim() == "")
            {
                MessageBox.Show("请输入药品进价!");
            }
            else if (commdity.getPrice().Trim() == "")
            {
                MessageBox.Show("请输入药品售价!");
            }
            else if (commdity.getPacking().Trim() == "")
            {
                MessageBox.Show("请输入包装数量!");
            }
            else if (commdity.getApproval().Trim() == "")
            {
                MessageBox.Show("请输入批准文号!");
            }
            else
            {
                return true;
            }
            return false;
        }

        public String getSpecificationName(int id)
        {
            String name = "";
            Specification specification = new Specification();
            List<Specification> list = this.loadSpecification();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].getId() == id)
                {
                    name = list[i].getName();
                }
            }
            return name;
        }

        public String getUnitName(int id)
        {
            String name = "";
            Unit unit = new Unit();
            List<Unit> list = this.loadUnit();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].getId() == id)
                {
                    name = list[i].getName();
                }
            }
            return name;
        }
        public int getSnameById(String flag)
        {
            int id = 0;
            Specification specification = new Specification();
            List<Specification> list = this.loadSpecification();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].getName() == flag)
                {
                    id = list[i].getId();
                }
            }
            return id;
        }
        public int getUnameById(String flag)
        {
            int id = 0;
            Unit unit = new Unit();
            List<Unit> list = this.loadUnit();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].getName() == flag)
                {
                    id = list[i].getId();
                }
            }
            return id;
        }

        //通过规格名获取ID
        public List<int> getSpecificationId(String flag)
        {
            List<int> id = new List<int>();
            List<Specification> list = this.loadSpecification();
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < list[i].getName().Length; j++)
                    {
                        for (int n = 1; n < list[i].getName().Length - j + 1; n++)
                        {
                            if (list[i].getName().Substring(j, n) == flag)
                            {
                                id.Add(list[i].getId());
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return id;
        }

        //通过记录单位名获取ID
        public List<int> getUnitId(String flag)
        {
            List<int> id = new List<int>();
            List<Unit> list = this.loadUnit();
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].getName().Length; j++)
                {
                    for (int n = 1; n < list[i].getName().Length - j + 1; n++)
                    {
                        if (list[i].getName().Substring(j, n) == flag)
                        {
                            id.Add(list[i].getId());
                        }
                    }
                }
            }
            return id;
        }
        public Boolean updateCommodity(Commodity commodity)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            String sql = "update commodity set name='" + commodity.getName() + "',approval='" + commodity.getApproval() + "',bid=" + Convert.ToSingle(commodity.getBid()) + ",price=" + Convert.ToSingle(commodity.getPrice()) + ",packing=" + Convert.ToSingle(commodity.getPacking()) + ",unit='" + this.getUnameById(commodity.getUnit()) + "',specification='" + this.getSnameById(commodity.getSpecification()) + "' WHERE ID='" + commodity.getId() + "'";
            DButil db = new DButil();
            try
            {
                conn = db.getConnection();
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                conn.Close();
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public Boolean DeleteCommodity(int id)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            String sql = "delete from commodity where id='" + id + "' ";
            DButil db = new DButil();
            try
            {
                conn = db.getConnection();
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                conn.Close();
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public String getSql(int id)
        {
            String sql = "SELECT * FROM commodity where id=" + id + "";
            return sql;
        }

        public int getCount(String sql)
        {
            int count = 0;
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                DButil db = new DButil();
                conn = db.getConnection();
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    count = reader.GetInt32("count");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("查询出错!" + e);
            }
            finally
            {
                conn.Close();
            }
            return count;
        }
    }
}



