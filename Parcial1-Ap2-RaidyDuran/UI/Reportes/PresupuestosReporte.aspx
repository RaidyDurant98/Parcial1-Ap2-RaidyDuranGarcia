<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PresupuestosReporte.aspx.cs" Inherits="Parcial1_Ap2_RaidyDuran.UI.Reportes.PresupuestosReporte" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte de Presu[uestos</title>
</head>
<body>
    <form id="PresupuestoForm" runat="server">
        <asp:ScriptManager ID="PresupuestosScriptManager" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="PresupuestosReportViewer" runat="server" ProcessingMode="Remote" Width="850" Height="750">
            <ServerReport ReportServerUrl="" ReportPath="" />
        </rsweb:ReportViewer>
    </form>
</body>
</html>
