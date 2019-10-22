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
                <script>
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
                <asp:TextBox ID="txtOperatingSystem" runat="server" CssClass="form-control"></asp:TextBox>
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
    <div class="modal-dialog">
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
              <h4 class="modal-title">Seleccionar Empleado</h4>
            </div>
            <div class="modal-body">
              <asp:DropDownList ID="cmbCodEmpAsig" CssClass="form-control" runat="server">
                  <asp:ListItem>-- Seleccionar --</asp:ListItem>
                  <asp:ListItem></asp:ListItem>
              </asp:DropDownList>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
          </div>
        </div>
    </div>

    <!-- Modal para Equipo -->
  <div class="modal fade" id="modalEquipo" role="dialog">
    <div class="modal-dialog">
    
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
              <h4 class="modal-title">Seleccionar Equipo</h4>
            </div>
            <div class="modal-body">
              
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
          </div>
        </div>
    </div>
</asp:Content>
