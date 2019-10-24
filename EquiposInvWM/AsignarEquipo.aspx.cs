using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class AsignarEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fillGridEquipos();
            fillGridEmp();
        }

        protected void fillGridEmp()
        {
            using(var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Empleados
                             orderby m.emp_id descending
                             select new
                             {
                                 Id = m.emp_id,
                                 Nombre = m.emp_pnom,
                                 Apellido = m.emp_pape
                             }).ToList();

                SelectEmpGrid.DataSource = query;
                SelectEmpGrid.DataBind();
            }
        }

        protected void fillGridEquipos()
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Equipos
                             orderby m.equi_id descending
                             select new { 
                                Id = m.equi_id,
                                Marca = m.equi_marca,
                                Serie = m.equi_serie
                             }).ToList();

                SelecEquipoGrid.DataSource = query;
                SelecEquipoGrid.DataBind();

            }
        }

        // Para forzar que Gridview SelectEquipoGrid use <thead> en vez de <tbody>
        protected void SelecEquipoGrid_PreRender(object sender, EventArgs e)
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

        protected void SelectEmpGrid_PreRender(object sender, EventArgs e)
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