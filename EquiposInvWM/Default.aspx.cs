using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btRedAsignarEquipo_Click(object sender, EventArgs e)
        {
            string permission = Request.QueryString["param"];
            Response.Redirect("~/AsignarEquipo.aspx?param=" + permission);
        }
    }
}