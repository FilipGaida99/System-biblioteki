<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatePicker.ascx.cs" Inherits="WebGuest.DatePicker" %>
<asp:CheckBox ID="CheckBox" runat="server" Text=" " ToolTip="Czy brać podaną datę pod uwagę?" />
<asp:TextBox ID ="Day" TextMode="Number" runat="server" min="0" max="31" step="1" Width="37px" ToolTip="Dzień"/>
<asp:TextBox ID ="Month" TextMode="Number" runat="server" min="0" max="12" step="1" Width="44px" ToolTip="Miesiąc"/>
<asp:TextBox ID ="Year" TextMode="Number" runat="server" min="1753" max="9998" step="1" Width="72px" ToolTip="Rok"/>
<asp:Label ID="ErrorLabel" runat="server" Text="Error" ForeColor="Red"></asp:Label>