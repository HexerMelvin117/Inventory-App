﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EquiposInvWM._Default" %>

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
                <asp:Button CssClass="btn btn-default" ID="btRedAsignarEquipo" Text="Asignar &raquo;" runat="server" OnClick="btRedAsignarEquipo_Click" />
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
            <h2>Fichas y Devoluciones</h2>
            <p>
                Control de fichas de equipo de computo y devoluciones.
            </p>
            <p>
                <a class="btn btn-default" href="ControlDeFichas.aspx">Fichas y Devoluciones &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Graficos</h2>
            <p>
                Visualizar graficos de equipos de Computo.
            </p>
            <p>
                <a class="btn btn-default" href="GraficosEquipos.aspx">Graficos &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Reparaciones de Equipo</h2>
            <p>
                Historico de reparaciones de equipo.
            </p>
            <p>
                <a class="btn btn-default" href="ReparacionDeEquipos.aspx">Reparaciones &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
