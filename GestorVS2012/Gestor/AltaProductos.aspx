<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AltaProductos.aspx.vb" Inherits="GestorVS2012.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 66px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:FormView ID="FormView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" DataKeyNames="codigo" DataSourceID="SqlDataProduct" AllowPaging="True">
                        <EditItemTemplate>
                            codigo:
                            <asp:Label ID="codigoLabel1" runat="server" Text='<%# Eval("codigo") %>' ForeColor="Blue" />
                            <br />
                            producto:
                            <asp:TextBox ID="productoTextBox" runat="server" Text='<%# Bind("producto") %>' ForeColor="Blue"  />
                            <br />
                            precio:
                            <asp:TextBox ID="precioTextBox" runat="server" Text='<%# Bind("precio") %>' ForeColor="Blue"  />
                            <br />
                            precio2:
                            <asp:TextBox ID="precio2TextBox" runat="server" Text='<%# Bind("precio2") %>' ForeColor="Blue" />
                            <br />
                            Cve_Pro:
                            <asp:TextBox ID="Cve_ProTextBox" runat="server" Text='<%# Bind("Cve_Pro") %>' ForeColor="Blue" />
                            <br />
                            a_granel:
                            <asp:CheckBox ID="a_granelCheckBox" runat="server" Checked='<%# Bind("a_granel") %>' ForeColor="Blue"  />
                            <br />
                            costo:
                            <asp:TextBox ID="costoTextBox" runat="server" Text='<%# Bind("costo") %>' ForeColor="Blue" />
                            <br />
                            ganancia:
                            <asp:TextBox ID="gananciaTextBox" runat="server" Text='<%# Bind("ganancia") %>' ForeColor="Blue" />
                            <br />
                            iva:
                            <asp:TextBox ID="ivaTextBox" runat="server" Text='<%# Bind("iva") %>' ForeColor="Blue" />
                            <br />
                            ieps:
                            <asp:TextBox ID="iepsTextBox" runat="server" Text='<%# Bind("ieps") %>' ForeColor="Blue" />
                            <br />
                            fechmov:
                            <asp:TextBox ID="fechmovTextBox" runat="server" Text='<%# Bind("fechmov") %>' ForeColor="Blue" />
                            <br />
                            marcamov:
                            <asp:TextBox ID="marcamovTextBox" runat="server" Text='<%# Bind("marcamov") %>' ForeColor="Blue" />
                            <br />
                            unidad:
                            <asp:TextBox ID="unidadTextBox" runat="server" Text='<%# Bind("unidad") %>' ForeColor="Blue" />
                            <br />
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <InsertItemTemplate>
                            codigo:
                            <asp:TextBox ID="codigoTextBox" runat="server" Text='<%# Bind("codigo") %>' ForeColor ="Brown" />                            
                            <br />
                            producto:
                            <asp:TextBox ID="productoTextBox" runat="server" Text='<%# Bind("producto") %>' ForeColor ="Brown"  />
                            <br />
                            precio:
                            <asp:TextBox ID="precioTextBox" runat="server" Text='<%# Bind("precio") %>' ForeColor ="Brown" />
                            <br />
                            precio2:
                            <asp:TextBox ID="precio2TextBox" runat="server" Text='<%# Bind("precio2") %>' ForeColor ="Brown" />
                            <br />
                            Cve_Pro:
                            <asp:TextBox ID="Cve_ProTextBox" runat="server" Text='<%# Bind("Cve_Pro") %>' ForeColor ="Brown" />
                            <br />
                            a_granel:
                            <asp:CheckBox ID="a_granelCheckBox" runat="server" Checked='<%# Bind("a_granel") %>' />
                            <br />
                            costo:
                            <asp:TextBox ID="costoTextBox" runat="server" Text='<%# Bind("costo") %>' ForeColor ="Brown"/>
                            <br />
                            ganancia:
                            <asp:TextBox ID="gananciaTextBox" runat="server" Text='<%# Bind("ganancia") %>' ForeColor ="Brown" />
                            <br />
                            iva:
                            <asp:TextBox ID="ivaTextBox" runat="server" Text='<%# Bind("iva") %>' ForeColor ="Brown" />
                            <br />
                            ieps:
                            <asp:TextBox ID="iepsTextBox" runat="server" Text='<%# Bind("ieps") %>' ForeColor ="Brown" />
                            <br />
                            fechmov:
                            <asp:TextBox ID="fechmovTextBox" runat="server" Text='<%# Bind("fechmov") %>' ForeColor ="Brown" />
                            <br />
                            marcamov:
                            <asp:TextBox ID="marcamovTextBox" runat="server" Text='<%# Bind("marcamov") %>' ForeColor ="Brown" />
                            <br />
                            unidad:
                            <asp:TextBox ID="unidadTextBox" runat="server" Text='<%# Bind("unidad") %>' ForeColor ="Brown"/>
                            <br />
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            codigo:
                            <asp:Label ID="codigoLabel" runat="server" Text='<%# Bind("codigo")%>' />
                            <br />
                            producto:
                            <asp:Label ID="productoLabel" runat="server" Text='<%# Bind("producto") %>' />
                            <br />
                            precio:
                            <asp:Label ID="precioLabel" runat="server" Text='<%# Bind("precio") %>' />
                            <br />
                            precio2:
                            <asp:Label ID="precio2Label" runat="server" Text='<%# Bind("precio2") %>' />
                            <br />
                            Cve_Pro:
                            <asp:Label ID="Cve_ProLabel" runat="server" Text='<%# Bind("Cve_Pro") %>' />
                            <br />
                            a_granel:
                            <asp:CheckBox ID="a_granelCheckBox" runat="server" Checked='<%# Bind("a_granel") %>' Enabled="false" />
                            <br />
                            costo:
                            <asp:Label ID="costoLabel" runat="server" Text='<%# Bind("costo") %>' />
                            <br />
                            ganancia:
                            <asp:Label ID="gananciaLabel" runat="server" Text='<%# Bind("ganancia") %>' />
                            <br />
                            iva:
                            <asp:Label ID="ivaLabel" runat="server" Text='<%# Bind("iva") %>' />
                            <br />
                            ieps:
                            <asp:Label ID="iepsLabel" runat="server" Text='<%# Bind("ieps") %>' />
                            <br />
                            fechmov:
                            <asp:Label ID="fechmovLabel" runat="server" Text='<%# Bind("fechmov") %>' />
                            <br />
                            marcamov:
                            <asp:Label ID="marcamovLabel" runat="server" Text='<%# Bind("marcamov") %>' />
                            <br />
                            unidad:
                            <asp:Label ID="unidadLabel" runat="server" Text='<%# Bind("unidad") %>' />
                            <br />
                            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                        </ItemTemplate>
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    </asp:FormView>
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                    <asp:SqlDataSource ID="SqlDataProduct" runat="server" ConnectionString="<%$ ConnectionStrings:gestorFacturasConnectionString %>" DeleteCommand="DELETE FROM [Productos001         ] WHERE [codigo] = @codigo" InsertCommand="INSERT INTO [Productos001         ] ([codigo], [producto], [precio], [precio2], [Cve_Pro], [a_granel], [costo], [ganancia], [iva], [ieps], [fechmov], [marcamov], [unidad]) VALUES (@codigo, @producto, @precio, @precio2, @Cve_Pro, @a_granel, @costo, @ganancia, @iva, @ieps, @fechmov, @marcamov, @unidad)" SelectCommand="SELECT [codigo], [producto], [precio], [precio2], [Cve_Pro], [a_granel], [costo], [ganancia], [iva], [ieps], [fechmov], [marcamov], [unidad] FROM [Productos001         ]" UpdateCommand="UPDATE [Productos001         ] SET [producto] = @producto, [precio] = @precio, [precio2] = @precio2, [Cve_Pro] = @Cve_Pro, [a_granel] = @a_granel, [costo] = @costo, [ganancia] = @ganancia, [iva] = @iva, [ieps] = @ieps, [fechmov] = @fechmov, [marcamov] = @marcamov, [unidad] = @unidad WHERE [codigo] = @codigo">
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
                    </asp:SqlDataSource>
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
