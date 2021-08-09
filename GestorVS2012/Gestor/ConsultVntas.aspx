<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ConsultVntas.aspx.vb" Inherits="GestorVS2012.WebForm1" %>
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
    .auto-style1 {
        height: 20px;
    }
    </style> 
    <link href ="../Content/estiloFacturas.css" rel ="Stylesheet" type ="text/css" />
    <!-- Esta exclusiva de jquery control <input type=date..> -->
    <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js' type='text/javascript'/>

    <%--<link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" media="screen"
     href="http://tarruda.github.com/bootstrap-datetimepicker/assets/css/bootstrap-datetimepicker.min.css">
  --%>
   
    <%--<link href ="../Content/bootstrap.css" rel="stylesheet" />Se Obtenie de la MASTER--%>
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
    <%--<link href ="../Content/bootstrap.css" rel="stylesheet" />Se Obtenie de la MASTER--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div style="margin-left:10px">
        <div class="row">
            <div class="col-sm-7 col-md-9 well">
                <center><asp:Label ID="LblNombEmp" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="EMPRESA DEMOSTRACION"></asp:Label> 
                <br />
                <asp:Label ID="Label7" runat="server" ForeColor="#000066" 
                    Text="calle ficticia # 45, Col  Conocida"></asp:Label></center>

            </div>
            <div class="col-sm-5 col-md-3 " style="text-align: right">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Medium"
                    ForeColor="#660033" Text="Ventas en Tienda"></asp:Label>
                <br />
                <asp:Label ID="Label10" runat="server" Text="del"></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="Label11" runat="server" Text="00/00/0000"></asp:Label>
                &nbsp;al&nbsp;&nbsp;<asp:Label ID="Label12" runat="server"
                    Text="00/00/0000"></asp:Label>
                <%--<label id="lbfechini" style ="font-size:small">00/00/2017</label>&nbsp;al&nbsp;<label id="lbfechfin" style ="font-size:small">00/00/2017</label>--%>
            </div>
        </div>
        <div class="row">
            <center>Opciones de Consulta:
            <div class="panel panel-info">
                <div style="text-align :center"> <asp:RadioButton ID="RadioButton1" runat="server" GroupName="TipBus" 
                    Text="Por Periodo:" TextAlign="Left" EnableTheming="False" Height="20px" Width="120px" />
                    <asp:RadioButton ID="RadioButton2" runat="server" 
                    GroupName="TipBus" Text="Al día:" TextAlign="Left" EnableTheming="False" Height="20px" Width="100px"/>
                &nbsp;&nbsp;&nbsp;<asp:Label ID="LabelHora" runat="server" 
                    Text="00:00 am"> Horas</asp:Label>
            </div>
                </div>
                </center>
            <asp:Label
                ID="Label13" runat="server" ForeColor="#CC3300" Text="Label" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                ID="BtnConsultVentas" runat="server" Text="Consultar" class="btn btn-info" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="Total: $"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="LblTotPeriodo" runat="server" Text="00.0"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
        </div>
        <div class="row">
            <br />
            <%-- <script type="text/javascript" >
        function SelectCalendar() {
            var avz = false;
            var mostrarfecha;
            /*var control_1 = document.getElementById('< %= Calendar1.ClientID%>');*/
            var control_1 = document.getElementById('fechahora');
            /*if (control_1.hasAttribute('SelectedDate') == null) {
                alert('debe seleccionar una fecha del control');
            }*/
            var localDate = picker.getLocalDate();
            alert('seleccionó' + localDate);
            return avz
        }
    </script>--%>
            <a href="WebFormViwer.aspx">Ver grafico</a>
            <center>
            <div class  ="col-md-6">
                <label>Inicial</label>&nbsp;
                   <input type="date" id="dtFrom" name="dtFrom" step="1" min="2000-01-01" max="2077-12-31"  aria-dropeffect="popup" required="required" />
            </div>
            <div class ="col-md-6" >
                <label>Final</label>&nbsp;<input type="date" id="dtTo" name="dtTo" step="1" min="2000-01-01" max="2077-12-31" />
            </div>
            </center>
            <script type="text/javascript">
                $(document).ready(function () {
                    $("#dtFrom").focusout(function ()
                        /*$("#FeaturedContent_BtnConsultVentas").click(function ()*/ {
                        var currentDate = $("#dtFrom").val();
                        /*$("FeaturedContent_Label11").text = currentDate;*/
                        document.cookie = "Fecha_ini=" + currentDate;

                    });
                    $("#dtTo").focusout(function () {
                        var currentDate2 = $("#dtTo").val();
                        document.cookie = "Fecha_fin=" + currentDate2;

                    });
                });
            </script>
        </div>
        <%--<input type=“datetime” name=“fechahora”>
                  
                    <div id="datetimepicker" class="input-append date">
      <input type="text"></input>
      <span class="add-on">
        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
      </span>--%>
        <div class="row">
             <div style="margin-left:8px">
                 <asp:GridView ID="GridView1" runat="server" BackColor="White"
                     BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                     GridLines="Vertical" Width="90%">
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

                 <asp:Label ID="Label6" runat="server" ForeColor="Red" Text=". . ."></asp:Label>
             </div>

        </div>
   </DIV>
    <!-- Script para control datepker-->
    <%--<script type ="text/javascript" src="Scripts/jquery.min.js">
    </script>--%>
        <!-- Seccion de script bootstrap -->
    <%--<script type="text/javascript"
     src="http://cdnjs.cloudflare.com/ajax/libs/jquery/1.8.3/jquery.min.js">
    </script> 
    <script type="text/javascript"
     src="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/js/bootstrap.min.js">
    </script>
    <script type="text/javascript"
     src="http://tarruda.github.com/bootstrap-datetimepicker/assets/js/bootstrap-datetimepicker.min.js">
    </script>
    <script type="text/javascript"
     src="http://tarruda.github.com/bootstrap-datetimepicker/assets/js/bootstrap-datetimepicker.pt-BR.js">
    </script>--%>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
