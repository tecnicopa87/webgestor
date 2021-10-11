'Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine ' *
Imports Microsoft.Reporting.WebForms ' <- clave para ReportDataSource
Imports CrystalDecisions.Shared '<- requerido para declarar parametros
Imports System.Configuration
Imports System.Web
Imports System.ComponentModel
'Imports System.Web.Services '*webmethod
Imports System.Web.Script

Public Class VistaReporte
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If Request.QueryString("fini") IsNot Nothing And Request.QueryString("ffin") IsNot Nothing Then
                Dim dateIni As Date
                dateIni = Request.QueryString("fini")
                txtdateIni.Text = Request.QueryString("fini")
                txtdateFin.Text = Request.QueryString("ffin")
                Dim ods As New ObjectDataSource("GestorVS2012.datosGraficarTableAdapters.Cortes001_________TableAdapter", "GetData")
                ods.SelectParameters.Add("@fechaini", Request.QueryString("fini"))
                ods.SelectParameters.Add("@fechafin", Request.QueryString("ffin"))

                ReportViewerR.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", ods)) '* dtRep
                ReportViewerR.DataBind()
            End If
            ''Dim Report As New ReportDocument
            ''Report.Load("~/ReportCortes.rdlc")
            'Dim dtReport As New DataTable '* dtRep
            'dtReport.TableName = "DataSet1"
            ''dtReport.Columns.Add("Folventa") '* dtRep
            'dtReport.Columns.Add("monto") '* dtRep
            'dtReport.Columns.Add("fecha") '* dtRep
            'dtReport.Columns.Add("utilidad") '* dtRep

            'Dim dr As DataRow '* dtRep
            'dr = dtReport.NewRow '* dtRep
            ''dr("Folventa") = 21 '* dtRep
            'dr("monto") = 357.25 '* dtRep
            'dr("fecha") = "22/08/2021" '* dtRep
            'dr("utilidad") = 59

            'dtReport.Rows.Add(dr) '* dtRep        
            'Dim dr2 As DataRow '* dtRep
            'dr2 = dtReport.NewRow '* dtRep
            ''dr("Folventa") = 21 '* dtRep
            'dr2("monto") = 152.25 '* dtRep
            'dr2("utilidad") = 42
            'dr2("fecha") = "24/08/2021" '* dtRep
            'dtReport.Rows.Add(dr2) '* dtRep  
            '' ' ######                    #####
            ''Dim rpt As New ReportDocument '*
            ''rpt.Load("Report2.rdlc") '**

            'Dim Parametros As ParameterFields = New ParameterFields() '**
            ''Dim nombrenegocio As ParameterField = New ParameterField() '**
            Dim params As New ReportParameter '**

                params.Name = "NombreNegocio" '**
                params.Values.Add("EMPRESA XXX S.A DE C.V")
                '''params."EMPRESA DEMO S.A DE C.V"
                ''Dim crdefinitions As ParameterFieldDefinitions '**
                ''Dim crdefinition As ParameterFieldDefinition '**
                ''Dim crparamvalues As New ParameterValues '**


                ''Dim myDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue() '**

                ''nombrenegocio.ParameterFieldName = "NombreNegocio"
                ''myDiscreteValue.Value = "EMPRESA DEMO S.A DE C.V" '**
                ''crdefinitions = rpt.DataDefinition.ParameterFields '**
                ''crdefinition = crdefinitions.Item("NombreNegocio") '**
                ''crparamvalues = crdefinition.CurrentValues '**
                ''crparamvalues.Add(myDiscreteValue) '**

                'ReportViewerR.LocalReport.ReportPath = "Gestor\Report2.rdlc"
                ReportViewerR.LocalReport.SetParameters(params) '**
                ReportViewerR.LocalReport.Refresh()
                ''nombrenegocio.CurrentValues.Add(myDiscreteValue)
                ''Parametros.Add(nombrenegocio)

                '''ReportViewer1.ParameterFieldInfo = Parametros
                ''rpt.ParameterFields("NombreNegocio").CurrentValues = nombrenegocio.DefaultValues


                ''rpt.SetParameterValue("recibido", myDiscreteValue.Value) ' del tipo definido en el informe
                '' ####                      #######


                ''' ReportViewer1.ServerReport.ReportPath = "~/ReportCortes.rdlc"

                'ReportViewerR.ProcessingMode = ProcessingMode.Local
                'Dim ods As New ObjectDataSource("GestorVS2012.datosGraficarTableAdapters.Cortes001_________TableAdapter", "GetData")
                'ods.SelectParameters.Add("@fechaini", txtdateIni.Text)
                'ods.SelectParameters.Add("@fechafin", txtdateFin.Text)
                ''ods.DataBind()

                'ReportViewerR.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", dtReport)) '* dtRep
                ''ReportViewerR.LocalReport.DataSources.Add(New ReportDataSource("datosGraficar", dtReport))
                'ReportViewerR.DataBind() '* dtRep
            End If
            Button1.Attributes.Add("onClick", "javascript:return true;") '*funcion clave resolver inputs que no son asp

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtdateIni.Text IsNot Nothing And txtdateFin.Text IsNot Nothing Then
            Dim dateIni As Date
            Dim dateFin As Date
            dateFin = Convert.ToDateTime(txtdateFin.Text)
            dateIni = Convert.ToDateTime(txtdateIni.Text) 'funcionaría pero en el postback no ejecuta el ObjectDataSource
            Session("dateIni") = dateIni 'se puede asignar previo al ObjectDataSource en modo diseño
            Session("dateFin") = dateFin
            Response.Redirect("VistaReporte0.aspx?fini=" & dateIni.ToShortDateString & "&ffin=" & dateFin.ToShortDateString)

        End If
    End Sub

    Private Sub ReportViewerR_ReportRefresh(sender As Object, e As CancelEventArgs) Handles ReportViewerR.ReportRefresh
        Dim dateIni As Date
        Dim dateFin As Date
        dateFin = Convert.ToDateTime(txtdateFin.Text)
        dateIni = Convert.ToDateTime(txtdateIni.Text)
        Dim params As New ReportParameter '**

        params.Name = "NombreNegocio" '**
        params.Values.Add("EMPRESA XXX S.A DE C.V")
        ReportViewerR.ProcessingMode = ProcessingMode.Local
        Dim ods As New ObjectDataSource("GestorVS2012.datosGraficarTableAdapters.Cortes001TableAdapter", "GetData")
        ods.SelectParameters.Add("fechaini", txtdateIni.Text)
        ods.SelectParameters.Add("fechafin", txtdateFin.Text)
        ods.DataBind()
        ReportViewerR.LocalReport.SetParameters(params)
        ReportViewerR.LocalReport.ReportPath = "Gestor\Report2.rdlc"
        ReportViewerR.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", ods))
        ReportViewerR.DataBind 
        'document.getElementById('dateFin').value
    End Sub
    '<WebMethod()>
    'Public Shared Function BuscaPeriodo(ByVal fechaIni As String, ByVal fechafin As String) As List(Of String)
    '    Dim a As List(Of String)

    '    Return a
    'End Function
End Class