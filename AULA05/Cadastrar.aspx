<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cadastrar.aspx.cs" Inherits="Cadastrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastrar</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <label>Login:</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtLogin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Senha:</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtSenha" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="ACESSAR" CssClass="btn default" OnClick="btnLogin_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCadastrar" runat="server" Text="CADASTRAR" CssClass="btn success" OnClick="btnCadastrar_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
