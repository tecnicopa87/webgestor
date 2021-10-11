<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Gestor/Reportes.Master" CodeBehind="VistaReporte0.aspx.vb" Inherits="GestorVS2012.VistaReporte" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%--<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:TextBox ID="txtdateIni" TextMode="Date" runat="server" Width="124px" Text="25/08/2021"></asp:TextBox><asp:TextBox ID="txtdateFin" TextMode="Date" runat="server" Width="124px" Text="30/08/2021"></asp:TextBox>
    <%--<input type="date" id="dateIni" value="01/01/2019" runat="server" />&nbsp;<input type="date" id="dateFin" value="01/01/2019" runat ="server"  />--%>

    <asp:Button ID="Button1" runat="server" Text="Buscar" />
&nbsp;
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <rsweb:ReportViewer ID="ReportViewerR" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Gestor\Report2.rdlc">
           <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet1" />
            </DataSources>
        </LocalReport> 
</rsweb:ReportViewer>   
    
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GestorVS2012.datosGraficarTableAdapters.Cortes001_________TableAdapter">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="" Name="fechaini" SessionField="dateIni" Type="DateTime" />
            <asp:SessionParameter DefaultValue="" Name="fechafin" SessionField="dateFin" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="gestorFacturasDataSetTableAdapters.Clientes001_________TableAdapter"></asp:ObjectDataSource>--%>
    
    </asp:Content>
