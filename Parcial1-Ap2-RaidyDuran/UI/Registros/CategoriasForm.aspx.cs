using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1_Ap2_RaidyDuran.UI.Registros
{
    public partial class CategoriasForm : System.Web.UI.Page
    {
        private Categorias Categoria = new Categorias();

        protected void Page_Load(object sender, EventArgs e)
        {
            AlertSuccessPanel.Visible = false;
            AlertInfoPanel.Visible = false;
            AlertDangerPanel.Visible = false;
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
            CategoriaIdTextBox.Text = "";
            DescripcionTextBox.Text = "";
        }

        private bool Validar()
        {
            bool interruptor = true;

            if (string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                interruptor = false;
            }

            return interruptor;
        }

        private void DatosPresupuesto()
        {
            DescripcionTextBox.Text = Categoria.Descripcion;
        }

        private void BuscarCategoria()
        {
            if (string.IsNullOrEmpty(CategoriaIdTextBox.Text))
            {
                AsignarTextoAlertaInfo("Digite el id de la categoria que desea buscar.");
            }
            else
            {
                int id = Utilidades.TOINT(CategoriaIdTextBox.Text);

                Categoria = CategoriasBLL.Buscar(p => p.CategoriaId == id);

                if (Categoria != null)
                {

                    DatosPresupuesto();
                }
                else
                {
                    AsignarTextoAlertaInfo("No existe categoria con ese id.");
                }
            }
        }

        private Categorias LlenarCampos()
        {
            Categoria.CategoriaId = Utilidades.TOINT(CategoriaIdTextBox.Text);
            Categoria.Descripcion = DescripcionTextBox.Text;

            return Categoria;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validar())
            {             
                if (CategoriasBLL.Guardar(LlenarCampos()))
                {
                    CategoriaIdTextBox.Text = Convert.ToString(Categoria.CategoriaId);
                    AsignarTextoAlertaSuccess("Categoria guardada con exito.");
                }
                else
                {
                    AsignarTextoAlertaDanger("No se pudo guardar la categoria.");
                }
            }
            else
            {
                AsignarTextoAlertaInfo("Por favor llenar los campos vacios");
            }
        }

        protected void EnviarAlModalEliminarButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CategoriaIdTextBox.Text))
            {
                AsignarTextoAlertaInfo("Ingresar el id de la categoria que desea eliminar.");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "#ModalEliminar", "showModalEliminar();", true);
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(CategoriaIdTextBox.Text);

            if (CategoriasBLL.Eliminar(CategoriasBLL.Buscar(p => p.CategoriaId == id)))
            {
                Limpiar();
                AsignarTextoAlertaSuccess("Categoria eliminada con exito");
            }
            else
            {
                AsignarTextoAlertaDanger("No se pudo eliminar la categoria");
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            BuscarCategoria();
        }
    }
}