using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EquiposInvWM
{
    public partial class AgregarEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public int identificarEquipo(string prefijo)
        {
            int cod;
            using(var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Equipos
                             orderby m.equi_id descending
                             where m.equi_prefijo == prefijo
                             select m).ToList();

                int amountToAssign = query.Count();
                cod = amountToAssign + 1;
                return cod;
            }
        }

        public int randomId()
        {
            Random randomNumber = new Random();
            return randomNumber.Next(0, 5000);
        }

        protected void addRegistry(string marca, string tipo, string prefijo, int cod)
        {
            string procesador, modelo, serie, ram, ordenCompra, disco, proveedor, compGHZ, garantia, observacion;

            decimal precio;

            procesador = cmbProcessor.SelectedItem.Text;
            modelo = txtModel.Text;
            serie = txtSerie.Text;
            ram = txtRAM.Text;
            ordenCompra = txtBuyOrder.Text;
            disco = txtDiskSpace.Text;
            proveedor = txtProvider.Text;
            compGHZ = txtGHZ.Text;
            garantia = txtGarantiaFecha.Text;
            observacion = txtAreaObservacionEqui.Text;
            precio = decimal.Parse(txtPriceTag.Text);

            using (var ctx = new EquiposInvModelContainer())
            {
                var equ = new Equipos()
                {
                    equi_id = randomId(),
                    equi_prefijo = prefijo,
                    equi_cod = cod,
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
                    equi_garantia = DateTime.Parse(garantia),
                    equi_observacion = observacion,
                    equi_precio = precio,
                    equi_ordencompra = ordenCompra,
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
            string prefijo = "";
            int cod;

            if (chboxCodEquipo.Checked == true)
            {
                if (cmbCompaniaEqui.SelectedItem.Text == "William y Molina")
                {
                    prefijo = "WM";
                }
                else if (cmbCompaniaEqui.SelectedItem.Text == "Siglo 21")
                {
                    prefijo = "SI";
                }
                else if (cmbCompaniaEqui.SelectedItem.Text == "Duracreto")
                {
                    prefijo = "DC";
                }
                else if (cmbCompaniaEqui.SelectedItem.Text == "Grupo Platino")
                {
                    prefijo = "PLA";
                }

                if (cmbTipo.SelectedItem.Text == "Computadora")
                {
                    tipo = cmbTipoCompu.SelectedItem.Text;
                    marca = cmbMarca.SelectedItem.Text;

                    if (cmbTipoCompu.SelectedItem.Text == "Laptop")
                    {
                        prefijo = prefijo + "LPT";
                    }
                    else if (cmbTipoCompu.SelectedItem.Text == "Computadora")
                    {
                        prefijo = prefijo + "PC";
                    }
                }
                else
                {
                    tipo = cmbTipo.SelectedItem.Text;
                    marca = cmbBrandOthers.SelectedItem.Text;
                    if (cmbTipo.SelectedItem.Text == "Impresora")
                    {
                        prefijo = prefijo + "IMP";
                    }
                    else if (cmbTipo.SelectedItem.Text == "Reloj Biometrico")
                    {
                        prefijo = prefijo + "RB";
                    }
                    else if (cmbTipo.SelectedItem.Text == "Camara")
                    {
                        prefijo = prefijo + "CM";
                    }
                }

                cod = identificarEquipo(prefijo);

                addRegistry(marca, tipo, prefijo, cod);
                emptyFields();
            } else
            {
                prefijo = txtPrefijoEqui.Text;
                cod = int.Parse(txtCodEquipo.Text);
                tipo = cmbTipo.SelectedItem.Text;
                marca = cmbBrandOthers.SelectedItem.Text;

                addRegistry(marca, tipo, prefijo, cod);
            }
            
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