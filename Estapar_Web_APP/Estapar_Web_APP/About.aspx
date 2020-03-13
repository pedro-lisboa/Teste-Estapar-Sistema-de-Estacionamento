<%@ Page Title="Sobre o Sistema" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Estapar_Web_APP.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Sistema para controle de Estacionamento.</h3>
    <p>Neste sistema se cadastra os manobristas, onde somente o CPF é único e não se reperte.
        Há o cadastro dos veículos, onde as placas são únicas e não se repetem.
        E o principal, onde se relaciona o manobrista a um carro e este é unico conforme sua data e hora de manobra. 
    </p>
</asp:Content>
