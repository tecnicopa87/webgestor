Imports GestorEntities
Imports gestorDataAcces

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.Cookies("SESSION-GESTOR") Is Nothing Then
            Response.Redirect("../Default.aspx")
        End If

        If Session("tabGeneradas") Is Nothing Then
            Response.Redirect("Servicio.aspx")
        End If
        LabelHora.Text = TimeString & " Horas"
        Label11.Text = Format(Date.Now, "dd/MM/yyyy")
        Label12.Text = Format(Date.Now, "dd/MM/yyyy")
        Try
            Dim Emisor As New DatosEmpDAL
            Dim DatEmisor As New DatosEmpresa
            DatEmisor = Emisor.GetONE(Session("idClient"))
            LblNombEmp.Text = DatEmisor.Titulo
            Label7.Text = DatEmisor.Dircalle & " " & DatEmisor.noExt & ", " & DatEmisor.Colonia
        Catch ex As Exception
            'quedan valores por defecto en los labels

        End Try
        'ImageButton1.Attributes.Add("onClick", "javascript:return DespliegaClient();")

        ' % Debo consultar tabla Facturas-idclient para mostrar folsiguiente automaticamente
        Dim conn As New Conexion

        Label13.Visible = False 'muestra result consulta *
        ' Calendar1.Attributes.Add("OnVisibleMonthChanged", "javascript:return SelectCalendar();")
    End Sub

    Protected Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        'Calendar1.Visible = False
        ' Calendar2.Visible = False
    End Sub

    Protected Sub BtnConsultVentas_Click(sender As Object, e As EventArgs) Handles BtnConsultVentas.Click

        Dim ConVentas As New VentasDAL
        Dim dsC As New Data.DataSet
        Dim result As String
        Try
            Label11.Text = Request.Cookies("Fecha_ini").Value
            Label12.Text = Request.Cookies("Fecha_fin").Value
        Catch ex As Exception
            If RadioButton2.Checked = False Then
                Response.Write("Formato incorrecto o falta seleccionar un paràmetro")
                Exit Sub
            End If
        End Try
        

        If RadioButton1.Checked = True Then ' Consulta por Periodo
            'If Calendar2.SelectedDates Is Nothing Then
            '    Calendar2.SelectedDate = Date.Today

            'End If
            Dim str As String
            'str = Calendar1.SelectedDate.Date & "|" & Calendar2.SelectedDate.Date
            Dim Inicial, Final As Date
            Inicial = Date.Parse(Label11.Text) ' Format(Label11.Text, "dd/MM/yyyy")
            Final = Date.Parse(Label12.Text) 'Format(Label12.Text, "dd/MM/yyyy")

            dsC = ConVentas.ConsultRemotVntas(Session("idClient"), "P", Inicial, Final) 'Calendar2.SelectedDate.Date)
            'Label6.Text = ConVentas.verificSQL '* SOLO TEST MARZ-16 
            Try
                result = dsC.Tables(0).Rows(0)(0)
                'Label11.Text = Calendar1.SelectedDates.Item(0).Date
                'Label12.Text = Calendar2.SelectedDates.Item(Calendar2.SelectedDates.Count - 1).Date
            Catch ex As Exception
                Label13.Text = "No se encontraron resultados"
                Label13.Visible = True
                GridView1.DataBind()
                Exit Sub
            End Try
        ElseIf RadioButton2.Checked = True Then ' Consulta Al dìa
            dsC = ConVentas.ConsultRemotVntas(Session("idClient"), "A")
            Try
                result = dsC.Tables(0).Rows(0)(0)
            Catch ex As Exception
                Label13.Text = "No se encontraron resultados"
                Label13.Visible = True
                GridView1.DataBind()
                Exit Sub
            End Try
        End If
        If dsC IsNot Nothing Then
            GridView1.DataSource = dsC.Tables(0)
            GridView1.DataBind()
        End If
       
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim drv As System.Data.DataRowView

        drv = CType(e.Row.DataItem, System.Data.DataRowView)
        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Cells(5).Text = FormatCurrency(e.Row.Cells(5).Text)
            e.Row.Cells(4).Text = FormatCurrency(e.Row.Cells(4).Text)
            e.Row.Cells(3).Text = FormatCurrency(e.Row.Cells(3).Text)
            e.Row.Cells(2).Text = FormatNumber(e.Row.Cells(2).Text, 2)
            e.Row.Cells(1).Text = FormatNumber(e.Row.Cells(1).Text, 2)
            If drv IsNot Nothing Then

                For Each cell As TableCell In e.Row.Cells

                    cell.Wrap = False

                Next
                '

            End If
        End If
    End Sub

    'Private Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar1.SelectionChanged
    '    Dim firstdate As Date
    '    Dim lastdate As Date
    '    With Calendar1.SelectedDates
    '        firstdate = .Item(0).Date
    '        lastdate = .Item(.Count - 1).Date

    '    End With
    '    If lastdate > firstdate Then
    '        Calendar2.SelectedDate = lastdate
    '    Else
    '        Calendar2.SelectedDate = Date.Today
    '    End If

    'End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        'Calendar1.Visible = True
        'Calendar2.Visible = True
    End Sub

    'Private Sub Calendar1_DayRender(sender As Object, e As DayRenderEventArgs) Handles Calendar1.DayRender

    '    e.Cell.Attributes.Add("OnClick", "return SelectCalendar();")

    'End Sub

   
    'Private Sub Calendar2_DayRender(sender As Object, e As DayRenderEventArgs) Handles Calendar2.DayRender
    '    e.Cell.Attributes.Add("OnClick", "return SelectCalendar();") <- si funciona pero ya no es utilizado *
    'End Sub

End Class