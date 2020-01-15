<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DevolucionEquipos.aspx.cs" Inherits="EquiposInvWM.DevolucionEquipos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Scripts y archivo de estilo para usar la API de dataTable -->
    <link rel="stylesheet" type="text/css" href="Content/jquery.dataTables.min.css" />
    <script type="text/javascript" src="Scripts/jquery.dataTables.min.js"></script>

    <!-- Breadcrumbs -->
    <br />
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="ControlDeFichas.aspx">Control de Fichas</a></li>
        <li class="breadcrumb-item active" aria-current="page">Crear Devolucion</li>
      </ol>
    </nav>

    <!-- Informacion y seleccion de ficha para crear devolucion -->
    <h1>Devoluciones</h1>
    <a class="btn btn-default" href="VisualizadorDevolucion.aspx">Imprimir Devolucion &raquo;</a>
    
    <div class="container">
        <div class="jumbotron">
            <h2>Informacion General</h2>
            <div class="row">
                <div class="col-md-2">
                    <button type="button" class="btn btn-info" data-toggle="modal" data-target=".bd-modal-ficha">Seleccionar Ficha</button>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2">
                    <h4>ID Ficha:</h4>
                </div>
                <div class="col-md-2">
                    <h4>
                        <asp:Label ID="lbFichaID" runat="server" Text=""></asp:Label>
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4>Usuario Asignado:</h4>
                </div>
                <div class="col-md-2">
                    <h4>
                        <asp:Label ID="lbUsuarioAsignado" runat="server" Text=""></asp:Label>
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4>Equipo Asignado:</h4>
                </div>
                <div class="col-md-2">
                    <h4>
                        <asp:Label ID="lbEquipoAsignado" runat="server" Text=""></asp:Label>
                    </h4>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4>Fecha Creacion:</h4>
                </div>
                <div class="col-md-2">
                    <h4>
                        <asp:Label ID="lbFechaCreacion" runat="server" Text=""></asp:Label>
                    </h4> 
                </div>
            </div>
        </div>
    </div>
    
    <div class="row">
        <div class="col-md-2">
            <h3>Perifericos</h3>
        </div>
    </div>
    <div class="row">
        <!-- GridView para mostrar todos los perifericos asociados -->
        <div class="col-md-12">
            <asp:GridView ID="gridPeriphSelect" runat="server" onclick="periphSelect()" style="cursor: pointer;" CssClass="table table-striped table-bordered" OnPreRender="gridPeriphSelect_PreRender"></asp:GridView>
        </div>
    </div>
    <!-- Area donde se mostrara la informacion del periferico seleccionado en cajas de texto -->
    <div class="row">
        <div class="col-md-2">
            <label>ID Periferico Seleccionado:</label>
            <asp:TextBox ID="txtSelectedPeriph" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label>Tipo:</label>
            <asp:TextBox ID="txtTypeSelPer" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label>Marca:</label>
            <asp:TextBox ID="txtMarcaSelPer" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label>Estado</label>
            <asp:TextBox ID="txtEstadoSelPer" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label>ID Interno:</label>
            <asp:TextBox ID="txtInternalIDPer" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            <asp:UpdatePanel ID="ActionSelectPeriphPanel" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btSelectPeriph" runat="server" CssClass="btn btn-primary" Text="Seleccionar" OnClick="btSelectPeriph_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <br />
    <div class="row">
        <!-- GridView para colocar perifericos seleccionados y luego subirlos a la BD -->
        <div class="col-md-12">
            <asp:UpdatePanel ID="UpdateGridSelectedPeriph" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gridSelectedPeriph" runat="server" style="cursor: pointer;" CssClass="table table-striped table-bordered" OnPreRender="gridSelectedPeriph_PreRender"></asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <br />
    
    <!-- Seccion de seleccion de imagenes -->
    <h3>Imagenes</h3>
    <asp:FileUpload ID="ImagenUpload1" runat="server" AllowMultiple="true" accept=".png,.jpg,.jpeg,.gif" CssClass="form-control" />
    <br />
    <asp:FileUpload ID="ImagenUpload2" runat="server" AllowMultiple="true" accept=".png,.jpg,.jpeg,.gif" CssClass="form-control" />
    <br />
    <asp:FileUpload ID="ImagenUpload3" runat="server" AllowMultiple="true" accept=".png,.jpg,.jpeg,.gif" CssClass="form-control" />
    <br />
    <asp:FileUpload ID="ImagenUpload4" runat="server" AllowMultiple="true" accept=".png,.jpg,.jpeg,.gif" CssClass="form-control" />
    <br />
    <asp:FileUpload ID="ImagenUpload5" runat="server" AllowMultiple="true" accept=".png,.jpg,.jpeg,.gif" CssClass="form-control" />
    <br />
    <asp:FileUpload ID="ImagenUpload6" runat="server" AllowMultiple="true" accept=".png,.jpg,.jpeg,.gif" CssClass="form-control" />
    <br />

    <!-- Seccion de Observaciones -->
    <div class="row">
        <div class="col-md-6">
            <h3>Observaciones: </h3>
            <asp:TextBox ID="txtObservacionArea" TextMode="MultiLine" CssClass="form-control rounded-0" runat="server" Columns="100" Rows="5"></asp:TextBox>
        </div>
    </div>
    <br />
    <!-- Checkboxes para escoger que contenida ira en la devolucion -->
    <div class="row">
        <div class="col-md-2">
            <asp:CheckBox ID="chboxIncludePeriph" runat="server" Text="Incluir Perifericos" />
        </div>
        <div class="col-md-2">
            <asp:CheckBox ID="chboxIncludeEquipment" runat="server" Text="Incluir Equipo" />
        </div>
    </div>
    <br />
    <!-- Acciones para crear devolucion (botones) -->
    <div class="row">
        <div class="col-md-2">
            <button type="button" class="btn btn-info" data-toggle="modal" data-target=".bd-modal-confirmarDevolucion">Subir Ficha</button>
        </div>
    </div>

    <!-- Area de Modales -->
    <!-- Modal para seleccionar Ficha -->
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
                <div class="row">
                    <div class="col-md-3">
                        <label>Ficha Seleccionada:</label>
                        <asp:TextBox ID="txtFichaIdSelec" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <br />
                <asp:GridView ID="gridFichasDevolucion" runat="server" onclick="fichaSelect()" CssClass="table table-striped table-bordered" OnPreRender="gridFichasDevolucion_PreRender"></asp:GridView>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btSelecFichaDevo" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="btSelecFichaDevo_Click" />
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
            </div>
        </div>
      </div>
    </div>

    <!-- Modal para confirmar creacion de ficha de devolucion -->
    <div class="modal fade bd-modal-confirmarDevolucion" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <h5>¿Desea proceder con la creacion de la devolucion?</h5>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btCreateDevolution" runat="server" CssClass="btn btn-primary" Text="Crear Devolucion" OnClick="btCreateDevolution_Click" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
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

    <!-- Para usar API de datatable con gridPeriphSelect -->
    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#MainContent_gridPeriphSelect').DataTable({
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

            $('#MainContent_gridPeriphSelect tbody').on('click', 'tr', function () {
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

    <!-- Script para coger primer valor de DataTable al dar click en una de las filas -->
    <script>
        function fichaSelect() {
            var table = document.getElementById("MainContent_gridFichasDevolucion");
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
                document.getElementById('MainContent_txtFichaIdSelec').value = data[0];
            };
        }
     </script>

    <!-- Script para coger valores de gridPerifericoSelect -->
    <script>
        function periphSelect() {
            var table = document.getElementById("MainContent_gridPeriphSelect");
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
                document.getElementById('MainContent_txtInternalIDPer').value = data[0];
                document.getElementById('MainContent_txtSelectedPeriph').value = data[1];
                if (data[1] == "&nbsp;") {
                    document.getElementById('MainContent_txtSelectedPeriph').value = "";
                }
                document.getElementById('MainContent_txtMarcaSelPer').value = data[2];
                if (data[2] == "&nbsp;") {
                    document.getElementById('MainContent_txtMarcaSelPer').value = "";
                }
                document.getElementById('MainContent_txtTypeSelPer').value = data[3];
                if (data[3] == "&nbsp;") {
                    document.getElementById('MainContent_txtTypeSelPer').value = "";
                }
                document.getElementById('MainContent_txtEstadoSelPer').value = data[4];
                if (data[4] == "&nbsp;") {
                    document.getElementById('MainContent_txtEstadoSelPer').value = "";
                }
            };
        }
    </script>
</asp:Content>
