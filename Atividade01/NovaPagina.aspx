<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NovaPagina.aspx.cs" Inherits="NovaPagina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl1" runat="server" Text="nova pagina"></asp:Label>
        <asp:Button ID="btnVolta" runat="server" Text="Voltar" OnClick="btnVolta_Click" />
        <br />
        <asp:Label ID="lbl2" runat="server" Text="nova pagina"></asp:Label>
    </div>
    </form>
</body>
</html>
