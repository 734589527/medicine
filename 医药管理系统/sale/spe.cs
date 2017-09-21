using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 医药管理系统
{
   
    class spe
    {
        int id;
        String spes;
        public void setId(int id)
        {
            this.id =id;
        }
        public void setSpe(String Spes)
        {
            this.spes = Spes;
        }
        public int getId()
        {
            return id;
        }
        public String getSpe()
        {
            return spes;
        }
    }
}
