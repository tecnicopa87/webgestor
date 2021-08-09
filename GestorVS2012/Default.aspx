<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="GestorVS2012._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <%--<link href ="../Content/bootstrap.css" rel="stylesheet" />--%>
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>&nbsp;Conéctacte a tu terminal donde te encuentres.</h1>
            </hgroup>
            <p>
               <asp:Label ID="LabelInicial" runat ="server"  Text ="Para explorar las opciones de menu debes estar logueado con tu nombre de usuario y contraseña vigentes."></asp:Label>
            </p>
        </div>
    </section>
    
 <%-- <script type ="text/javascript">
      $(document).ready(function () {

          $("#Button1").click(function () {
              var currentDate = $("#periodo").val();
              alert('Fecha:' + currentDate);
          });
      });
       </script>--%>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Opciones de la app:</h3>
    <ol class="round">
        <li class="one">
            <h5>Ventas</h5>
            &nbsp;<%-- <script type="text/javascript">
        $('#datetimepicker').datetimepicker({
            format: 'dd/MM/yyyy hh:mm:ss',
            language: 'pt-BR'
        });
        
    </script>--%>puede consultar las ventas de tu sucursal desde ésta aplicacion, por fecha o por día siempre que tengas conexion a internet&nbsp;
            <a href="Default.aspx">Ver mas…</a>
        </li>
        <li class="two">
            <h5>Compras</h5>
            Registrar tus compras y verlas reflejada en el inventario de tu sucursal.
            <a href="Default.aspx">Ver mas…</a>
        </li>
        <li class="three">
            <h5>Facturas</h5>
            El proceso de generar facturas tambíen será posible hacerlo desde tu movil, pero es recomendable hacerlo desde un lugar seguro donde no expongas tus datos en redes publicas o en conexiones inestables para evitar errores en el proceso.
            <a href="Default.aspx">Ver mas…</a>
        </li>
    </ol>
     <%--<!-- Seccion de script bootstrap -->
        <script src ="../Scripts/jquery-1.9.1.js"></script>
        <script src ="../Scripts/bootstrap.js"></script>--%>
</asp:Content>
