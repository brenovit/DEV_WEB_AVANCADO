<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClienteListagem.aspx.cs" Inherits="ClienteListagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Nome Comum"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNomeComum" runat="server"></asp:TextBox>
            </td>
        </tr>        
         <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="CPF/CNPJ"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCpfCnpj" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Capital"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtVlCapital" runat="server"></asp:TextBox>
            </td>
        </tr>        
        <tr>
            <td>
                <asp:Button ID="btnFiltrar" runat="server" Text="FILTRAR" CssClass="btn default" OnClick="btnFiltrar_Click"/>
            </td>
            <td>
                <asp:Button ID="btnInserir" runat="server" Text="INSERIR" CssClass="btn success" OnClick="btnInserir_Click"/>
            </td>
        </tr>
    </table>
    <div>
        <asp:GridView ID="grdClientes" runat="server"
            AutoGenerateColumns="false" AutoGenerateSelectButton="true"
            PageSize="10" Width="100%" DataKeyNames="idCliente"
            EmptyDataText="Tem nada aqui" OnPageIndexChanging="grdClientes_PageIndexChanging"
            OnSelectedIndexChanged="grdClientes_SelectedIndexChanged"
            OnRowDataBound="grdClientes_RowDataBound">
            <Columns>
                <asp:BoundField DataField="idCliente" HeaderText="Id" InsertVisible="true" ControlStyle-CssClass="hide" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"/>
                <asp:BoundField DataField="dsNome" HeaderText="NOME" />
                <asp:BoundField DataField="dsNomeComum" HeaderText="NOME COMUM" />
                <asp:BoundField DataField="dsCPFCNPJ" HeaderText="CPFCNPJ" />
                <asp:BoundField DataField="vlCapital" HeaderText="VALOR" />
            </Columns>
            <SelectedRowStyle BackColor="LightBlue" Font-Bold="true" ForeColor="Red" />
        </asp:GridView>
    </div>

    <table>
        <tr>
            <td>
                <asp:Button ID="btnVisualizar" runat="server" Text="VISUALIZAR" CssClass="btn info" OnClick="btnVisualizar_Click" />
            </td>
            <td>
                <asp:Button ID="btnAlterar" runat="server" Text="ALTERAR" CssClass="btn warning" OnClick="btnAlterar_Click"/>
            </td>
            <td>
                <asp:Button ID="btnDeletar" runat="server" Text="DELETAR" CssClass="btn danger" OnClick="btnDeletar_Click"/>
            </td>
            <td>
                <asp:Button ID="btnVoltar" runat="server" Text="VOLTAR" CssClass="btn default" OnClick="btnVoltar_Click"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblId" runat="server" Text="" CssClass="hide"></asp:Label>
            </td>
        </tr>
        </table>
</asp:Content>

