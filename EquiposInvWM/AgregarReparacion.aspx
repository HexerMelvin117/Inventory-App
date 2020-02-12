<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarReparacion.aspx.cs" Inherits="EquiposInvWM.AgregarReparacion" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Scripts y archivo de estilo para usar la API de dataTable -->
    <link rel="stylesheet" type="text/css" href="Content/jquery.dataTables.min.css" />
    <script type="text/javascript" src="Scripts/jquery.dataTables.min.js"></script>

    <!-- Script y Hoja de estilo para utilizar escogedor de fecha -->
    <link rel="stylesheet" href="Content/foopicker.css" />
    <script type="text/javascript" src="Scripts/foopicker.js"></script>

    <br />
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="ReparacionDeEquipos.aspx">Reparaciones</a></li>
        <li class="breadcrumb-item active" aria-current="page">Agregar Reparacion</li>
      </ol>
    </nav>

    <h2>Agregar Reparacion</h2>
    <br />
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalSelecEquipo">
        Seleccionar Equipo
    </button>
    <br />
    <div class="row">
        <div class="col-md-2">
            <h5>Tipo de Reparacion:</h5>
            <asp:DropDownList ID="cmbTypeRepa" runat="server" CssClass="form-control">
                <asp:ListItem>Preventiva</asp:ListItem>
                <asp:ListItem>Correctiva</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <h5>Num. Factura</h5>
            <asp:TextBox ID="txtNumFactura" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

        <!-- Modal para la seleccion de equipos -->
        <div class="modal fade" id="ModalSelecEquipo" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Seleccion de Equipo</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <div class="row">
                    <div class="col-md-3">
                        <label>Equipo seleccionado:</label>
                        <asp:TextBox ID="txtEquipoSelec" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <br />
                <asp:GridView ID="gridSelecEquipo" runat="server" CssClass="table table-striped table-bordered"
                    style="cursor: pointer;" OnPreRender="gridSelecEquipo_PreRender" onclick="equiSelect()"></asp:GridView>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                <asp:Button ID="btSelecEqui" runat="server" CssClass="btn btn-primary" Text="Seleccionar Equipo" OnClick="btSelecEqui_Click" />
              </div>
            </div>
          </div>
        </div>
        <!-- Script para usar API DataTable con SelecEquipoGrid -->
            <script type="text/javascript">
                $(document).ready(function () {
                    var table = $('#MainContent_gridSelecEquipo').DataTable({
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

                    $('#MainContent_gridSelecEquipo tbody').on('click', 'tr', function () {
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
            <!-- Script para seleccionar equipo -->
            <script>
                function equiSelect() {
                    var table = document.getElementById("MainContent_gridSelecEquipo");
                    var tbody = table.getElementsByTagName("tbody")[0];
                    tbody.onclick = function (e) {
                        e = e || window.event;
                        var data = [];
                        var target = e.srcElement || e.target;
                        while (target && target.nodeName !== "TR") {
                            target = target.parentNode;
                        }
                        if (target) {
                            var cells = target.getElementsByTagName("td");
                            for (var i = 0; i < cells.length; i++) {
                                data.push(cells[i].innerHTML);
                            }
                        }
                        document.getElementById('MainContent_txtEquipoSelec').value = data[0];
                        document.getElementById('MainContent_txtEquiCod').value = data[3];
                    };
                }
             </script>

    <div class="row">
        <div class="col-md-2">
            <h5>Fecha:</h5>
            <asp:TextBox ID ="txtDate" class="form-control" runat="server"></asp:TextBox>
            <!-- Para formato de fecha y funcionalidad -->
            <script type="text/javascript">
                var foopicker = new FooPicker({
                    id: 'MainContent_txtDate',
                    dateFormat: 'dd/MM/yyyy',
                    disable: ['29/07/2017', '30/07/2017', '31/07/2017', '01/08/2017']
                });
            </script>
            <div id="foopicker-datepicker" style="position: fixed; top: 58px; left: 8px; z-index: 99999;"></div>
        </div>
        <div class="col-md-2">
            <h5>Equipo Seleccionado</h5>
            <asp:TextBox ID="txtEquiCod" runat="server" CssClass="form-control"></asp:TextBox> 
        </div>
        <div class="col-md-2">
            <h5>Proveedor</h5>
            <asp:TextBox ID="txtRepaProveedor" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h5>Observacion</h5>
            <asp:TextBox ID="txtObservacionArea" TextMode="MultiLine" CssClass="form-control rounded-0" runat="server" Columns="100" Rows="5"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="btCrearRepa" runat="server" CssClass="btn btn-primary" Text="Agregar Reparacion" OnClick="btCrearRepa_Click" />
        </div>
    </div>
</asp:Content>
