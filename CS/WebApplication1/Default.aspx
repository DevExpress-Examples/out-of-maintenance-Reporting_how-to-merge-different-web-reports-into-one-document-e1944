<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<%@ Register Assembly="DevExpress.XtraReports.v13.2.Web, Version=13.2.0.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxxr" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <dxxr:ASPxDocumentViewer ID="DocumentViewer1" runat="server" 
            OnCacheReportDocument="DocumentViewer1_CacheReportDocument" 
            OnRestoreReportDocumentFromCache="DocumentViewer1_RestoreReportDocumentFromCache"  />
    </div>
    </form>
</body>
</html>
