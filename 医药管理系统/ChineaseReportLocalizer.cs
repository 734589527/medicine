using DevExpress.XtraPrinting.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 医药管理系统
{
    class ChineaseReportLocalizer : DevExpress.XtraPrinting.Localization.PreviewLocalizer
    {
        public override string Language { get { return "简体中文"; } }
        public override string GetLocalizedString(PreviewStringId id)
        {
            string ret = "";
            switch (id)
            {
                case PreviewStringId.PreviewForm_Caption: return "统计报表预览";
                case PreviewStringId.MenuItem_File: return "文件";
                case PreviewStringId.MenuItem_PageSetup: return "页面设置";
                case PreviewStringId.MenuItem_PrintDirect: return "打印设置";
                case PreviewStringId.MenuItem_Print: return "打印";
                case PreviewStringId.MenuItem_Export: return "导出";
                case PreviewStringId.MenuItem_PdfDocument: return "Pdf文档";
                case PreviewStringId.MenuItem_RtfDocument: return "Rtf文档";
                case PreviewStringId.MenuItem_TxtDocument: return "Txt文档";
                case PreviewStringId.MenuItem_XlsDocument: return "Xls文档";
                case PreviewStringId.MenuItem_HtmDocument: return "Htm文档";
                case PreviewStringId.MenuItem_GraphicDocument: return "Graphic文档";
                case PreviewStringId.MenuItem_CsvDocument: return "Csv文档";
                case PreviewStringId.MenuItem_MhtDocument: return "Mht文档";
                case PreviewStringId.MenuItem_Send: return "发送";
                case PreviewStringId.MenuItem_Exit: return "退出";

                case PreviewStringId.MenuItem_View: return "查看";
                case PreviewStringId.MenuItem_ViewToolbar: return "工具栏";
                case PreviewStringId.MenuItem_ViewStatusbar: return "状态条";

                case PreviewStringId.MenuItem_Background: return "背景";
                case PreviewStringId.MenuItem_BackgrColor: return "颜色";
                case PreviewStringId.MenuItem_Watermark: return "水印";

                case PreviewStringId.Msg_IncorrectPageRange: return "设置的页边距不正确";

                case PreviewStringId.TB_TTip_PageSetup: return "页面设置";
                case PreviewStringId.TB_TTip_Print: return "打印";
                case PreviewStringId.TB_TTip_Export: return "导出";
                case PreviewStringId.TB_TTip_Close: return "退出";
                case PreviewStringId.TB_TTip_Send: return "发送";
                default:
                    ret = "";
                    break;
            }

            return ret;
        }
    }
}
