﻿using System;
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
                MostrarEstadoEquipos();
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
                chart += "]},options: { title: { display: true,text: 'Cantidad de Equipos por Compañia'} }"; // Chart title
                chart += "});";
                chart += "</script>";

                ltChartEquiPorComp.Text = chart;
            }
        }

        protected void MostrarEstadoEquipos()
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

            SELECT TOP 4 Cantidad FROM @TempCompanias ORDER BY Cantidad desc;";
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
                
            }
        }
    }
}