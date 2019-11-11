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
            <h2>Perifericos</h2>
            <p>
                Control de perifericos.
            </p>
            <p>
                <a class="btn btn-default" href="TodosPerifericos.aspx">Perifericos &raquo;</a>
            </p>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Devoluciones</h2>
            <p>
                Devolucion de Equipos de Computo.
            </p>
            <p>
                <a class="btn btn-default" href="DevolucionDeEquipos.aspx">Devoluciones &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Graficos</h2>
            <p>
                Visualizar graficos de equipos de Computo.
            </p>
            <p>
                <a class="btn btn-default" href="Graficos.aspx">Graficos &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
