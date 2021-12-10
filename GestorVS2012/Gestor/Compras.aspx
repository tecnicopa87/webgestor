<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Compras.aspx.vb" Inherits="GestorVS2012.WebForm7" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style type="text/css">
		.encabezado {
			text-align: center;
		}

		.subtitulo {
			text-align: right;
		}

		.style1 {
			height: 51px;
			font-weight: bold;
		}

		.style2 {
			height: 199px;
		}

		.style3 {
			height: 51px;
			width: 95px;
		}

		.style4 {
			height: 199px;
			width: 95px;
		}

		.style5 {
			height: 51px;
			width: 384px;
		}

		.style6 {
			height: 28px;
			width: 95px;
		}

		.style7 {
			height: 28px;
			width: 384px;
		}

		.style8 {
			height: 28px;
		}

		.style9 {
			height: 29px;
			width: 95px;
		}

		.style10 {
			height: 29px;
			width: 384px;
		}

		.style11 {
			height: 29px;
		}

		.style12 {
			height: 29px;
			width: 266px;
		}

		.style13 {
			width: 424px;
		}

		.style14 {
			height: 29px;
			width: 130px;
		}

		.style16 {
			height: 29px;
			width: 424px;
		}

		.style17 {
			height: 28px;
			width: 135px;
		}

		.style18 {
			height: 28px;
			width: 266px;
		}

		.style19 {
			width: 143px;
		}

		.style20 {
			height: 44px;
			width: 143px;
		}

		.style21 {
			width: 648px;
			height: 44px;
		}

		.style22 {
			height: 44px;
		}

		.style23 {
			height: 28px;
			width: 143px;
		}

		.style24 {
			width: 648px;
		}

		.style25 {
			height: 29px;
			width: 648px;
		}
	</style>
	<link href="../../Content/estiloFacturas.css" rel="Stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
	<%--<div class="form-group row">
		<div class="col-md-3"></div>
		<br />
		<div class="encabezado col-md-5">
			<asp:Label ID="LblNombEmp" CssClass="control-label " runat="server" Font-Bold="True" Font-Size="Medium"
				ForeColor="#000066" Text="EMPRESA DEMOSTRACION"></asp:Label>
			<br />
			<asp:Label ID="Label7" CssClass="control-label " runat="server" ForeColor="#000066"
				Text="calle ficticia # 45, Col  Conocida"></asp:Label>
			<br />
		</div>
		<div class="subtitulo col-md-4 col-lg-offset-4">
			<%--&nbsp;<asp:ImageButton ID="ImageButton1" 
                    runat="server" Height="26px" 
                        ImageUrl="~/images/provedors.jpg" Width="59px" />
			<button type="button" class="btn btn-img-cat" data-toggle="modal" data-target="#catProvedores" onclick="cargaClient();">Nuevo Prov</button>
			<asp:TextBox ID="TextCliente" CssClass="form-control " runat="server" Width="183px"></asp:TextBox>
			&nbsp;&nbsp;<asp:Label ID="Label9" CssClass="control-label " runat="server" Font-Bold="True" Font-Size="Medium"
				ForeColor="#660033" Text="Compras Realizadas"></asp:Label>
		</div>
	</div>  --%>
	<div style="margin-left: 30px; margin-right: 30px">
		<div class="panel panel-primary">
			<div class="form-group row">
				<div class="col-md-3"></div>
				<br />
				<div class="encabezado col-md-5">
					<asp:Label ID="LblNombEmp" CssClass="control-label " runat="server" Font-Bold="True" Font-Size="Medium"
						ForeColor="#000066" Text="EMPRESA DEMOSTRACION"></asp:Label>
					<br />
					<asp:Label ID="Label7" CssClass="control-label " runat="server" ForeColor="#000066"
						Text="calle ficticia # 45, Col  Conocida"></asp:Label>
					<br />
				</div>
				<div class="subtitulo col-md-4 ">
					<%--&nbsp;<asp:ImageButton ID="ImageButton1" 
                    runat="server" Height="26px" 
                        ImageUrl="~/images/provedors.jpg" Width="59px" />--%>
					<button type="button" class="btn btn-img-cat" data-toggle="modal" data-target="#catProvedores" onclick="cargaClient();">Nuevo Prov</button>
					<asp:TextBox ID="TextCliente" CssClass="form-control " runat="server" Width="183px"></asp:TextBox>
					&nbsp;&nbsp;<asp:Label ID="Label2" CssClass="control-label " runat="server" Font-Bold="True" Font-Size="Medium"
						ForeColor="#660033" Text="Compras Realizadas"></asp:Label>
				</div>
			</div>
			<div class ="row">
				<div class="col-md-4 ">
				<asp:Button ID="btnCatProductos" CssClass="btn btn-sm " runat="server" Text="Cat productos" Width="111px" Font-Bold="True" ForeColor="#660066" /><asp:Label ID="LblCargProds" runat="server" Font-Bold="True"
					class="control-label" ForeColor="#CC0000" Text="P" Visible="False"></asp:Label>

				<asp:Label ID="LblCompraExitosa" runat="server" Font-Bold="True" ForeColor="#CC99FF" Text="Se registrò su compra exitosamente" Visible="False"></asp:Label>
				<br />
			  </div>
				<div class="col-md-8"></div>
			</div>
			<div class="form-group row">				
				<div class="col-md-1 ">
					<asp:Label ID="Label1" CssClass="control-label " runat="server" Text="Folio:"></asp:Label>
					<asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" Width="65px">
					</asp:DropDownList>
				</div>
				<div class="col-md-4 ">
					<asp:Label ID="Label11" CssClass="control-label " runat="server" Text="Cantidad:"></asp:Label>
					<asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" Width="65px"></asp:TextBox>
					<asp:Label ID="Label12" CssClass="control-label " runat="server" Text="Descripcion :"></asp:Label>
					<asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" Width="211px"></asp:TextBox>

					<script type="text/javascript">
						function Validar() {
							var foo = true;
							var txtcliente = document.getElementById('<%=TextCliente.ClientID%>');

					if (txtcliente.value == "") {
						alert(' Debe seleccionar un destinatario de factura');
						foo = false;

					} else {

						var txtdato1 = document.getElementById('<%=TextBox6.ClientID %>');
                            	var txtdato2 = document.getElementById('<%=txtPrecio.ClientID %>');
                            	if (txtdato1.value == "" || txtdato2.value == "") {
                            		alert(' Se requieren llenar datos minimos para agregar un articulo');
                            		foo = false;
                            	}
                            }
							return foo;
						}
                </script>
				</div>
				<div class="col-md-3  ">					
					<asp:Label ID="Label4" CssClass="control-label " runat="server" Text="Precio:"></asp:Label>
					<asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" Width="59px"></asp:TextBox>

					<asp:Label ID="Label5" CssClass="control-label " runat="server" Text="Importe :"></asp:Label>
					<asp:TextBox ID="txtImporte" CssClass="form-control" runat="server" Width="73px"></asp:TextBox>
					<script type="text/javascript">
						Importe = 0;
						function CalculaImporteArticulo() {
							var foo = true;
							var costo = document.getElementById('<%=txtPrecio.ClientID%>');
					var cantidad = document.getElementById('<%=txtCantidad.ClientID%>');
					Importe = (parseFloat(cantidad.value) * parseFloat(costo.value));//solo en tiempo ejecucion asigna costo.value
					document.getElementById('<%=txtImporte.ClientID%>').innerText = Importe
                    	if (costo.value == "") {
                    		alert(' Debe indicar un costo');
                    		foo = false;

                    	} else {
                    		document.getElementById('<%=txtImporte.ClientID%>').innerText = Importe;
                        	foo = true;
                        }
						return foo;
					}
                </script>
				</div>
				<div class="col-md-3 ">
					<asp:Label ID="LblCodProd" CssClass="control-label " runat="server" Text="|"></asp:Label>
					&nbsp;                              
			<asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" Width="75px">
				<asp:ListItem>pzas</asp:ListItem>
				<asp:ListItem>kg</asp:ListItem>
				<asp:ListItem>ltrs</asp:ListItem>
				<asp:ListItem>cjas</asp:ListItem>
				<asp:ListItem>bols</asp:ListItem>
			</asp:DropDownList>					                     
				</div>
				<div class="col-md-2">
					<br />
					<asp:Button ID="btnIngresar" 
				runat="server" Text="Ingresar" />
				</div>
			</div>
		</div>
	</div>
	<div style="margin-left: 30px; margin-right: 30px">
	<div class="form-group row">
		<%--	<div class="col-md-2 col-md-offset-2">

			<asp:Label ID="Label2" CssClass="control-label " runat="server" Text="Cantidad:"></asp:Label>
			<asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" Width="65px"></asp:TextBox>
			<asp:Label ID="Label3" CssClass="control-label " runat="server" Text="Descripcion :"></asp:Label>
			<asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Width="211px"></asp:TextBox>

			<script type="text/javascript">
				function Validar() {
					var foo = true;
					var txtcliente = document.getElementById('<%=TextCliente.ClientID%>');

                            if (txtcliente.value == "") {
                            	alert(' Debe seleccionar un destinatario de factura');
                            	foo = false;

                            } else {

                            	var txtdato1 = document.getElementById('<%=TextBox2.ClientID %>');
                            	var txtdato2 = document.getElementById('<%=txtPrecio.ClientID %>');
                            	if (txtdato1.value == "" || txtdato2.value == "") {
                            		alert(' Se requieren llenar datos minimos para agregar un articulo');
                            		foo = false;
                            	}
                            }
							return foo;
						}
                </script>
		</div>--%>
		<%--<div class="col-md-4 col-md-offset-2">
			<br />
			<asp:Label ID="Label4" CssClass="control-label " runat="server" Text="Precio:"></asp:Label>
			<asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" Width="59px"></asp:TextBox>
               
			<asp:Label ID="Label5" CssClass="control-label " runat="server" Text="Importe :"></asp:Label>
			<asp:TextBox ID="txtImporte" CssClass="form-control" runat="server" Width="73px"></asp:TextBox>
			<script type="text/javascript">
				Importe = 0;
				function CalculaImporteArticulo() {
					var foo = true;
					var costo = document.getElementById('<%=txtPrecio.ClientID%>');
                        var cantidad = document.getElementById('<%=txtCantidad.ClientID%>');
                    	Importe = (parseFloat(cantidad.value) * parseFloat(costo.value));//solo en tiempo ejecucion asigna costo.value
                    	document.getElementById('<%=txtImporte.ClientID%>').innerText = Importe
                        if (costo.value == "") {
                        	alert(' Debe indicar un costo');
                        	foo = false;

                        } else {
                        	document.getElementById('<%=txtImporte.ClientID%>').innerText = Importe;
                        	foo = true;
                        }
						return foo;
					}
                </script>
		</div>--%>
		<%--	<div class="col-md-2">
			<asp:Label ID="LblCodProd" CssClass="control-label " runat="server" Text="|"></asp:Label>
			&nbsp;                              
			<asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" Width="60px">
				<asp:ListItem>pzas</asp:ListItem>
				<asp:ListItem>kg</asp:ListItem>
				<asp:ListItem>ltrs</asp:ListItem>
				<asp:ListItem>cjas</asp:ListItem>
				<asp:ListItem>bols</asp:ListItem>
			</asp:DropDownList>
			&nbsp;                      
		</div>--%>
		<div class="col-md-3 ">			
			<div style ="margin-left :10px;margin-right:4px">
			<asp:GridView ID="GridView1" CssClass="table-responsive " runat="server" BackColor="White"
				BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3"
				GridLines="Horizontal" Width="100%" AutoGenerateEditButton="True"
				DataKeyNames="id" OnRowUpdating="GridView1_RowUpdating">
				<AlternatingRowStyle BackColor="#F7F7F7" />
				<FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
				<HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
				<PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
				<RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
				<SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
				<SortedAscendingCellStyle BackColor="#F4F4FD" />
				<SortedAscendingHeaderStyle BackColor="#5A4C9D" />
				<SortedDescendingCellStyle BackColor="#D8D8F0" />
				<SortedDescendingHeaderStyle BackColor="#3E3277" />
			</asp:GridView>
			</div>
			<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
			<asp:Label ID="Label6" runat="server" ForeColor="Red" Text=". . ."
				Visible="False"></asp:Label>
			<asp:Button ID="BttnConfirmar" runat="server" Text="Registrar Compra"
				Width="110px" />
			Total:&nbsp;&nbsp;&nbsp;
			<asp:Label ID="Label8" runat="server" Text="$ 0.00"></asp:Label>
			
		</div>
		<div class="col-md-8"></div>
	</div>
	<div class="modal fade" id="catProvedores" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
		<div class="modal-dialog modal-md" role="document">
			<div class="modal-content">
				<script type="text/javascript">
					function cargaClient() {
						$(document).ready(function (e) {
							document.cookie = "ajax-ck=T";
							$.ajax({
								type: "GET",
								url: 'Compras.aspx/ObtenClientesPorClave',
								data: "{}",
								async: true,
								success: function (data) {
									var s = data.lenght;
									//alert('valor[0] :' + data[0].value + ' data:'+data);
								},
								error: function (XMLHttpRequest, textStatus, errorThrown) {
									var error = eval("(" + XMLHttpRequest.responseText + ")");
									alert(error.Message);
								}
							});
						});
					}

                </script>

				<table style="width: 100%; height: 243px;">
					<tr>
						<td class="style18">&nbsp;</td>
						<td class="style16">&nbsp;</td>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td class="style18">
							<label class="etiqueta ">RFC Provedor:</label></td>
						<td class="style16">
							<asp:DropDownList ID="DropDownList3" runat="server" Width="130px"
								AutoPostBack="False">
								<asp:ListItem></asp:ListItem>
								<asp:ListItem>Nuevo RFC</asp:ListItem>
							</asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
								ControlToValidate="DropDownList3" ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator>
							<script>
								function cargaClientRFC() {
									alert('entró a cambiar cookie');
									$(document).ready(function (e) {
										var drp = document.getElementById('<%=DropDownList3.ClientID%>');
										//var drp = $('#DropDownList3').val();
										alert('entró a cambiar cookie' + drp);
										document.cookie = "ajax-ck=" + drp.value;
									});
									}
                </script>
						</td>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td class="style18">
							<label class="etiqueta ">Nombre Provedor:</label></td>
						<td class="style16">
							<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
								ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
						</td>
						<td class="style10"></td>
					</tr>
					<tr>
						<td class="style18">
							<label class="etiqueta">calle y Num.:</label></td>
						<td class="style16">
							<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
								ControlToValidate="TextBox3" ErrorMessage="*"></asp:RequiredFieldValidator>
							&nbsp;
                       
							<asp:TextBox ID="TextBox4" runat="server" Width="69px"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
								ControlToValidate="TextBox4" ErrorMessage="*"></asp:RequiredFieldValidator>
						</td>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td class="style18">
							<label class="etiqueta">Colonia:</label></td>
						<td class="style16">
							<asp:TextBox ID="TextBox11" runat="server" Width="186px"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
								ControlToValidate="TextBox11" ErrorMessage="*"></asp:RequiredFieldValidator>
						</td>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td class="style18">
							<label class="etiqueta">Municipio:</label></td>
						<td class="style16">
							<asp:TextBox ID="TextBox12" runat="server" Width="182px"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
								ControlToValidate="TextBox12" ErrorMessage="*"></asp:RequiredFieldValidator>
						</td>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td class="style18">
							<label class="etiqueta">C.P.</label></td>
						<td class="style16">
							<asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
								ControlToValidate="TextBox14" ErrorMessage="*"></asp:RequiredFieldValidator>
						</td>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td class="style18">&nbsp;</td>
						<td class="style16">&nbsp;</td>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td class="style12">&nbsp;</td>
						<td class="style13">&nbsp;</td>
						<td class="style14">&nbsp;</td>
					</tr>
					<tr>
						<td class="style12"></td>
						<td class="style13">
							<asp:Button ID="ButtonM" runat="server" Text="Aceptar" />
						</td>
						<td class="style17"></td>
					</tr>
				</table>
				<%-- <script type="text/javascript">
                    //var xhr = new XMLHttpRequest();
                    //xhr.open('POST', 'Compras.aspx', true);
                    $(document).ready(function() {
                        $('#DropDownList3').on('');
                        $.ajax({
                            type:"POST",
                            url:'Compras.aspx/ObtenClientesPorClave?'+ $('#DropDownList3').val(),
                            data:null,
                            contentType:"text/html; charset=utf-8",
                            success:
                            });
                    });
                </script>--%>
			</div>
		</div>
	</div>

	<div id="CatProductos" runat="server">
		<table style="width: 100%; height: 243px;">
			<tr>
				<td class="style20">
					<asp:Label ID="Label10" runat="server" Text="Buscar texto:"></asp:Label>
				</td>
				<td class="style21">
					<asp:TextBox ID="TextBox13" runat="server" Width="237px" AutoPostBack="True"></asp:TextBox>
					&nbsp;&nbsp;&nbsp;&nbsp;
                       
					<asp:Button ID="btnBuscaArticulo" runat="server" Text="Buscar" />
				</td>
				<td class="style22"></td>
			</tr>
			<tr>
				<td class="style19">&nbsp;</td>
				<td class="style24">
					<asp:GridView ID="GridView2" runat="server" BackColor="White"
						BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
						AllowPaging="True" PageSize="12" DataKeyNames="codigo" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
						AutoGenerateSelectButton="True" OnPageIndexChanging="GridView2_PageIndexChanging">
						<FooterStyle BackColor="White" ForeColor="#000066" />
						<HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
						<PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
						<RowStyle ForeColor="#000066" />
						<SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
						<SortedAscendingCellStyle BackColor="#F1F1F1" />
						<SortedAscendingHeaderStyle BackColor="#007DBB" />
						<SortedDescendingCellStyle BackColor="#CAC9C9" />
						<SortedDescendingHeaderStyle BackColor="#00547E" />
					</asp:GridView>
				</td>
				<td></td>
			</tr>
			<tr>
				<td class="style23">Encontrados<label class="etiqueta ">:</label></td>
				<td class="style25"></td>
				<td>&nbsp;</td>
			</tr>
		</table>
	</div>
		</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
