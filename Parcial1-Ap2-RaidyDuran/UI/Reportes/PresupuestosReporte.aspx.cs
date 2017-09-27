using Parcial1_Ap2_RaidyDuran.UI.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1_Ap2_RaidyDuran.UI.Reportes
{
    public partial class PresupuestosReporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                PresupuestosReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                PresupuestosReportViewer.Reset();
                PresupuestosReportViewer.LocalReport.ReportPath = Server.MapPath(@"PresupuestosReporte.rdlc");
                PresupuestosReportViewer.LocalReport.DataSources.Clear();

                PresupuestosReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource(
                    "PresupuestosDataSet", PresupuestosConsulta.Lista));

                PresupuestosReportViewer.LocalReport.Refresh();
            }
        }
    }
}