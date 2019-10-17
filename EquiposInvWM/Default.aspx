<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EquiposInvWM._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Bienvenido</h1>
        <p class="lead">Abajo encontrara las opciones para ver y asignar los equipos en el sistema.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Asignar Equipo</h2>
            <p>
                Para poder asignar equipos los empleados.
            </p>
            <p>
                <a class="btn btn-default" href="AsignarEquipo.aspx">Ir a Asignar &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Equipos</h2>
            <p>
                Eliminar, agregar, y mostrar los equipos.
            </p>
            <p>
                <a class="btn btn-default" href="TodosEquipos.aspx">Equipos &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Equipo con Politica</h2>
            <p>
                Ver y administrar equipo con politica.
            </p>
            <p>
                <a class="btn btn-default" href="EquiposPolitica.aspx">Equipos con Politica &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
