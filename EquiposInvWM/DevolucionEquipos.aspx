<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DevolucionEquipos.aspx.cs" Inherits="EquiposInvWM.DevolucionEquipos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Devoluciones</h1>
    <div class="container">
        <div class="jumbotron">
        <h2>Informacion General</h2>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>ID Ficha:</h4>
            </div>
            <div class="col-md-1">
                <asp:Label ID="lbFichaID" runat="server" Text="Ninguna Ficha Seleccionada"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <button type="button" class="btn btn-info" data-toggle="modal" data-target=".bd-example-modal-sm">Seleccionar Ficha</button>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>Usuario Asignado:</h4>
            </div>
            <div class="col-md-1">
                <asp:Label ID="lbUsuarioAsignado" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <h4>Equipo Asignado:</h4>
            </div>
            <div class="col-md-1">
                <asp:Label ID="lbEquipoAsignado" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <h4>Fecha Creacion:</h4>
            </div>
            <div class="col-md-1">
                <asp:Label ID="lbFechaCreacion" runat="server" Text=""></asp:Label>
            </div>
        </div>
        </div>
    </div>

    <!-- Area de Modales -->
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-lg">Large modal</button>

    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          ...
        </div>
      </div>
    </div>
    

</asp:Content>
