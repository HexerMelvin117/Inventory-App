<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarEquipo.aspx.cs" Inherits="EquiposInvWM.AsignarEquipo" %>

<%@ Register assembly="DevExpress.Web.ASPxScheduler.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Scripts y archivo de estilo para usar la API de dataTable -->
    <link rel="stylesheet" type="text/css" href="Content/dataTables.bootstrap4.min.css" />
    <script type="text/javascript" src="Scripts/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.dataTables.min.js"></script>

    <!-- Archivo de estilo y javascript para el escogedor de fechas -->
    <link rel="stylesheet" href="Content/foopicker.css" />
    <script type="text/javascript" src="Scripts/foopicker.js"></script>
    <div id="main">
        <h1>Asignacion de Equipo</h1>
        <div class="row">
            <!-- Para ir al formulario "AgregarEmpleado" -->
            <div class="col-md-2">
                <a class="btn btn-default" href="AgregarEmpleado.aspx">Agregar Empleado &raquo;</a>
            </div>
        </div>

        <h3>Ficha de Equipo de Computo</h3>
        <!-- Formulario para creacion de ficha -->
        <div class="row">
            <div class="col-md-2">
                <h5>Empresa: </h5>
                <asp:DropDownList ID="cmbEmpresa" CssClass="form-control" runat="server">
                    <asp:ListItem>-- Seleccionar --</asp:ListItem>
                    <asp:ListItem>William y Molina</asp:ListItem>
                    <asp:ListItem>Duracreto</asp:ListItem>
                    <asp:ListItem>Platino</asp:ListItem>
                    <asp:ListItem>Siglo 21</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <h5>Fecha: </h5>
                <input type="text" id="datepicker" class="form-control" />
                <!-- Para formato de fecha y funcionalidad -->
                <script type="text/javascript">
                    var foopicker = new FooPicker({
                        id: 'datepicker',
                        dateFormat: 'dd/MM/yyyy',
                        disable: ['29/07/2017', '30/07/2017', '31/07/2017', '01/08/2017']
                    });
                </script>
                <div id="foopicker-datepicker" style="position: fixed; top: 58px; left: 8px; z-index: 99999;"></div>
            </div>
        </div>

        <!-- Para Informacion del empleado -->
        <h3>Informacion del empleado</h3>
        <button type="button" class="btn btn-info" data-toggle="modal" data-target="#modalEmpleado">Seleccionar Empleado</button>
        <div class="row">
            <div class="col-md-2">
                <h5>Departamento: </h5>
                <asp:TextBox ID="txtDepartamento" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <h5>Usuario Asignado: </h5>
                <asp:TextBox ID="txtAssignedUser" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <h5>Proyecto: </h5>
                <asp:TextBox ID="txtProject" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <!-- Seccion para detalles del equipo -->
        <h3>Informacion del Equipo</h3>
        <button type="button" class="btn btn-info" data-toggle="modal" data-target="#modalEquipo">Seleccionar Equipo</button>
        <div class="row">
            <div class="col-md-2">
                <h5>Marca: </h5>
                <asp:TextBox ID="txtBrandAssigned" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <h5>Codigo del Equipo: </h5>
                <asp:TextBox ID="txtEquipCode" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <h5>Serie: </h5>
                <asp:TextBox ID="txtSerialEquip" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <h5>Sistema Operativo: </h5>
                <asp:DropDownList ID="cmbOsEquipment" CssClass="form-control" runat="server">
                    <asp:ListItem>-- Seleccionar --</asp:ListItem>
                    <asp:ListItem>N/A</asp:ListItem>
                    <asp:ListItem>Windows 7 Home</asp:ListItem>
                    <asp:ListItem>Windows 7 Ultimate</asp:ListItem>
                    <asp:ListItem>Windows 7 Pro</asp:ListItem>
                    <asp:ListItem>Windows 8</asp:ListItem>
                    <asp:ListItem>Windows 10 Home</asp:ListItem>
                    <asp:ListItem>Windows 10 Pro</asp:ListItem>
                    <asp:ListItem>Windows 10 Enterprise</asp:ListItem>
                    <asp:ListItem>Windows XP</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="col-md-2">
                <h5>Procesador: </h5>
                <asp:TextBox ID="txtProcessor" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <h5>ghz:</h5>
                <asp:TextBox ID="txtGhz" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <h5>Capacidad HD: </h5>
                <asp:TextBox ID="txtHdCapacity" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>

  <!-- Modal para Empleado -->
  <div class="modal fade" id="modalEmpleado" role="dialog">
    <div class="modal-dialog modal-lg">
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
              <h4 class="modal-title">Seleccionar Empleado</h4>
            </div>
            <div class="modal-body">
                <label>Empleado Seleccionado:</label>
                <asp:TextBox ID="txtSelectedEmp" CssClass="form-control" runat="server"></asp:TextBox>
                <br />
              <asp:GridView ID="SelectEmpGrid" runat="server" onclick="empSelect()" CssClass="table table-striped table-bordered" OnPreRender="SelectEmpGrid_PreRender"></asp:GridView>
            </div>
            <div class="modal-footer">
              <asp:Button ID="btSelectEmp" class="btn btn-primary" data-dismiss="modal" runat="server" OnClick="btSelectEmp_Click" Text="Seleccionar"/>
              <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
            </div>
          </div>
            <script type="text/javascript">
                $(document).ready(function () {
                    $('#MainContent_SelectEmpGrid').DataTable({
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
                })
            </script>
        </div>
    </div>
    <script>
        function empSelect() {
            var table = document.getElementById("MainContent_SelectEmpGrid");
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
                document.getElementById('MainContent_txtSelectedEmp').value = data[0];
            };
        }
    </script>

    <!-- Modal para Equipo -->
  <div class="modal fade" id="modalEquipo" role="dialog">
    <div class="modal-dialog modal-lg">
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
              <h4 class="modal-title">Seleccionar Equipo</h4>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-md-3">
                        <label>Equipo seleccionado:</label>
                        <asp:TextBox ID="txtEquipoSelec" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <br />
                <asp:GridView ID="SelecEquipoGrid" runat="server" onclick="equiSelect()" OnPreRender="SelecEquipoGrid_PreRender" CssClass="table table-striped table-bordered"></asp:GridView>
                </div>
                <div class="modal-footer">
                  <asp:Button ID="btnSelEmployee" runat="server" CssClass="btn btn-primary" Text="Seleccionar" OnClick="btnSelEmployee_Click" />
                  <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
          </div>
            <script type="text/javascript">
                $(document).ready(function () {
                    $('#MainContent_SelecEquipoGrid').DataTable({
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
                })
            </script>
        </div>
    </div>

    <script>
        function equiSelect() {
            var table = document.getElementById("MainContent_SelecEquipoGrid");
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
            };
        }
     </script>
    

    <ul class="nav nav-tabs">
      <li class="active"><a data-toggle="tab" href="#perifericos-tab">Perifericos</a></li>
      <li><a data-toggle="tab" href="#software-tab">Software Instalado</a></li>
    </ul>

    <div class="tab-content">
      <div id="perifericos-tab" class="tab-pane fade in active">
        <h3>Perifericos</h3>
        <asp:GridView ID="gridPerifericoSelect" runat="server" onclick="periphSelect()"  CssClass="table table-striped table-bordered" OnPreRender="gridPerifericoSelect_PreRender"></asp:GridView>
          <script type="text/javascript">
              $(document).ready(function () {
                  $('#MainContent_gridPerifericoSelect').DataTable({
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
              })
            </script>
          <div class="row">
              <div class="col-md-2">
                  <label>Periferico seleccionado: </label>
                  <asp:TextBox ID="txtSelectedPeriph" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="col-md-2">
                  <label>Tipo: </label>
                  <asp:TextBox ID="txtTypePeriph" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="col-md-2">
                  <label>ID Interno: </label>
                  <asp:TextBox ID="txtIDInternPeri" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
          <script>
              function periphSelect() {
                  var table = document.getElementById("MainContent_gridPerifericoSelect");
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
                      document.getElementById('MainContent_txtIDInternPeri').value = data[0];
                      document.getElementById('MainContent_txtTypePeriph').value = data[1];
                      document.getElementById('MainContent_txtSelectedPeriph').value = data[2];
                  };
              }
     </script>
      </div>
      <div id="software-tab" class="tab-pane fade">
        <h3>Software Instalado</h3>
        <asp:CheckBoxList ID="cblistInstalledSoftware" runat="server" CssClass="checkbox">
            <asp:ListItem Text="Office" Value="1"></asp:ListItem>
            <asp:ListItem Text="Adobe" Value="2"></asp:ListItem>
            <asp:ListItem Text="Winrar" Value="3"></asp:ListItem>
            <asp:ListItem Text="Ccleaner" Value="4"></asp:ListItem>
            <asp:ListItem Text="Antivirus" Value="5"></asp:ListItem>
            <asp:ListItem Text="Sistema Integrado" Value="6"></asp:ListItem>
            <asp:ListItem Text="DEP" Value="7"></asp:ListItem>
            <asp:ListItem Text="Autocad" Value="8"></asp:ListItem>
            <asp:ListItem Text="Teamviewer" Value="9"></asp:ListItem>
            <asp:ListItem Text="Acceso a ISO" Value="10"></asp:ListItem>
        </asp:CheckBoxList>
      </div>
    </div>
</asp:Content>
