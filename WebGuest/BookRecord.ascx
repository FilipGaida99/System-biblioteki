<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookRecord.ascx.cs" Inherits="WebGuest.BookRecord" %>
<div style ="border-style: solid;">
<asp:HyperLink ID="ShowLink" runat="server" runat="server" style="position:relative; float:right; top: 37px; left: -45px;" Font-Size ="30px" CauseValidation="false">Wyświetl</asp:HyperLink>
<asp:Label ID="Title" runat="server" Text="Label" ToolTip="Tytuł" style ="margin-left:5px" Font-Size ="30px"></asp:Label>
<br />
<asp:Label ID="ISBN" runat="server" Text="Label" ToolTip="ISBN" style ="margin-left:5px">ISBN</asp:Label>
<br />
<asp:Label ID="Year" runat="server" Text="Label" ToolTip="Rok wydania" style ="margin-left:5px">Rok</asp:Label>
<br />
<asp:Label ID="Publisher" runat="server" Text="Label" ToolTip="Wydawnictwo" style ="margin-left:5px">Wydawnictwo</asp:Label>
<br />
<asp:Label ID="Authors" runat="server" Text="Label" ToolTip="Autorzy" style ="margin-left:5px">Autorzy</asp:Label>
</div>