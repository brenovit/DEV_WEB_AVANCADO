<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageIMCResultado.aspx.cs" Inherits="pageIMCResultado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Resultado Calculo</h2>
        <asp:Panel runat="server" ID="panelAlerta" Visible="false">
                <asp:Label runat="server" ID="labelAlerta"></asp:Label>
            </asp:Panel>
        <div>
            <asp:Label runat="server" ID="labelIMC" Text=""></asp:Label>
            <br />
            <br />
        </div>
        <div>
            <asp:Button ID="btnVoltarPrincipal" runat="server" Text="Voltar Principal" OnClick="btnVoltarPrincipal_Click" />
            <br />
        </div>
        <div>
            <asp:Button ID="btnVoltarCalculo" runat="server" Text="Voltar Calculo" OnClick="btnVoltarCalculo_Click" />
            <br />
        </div>
    </form>
</body>
</html>
