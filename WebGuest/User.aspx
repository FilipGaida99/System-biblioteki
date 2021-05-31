<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebGuest.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Sprawdz swoje wypożyczenia i rezerwacje</h1>
    <form id="form1" runat="server">
        <div>
            Twoj numer czytelnika:<asp:TextBox ID="IDTextBox" runat="server" Width="421px" ToolTip ="Numer czytelnika"></asp:TextBox>
            <asp:Button ID="SubmitButton" runat="server" Text="Wprowadź" OnClick="SubmitButton_Click" />
            <br />
        </div>
    </form>
</body>
</html>
