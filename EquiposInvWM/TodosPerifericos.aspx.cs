using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

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
                e.Row.Cells[1].Text = "Prefijo";
                e.Row.Cells[2].Text = "Codigo";
                e.Row.Cells[3].Text = "Tipo";
                e.Row.Cells[4].Text = "Marca";
                e.Row.Cells[5].Text = "Estado";
                e.Row.Cells[6].Text = "Serie";
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

        protected void btExportExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", "Perifericos"));
            Response.Charset = "";

            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            PerifericosGrid.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
    }
}