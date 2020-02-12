<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisualizadorFicha.aspx.cs" Inherits="EquiposInvWM.VisualizadorFicha" %>

<%@ Register Assembly="DevExpress.XtraReports.v19.1.Web.WebForms, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/jquery.dataTables.min.css" />
    <script type="text/javascript" src="Scripts/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.dataTables.min.js"></script>

    <br />
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="AsignarEquipo.aspx">Asignacion de Equipo</a></li>
        <li class="breadcrumb-item active" aria-current="page">Imprimir Ficha</li>
      </ol>
    </nav>
    <h3>Fichas Guardadas</h3>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="FichasGrid" runat="server" CssClass="table table-striped table-bordered"
                style="width:100%; cursor: pointer;" OnPreRender="FichasGrid_PreRender"></asp:GridView>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#MainContent_FichasGrid').DataTable({
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

            $('#MainContent_FichasGrid tbody').on('click', 'tr', function () {
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
    <br />
    <div class="row">
        <dx:ASPxWebDocumentViewer ID="FichaWebDocumentViewer" runat="server" ReportSourceId="EquiposInvWM.Reporting.FichaComputoReport"></dx:ASPxWebDocumentViewer>
    </div>
</asp:Content>
