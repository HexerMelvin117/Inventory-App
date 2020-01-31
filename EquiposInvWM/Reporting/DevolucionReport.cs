using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace EquiposInvWM.Reporting
{
    public partial class DevolucionReport : DevExpress.XtraReports.UI.XtraReport
    {
        public DevolucionReport()
        {
            InitializeComponent();
        }

        private void DevolucionReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            creacionDevolucionTableAdapter.Fill(dsDevolucionFicha1.CreacionDevolucion, (int)(Parameters["Devo_id"].Value));
            listaPerifericoDevoTableAdapter.Fill(dsDevolucionFicha1.ListaPerifericoDevo, (int)(Parameters["Devo_id"].Value));
            listaSoftwareDevoTableAdapter.Fill(dsDevolucionFicha1.ListaSoftwareDevo, (int)(Parameters["Devo_id"].Value));
            devoFotosEquipoTableAdapter.Fill(dsDevolucionFicha1.DevoFotosEquipo, (int)(Parameters["Devo_id"].Value));
        }
    }
}
