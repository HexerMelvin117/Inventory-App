<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DevolucionDeEquipos.aspx.cs" Inherits="EquiposInvWM.DevolucionDeEquipos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/jquery.dataTables.min.css" />
    <script type="text/javascript" src="Scripts/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.dataTables.min.js"></script>

    <h1>Devolucion de Equipo</h1>

    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gridDevolucionFicha" runat="server" CssClass="table table-striped table-bordered"
                style="width:100%; cursor: pointer;" OnPreRender="gridDevolucionFicha_PreRender"></asp:GridView>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#MainContent_gridDevolucionFicha').DataTable({
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

            $('#MainContent_EquiposGrid tbody').on('click', 'tr', function () {
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

    <h3>Informacion de Ficha</h3>

    <div class="row">
        <div class="col-md-2">
            
        </div>
    </div>
</asp:Content>

