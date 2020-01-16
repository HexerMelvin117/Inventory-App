<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graficos.aspx.cs" Inherits="EquiposInvWM.Graficos" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Graficos</h1>
    <dx:bootstrappiechart runat="server" TitleSettings-Text="Equipos de Computo por Compañia"></dx:bootstrappiechart>
</asp:Content>

