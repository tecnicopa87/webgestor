<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AltaProductos_.aspx.vb" Inherits="GestorVS2012.WebForm11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

	<div class="form-group">
		<%--<div class="col-md-8 form-control">--%>
		<asp:Label ID="Label1" CssClass="control-label col-md-4" runat="server" Text="Codigo"></asp:Label>
		<div class="col-md-8">
			<asp:TextBox ID="txtcodigo" CssClass="form-control" runat="server" Text='<%# Eval("codigo") %>'></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredValidator1" runat="server" ControlToValidate="txtcodigo" ErrorMessage="*" ForeColor="#CC0066"></asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtcodigo" ErrorMessage="solo alfanumericos" ForeColor="#CC0066" ValidationExpression="^[0-9a-zA-Z]+$"></asp:RegularExpressionValidator>
		</div>
	</div>
	<div class="form-group">
		<asp:Label ID="Label2" CssClass="control-label col-md-4" runat="server" Text="Descripcion"></asp:Label>
		<div class="col-md-8">
			<asp:TextBox ID="txtproducto" CssClass="form-control" runat="server" Text='<%# Eval("producto") %>'></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredValidator2" runat="server" ControlToValidate="txtproducto" ErrorMessage=" *" ForeColor="Red"></asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtproducto" ErrorMessage="no se aceptan caracteres especiales " ForeColor="#FF3300" ValidationExpression="^[0-9a-zA-Z ]+$"></asp:RegularExpressionValidator>
		</div>
	</div>
	<div class="form-group">
		<asp:Label ID="Label3" CssClass="control-label col-md-2" runat="server" Text="Precio"></asp:Label>
		<div class="col-md-4">
			<asp:TextBox ID="txtprecio" CssClass="form-control " runat="server" Width="30%" Text='<%# Eval("precio") %>'></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredValidator3" runat="server" ControlToValidate="txtprecio" ErrorMessage=" *" ForeColor="Red"></asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtprecio" ErrorMessage="solo numericos" ForeColor="#CC0066" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
			<br />
		</div>
		<asp:Label ID="Label4" CssClass="control-label col-sm-2" runat="server" Text="Precio2"></asp:Label>
		<div class="col-md-4">
			<asp:TextBox ID="txtprecio2" CssClass="form-control " runat="server" Width="30%" Text='<%# Eval("precio2") %>'></asp:TextBox>
			<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtprecio2" ErrorMessage="solo numericos" ForeColor="#CC0066" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
		</div>
	</div>
	<div class="form-group">
		<asp:Label ID="Label5" CssClass="control-label col-sm-2" runat="server" Text="CveProv"></asp:Label>
		<div class="col-md-4">
			<asp:DropDownList ID="drpCveProv" CssClass="form-control" runat="server">
				<asp:ListItem>Abarrotes</asp:ListItem>
				<asp:ListItem>Farmacia</asp:ListItem>
				<asp:ListItem>Tlapaleria</asp:ListItem>
				<asp:ListItem>Dulces</asp:ListItem>
			</asp:DropDownList>
			<br />
		</div>
		<asp:Label ID="Label11" CssClass="control-label col-sm-2" runat="server" Text="Granel"></asp:Label>
		<div class="col-md-4">
			<asp:CheckBox ID="CheckBox1" CssClass="form-control " runat="server" />
			<br />
		</div>
	</div>
	<div class="form-group">
		<asp:Label ID="Label6" CssClass="control-label col-sm-2" runat="server" Text="Costo"></asp:Label>
		<div class="col-md-4">
			<asp:TextBox ID="txtcosto" CssClass="form-control " runat="server" Width="30%" Text='<%# Eval("costo") %>'></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredValidator4" runat="server" ControlToValidate="txtcosto" ErrorMessage=" *" ForeColor="Red"></asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtcosto" ErrorMessage="solo numericos" ForeColor="#CC0066" ValidationExpression="^[\d]+[\.]*[\d]$"></asp:RegularExpressionValidator>
		</div>
		<asp:Label ID="Label7" CssClass="control-label col-sm-2" runat="server" Text="Utilidad"></asp:Label>
		<div class="col-md-4">
			<asp:TextBox ID="txtUtilidad" CssClass="form-control " runat="server" Width="30%" Text='<%# Eval("utilidad") %>'></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUtilidad" ErrorMessage=" *" ForeColor="Red"></asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtUtilidad" ErrorMessage="solo numericos" ForeColor="#CC0066" ValidationExpression="^[\d]+[\.]*[\d]$"></asp:RegularExpressionValidator>
		</div>
	</div>
	<div class="form-group">
		<asp:Label ID="Label8" CssClass="control-label col-sm-2" runat="server" Text="IVA"></asp:Label>
		<div class="col-md-4">
			<asp:TextBox ID="txtIVA" CssClass="form-control" runat="server" Text='<%# Eval("iva") %>' Width="30%"></asp:TextBox>
			&nbsp;<asp:Label ID="Label10" CssClass="control-label col-sm-4" runat="server" Text="IEPS"></asp:Label><asp:TextBox ID="txtIEPS" CssClass="form-control" runat="server" Text='<%# Eval("ieps") %>' Width="30%"></asp:TextBox>
			<br />
		</div>
		<asp:Label ID="Label9" CssClass="control-label col-sm-2" runat="server" Text="Unidad"></asp:Label>
		<div class="col-md-4">
			<asp:DropDownList ID="drpUnidad" CssClass="form-control" Width="30%" runat="server">
				<asp:ListItem>pza</asp:ListItem>
				<asp:ListItem>kg</asp:ListItem>
				<asp:ListItem>litro</asp:ListItem>
				<asp:ListItem>metros</asp:ListItem>
			</asp:DropDownList>
		</div>
	</div>

	<div>
		<table style="width: 100%;">
			<tr>
				<td class="auto-style1">&nbsp;</td>
				<td>
					<asp:FormView ID="FormView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" DataSourceID="SqlDataSourceP" AllowPaging="True">
						<EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
						<FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
						<HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
						<ItemTemplate>
							<asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label>
							<asp:TextBox ID="txtcodigo" runat="server" Text='<%# Eval("codigo") %>'></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcodigo" ErrorMessage=" *" ForeColor="Red"></asp:RequiredFieldValidator>
							Descripcion<asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("producto") %>'></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
							Precio
							<asp:TextBox ID="TextBox2" runat="server" Width="85px" Text='<%# Eval("precio") %>'></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
							<br />
							Precio2
							<asp:TextBox ID="TextBox3" runat="server" Width="74px" Text='<%# Eval("precio2") %>'></asp:TextBox>
							<br />
							CveProv
							<asp:DropDownList ID="DropDownList1" runat="server">
								<asp:ListItem>Abarrotes</asp:ListItem>
								<asp:ListItem>Farmacia</asp:ListItem>
								<asp:ListItem>Tlapaleria</asp:ListItem>
								<asp:ListItem>Dulces</asp:ListItem>
							</asp:DropDownList>
							&nbsp; Granel
							<asp:CheckBox ID="CheckBox1" Text="Granel" runat="server" />
							<br />
							Costo
							<asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("costo") %>' Width="71px"></asp:TextBox>
							&nbsp;utilidad
							<asp:TextBox ID="TextBox5" runat="server" Width="94px"></asp:TextBox>
							<br />
							IVA
							<asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("iva") %>' Width="70px"></asp:TextBox>
							&nbsp; IEPS<asp:TextBox ID="TextBox7" runat="server" Text='<%# Eval("ieps") %>' Width="81px"></asp:TextBox>
							<br />
							Unidad
							<asp:DropDownList ID="DropDownList2" runat="server">
								<asp:ListItem>pza</asp:ListItem>
								<asp:ListItem>kg</asp:ListItem>
								<asp:ListItem>litro</asp:ListItem>
								<asp:ListItem>metros</asp:ListItem>
							</asp:DropDownList>
						</ItemTemplate>
						<InsertItemTemplate>

							<asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label>
							<asp:TextBox ID="txtcodigo" runat="server" Text='<%# Eval("codigo") %>'></asp:TextBox>
							Descripcion<asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("producto") %>'></asp:TextBox>
							Precio
							<asp:TextBox ID="txtprecio" runat="server" Width="85px" Text='<%# Eval("precio") %>'></asp:TextBox>
							<br />
							Precio2
							<asp:TextBox ID="txtprecio2" runat="server" Width="74px" Text='<%# Eval("precio2") %>'></asp:TextBox>
							<br />
							CveProv
							<asp:DropDownList ID="drpCveProv" runat="server">
								<asp:ListItem>Abarrotes</asp:ListItem>
								<asp:ListItem>Farmacia</asp:ListItem>
								<asp:ListItem>Tlapaleria</asp:ListItem>
								<asp:ListItem>Dulces</asp:ListItem>
							</asp:DropDownList>
							&nbsp; Granel
							<asp:CheckBox ID="CheckBox1" Text="Granel" runat="server" />
							<br />
							Costo
							<asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("costo") %>' Width="71px"></asp:TextBox>
							&nbsp;utilidad
							<asp:TextBox ID="TextBox5" runat="server" Width="94px"></asp:TextBox>
							<br />
							IVA
							<asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("iva") %>' Width="70px"></asp:TextBox>
							&nbsp; IEPS<asp:TextBox ID="TextBox7" runat="server" Text='<%# Eval("ieps") %>' Width="81px"></asp:TextBox>
							<br />
							Unidad
							<asp:DropDownList ID="DropDownList2" runat="server">
								<asp:ListItem>pza</asp:ListItem>
								<asp:ListItem>kg</asp:ListItem>
								<asp:ListItem>litro</asp:ListItem>
								<asp:ListItem>metros</asp:ListItem>
							</asp:DropDownList>

						</InsertItemTemplate>
						<PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
						<RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
					</asp:FormView>
					<asp:SqlDataSource ID="SqlDataSourceP" runat="server" ConnectionString="<%$ ConnectionStrings:gestorFacturasConnectionString %>" SelectCommand="spProductos_insert" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
					<asp:Button ID="Button1" runat="server" Text="Agregar" />
					<%--<asp:SqlDataSource ID="SqlDataProduct" runat="server" ConnectionString="<%$ ConnectionStrings:gestorFacturasConnectionString %>" DeleteCommand="DELETE FROM [Productos001         ] WHERE [codigo] = @codigo" InsertCommand="INSERT INTO [Productos001         ] ([codigo], [producto], [precio], [precio2], [Cve_Pro], [a_granel], [costo], [ganancia], [iva], [ieps], [fechmov], [marcamov], [unidad]) VALUES (@codigo, @producto, @precio, @precio2, @Cve_Pro, @a_granel, @costo, @ganancia, @iva, @ieps, @fechmov, @marcamov, @unidad)" SelectCommand="spProductos_insert" UpdateCommand="UPDATE [Productos001         ] SET [producto] = @producto, [precio] = @precio, [precio2] = @precio2, [Cve_Pro] = @Cve_Pro, [a_granel] = @a_granel, [costo] = @costo, [ganancia] = @ganancia, [iva] = @iva, [ieps] = @ieps, [fechmov] = @fechmov, [marcamov] = @marcamov, [unidad] = @unidad WHERE [codigo] = @codigo" SelectCommandType="StoredProcedure">
                        <DeleteParameters>
                            <asp:Parameter Name="codigo" Type="String" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="codigo" Type="String" />
                            <asp:Parameter Name="producto" Type="String" />
                            <asp:Parameter Name="precio" Type="Single" />
                            <asp:Parameter Name="precio2" Type="Single" />
                            <asp:Parameter Name="Cve_Pro" Type="String" />
                            <asp:Parameter Name="a_granel" Type="Boolean" />
                            <asp:Parameter Name="costo" Type="Single" />
                            <asp:Parameter Name="ganancia" Type="Single" />
                            <asp:Parameter Name="iva" Type="Decimal" />
                            <asp:Parameter Name="ieps" Type="Decimal" />
                            <asp:Parameter Name="fechmov" Type="DateTime" />
                            <asp:Parameter Name="marcamov" Type="String" />
                            <asp:Parameter Name="unidad" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="producto" Type="String" />
                            <asp:Parameter Name="precio" Type="Single" />
                            <asp:Parameter Name="precio2" Type="Single" />
                            <asp:Parameter Name="Cve_Pro" Type="String" />
                            <asp:Parameter Name="a_granel" Type="Boolean" />
                            <asp:Parameter Name="costo" Type="Single" />
                            <asp:Parameter Name="ganancia" Type="Single" />
                            <asp:Parameter Name="iva" Type="Decimal" />
                            <asp:Parameter Name="ieps" Type="Decimal" />
                            <asp:Parameter Name="fechmov" Type="DateTime" />
                            <asp:Parameter Name="marcamov" Type="String" />
                            <asp:Parameter Name="unidad" Type="String" />
                            <asp:Parameter Name="codigo" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>--%>
                </td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style1">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style1">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
		</table>

	</div>
</asp:Content>
