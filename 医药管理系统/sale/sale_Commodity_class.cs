using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 医药管理系统
{
   public  class sale_Commodity_class
    {

        String ID, custom, address, ph, name, data, spe, gg, pack, unit, jsr,sbph;

        public String Pack
        {
            get { return pack; }
            set { pack = value; }
        }
        public String Sbph
        {
            get { return sbph; }
            set { sbph = value; }
        }

        public String Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public String Jsr
        {
            get { return jsr; }
            set { jsr = value; }
        }

        public String Gg
        {
            get { return gg; }
            set { gg = value; }
        }

        public String Spe
        {
            get { return spe; }
            set { spe = value; }
        }

        public String Data
        {
            get { return data; }
            set { data = value; }
        }

        public String Ph
        {
            get { return ph; }
            set { ph = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public String ID1
        {
            get { return ID; }
            set { ID = value; }
        }

        public String Custom
        {
            get { return custom; }
            set { custom = value; }
        }
        double num, packnum, price, sum;

        public double Sum
        {
            get { return sum; }
            set { sum = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public double Packnum
        {
            get { return packnum; }
            set { packnum = value; }
        }

        public double Num
        {
            get { return num; }
            set { num = value; }
        }
        public void setID(String ID,String custom,String address,String ph,String name,String data,String spe,String gg,String pack,String unit,String jsr,double num,double packnum,double sum,double price)
        {
            this.ID1 = ID;
            this.Custom = custom;
            this.Address=address;
            this.Ph = ph;
            this.Name = name;
            this.Data = data;
            this.Spe = spe;
            this.Gg = gg;
            this.Pack = pack;
            this.Unit = unit;
            this.Jsr = jsr;
            this.Num = num;
            this.Packnum = packnum;
            this.Sum = sum;
            this.Price = price;
        }
    }
}
