using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btVolverInicion_Click(object sender, EventArgs e)
        {
            string permisos = Request.QueryString["param"];
            Response.Redirect("~/Default.aspx?param=" + permisos);
        }
    }
}