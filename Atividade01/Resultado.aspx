<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Resultado.aspx.cs" Inherits="Resultado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resultado IMC</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl1" runat="server" Text="Resultado"></asp:Label>
        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />        
    </div>
    </form>
</body>
</html>