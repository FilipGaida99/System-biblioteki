<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebGuest._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Witaj na stronie biblioteki publicznej</h1>
    <form id="form1" runat="server">
        <asp:Button ID="BrowseButton" runat="server" Text="Przeglądanie księgozbioru" OnClick="BrowseButton_Click" Font-Size="XX-Large" Height="167px" ToolTip="Przejście do strony przeglądania księgozbioru" Width="100%" />
        <hr />
        <asp:Button ID="UserButton" runat="server" Text="Przeglądanie wypożyczeń i rezerwacji" OnClick="UserButton_Click" Font-Size="XX-Large" Height="167px" ToolTip="Przejście do strony przeglądania wypożyczeń" Width="100%" />
    </form>
</body>
</html>
