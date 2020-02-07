<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReparacionDeEquipos.aspx.cs" Inherits="EquiposInvWM.ReparacionDeEquipos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Scripts para utilizacion de API de Datatable -->
    <link rel="stylesheet" type="text/css" href="Content/jquery.dataTables.min.css" />
    <script type="text/javascript" src="Scripts/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.dataTables.min.js"></script>

    <h1>Reparacion de Equipos</h1>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gridHistoricoRepa" runat="server" CssClass="table table-striped table-bordered"
                style="cursor: pointer;" OnPreRender="gridHistoricoRepa_PreRender" ></asp:GridView>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#MainContent_gridHistoricoRepa').DataTable({
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

            $('#MainContent_gridHistoricoRepa tbody').on('click', 'tr', function () {
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
        })
    </script>

    <h2>Detalles de la Reparacion</h2>
    <div class="row">
        <div class="col-md-3">
            <h5>ID Reparacion</h5>
            <asp:TextBox ID="txtIDReparacion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btBuscarInfoRepa" runat="server" CssClass="btn btn-primary" Text="Buscar" />
        </div>
    </div>
</asp:Content>
