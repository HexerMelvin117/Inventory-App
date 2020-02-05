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

        public string identificarEquipo(string prefijo)
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
                return cod.ToString();
            }
        }

        
        protected void addRegistry(string marca, string tipo, string prefijo, string cod, string compania)
        {
            string procesador, modelo, serie, ram, ordenCompra, disco, proveedor, compGHZ, observacion, status;
            decimal precio;
            DateTime garantiaFin;

            observacion = txtAreaObservacionEqui.Text;
            precio = decimal.Parse(txtPriceTag.Text);

            procesador = cmbProcessor.SelectedItem.Text;
            modelo = txtModel.Text;
            serie = txtSerie.Text;
            ram = txtRAM.Text;
            ordenCompra = txtBuyOrder.Text;
            disco = txtDiskSpace.Text;
            proveedor = txtProvider.Text;
            compGHZ = txtGHZ.Text;
            status = cmbStateEquip.SelectedItem.Text;

            try
            {
                if (chBoxGarantia.Checked == true)
                {
                    // Cuando no tiene garantia
                    using (var ctx = new EquiposInvModelContainer())
                    {
                        var equ = new Equipos()
                        {
                            equi_prefijo = prefijo,
                            equi_cod = cod,
                            equi_tipo = tipo,
                            equi_disco = disco,
                            equi_ghz = decimal.Parse(compGHZ),
                            equi_modelo = modelo,
                            equi_procesador = procesador,
                            equi_politica = true,
                            equi_proveedor = proveedor,
                            equi_ram = ram,
                            equi_serie = serie,
                            equi_status = status,
                            equi_marca = marca,
                            equi_garantia = null,
                            equi_observacion = observacion,
                            equi_precio = precio,
                            equi_ordencompra = ordenCompra,
                            equi_empresa = compania
                        };

                        ctx.Equipos.Add(equ);
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    // Cuando tiene garantia
                    garantiaFin = DateTime.Parse(txtGarantiaFecha.Text);

                    using (var ctx = new EquiposInvModelContainer())
                    {
                        var equ = new Equipos()
                        {
                            equi_prefijo = prefijo,
                            equi_cod = cod,
                            equi_tipo = tipo,
                            equi_disco = disco,
                            equi_ghz = decimal.Parse(compGHZ),
                            equi_modelo = modelo,
                            equi_procesador = procesador,
                            equi_politica = true,
                            equi_proveedor = proveedor,
                            equi_ram = ram,
                            equi_serie = serie,
                            equi_status = status,
                            equi_marca = marca,
                            equi_garantia = garantiaFin,
                            equi_observacion = observacion,
                            equi_precio = precio,
                            equi_ordencompra = ordenCompra,
                            equi_empresa = compania
                        };

                        ctx.Equipos.Add(equ);
                        ctx.SaveChanges();
                    }
                }
            } 
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "')</script>");
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
            txtAreaObservacionEqui.Text = "";
            txtGarantiaFecha.Text = "";
            txtCodEquipo.Text = "";
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            string tipo;
            string marca;
            string prefijo = "";
            string cod;
            string compania;

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

                compania = null;
                cod = identificarEquipo(prefijo);

                addRegistry(marca, tipo, prefijo, cod, compania);
                emptyFields();
            } else
            {

                prefijo = txtPrefijoEqui.Text;
                cod = txtCodEquipo.Text;
                if (cmbTipo.SelectedItem.Text == "Computadora")
                {
                    tipo = cmbTipoCompu.SelectedItem.Text;
                    marca = cmbMarca.SelectedItem.Text;
                } else
                {
                    tipo = cmbTipo.SelectedItem.Text;
                    marca = cmbBrandOthers.SelectedItem.Text;
                }

                if (cmbCompaniaEqui.SelectedItem.Text == "William y Molina")
                {
                    compania = "WM";
                }
                else if (cmbCompaniaEqui.SelectedItem.Text == "Siglo 21")
                {
                    compania = "SI";
                }
                else if (cmbCompaniaEqui.SelectedItem.Text == "Duracreto")
                {
                    compania = "DC";
                }
                else if (cmbCompaniaEqui.SelectedItem.Text == "Grupo Platino")
                {
                    compania = "PLA";
                } 
                else if (cmbCompaniaEqui.SelectedItem.Text == "Duracreto Santos") {
                    compania = "DCS";
                }
                else if (cmbCompaniaEqui.SelectedItem.Text == "Invalle")
                {
                    compania = "INV";
                }
                else if (cmbCompaniaEqui.SelectedItem.Text == "Altitud")
                {
                    compania = "ALT";
                }
                else
                {
                    compania = null;
                }
                addRegistry(marca, tipo, prefijo, cod, compania);
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