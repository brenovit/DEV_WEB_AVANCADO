<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Template Method - Facede</h2>
        <asp:Label ID="lbl1" runat="server" Text="Valor 1"></asp:Label>
        <asp:TextBox ID="txtValor1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbl2" runat="server" Text="Valor 2"></asp:Label>
        <asp:TextBox ID="txtValor2" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbl3" runat="server" Text="Valor 3"></asp:Label>
        <asp:TextBox ID="txtValor3" runat="server"></asp:TextBox>
        <asp:DropDownList ID="ddlOperacoes" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="btnProcesso" runat="server" Text="Processar" OnClick="btnProcesso_Click" />
        <br />
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
