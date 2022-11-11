<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="esquema_contable.aspx.cs" Inherits="proyDataFidelis.esquema_contable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
											<h1 class="page-header">Esquema Contable<small>Oct - Dec 2021</small></h1>
											
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
												<table id="data-table-buttons" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">Portafolio</th>
															<th class="text-nowrap">Port.Pictet</th>
															<th class="text-nowrap">Tot Fees (Y)%</th>
															<th class="text-nowrap">TotFees%Q</th>
															<th class="text-nowrap">Total Fees</th>
															<th class="text-nowrap">Fees P.%</th>
															<th class="text-nowrap">Fees P.</th>
															<th class="text-nowrap">Fees SF.%</th>
															<th class="text-nowrap">Fees SF</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
															<td><asp:Label ID="lblNombre" runat="server" Text='<%# Eval("PORTAFOLIO") %>'></asp:Label></td>
																<td><asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" Width="60" Text='<%# Eval("PORT_PICTET") %>'></asp:TextBox> </td>
																<td><asp:Label ID="lblMaterno" runat="server" Text='<%# Eval("TOT_FEES_Y") %>'></asp:Label></td>
																<td><asp:Label ID="lblMarital" runat="server" Text='<%# Eval("TOT_FEES_Q") %>'></asp:Label></td>
																<td><asp:Label ID="lblTipoDoc" runat="server" Text='<%# Eval("TOTAL_FEES") %>'></asp:Label></td>
																<td><asp:Label ID="lblNumDoc" runat="server" Text='<%# Eval("FEES_PP") %>'></asp:Label></td>
																<td><asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"  Width="60" Text='<%# Eval("FEES_P") %>'></asp:TextBox> </td>
																<td><asp:Label ID="lblExpedido" runat="server" Text='<%# Eval("FEES_SF_P") %>'></asp:Label></td>
																<td><asp:Label ID="lblSucursal" runat="server" Text='<%# Eval("FEES_SF") %>'></asp:Label></td>
															<td>
																<asp:ImageButton ID="ibtnActualizar" ImageUrl="~/assets/img/iconos/actualizar.png" OnClick="ibtnActualizar_Click" Height="30"  runat="server" />
															</td>
														</tr>
														</ItemTemplate>
														</asp:Repeater>
														
													
													</tbody>
													<%--<tbody>
															<tr class="gradeA">
																<td><asp:TextBox ID="txtCol11" runat="server" Text="117980.001"></asp:TextBox></td>
																<td><asp:TextBox ID="txtCol21" runat="server" onchange="calcularf1();"></asp:TextBox> </td>
																<td><asp:Label ID="lblCol31" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol41" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol51" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol61" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol71" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol81" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol91" runat="server" Text=""></asp:Label></td>
																<td>
																	<asp:Button ID="btnActivar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("CLI_ID_CLIENTE") %>' OnClick="btnActivar_Click" runat="server" Text="Nuevo" ToolTip="Nueva simulacion" />
																</td>
															</tr>
															<tr class="gradeA">
																<td><asp:TextBox ID="txtCol12" runat="server" Text="123532.001"></asp:TextBox></td>
																<td><asp:TextBox ID="txtCol22" runat="server" ></asp:TextBox> </td>
																<td><asp:Label ID="lblCol32" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol42" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol52" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol62" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol72" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol82" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol92" runat="server" Text=""></asp:Label></td>
																<td>
																	<asp:Button ID="btnActivar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("CLI_ID_CLIENTE") %>' OnClick="btnActivar_Click" runat="server" Text="Nuevo" ToolTip="Nueva simulacion" />
																</td>
															</tr>
															<tr class="gradeA">
																<td><asp:TextBox ID="txtCol13" runat="server" Text="127698.001"></asp:TextBox></td>
																<td><asp:TextBox ID="txtCol23" runat="server"></asp:TextBox> </td>
																<td><asp:Label ID="lblCol33" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol43" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol53" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol63" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol73" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol83" runat="server" Text=""></asp:Label></td>
																<td><asp:Label ID="lblCol93" runat="server" Text=""></asp:Label></td>
																<td>
																	<asp:Button ID="btnActivar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("CLI_ID_CLIENTE") %>' OnClick="btnActivar_Click" runat="server" Text="Nuevo" ToolTip="Nueva simulacion" />
																</td>
															</tr>
													</tbody>--%>
												</table>
											</div>
											<!-- end table-responsive -->
													</div>
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
