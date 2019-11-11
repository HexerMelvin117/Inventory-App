<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEquipo.aspx.cs" Inherits="EquiposInvWM.AgregarEquipo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="Content/foopicker.css" />
    <script type="text/javascript" src="Scripts/foopicker.js"></script>
    <br />
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="TodosEquipos.aspx">Todos los Equipos</a></li>
        <li class="breadcrumb-item active" aria-current="page">Crear Equipo</li>
      </ol>
    </nav>
    <h2><%: Title %>Agregar Equipo</h2>
    <p>

    </p>
    <a class="btn btn-danger" href="TodosEquipos.aspx">Volver &raquo;</a>
    <!-- Informacion de Equipo -->
        <h3>Informacion de Equipo:</h3>     
    <div class="row">
        <div class="col-md-2">
            <h5>Compañia:</h5>
            <asp:DropDownList ID="cmbCompaniaEqui" CssClass="form-control" runat="server">
                <asp:ListItem>William y Molina</asp:ListItem>
                <asp:ListItem>Duracreto</asp:ListItem>
                <asp:ListItem>Transporte Platino</asp:ListItem>
                <asp:ListItem>Siglo 21</asp:ListItem>
                <asp:ListItem>Invalle</asp:ListItem>
                <asp:ListItem>Altitud</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <h5>Tipo de Equipo: </h5>
            <asp:DropDownList ID="cmbTipo" onChange="enableTypeC()" CssClass="form-control" runat="server" OnSelectedIndexChanged="cmbTipo_SelectedIndexChanged">
                <asp:ListItem>-- Seleccionar --</asp:ListItem>
                <asp:ListItem>Computadora</asp:ListItem>
                <asp:ListItem>Impresora</asp:ListItem>
                <asp:ListItem>Reloj Biometrico</asp:ListItem>
                <asp:ListItem>Camara</asp:ListItem>
            </asp:DropDownList>
            <script type="text/javascript">
                function enableTypeC() {
                    var str = document.getElementById("MainContent_cmbTipo");
                    var selec = str.options[str.selectedIndex].value;

                    var c = document.getElementById("MainContent_cmbTipoCompu");
                    var mc = document.getElementById("MainContent_cmbMarca");
                    var marcaOtros = document.getElementById("MainContent_cmbBrandOthers");
                    if (selec === "Computadora") {
                        c.disabled = false;
                        mc.disabled = false;
                        marcaOtros.disabled = true;
                    } else {
                        c.disabled = true;
                        mc.disabled = true;
                        marcaOtros.disabled = false;
                    }  
                }
            </script>
        </div>

        <div class="col-md-2">
            <h5>Tipo de Computadora: </h5>
            <asp:DropDownList ID="cmbTipoCompu" EnableViewState="true" CssClass="form-control" runat="server" Enabled="False">
                <asp:ListItem>-- Seleccionar --</asp:ListItem>
                <asp:ListItem>N/A</asp:ListItem>
                <asp:ListItem>Laptop</asp:ListItem>
                <asp:ListItem>Escritorio</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2">
            <h5>Prefijo: </h5>
            <asp:TextBox ID="txtPrefijoEqui" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:CheckBox ID="chboxCodEquipo" runat="server" CssClass="form-check-input" Text="Generar Codigo Automaticamente" onclick="document.getElementById('MainContent_txtCodEquipo').disabled=this.checked;
                document.getElementById('MainContent_txtPrefijoEqui').disabled=this.checked;"/>
        </div>
        <div class="col-md-2">
            <h5>Codigo: </h5>
            <asp:TextBox ID="txtCodEquipo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Estado: </h5>
            <asp:DropDownList ID="cmbStateEquip" CssClass="form-control" runat="server">
                <asp:ListItem>STOCK</asp:ListItem>
                <asp:ListItem>ACTIVO</asp:ListItem>
                <asp:ListItem>DESACTIVO</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <!-- Informacion de marca, modelo y serie -->
    <h3>Informacion de marca, modelo y serie</h3>
    <div class="row">
        <div class="col-md-2">
            <h5>Marca de Computadora: </h5>
            <asp:DropDownList ID="cmbMarca" CssClass="form-control" runat="server" Enabled="False">
                <asp:ListItem>-- Seleccionar --</asp:ListItem>
                <asp:ListItem>ASUS</asp:ListItem>
                <asp:ListItem>DELL</asp:ListItem>
                <asp:ListItem>HP</asp:ListItem>
                <asp:ListItem>Alienware</asp:ListItem>
                <asp:ListItem>Lenovo</asp:ListItem>
                <asp:ListItem>Toshiba</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <h5>Marca: </h5>
            <asp:DropDownList ID="cmbBrandOthers" CssClass="form-control" runat="server">
                <asp:ListItem>-- Seleccionar --</asp:ListItem>
                <asp:ListItem>N/A</asp:ListItem>
                <asp:ListItem>HIKVISION</asp:ListItem>
                <asp:ListItem>KYOCERA</asp:ListItem>
                <asp:ListItem>EPSON</asp:ListItem>
                <asp:ListItem>TOSHIBA</asp:ListItem>
                <asp:ListItem>HP</asp:ListItem>
                </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <h5>Modelo: </h5>
            <asp:TextBox ID="txtModel" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Serie: </h5>
            <asp:TextBox ID="txtSerie" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        
    </div>
    <br />
    <h3>Especificaciones</h3>

    <!-- Informacion sobre procesador, ram, y espacio de disco -->
    <div class="row">
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
        <div class="col-md-2">
            <h5>ghz: </h5>
            <asp:TextBox ID="txtGHZ"  CssClass="form-control" placeholder="0.0" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Ram: </h5>
            <asp:TextBox ID="txtRAM"  CssClass="form-control" placeholder="0" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Disco: </h5>
            <asp:TextBox ID="txtDiskSpace"  CssClass="form-control" placeholder="0" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <!-- Informacion de compra -->
    <h3>Informacion de Compra</h3>
    <div class="row">
        <div class="col-md-2">
            <h5>Proveedor: </h5>
            <asp:TextBox ID="txtProvider" CssClass="form-control" placeholder="Proveedor" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Orden de Compra: 
            </h5>
            <asp:TextBox ID="txtBuyOrder" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Precio: </h5>
            <asp:TextBox ID="txtPriceTag" CssClass="form-control" placeholder="0.00" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Fin de Garantia: </h5>
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
    <br />
    <div class="row">
        <div class="col-md-6">
            <h5>Observacion: </h5>
            <asp:TextBox ID="txtAreaObservacionEqui" TextMode="MultiLine" placeholder="Observacion del equipo..." CssClass="form-control rounded-0" runat="server" Columns="100" Rows="5"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            <asp:Button ID="btSubmit" class="btn btn-primary" runat="server" Text="Subir a Sistema" OnClientClick="return validateFields();" OnClick="btSubmit_Click" />
        </div>
    </div>
    <script>
        function validateFields() {
            var ghz, disco, ram, garantia, precio, garantiaChecked;
            ram = document.getElementById("MainContent_txtRAM").value;
            disco = document.getElementById("MainContent_txtDiskSpace").value;
            ghz = document.getElementById("MainContent_txtGHZ").value;
            garantia = document.getElementById("MainContent_txtGarantiaFecha").value;
            garantiaChecked = document.getElementById('MainContent_txtGarantiaFecha').disabled;
            precio = document.getElementById("MainContent_txtPriceTag").value;

            if (ghz == '') {
                alert("porfavor introducir valor de ghz");
                return false;
            }
            if (disco == '') {
                alert("porfavor introducir valor de disco");
                return false;
            }
            if (garantia == '') {
                if (garantiaChecked !== true) {
                    alert("porfavor introducir fecha de vencimiento de garantia");
                    return false;
                }
            }
            if (ram == '') {
                alert("porfavor introducir cantidad de RAM");
                return false;
            }
            if (precio == '') {
                alert("porfavor introducir precio");
                return false;
            }
        }
    </script>
</asp:Content>
