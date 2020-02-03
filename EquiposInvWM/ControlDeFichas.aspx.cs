using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class DevolucionDeEquipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGridFichas();
            FillGridDevoluciones();
        }

        protected void FillGridFichas()
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.FichaComputo
                             orderby m.ficha_id descending
                             select new
                             {
                                 Ficha_id = m.ficha_id,
                                 Fecha = m.ficha_fecha,
                                 Equipo = m.equi_cod,
                                 Marca = m.equi_marca,
                                 Usuario_Asignado = m.emp_nom
                             }).ToList();

                gridDevolucionFicha.DataSource = query;
                gridDevolucionFicha.DataBind();
            }
        }

        protected void FillGridDevoluciones()
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Devoluciones
                             orderby m.devo_id descending
                             select new
                             {
                                 Devolucion_id = m.devo_id,
                                 Fecha_Creacion = m.devo_fecha,
                                 Ficha_Asociada = m.ficha_id,
                                 Codigo_Equipo = m.equi_cod
                             }).ToList();

                gridDevoluciones.DataSource = query;
                gridDevoluciones.DataBind();
            }
        }

        // Para usar <thead> envez de <tbody>
        protected void gridDevolucionFicha_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0) || (gv.ShowHeaderWhenEmpty == true))
            {
                // Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                // Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        // Para usar <thead> envez de <tbody>
        protected void gridPerifericosAsoc_PreRender(object sender, EventArgs e)
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

        protected void BuscarPeriph(int fichaId)
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.ListaPerifericos
                             orderby m.ficha_id descending
                             where m.ficha_id == fichaId
                             select new
                             {
                                 Codigo_Per = m.per_cod,
                                 Tipo_Per = m.per_tipo,
                                 Marca_Per = m.per_marca,
                                 Estado = m.per_estado,
                                 Ficha_ID = m.ficha_id,
                             }).ToList();

                gridPerifericosAsoc.DataSource = query;
                gridPerifericosAsoc.DataBind();
            }
        }

        protected void btSearchPeriphAsoc_Click(object sender, EventArgs e)
        {
            int fichaId = int.Parse(txtidFichaPeri.Text);
            BuscarPeriph(fichaId);
        }

        protected void gridDevoluciones_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0) || (gv.ShowHeaderWhenEmpty == true))
            {
                // Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                // Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}