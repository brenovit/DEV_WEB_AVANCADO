<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageIMC.aspx.cs" Inherits="pageIMC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calcular IMC</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Calcular IMC</h2>
            <asp:Panel runat="server" ID="panelAlerta" Visible="false">
                <asp:Label runat="server" ID="labelAlerta"></asp:Label>
            </asp:Panel>
            <table style="border-spacing:10px">
                <tr>
                    <td>
                        <asp:Label ID="lblPeso" runat="server" Text="Peso:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAltura" runat="server" Text="Altura:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAltura" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
