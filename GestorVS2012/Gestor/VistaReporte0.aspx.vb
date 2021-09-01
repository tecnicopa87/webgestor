'Imports CrystalDecisions.Shared
'Imports CrystalDecisions.CrystalReports.Engine *
'Imports Microsoft.Reporting.WebForms ' <- clave para ReportDataSource
'Imports CrystalDecisions.Shared '<- requerido para declarar parametros
Imports System.Configuration
Imports System.Web

Public Class VistaReporte
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'Dim Report As New ReportDocument
        'Report.Load("~/ReportCortes.rdlc")
        Dim dtReport As New DataTable '* dtRep
        dtReport.TableName = "datosGraficar"
        'dtReport.Columns.Add("Folventa") '* dtRep
        dtReport.Columns.Add("Monto") '* dtRep
        dtReport.Columns.Add("Utilidad") '* dtRep
        dtReport.Columns.Add("Fecha") '* dtRep
        Dim dr As DataRow '* dtRep
        dr = dtReport.NewRow '* dtRep
        'dr("Folventa") = 21 '* dtRep
        dr("Monto") = 352.25 '* dtRep
        dr("Utilidad") = 23
        dr("Fecha") = "02/03/2019" '* dtRep
        dtReport.Rows.Add(dr) '* dtRep
        ' ' ######                    #####
        'Dim rpt As New ReportDocument '*
        'rpt.Load("Report2.rdlc") '**

        'Dim Parametros As ParameterFields = New ParameterFields() '**
        'Dim nombrenegocio As ParameterField = New ParameterField() '**
        'Dim params As New ReportParameter '**

        'params.Name = "NombreNegocio" '**
        ''params."EMPRESA DEMO S.A DE C.V"
        'Dim crdefinitions As ParameterFieldDefinitions '**
        'Dim crdefinition As ParameterFieldDefinition '**
        'Dim crparamvalues As New ParameterValues '**


        'Dim myDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue() '**

        'nombrenegocio.ParameterFieldName = "NombreNegocio"
        'myDiscreteValue.Value = "EMPRESA DEMO S.A DE C.V" '**
        'crdefinitions = rpt.DataDefinition.ParameterFields '**
        'crdefinition = crdefinitions.Item("NombreNegocio") '**
        'crparamvalues = crdefinition.CurrentValues '**
        'crparamvalues.Add(myDiscreteValue) '**

        'ReportViewer1.LocalReport.SetParameters(params) '**
        'nombrenegocio.CurrentValues.Add(myDiscreteValue)
        'Parametros.Add(nombrenegocio)

        ''ReportViewer1.ParameterFieldInfo = Parametros
        'rpt.ParameterFields("NombreNegocio").CurrentValues = nombrenegocio.DefaultValues


        'rpt.SetParameterValue("recibido", myDiscreteValue.Value) ' del tipo definido en el informe
        ' ####                      #######


        '' ReportViewer1.ServerReport.ReportPath = "~/ReportCortes.rdlc"

        'ReportViewer1.ProcessingMode = ProcessingMode.Local
        'ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("datosGraficar", dtReport)) '* dtRep
        'ReportViewer1.DataBind() '* dtRep

    End Sub

End Class