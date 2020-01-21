<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GraficosEquipos.aspx.cs" Inherits="EquiposInvWM.GraficosEquipos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/Chart.js"></script>
    <h1>Graficos</h1>
    
    <div class="row">
        <div class="col-md-6">
            <asp:Literal ID="ltChartEquiPorComp" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
