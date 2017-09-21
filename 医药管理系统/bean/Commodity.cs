using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagentSystem.bean
{
    public class Commodity
    {
        private int id;
        private String name;
        private String specification;
        private String unit;
        private String bid;
        private String price;
        private String num;
        private String packing;
        private String approval;

        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return id;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public String getName()
        {
            return name;
        }
        public void setBid(String bid)
        {
            this.bid = bid;
        }
        public String getBid()
        {
            return bid;
        }

        public void setPrice(String price)
        {
            this.price = price;
        }
        public String getPrice()
        {
            return price;
        }
        public void setSpecification(String specification)
        {
            this.specification = specification;
        }
        public String getSpecification()
        {
            return specification;
        }
        public void setUnit(String unit)
        {
            this.unit = unit;
        }
        public String getUnit()
        {
            return unit;
        }
        public void setNum(String num)
        {
            this.num = num;
        }
        public String getNum()
        {
            return num;
        }
        public void setPacking(String packing)
        {
            this.packing = packing;
        }
        public String getPacking()
        {
            return packing;
        }
        public void setApproval(String approval)
        {
            this.approval = approval;
        }
        public String getApproval()
        {
            return approval;
         }
    }
}
