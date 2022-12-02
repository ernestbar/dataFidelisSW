<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="cuentas_admin.aspx.cs" Inherits="proyDataFidelis.cuentas_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:ObjectDataSource ID="odsClientes" runat="server" SelectMethod="PR_SEG_GET_CLIENTES" TypeName="proyDataFidelis.Clases.Clientes">
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsCuentas" runat="server" SelectMethod="Lista" TypeName="proyDataFidelis.Clases.Cuentas">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIDCliente" Name="CLI_ID_CLIENTE" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	
	<asp:ObjectDataSource ID="odsCasoUso" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="proyDataFidelis.Clases.Dominios">
		<SelectParameters>
            <asp:Parameter Name="PV_DOMINIO" DefaultValue="CASO USO" />
        </SelectParameters>
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsBanco" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="proyDataFidelis.Clases.Dominios">
		<SelectParameters>
            <asp:Parameter Name="PV_DOMINIO" DefaultValue="BANCO" />
        </SelectParameters>
		</asp:ObjectDataSource>
	
	<style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .ErrorControl
        {
            background-color: #FBE3E4;
            border: solid 1px Red;
        }
    </style>
	<script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                for (var i in Page_Validators) {
                    try {
                        var control = document.getElementById(Page_Validators[i].controltovalidate);
                        if (!Page_Validators[i].isvalid) {
                            control.className = "form-control ErrorControl";
                        } else {
                            control.className = "form-control";
                        }
                    } catch (e) { }
                }
                return false;
            }
            return true;
        }
    </script>
	<!-- begin #content -->
		<div id="content" class="content">
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblIDCliente" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCuenta" runat="server" Text="3" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn-sm btn-info btn-block" OnClick="btnNuevo_Click" runat="server" Text="Nueva Cuenta" />
												 <asp:Button ID="btnVolverClientes" class="btn-sm btn-info btn-block" OnClick="btnVolverClientes_Click" runat="server" Text="Volver a Clientes" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Adminitración de Cuentas</h1>
			Cliente:
										<asp:Label ID="lblClienteNombreTitulo" runat="server" Text=""></asp:Label>
											<!-- end page-header -->
											<!-- begin panel -->
											<div class="panel panel-inverse">
												<!-- begin panel-heading -->
												<div class="panel-heading">
													<div class="panel-heading-btn">
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-redo"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
													</div>
													<h4 class="panel-title">Registros</h4>
												</div>
												<!-- end panel-heading -->
												
												<div class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">CUENTA</th>
															<th class="text-nowrap">CLIENTE</th>
															<th class="text-nowrap">FECHA INGRESO</th>
															<th class="text-nowrap">FECHA SALIDA</th>
															<th class="text-nowrap">CASO USO</th>
															<th class="text-nowrap">BANCO</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsCuentas" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
															<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("CUENTA") %>'></asp:Label></td>
															<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("CLI_RAZON_SOCIAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto" runat="server" Text='<%# Eval("FECHA_INGRESO") %>'></asp:Label></td>
															<td><asp:Label ID="lblValor" runat="server" Text='<%# Eval("FECHA_SALIDA") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("DESC_CASO_USO") %>'></asp:Label></td>
																<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("DESC_BANCO") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnEditar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("CUENTA") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("CUENTA") +"|"+Eval("FECHA_INGRESO") %>' OnClick="btnEliminar_Click" runat="server" Text="Dar de Baja" ToolTip="Borrar registro" />
                                                                
																<%--<asp:Button ID="btnActivar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("CLI_ID_CLIENTE") %>' OnClick="btnActivar_Click" runat="server" Text="Nuevo" ToolTip="Nueva simulacion" />--%>
															</td>
															
															
														</tr>
														</ItemTemplate>
														</asp:Repeater>
														
													
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
													</div>
										</div>
        </asp:View>
		 <asp:View ID="View2" runat="server">
			<!-- begin row -->
			<div class="row">
				<!-- begin col-8 -->
				<div class="col-md-6 offset-md-2">
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos Cuenta</legend>
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Cliente:</label>
						<div class="col-md-6">
                            <asp:Label ID="lblNombreCliente" runat="server" Text=""></asp:Label>
						</div>
					</div>
					<!-- end form-group row -->
					<asp:Panel ID="Panel_alta" runat="server">
						<!-- begin form-group row -->
						<div class="form-group row m-b-10">
							<label class="col-md-3 text-md-right col-form-label">Cuenta:</label>
							<div class="col-md-6">
								 <asp:TextBox ID="txtCuenta" class="form-control" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCuenta" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
						</div>
						<!-- end form-group row -->
					
					
					<!-- begin form-group row -->
						<div class="form-group row m-b-10">
							<label class="col-md-3 text-md-right col-form-label">Caso de Uso:</label>
							<div class="col-md-6">
								<asp:DropDownList ID="ddlCasoUso" class="form-control"  DataSourceID="odsCasoUso" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlCasoUso_DataBound" runat="server"></asp:DropDownList>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCasoUso" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
						</div>
						<!-- end form-group row -->
					</asp:Panel>
					
					<asp:Panel ID="Panel_edicion" runat="server">
						<!-- begin form-group row -->
						<div class="form-group row m-b-10">
							<label class="col-md-3 text-md-right col-form-label">Fecha desde:</label>
							<div class="col-md-6">
								<asp:Label ID="lblFechaDesde" Visible="false" runat="server" Text=""></asp:Label>
								<input id="fecha_salida" class="form-control" style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaSalida" runat="server" />
							</div>
						</div>
						<!-- end form-group row -->
						<!-- begin form-group row -->
						<div class="form-group row m-b-10">
							<label class="col-md-3 text-md-right col-form-label">Banco:</label>
							<div class="col-md-6">
								<asp:DropDownList ID="ddlBanco" class="form-control"  DataSourceID="odsBanco" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlBanco_DataBound" runat="server"></asp:DropDownList>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlBanco" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
						</div>
						<!-- end form-group row -->
					</asp:Panel>
					
					<asp:Panel ID="Panel_baja" Visible="false" runat="server">
							<!-- begin form-group row -->
							<div class="form-group row m-b-10">
								<label class="col-md-3 text-md-right col-form-label">Fecha de baja de la cuenta:</label>
								<div class="col-md-6">
									<asp:Label ID="lblFechaHasta" Visible="false" runat="server" Text=""></asp:Label>
									<input id="fecha_retorno" class="form-control"  style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaRetorno" runat="server" />
								</div>
							</div>
							<!-- end form-group row -->
					</asp:Panel>
				
					
					
					
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-success" OnClientClick="recuperarFechaSalida()" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
							<asp:Button ID="btnVolverAlta" CssClass="btn btn-success"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancelar" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
			
        </asp:View>
    </asp:MultiView>
	
			
		</div>
		<!-- end #content -->
		<script type="text/javascript">

			function recuperarFechaSalida() {

                if (document.getElementById('fecha_salida').visiblity = 'visible') {
                    document.getElementById('<%=hfFechaSalida.ClientID%>').value = document.getElementById('fecha_salida').value;
				}

                if (document.getElementById("fecha_retorno").visiblity = "visible") {
                    document.getElementById('<%=hfFechaRetorno.ClientID%>').value = document.getElementById('fecha_retorno').value;
                }
				
			}

			function setearFechaSalida() {
				document.getElementById('fecha_salida').value = document.getElementById('<%=hfFechaSalida.ClientID%>').value;
			}

			function setearFechaRetorno() {
				document.getElementById('fecha_retorno').value = document.getElementById('<%=hfFechaRetorno.ClientID%>').value;
            }
        </script>
</asp:Content>
