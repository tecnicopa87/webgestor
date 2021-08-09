<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin.aspx.vb" Inherits="GestorVS2012.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="#CC0099" Text="Administrador de Sitio"></asp:Label>
    <br />
    <asp:Panel ID="Panel1" runat="server">
        
        <asp:SqlDataSource ID="SqlDataSUsersPendientes" runat="server" ConnectionString="<%$ ConnectionStrings:gestorFacturasConnectionString %>" SelectCommand="SELECT [seudonimo], [Email], [idCliente], [fechAlta], [CFDIs] FROM [MisClientes] WHERE ([CFDIs] IS NULL)"></asp:SqlDataSource>
        <div class ="row">
        <div class ="row col-md-4 col-lg-4">
            <asp:TreeView ID="TreeView1" runat="server" ImageSet="News" NodeIndent="10">
                <HoverNodeStyle Font-Underline="True" />
                <Nodes>
                    <asp:TreeNode NavigateUrl="~/Gestor/Admin.aspx?opt=ac" Text="Autorizar Cuentas" Value="AutorizarCuentas">
                                            </asp:TreeNode>
                    <asp:TreeNode NavigateUrl="~/Gestor/Admin.aspx?opt=ct" Text="Configurar Terminales" Value="ConfigurarTerminales">
                        
                    </asp:TreeNode>
                    <asp:TreeNode NavigateUrl="~/Gestor/Admin.aspx?opt=status" Text="Cambiar Estatus App" Value="CambiarEstatusApp"></asp:TreeNode>
                </Nodes>
                <NodeStyle Font-Names="Arial" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                <ParentNodeStyle Font-Bold="False" />
                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
            </asp:TreeView>
            </div>
        <div class ="row col-md-8 col-lg-8">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="idCliente" DataSourceID="SqlDataSUsersPendientes" GridLines="Vertical" Visible="False">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:CommandField SelectText="Autorizar" ShowSelectButton="True" />
                    <asp:BoundField DataField="seudonimo" HeaderText="seudonimo" SortExpression="seudonimo" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="idCliente" HeaderText="idCliente" SortExpression="idCliente" />
                    <asp:BoundField DataField="fechAlta" HeaderText="fechAlta" SortExpression="fechAlta" />
                    <asp:BoundField DataField="CFDIs" HeaderText="CFDIs" SortExpression="CFDIs" Visible="False" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
        </div>
            </div>
        <div class ="row" style="left:15px"> <asp:Label ID="Label2" runat="server" Text="CFDIs autorizados:" Visible="False"></asp:Label>
                    <asp:TextBox ID="TxtNoCFDIs" runat="server" Width="50px" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1px" Visible="False"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:GridView ID="gvInfoClientes" runat="server" AutoGenerateColumns="False" DataSourceID="SqlOrigen" Width ="70%" DataKeyNames="idCliente" Visible="False">
                <Columns>
                    <asp:BoundField DataField="idCliente" HeaderText="idCliente" ReadOnly="True" SortExpression="idCliente" />
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
                    <asp:BoundField DataField="Regimen" HeaderText="Regimen Fiscal" SortExpression="Regimen" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="CFDIs" HeaderText="CFDIs" SortExpression="CFDIs" />
                    <asp:CheckBoxField DataField="Edo_App" HeaderText="Edo_App" SortExpression="Edo_App" Visible="False" />
                    <asp:TemplateField HeaderText="Estado App">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEdoApp" runat="server" Checked='<%# Bind("Edo_App") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                
            </asp:GridView>
            <asp:SqlDataSource ID="SqlOrigen" runat="server" ConnectionString="<%$ ConnectionStrings:gestorFacturasConnectionString %>" SelectCommand="SELECT [idCliente], [Titulo], [Regimen], [Email], [CFDIs], [Edo_App] FROM [MisClientes]" UpdateCommand="UPDATE [MisClientes] SET [Titulo] = @Titulo, [Regimen] = @Regimen, [Email] = @Email, [CFDIs] = @CFDIs, [Edo_App] = @Edo_App WHERE [idCliente] = @idCliente" DeleteCommand="DELETE FROM [MisClientes] WHERE [idCliente] = @idCliente" InsertCommand="INSERT INTO [MisClientes] ([idCliente], [Titulo], [Regimen], [Email], [CFDIs], [Edo_App]) VALUES (@idCliente, @Titulo, @Regimen, @Email, @CFDIs, @Edo_App)">
                <DeleteParameters>
                    <asp:Parameter Name="idCliente" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="idCliente" Type="String" />
                    <asp:Parameter Name="Titulo" Type="String" />
                    <asp:Parameter Name="Regimen" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="CFDIs" Type="Int32" />
                    <asp:Parameter Name="Edo_App" Type="Boolean" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Titulo" Type="String" />
                    <asp:Parameter Name="Regimen" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="CFDIs" Type="Int32" />
                    <asp:Parameter Name="Edo_App" Type="Boolean" />
                    <asp:Parameter Name="idCliente" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:Button ID="BntConfigurar" runat="server" Text="Configurar" />
         </div>
        <asp:Label ID="LabelResult" runat="server" ForeColor="#CC0000" Text="Resultado"></asp:Label>
        </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
