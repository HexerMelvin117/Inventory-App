﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodosPerifericos.aspx.cs" Inherits="EquiposInvWM.TodosPerifericos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/jquery.dataTables.min.css" />
    <script type="text/javascript" src="Scripts/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="Scripts/buttons.html5.min.js"></script>
    <script type="text/javascript" src="Scripts/dataTables.buttons.min.js"></script>
    <h1>Perifericos</h1>
        <a class="btn btn-default" href="AgregarPeriferico.aspx">Agregar Periferico &raquo;</a>
    <br />
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="PerifericosGrid" runat="server" CssClass="table table-striped table-bordered" style="width:100%; cursor: pointer;" OnPreRender="PerifericosGrid_PreRender" OnRowDataBound="PerifericosGrid_RowDataBound" OnSelectedIndexChanged="PerifericosGrid_SelectedIndexChanged"></asp:GridView>
            <asp:Button ID="btExportExcel" runat="server" CssClass="btn btn-success" OnClick="btExportExcel_Click" Text="Exportar a Excel" />
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#MainContent_PerifericosGrid').DataTable({
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
                "searching": true,
            });

            $('#MainContent_PerifericosGrid tbody').on('click', 'tr', function () {
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
    <!-- Seccion para modificar y eliminar -->
    <h3>Modificar y Eliminar</h3>
    <div class="row">
        <div class="col-md-2">
            <h5>ID:</h5>
            <asp:TextBox ID="txtIdPer" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2"></div>
    </div>

</asp:Content>