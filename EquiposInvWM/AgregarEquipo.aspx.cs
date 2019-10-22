using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class AgregarEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int randomId()
        {
            Random randomNumber = new Random();
            return randomNumber.Next(0, 5000);
        }


        protected void addRegistry(string marca, string tipo)
        {
            string procesador, modelo, serie, ram, ordenCompra, disco, proveedor, compGHZ;

            procesador = cmbProcessor.SelectedItem.Text;
            modelo = txtModel.Text;
            serie = txtSerie.Text;
            ram = txtRAM.Text;
            ordenCompra = txtBuyOrder.Text;
            disco = txtDiskSpace.Text;
            proveedor = txtProvider.Text;
            compGHZ = txtGHZ.Text;

            using (var ctx = new EquiposInvModelContainer())
            {
                var equ = new Equipos()
                {
                    equi_id = randomId().ToString(),
                    equi_tipo = tipo,
                    equi_disco = int.Parse(disco),
                    equi_ghz = decimal.Parse(compGHZ),
                    equi_modelo = modelo,
                    equi_procesador = procesador,
                    equi_politica = true,
                    equi_proveedor = proveedor,
                    equi_ram = int.Parse(ram),
                    equi_serie = serie,
                    equi_status = "STOCK",
                    equi_marca = marca,
                };
                ctx.Equipos.Add(equ);
                ctx.SaveChanges();
            }

        }

        protected void emptyFields()
        {
            txtBuyOrder.Text = "";
            txtDiskSpace.Text = "";
            txtGHZ.Text = "";
            txtModel.Text = "";
            txtProvider.Text = "";
            txtRAM.Text = "";
            txtSerie.Text = "";
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string tipo;
            string marca;
            if (cmbTipo.SelectedItem.Text == "Computadora")
            {
                tipo = cmbTipoCompu.SelectedItem.Text;
                marca = cmbMarca.SelectedItem.Text;
            }
            else
            {
                tipo = cmbTipo.SelectedItem.Text;
                marca = cmbBrandOthers.SelectedItem.Text;
            }

            addRegistry(marca, tipo);
            emptyFields();
        }

        protected void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem.Text == "Computadora")
            {
                cmbTipoCompu.Enabled = true;
            }
            else
            {
                cmbTipoCompu.Enabled = false;
            }
        }
    }
}