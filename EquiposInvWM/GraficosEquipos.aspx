<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GraficosEquipos.aspx.cs" Inherits="EquiposInvWM.GraficosEquipos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scrips/Chart.js"></script>
    <h1>Graficos</h1>
    
    <asp:Literal ID="ltChartEquiPorComp" runat="server"></asp:Literal>
</asp:Content>
