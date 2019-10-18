<%@ Page Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EquiposInvWM.Login" %>

<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <style type="text/css">
	    .login-form {
		    width: 340px !important;
    	    margin: 50px auto !important;
	    }
        .login-form form {
    	    margin-bottom: 15px !important;
            background: #f7f7f7 !important;
            box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3) !important;
            padding: 30px !important;
        }
        .login-form h2 {
            margin: 0 0 15px !important;
        }
        .form-control, .btn {
            min-height: 38px !important;
            border-radius: 2px !important;
        }
        .btn {        
            font-size: 15px !important;
            font-weight: bold !important;
            border-radius: 3px !important;
        }
    </style>
    <!-- Formulario de inicio de sesion -->
    <div class="login-form">
        <h2 class="text-center">Ingresar</h2>  
        <div class="form-group">
            <input type="text" id="Usuario" class="form-control" placeholder="Usuario" required="required">
        </div>
        <div class="form-group"> 
            <input type="password" id="Contrasena" onkeyup="passToHidden()" class="form-control" placeholder="Contraseña" required="required">
        </div>
        <div class="form-group">
            <asp:Button ID="btLogin" runat="server" CssClass="btn btn-primary btn-block" Text="Log in" OnClick="btLogin_Click" />
        </div>
        <div class="clearfix">
            <label class="pull-left checkbox-inline"><input type="checkbox">Recordarme</label>
            <a href="#" class="pull-right">Olvido su contraseña?</a>
        </div>
        <asp:HiddenField id="txtUser" value="" runat="server" />
        <asp:HiddenField ID="txtPass" Value="" runat="server" />
    </div>
    <!-- Script para pasar valores al controlador oculto -->
    <script type="text/javascript">
        function passToHidden() {
            var usuario = document.getElementById('Usuario').value;
            var contrasena = document.getElementById('Contrasena').value;

            document.getElementById('ContentPlaceHolder1_txtUser').value = usuario;
            document.getElementById('ContentPlaceHolder1_txtPass').value = contrasena;

            var user = document.getElementById('ContentPlaceHolder1_txtUser').value
            var password = document.getElementById('ContentPlaceHolder1_txtPass').value

            console.log(user);
            console.log(password);
        }
    </script>
</asp:Content> 
