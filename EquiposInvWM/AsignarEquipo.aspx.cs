using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EquiposInvWM
{
    public partial class AsignarEquipo : System.Web.UI.Page
    {
        DataTable dtPeriph = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(ViewState["Records"] == null)
                {
                    dtPeriph.Columns.Add("ID Interno");
                    dtPeriph.Columns.Add("Codigo_Periferico");
                    dtPeriph.Columns.Add("Tipo");
                    ViewState["Records"] = dtPeriph;
                }
                
            }
            
            fillGridEquipos();
            fillGridEmp();
            fillGridPerifericos();
        }

        // Para llenar gridview de seleccion de Perifericos
        protected void fillGridPerifericos()
        {
            using(var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Perifericos
                             orderby m.per_id descending
                             select new
                             {
                                 Id = m.per_id,
                                 Tipo = m.per_tipo,
                                 Codigo = (m.per_prefijo + m.per_cod)
                             }).ToList();

                gridPerifericoSelect.DataSource = query;
                gridPerifericoSelect.DataBind();
            }
        }

        // Para llenar gridview de seleccion de empleado
        protected void fillGridEmp()
        {
            using(var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Empleados
                             orderby m.emp_id descending
                             select new
                             {
                                 Id = m.emp_id,
                                 Nombre = m.emp_pnom,
                                 Apellido = m.emp_pape
                             }).ToList();

                SelectEmpGrid.DataSource = query;
                SelectEmpGrid.DataBind();
            }
        }

        // Para llenar gridview de seleccion de Equipos
        protected void fillGridEquipos()
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Equipos
                             orderby m.equi_id descending
                             select new { 
                                Id = m.equi_id,
                                Marca = m.equi_marca,
                                Serie = m.equi_serie
                             }).ToList();

                SelecEquipoGrid.DataSource = query;
                SelecEquipoGrid.DataBind();

            }
        }

        // Para forzar que Gridview SelectEquipoGrid use <thead> en vez de <tbody>
        protected void SelecEquipoGrid_PreRender(object sender, EventArgs e)
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

        protected void SelectEmpGrid_PreRender(object sender, EventArgs e)
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

        protected void getEmpInfo(int id)
        {
            string firstName, lastName, codemp;

            using (var ctx = new EquiposInvModelContainer())
            {
                firstName = ctx.Empleados
                    .Where(e => e.emp_id == id)
                    .Select(e => e.emp_pnom)
                    .FirstOrDefault();

                lastName = ctx.Empleados
                    .Where(e => e.emp_id == id)
                    .Select(e => e.emp_pape)
                    .FirstOrDefault();

                codemp = ctx.Empleados
                    .Where(e => e.emp_id == id)
                    .Select(e => e.emp_numemp)
                    .FirstOrDefault();

                txtApellido.Text = lastName;
                txtPNom.Text = firstName;
                txtAssignedUser.Text = codemp;
            }
        }

        protected void getEquiposInfo(int id)
        {
            string marca, codEqui, serie, procesador;
            decimal ghz;
            int capacidad;

            using (var ctx = new EquiposInvModelContainer())
            {
                string prefijo;
                int cod;

                serie = ctx.Equipos
                    .Where(s => s.equi_id == id)
                    .Select(s => s.equi_serie)
                    .FirstOrDefault();

                capacidad = ctx.Equipos
                    .Where(s => s.equi_id == id)
                    .Select(s => s.equi_disco)
                    .FirstOrDefault().GetValueOrDefault();

                marca = ctx.Equipos
                    .Where(s => s.equi_id == id)
                    .Select(s => s.equi_marca)
                    .FirstOrDefault();

                procesador = ctx.Equipos
                    .Where(s => s.equi_id == id)
                    .Select(s => s.equi_procesador)
                    .FirstOrDefault();

                ghz = ctx.Equipos
                    .Where(s => s.equi_id == id)
                    .Select(s => s.equi_ghz)
                    .FirstOrDefault().GetValueOrDefault();


                // Prefijo y Cod se combinan para formar cod del equipo
                prefijo = ctx.Equipos
                    .Where(s => s.equi_id == id)
                    .Select(s => s.equi_prefijo)
                    .FirstOrDefault();

                cod = ctx.Equipos
                    .Where(s => s.equi_id == id)
                    .Select(s => s.equi_cod)
                    .FirstOrDefault();

                codEqui = prefijo + Convert.ToString(cod);
            }

            txtProcessor.Text = procesador;
            txtBrandAssigned.Text = marca;
            txtGhz.Text = ghz.ToString();
            txtHdCapacity.Text = capacidad.ToString();
            txtEquipCode.Text = codEqui;
            txtSerialEquip.Text = serie;
        }

        public int randomId()
        {
            Random randomNumber = new Random();
            return randomNumber.Next(0, 5000);
        }


        protected void CrearFicha()
        {
            // Variables para informacion de equipo
            string marca, codEqui, serie, procesador, sysope;
            decimal ghz;
            int capacidad;

            procesador = txtProcessor.Text;
            marca = txtBrandAssigned.Text;
            ghz = decimal.Parse(txtGhz.Text);
            capacidad = int.Parse(txtHdCapacity.Text);
            codEqui = txtEquipCode.Text;
            serie = txtSerialEquip.Text;
            sysope = cmbOsEquipment.SelectedItem.Text;

            // variables para informacion de empleado
            string firstName, lastName, fullName, codemp, departamento, project;

            departamento = cmbDpto.SelectedItem.Text;
            lastName = txtApellido.Text;
            firstName = txtPNom.Text;
            fullName = firstName + " " + lastName;

            codemp = txtAssignedUser.Text;
            project = txtProject.Text;
            
            using(var ctx = new EquiposInvModelContainer())
            {
                var ficha = new FichaComputo()
                {
                    ficha_id = randomId(),
                    ficha_dpto = departamento,
                    ficha_emp = firstName,
                    emp_nom = fullName,
                    emp_id = randomId(),
                    emp_cod = codemp,
                    ficha_pyto = project,
                    ficha_sysope = sysope,
                    equi_cod = codEqui,
                    equi_disco = capacidad,
                    equi_ghz = ghz,
                    equi_marca = marca,
                    equi_serie = serie,
                    equi_procesador = procesador,
                    equi_id = randomId()
                };
                ctx.FichaComputo.Add(ficha);
                ctx.SaveChanges();
            }

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }


        // Para Seleccionar empleado
        protected void btSelectEmp_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSelectedEmp.Text);
            getEmpInfo(id);
        }

        // Para Seleccionar Equipo
        protected void btnSelEmployee_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtEquipoSelec.Text);

            getEquiposInfo(id);
        }

        protected void gridPerifericoSelect_PreRender(object sender, EventArgs e)
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

        // Para agregar perifericos a gridSelectedPeriph
        protected void btSelectPeriph_Click(object sender, EventArgs e)
        {
            dtPeriph = (DataTable)ViewState["Records"];
            dtPeriph.Rows.Add(txtIDInternPeri.Text, txtSelectedPeriph.Text, txtTypePeriph.Text);
            gridSelectedPeriph.DataSource = dtPeriph;
            gridSelectedPeriph.DataBind();
        }

        protected void emptyFields()
        {
            txtApellido.Text = "";
            txtBrandAssigned.Text = "";
            txtGhz.Text = "";
            txtHdCapacity.Text = "";
            txtIDInternPeri.Text = "";
            txtObservacionArea.Text = "";
            txtPNom.Text = "";
            txtSelectedPeriph.Text = "";
            txtSerialEquip.Text = "";
            txtApellido.Text = "";
        }

        protected void btCrearFicha_Click(object sender, EventArgs e)
        {
            CrearFicha();
            emptyFields();
        }
    }
}