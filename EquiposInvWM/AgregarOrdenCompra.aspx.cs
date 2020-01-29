using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class AgregarOrdenCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AgregarOrden()
        {
            string proyecto, descripcion, numFactura, tipo, proveedor;
            decimal precio;
            DateTime garantiaFin, fechaEmitida;

            precio = decimal.Parse(txtPrecio.Text);
            proyecto = txtPyto.Text;
            descripcion = txtDescripcionArea.Text;
            numFactura = txtNumFactura.Text;
            proveedor = cmbProvider.SelectedItem.Text;
            
            if (cmbTypeSelect.SelectedItem.Text == "Periferico")
            {
                tipo = cmbTypePeri.SelectedItem.Text;
            } 
            else
            {
                tipo = cmbTypeEquipoComputo.SelectedItem.Text;
            }

            
            fechaEmitida = DateTime.Parse(txtFechaFacturacion.Text);

            if (chBoxGarantia.Checked == true)
            {
                using (var ctx = new EquiposInvModelContainer())
                {
                    var ordenCompra = new OrdenCompra()
                    {
                        orden_tipo = tipo,
                        orden_fecha = fechaEmitida,
                        orden_desc = descripcion,
                        orden_garantia = null,
                        orden_numfactura = numFactura,
                        orden_precio = precio,
                        orden_proveedor = proveedor,
                        orden_proy = proyecto
                    };

                    ctx.OrdenCompra.Add(ordenCompra);
                    ctx.SaveChanges();
                }
            } 
            else
            {
                garantiaFin = DateTime.Parse(txtGarantiaFecha.Text);
                using (var ctx = new EquiposInvModelContainer())
                {
                    var ordenCompra = new OrdenCompra()
                    {
                        orden_tipo = tipo,
                        orden_fecha = fechaEmitida,
                        orden_desc = descripcion,
                        orden_garantia = garantiaFin,
                        orden_numfactura = numFactura,
                        orden_precio = precio,
                        orden_proveedor = proveedor,
                        orden_proy = proyecto
                    };

                    ctx.OrdenCompra.Add(ordenCompra);
                    ctx.SaveChanges();
                }
            }
            
        }

        protected void btAgregarOrdenCompra_Click(object sender, EventArgs e)
        {
            AgregarOrden();
        }
    }
}