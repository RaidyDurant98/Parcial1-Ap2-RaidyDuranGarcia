<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PresupuestoForm.aspx.cs" Inherits="Parcial1_Ap2_RaidyDuran.UI.Registros.PresupuestoForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!--Inclusión de Bootstrap 4.0.0-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css"/>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>

    <title>Registro de Presupuesto</title>
</head>
<body>
    <div class="container-fluid">
        <div class="col-12">
            <h1>Registro de Presupuestos</h1>
            <br />
        </div>
        <!--Formulario-->
        <div class="col-12 col-sm-8 col-md-6 col-lg-5">
            <form id="PresupuestoForm" runat="server">
                <div class="float-right">
                    <asp:Button CssClass="btn btn-dark" ID="BuscarButton" runat="server" Text="Buscar" />
                </div>
                <br />
                <!--Presupuesto Id-->
                <div class="form-group">
                    <asp:Label ID="PresupuestoIdLabel" runat="server" Text="Presupuesto Id:"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="PresupuestoIdTextBox" runat="server" AutoComplete="off"></asp:TextBox>
                </div>
                <!--Descripcion-->
                <div class="form-group">
                    <asp:Label ID="DescripcionLabel" runat="server" Text="Descripcion:"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="DescripcionTextBox" runat="server" AutoComplete="off"></asp:TextBox>
                </div>
                <!--Monto-->
                <div class="form-group">
                    <asp:Label ID="MontoLabel" runat="server" Text="Monto:"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="MontoTextBox" runat="server" AutoComplete="off"></asp:TextBox>
                </div>
                <!--Fecha-->
                <div class="form-group">
                    <asp:Label ID="FechaLabel" runat="server" Text="Fecha:"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="FechaTextBox" runat="server" type="date" AutoComplete="off"></asp:TextBox>
                </div>
                <!--Botones-->
                <div class="text-center">
                    <asp:Button CssClass="btn btn-dark" ID="NuevoButton" runat="server" Text="Nuevo" />
                    <asp:Button CssClass="btn btn-dark" ID="GuardarButton" runat="server" Text="Guardar"/>
                    <asp:Button CssClass="btn btn-dark" ID="EnviarAlModalEliminarButton" runat="server" Text="Eliminar"/>
                </div>
                <!--Modal de confirmacion de eliminar-->
                <div class="modal" id="ModalEliminar">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content ">
                            <div class="modal-header bg-secondary">
                                <h5 class="modal-title">¡Atencion!</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <p>Esta seguro de eliminar este usuario?</p>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="EliminarButton" runat="server" CssClass="btn btn-secondary" Text="Si"/>
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                            </div>
                        </div>
                    </div>
                </div><!--Fin Modal-->
            </form>
            <br />
            <!--Alertas-->
            <asp:Panel CssClass="alert alert-success text-center" ID="AlertSuccessPanel"  role="alert" runat="server">
                <asp:Label ID="AlertSuccessLabel" runat="server" Text=""></asp:Label>
            </asp:Panel>
            <asp:Panel CssClass="alert alert-info text-center" ID="AlertInfoPanel" role="alert" runat="server">
                <asp:Label ID="AlertInfoLabel" runat="server" Text=""></asp:Label>
            </asp:Panel>
            <asp:Panel CssClass="alert alert-danger text-center" ID="AlertDangerPanel" role="alert" runat="server">
                <asp:Label ID="AlertDangerLabel" runat="server" Text=""></asp:Label>
            </asp:Panel>
            <asp:Panel CssClass="alert alert-Warnig text-center" ID="AlertWarningPanel" role="alert" runat="server">
                <asp:Label ID="AlertWarningLabel" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </div><!--Col formulario-->
    </div><!--Container-fluid-->
</body>
</html>
