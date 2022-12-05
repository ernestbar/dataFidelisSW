<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="caso_uno.aspx.cs" Inherits="proyDataFidelis.caso_uno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	 <asp:ObjectDataSource ID="odsBanco" runat="server" SelectMethod="PR_GET_BANCOS" TypeName="proyDataFidelis.Clases.Dominios">
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsCuenta" runat="server" SelectMethod="PR_GET_CUENTASCLIENTES" TypeName="proyDataFidelis.Clases.Cuentas">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlBanco" Name="PV_BANCO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTrimestre" runat="server" SelectMethod="PR_GET_TRIMESTRES" TypeName="proyDataFidelis.Clases.Utiles">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlCuenta" Name="PV_CUENTA" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <!-- begin #content -->
		<div id="content" class="content">
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblDominio" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodigo" runat="server" Text="3" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
										
										<!-- begin page-header -->
											<h1 class="page-header">Portafolios Caso 1<small></small></h1>
											Banco:
											<asp:DropDownList ID="ddlBanco" class="form-control col-md-6" AutoPostBack="true" DataSourceID="odsBanco" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlBanco_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlBanco" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
											Cuenta:
											<asp:DropDownList ID="ddlCuenta" class="form-control col-md-6" AutoPostBack="true" DataSourceID="odsCuenta" DataTextField="cliente" DataValueField="cuenta" OnDataBound="ddlCuenta_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCuenta" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
											Trimestre:
											<asp:DropDownList ID="ddlTrimestre" class="form-control col-md-6" AutoPostBack="true" DataSourceID="odsTrimestre" DataTextField="TRIMESTRE" DataValueField="CODIGO" OnDataBound="ddlTrimestre_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCuenta" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
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
										</div>
									<!-- begin form-group row -->
										<div class="form-group row m-b-12">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnConsultar" class="btn-sm btn-info btn-block" OnClick="btnConsultar_Click" runat="server" Text="Consultar" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
        </asp:View>
		<asp:View ID="View2" runat="server">
								<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnVolver" class="btn-sm btn-info btn-block" OnClick="btnVolver_Click" runat="server" Text="Volver" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
						<!-- begin form-group row -->
					<div class="form-group row m-b-12">
						<label class="col-md-3 text-md-right col-form-label">FEE SF (%):</label>
						<div class="col-md-1">
                             <asp:TextBox ID="txtFEEFS" class="form-control" Text="0" runat="server"></asp:TextBox>
						</div>
							<label class="col-md-3 text-md-right col-form-label">FEE BANCO ($):</label>
						<div class="col-md-1">
                             <asp:TextBox ID="txtFEEBANCO" class="form-control" Text="0" runat="server"></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
			<div class="table-responsive">
				<!-- begin panel-body -->
				<div class="panel-body">
				<%--<div class="table-responsive">--%>
				<table id="data-table-default1" class="table table-striped table-bordered" style="width:600px">
					<thead>
						<tr>
							<th class="text-nowrap" style="width:100px">Período</th>
							<th class="text-nowrap" style="width:100px">Portafolio Valor</th>
							<th class="text-nowrap" style="width:40px">Fees L.</th>
							<th class="text-nowrap" style="width:100px">Fees Q.</th>
							<th class="text-nowrap" data-orderable="false">OPCIONES</th>
							</tr>
					</thead>
					<tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
						<ItemTemplate>
							<tr class="gradeA">
							<td><asp:Label ID="lblNombre" runat="server" Text='<%# Eval("PERIODO") %>'></asp:Label></td>
								<td><asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" Width="100" Text='<%# Eval("PORTAFOLIO_VAL") %>'></asp:TextBox> </td>
								<td><asp:Label ID="lblMaterno" runat="server" Text='<%# Eval("FEES_L") %>'></asp:Label></td>
								<td><asp:Label ID="lblMarital" runat="server" Text='<%# Eval("FEES_Q") %>'></asp:Label></td>
							<td>
								<asp:ImageButton ID="ibtnActualizar" ImageUrl="~/assets/img/iconos/actualizar.png" OnClick="ibtnActualizar_Click" Height="30"  runat="server" ToolTip="Actualizar" />
							</td>
						</tr>
						</ItemTemplate>
						</asp:Repeater>
														
													
					</tbody>
													
				</table>
			</div>
			<!-- end table-responsive -->
			</div>
			<div class="table-responsive">
				<!-- begin panel-body -->
				<div class="panel-body">
				<%--<div class="table-responsive">--%>
				<table id="data-table-default2" class="table table-striped table-bordered" style="width:600px">
					<thead>
						<tr>
							<th class="text-wrap" style="width:50px">CUENTA</th>
							<th class="text-nowrap" style="width:100px">FEES FS</th>
						</tr>
					</thead>
					<tbody>
                        <asp:Repeater ID="Repeater2" runat="server">
						<ItemTemplate>
							<tr class="gradeA">
							<td><asp:Label ID="lblNombre" runat="server" Text='<%# Eval("CUENTA") %>'></asp:Label></td>
								<td><asp:Label ID="lblMaterno" runat="server" Text='<%# Eval("FEES_SF") %>'></asp:Label></td>
							</td>
						</tr>
						</ItemTemplate>
						</asp:Repeater>
														
													
					</tbody>
													
				</table>
			</div>
			<!-- end table-responsive -->
			</div>
		</asp:View>
    </asp:MultiView>
	
			
		</div>
		<!-- end #content -->
	<script type="text/javascript">

		<%--function calcularf1() {

            var x = document.getElementById('<%=txtCol11.ClientID%>');
            var y = document.getElementById('<%=txtCol21.ClientID%>');
            document.getElementById('<%=lblCol31.ClientID%>').innerHTML = y.value/x.value;
		}--%>
        <%--function setearFechaSalida() {
            document.getElementById('fecha_salida').value = document.getElementById('<%=hfFechaSalida.ClientID%>').value;
		}
        function setearFechaRetorno() {
            document.getElementById('fecha_retorno').value = document.getElementById('<%=hfFechaRetorno.ClientID%>').value;
        }--%>
    </script>
</asp:Content>
