using System;
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

        protected void agregarPeriferico()
        {
            string tipo, marca, Id, serie, estado;

            tipo = cmbTipoPeriferico.SelectedItem.Value;
            marca = txtMarcaPeriferico.Text;
            serie = txtSeriePeriferico.Text;
            Id = txtIdPeriferico.Text;
            estado = cmbEstadoPeriferico.SelectedItem.Value;

            using(var ctx = new EquiposInvModelContainer())
            {
                var per = new Periferico()
                {
                    per_id = Id,
                    per_estado = estado,
                    per_serie = serie,
                    per_marca = marca,
                    per_tipo = tipo
                };
                ctx.Perifericos.Add(per);
                ctx.SaveChanges();
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
            agregarPeriferico();
            emptyFields();
        }
    }
}