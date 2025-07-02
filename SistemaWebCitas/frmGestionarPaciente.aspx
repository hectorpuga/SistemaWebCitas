<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmGestionarPaciente.aspx.cs" Inherits="SistemaWebCitas.frmGestionarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- ⚠️ Aquí colocamos el Literal donde se renderiza correctamente el JS -->
    <asp:Literal ID="litMensaje" runat="server" EnableViewState="false" />

    <section class="content-header">
        <h1 style="text-align: center">REGISTRO DE PACIENTES</h1>
    </section>

    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">

                        <div class="form-group">
                            <label>DOCUMENTO DE IDENTIDAD</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNroDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>NOMBRES</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>APELLIDO PATERNO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtApPaterno" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>APELLIDO MATERNO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtApMaterno" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">

                        <div class="form-group">
                            <label>SEXO</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlSexo" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label>EDAD</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>TELEFONO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>DIRECCION</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button Width="200px" ID="btnRegistrar" CssClass="btn btn-primary" Text="Registrar" runat="server" OnClick="btnRegistrar_Click" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp</td>
                    <td>
                        <asp:Button ID="btnCancelar" Width="200px" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                    </td>
                </tr>
            </table>
        </div>

        <br />

        <!-- Tabla con DataTable -->
        <div class="row">
            <div class="col-xs-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Lista de Pacientes</h3>
                    </div>
                    <div class="box-body table-responsive">
                        <table id="tbl_pacientes" class="table">
                            <thead>
                                <tr>
                                    <th>Codigo</th>
                                    <th>Nombres</th>
                                    <th>Apellidos</th>
                                    <th>Sexo</th>
                                    <th>Edad</th>
                                    <th>Direccion</th>
                                    <th>Estado</th>
                                </tr>
                            </thead>
                            <tbody id="tbl_body_table">
                                <!-- AJAX data -->
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

    </section>

</asp:Content>
