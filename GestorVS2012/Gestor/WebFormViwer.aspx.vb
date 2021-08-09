Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Reporting.WebForms
Imports gestorDataAcces

Public Class WebFormViwer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Dim rpt As New ReportDocument
        If Not Page.IsPostBack Then
            'ReportViewer1.Visible = False
            Dim DsCortes As New DataTable
            DsCortes.TableName = "DSCortes_" 'DsCortes
            With DsCortes.Columns
                .Add("monto")
                .Add("utilidad")
                .Add("fecha")
            End With
            Dim ds As New DataSet
            ds.Tables.Add(DsCortes)
            ReportViewer1.LocalReport.ReportPath = Server.MapPath(("Report2.rdlc"))
            Dim rdc As ReportDataSource = New ReportDataSource("DSCortes_", ds.Tables(0)) '"Cortes" & Trim(Session("idClient") ds.Tables("StoredProcedure2"))
            ReportViewer1.LocalReport.DataSources.Add(rdc)            
            ReportViewer1.DataBind()
        End If

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim negocio As New VentasDAL

        Dim fini As Date
        If fechini.SelectedDate.HasValue Then
            fini = fechini.SelectedDate.Value  'Date.FromOADate(43396)
        Else
            fini = Date.FromOADate(43396)
        End If
        Dim ffin As Date = IIf(fechfin.SelectedDate.HasValue, fechfin.SelectedDate, Date.FromOADate(43412))  'Date.FromOADate(43412)
        Dim ds As New DataSet
        Dim DsCortes As New DataTable
        DsCortes.TableName = "DataSet1" '"DsCortes"
        With DsCortes.Columns
            .Add("monto")
            .Add("utilidad")
            .Add("fecha")
        End With
        Dim iss As String = Session("idClient")
        Dim dttmp As New DataTable ''ReportDataSource' solo acepta fijo=nombreDataset en Reporte
        dttmp = negocio.DatosGraficar(Session("idClient"), fini, ffin).Tables(0)

        For Each row As DataRow In dttmp.Rows
            Dim dr As DataRow = DsCortes.NewRow
            dr("monto") = row("monto")
            dr("utilidad") = row("utilidad")
            dr("fecha") = row("fecha")
            DsCortes.Rows.Add(dr)
        Next

        'ds =  negocio.DatosGraficar(Session("idClient"), fini, ffin) <- se requiere dinámico,pero 'ReportDataSource' solo acepta fijo=nombreDataset en Reporte
        ds.Tables.Add(DsCortes)

        ReportViewer1.LocalReport.ReportPath = Server.MapPath(("Report2.rdlc")) '(("RendimientoVentas.rdlc"))
        Dim rdc As ReportDataSource = New ReportDataSource("DataSet1", ds.Tables(0)) '"Cortes" & Trim(Session("idClient") ds.Tables("StoredProcedure2"))
        ReportViewer1.LocalReport.DataSources.Add(rdc)
        ReportViewer1.DataBind()
    End Sub
End Class