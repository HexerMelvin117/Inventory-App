﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class AgregarPeriferico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void agregarPeriferico(string prefijo, int cod)
        {
            string tipo, marca, serie, estado;

            tipo = cmbTipoPeriferico.SelectedItem.Value;
            marca = txtMarcaPeriferico.Text;
            serie = txtSeriePeriferico.Text;
            estado = cmbEstadoPeriferico.SelectedItem.Value;

            try
            {
                using (var ctx = new EquiposInvModelContainer())
                {
                    var per = new Perifericos()
                    {
                        per_prefijo = prefijo,
                        per_cod = cod,
                        per_estado = estado,
                        per_serie = serie,
                        per_marca = marca,
                        per_tipo = tipo
                    };
                    ctx.Perifericos.Add(per);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "')</script>");
            } 
        }

        protected void emptyFields()
        {
            txtIdPeriferico.Text = "";
            txtMarcaPeriferico.Text = "";
            txtSeriePeriferico.Text = "";
        }

        protected void btAgregarPeriferico_Click(object sender, EventArgs e)
        {
            string prefijo = "";
            int cod = int.Parse(txtIdPeriferico.Text);

            if (cmbCompPer.SelectedItem.Text == "William y Molina")
            {
                prefijo = "WMP";
            }
            else if(cmbCompPer.SelectedItem.Text == "Duracreto")
            {
                prefijo = "DCP";
            }
            else if (cmbCompPer.SelectedItem.Text == "Grupo Platino")
            {
                prefijo = "PLAP";
            }
            else if (cmbCompPer.SelectedItem.Text == "Siglo 21")
            {
                prefijo = "SIP";
            }
            else if (cmbCompPer.SelectedItem.Text == "Invalle")
            {
                prefijo = "INVP";
            }
            else if (cmbCompPer.SelectedItem.Text == "Duracreto Santos")
            {
                prefijo = "DCSP";
            }

            if (cmbTipoPeriferico.SelectedItem.Text == "Cargador")
            {
                prefijo = prefijo + "CAR";
            }
            else if(cmbTipoPeriferico.SelectedItem.Text == "Bateria")
            {
                prefijo = prefijo + "BAT";
            }
            else if (cmbTipoPeriferico.SelectedItem.Text == "Mouse")
            {
                prefijo = prefijo + "MOU";
            }
            else if (cmbTipoPeriferico.SelectedItem.Text == "Maletin")
            {
                prefijo = prefijo + "MAL";
            }
            else if (cmbTipoPeriferico.SelectedItem.Text == "Monitor")
            {
                prefijo = prefijo + "MON";
            }
            else if (cmbTipoPeriferico.SelectedItem.Text == "Teclado")
            {
                prefijo = prefijo + "TEC";
            }
            else if (cmbTipoPeriferico.SelectedItem.Text == "Otro")
            {
                prefijo = prefijo + "OTR";
            }

            agregarPeriferico(prefijo, cod);
            emptyFields();
        }
    }
}