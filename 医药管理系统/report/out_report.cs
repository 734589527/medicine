using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using DevExpress.XtraPrinting.Localization;

namespace 医药管理系统.report
{
    public partial class out_report : DevExpress.XtraReports.UI.XtraReport
    {
        public out_report()
        {
            InitializeComponent();
            PreviewLocalizer.Active = new ChineaseReportLocalizer();
            rq();
        }
        public void addCommodity(List<sale_Commodity_class> s)
        {
            double sum = 0;
            double num = 0;
            for (int i = 0; i < s.Count; i++)
            {
                XRTableRow a = new XRTableRow();
                XRTableCell cell1 = new XRTableCell();
                cell1.Text = s[i].Name;
                XRTableCell cell2 = new XRTableCell();
                cell2.Text = s[i].Gg;
                XRTableCell cell3 = new XRTableCell();
                cell3.Text = s[i].Pack;
                XRTableCell cell4 = new XRTableCell();
                cell4.Text = s[i].Packnum.ToString();
                XRTableCell cell5 = new XRTableCell();
                cell5.Text = s[i].Unit;
                XRTableCell cell6 = new XRTableCell();
                cell6.Text = s[i].Num.ToString();
                XRTableCell cell7 = new XRTableCell();
                cell7.Text = s[i].Price.ToString();
                XRTableCell cell8 = new XRTableCell();
                cell8.Text = s[i].Sum.ToString();
                XRTableCell cell9 = new XRTableCell();
                cell9.Text = s[i].Ph;
                XRTableCell cell10 = new XRTableCell();
                cell10.Text = s[i].Data;
                XRTableCell cell11 = new XRTableCell();
                cell11.Text = s[i].Spe;
                a.Cells.Add(cell1);
                a.Cells.Add(cell2);
                a.Cells.Add(cell3);
                a.Cells.Add(cell4);
                a.Cells.Add(cell5);
                a.Cells.Add(cell6);
                a.Cells.Add(cell7);
                a.Cells.Add(cell8);
                a.Cells.Add(cell9);
                a.Cells.Add(cell10);
                a.Cells.Add(cell11);
                a.Size = new System.Drawing.Size(a.Size.Width, 58);
                cell1.Size = new System.Drawing.Size(xrTableCell1.Width, 58);
                cell2.Size = new System.Drawing.Size(xrTableCell2.Width, 58);
                cell3.Size = new System.Drawing.Size(xrTableCell3.Width, 58);
                cell4.Size = new System.Drawing.Size(xrTableCell4.Width, 58);
                cell5.Size = new System.Drawing.Size(xrTableCell5.Width, 58);
                cell6.Size = new System.Drawing.Size(xrTableCell6.Width, 58);
                cell7.Size = new System.Drawing.Size(xrTableCell7.Width, 58);
                cell8.Size = new System.Drawing.Size(xrTableCell8.Width, 58);
                cell9.Size = new System.Drawing.Size(xrTableCell9.Width, 58);
                cell10.Size = new System.Drawing.Size(xrTableCell10.Width, 58);
                cell11.Size = new System.Drawing.Size(xrTableCell11.Width, 58);
                xrTable1.Rows.Add(a);
                sum = sum + s[i].Sum;
                num = num + s[i].Num;
            }
            xrLabel9.Text = num.ToString();
            xrLabel12.Text = sum.ToString();
            xrLabel10.Text = new MoneyConvertChinese().MoneyToChinese(sum.ToString());

        }
        public void setKH(String s)
        {
            xrLabel5.Text = s;
        }
        public void setDJ(String s)
        {
            xrLabel6.Text = s;
        }
        public void rq()
        {
            xrLabel7.Text = DateTime.Now.ToLongDateString();
        }
        public void setfzr(String s)
        {
            xrLabel15.Text = s;
        }
        public void setjsr(String s)
        {
            xrLabel16.Text = s;
        }
        public void setdzdh(String s, string s2)
        {
            xrLabel19.Text = s;
            xrLabel21.Text = s2;
        }

    }
}
