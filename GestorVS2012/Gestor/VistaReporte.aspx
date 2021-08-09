<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Gestor/Reportes.Master" CodeBehind="VistaReporte.aspx.vb" Inherits="GestorVS2012.VistaReporte" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <input type="date" id="dateIni" value="01/01/2019" />&nbsp;<input type="date" id="dateFin" value="01/01/2019" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportEmbeddedResource="GestorVS2012.Report1.rdlc" ReportPath="Gestor/Report1.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="gestorFacturasDataSetTableAdapters.Clientes001_________TableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GestorVS2012.gestorFacturasDataSetTableAdapters.Clientes001_________TableAdapter">
        <InsertParameters>
            <asp:Parameter Name="CveCliente" Type="String" />
            <asp:Parameter Name="Nombre" Type="String" />
            <asp:Parameter Name="RFC" Type="String" />
            <asp:Parameter Name="Regimen" Type="String" />
            <asp:Parameter Name="Calle" Type="String" />
            <asp:Parameter Name="noExt" Type="String" />
            <asp:Parameter Name="noInt" Type="String" />
            <asp:Parameter Name="Colonia" Type="String" />
            <asp:Parameter Name="Municipio" Type="String" />
            <asp:Parameter Name="Pais" Type="String" />
            <asp:Parameter Name="Estado" Type="String" />
            <asp:Parameter Name="CP" Type="String" />
            <asp:Parameter Name="email" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    
    </asp:Content>
