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
    <div class="login-form">
            <h2 class="text-center">Ingresar</h2>       
            <div class="form-group">
                <input type="text" class="form-control" placeholder="Usuario" required="required">
            </div>
            <div class="form-group"> 
                <input type="password" class="form-control" placeholder="Contraseña" required="required">
            </div>
            <div class="form-group">
                <asp:Button ID="btLogin" runat="server" CssClass="btn btn-primary btn-block" Text="Log in" />
            </div>
            <div class="clearfix">
                <label class="pull-left checkbox-inline"><input type="checkbox"> Recordarme</label>
                <a href="#" class="pull-right">Olvido su contraseña?</a>
            </div>        
    </div>
</asp:Content> 
