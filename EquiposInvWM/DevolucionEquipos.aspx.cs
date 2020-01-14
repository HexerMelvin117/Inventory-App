using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EquiposInvWM
{
    public partial class DevolucionEquipos : System.Web.UI.Page
    {
        // Metodo para agregar contenido a gridview
        protected void FillGridFichas()
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.FichaComputo
                             orderby m.ficha_id descending
                             select new
                             {
                                 ID = m.ficha_id,
                                 Equipo = m.equi_cod,
                                 Usuario_Asignado = m.emp_nom,
                                 Fecha_Creacion = m.ficha_fecha
                             }).ToList();

                gridFichasDevolucion.DataSource = query;
                gridFichasDevolucion.DataBind();
            }
        }

        protected void FillGridPeriph(int fichaSelId)
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.ListaPerifericos
                             orderby m.lisper_id descending
                             where m.ficha_id == fichaSelId
                             select new
                             {
                                 ID = m.per_id,
                                 Codigo = m.per_cod,
                                 Marca = m.per_marca,
                                 Tipo = m.per_tipo,
                                 Estado = m.per_estado
                             }).ToList();

                gridPeriphSelect.DataSource = query;
                gridPeriphSelect.DataBind();
            }
        }

        DataTable dtPerifericosSeleccionados = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (ViewState["Records"] == null)
                {
                    dtPerifericosSeleccionados.Columns.Add("ID Interno");
                    dtPerifericosSeleccionados.Columns.Add("Codigo_Periferico");
                    dtPerifericosSeleccionados.Columns.Add("Tipo");
                    dtPerifericosSeleccionados.Columns.Add("Marca");
                    dtPerifericosSeleccionados.Columns.Add("Estado");
                    ViewState["Records"] = dtPerifericosSeleccionados;
                }
            }

            FillGridFichas();
        }

        protected void AgregarPerifericos(int devoId)
        {
            int idPer;
            string tipoPer, codPer, estadoPer, marcaPer;

            dtPerifericosSeleccionados = (DataTable)ViewState["Records"];

            using (var ctx = new EquiposInvModelContainer())
            {
                foreach(DataRow row in dtPerifericosSeleccionados.Rows)
                {
                    string idTemp = row["ID Interno"].ToString();
                    idPer = int.Parse(idTemp);
                    tipoPer = row["Tipo"].ToString();
                    codPer = row["Codigo_Periferico"].ToString();
                    estadoPer = row["Estado"].ToString();
                    marcaPer = row["Marca"].ToString();

                    var ListaPeriDevo = new ListaPerifericosDevo()
                    {
                        per_id = idPer,
                        devo_id = devoId
                    };

                    ctx.ListaPerifericosDevo.Add(ListaPeriDevo);
                    ctx.SaveChanges();
                }

                
            }
        }

        protected void CrearDevolucion()
        {
            int fichaId = int.Parse(lbFichaID.Text);
            string equiCod = lbEquipoAsignado.Text;

            using (var ctx = new EquiposInvModelContainer())
            {
                try
                {
                    if (chboxIncludeEquipment.Checked == true)
                    {
                        var devolucion = new Devoluciones()
                        {
                            equi_cod = equiCod,
                            ficha_id = fichaId,
                        };
                        ctx.Devoluciones.Add(devolucion);
                        ctx.SaveChanges();

                        int devolucionId = devolucion.devo_id;

                        if (chboxIncludePeriph.Checked == true)
                        {
                            AgregarPerifericos(devolucionId);
                        }
                    } 
                    else
                    {
                        var devolucion = new Devoluciones()
                        {
                            equi_cod = null,
                            ficha_id = fichaId,
                        };
                        ctx.Devoluciones.Add(devolucion);
                        ctx.SaveChanges();

                        int devolucionId = devolucion.devo_id;

                        if (chboxIncludePeriph.Checked == true)
                        {
                            AgregarPerifericos(devolucionId);
                        }  
                    }
                } 
                catch (Exception ex)
                {
                    throw; 
                }
            }
        }

        protected void gridFichasDevolucion_PreRender(object sender, EventArgs e)
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

        protected void QuerySeleccionarFicha()
        {
            int FichaSelec = int.Parse(txtFichaIdSelec.Text);
            lbFichaID.Text = Convert.ToString(FichaSelec);

            string userAsignado, fechaCreacion, equiAsignado;

            using (var ctx = new EquiposInvModelContainer())
            {
                userAsignado = ctx.FichaComputo
                    .Where(s => s.ficha_id == FichaSelec)
                    .Select(s => s.emp_nom)
                    .FirstOrDefault();

                equiAsignado = ctx.FichaComputo
                    .Where(s => s.ficha_id == FichaSelec)
                    .Select(s => s.equi_cod)
                    .FirstOrDefault();

                fechaCreacion = ctx.FichaComputo
                    .Where(s => s.ficha_id == FichaSelec)
                    .Select(s => s.ficha_fecha)
                    .FirstOrDefault().ToString();
            }
            lbUsuarioAsignado.Text = userAsignado;
            lbEquipoAsignado.Text = equiAsignado;
            lbFechaCreacion.Text = fechaCreacion;
        }

        protected void btSelecFichaDevo_Click(object sender, EventArgs e)
        {
            int fichaId = int.Parse(txtFichaIdSelec.Text);

            QuerySeleccionarFicha();
            FillGridPeriph(fichaId);
        }

        protected void btCreateDevolution_Click(object sender, EventArgs e)
        {
            CrearDevolucion();
        }

        protected void gridPeriphSelect_PreRender(object sender, EventArgs e)
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

        protected void gridSelectedPeriph_PreRender(object sender, EventArgs e)
        {

        }

        // Metodo para agregar periferico a gridSelectedPeriph
        protected void AddPeriphToGrid()
        {
            dtPerifericosSeleccionados = (DataTable)ViewState["Records"];
            dtPerifericosSeleccionados.Rows.Add(txtInternalIDPer.Text, txtSelectedPeriph.Text, txtTypeSelPer.Text, txtMarcaSelPer.Text, txtEstadoSelPer.Text);
            gridSelectedPeriph.DataSource = dtPerifericosSeleccionados;
            gridSelectedPeriph.DataBind();
        }

        // Boton utilizado para agregar periferico a gridSelectedPeriph
        protected void btSelectPeriph_Click(object sender, EventArgs e)
        {
            AddPeriphToGrid();
        }
    }
}