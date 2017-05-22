<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddlMes" runat="server" Height="16px" Width="191px" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged"
                            AutoPostBack="true">
            <asp:ListItem Value="-1">- - - Selecione um Item - - -</asp:ListItem>
            <asp:ListItem Value="1">Janeiro</asp:ListItem>
            <asp:ListItem Value="2">Fevereiro</asp:ListItem>
            <asp:ListItem Value="3">Março</asp:ListItem>
            <asp:ListItem Value="4">Abril</asp:ListItem>
            <asp:ListItem Value="5">Maio</asp:ListItem>
            <asp:ListItem Value="6">junho</asp:ListItem>
            <asp:ListItem Value="7">julho</asp:ListItem>
            <asp:ListItem Value="8">Agosto</asp:ListItem>
            <asp:ListItem Value="9">Setembro</asp:ListItem>
            <asp:ListItem Value="10">Outubro</asp:ListItem>
            <asp:ListItem Value="11">Novembro</asp:ListItem>
            <asp:ListItem Value="12">Dezembro</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lbResultado" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" />

        <br />
        <br />

        <table border="0">
              <tr>
                <td>
                    <asp:ListBox ID="lst1" runat="server" Height="107px" Width="148">
                        <asp:ListItem Value="1">Segunda</asp:ListItem>
                        <asp:ListItem Value="2">Terça</asp:ListItem>
                        <asp:ListItem Value="3">Quarta</asp:ListItem>
                        <asp:ListItem Value="4">Quinta</asp:ListItem>
                        <asp:ListItem Value="5">Sexta</asp:ListItem>
                        <asp:ListItem Value="6">Sábado</asp:ListItem>
                        <asp:ListItem Value="1">Domingo</asp:ListItem>
                    </asp:ListBox>
              </td>
                  <!-- -->
                <td>
                    <asp:Button ID="btnIncluir" runat="server" Text=">" Width="32px" OnClick="btnIncluir_Click" />
                    <br />
                    <asp:Button ID="btnTodos" runat="server" Text=">>" Width="32px" OnClick="btnTodos_Click" />
                    <br />
                    <asp:Button ID="btnRemover" runat="server" Text="<" Width="32px" OnClick="btnRemover_Click" />
                    <br />
                </td>
                  <!-- -->
                <td>
                    <asp:ListBox ID="lst2" runat="server" Width="148px" Height="107"></asp:ListBox>
                </td>
            </tr>
        </table>


    </div>
    </form>
</body>
</html>
