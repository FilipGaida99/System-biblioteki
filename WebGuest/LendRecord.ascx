<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LendRecord.ascx.cs" Inherits="WebGuest.LendRecord" %>
<div style="border-style: solid; margin-bottom: 5px;">
    <div style="margin-left: 5px;">
        <asp:Label ID="LendNumber" runat="server" Text="Numer Wypożyczenia" Font-Size="30px" ToolTip="Numer wypożyczenia"></asp:Label>
        <br />
        <asp:Label ID="CopyNumber" runat="server" Text="Egzemplarz" ToolTip ="Numer egzemplarza" Style="margin-right: 2px"></asp:Label>(<asp:HyperLink ID="BookLink" runat="server">Książka</asp:HyperLink>)
        <br />
        Data wypożyczenia:<asp:Label ID="LendDate" runat="server" Text="00.00.0000"></asp:Label>
        <br />
        Data przewidywanego zwrotu:<asp:Label ID="ExpectedReturnDate" runat="server" Text="00.00.0000"></asp:Label>
        <br />
        Data zwrotu:<asp:Label ID="ReturnDate" runat="server" Text="00.00.0000"></asp:Label>
        <br />
        Kary:<asp:Label ID="Penalties" runat="server" Text="Brak"></asp:Label>
    </div>
</div>
