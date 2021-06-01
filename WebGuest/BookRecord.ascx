<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookRecord.ascx.cs" Inherits="WebGuest.BookRecord" %>
<div style="border-style: solid; margin-bottom: 5px;">
    <div style ="margin-left:5px">
        <asp:HyperLink ID="ShowLink" runat="server" runat="server" Style="position: relative; float: right; top: 37px; left: -45px;" Font-Size="30px" CauseValidation="false">Wyświetl</asp:HyperLink>
        <asp:Label ID="Title" runat="server" Text="Label" ToolTip="Tytuł" Font-Size="30px"></asp:Label>
        <br />
        <asp:Label ID="ISBN" runat="server" Text="Label" ToolTip="ISBN">ISBN</asp:Label>
        <br />
        <asp:Label ID="Year" runat="server" Text="Label" ToolTip="Rok wydania">Rok</asp:Label>
        <br />
        <asp:Label ID="Publisher" runat="server" Text="Label" ToolTip="Wydawnictwo">Wydawnictwo</asp:Label>
        <br />
        <asp:Label ID="Authors" runat="server" Text="Label" ToolTip="Autorzy">Autorzy</asp:Label>
    </div>
</div>