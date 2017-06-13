<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClienteAlterar.aspx.cs" Inherits="ClienteAlterar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="Server">
    <table>
        <tr>
            <td>
                <asp:label id="Label1" runat="server" text="Nome"></asp:label>
            </td>
            <td>
                <asp:textbox id="txtNome" runat="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:label id="Label2" runat="server" text="Nome Comum"></asp:label>
            </td>
            <td>
                <asp:textbox id="txtNomeComum" runat="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:label id="Label4" runat="server" text="CPF/CNPJ"></asp:label>
            </td>
            <td>
                <asp:textbox id="txtCpfCnpj" runat="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:label id="Label3" runat="server" text="Capital"></asp:label>
            </td>
            <td>
                <asp:textbox id="txtVlCapital" runat="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button id="btnVoltar" runat="server" text="VOLTAR" cssclass="btn default" onclick="btnVoltar_Click" />
            </td>
            <td>
                <asp:button id="btnSalvar" runat="server" text="SALVAR" cssclass="btn success" onclick="btnSalvar_Click" />
            </td>
        </tr>
    </table>
    <asp:label id="lblId" runat="server" text="" cssclass="hide"></asp:label>
</asp:Content>

