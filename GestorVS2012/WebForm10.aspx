<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="WebForm10.aspx.vb" Inherits="GestorVS2012.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <table class="table-responsive ">
        <tr>
            <td colspan="1" style="width:10%"></td>
            <td colspan="2">
                <center><asp:Label ID="LblNombEmp" runat="server" Font-Bold="True" Font-Size="Medium"
                        ForeColor="#000066" Text="EMPRESA DEMOSTRACION"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" ForeColor="#000066"
                        Text="calle ficticia # 45, Col  Conocida"></asp:Label></center>
            </td>
         
            <td colspan="1" style="width:30%"><button type="button" class="btn btn-img-cat" >Clientes</button>
                <asp:TextBox ID="TextCliente" runat="server" Wrap="true"></asp:TextBox>                
                <div style="text-align:right">
                    <label style="color:#f70f3a" >Ventas</label>
                </div>
                <asp:CheckBox ID="CheckBox1" Text ="revisado" runat="server"  />

            </td>
        </tr>
        <tr>
            <td colspan="1">&nbsp;</td>
            <td colspan="1">
                <p>            
                </p>
                <asp:Button ID="btnCatProducts" runat="server" Text="Catalogo" class="btn btn-primary" />
                <asp:Label ID="LblCargProds" runat="server" Font-Bold="True"
                    ForeColor="#CC0000" Text="P" Visible="False"></asp:Label>
                <asp:Label ID="LblVentaExitosa" runat="server" Font-Bold="True" ForeColor="#CC99FF" Text="Se registró su venta exitosamente" Visible="False"></asp:Label>

            </td>
            <td colspan="1">&nbsp;</td>
            <td colspan="1">&nbsp;</td>
        </tr>
        <tr>
            <%--fila 3--%>
            <td colspan="1">
                <asp:Label ID="Label1" runat="server" Text="Folio:"></asp:Label>
               <asp:Label ID="LblFolVenta" runat="server" Text="000"></asp:Label>
            </td>
            <td colspan="1">
                <asp:Label ID="Label2" runat="server" Text="Cantidad:"></asp:Label>
                <asp:Label ID="Label9" runat="server" Text="Unidad"></asp:Label>
                <script type="text/javascript">
                    function Validar() {
                        var foo = true;
                        var txtcliente = document.getElementById('<%=TextCliente.ClientID%>');

                            if (txtcliente.value == "") {
                                alert(' Debe seleccionar un Cliente/Destinatario de factura');
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
            </td>
            <td colspan="1">
                <asp:Label ID="Label3" runat="server" Text="Descripcion :"></asp:Label>
            </td>
            <td colspan="1">
                <asp:Label ID="Label4" runat="server" Text="Precio:"></asp:Label>
                <asp:Label ID="Label5" runat="server" Text="Importe :"></asp:Label>              
            </td>
        </tr>
        <tr>
            <td colspan="1">
                <asp:Label ID="LblCodProd" runat="server"></asp:Label>
            </td>
            <td colspan="1">&nbsp;<asp:TextBox ID="txtCantidad" runat="server" Width="65px"></asp:TextBox>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="60px">
                    <asp:ListItem>pzas</asp:ListItem>
                    <asp:ListItem>kg</asp:ListItem>
                    <asp:ListItem>ltrs</asp:ListItem>
                    <asp:ListItem>cjas</asp:ListItem>
                    <asp:ListItem>bols</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                <asp:DropDownList ID="drpdwnListCveUnd" runat="server">
                </asp:DropDownList>
            </td>
            <td colspan="1">
                <asp:TextBox ID="TextBox2" runat="server" Wrap="true" ></asp:TextBox>

            </td>
            <td colspan="1"><asp:TextBox ID="txtPrecio" Width="65px" runat="server" ></asp:TextBox>
                <asp:TextBox ID="txtImporte" Width="65px" runat="server" ></asp:TextBox>
                <div >
                    <asp:Button ID="btnIngresar"
                        runat="server" class="btn btn-sm" Text="Agregar" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
