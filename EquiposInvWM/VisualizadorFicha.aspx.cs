using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class VisualizadorFicha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        protected void FillGrid()
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.FichaComputo
                             orderby m.ficha_id descending
                             select new
                             {
                                 ID = m.ficha_id,
                                 Usuario_Asignado = m.ficha_emp,
                                 Fecha = m.ficha_fecha,
                                 Cod_Equipo = m.equi_cod,
                                 Serie = m.equi_serie
                             }).ToList();

                FichasGrid.DataSource = query;
                FichasGrid.DataBind();
            }
        }

        protected void FichasGrid_PreRender(object sender, EventArgs e)
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