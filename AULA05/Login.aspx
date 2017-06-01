<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Content_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Acessar</title>
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
                        <asp:Button ID="btnCadastrar" runat="server" Text="CADASTRAR" CssClass="btn default" OnClick="btnCadastrar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="ACESSAR" CssClass="btn success" OnClick="btnLogin_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
