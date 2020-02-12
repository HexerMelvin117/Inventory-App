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

            bool isAdmin = false;
            try
            {
                // Comparar con base de datos
                using (var ctx = new EquiposInvModelContainer())
                {
                    var query = from u in ctx.Usuarios
                                where u.user_correo == user && u.user_contrasenia == password
                                select u;

                    isAdmin = ctx.Usuarios
                        .Where(u => u.user_correo == user)
                        .Select(u => u.user_escritura)
                        .FirstOrDefault();

                    if (query.Count() > 0)
                    {
                        if (isAdmin == true)
                        {
                            Response.Redirect("~/Default.aspx?param=1");
                        }

                        else
                        {
                            Response.Redirect("~/Default.aspx?param=0");
                        }
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