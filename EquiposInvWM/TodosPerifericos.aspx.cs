using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using Microsoft.Reporting.WebForms;

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
                             select new { 
                                Id = m.per_id,
                                Codigo = (m.per_prefijo + m.per_cod),
                                Tipo = m.per_tipo,
                                Marca = m.per_marca,
                                Serie = m.per_serie,
                                Estado = m.per_estado,
                             }).ToList();

                PerifericosGrid.DataSource = query;
                PerifericosGrid.DataBind();
            }
        }

        protected void PerifericosGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Reports(string ReportType)
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Perifericos
                             select m).ToList();

                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reporting/PerifericosReport.rdlc");

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "PerifericosSet";
                reportDataSource.Value = query;
                localReport.DataSources.Add(reportDataSource);
                string mimeType;
                string encoding;
                string fileNameExtension;

                string reportType = ReportType;

                if (reportType == "Excel")
                {
                    fileNameExtension = "xlsx";
                }
                else if (reportType == "Word")
                {
                    fileNameExtension = "docx";
                }
                else if (reportType == "PDF")
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
                Response.AddHeader("content-disposition", "attachment:filename=perifericos_report." + fileNameExtension);
                Response.BinaryWrite(renderedByte);
                Response.End();
            }
        }

        protected void PerifericosGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
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
            string type = "Excel";
            Reports(type);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
    }
}