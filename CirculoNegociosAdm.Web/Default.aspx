<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="CirculoNegociosAdm._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Bem vindo ao portal de administração do site Circulo de Negocios.
    </h2>
    <p>
        Se você é um novo administrador e nao tem seu Login, peça para nossa área de gestão lhe cadastrar.
    </p>
    <p>
        Faça o Login <a href="~/Account/Login.aspx" ID="HeadLoginStatus" runat="server">aqui</a>.
    </p>
</asp:Content>
