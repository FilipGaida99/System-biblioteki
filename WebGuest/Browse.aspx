<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="WebGuest.Browse" %>

<%@ Register Src="~/DatePicker.ascx" TagPrefix="uc1" TagName="DatePicker" %>
<%@ Register Src="~/BookSearch.ascx" TagPrefix="uc1" TagName="BookSearch" %>
<%@ Register Src="~/BookRecord.ascx" TagPrefix="uc1" TagName="BookRecord" %>
<%@ Register Src="~/HomeButton.ascx" TagPrefix="uc1" TagName="HomeButton" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>PRZEGLĄDANIE KSIĘGOZBIORU <uc1:HomeButton runat="server" ID="HomeButton" /></h1>
        <uc1:BookSearch runat="server" id="BookSearch" />
        <asp:Label ID="CountLabel" runat="server" Text="Wyniki wyszukiwania:"></asp:Label>
        <asp:Panel ID="BookRecordPanel" runat="server"></asp:Panel>
    </form>
</body>
</html>
