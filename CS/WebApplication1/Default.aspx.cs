using System;
using System.IO;
using System.Web.UI;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;

namespace WebApplication1 {
    public partial class _Default : Page {
        static XtraReport CreateMergedReport() {
            var report = new XtraReport1();
            report.CreateDocument();
            var report2 = new XtraReport2();
            report2.CreateDocument();
            report.Pages.AddRange(report2.Pages);
            return report;
        }

        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                DocumentViewer1.Report = CreateMergedReport();
            }
        }

        protected void DocumentViewer1_CacheReportDocument(object sender, CacheReportDocumentEventArgs e) {
            var reportLayout = e.SaveDocumentToMemoryStream().ToArray();
            MergedReportLayout = reportLayout;

            var exportOptions = e.SaveExportOptionsToMemoryStream().ToArray();
            MergedDocumentExportOptions = exportOptions;
        }

        protected void DocumentViewer1_RestoreReportDocumentFromCache(object sender, RestoreReportDocumentFromCacheEventArgs e) {
            if(MergedReportLayout == null) {
                return;
            }
            var stream = new MemoryStream(MergedReportLayout);
            e.RestoreDocumentFromStream(stream);
        }

        byte[] MergedReportLayout {
            get { return Session["Report"] as byte[]; }
            set { Session["Report"] = value; }
        }

        byte[] MergedDocumentExportOptions {
            get { return Session["ExportOptions"] as byte[]; }
            set { Session["ExportOptions"] = value; }
        }
    }
}
