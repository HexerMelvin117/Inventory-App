<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarPeriferico.aspx.cs" Inherits="EquiposInvWM.AgregarPeriferico" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="TodosPerifericos.aspx">Todos los Perifericos</a></li>
        <li class="breadcrumb-item active" aria-current="page">Agregar Periferico</li>
      </ol>
    </nav>
    <h1>Agregar Periferico</h1>
    <!-- Seccion para informacion -->
    <div class="row">
        <div class="col-md-2">
            <h5>Compañia:</h5>
            <asp:DropDownList ID="cmbCompPer" CssClass="form-control" runat="server">
                <asp:ListItem>William y Molina</asp:ListItem>
                <asp:ListItem>Duracreto</asp:ListItem>
                <asp:ListItem>Grupo Platino</asp:ListItem>
                <asp:ListItem>Siglo 21</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <h5>Tipo: </h5>
            <asp:DropDownList ID="cmbTipoPeriferico" CssClass="form-control" runat="server">
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
            <h5>ID: </h5>
            <asp:TextBox ID="txtIdPeriferico" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        
    </div>
    <h3>Marca, Modelo y Estado</h3>
    <div class="row">
        <div class="col-md-2">
            <h5>Marca:</h5>
            <asp:TextBox ID="txtMarcaPeriferico" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Estado:</h5>
            <asp:DropDownList ID="cmbEstadoPeriferico" CssClass="form-control" runat="server">
                <asp:ListItem>-- Seleccionar --</asp:ListItem>
                <asp:ListItem>Nuevo</asp:ListItem>
                <asp:ListItem>Usado</asp:ListItem>
                <asp:ListItem>Dañado</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <h5>Serie:</h5>
            <asp:TextBox ID="txtSeriePeriferico" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-6">
            <h5>Observacion: </h5>
            <asp:TextBox ID="txtAreaPeri" TextMode="MultiLine" CssClass="form-control rounded-0" runat="server" Columns="100" Rows="5"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            <asp:Button ID="btAgregarPeriferico" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btAgregarPeriferico_Click" />
        </div>
    </div>
</asp:Content>
