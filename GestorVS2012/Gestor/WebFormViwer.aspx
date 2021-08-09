<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebFormViwer.aspx.vb" Inherits="GestorVS2012.WebFormViwer" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br /><asp:TextBox runat="server" ID="txtfech" Text ="00/00/2000"></asp:TextBox>        
        <ajaxtoolkit:CalendarExtender ID="fechini" runat="server" TargetControlID="txtfech" Format ="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>                                 
        <asp:TextBox runat="server" ID="txtfech2" Text ="00/00/2000" ></asp:TextBox>
        <ajaxtoolkit:CalendarExtender ID="fechfin" runat="server" TargetControlID="txtfech2" Format ="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
        <asp:Button ID="btnGenerar" runat="server" Text ="Generar Reporte" class="btn btn-primary" />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ShowExportControls="False" ShowFindControls="False" Width="687px">
            <LocalReport ReportEmbeddedResource="Report2.rdlc" ReportPath="Report2.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="GestorVS2012.datosGraficarTableAdapters.Cortes001_________TableAdapter" OldValuesParameterFormatString="original_{0}">
        </asp:ObjectDataSource>
    
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
