using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.Security.Resources;

namespace EquiposInvWM.Reporting
{
    public partial class FichaComputoReport : DevExpress.XtraReports.UI.XtraReport
    {
        public FichaComputoReport()
        {
            InitializeComponent();
        }

        private void FichaComputoReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            creacionFichaTableAdapter2.Fill(dsCreacionFicha1.CreacionFicha, (int)(Parameters["Ficha_id"].Value));
            listaSoftwareTableAdapter.Fill(dsCreacionFicha1.ListaSoftware, (int)(Parameters["Ficha_id"].Value));
            listaPerifericoAsociadaTableAdapter.Fill(dsCreacionFicha1.ListaPerifericoAsociada, (int)(Parameters["Ficha_id"].Value));
            fichaFotosEquipoTableAdapter.Fill(dsCreacionFicha1.FichaFotosEquipo, (int)(Parameters["Ficha_id"].Value));
        }

        private void xrPictureBox2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }
    }
}
