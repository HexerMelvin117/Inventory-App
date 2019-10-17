<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarEquipo.aspx.cs" Inherits="EquiposInvWM.AsignarEquipo" %>

<%@ Register assembly="DevExpress.Web.ASPxScheduler.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="main">
        <h1>Asignacion de Equipo</h1>
        <div class="row">
            <div class="col-md-2">
                <a class="btn btn-default" href="AgregarEmpleado.aspx">Agregar Empleado &raquo;</a>
            </div>
        </div>
        <div class="row">
            <h3>Formulario</h3>
        </div>
        <div class="row">
            <div class="col-md-2">
                <h5>Fecha: </h5>
                <asp:TextBox TextMode="Date" ID="txtDate" runat="server"></asp:TextBox>
            </div>
        </div>
        <div id="mySidenav" class="sidenav">
            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
            <a href="AgregarEmpleado.aspx">Agregar Empleado</a>
            <a href="#">Services</a>
            <a href="#">Clients</a>
            <a href="#">Contact</a>
        </div>
        <span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776; open</span>
        <script>
        function openNav() {
            document.getElementById("mySidenav").style.width = "250px";
            document.getElementById("main").style.marginLeft = "250px";
        }

        function closeNav() {
            document.getElementById("mySidenav").style.width = "0";
            document.getElementById("main").style.marginLeft= "0";
        }
        </script>
    </div>
</asp:Content>
