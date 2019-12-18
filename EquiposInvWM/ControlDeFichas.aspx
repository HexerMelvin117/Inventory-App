<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlDeFichas.aspx.cs" Inherits="EquiposInvWM.DevolucionDeEquipos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/jquery.dataTables.min.css" />
    <script type="text/javascript" src="Scripts/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.dataTables.min.js"></script>

    <h1>Control de Fichas</h1>
    
    <div class="row">
        <div class="col-md-2">
            <a class="btn btn-default" href="DevolucionEquipos.aspx">Devolucion de Equipo &raquo;</a>
        </div>
    </div>

    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gridDevolucionFicha" runat="server" CssClass="table table-striped table-bordered"
                style="width:100%;" cursor="pointer;" OnPreRender="gridDevolucionFicha_PreRender"></asp:GridView>
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

            $('#MainContent_gridDevolucionFicha tbody').on('click', 'tr', function () {
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
    <br />
    <h4>Perifericos Asociados</h4>
    <div class="row">
        <div class="col-md-2">
            <h5>ID Ficha:</h5>
            <asp:TextBox ID="txtidFichaPeri" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            <asp:UpdatePanel ID="searchPanel" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btSearchPeriphAsoc" runat="server" OnClick="btSearchPeriphAsoc_Click" CssClass="btn btn-primary" Text="Buscar Perifericos" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="gridPerPanel" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gridPerifericosAsoc" runat="server" CssClass="table table-striped table-bordered"
                        style="width:100%;" cursor="pointer;" OnPreRender="gridPerifericosAsoc_PreRender"></asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#MainContent_gridPerifericosAsoc').DataTable({
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

            $('#MainContent_gridPerifericosAsoc tbody').on('click', 'tr', function () {
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
</asp:Content>

