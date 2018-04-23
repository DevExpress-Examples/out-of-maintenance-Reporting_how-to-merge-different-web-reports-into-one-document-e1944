Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports DevExpress.XtraReports.UI

Namespace WebApplication1
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If Session("Report") Is Nothing Then
				Dim rpt As New XtraReport1()
				Dim rpt2 As New XtraReport2()
				rpt.CreateDocument()
				rpt2.CreateDocument()
				rpt.Pages.AddRange(rpt2.Pages)
				Dim ms As New MemoryStream()
				Try
					rpt.PrintingSystem.SaveDocument(ms)
					ms.Seek(0,SeekOrigin.Begin)
					Dim array() As Byte = ms.ToArray()
					Session("Report") = array
					ReportViewer1.Report = rpt
				Finally
					ms.Close()
				End Try
			Else
				Dim ms As New MemoryStream(CType(Session("Report"), Byte()))
				Try
					ms.Seek(0,SeekOrigin.Begin)
					Dim rep As New XtraReport()
					rep.PrintingSystem.LoadDocument(ms)
					ReportViewer1.Report = rep
				Finally
					ms.Close()
				End Try

			End If

		End Sub
	End Class
End Namespace
