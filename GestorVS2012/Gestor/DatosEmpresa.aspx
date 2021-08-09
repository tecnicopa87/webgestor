<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DatosEmpresa.aspx.vb" Inherits="GestorVS2012.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link rel ="Stylesheet" href ="../Content/estiloEmpresa.css" type ="text/css" />           
 <style type="text/css">
              .style10
        {
            width: 25%/*131px*/;
          
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="container"><!-- frmbase -->
        <div class="row" style="margin-left: 5%; background-color: gray;">
            <!-- tab-->
            <div class="col-sm-6 col-md-8 ">
                <div class="style1">NOMBRE EMPRESA:</div>
                <div class="style2">
                    <asp:TextBox ID="TextBox1" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="TextBox1" ErrorMessage=" *" Font-Bold="True"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="style3">
                    &nbsp;
                </div>
            </div>
            <div class="col-sm-6 col-md-4">
                <div
                    class="style1">
                    CALLE:
                </div>
                <div class="style2">
                    <asp:TextBox ID="TextBox2" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="TextBox2" ErrorMessage=" *" Font-Bold="True"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="style3">
                    <div class="style1">No.EXTERIOR:.</div>:<asp:TextBox ID="TextBox3" runat="server"
                        Width="27%" />;<!-- 69px--><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            runat="server" ControlToValidate="TextBox3" ErrorMessage=" *" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="row" style="margin-left: 5%; background-color: gray;">
            <div class="col-sm-6 col-md-8">
                <div class="style1">
                    COLONIA:
                </div>
                <div
                    class="style2">
                    <asp:TextBox ID="TextBox4" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="TextBox4" ErrorMessage=" *" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="style1">
                    MUNICIPIO:
                </div>
                <div
                    class="style2">
                    <asp:TextBox ID="TextBox5" runat="server" />
                </div>
                <div class="style3">&nbsp;</div>
            </div>
            <div class="style3">&nbsp;</div>
        </div>
        <div class="row" style="margin-left: 5%; background-color: gray;">
            <div class="col-sm-6 col-md-8">
                <div class="style1">
                    ESTADO:
                </div>
                <div
                    class="cboEstados">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="21px" Width="315px">
                        <asp:ListItem> </asp:ListItem>
                        <asp:ListItem>AguasCalientes</asp:ListItem>
                        <asp:ListItem>Bajacalifornia_norte</asp:ListItem>
                        <asp:ListItem>Bajacalifornia_sur</asp:ListItem>
                        <asp:ListItem>Campeche</asp:ListItem>
                        <asp:ListItem>Coahuila</asp:ListItem>
                        <asp:ListItem>Chiapas</asp:ListItem>
                        <asp:ListItem>Chihuahua</asp:ListItem>
                        <asp:ListItem>Distrito Federal</asp:ListItem>
                        <asp:ListItem>Estado de Mexico</asp:ListItem>
                        <asp:ListItem>Guanajuato</asp:ListItem>
                        <asp:ListItem>Guerrero</asp:ListItem>
                        <asp:ListItem>Hidalgo</asp:ListItem>
                        <asp:ListItem>Jalisco</asp:ListItem>
                        <asp:ListItem>Michoacán</asp:ListItem>
                        <asp:ListItem>Morelos</asp:ListItem>
                        <asp:ListItem>Nuevo Leon</asp:ListItem>
                        <asp:ListItem>Oaxaca</asp:ListItem>
                        <asp:ListItem>Puebla</asp:ListItem>
                        <asp:ListItem>Querétaro</asp:ListItem>
                        <asp:ListItem>San Luis Potosi</asp:ListItem>
                        <asp:ListItem>Sinaloa</asp:ListItem>
                        <asp:ListItem>Tabasco</asp:ListItem>
                        <asp:ListItem>Veracruz</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="style3"></div>
            </div>
            <div class="col-sm-6 col-md-4">
                <div class="style1">
                    PAIS :
                </div>
                <div
                    class="style2">
                    <asp:TextBox ID="TextBox6" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
                </div>
                <div class="style3">&nbsp;</div>
                <div class="style1">
                    <label class="font ">C.P.:</label>
                </div>
                <div class="style2">
                    <asp:TextBox ID="TextBox7" runat="server"
                        Width="38%" />
                </div>
            </div>
            <!--with:72px -->
            </div>
            <div class="row" style ="margin-left:5%; background-color :gray;">
            <div class ="col-sm-5 col-md-8">
                <div class="style1">
                REGIMEN FISCAL:</div><div 
                class="style2">
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="21px" Width="315px" >
                        <asp:ListItem> </asp:ListItem>
                        <asp:ListItem>Regimen de Incorporación</asp:ListItem>
                        <asp:ListItem>Regimen de Personas Físicas con Actividades Empresariales</asp:ListItem>
                        <asp:ListItem>Regimen General de Ley de Personas Morales</asp:ListItem>
                        <asp:ListItem>Regimen Personas Físicas con Servicios Profesionales</asp:ListItem>
                    </asp:DropDownList>
                </div><div class="style3">&nbsp;</div>
                <div class="style1">
                RFC :
            </div>
                <div
                    class="style2">
                    <asp:TextBox ID="TextBox8" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="TextBox8" ErrorMessage=" *" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <%--<asp:Button ID="BttnGuardar" runat="server" Text="Guardar" />--%>
                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#fadesmall">Guardar</button>
                  <%--  <table style="width:100%;"><tr><td></td></tr></table>--%>
                    
                    <div class="modal fade" id="fadesmall" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
                        <div class="modal-dialog modal-sm" role="document">
                            <div class="modal-content">
                                Está seguro de guardar sus cambios ?
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerar</button>
                                    <button type="button" ID="btnGuardar" runat="server" onserverclick="btnGuardar_Click" class="btn btn-primary">Confirmar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
                </div>
                </div>
        <div class="row" style="margin-left: 5%; background-color: gray;">
            <div class="col-sm-6 col-md-4">
                <div class="style3">
                    <asp:Label ID="Label1" runat="server" CssClass="font" Text="*.Cer"></asp:Label>&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Label ID="Label2" runat="server" CssClass="font" Text="*.Key"></asp:Label>&nbsp;<asp:FileUpload ID="FileUpload2" runat="server" />
                </div>
                <div class="style1">
                    <asp:Button ID="bttnGuardaTodo" runat="server" Text="Guardar todo" />
                    <br />
                    &nbsp;&nbsp;<asp:Label ID="Lbl_Respuesta" runat="server"
                        Text="Se guardaron sus datos exitosamente" ForeColor="#9999FF" Visible="False"></asp:Label>
                </div>
                <div class="style2">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:gestorFacturasConnectionString %>"
                        SelectCommand="SELECT [Titulo], [RFC], [Email], [Edo_App] FROM [MisClientes]"></asp:SqlDataSource>
                </div>
                <div class="style3">
                    &nbsp;
                </div>
                <div
                    class="style1">
                    &nbsp;
                </div>
                <div class="style2">
                    &nbsp;
                </div>
            </div>
        </div>
     </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
