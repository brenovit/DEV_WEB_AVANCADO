<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculo - IMC</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblPeso" runat="server" Text="Peso: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAltura" runat="server" Text="Altura: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAltura" runat="server"></asp:TextBox><br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnOk" runat="server" Text="IMC" OnClick="btnOk_Click" />
                    </td>
                </tr>
            </table>
            <p>
                <asp:Label ID="lblResultado" runat="server" Text="" />
            </p>
        </div>
    </form>
</body>
</html>
