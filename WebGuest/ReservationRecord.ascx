<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReservationRecord.ascx.cs" Inherits="WebGuest.ReservationRecord" %>
<div style="border-style: solid; margin-bottom: 5px;">
    <div style="margin-left: 5px;">
        <asp:HyperLink ID="BookLink" runat="server" Font-Size="30px">Książka</asp:HyperLink>
        <br />
        Data rezerwacji: <asp:Label ID="ReservationDate" runat="server" Text="00.00.0000"></asp:Label>
        <br />
    </div>
</div>
