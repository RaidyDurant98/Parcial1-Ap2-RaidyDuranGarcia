<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PresupuestosConsulta.aspx.cs" Inherits="Parcial1_Ap2_RaidyDuran.UI.Consultas.PresupuestosConsulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!--Inclusión de Bootstrap 4.0.0-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css"/>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>

    <title>Consulta de Presupuestos</title>
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
                <a class="nav-item nav-link active" href="PresupuestosConsulta.aspx">Presupuestos</a>
                <a class="nav-item nav-link" href="../Registros/CategoriasForm.aspx">Categorias</a>
            </div>
        </div>
    </nav>
    <br />
    <div class="container-fluid">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link " href="../Registros/PresupuestoForm.aspx">Registro</a>
            </li>
            <li class="nav-item">
                <a class="nav-link active" href="PresupuestosConsulta.aspx">Consulta</a>
            </li>
        </ul>

        <div class="container-fluid">
            <div class="text-center">
                <h1>Consulta de presupuestos</h1>
                <br />
            </div>
        </div>

        <form id="PresupuestoForm" runat="server">
            <div class="container">
                <!--DropDowmList y TextBox-->
                <div class="row">
                    <div class="col-12 col-sm-5">
                        <asp:DropDownList CssClass="form-control" ID="FiltrarDropDownList" runat="server">
                            <asp:ListItem>Todo</asp:ListItem>
                            <asp:ListItem>ID</asp:ListItem>
                            <asp:ListItem>Fecha</asp:ListItem>
                            <asp:ListItem>Categoria</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-12 col-sm-7">
                        <asp:TextBox CssClass="form-control" ID="FiltroTextBox" runat="server" autoComplete="off"></asp:TextBox> 
                    </div>
                </div><!--Row DropDowmList y textbox-->
                <!--TextBox Fecha-->
                <div class="row">
                    <div class="form-group col-12 col-sm-6">
                        <asp:Label ID="DesdeLabel" runat="server" Text="Desde:" CssClass=""></asp:Label>
                        <asp:TextBox CssClass="form-control" type="date" ID="FechaDesdeTextBox" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-12 col-sm-6">
                        <asp:Label ID="HastaLabel" runat="server" Text="Hasta:"></asp:Label>
                        <asp:TextBox CssClass="form-control" type="date" ID="FechaHastaTextBox" runat="server"></asp:TextBox>
                    </div>
                </div><!--Row Fecha-->
                <!--GridView-->
                <div class="container">
                    <div class="col-12">
                        <!--Alertas-->
                        <div class="float-left col-sm-5">
                            <asp:Panel CssClass="alert alert-info text-center" ID="AlertInfoPanel" role="alert" runat="server">
                                <asp:Label ID="AlertInfoLabel" runat="server" Text=""></asp:Label>
                            </asp:Panel>
                            <asp:Panel CssClass="alert alert-success text-center" ID="AlertSuccessPanel"  role="alert" runat="server">
                                <asp:Label ID="AlertSuccessLabel" runat="server" Text=""></asp:Label>
                            </asp:Panel>
                            <asp:Panel CssClass="alert alert-danger text-center" ID="AlertDangerPanel" role="alert" runat="server">
                                <asp:Label ID="AlertDangerLabel" runat="server" Text=""></asp:Label>
                            </asp:Panel>
                        </div>
                        <br />
                        <br />
                        <div class="float-right">
                            <asp:Button CssClass="btn btn-dark" ID="FiltroButton" runat="server" Text="Filtrar" OnClick="FiltroButton_Click"/>
                        </div>
                        <asp:GridView CssClass="table table-responsive table-hover" BorderStyle="None" ID="PresupuestoConsultaGridView" runat="server" 
                            AutoGenerateColumns="False" GridLines="Horizontal" DataKeyNames="PresupuestoId,Descripcion" ShowFooter="true">
                            <HeaderStyle CssClass="bg-dark text-white"/>
                            <Columns>
                                <asp:BoundField DataField="Presupuestoid" HeaderText="Presupuesto Id"/>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"/>
                                <asp:BoundField DataField="CategoriaId" HeaderText="Categoria"/>
                                <asp:BoundField DataField="Fecha" DataFormatString="{0:d}" HeaderText="Fecha Inscripcion"/>   
                                <asp:BoundField DataField="Monto" HeaderText="Monto"/>
                            </Columns>
                            <FooterStyle CssClass="bg-dark"/>
                        </asp:GridView> 
                        <div class="float-left">
                            <asp:Button CssClass="btn btn-dark" ID="ImprimirButton" runat="server" CommandName="Select" Text="Imprimir" OnClick="ImprimirButton_Click"/>
                        </div>    
                        <div class="float-right">
                            <asp:Label ID="TotalLabel" runat="server"><strong>Total:</strong></asp:Label>
                            <asp:Label ID="TotalMontoLabel" runat="server" Font-Size="X-Large"><strong>0.0</strong></asp:Label>
                        </div>
                    </div>
                </div><!--Div grid view-->
            </div><!--Container-->
        </form>
    </div> 
</body>
</html>
