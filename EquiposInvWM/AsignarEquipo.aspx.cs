using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using DevExpress.Security.Resources;

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
                    dtPeriph.Columns.Add("Marca");
                    dtPeriph.Columns.Add("Estado");
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
                                 Codigo = (m.per_prefijo + m.per_cod),
                                 Estado = m.per_estado,
                                 Marca = m.per_marca
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

        // Para capturar la informacion del empleado en la seccion de "Informacion de Empleado"
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

        // Para capturar la informacion del equipo en la seccion de "Informacion de Equipo"
        protected void getEquiposInfo(int id)
        {
            string marca, codEqui, serie, procesador;
            decimal ghz;
            string capacidad;
            string ram;

            using (var ctx = new EquiposInvModelContainer())
            {
                string prefijo;
                string cod;

                serie = ctx.Equipos
                    .Where(s => s.equi_id == id)
                    .Select(s => s.equi_serie)
                    .FirstOrDefault();

                capacidad = ctx.Equipos
                    .Where(s => s.equi_id == id)
                    .Select(s => s.equi_disco)
                    .FirstOrDefault();

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

                ram = ctx.Equipos
                    .Where(s => s.equi_id == id)
                    .Select(s => s.equi_ram)
                    .FirstOrDefault();

                codEqui = prefijo + Convert.ToString(cod);
            }

            txtProcessor.Text = procesador;
            txtBrandAssigned.Text = marca;
            txtGhz.Text = ghz.ToString();
            txtHdCapacity.Text = capacidad.ToString();
            txtEquipCode.Text = codEqui;
            txtSerialEquip.Text = serie;
            txtRamEqui.Text = ram;
            txtIdEquiHidden.Value = Convert.ToString(id);
        }

        // Query en SQL Server para subir imagenes a carpeta Images/ y guardar a BD
        protected void QueryToAddImage(string imgFile, int fichaId)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["EquiposInventarioConnectionString"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            string sqlquery = "insert into [dbo].[ImagenEquipo] ([img_name],[img_path],[ficha_id]) values (@img_name,@img_path,@ficha_id)";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("@img_name", imgFile);
            sqlcomm.Parameters.AddWithValue("@img_path", @"Images/" + imgFile);
            sqlcomm.Parameters.AddWithValue("@ficha_id", fichaId);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
        }

        // Para subir las imagenes a la BD
        protected void AddImages(int fichaId)
        {
            if (ImagenUpload1.HasFile != false)
            {
                string imgFile = Path.GetFileName(ImagenUpload1.PostedFile.FileName);
                string physicalPath = Path.Combine(Server.MapPath(" "), "Images/");
                ImagenUpload1.SaveAs(physicalPath + imgFile);
                QueryToAddImage(imgFile, fichaId);
            } 
            
            if (ImagenUpload2.HasFile != false)
            {
                string imgFile = Path.GetFileName(ImagenUpload2.PostedFile.FileName);
                string physicalPath = Path.Combine(Server.MapPath(" "), "Images/");
                ImagenUpload2.SaveAs(physicalPath + imgFile);
                QueryToAddImage(imgFile, fichaId);
            } 
            
            if (ImagenUpload3.HasFile != false)
            {
                string imgFile = Path.GetFileName(ImagenUpload3.PostedFile.FileName);
                string physicalPath = Path.Combine(Server.MapPath(" "), "Images/");
                ImagenUpload3.SaveAs(physicalPath + imgFile);
                QueryToAddImage(imgFile, fichaId);
            } 
            
            if (ImagenUpload4.HasFile != false)
            {
                string imgFile = Path.GetFileName(ImagenUpload4.PostedFile.FileName);
                string physicalPath = Path.Combine(Server.MapPath(" "), "Images/");
                ImagenUpload4.SaveAs(physicalPath + imgFile);
                QueryToAddImage(imgFile, fichaId);
            } 
            
            if (ImagenUpload5.HasFile != false)
            {
                string imgFile = Path.GetFileName(ImagenUpload5.PostedFile.FileName);
                string physicalPath = Path.Combine(Server.MapPath(" "), "Images/");
                ImagenUpload5.SaveAs(physicalPath + imgFile);
                QueryToAddImage(imgFile, fichaId);
            } 
            
            if (ImagenUpload6.HasFile != false)
            {
                string imgFile = Path.GetFileName(ImagenUpload6.PostedFile.FileName);
                string physicalPath = Path.Combine(Server.MapPath(" "), "Images/");
                ImagenUpload6.SaveAs(physicalPath + imgFile);
                QueryToAddImage(imgFile, fichaId);
            } 
            
        }

        // Para crear la ficha
        protected void CrearFicha()
        {
            string fecha;
            fecha = txtDate.Text;

            // Variables para informacion de equipo
            string marca, codEqui, serie, procesador, sysope, observacion;
            decimal ghz;
            string capacidad;
            int equiId;
            if (txtIdEquiHidden.Value == "")
            {
                equiId = 0;
            } 
            else
            {
                equiId = int.Parse(txtIdEquiHidden.Value);
            }

            procesador = txtProcessor.Text;
            marca = txtBrandAssigned.Text;
            if (txtGhz.Text == "")
            {
                ghz = decimal.Parse("0");
            } else
            {
                ghz = decimal.Parse(txtGhz.Text);
            }
            capacidad = txtHdCapacity.Text;
            codEqui = txtEquipCode.Text;
            serie = txtSerialEquip.Text;
            sysope = cmbOsEquipment.SelectedItem.Text;
            observacion = txtObservacionArea.Text;

            // variables para informacion de empleado
            string firstName, lastName, fullName, codemp, departamento, project, ram;

            departamento = cmbDpto.SelectedItem.Text;
            lastName = txtApellido.Text;
            firstName = txtPNom.Text;
            fullName = firstName + " " + lastName;
            ram = txtRamEqui.Text;

            codemp = txtAssignedUser.Text;
            project = txtProject.Text;

            try
            {
                if (equiId == 0)
                {
                    using (var ctx = new EquiposInvModelContainer())
                    {
                        var ficha = new FichaComputo()
                        {
                            ficha_dpto = departamento,
                            ficha_fecha = DateTime.Parse(fecha),
                            ficha_emp = firstName,
                            ficha_observacion = observacion,
                            emp_nom = fullName,
                            emp_id = null,
                            emp_cod = codemp,
                            ficha_pyto = project,
                            ficha_sysope = sysope,
                            equi_cod = null,
                            equi_disco = null,
                            equi_ghz = null,
                            equi_marca = null,
                            equi_serie = null,
                            equi_procesador = null,
                            equi_ram = null,
                            equi_id = null
                        };
                        ctx.FichaComputo.Add(ficha);
                        ctx.SaveChanges();

                        int fichaid;
                        fichaid = ficha.ficha_id;

                        ListaPerifericosAgregar(fichaid);
                        CaptureSoftware(fichaid);
                        AddImages(fichaid);
                        Response.Write("<script>alert('Ficha creada con ID: " + fichaid + "')</script>");
                    }
                }
                else
                {
                    using (var ctx = new EquiposInvModelContainer())
                    {
                        var ficha = new FichaComputo()
                        {
                            ficha_dpto = departamento,
                            ficha_fecha = DateTime.Parse(fecha),
                            ficha_emp = firstName,
                            ficha_observacion = observacion,
                            emp_nom = fullName,
                            emp_id = null,
                            emp_cod = codemp,
                            ficha_pyto = project,
                            ficha_sysope = sysope,
                            equi_cod = codEqui,
                            equi_disco = capacidad,
                            equi_ghz = ghz,
                            equi_marca = marca,
                            equi_serie = serie,
                            equi_procesador = procesador,
                            equi_ram = ram,
                            equi_id = equiId
                        };
                        ctx.FichaComputo.Add(ficha);
                        ctx.SaveChanges();

                        int fichaid;
                        fichaid = ficha.ficha_id;

                        ChangeComputerState(equiId, fullName, project);
                        ListaPerifericosAgregar(fichaid);
                        CaptureSoftware(fichaid);
                        AddImages(fichaid);
                        Response.Write("<script>alert('Ficha creada con ID: " + fichaid + "')</script>");
                    }
                }
            } 
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al subir ficha: " + ex.Message + "')</script>");
            } 
        }

        protected void ChangeComputerState(int idEqui, string empNom, string pyto)
        {
            using (var ctx = new EquiposInvModelContainer())
            {
                try
                {
                    var result = ctx.Equipos.SingleOrDefault(m => m.equi_id == idEqui);
                    if (result != null)
                    {
                        result.equi_status = "Activo";
                        result.emp_nom = empNom;
                        result.equi_proyecto = pyto;

                        ctx.Equipos.Add(result);
                        ctx.Equipos.Attach(result);
                        ctx.Entry(result).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                } 
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        protected void CaptureSoftware(int idFicha)
        {
            // Lista que contiene todos los nombres de los software
            List<string> allSoftware = cblistInstalledSoftware.Items.Cast<ListItem>()
                .Select(li => li.Text)
                .ToList();


            // Lista que contiene solo los software seleccionados
            List<string> selected = cblistInstalledSoftware.Items.Cast<ListItem>()
                .Where(li => li.Selected)
                .Select(li => li.Text)
                .ToList();

            // Compara lista de seleccionados vs lista de todos los software
            // Produce una nueva lista sin los software seleccionados
            List<string> notSelected = new List<string>();
            notSelected = allSoftware.Except(selected).ToList();

            using (var ctx = new EquiposInvModelContainer())
            {
                // Algoritmo para agregar software seleccionado a tabla de lista de softwares instalados
                foreach (var item in selected)
                {
                    var softwareSelec = new SoftwareInstalado()
                    {
                        softinstal_nom = item,
                        softinstal_instalado = true,
                        ficha_id = idFicha,
                    };

                    ctx.SoftwareInstalado.Add(softwareSelec);
                    ctx.SaveChanges();
                }

                // Algoritmo para agregar software no seleccionado a tabla de lista de softwares instalados
                foreach (var item in notSelected)
                {
                    var unSelected = new SoftwareInstalado()
                    {
                        softinstal_nom = item,
                        softinstal_instalado = false,
                        ficha_id = idFicha
                    };

                    ctx.SoftwareInstalado.Add(unSelected);
                    ctx.SaveChanges();
                }
            }
        }

        // Para agregar lista de perifericos a la BD
        protected void ListaPerifericosAgregar(int idFicha)
        {
            int idPer;
            string tipoPer, codPer, estadoPer, marcaPer;

            dtPeriph = (DataTable)ViewState["Records"];
            using (var ctx = new EquiposInvModelContainer())
            {
                foreach(DataRow row in dtPeriph.Rows)
                {
                    string idtemp = row["ID Interno"].ToString();
                    tipoPer = row["Tipo"].ToString();
                    codPer = row["Codigo_Periferico"].ToString();
                    marcaPer = row["Marca"].ToString();
                    estadoPer = row["Estado"].ToString();
                    idPer = int.Parse(idtemp);

                    var ListaPer = new ListaPerifericos()
                    {
                        per_tipo = tipoPer,
                        per_id = idPer,
                        per_cod = codPer,
                        per_marca = marcaPer,
                        per_estado = estadoPer,
                        ficha_id = idFicha,
                    };

                    ctx.ListaPerifericos.Add(ListaPer);
                    ctx.SaveChanges();
                }
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
            dtPeriph.Rows.Add(txtIDInternPeri.Text, txtSelectedPeriph.Text, txtTypePeriph.Text, txtMarcaPeriph.Text, txtEstadoPeriph.Text);
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