<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookSearch.ascx.cs" Inherits="WebGuest.BookSearch" %>
<%@ Register Src="~/DatePicker.ascx" TagPrefix="uc1" TagName="DatePicker" %>

<asp:Label runat="server" Text="Label">Szukaj:</asp:Label>
<asp:TextBox ID="SearchTextBox" runat="server" Width="171px"></asp:TextBox>
<asp:CheckBox ID="DescriptionCheckBox" runat="server" Text="Szukaj w opisach" />
<br />
<asp:Label runat="server" Text="Label">Data wydania:</asp:Label>
<asp:Label ID="DateErrorLabel" runat="server" Text="Error" ForeColor="Red"></asp:Label>
<div>
    <asp:Label runat="server" Text="Label">od</asp:Label>
    <uc1:DatePicker runat="server" ID="StartDatePicker" />
</div>
<div>
    <asp:Label runat="server" Text="Label">do</asp:Label>
    <uc1:DatePicker runat="server" ID="EndDatePicker" />
</div>
<asp:Label runat="server" Text="Label">ISBN:</asp:Label>
<asp:TextBox ID="ISBNTextBox" runat="server" Width="176px"></asp:TextBox>
<br />
<asp:Label runat="server" Text="Label">Wydawnictwo:</asp:Label>
<asp:TextBox ID="PublisherTextBox" runat="server" Width="124px"></asp:TextBox>
<br />
<asp:Label runat="server" Text="Label">Autor:</asp:Label>
<asp:TextBox ID="AuthorTextBox" runat="server" Width="178px"></asp:TextBox>
<br />
<asp:Button ID="SerachButton" runat="server" Text="Szukaj" Height="65px" OnClick="SerachButton_Click" Width="345px" />
<br />