<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="WebGuest.BookDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Title" runat="server" Text="Label" ToolTip="Tytuł" Style="margin-left: 5px" Font-Size="30px"></asp:Label>
        <br />
        <asp:Label ID="ISBN" runat="server" Text="Label" ToolTip="ISBN" Style="margin-left: 5px">ISBN</asp:Label>
        <br />
        <asp:Label ID="Date" runat="server" Text="Label" ToolTip="Rok wydania" Style="margin-left: 5px">Data</asp:Label>
        <br />
        <asp:Label ID="Publisher" runat="server" Text="Label" ToolTip="Wydawnictwo" Style="margin-left: 5px">Wydawnictwo</asp:Label>
        <br />
        <asp:Label ID="Authors" runat="server" Text="Label" ToolTip="Autorzy" Style="margin-left: 5px">Autorzy</asp:Label>
        <br />
        <asp:Label ID="MaxDays" runat="server" Text="Label" ToolTip="Maksymalny okres wypożyczenia" Style="margin-left: 5px">Dni</asp:Label>
        <br />
        <br />
        <asp:Label ID="Description" runat="server" Text="Label" ToolTip="Opis" Style="margin-left: 5px">Opis</asp:Label>
        <hr />
        <asp:Label ID="Availability" runat="server" Text="Label" Font-Size="30px">Dostępność</asp:Label>
        <hr />
        <asp:Table ID="CopyTable" runat="server" Width="100%">
            <asp:TableHeaderRow 
                runat="server" 
                Font-Bold="true"
                BackColor="#999999">
                <asp:TableHeaderCell>Numer Inwentarza</asp:TableHeaderCell>
                <asp:TableHeaderCell>Data wydruku</asp:TableHeaderCell>
                <asp:TableHeaderCell>Dostępność</asp:TableHeaderCell>
            </asp:TableHeaderRow></asp:Table>
    </form>
</body>
</html>
