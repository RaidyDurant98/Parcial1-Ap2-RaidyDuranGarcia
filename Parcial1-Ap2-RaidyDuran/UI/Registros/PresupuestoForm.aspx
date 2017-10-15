<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PresupuestoForm.aspx.cs" Inherits="Parcial1_Ap2_RaidyDuran.UI.Registros.PresupuestoForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!--Inclusión de Bootstrap 4.0.0-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css"/>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>

    <!--Inclusion de Scripts personales-->
    <script src="../../Scripts/Scripts.js"></script>

    <title>Registro de Presupuesto</title>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <a class="navbar-brand" href="#">Parcial1-Ap2-RaidyDuran</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
            <div class="navbar-nav">
                <a class="nav-item nav-link" href="#">Inicio <span class="sr-only">(current)</span></a>
                <a class="nav-item nav-link active" href="PresupuestoForm.aspx">Presupuestos</a>
                <a class="nav-item nav-link" href="CategoriasForm.aspx">Categorias</a>
            </div>
        </div>
    </nav>
    <br />
    <div class="container-fluid">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" href="PresupuestoForm.aspx">Registro</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="../Consultas/PresupuestosConsulta.aspx">Consulta</a>
            </li>
        </ul>

        <div class="col-12">
            <h1>Registro de Presupuestos</h1>
            <br />
        </div>
        <!--Formulario-->
        <div class="col-12 col-sm-8 col-md-6 col-lg-5">
            <form id="PresupuestoForm" runat="server">
                <div class="float-right">
                    <asp:Button CssClass="btn btn-dark" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click"/>
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
                    <asp:TextBox CssClass="form-control" ID="DescripcionTextBox" runat="server" AutoComplete="off" Height="100px"></asp:TextBox>
                </div>
                <!--Monto-->
                <div class="form-group">
                    <asp:Label ID="MontoLabel" runat="server" Text="Monto:"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="MontoTextBox" runat="server" AutoComplete="off"></asp:TextBox>
                </div>
                <!--Categoria-->
                <div class="form-group">
                    <asp:Label ID="CategoriaLabel" runat="server" Text="Categoria:"></asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="CategoriaDropDownList" runat="server"></asp:DropDownList>
                </div>
                <!--Fecha-->
                <div class="form-group">
                    <asp:Label ID="FechaLabel" runat="server" Text="Fecha:"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="FechaTextBox" runat="server" TextMode="date" AutoComplete="off"></asp:TextBox>
                </div>
                <!--Botones-->
                <div class="text-center">
                    <asp:Button CssClass="btn btn-dafault" ID="NuevoButton" runat="server" Text="Nuevo"/>
                    <asp:Button CssClass="btn btn-primary" ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click"/>
                    <asp:Button CssClass="btn btn-danger" ID="EnviarAlModalEliminarButton" runat="server" Text="Eliminar" OnClick="EnviarAlModalEliminarButton_Click"/>
                </div>
                <!--Modal de confirmacion de eliminar-->
                <div class="modal" id="ModalEliminar">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content ">
                            <div class="modal-header bg-Primary">
                                <h5 class="modal-title">¡Atencion!</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <p>Esta seguro de eliminar este usuario?</p>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="EliminarButton" runat="server" CssClass="btn btn-secondary" Text="Si" OnClick="EliminarButton_Click"/>
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
