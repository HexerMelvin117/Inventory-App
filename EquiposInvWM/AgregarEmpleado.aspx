<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEmpleado.aspx.cs" Inherits="EquiposInvWM.AgregarEmpleado" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="AsignarEquipo.aspx">Asignacion de Equipo</a></li>
        <li class="breadcrumb-item active" aria-current="page">Agregar Empleado</li>
      </ol>
    </nav>
    <h1>Agregar Empleado</h1>
    <div class="row">
        <div class="col-md-2">
            <h5>Nombre:</h5>
            <asp:TextBox ID="txtNomEmp" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Apellido: </h5>
            <asp:TextBox ID="txtPape" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>ID Emp:</h5>
            <asp:TextBox ID="txtIdEmp" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Correo del Empleado:</h5>
            <asp:TextBox ID="txtCorreoEmp" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <h5>Compañia:</h5>
            <asp:DropDownList ID="cmbCompEmp" CssClass="form-control inputstl" runat="server">
                <asp:ListItem>-- Seleccionar --</asp:ListItem>
                <asp:ListItem>WM</asp:ListItem>
                <asp:ListItem>DC</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            <asp:Button ID="btAgregarEmp" CssClass="btn btn-primary" Text="Agregar" runat="server" OnClick="btAgregarEmp_Click" />
        </div>
    </div>
</asp:Content>
