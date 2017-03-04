<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="Ok" />
        <asp:TextBox ID="txtOutroNome" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnVai" runat="server" Text="StringSend" Width="285px" OnClick="btnVai_Click"/>
    <asp:Button ID="btnOutro" runat="server" Text="Session" Width="285px" OnClick="btnOutro_Click"/>
    </div>
    </form>
</body>
</html>
