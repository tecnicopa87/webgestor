<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="GestorVS2012.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href ="../Content/bootstrap.css" rel="stylesheet" />
    <hgroup class="title">
        <h1>CONOCE NUESTRA APLICACION.</h1>
    </hgroup>

    <article>
        <p>        
            Gestor de factura EASY CONTROL te permite llevar una contabilidad basica de tu negocio, agilizando los procesos de compra y facturacion electronica con muy pocos menus.<br />
            Ahora desde tu laptop o dispositivo mòvil registraràs todas tus operaciones monetarias
        </p>

        <p>        
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ejecutivos.jpg" />
        </p>

        <p>        
            Si ya cuentas con nuestro sistema de punto de venta podràs consultarlo desde esta app; desde el lugar en que te encuentres revisar tus ventas y registrar alguna compra directo a tu terminal TPV..
        </p>
        <p>
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/app_ejemplo1.png" Width="80%" /><br />
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/app_ejemplo2.png" Width="80%" />
        </p>
    </article>
    
    <aside>
        <h3>Portafolio</h3>
        <p>        
            Conoce Otras aplicaciones en MVC .
        </p>
        <ul>
            <li><a runat="server" href="http://localhost:88/">App Bodegas</a></li>
            <li><a runat="server" href="~/About.aspx">About</a></li>
            <li><a runat="server" href="~/Contact.aspx">Contact</a></li>
        </ul>
    </aside>
</asp:Content>