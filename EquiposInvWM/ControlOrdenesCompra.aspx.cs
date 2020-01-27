using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class ControlOrdenesCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FillGridOrdenesCompra()
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.OrdenCompra
                             orderby m.orden_id descending
                             select new
                             {
                                 ID = m.orden_id,
                                 Tipo = m.orden_tipo,
                                 Descripcion = m.orden_desc,
                                 Fecha = m.orden_fecha,
                                 Num_Factura = m.orden_numfactura,
                                 Proveedor = m.orden_proveedor,
                                 Garantia = m.orden_garantia,
                                 Proyecto = m.orden_proy
                             }).ToList();

                gridOrdenesCompra.DataSource = query;
                gridOrdenesCompra.DataBind();
            }
        }

        protected void gridOrdenesCompra_PreRender(object sender, EventArgs e)
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