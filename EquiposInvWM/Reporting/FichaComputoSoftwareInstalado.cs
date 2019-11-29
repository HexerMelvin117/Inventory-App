using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace EquiposInvWM.Reporting
{
    public partial class FichaComputoSoftwareInstalado : DevExpress.XtraReports.UI.XtraReport
    {
        public FichaComputoSoftwareInstalado()
        {
            InitializeComponent();
        }

        private void FichaComputoSoftwareInstalado_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            listaSoftwareTableAdapter1.Fill(dsCreacionFicha1.ListaSoftware, (int)(Parameters["Ficha_id"]).Value);
        }
    }
}
