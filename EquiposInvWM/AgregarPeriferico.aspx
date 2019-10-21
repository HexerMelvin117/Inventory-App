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
            <h5>Tipo: </h5>
            <asp:DropDownList ID="cmbTipoPeriferico" CssClass="btn btn-default btn-sm" runat="server">
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
            <asp:TextBox ID="txtIdPeriferico" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Marca</h5>
            <asp:TextBox ID="txtMarcaPeriferico" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Modelo</h5>
            <asp:TextBox ID="txtModelPeriferico" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Estado</h5>
            <asp:DropDownList ID="cmbEstadoPeriferico" CssClass="btn btn-default btn-sm" runat="server">
                <asp:ListItem>-- Seleccionar --</asp:ListItem>
                <asp:ListItem>Nuevo</asp:ListItem>
                <asp:ListItem>Usado</asp:ListItem>
                <asp:ListItem>Dañado</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
</asp:Content>
