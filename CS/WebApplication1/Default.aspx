<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.1.Web, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
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
