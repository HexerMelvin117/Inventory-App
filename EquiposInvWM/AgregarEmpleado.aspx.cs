using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquiposInvWM
{
    public partial class AgregarEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int randomId()
        {
            Random randomNumber = new Random();
            return randomNumber.Next(0, 10000);
        }

        protected void emptyFields()
        {
            txtCorreoEmp.Text = "";
            txtIdEmp.Text = "";
            txtNomEmp.Text = "";
            txtPape.Text = "";
        }

        protected void AgregarEmp(string nombre, string pape, string ident, string compania, string correo)
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                var emp = new Empleado()
                {
                    emp_id = randomId(),
                    emp_pape = pape,
                    emp_compania = compania,
                    emp_correo = correo,
                    emp_pnom = nombre,
                    emp_numemp = ident
                };
                ctx.Empleados.Add(emp);
                ctx.SaveChanges();
            }
        }

        protected void btAgregarEmp_Click(object sender, EventArgs e)
        {
            string nombre, pape, ident, compania, correo;
            nombre = txtNomEmp.Text;
            pape = txtPape.Text;
            ident = txtIdEmp.Text;
            compania = cmbCompEmp.SelectedItem.Value;
            correo = txtCorreoEmp.Text;

            AgregarEmp(nombre, pape, ident, compania, correo);
            emptyFields();
        }
    }
}