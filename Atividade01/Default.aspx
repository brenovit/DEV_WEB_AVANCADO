<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculo - IMC</title>
</head>
<body>
    <form id="form2" runat="server">
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
                        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" OnClick="btnCalcular_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>    
</body>
</html>
