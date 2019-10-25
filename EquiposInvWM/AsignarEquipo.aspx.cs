using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class AsignarEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fillGridEquipos();
            fillGridEmp();
        }

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

            txtEquipCode.Text = codEqui;
        }

        protected void getEmployeeInfo()
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var query = (from m in ctx.Empleados
                             select m).ToList();
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }


        // Para Seleccionar empleado
        protected void btSelectEmp_Click(object sender, EventArgs e)
        {
            getEmployeeInfo();
        }

        // Para Seleccionar Equipo
        protected void btnSelEmployee_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtEquipoSelec.Text);

            getEquiposInfo(id);
        }
    }
}