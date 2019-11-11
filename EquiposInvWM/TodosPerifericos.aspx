<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodosPerifericos.aspx.cs" Inherits="EquiposInvWM.TodosPerifericos" %>

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
    <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#modify">Modificar</a></li>
            <li><a data-toggle="tab" href="#delete">Eliminar</a></li>
    </ul>

    <!-- Para modificar Periferico -->
    <div class="tab-content">
        <div id="modify" class="tab-pane fade in active">
            <h3>Modificar</h3>
            <div class="row">
                <div class="col-md-2">
                    <h5>Id: </h5>
                    <asp:TextBox ID="txtIdModify" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h5>Tipo: </h5>
                    <asp:TextBox ID="txtTypePer" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <h5>Marca: </h5>
                    <asp:TextBox ID="txtBrandPer" runat="server" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="col-md-2">
                    <h5>Serie: </h5>
                    <asp:TextBox ID="txtSeriePer" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <h5>Estado:</h5>
                    <asp:DropDownList ID="cmbStatePer" runat="server" CssClass="form-control">
                        <asp:ListItem>Nuevo</asp:ListItem>
                        <asp:ListItem>Usado</asp:ListItem>
                        <asp:ListItem>Dañado</asp:ListItem>
                    </asp:DropDownList>
                </div>                
            </div>
            <br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btModifyPer" runat="server" CssClass="btn btn-primary" Text="Modificar" />
                </div>
            </div>
        </div>

        <!-- Para Eliminar Periferico -->
        <div id="delete" class="tab-pane fade">
            <h3>Eliminar</h3>
            <div class="row">
                <div class="col-md-2">
                    <h5>Id: </h5>
                    <asp:TextBox ID="txtIdDelete" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <h5>Codigo: </h5>
                    <asp:TextBox ID="txtCodDeletePer" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btDeletePer" runat="server" CssClass="btn btn-danger" Text="Eliminar" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>