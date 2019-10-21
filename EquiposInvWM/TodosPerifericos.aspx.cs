using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class TodosPerifericos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        protected void fillGrid()
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Perifericos
                             orderby m.per_id descending
                             select m).ToList();

                PerifericosGrid.DataSource = query;
                PerifericosGrid.DataBind();
            }
        }

        protected void PerifericosGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void PerifericosGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "ID";
                e.Row.Cells[1].Text = "Tipo";
                e.Row.Cells[2].Text = "Marca";
                e.Row.Cells[3].Text = "Estado";
                e.Row.Cells[4].Text = "Serie";
            }
        }

        protected void PerifericosGrid_PreRender(object sender, EventArgs e)
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