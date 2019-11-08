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

        // Para generar archivo de excel con todos los equipos en la base de datos
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

        // Para modificar registro en la BD
        protected void ModifyRow()
        {
            string empleado, empresa, marca, tipo, processor, ordenCompra;
            marca = cmbMarca.SelectedItem.Text;
            empleado = txtEmpleado.Text;
            empresa = cmbEmpresaCod.SelectedItem.Text;
            tipo = cmbTipo.SelectedItem.Text;
            processor = cmbProcessor.SelectedItem.Text;
            ordenCompra = txtOrdenCompra.Text;

            decimal ghz = decimal.Parse(txtGhz.Text);

            int ram = int.Parse(txtRam.Text);
            int disk = int.Parse(txtDisk.Text);
            int id = int.Parse(txtEquipoID.Text);
            using (var ctx = new EquiposInvModelContainer())
            {
                try
                {
                    var result = ctx.Equipos.SingleOrDefault(m => m.equi_id == id);
                    if (result != null)
                    {
                        result.equi_tipo = tipo;
                        result.equi_disco = disk;
                        result.emp_nom = empleado;
                        result.equi_empresa = empresa;
                        result.equi_marca = marca;
                        result.equi_procesador = processor;
                        result.equi_ordencompra = ordenCompra;
                        result.equi_ghz = ghz;
                        result.equi_ram = ram;
                        

                        ctx.Equipos.Add(result);
                        ctx.Equipos.Attach(result);
                        ctx.Entry(result).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                
            }
        }

        protected void fillGrid()
        {
            // Llenar GridView de equipos almacenados en la base de datos.
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Equipos
                             orderby m.equi_id descending
                             select new
                             {
                                 Id = m.equi_id,
                                 Codigo = (m.equi_prefijo + m.equi_cod),
                                 Usuario_Asignado = m.emp_nom,
                                 Tipo = m.equi_tipo,
                                 Marca = m.equi_marca,
                                 Procesador = m.equi_procesador,
                                 GHZ = m.equi_ghz,
                                 RAM = m.equi_ram,
                                 Disco = m.equi_disco,
                                 Serie = m.equi_serie,
                                 Garantia = m.equi_garantia,
                                 Proveedor = m.equi_proveedor,
                                 Orden_Compra = m.equi_ordencompra,
                                 Precio = m.equi_precio,
                                 Empresa = m.equi_empresa,
                                 Proyecto = m.equi_proyecto,
                                 Departamento = m.equi_dpto,
                                 Estado = m.equi_status
                             }).ToList();

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
            
           
        }

        protected void EquiposGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Para nombrar las columnas
            
        }

        protected void btMostrarTodo_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        protected void btBuscarID_Click(object sender, EventArgs e)
        {
            
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
            int queId = int.Parse(txtEliminarID.Text);

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

        protected void btExportarExcel_Click(object sender, EventArgs e)
        {
            string type = "Excel";
            Reports(type);
        }

        public override void VerifyRenderingInServerForm(Control control) { }

        protected void btModify_Click(object sender, EventArgs e)
        {
            ModifyRow();
        }
    }
}
