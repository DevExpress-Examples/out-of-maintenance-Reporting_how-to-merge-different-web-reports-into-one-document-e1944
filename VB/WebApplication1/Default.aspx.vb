Imports System
Imports System.IO
Imports System.Web.UI
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Web

Namespace WebApplication1
    Partial Public Class _Default
        Inherits Page

        Shared Function CreateMergedReport() As XtraReport
            Dim report As New XtraReport1()
            report.CreateDocument()
            Dim report2 As New XtraReport2()
            report2.CreateDocument()
            report.Pages.AddRange(report2.Pages)
            Return report
        End Function

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            If Not IsPostBack Then
                DocumentViewer1.Report = CreateMergedReport()
            End If
        End Sub

        Protected Sub DocumentViewer1_CacheReportDocument(sender As Object, e As CacheReportDocumentEventArgs) Handles DocumentViewer1.CacheReportDocument
            Dim reportLayout As Byte() = e.SaveDocumentToMemoryStream().ToArray()
            MergedReportLayout = reportLayout

            Dim exportOptions As Byte() = e.SaveExportOptionsToMemoryStream().ToArray()
            MergedDocumentExportOptions = exportOptions
        End Sub

        Protected Sub DocumentViewer1_RestoreReportDocumentFromCache(sender As Object, e As RestoreReportDocumentFromCacheEventArgs) Handles DocumentViewer1.RestoreReportDocumentFromCache
            If MergedReportLayout Is Nothing Then
                Return
            End If
            Dim stream As New MemoryStream(MergedReportLayout)
            e.RestoreDocumentFromStream(stream)
        End Sub

        Property MergedReportLayout() As Byte()
            Get
                Return TryCast(Session("Report"), Byte())
            End Get
            Set(value As Byte())
                Session("Report") = value
            End Set
        End Property

        Property MergedDocumentExportOptions() As Byte()
            Get
                Return TryCast(Session("ExportOptions"), Byte())
            End Get
            Set(value As Byte())
                Session("ExportOptions") = value
            End Set
        End Property
    End Class
End Namespace
