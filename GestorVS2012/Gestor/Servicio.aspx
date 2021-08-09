<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Servicio.aspx.vb" Inherits="GestorVS2012.Servicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
        .style1
        {
            height: 21px;
        }
        .style2
        {
            height: 21px;
            width: 370px;
        }
        .style3
        {
            width: 370px;
        }
        .style4
        {
            height: 21px;
            width: 315px;
        }
        .style5
        {
            width: 315px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class ="row" style ="margin-left :10px" >
        <div class ="col-sm-6 col-md-8">
        Config. APP <asp:Label ID="LblTipServicio" runat="server" Text="ninguno"></asp:Label>
            &nbsp;&nbsp;<asp:Label ID="LabelCliente" runat="server" Text="Cliente"></asp:Label>
            </div>
        <div class ="col-sm-6 col-md-8" style="text-align :right ">
             <asp:Label ID="Label2" runat="server" Text="00/00/00"></asp:Label>
        </div>
        <div class ="col-sm-6 col-md-8" >
            <asp:Label ID="Label3" runat="server" Text="IP/Dominio del Servidor:"></asp:Label>
                    <asp:TextBox ID="TxtDominioServidor" runat="server" Width="211px"></asp:TextBox>
                    <br />
                    <br />
                    <label ID="Label4">Puerto :</label>
&nbsp;
                    <asp:TextBox ID="TxtPuertoServidor" runat="server"  Width="69px"></asp:TextBox>
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
             <asp:Button ID="Button1" runat="server" Text="Conectar" Enabled="False" />
        </div>
        <div class ="col-sm-6 col-md-8" >
             Estado de Aplicacion<label ID="LbluserSQL" >:</label>
                    <br />
                    <br />
                   
                    <asp:Label ID="LblConfig" runat="server" Text="Label" Visible="False" 
                        ForeColor="#33CCFF"></asp:Label>
                    <br />
                    <asp:Label ID="LblError" runat="server" Font-Size="Medium" ForeColor="#FF5050" Text="LblError" Visible="False"></asp:Label>
        </div>
        <div><asp:Image ID="Image1" runat="server" ImageUrl="~/images/conecta_mundo.jpg" /></div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
