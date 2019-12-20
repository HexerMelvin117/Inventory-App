﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DevolucionEquipos.aspx.cs" Inherits="EquiposInvWM.DevolucionEquipos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Scripts y archivo de estilo para usar la API de dataTable -->
    <link rel="stylesheet" type="text/css" href="Content/jquery.dataTables.min.css" />
    <script type="text/javascript" src="Scripts/jquery.dataTables.min.js"></script>

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
                    <button type="button" class="btn btn-info" data-toggle="modal" data-target=".bd-modal-ficha">Seleccionar Ficha</button>
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
    <div class="modal fade bd-modal-ficha" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <h3>Fichas</h3>
                <asp:GridView ID="gridFichasDevolucion" runat="server" CssClass="table table-striped table-bordered" OnPreRender="gridFichasDevolucion_PreRender"></asp:GridView>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btSelecFichaDevo" runat="server" Text="Seleccionar" CssClass="btn btn-primary" />
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
            </div>
        </div>
      </div>
    </div>
    <!-- Para usar API de datatable con gridFichasDevolucion -->
    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#MainContent_gridFichasDevolucion').DataTable({
                "language": {
                    "search": "Buscar:",
                    "lengthMenu": "Mostrar _MENU_ entradas",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
                    "infoEmpty": "Mostrando 0 Entradas",
                    "infoFiltered": "(filtrando de _MAX_ total entradas)",
                    "processing": "Procesando...",
                    "zeroRecords": "Ningun record encontrado",
                    "emptyTable": "No hay datos en la tabla",
                    paginate: {
                        "previous": "Anterior",
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente"
                    }
                },
                "searching": true
            });

            $('#MainContent_gridFichasDevolucion tbody').on('click', 'tr', function () {
                if ($(this).hasClass('selected')) {
                    $(this).removeClass('selected');
                }
                else {
                    table.$('tr.selected').removeClass('selected');
                    $(this).addClass('selected');
                }
            });

            $('#button').click(function () {
                table.row('.selected').remove().draw(false);
            });
        });
    </script>
    

</asp:Content>
