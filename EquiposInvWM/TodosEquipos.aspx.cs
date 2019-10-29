using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace EquiposInvWM
{
    public partial class TodosEquipos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        protected void Reports(string ReportType)
        {
            using(var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Equipos
                             select m).ToList();

                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reporting/EquiposReport.rdlc");

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "Equipos";
                reportDataSource.Value = query;
                localReport.DataSources.Add(reportDataSource);
                string mimeType;
                string encoding;
                string fileNameExtension;

                string reportType = ReportType;

                if(reportType == "Excel")
                {
                    fileNameExtension = "xlsx";
                }
                else if(reportType == "Word")
                {
                    fileNameExtension = "docx";
                }
                else if(reportType == "PDF")
                {
                    fileNameExtension = "pdf";
                }
                else
                {
                    fileNameExtension = "jpg";
                }

                string[] streams;
                Warning[] warnings;
                byte[] renderedByte;
                renderedByte = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension,
                    out streams, out warnings);

                Response.Clear(); // we're going to override the default page response
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment:filename=equipo_report." + fileNameExtension);
                Response.BinaryWrite(renderedByte);
                Response.End();
            }
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
                             where m.equi_id == int.Parse(idEqui)
                             select m).ToList();

                EquiposGrid.DataSource = query;
                EquiposGrid.DataBind();
            }
        }

        protected void btMostrar_Click(object sender, EventArgs e)
        {
            string searched = txtBuscar.Text;
            individualSearch(searched);
        }

        protected void EquiposGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Para nombrar las columnas
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "ID";
                e.Row.Cells[1].Text = "Prefijo";
                e.Row.Cells[2].Text = "Identificador";
                e.Row.Cells[3].Text = "Marca";
                e.Row.Cells[4].Text = "Tipo";
                e.Row.Cells[5].Text = "Proveedor";
                e.Row.Cells[6].Text = "Garantia";
                e.Row.Cells[7].Text = "Serie";
                e.Row.Cells[8].Text = "Disco";
                e.Row.Cells[9].Text = "Procesador";
                e.Row.Cells[10].Text = "Ram";
                e.Row.Cells[11].Text = "ghz";
                e.Row.Cells[12].Text = "Modelo";
                e.Row.Cells[13].Text = "Estado";
                e.Row.Cells[14].Text = "Usuario";
                e.Row.Cells[15].Text = "Politica";
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
                    .Where(u => u.equi_id == int.Parse(queId))
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

        protected void btExportarExcel_Click(object sender, EventArgs e)
        {
            /* Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", "Equipos"));
            Response.Charset = "";

            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            EquiposGrid.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());
            Response.End(); */
            string type = "Excel";
            Reports(type);
        }

        public override void VerifyRenderingInServerForm(Control control) { }
    }
}
