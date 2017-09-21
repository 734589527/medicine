using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Localization;
using System.Collections.Generic;
using 医药管理系统.Dao;

namespace 医药管理系统.report
{
    public partial class jy_report : DevExpress.XtraReports.UI.XtraReport
    {
        public jy_report()
        {
            InitializeComponent();
            PreviewLocalizer.Active = new ChineaseReportLocalizer();
        }
        public void init(String a1, String a2, String a3, String a4, String a5, String a6, String a7, String a8, String a9, String a10, String a11, String a12, String a13, String a14)
        {
            this.jpmc.Text = a1;
            this.byrq.Text = a2;
            this.qybm.Text = a3;
            this.hyrq.Text = a4;
            this.gg.Text = a5;
            this.bgrq.Text = a6;
            this.sl.Text = a7;
            this.cpph.Text = a8;
            this.bzqk.Text = a9;
            this.jyyj.Text = a10;
            this.jl.Text = a11;
            this.sh.Text = a12;
            this.fx.Text = a13;
            this.hy.Text = a14;
        }
        public void init2(List<jy_dao> jy)
        {
            for (int i = 0; i < jy.Count; i++)
            {
                xrTable1.Rows[i+1].Cells[0].Text = jy[i].fxxm;
                xrTable1.Rows[i+1].Cells[1].Text = jy[i].jszb;
                xrTable1.Rows[i+1].Cells[2].Text = jy[i].fxxj;
            }
        }

    }
}
