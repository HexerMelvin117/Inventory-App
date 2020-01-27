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

            garantiaFin = DateTime.Parse(txtGarantiaFecha.Text);
            fechaEmitida = DateTime.Parse(txtFechaFacturacion.Text);
        }
    }
}