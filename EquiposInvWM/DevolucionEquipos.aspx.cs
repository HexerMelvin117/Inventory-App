using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class DevolucionEquipos : System.Web.UI.Page
    {

        protected void FillGridFichas()
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.FichaComputo
                             orderby m.ficha_id descending
                             select new
                             {
                                 ID = m.ficha_id,
                                 Equipo = m.equi_cod,
                                 Usuario_Asignado = m.emp_nom,
                                 Fecha_Creacion = m.ficha_fecha
                             }).ToList();

                gridFichasDevolucion.DataSource = query;
                gridFichasDevolucion.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            FillGridFichas();
        }

        protected void AgregarSinEquipo()
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                
            }
        }

        protected void AgregarConEquipo()
        {
            using (var ctx = new EquiposInvModelContainer())
            {

            }
        }

        protected void CrearDevolucion()
        {
            
        }

        protected void gridFichasDevolucion_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0) || (gv.ShowHeaderWhenEmpty == true))
            {
                //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}