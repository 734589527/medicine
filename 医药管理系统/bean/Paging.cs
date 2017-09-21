using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagentSystem.bean
{
    class Paging
    {
        private int pageNo;
        private int pageNum;
        private int pageCount;
        private int recordNum;
        private int recordStart;

        public Paging(int recordNum, int pageCount, int pageNo)
        {
            this.recordNum = recordNum;
            this.pageCount = pageCount;
            this.pageNo = pageNo;
            if (recordNum % pageCount == 0)
            {
                pageNum = recordNum / pageCount;
            }
            else
            {
                pageNum = recordNum / pageCount + 1;
            }
            recordStart = (pageNo - 1) * pageCount;
        }

        public int getRecordStart()
        {
            return recordStart;
        }

        public int getPageNum()
        {
            return pageNum;
        }
    }
}
