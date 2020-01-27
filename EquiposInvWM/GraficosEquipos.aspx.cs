using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EquiposInvWM
{
    public partial class GraficosEquipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarEquiposPorComp();
                MostrarPorEstadoEquipos();
                MostrarPerifericosEstados();
                MostrarPerTipoCantidad();
            }
        }

        protected void MostrarEquiposPorComp()
        {
            string myConnection = ConfigurationManager.ConnectionStrings["EquiposInventarioConnectionString"].ToString();
            SqlConnection con = new SqlConnection(myConnection);
            string query = @"
            DECLARE
            @CantidadWM int,
            @CantidadDCS int,
            @CantidadDC int,
            @CantidadINV int;

                        SELECT @CantidadWM = count(equi_id) FROM Equipos WHERE equi_empresa = 'WM';
                        SELECT @CantidadDCS = count(equi_id) FROM Equipos WHERE equi_empresa = 'DCS';
                        SELECT @CantidadDC = count(equi_id) FROM Equipos WHERE equi_empresa = 'DC';
                        SELECT @CantidadINV = count(equi_id) FROM Equipos WHERE equi_empresa = 'INV';

                        DECLARE @TempCompanias TABLE
                        (
                            Compania varchar(10),
                            Cantidad int
                        )

            INSERT INTO @TempCompanias(Compania, Cantidad) VALUES('WM', @CantidadWM);
                        INSERT INTO @TempCompanias(Compania, Cantidad) VALUES('DC', @CantidadDC);
                        INSERT INTO @TempCompanias(Compania, Cantidad) VALUES('DCS', @CantidadDCS);
                        INSERT INTO @TempCompanias(Compania, Cantidad) VALUES('INV', @CantidadINV);

            SELECT TOP 4 Compania,Cantidad FROM @TempCompanias ORDER BY Cantidad desc;";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable tb = new DataTable();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                tb.Load(dr, LoadOption.OverwriteChanges);
                con.Close();
            } 
            catch { }

            if (tb != null)
            {
                string chart = "";
                chart = "<canvas id=\"line-chart\" width=\"100%\" height=\"40\"></canvas>";
                chart += "<script>";
                chart += "new Chart(document.getElementById(\"line-chart\"), { type: 'doughnut', data: {labels: [";

                string graphLabel = "";
                // Mas Detalles
                for (int i = 0; i < tb.Rows.Count; i++)
                    graphLabel += @"""" + tb.Rows[i]["Compania"].ToString() + @"""" + ",";
                graphLabel = graphLabel.Substring(0, graphLabel.Length - 1);
                chart += graphLabel;
                chart += "],datasets: [{ data: [";

                // Conseguir datos de la Base de datos y agregarlos al grafico
                string value = "";
                for (int i = 0; i < tb.Rows.Count; i++)
                    value += tb.Rows[i]["Cantidad"].ToString() + ",";
                value = value.Substring(0, value.Length - 1);
                chart += value;

                chart += "],label: \"Cantidad de equipos por compañia\",fill: true, backgroundColor: [\"rgb(255, 99, 132)\",\"rgb(54, 162, 235)\",\"rgb(255, 205, 86)\"]}"; // Chart color
                chart += "]},options: { title: { display: true,text: 'Cantidad de Equipos Totales por Compañia'} }"; // Chart title
                chart += "});";
                chart += "</script>";

                ltChartEquiPorComp.Text = chart;
            }
        }

        protected void MostrarPerifericosEstados()
        {
            string myConnection = ConfigurationManager.ConnectionStrings["EquiposInventarioConnectionString"].ToString();
            SqlConnection con = new SqlConnection(myConnection);
            string query = @"
            DECLARE
            @CantidadNuevo int,
            @CantidadDanado int,
            @CantidadUsado int;

            SELECT @CantidadNuevo = count(per_id) FROM Perifericos WHERE per_estado = 'Nuevo'; 
            SELECT @CantidadDanado = count(per_id) FROM Perifericos WHERE per_estado = 'Dañado'; 
            SELECT @CantidadUsado = count(per_id) FROM Perifericos WHERE per_estado = 'Usado';

            DECLARE @TempEstadosPerifericos TABLE
	            (
		            Estado varchar(20),
		            Cantidad int
	            )

            INSERT INTO @TempEstadosPerifericos(Estado, Cantidad) VALUES('Nuevo', @CantidadNuevo);
            INSERT INTO @TempEstadosPerifericos(Estado, Cantidad) VALUES('Dañado', @CantidadDanado);
            INSERT INTO @TempEstadosPerifericos(Estado, Cantidad) VALUES('Usado', @CantidadUsado);

            SELECT TOP 4 Estado,Cantidad FROM @TempEstadosPerifericos ORDER BY Cantidad desc;";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable tb = new DataTable();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                tb.Load(dr, LoadOption.OverwriteChanges);
                con.Close();
            }
            catch { }

            if (tb != null)
            {
                string chart = "";
                chart = "<canvas id=\"chat-perestado\" width=\"100%\" height=\"40\"></canvas>";
                chart += "<script>";
                chart += "new Chart(document.getElementById(\"chat-perestado\"), { type: 'doughnut', data: {labels: [";

                string graphLabel = "";
                // Mas Detalles
                for (int i = 0; i < tb.Rows.Count; i++)
                    graphLabel += @"""" + tb.Rows[i]["Estado"].ToString() + @"""" + ",";
                graphLabel = graphLabel.Substring(0, graphLabel.Length - 1);
                chart += graphLabel;
                chart += "],datasets: [{ data: [";

                // Conseguir datos de la Base de datos y agregarlos al grafico
                string value = "";
                for (int i = 0; i < tb.Rows.Count; i++)
                    value += tb.Rows[i]["Cantidad"].ToString() + ",";
                value = value.Substring(0, value.Length - 1);
                chart += value;

                chart += "],label: \"Cantidad de equipos por compañia\",fill: true, backgroundColor: [\"rgb(255, 99, 132)\",\"rgb(54, 162, 235)\",\"rgb(255, 205, 86)\"]}"; // Chart color
                chart += "]},options: { title: { display: true,text: 'Cantidad de Perifericos por Estado'} }"; // Chart title
                chart += "});";
                chart += "</script>";

                ltChartPerPorEstado.Text = chart;
            }
        }

        protected void MostrarPorEstadoEquipos()
        {
            string myConnection = ConfigurationManager.ConnectionStrings["EquiposInventarioConnectionString"].ToString();
            SqlConnection con = new SqlConnection(myConnection);
            string query = @"
            DECLARE
            @CantidadActivo int,
            @CantidadDesactivado int,
            @CantidadStock int,
            @CantidadReparacion int;

            SELECT @CantidadActivo = count(equi_id) FROM Equipos WHERE equi_status = 'ACTIVO';
            SELECT @CantidadDesactivado = count(equi_id) FROM Equipos WHERE equi_status = 'DESACTIVADO';
            SELECT @CantidadReparacion = count(equi_id) FROM Equipos WHERE equi_status = 'REPARACION';
            SELECT @CantidadStock = count(equi_id) FROM Equipos WHERE equi_status = 'STOCK';

            DECLARE @TempEstados TABLE
	            (
		            Estado varchar(20),
		            Cantidad int
	            )

            INSERT INTO @TempEstados(Estado, Cantidad) VALUES('ACTIVO', @CantidadActivo);
            INSERT INTO @TempEstados(Estado, Cantidad) VALUES('DESACTIVADO', @CantidadDesactivado);
            INSERT INTO @TempEstados(Estado, Cantidad) VALUES('REPARACION', @CantidadReparacion);
            INSERT INTO @TempEstados(Estado, Cantidad) VALUES('STOCK', @CantidadStock);

            SELECT TOP 4 Estado,Cantidad FROM @TempEstados ORDER BY Cantidad desc;";
            SqlCommand cmd = new SqlCommand(query, con);

            DataTable tb = new DataTable();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                tb.Load(dr, LoadOption.OverwriteChanges);
                con.Close();
            }
            catch { }

            if (tb != null)
            {
                string chart = "";
                chart = "<canvas id=\"chart-estados\" width=\"100%\" height=\"40\"></canvas>";
                chart += "<script>";
                chart += "new Chart(document.getElementById(\"chart-estados\"), { type: 'bar', data: {labels: [";

                string graphLabel = "";
                // Mas Detalles
                for (int i = 0; i < tb.Rows.Count; i++)
                    graphLabel += @"""" + tb.Rows[i]["Estado"].ToString() + @"""" + ",";
                graphLabel = graphLabel.Substring(0, graphLabel.Length - 1);
                chart += graphLabel;
                chart += "],datasets: [{ data: [";

                // Conseguir datos de la Base de datos y agregarlos al grafico
                string value = "";
                for (int i = 0; i < tb.Rows.Count; i++)
                    value += tb.Rows[i]["Cantidad"].ToString() + ",";
                value = value.Substring(0, value.Length - 1);
                chart += value;

                chart += "],label: \"Cantidad de equipos por compañia\",fill: true, backgroundColor: [\"rgb(255, 99, 132)\",\"rgb(54, 162, 235)\",\"rgb(255, 205, 86)\"]}"; // Chart color
                chart += "]},options: { title: { display: true,text: 'Cantidad de Equipos por Estado'} }"; // Chart title
                chart += "});";
                chart += "</script>";

                ltChartEquiPorEstados.Text = chart;
            }
        }

        protected void MostrarPerTipoCantidad()
        {
            string myConnection = ConfigurationManager.ConnectionStrings["EquiposInventarioConnectionString"].ToString();
            SqlConnection con = new SqlConnection(myConnection);
            string query = @"
            DECLARE
            @CantidadBateria int,
            @CantidadCargador int,
            @CantidadMouse int,
            @CantidadMaletin int,
            @CantidadOtro int;

            SELECT @CantidadBateria = count(per_id) FROM Perifericos WHERE per_tipo = 'Bateria';
            SELECT @CantidadCargador = count(per_id) FROM Perifericos WHERE per_tipo = 'Cargador';
            SELECT @CantidadMouse = count(per_id) FROM Perifericos WHERE per_tipo = 'Mouse';
            SELECT @CantidadMaletin = count(per_id) FROM Perifericos WHERE per_tipo = 'Maletin';
            SELECT @CantidadOtro = count(per_id) FROM Perifericos WHERE per_tipo = 'Otro';

            DECLARE @TempTiposPerifericos TABLE
	            (
		            Tipo varchar(20),
		            Cantidad int
	            )

            INSERT INTO @TempTiposPerifericos(Tipo, Cantidad) VALUES('Bateria', @CantidadBateria);
            INSERT INTO @TempTiposPerifericos(Tipo, Cantidad) VALUES('Cargador', @CantidadCargador);
            INSERT INTO @TempTiposPerifericos(Tipo, Cantidad) VALUES('Mouse', @CantidadMouse);
            INSERT INTO @TempTiposPerifericos(Tipo, Cantidad) VALUES('Maletin', @CantidadMaletin);
            INSERT INTO @TempTiposPerifericos(Tipo, Cantidad) VALUES('Otro', @CantidadOtro);

            SELECT TOP 4 Tipo,Cantidad FROM @TempTiposPerifericos ORDER BY Cantidad desc;";
            SqlCommand cmd = new SqlCommand(query, con);

            DataTable tb = new DataTable();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                tb.Load(dr, LoadOption.OverwriteChanges);
                con.Close();
            }
            catch { }

            if (tb != null)
            {
                string chart = "";
                chart = "<canvas id=\"chart-tiposper\" width=\"100%\" height=\"40\"></canvas>";
                chart += "<script>";
                chart += "new Chart(document.getElementById(\"chart-tiposper\"), { type: 'bar', data: {labels: [";

                string graphLabel = "";
                // Mas Detalles
                for (int i = 0; i < tb.Rows.Count; i++)
                    graphLabel += @"""" + tb.Rows[i]["Tipo"].ToString() + @"""" + ",";
                graphLabel = graphLabel.Substring(0, graphLabel.Length - 1);
                chart += graphLabel;
                chart += "],datasets: [{ data: [";

                // Conseguir datos de la Base de datos y agregarlos al grafico
                string value = "";
                for (int i = 0; i < tb.Rows.Count; i++)
                    value += tb.Rows[i]["Cantidad"].ToString() + ",";
                value = value.Substring(0, value.Length - 1);
                chart += value;

                chart += "],label: \"Cantidad de equipos por compañia\",fill: true, backgroundColor: [\"rgb(255, 99, 132)\",\"rgb(54, 162, 235)\",\"rgb(255, 205, 86)\"]}"; // Chart color
                chart += "]},options: { title: { display: true,text: 'Cantidad de Perifericos por Tipo'} }"; // Chart title
                chart += "});";
                chart += "</script>";

                ltChartPerPorTipo.Text = chart;
            }
        }
    }
}