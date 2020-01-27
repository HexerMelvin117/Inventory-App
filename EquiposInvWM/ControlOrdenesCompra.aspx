<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlOrdenesCompra.aspx.cs" Inherits="EquiposInvWM.ControlOrdenesCompra" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Script y Hoja de estilo para gridview -->
    <link rel="stylesheet" type="text/css" href="Content/jquery.dataTables.min.css" />
    <script type="text/javascript" src="Scripts/jquery.dataTables.min.js"></script>

    <h1>Control de Ordenes de Compra</h1>
    <br />
    <a class="btn btn-default" href="AgregarOrdenCompra.aspx">Agregar Factura &raquo;</a>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gridOrdenesCompra" runat="server" CssClass="table table-striped table-bordered" 
                style="width:100%; cursor: pointer;" OnPreRender="gridOrdenesCompra_PreRender"></asp:GridView>
        </div>
    </div>

</asp:Content>
