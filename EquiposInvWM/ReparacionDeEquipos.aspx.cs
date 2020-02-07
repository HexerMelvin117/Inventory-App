using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class ReparacionDeEquipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGridReparaciones();
        }

        protected void Unnamed_PreRender(object sender, EventArgs e)
        {

        }

        protected void Unnamed_PreRender1(object sender, EventArgs e)
        {

        }

        protected void FillGridReparaciones()
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Reparacion
                             orderby m.repa_id descending
                             select new
                             {
                                 ID = m.repa_id,
                                 Factura = m.repa_numfactura,
                                 Proveedor = m.repa_proveedor,
                                 Tipo_Reparacion = m.repa_tipo,
                                 Fecha_Reparacion = m.repa_fecha,
                                 Observacion = m.repa_observacion
                             }).ToList();

                gridHistoricoRepa.DataSource = query;
                gridHistoricoRepa.DataBind();
            }
        }

        protected void gridHistoricoRepa_PreRender(object sender, EventArgs e)
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