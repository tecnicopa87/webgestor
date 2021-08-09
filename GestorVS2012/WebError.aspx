<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="WebError.aspx.vb" Inherits="GestorVS2012.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:Image ID="Image2" runat="server" Height="53px" ImageUrl="~/Images/adverten.jpg" Width="84px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Se ha producido un error, revise que haya ingresado valores correctos" Font-Bold="True" Font-Size="Medium"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Text="Si continúa recibiendo ete error contacte al Administrador de la aplicacion"></asp:Label>
    </p>
</asp:Content>
