<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ConsultarFact.aspx.vb" Inherits="GestorVS2012.ConsultarFact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 51px;
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
            width: 767px;
        }
        .style6
        {
            height: 28px;
            width: 95px;
        }
        .style7
        {
            height: 28px;
            width: 767px;
        }
        .style8
        {
            height: 28px;
        }
        .style9
        {
            height: 44px;
            width: 95px;
        }
        .style10
        {
            height: 44px;
            width: 388px;
        }
        .style11
        {
            height: 44px;
        }
        .style12
        {
            height: 44px;
            width: 538px;
        }
        .style13
        {
            height: 28px;
            width: 538px;
        }
    </style>
    <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js' type='text/javascript'/>
    <script type ="text/javascript">
        function DespliegaClient() {
            var foo = false;
            var ventana = document.getElementById('VentanaReceptor');
            if (ventana.style.visibility == "visible") {
                var lscokies = document.cookie.split(";");
                for (i in lscokies) {
                    var busca = lscokies[i].search("cat");
                    if (busca > -1) { micookie = lscokies[i] }
                }
                var igual = micookie.indexOf("=");
                var valor = micookie.substring(igual + 1);
                if (valor = "activo") {
                    ventana.style.visibility = "hidden";
                }
            } else {

                ventana.style.visibility = "visible";
            }
            return foo
        }
        </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left:10px">
        <div class ="row">
        <div class ="col-sm-6 col-md-9">
             <center><asp:Label ID="LblNombEmp" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="EMPRESA DEMOSTRACION"></asp:Label>
                <br />
                <asp:Label ID="Label7" runat="server" ForeColor="#000066" 
                    Text="calle ficticia # 45, Col  Conocida"></asp:Label></center>
        </div>
        <div class ="col-sm-4 col-md-3" style ="text-align:right"> <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#660033" Text="Facturas Emitidas"></asp:Label>

        </div> 
            <div> <table style ="width :400px"><tr><td><asp:Label ID="Label1" runat="server" Text="Busqueda:"></asp:Label></td><td></td><td></td></tr>
                <tr><td><asp:RadioButton ID="RadioButton1" runat="server" GroupName="TipBus" 
                    Text="Por Periodo:" /></td><td><asp:RadioButton ID="RadioButton2" runat="server" 
                    GroupName="TipBus" Text="Por Folio:" /></td><td></td></tr>
                  </table><asp:DropDownList ID="DropDownList2" 
                    runat="server" Width="77px" Height="16px">
                </asp:DropDownList><br />          
            </div>
            <div><asp:Label 
                    ID="Label13" runat="server" ForeColor="#CC3300" Text="Label" Visible="False"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                    ID="Button1" runat="server" Text="Buscar" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label10" runat="server" Text="del"></asp:Label>
&nbsp;&nbsp;
                <asp:Label ID="Label11" runat="server" Text="00/00/0000"></asp:Label>
            </div>
            <div><asp:Label ID="Label12" runat="server" 
                    Text="00/00/0000"></asp:Label>
                <div style ="text-align:right  ">
                    <asp:Label ID="Label4" runat="server" Text="Monto:"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" Width="79px"></asp:TextBox>
            </div>
            <br /><div class ="col-xs-9 col-sm-5">
               Inicio: <input type="date" id="dtDesde" step="1" min="2000-01-01" max="2077-12-31" /></div>
               <div class ="col-xs-9 col-sm-5">
                   Final:<input type="date" id="dtHasta" step="1" min="2000-01-01" max="2077-12-31"/></div>
            </div>
            
            <div>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    GridLines="Horizontal" Width="523px">
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
            <div><asp:Label ID="Label6" runat="server" ForeColor="Red" Text=". . ."></asp:Label>
            </div>
            <div>
            </div>
        </div>
        </div>
    <script type ="text/javascript">
        $(document).ready(function () {
            $("#dtDesde").focusout(function ()
                /*$("#FeaturedContent_BtnConsultVentas").click(function ()*/ {
                var currentDate = $("#dtDesde").val();
                /*$("FeaturedContent_Label11").text = currentDate;*/
                document.cookie = "Fact_ini=" + currentDate;

            });
            $("#dtHasta").focusout(function () {
                var currentDate2 = $("#dtHasta").val();
                document.cookie = "Fact_fin=" + currentDate2;

            });
        });
       </script>
</asp:Content>
