using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1_Ap2_RaidyDuran.UI.Registros
{
    public partial class PresupuestoForm : System.Web.UI.Page
    {
        public Presupuestos presupuesto;

        protected void Page_Load(object sender, EventArgs e)
        {
            presupuesto = new Presupuestos();
            AlertSuccessPanel.Visible = false;
            AlertInfoPanel.Visible = false;
            AlertDangerPanel.Visible = false;

            if (!Page.IsPostBack)
            {
                LlenarCombo();
            }  
        }

        private void LlenarCombo()
        {
            List<Entidades.Categorias> Lista = BLL.CategoriasBLL.GetListAll();

            CategoriaDropDownList.DataSource = Lista;
            CategoriaDropDownList.DataValueField = "CategoriaId";
            CategoriaDropDownList.DataTextField = "Descripcion";
            CategoriaDropDownList.DataBind();
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

        private void AsignarTextoAlertaWarning(string texto)
        {
            AlertWarningLabel.Text = texto;
            AlertWarningPanel.Visible = true;
        }

        private void AsignarTextoAlertaDanger(string texto)
        {
            AlertDangerLabel.Text = texto;
            AlertDangerPanel.Visible = true;
        }

        private void Limpiar()
        {
            PresupuestoIdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            MontoTextBox.Text = "";
            FechaTextBox.Text = "";
        }

        private bool Validar()
        {
            bool interruptor = true;

            if (string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                interruptor = false; 
            }
            if (string.IsNullOrEmpty(MontoTextBox.Text))
            {
                interruptor = false;
            }
            if (string.IsNullOrEmpty(FechaTextBox.Text))
            {
                interruptor = false;
            }

            return interruptor;
        }

        private void DatosPresupuesto()
        {
            string fechaMonth = presupuesto.Fecha.Month.ToString();
            string fechaDay = presupuesto.Fecha.Day.ToString();

            if (presupuesto.Fecha.Month < 10)
            {
                fechaMonth = ("0" + presupuesto.Fecha.Month);
            }
            else if (presupuesto.Fecha.Day < 10)
            {
                fechaDay = ("0" + presupuesto.Fecha.Day);
            }
            DescripcionTextBox.Text = presupuesto.Descripcion;
            MontoTextBox.Text = presupuesto.Monto.ToString();
            FechaTextBox.Text = presupuesto.Fecha.ToString("yyyy-MM-dd");// (presupuesto.Fecha.Year +"-"+ fechaMonth +"-"+ fechaDay);
        }

        private void BuscarPresupuesto()
        {
            if (string.IsNullOrEmpty(PresupuestoIdTextBox.Text))
            {
                AsignarTextoAlertaInfo("Digite el id del presupuesto que desea buscar.");
            }
            else
            {
                int id = Utilidades.TOINT(PresupuestoIdTextBox.Text);

                presupuesto = PresupuestosBLL.Buscar(p => p.PresupuestoId == id);

                if (presupuesto != null)
                {

                    DatosPresupuesto();
                }
                else
                {
                    AsignarTextoAlertaInfo("No existe presupuesto con ese id.");
                }
            }
        }

        private Presupuestos LlenarCampos()
        {
            presupuesto.PresupuestoId = Utilidades.TOINT(PresupuestoIdTextBox.Text);
            presupuesto.Descripcion = DescripcionTextBox.Text;
            presupuesto.Monto = Utilidades.TOINT(MontoTextBox.Text);
            presupuesto.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            presupuesto.CategoriaId = Utilidades.TOINT(CategoriaDropDownList.Text);

            return presupuesto;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                presupuesto = LlenarCampos();

                if (PresupuestosBLL.Guardar(presupuesto))
                {
                    PresupuestoIdTextBox.Text = Convert.ToString(presupuesto.PresupuestoId);
                    AsignarTextoAlertaSuccess("Presupuesto guardado con exito.");
                }
                else
                {
                    AsignarTextoAlertaDanger("No se pudo guardar el presupuesto.");
                }
            }
            else
            {
                AsignarTextoAlertaInfo("Por favor llenar los campos vacios");
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            BuscarPresupuesto();
        }

        protected void EnviarAlModalEliminarButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PresupuestoIdTextBox.Text))
            {
                AsignarTextoAlertaInfo("Ingresar el id del presupuesto que desea eliminar.");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "#ModalEliminar", "showModalEliminar();", true);
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(PresupuestoIdTextBox.Text);

            if (PresupuestosBLL.Eliminar(PresupuestosBLL.Buscar(p => p.PresupuestoId == id)))
            {
                Limpiar();
                AsignarTextoAlertaSuccess("Presupuesto eliminado con exito");
            }
            else
            {
                AsignarTextoAlertaDanger("No se pudo eliminar el presupuesto");
            }
        }
    }
}