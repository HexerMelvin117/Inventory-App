using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EquiposInvWM
{
    public partial class GraficosEquipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarEquiposPorComp();
            }
        }

        protected void MostrarEquiposPorComp()
        {
            string myConnection = ConfigurationManager.ConnectionStrings["EquiposInventarioConnectionString"].ToString();
            SqlConnection con = new SqlConnection();

        }
    }
}