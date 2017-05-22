<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" ID="btn1" Text="Observer" OnClick="btn1_Click" />
        <br />
        <br />
        <asp:Button runat="server" ID="btn2" Text="Delegate" OnClick="btn2_Click" />
        <br />
        <br />
        <asp:Label runat="server" ID="lblResultado" Text=""/>
    </div>
    </form>
</body>
</html>
