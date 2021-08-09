<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="VentasOnline.aspx.vb" Inherits="GestorVS2012.VentasOnline" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
         .center
          {
             text-align:center ;
             font-size:80%; 
         }
        .style1
        {
            height: 51px;
            font-weight :bold ;
        }
        .style2
        {
            height: 199px;
        }
        .style3
        {
            height: 51px;
            width: 95px;
        }
        .style4
        {
            height: 199px;
            width: 95px;
        }
        .style5
        {
            height: 51px;
            width: 384px;
        }
        .style6
        {
            height: 28px;
            width: 95px;
        }
        .style7
        {
            height: 28px;
            width: 384px;
        }
        .style8
        {
            height: 28px;
        }
        .style9
        {
            height: 29px;
            width: 95px;
        }
        .style10
        {
            height: 29px;
            width: 384px;
        }
        .style11
        {
            height: 29px;
        }
        .style12
        {
            height: 29px;
            width: 266px;
        }
        .style13
        {
            width: 424px;
        }
        .style14
        {
            height: 29px;
            width: 130px;
        }
        .style16
        {
            height: 29px;
            width: 424px;
        }
        .style17
        {
            height: 28px;
            width: 135px;
        }
        .style18
        {
            height: 28px;
            width: 266px;
        }
        .style19
        {
            width: 143px;
        }
        .style20
        {
            height: 44px;
            width: 143px;
        }
        .style21
        {
            width: 646px;
            height: 44px;
        }
        .style22
        {
            height: 44px;
        }
        .style23
        {
            height: 28px;
            width: 143px;
        }
        .style24
        {
            width: 646px;
        }
        .style25
        {
            height: 29px;
            width: 646px;
        }
         .auto-style1 {
             height: 42px;
             width: 95px;
         }
         .auto-style2 {
             height: 42px;
             width: 288px;
         }
         .auto-style4 {
             height: 42px;
             font-weight : bold;
         }
         .auto-style5 {
             height: 52px;
             width: 95px;
         }
         .auto-style7 {
             height: 52px;
         }
         .auto-style8 {
             height: 42px;
             font-weight : bold;             
         }
         .auto-style9 {
             height: 52px;
             width: 302px;
         }
         .auto-style10 {
             height: 28px;
             width: 302px;
         }
         .auto-style11 {
             height: 29px;
             width: 302px;
         }
         .auto-style12 {
             height: 51px;
             font-weight : bold;
             width: 302px;
         }
         .auto-style15 {
             height: 51px;
             width: 288px;
         }
         .auto-style16 {
             height: 52px;
             width: 288px;
         }
         .auto-style17 {
             height: 28px;
             width: 288px;
         }
         .auto-style18 {
             height: 29px;
             width: 288px;
             align-content :center ; 
             align-items :center ;
         }
    </style>
    <link href ="../../Content/estiloFacturas.css" rel ="Stylesheet" type ="text/css" />
        <!-- Esta exclusiva de jquery control <input type=date..> -->
    <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js' type='text/javascript'></script>
        
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script type ="text/javascript" >
        function Cokieclientes() {
            document.cookie = "clie='activo'";
            return true;
        }
    </script>
    <script type ="text/javascript" >
        var objbtn = document.getElementById("btnCatProducts");
        function ClickAuto() {
            objbtn.click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div style="margin-left: 10px; margin-right:4px;">
        <table class="table-responsive ">
            <tr>
                <td colspan="1" style="width:10%"></td>
                <td class="well" colspan="2">
                    <center><asp:Label ID="LblNombEmp" runat="server" Font-Bold="True" Font-Size="Medium"
                        ForeColor="#000066" Text="EMPRESA DEMOSTRACION"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" ForeColor="#000066"
                        Text="calle ficticia # 45, Col  Conocida"></asp:Label></center>
                </td>
                <td style="width:30%" colspan="1">
                <button type="button" class="btn btn-img-cat" data-toggle="modal" data-target="#FeaturedContent_catClients" onclick="cargaClient();">Clientes</button>
                    <asp:TextBox ID="TextCliente" runat="server"  Wrap="true"></asp:TextBox>
                    <div style="text-align: right">
                        <label style="color: #660033">Ventas</label></div>
                </td>                
            </tr>
            <tr>
                <td colspan="1" style="width:10%">&nbsp;</td>
                <td colspan="1">
                    <p>
                        <%--<button type="button" class="btn btn-default btn-sm">
          <span class="glyphicon glyphicon-shopping-cart"></span> Plus
        </button>--%>
                    </p>

                    <asp:Button ID="btnCatProducts" runat="server" Text="Catalogo" class="btn btn-primary" />
                    &nbsp;&nbsp;<asp:Label ID="LblCargProds" runat="server" Font-Bold="True"
                        ForeColor="#CC0000" Text="P" Visible="False"></asp:Label>
                    <asp:Label ID="LblVentaExitosa" runat="server" Font-Bold="True" ForeColor="#CC99FF" Text="Se registró su venta exitosamente" Visible="False"></asp:Label>

                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr> <%--fila 3--%>
                <td colspan="1" style="width:10%">
                    <asp:Label ID="Label1" runat="server" Text="Folio:"></asp:Label>
                    &nbsp;&nbsp;<asp:Label ID="LblFolVenta" runat="server" Text="000"></asp:Label>
                </td>
                <td colspan="1">
                    <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Cantidad:"></asp:Label>
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
                    <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Descripcion :"></asp:Label></td>
                <td colspan="1">
                    <asp:Label ID="Label4" runat="server" Font-Bold="true" Text="Precio:"></asp:Label>
                <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Importe :"></asp:Label>
                    <script type="text/javascript">
                        Importe = 0;
                        function CalculaImporteArticulo() {
                            var foo = true;
                            //var costo = document.getElementById('<%=txtPrecio.ClientID%>');
                        var costo = $('[id*=txtPrecio]').val();
                        // document.getElementById('<%=txtCantidad.ClientID%>');  
                        var cantidad = $('[id*=txtCantidad]').val();
                        //Importe = (parseFloat(cantidad.value) * parseFloat(costo.value));
                        Importe = cantidad * costo;
                        //document.getElementById('<%=txtImporte.ClientID%>').innerText = Importe
                        $('[id*=txtImporte]').val(Importe);
                        // document.getElementById('<%=txtImporte.ClientID%>').innerText);                        
                        if (costo == "") {
                            alert(' Debe indicar un costo');
                            foo = false;

                            //} else {
                            //document.getElementById('<%=txtImporte.ClientID%>').innerText= Importe;
                            $('[id*=txtImporte]').val(Importe);
                            foo = true;
                        }
                        return foo;
                    }
                    </script>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width:10%">
                    <asp:Label ID="LblCodProd" runat="server"></asp:Label>
                </td>
                <td colspan="1">&nbsp;<asp:TextBox ID="txtCantidad" runat="server" Width="25px"></asp:TextBox>
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
                    <asp:TextBox ID="TextBox2" runat="server" Wrap="true"></asp:TextBox></td>
                <td colspan="1" style="width:30%">&nbsp;<asp:TextBox ID="txtPrecio" runat="server" Width="30px" Wrap="true"></asp:TextBox>
                    &nbsp;&nbsp;<asp:TextBox ID="txtImporte" runat="server" Width="40px" Wrap="true"></asp:TextBox>
                    <div style="text-align: right">
                        <asp:Button ID="btnIngresar"
                            runat="server" class="btn btn-sm" Text="Agregar" />
                    </div>
                </td>
            </tr>
        </table>
    <asp:GridView ID="GridViewTmp" runat="server" DataKeyNames="id" HorizontalAlign="Center" CellPadding="2" Width="100%">
                    <HeaderStyle BackColor ="#003399" ForeColor="#ffffcc"  />
                    <AlternatingRowStyle BackColor="#669999" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" DeleteText="Borrar" EditText="Editar" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <table class ="table-responsive">
        <tr>
            <td class="style3">
            </td>
            <td class="auto-style15">
                <asp:Label ID="Label6" runat="server" ForeColor="Red" Text=". . ." 
                    Visible="False"></asp:Label>
                <asp:Button ID="BttnConfirmar" runat="server" Text="Registrar Venta" 
                    Width="124px" class="btn btn-success"/>
            </td>
            <td class="auto-style12">
                Total&nbsp;:<asp:Label ID="LblTotal" runat="server" Text="$ 0.00"></asp:Label>
            </td>
            <td class="style1">
            </td>
        </tr>
    </table>
        </div>
    <script type = "text/javascript">
        function ShowCurrentTime() {
            $.ajax({
                type: "POST",
                url: "VentasOnline.aspx/ObtenClientesPorClave",
                data: '{cveRFC: "' + $("#<%=TextBox1.ClientID%>")[0].value + '" ,sessionid:001 }',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: OnSuccess,
                            failure: function (response) {
                                alert(response.d);
                            }
                        });
                    }
                    function OnSuccess(response) {
                        alert(response.d);
                    }
</script>
     <div class="modal fade" id="catClients" runat ="server" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" enableviewstate ="true" >
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
               
                <script type ="text/javascript">
                    function cargaClient() {
                        $(document).ready(function (e) {
                            var existck = document.cookie.indexOf('ajax-ck=');// -1 sino existe
                            var rfc = "";// por defecto p llamada ajax
                            rfc.value = "Clients";
                            if (existck == -1) {
                                document.cookie = "ajax-ck=Clients";
                                //alert('ajax catalogo');
                            }
                            else {
                                 rfc = document.getElementById('FeaturedContent_dpdwnListClient');
                                //alert('ajax por clave' + rfc.value);
                                document.cookie = "ajax-ck=" + rfc.value;
                            }
                            var lscokies = document.cookie.split(";");
                            for (i in lscokies) {
                                var busca = lscokies[i].search("sessid");
                                if (busca > -1) { micookie = lscokies[i] }
                            }
                            var igual = micookie.indexOf("=");
                            var id = micookie.substring(igual + 1);
                            //alert("rfc " + rfc.value);
                            $.ajax({
                                type: "POST",
                                url: "VentasOnline.aspx/ObtenClientesPorClave",
                                data: '{cveRFC: "' + rfc.value + '" ,sessionid: "'+ id+'" }',
                                contentType: "application/json; charset=utf-8",
                               // dataType: "json",
                                success: function (response) {
                                    var s = JSON.parse(response.d);                                  
                                    var json = response.d;
                                    console.log(json);
                                    //Lo parseamos para convertirlo en objeto
                                    var types = JSON.parse(json);                                                                                                         
                                    if (types.length > 0) {
                                        console.log(types.length);
                                        //alert('response[0].N:' + types[0].Nombre + 'response[0].C:' + types[0].Calle );
                                        $('[id*=TextBox1]').val(types[0].Nombre);
                                        $('[id*=TextBox3]').val(types[0].Calle);
                                        $('[id*=TextBox4]').val(types[0].NoExt);
                                        $('[id*=TextBox11]').val(types[0].Colonia);
                                        $('[id*=TextBox12]').val(types[0].Municipio);
                                        $('[id*=TextBox14]').val(types[0].CP);
                                    }                                   
                                    //Y lo recorremos
                                    for (x = 0; x < types.length; x++) {
                                        console.log(types[x].Nombre);
                                        console.log(types[x].Calle);
                                        console.log(types[x].NoExt);
                                        console.log(types[x].Colonia);
                                        console.log(types[x].Municipio);
                                        console.log(types[x].CP);
                                    }                                   
                                    //alert('valor[0] :' + response.d );
                                    //$('[id*=TextBox1]').val(data[0].value);
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
                            <label class="etiqueta ">RFC Cliente:</label></td>
                        <td class="style16">
                            <asp:DropDownList ID="dpdwnListClient" runat="server" Width="130px"
                                AutoPostBack="false"  >
                                <asp:ListItem></asp:ListItem>
                                <%--<asp:ListItem>Nuevo RFC</asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ControlToValidate="dpdwnListClient" ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style18">
                            <label class="etiqueta ">Nombre :</label></td>
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
                        <td class="style18">
                            <label class="etiqueta">Regimen Fiscal:</label></td>
                        <td class="style16">
                            <asp:DropDownList ID="dpdwnListRegimen" runat="server" Height="28px" Width="304px">
                                <asp:ListItem Value="IncorporacionFiscal">Regimen de Incorporación Fiscal</asp:ListItem>
                                <asp:ListItem Value="PersonasMorales">General de Personas Morales</asp:ListItem>
                                <asp:ListItem Value="FisicaActividadesEmpresariales">Persona Fisica Actividades Empresariales</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
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
                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
                        </td>
                        <td class="style17"></td>
                    </tr>
                </table>            
            </div>
        </div>
    </div>
     <%-- <div id="CatProductos" >
        <table style="width:100%; height: 243px;">
                <tr>
                    <td class="style20">
                        <asp:Label ID="Label10" runat="server" Text="Buscar texto:"></asp:Label>
                    </td>
                    <td class="style21">
                        <asp:TextBox ID="TextBox13" runat="server" Width="237px" AutoPostBack="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnBuscaArticulo" runat="server" Text="Buscar" />
                    </td>
                    <td class="style22">
                        </td>
                </tr>
                <tr>
                    <td class="style19">
                        &nbsp;</td>
                    <td class="style24">
                        <asp:GridView ID="GridView2" runat="server" BackColor="White" 
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                            AllowPaging="True" PageSize="12" DataKeyNames="codigo" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                            AutoGenerateSelectButton="True" OnPageIndexChanging="GridView2_PageIndexChanging" >
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
                    <td>
                        </td>
                </tr>
                <tr>
                    <td class="style23">
                        Encontrados<label class ="etiqueta ">:</label></td>
                    <td class="style25">
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                            ControlToValidate="dpdwnListClient" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                </table>
        </div>--%>
    <div id="CatProductos" runat="server" style="margin-left: 10px; margin-right: 4px; z-index: 1; background-color: #8ab4b2">
        <table class="table-responsive">
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
                <td class="style24"></td>
                <td></td>
            </tr>
        </table>
        <asp:GridView ID="GridView2" runat="server" BackColor="White"
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%"
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
        <table>
            <tr>
                <td class="style23">Encontrados<label class="etiqueta ">:</label><label id="lblEncontrados" runat="server">0</label></td>
                <td class="style25">

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                        ControlToValidate="dpdwnListClient" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
