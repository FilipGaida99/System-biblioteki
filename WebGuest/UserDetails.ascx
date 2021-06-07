<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserDetails.ascx.cs" Inherits="WebGuest.UserDetails" %>
Imię: <asp:Label ID="Forename" runat="server">Imię</asp:Label>
<br />
Nazwisko: <asp:Label ID="Surname" runat="server">Nazwisko</asp:Label>
<hr />
<strong>Wypożczenia:</strong>
<asp:Panel ID="LendsPanel" runat="server"></asp:Panel>
<strong>Rezerwacje:</strong>
<asp:Panel ID="ReservationsPanel" runat="server"></asp:Panel>