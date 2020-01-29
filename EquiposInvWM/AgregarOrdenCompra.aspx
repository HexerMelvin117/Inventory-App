<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarOrdenCompra.aspx.cs" Inherits="EquiposInvWM.AgregarOrdenCompra" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Script y Hoja de estilo para escogedor de fecha -->
    <link rel="stylesheet" href="Content/foopicker.css" />
    <script type="text/javascript" src="Scripts/foopicker.js"></script>

    <br />
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="ControlOrdenesCompra.aspx">Control Orden de Compra</a></li>
        <li class="breadcrumb-item active" aria-current="page">Agregar Orden de Compra</li>
      </ol>
    </nav>
    <a class="btn btn-danger" href="ControlOrdenesCompra.aspx">Volver &raquo;</a>
    <br />
    <h1>Agregar Orden de Compra</h1>

    <!-- Detalles de Orden de Compra -->
    <h3>Informacion General de Factura</h3>
    <div class="row">
        <div class="col-md-2">
            <h5>Proveedor</h5>
            <asp:DropDownList ID="cmbProvider" CssClass="form-control" runat="server">
                <asp:ListItem>-- Seleccionar --</asp:ListItem>
                <asp:ListItem>Acosa</asp:ListItem>
                <asp:ListItem>Sycom</asp:ListItem>
                <asp:ListItem>Sytek</asp:ListItem>
                <asp:ListItem>Tecnocomp</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <h5>Numero de Factura</h5>
            <asp:TextBox ID="txtNumFactura" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Precio</h5>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2">
            <h5>Fecha Facturacion</h5>
            <asp:TextBox ID="txtFechaFacturacion" CssClass="form-control" placeholder="Fecha" runat="server"></asp:TextBox>
            <script type="text/javascript">
                var foopicker = new FooPicker({
                    id: 'MainContent_txtFechaFacturacion',
                    dateFormat: 'dd/MM/yyyy',
                    disable: ['29/07/2017', '30/07/2017', '31/07/2017', '01/08/2017']
                });
            </script>
            <div id="foopicker-datepicker" style="position: fixed; top: 58px; left: 8px; z-index: 99999;"></div>
        </div>
        <div class="col-md-2">
            <h5>Garantia</h5>
            <asp:TextBox ID="txtGarantiaFecha" CssClass="form-control" placeholder="Fecha" runat="server"></asp:TextBox>
            <script type="text/javascript">
                var foopicker = new FooPicker({
                    id: 'MainContent_txtGarantiaFecha',
                    dateFormat: 'dd/MM/yyyy',
                    disable: ['29/07/2017', '30/07/2017', '31/07/2017', '01/08/2017']
                });
            </script>
            <div id="foopicker-datepicker" style="position: fixed; top: 58px; left: 8px; z-index: 99999;"></div>
            <asp:CheckBox ID="chBoxGarantia" runat="server" Text="Sin Garantia" onclick="document.getElementById('MainContent_txtGarantiaFecha').disabled=this.checked;" />
        </div>
    </div>

    <h3>Informacion del Equipo Comprado</h3>
    <div class="row">
        <div class="col-md-2">
            <h5>Tipo</h5>
            <asp:DropDownList ID="cmbTypeSelect" runat="server" CssClass="form-control">
                <asp:ListItem>-- Seleccionar --</asp:ListItem>
                <asp:ListItem>Periferico</asp:ListItem>
                <asp:ListItem>Equipo de Computo</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <h5>Tipo Equipo Computo</h5>
            <asp:DropDownList ID="cmbTypeEquipoComputo" runat="server" CssClass="form-control">
                <asp:ListItem>-- Seleccionar --</asp:ListItem>
                <asp:ListItem>Computadora</asp:ListItem>
                <asp:ListItem>Impresora</asp:ListItem>
                <asp:ListItem>Reloj Biometrico</asp:ListItem>
                <asp:ListItem>Camara</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <h5>Tipo Periferico</h5>
            <asp:DropDownList ID="cmbTypePeri" runat="server" CssClass="form-control">
                <asp:ListItem>-- Seleccionar --</asp:ListItem>
                <asp:ListItem>Bateria</asp:ListItem>
                <asp:ListItem>Cargador</asp:ListItem>
                <asp:ListItem>Mouse</asp:ListItem>
                <asp:ListItem>Maletin</asp:ListItem>
                <asp:ListItem>Otro</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2">
            <h5>Proyecto:</h5>
            <asp:TextBox ID="txtPyto" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h5>Descripcion:</h5>
            <asp:TextBox ID="txtDescripcionArea" TextMode="MultiLine" CssClass="form-control rounded-0" runat="server" Columns="100" Rows="5"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            <asp:Button ID="btAgregarOrdenCompra" runat="server" CssClass="btn btn-primary" Text="Agregar Orden" OnClick="btAgregarOrdenCompra_Click" />
        </div>
    </div>
</asp:Content>
