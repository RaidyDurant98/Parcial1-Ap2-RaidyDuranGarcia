﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1_Ap2_RaidyDuran.UI.Consultas
{
    public partial class PresupuestosConsulta : System.Web.UI.Page
    {
        public static List<Entidades.Presupuestos> Lista { get; set; }
        public static Entidades.Presupuestos Presupuestos;

        protected void Page_Load(object sender, EventArgs e)
        {
            AlertInfoPanel.Visible = false;
            AlertSuccessPanel.Visible = false;
            AlertDangerPanel.Visible = false;

            if (!Page.IsPostBack)
            {
                Lista = BLL.PresupuestosBLL.GetListAll();
                CargarListaPresupuesto();
            }

            if (Lista == null || Lista.Count() == 0)
            {
                ImprimirButton.Visible = false;
                TotalLabel.Visible = false;
                TotalMontoLabel.Visible = false;
            }
            else
            {
                ImprimirButton.Visible = true;
                TotalLabel.Visible = true;
                TotalMontoLabel.Visible = true;
            }
        }

        private void Limpiar()
        {
            FiltroTextBox.Text = "";
            FechaDesdeTextBox.Text = "";
            FechaHastaTextBox.Text = "";
            TotalMontoLabel.Text = "0.0";
        }

        private void CargarListaPresupuesto()
        {
            PresupuestoConsultaGridView.DataSource = Lista;
            PresupuestoConsultaGridView.DataBind();
            LlenarLabelMonto();
        }

        private void BotonImprimirVisibleSiHayListas()
        {
            if (Lista.Count() != 0)
            {
                ImprimirButton.Visible = true;
            }
        }

        private void AsignarTextoAlertaInfo(string texto)
        {
            AlertInfoLabel.Text = texto;
            AlertInfoPanel.Visible = true;
        }

        private void AsignarTextoAlertaSuccess(string texto)
        {
            AlertSuccessLabel.Text = texto;
            AlertSuccessPanel.Visible = true;
        }

        private void AsignarTextoAlertaDanger(string texto)
        {
            AlertDangerLabel.Text = texto;
            AlertDangerPanel.Visible = true;
        }

        private void Filtrar()
        {
            if (FiltrarDropDownList.SelectedIndex == 0)
            {
                Lista = BLL.PresupuestosBLL.GetListAll();
                Limpiar();
            }
            else if (FiltrarDropDownList.SelectedIndex != 0)
            {
                if (FiltrarDropDownList.SelectedIndex == 1)
                {
                    int id = Utilidades.TOINT(FiltroTextBox.Text);
                    Lista = BLL.PresupuestosBLL.GetList(p => p.PresupuestoId == id);
                }
                if (FiltrarDropDownList.SelectedIndex == 2)
                {
                    DateTime FechaDesde = Convert.ToDateTime(FechaDesdeTextBox.Text);
                    DateTime FechaHasta = Convert.ToDateTime(FechaHastaTextBox.Text);
                    Lista = BLL.PresupuestosBLL.GetList(p => p.Fecha >= FechaDesde.Date && p.Fecha <= FechaHasta.Date);
                }
                if (FiltrarDropDownList.SelectedIndex == 3)
                {
                    int id = Utilidades.TOINT(FiltroTextBox.Text);
                    Lista = BLL.PresupuestosBLL.GetList(p => p.CategoriaId == id);
                }
            }
            CargarListaPresupuesto();
            if (Lista.Count() == 0)
            {
                AsignarTextoAlertaInfo("No existe presupuesto.");
                ImprimirButton.Visible = false;
                TotalLabel.Visible = false;
                TotalMontoLabel.Visible = false;
            }
        }

        protected void FiltroButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FiltroTextBox.Text) && (FiltrarDropDownList.SelectedIndex == 1 || FiltrarDropDownList.SelectedIndex == 3))
            {
                PresupuestoConsultaGridView.DataBind();
                AsignarTextoAlertaInfo("Por favor digite el dato que desea filtrar.");
                ImprimirButton.Visible = false;
                TotalMontoLabel.Visible = false;
                TotalLabel.Visible = false;
            }
            else if (FiltrarDropDownList.SelectedIndex == 2)
            {
                if (string.IsNullOrEmpty(FechaDesdeTextBox.Text) || string.IsNullOrEmpty(FechaHastaTextBox.Text))
                {
                    PresupuestoConsultaGridView.DataBind();
                    AsignarTextoAlertaInfo("Por favor eliga el rango de fecha que desea filtrar.");
                    ImprimirButton.Visible = false;
                    TotalMontoLabel.Visible = false;
                    TotalLabel.Visible = false;
                }
                else
                {
                    Filtrar();
                    BotonImprimirVisibleSiHayListas();
                }
            }
            else
            {
                Filtrar();
                BotonImprimirVisibleSiHayListas();
            }
        }

        private void LlenarLabelMonto()
        {
            decimal monto = 0;
            foreach (GridViewRow montoCount in PresupuestoConsultaGridView.Rows)
            {
                monto += Convert.ToDecimal(montoCount.Cells[4].Text);     
            }

            TotalMontoLabel.Text = monto.ToString();
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/PresupuestosReporte.aspx");
        }
    }
}