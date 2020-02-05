using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UserLogin(string user, string password)
        {
            try
            {
                // Comparar con base de datos
                using (var ctx = new EquiposInvModelContainer())
                {
                    var query = from u in ctx.Usuarios
                                where u.user_correo == user && u.user_contrasenia == password
                                select u;

                    if (query.Count() > 0)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Usuario o contraseña incorrecta')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Ocurrio un: " + ex.Message + "')</script>");
            }
            
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Value;
            string password = txtPass.Value;

            UserLogin(user, password);
        }
    }
}