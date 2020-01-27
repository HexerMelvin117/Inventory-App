<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GraficosEquipos.aspx.cs" Inherits="EquiposInvWM.GraficosEquipos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/Chart.js"></script>
    <h1>Graficos</h1>

    <h3>Equipos de Computo</h3>
    <!-- Graficos para mostrar por Compañia y por Estado -->
    <div class="row">
        <div class="col-md-6">
            <asp:Literal ID="ltChartEquiPorComp" runat="server"></asp:Literal>
        </div>
        <div class="col-md-6">
            <asp:Literal ID="ltChartEquiPorEstados" runat="server"></asp:Literal>
        </div>
    </div>

    <h3>Perifericos</h3>
    <div class="row">
        <div class="col-md-6">
            <asp:Literal ID="ltChartPerPorEstado" runat="server"></asp:Literal>
        </div>
        <div class="col-md-6">
            <asp:Literal ID="ltChartPerPorTipo" runat="server"></asp:Literal>
        </div>
    </div>

</asp:Content>
