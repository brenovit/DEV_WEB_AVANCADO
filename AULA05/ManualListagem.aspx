<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManualListagem.aspx.cs" Inherits="ManualListagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Descrição"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Validade"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtValidade" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Preço"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPreco" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Estoque"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEstoque" runat="server"></asp:TextBox>
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
        <asp:GridView ID="grdManual" runat="server"
            AutoGenerateColumns="false" AutoGenerateSelectButton="true"
            PageSize="10" Width="100%" DataKeyNames="idProduto"
            EmptyDataText="Tem nada aqui" OnPageIndexChanging="grdManual_PageIndexChanging"
            OnSelectedIndexChanged="grdManual_SelectedIndexChanged"
            OnRowDataBound="grdManual_RowDataBound">
            <Columns>
                <asp:BoundField DataField="idProduto" HeaderText="Id" InsertVisible="true" ControlStyle-CssClass="hide" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"/>
                <asp:BoundField DataField="dsDescricao" HeaderText="DESCRIÇÃO" />
                <asp:BoundField DataField="dsFornecedor" HeaderText="FORNECEDOR" />
                <asp:BoundField DataField="vlValor" HeaderText="VALOR" />
                <asp:BoundField DataField="qtEstoque" HeaderText="ESTOQUE" />
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

