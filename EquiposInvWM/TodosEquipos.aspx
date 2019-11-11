<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodosEquipos.aspx.cs" EnableEventValidation="false" Inherits="EquiposInvWM.TodosEquipos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Scripts y archivo de estilo para usar la API de dataTable -->
    <link rel="stylesheet" type="text/css" href="Content/jquery.dataTables.min.css" />
    <script type="text/javascript" src="Scripts/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.dataTables.min.js"></script>

    <header>
        <link rel="stylesheet" type="text/css" href="Content/grid-style.css" />
    </header>
    
    <h1>Equipos</h1>
    <p>
        <a class="btn btn-default" href="AgregarEquipo.aspx">Agregar Equipo &raquo;</a>
    </p>
    <br />
     
    <div class="row">
        <div class="col-md-12">
            <!-- Gridview Section -->
            <asp:GridView ID="EquiposGrid" runat="server" OnRowDataBound="EquiposGrid_RowDataBound" CssClass="table table-striped table-bordered" 
                style="width:100%; cursor: pointer;" FooterStyle-CssClass="footer-grid" AllowPaging="False" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" OnPageIndexChanging="EquiposGrid_PageIndexChanging" OnPreRender="EquiposGrid_PreRender">
            </asp:GridView>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2">
            <asp:Button ID="btExportarExcel" runat="server" OnClick="btExportarExcel_Click" CssClass="btn btn-success" Text="Exportar a Excel" />
        </div>
        <div class="col-md-2">
            <asp:Button ID="btExportarPDF" runat ="server" OnClick="btExportarPDF_Click" CssClass="btn btn-danger" Text="Exportar a PDF" />
        </div>
    </div>
    <br />
    <!-- Script para cambiar lenguaje al API de DataTable -->

    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#MainContent_EquiposGrid').DataTable({
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
    <!-- Script para busqueda en el GridView -->
    <script type="text/javascript">
        function search_table() {
            var input, filter, found, table, tr, td, i, j;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            table = document.getElementById("MainContent_EquiposGrid");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td");
                for (j = 0; j < td.length; j++) {
                    if (td[j].innerHTML.toUpperCase().indexOf(filter) > -1) {
                        found = true;
                    }
                }
                if (found) {
                    tr[i].style.display = "";
                    found = false;
                } else if (tr[i].className != 'header') {
                        tr[i].style.display = "none";
                }
            }
        }
    </script>
    <script type="text/javascript" src="Scripts/filteringHeaders.js"></script>
        <div class="row">
            <div class="col-md-2">
                <asp:Button ID="btMostrarTodo" runat="server" OnClick="btMostrarTodo_Click" Text="Refrescar" class="btn btn-primary" />
            </div>
        </div>
        
    
        <br />
        <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#modify">Modificar</a></li>
            <li><a data-toggle="tab" href="#delete">Eliminar</a></li>
        </ul>

        <!-- Para Modificar y Eliminar -->
        <div class="tab-content">
            <div id="modify" class="tab-pane fade in active">
              <h3>Modificar</h3>
              <div class="row">
                <div class="col-md-2">
                    <h5>ID Interno:</h5>
                    <asp:TextBox ID="txtEquipoID" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <h5>Usuario Asignado:</h5>
                    <asp:TextBox ID="txtEmpleado" placeholder="Nombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <h5>Tipo:</h5>
                    <asp:DropDownList ID="cmbTipo" CssClass="form-control" runat="server" OnSelectedIndexChanged="cmbTipo_SelectedIndexChanged">
                        <asp:ListItem>-- Vacio --</asp:ListItem>
                        <asp:ListItem>Escritorio</asp:ListItem>
                        <asp:ListItem>Laptop</asp:ListItem>
                        <asp:ListItem>Impresora</asp:ListItem>
                        <asp:ListItem>Reloj Biometrico</asp:ListItem>
                        <asp:ListItem>Camara</asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                <div class="col-md-2">
                    <h5>Marca:</h5>
                    <asp:DropDownList ID="cmbMarca" CssClass="form-control" runat="server" Enabled="True">
                        <asp:ListItem>-- Vacio --</asp:ListItem>
                        <asp:ListItem>ASUS</asp:ListItem>
                        <asp:ListItem>DELL</asp:ListItem>
                        <asp:ListItem>HP</asp:ListItem>
                        <asp:ListItem>Alienware</asp:ListItem>
                        <asp:ListItem>Lenovo</asp:ListItem>
                        <asp:ListItem>Toshiba</asp:ListItem>
                        <asp:ListItem>HIKVISION</asp:ListItem>
                        <asp:ListItem>KYOCERA</asp:ListItem>
                        <asp:ListItem>EPSON</asp:ListItem>
                        <asp:ListItem>TOSHIBA</asp:ListItem>
                        <asp:ListItem>HP</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <h5>Procesador: </h5>
                    <asp:DropDownList ID="cmbProcessor" CssClass="form-control" runat="server">
                        <asp:ListItem>-- Seleccionar --</asp:ListItem>
                        <asp:ListItem>N/A</asp:ListItem>
                        <asp:ListItem>INTEL i3</asp:ListItem>
                        <asp:ListItem>INTEL i5</asp:ListItem>
                        <asp:ListItem>INTEL i7</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h5>Empresa</h5>
                    <asp:DropDownList ID="cmbEmpresaCod" CssClass="form-control" runat="server">
                        <asp:ListItem>WM</asp:ListItem>
                        <asp:ListItem>DC</asp:ListItem>
                        <asp:ListItem>S21</asp:ListItem>
                        <asp:ListItem>DCS</asp:ListItem>
                        <asp:ListItem>PLT</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <h5>Orden de Compra:</h5>
                    <asp:TextBox ID="txtOrdenCompra" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <h5>Serie:</h5>
                    <asp:TextBox ID="txtSerie" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <h5>Disco:</h5>
                    <asp:TextBox ID="txtDisk" placeholder="0 gb" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h5>Codigo de Equipo:</h5>
                    <asp:TextBox ID="txtModCodEqui" runat="server" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <h5>Ram:</h5>
                    <asp:TextBox ID="txtRam" placeholder="0" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <h5>ghz:</h5>
                    <asp:TextBox ID="txtGhz" placeholder="0" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2">
                  <asp:Button ID="btModify" class="btn btn-primary" OnClientClick="return validateFields();" OnClick="btModify_Click" runat="server" Text="Modificar" />
                </div>
            </div>
            <script>
                var table = document.getElementsByTagName("table")[0];
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
                    document.getElementById('MainContent_txtEliminarID').value = data[0];
                    document.getElementById('MainContent_txtCodEliminar').value = data[1];
                    document.getElementById('MainContent_txtEquipoID').value = data[0];
                    document.getElementById('MainContent_txtEmpleado').value = data[2];
                    if (data[2] == "&nbsp;") {
                        document.getElementById('MainContent_txtEmpleado').value = "";
                    }
                    document.getElementById('MainContent_txtSerie').value = data[10];
                    if (data[10] == "&nbsp;") {
                        document.getElementById('MainContent_txtSerie').value = ""
                    }
                    document.getElementById('MainContent_txtDisk').value = data[9];
                    document.getElementById('MainContent_txtRam').value = data[8];
                    document.getElementById('MainContent_txtGhz').value = data[7];
                    document.getElementById('MainContent_txtModCodEqui').value = data[1];
                    document.getElementById('MainContent_txtOrdenCompra').value = data[13];
                    if (data[13] == "&nbsp;") {
                        document.getElementById('MainContent_txtOrdenCompra').value = "";
                    }
                };
            </script>
            </div>
            <div id="delete" class="tab-pane fade">
              <h3>Eliminar</h3>
              <div class="row">
                  <div class="col-md-2">
                      <h5>ID Interno: </h5>
                      <asp:TextBox ID="txtEliminarID" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  <div class="col-md-2">
                      <h5>Codigo de Equipo: </h5>
                      <asp:TextBox ID="txtCodEliminar" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
              </div>
              <br />
              <div class="row">
                <div class="col-md-2">
                  <button type="button" class="btn btn-danger" data-toggle="modal" data-target=".bd-example-modal-sm">Eliminar</button>
                </div>
              </div>
            </div>
        </div>
        <br />

        <!-- Modal Para confirmar subida a base de datos -->
        <div class="modal fade bd-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <h5>¿Esta seguro que quiere eliminar este registro del sistema?</h5>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btEliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="btEliminar_Click" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>

        <script>
            function validateFields() {
                var ddlProcessor = document.getElementById("MainContent_cmbProcessor");
                var selectedValueProcessor = ddlProcessor.options[ddlProcessor.selectedIndex].value;
                var ddlMarca = document.getElementById("MainContent_cmbMarca");
                var selectedValueMarca = ddlMarca.options[ddlMarca.selectedIndex].value;
                var ddlEmpCod = document.getElementById("MainContent_cmbEmpresaCod");
                var selectedValueEmpCod = ddlEmpCod.options[ddlEmpCod.selectedIndex].value;

                if (selectedValueProcessor == "-- Seleccionar --") {
                    alert("Porfavor seleccionar procesador");
                    return false;
                }

                if (selectedValueMarca == "-- Vacio --") {
                    alert("Porfavor seleccionar marca");
                    return false;
                }

                if (selectedValueEmpCod == "-- Vacio --") {
                    alert("Porfavor seleccionar empresa");
                }
            }
    </script>
</asp:Content>
