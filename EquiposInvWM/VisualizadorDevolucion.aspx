<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisualizadorDevolucion.aspx.cs" Inherits="EquiposInvWM.VisualizadorDevolucion" %>

<%@ Register Assembly="DevExpress.XtraReports.v19.1.Web.WebForms, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Visualizador de Devolucion</h1>
    <div class="row">
        <dx:ASPxWebDocumentViewer ID="DevolucionWebDocumentViewer" runat="server" ReportSourceId="EquiposInvWM.Reporting.DevolucionReport"></dx:ASPxWebDocumentViewer> 
    </div>
</asp:Content>
