Imports gestorDataAcces
Imports System.Data

Public Class ConsultarFact
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Cookies("SESSION-GESTOR") Is Nothing Then
            Response.Redirect("../Default.aspx")
        End If
        If Session("tabGeneradas") Is Nothing Then
            Response.Redirect("Servicio.aspx")
        End If
        'ImageButton1.Attributes.Add("onClick", "javascript:return DespliegaClient();")

        ' % Debo consultar tabla Facturas-idclient para mostrar folsiguiente automaticamente
        Dim conn As New Conexion
        Dim correcto As Boolean
        'correcto = conn.GenerarTablatmp '<- % Provicional usaba ésta xq debía eliminar contenido al terminar su factura
        'Ahora Sep-2016 uso una sola tmp para todos los usuarios,filtrando campo "idUsuario"

        If correcto = False Then
            ' Label6.Text = "No se pudo generar la tabla"
        End If

        Dim consec As New VentasDAL
        ' seccion online -
        'Dim folmostrar As String   <- Sep-2016  descomentar y validar antes si es remoto omita esto
        'folmostrar = consec.CheckConsecVnta(Session("idClient"))
        'DropDownList2.Items.Add(folmostrar) '  (segun el # d facts emitidas online,èste se`rá automatico)
        ' seccion online -

        'limpiar controles
        'TextBox1.Text = ""
        'TextBox2.Text = ""
        'TextBox3.Text = ""
        'TextBox4.Text = ""
        'TextBox1.Focus()
        Label13.Visible = False 'muestra result consulta *
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim CabezalF As New FacturasDAL
        If Request.Cookies("Fact_ini") Is Nothing Or Request.Cookies("Fact_fin") Is Nothing Then
            Label13.Text = "Debe seleccionar una fecha válida"
            Label13.Visible = True
            Exit Sub
        End If
        Dim iva, ieps As Decimal
        'iva = Val(TextBox3.Text) * 0.16
        ieps = 0
        Dim dsC As New DataSet
        Dim idlineas As String
        If RadioButton1.Checked = True Then
            Label11.Text = Request.Cookies("Fact_ini").Value
            Label12.Text = Request.Cookies("Fact_fin").Value
            Dim FactIni, FactFin As Date
            FactIni = Date.Parse(Label11.Text) 'Date.ParseExact(Label11.Text, "dd/MM/yyyy 00:00:00", System.DateTime.ParseExact)
            FactFin = Date.Parse(Label12.Text) 'Date.TryParseExact(Label12.Text, "dd/MM/yyyy 00:00:00", System.DateTimeKind)
            dsC = CabezalF.BuscaCbzlFact(Session("idClient"), "P", "0", FactIni, FactFin)
        ElseIf RadioButton2.Checked = True Then
            dsC = CabezalF.BuscaCbzlFact(Session("idClient"), "F", DropDownList2.SelectedValue)
        End If
        Try
            Label11.Text = dsC.Tables(0).Rows(0)(1)
            TextBox2.Text = dsC.Tables(0).Rows(0)(2)
            idlineas = dsC.Tables(0).Rows(0)(3)
        Catch ex As Exception
            Label13.Text = "No se encontraron resultados"
            Label13.Visible = True
        End Try


        Dim fmanual As Boolean
        '*If fmanual = True Then

        '*Dim PreVnta As Preventa = VntaM.VisualizPrevnta("001") 'Invoko al metodo

        'Dim ds As New DataSet
        'ds = PreVnta.Dset 'Leo su propiedad Dataset 
        '*GridView1.DataSource = PreVnta.Dset.Tables(0)  'ds.Tables(0)
        '*GridView1.DataBind()
        '*Label8.Text = PreVnta.Importe 'leo su propiedad Importe

        '*End If
        GridView1.DataSource = dsC.Tables(0)
        GridView1.DataBind()

    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim drv As System.Data.DataRowView
        drv = CType(e.Row.DataItem, System.Data.DataRowView)
        If e.Row.RowType = DataControlRowType.DataRow Then
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
End Class