using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class TodosEquipos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void fillGrid()
        {
            // Llenar GridView de equipos almacenados en la base de datos.
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Equipos
                             orderby m.equi_id descending
                             select m).ToList();

                EquiposGrid.DataSource = query;
                EquiposGrid.DataBind();
            }

        }

        protected void individualSearch(string marca)
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Equipos
                             where m.equi_marca == marca
                             select m).ToList();

                EquiposGrid.DataSource = query;
                EquiposGrid.DataBind();
            }
        }

        protected void idSearch(string idEqui)
        {
            // Busqueda individual
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Equipos
                             where m.equi_id == idEqui
                             select m).ToList();

                EquiposGrid.DataSource = query;
                EquiposGrid.DataBind();
            }
        }

        protected void btMostrar_Click(object sender, EventArgs e)
        {
            /*using (var ctx = new EquiposInvModelContainer1())
            {
                string serialNum = ctx.Equipos
                    .Where(u => u.equi_marca == "DELL")
                    .Select(u => u.equi_modelo)
                    .SingleOrDefault();

                txtPrueba.Text = Convert.ToString(serialNum);
            } */
            string searched = txtBuscar.Text;
            individualSearch(searched);
        }

        protected void EquiposGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Para nombrar las columnas
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "ID";
                e.Row.Cells[1].Text = "Marca";
                e.Row.Cells[2].Text = "Tipo";
                e.Row.Cells[3].Text = "Proveedor";
                e.Row.Cells[4].Text = "Garantia";
                e.Row.Cells[5].Text = "Serie";
                e.Row.Cells[6].Text = "Disco";
                e.Row.Cells[7].Text = "Procesador";
                e.Row.Cells[8].Text = "Ram";
                e.Row.Cells[9].Text = "ghz";
                e.Row.Cells[10].Text = "Modelo";
                e.Row.Cells[11].Text = "Estado";
                e.Row.Cells[12].Text = "Usuario";
                e.Row.Cells[13].Text = "Politica";
            }
        }

        protected void btMostrarTodo_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        protected void btBuscarID_Click(object sender, EventArgs e)
        {
            idSearch(txtIDEqui.Text);
        }

        protected void EquiposGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            fillGrid();
            EquiposGrid.PageIndex = e.NewPageIndex;
            EquiposGrid.DataBind();
        }

        protected void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btEliminar_Click(object sender, EventArgs e)
        {
            string queId = txtEquipoID.Text;
            using (var ctx = new EquiposInvModelContainer())
            {
                ctx.Equipos
                    .Where(u => u.equi_id == queId)
                    .ToList()
                    .ForEach(u => ctx.Equipos.Remove(u));

                ctx.SaveChanges();
            }
            fillGrid();
        }

        // Para forzar que Gridview use <thead> en vez de <tbody>
        protected void EquiposGrid_PreRender(object sender, EventArgs e)
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

        protected void btOpenPopup_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
