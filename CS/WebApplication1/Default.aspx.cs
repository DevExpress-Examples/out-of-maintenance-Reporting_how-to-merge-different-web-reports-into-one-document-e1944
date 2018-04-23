using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using DevExpress.XtraReports.UI;

namespace WebApplication1 {
    public partial class _Default: System.Web.UI.Page {
        protected void Page_Load(object sender,EventArgs e) {
            if(Session["Report"] == null) {
                XtraReport1 rpt = new XtraReport1();
                XtraReport2 rpt2 = new XtraReport2();
                rpt.CreateDocument();
                rpt2.CreateDocument();
                rpt.Pages.AddRange(rpt2.Pages);
                MemoryStream ms = new MemoryStream();
                try {
                    rpt.PrintingSystem.SaveDocument(ms);
                    ms.Seek(0,SeekOrigin.Begin);
                    byte[] array = ms.ToArray();
                    Session["Report"] = array;
                    ReportViewer1.Report = rpt ;
                } finally {
                    ms.Close();
                }
            } else {
                MemoryStream ms = new MemoryStream((byte[])(Session["Report"]));
                try {
                    ms.Seek(0,SeekOrigin.Begin);
                    XtraReport rep = new XtraReport();
                    rep.PrintingSystem.LoadDocument(ms);
                    ReportViewer1.Report = rep;
                } finally {
                    ms.Close();
                }

            }

        }
    }
}
