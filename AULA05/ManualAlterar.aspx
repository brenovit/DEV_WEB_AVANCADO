﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManualAlterar.aspx.cs" Inherits="ManualAlterar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" Runat="Server">
       <table>
            <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Produto"></asp:Label>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="dropDownProdutos"></asp:DropDownList>
            </td>
        </tr>
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
                <asp:Button ID="btnVoltar" runat="server" Text="VOLTAR" CssClass="btn default" OnClick="btnVoltar_Click"/>
            </td>
            <td>
                <asp:Button ID="btnSalvar" runat="server" Text="SALVAR" CssClass="btn success" OnClick="btnSalvar_Click"/>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblId" runat="server" Text="" CssClass="hide"></asp:Label>
</asp:Content>

