<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="WebGuest.WebForm1" %>

<%@ Register Src="~/DatePicker.ascx" TagPrefix="uc1" TagName="DatePicker" %>
<%@ Register Src="~/BookSearch.ascx" TagPrefix="uc1" TagName="BookSearch" %>
<%@ Register Src="~/BookRecord.ascx" TagPrefix="uc1" TagName="BookRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <h1>PRZEGLĄDANIE KSIĘGOZBIORU</h1>
    <form id="form1" runat="server">
        <uc1:BookSearch runat="server" id="BookSearch" />
        <asp:Label ID="CountLabel" runat="server" Text="Label">Wyniki wyszukiwania:</asp:Label>
        <asp:Panel ID="BookRecordPanel" runat="server"></asp:Panel>
    </form>
</body>
</html>
