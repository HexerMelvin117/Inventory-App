using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class AgregarReparacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGridEquipos();
        }

        protected void FillGridEquipos()
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Equipos
                             orderby m.equi_id descending
                             select new
                             {
                                 Id = m.equi_id,
                                 Marca = m.equi_marca,
                                 Serie = m.equi_serie,
                                 Codigo = (m.equi_prefijo + m.equi_cod)
                             }).ToList();

                gridSelecEquipo.DataSource = query;
                gridSelecEquipo.DataBind();
            }
        }

        protected void gridSelecEquipo_PreRender(object sender, EventArgs e)
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

        protected void btSelecEqui_Click(object sender, EventArgs e)
        {

        }

        protected void AgregarOrdenReparacion()
        {
            string fecha, observacion, tipoReparacion, proveedor, numFactura, codEqui;
            int correlativoEqui;

            correlativoEqui = int.Parse(txtEquipoSelec.Text);
            fecha = txtDate.Text;
            observacion = txtObservacionArea.Text;
            tipoReparacion = cmbTypeRepa.SelectedItem.Text;
            proveedor = txtRepaProveedor.Text;
            numFactura = txtNumFactura.Text;
            codEqui = txtEquiCod.Text;

            using (var ctx = new EquiposInvModelContainer())
            {
                try
                {
                    var reparacion = new Reparacion()
                    {
                        equi_id = correlativoEqui,
                        repa_observacion = observacion,
                        repa_tipo = tipoReparacion,
                        repa_fecha = DateTime.Parse(fecha),
                        repa_proveedor = proveedor,
                        repa_numfactura = numFactura,
                        equi_cod = codEqui
                    };

                    ctx.Reparacion.Add(reparacion);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error al subir reparacion a la base de datos: " + ex.Message + "')</script>");
                }
            }
        }

        protected void btCrearRepa_Click(object sender, EventArgs e)
        {
            AgregarOrdenReparacion();
        }
    }
}