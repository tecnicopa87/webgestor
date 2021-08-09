Imports gestorDataAcces

Public Class WebForm3
    Inherits System.Web.UI.Page
    Dim AutorizCuentas As Boolean
    Dim CambiaStatusApp As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Cookies("SESSION-GESTOR") Is Nothing Then
            Response.Redirect("../Default.aspx")
        End If
        If Session("idClient") = Nothing Then
            Response.Redirect("../Default.aspx")
        ElseIf Session("idClient") = "A00" Then
            Session("idAdmin") = "A00"
            GridView1.Visible = True
        End If
        Dim Urlparam As String '= Request.QueryString("ReturnUrl")
        Dim urlParametro As String = Request.QueryString("opt") '<- esto también funciona
        Urlparam = Page.Request.RawUrl
        If urlParametro = "ac" Then '<- esto también funciona
            AutorizCuentas = True
        ElseIf urlParametro = "ct" Then

        ElseIf urlParametro = "status" Then
            CambiaStatusApp = True
        End If
        If Urlparam = "/Gestor/Admin.aspx?opt=ac" Then
            GridView1.Visible = True
            Label2.Visible = True
            TxtNoCFDIs.Visible = True
        ElseIf Urlparam = "/Gestor/Admin.aspx?opt=ct" Then
            '*
        ElseIf Urlparam = "/Gestor/Admin.aspx?opt=status" Then
            gvInfoClientes.Visible = True

        End If


    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim ind As GridViewRow = GridView1.SelectedRow

        Dim idUsuario As String = Convert.ToString(ind.Cells(3).Text) 'Convert.ToString(GridView1.DataKeys("idCliente").Value)
        Dim NUsuario As String = Convert.ToString(ind.Cells(1).Text)
        Dim OpeBD As New Conexion
        Dim result As String
        result = OpeBD.AutorizCuentaUsuario(idUsuario, IIf(TxtNoCFDIs.Text = "", 0, TxtNoCFDIs.Text))
        If result = String.Empty Then
            LabelResult.Text = "Se autorizó a " & NUsuario & " correctamente"
            LabelResult.ForeColor = Drawing.Color.Azure
        Else
            LabelResult.Text = result
        End If
    End Sub

    Private Sub TreeView1_DataBinding(sender As Object, e As EventArgs) Handles TreeView1.DataBinding

    End Sub

    Private Sub TreeView1_SelectedNodeChanged(sender As Object, e As EventArgs) Handles TreeView1.SelectedNodeChanged
        If TreeView1.SelectedNode.NavigateUrl = "~/Gestor/Admin.aspx?opt=ac" Then
            GridView1.Visible = True
        ElseIf TreeView1.SelectedNode.NavigateUrl = "~/Gestor/Admin.aspx?opt=ct" Then
            gvInfoClientes.Visible = True
        End If
    End Sub


    Protected Sub BntConfigurar_Click(sender As Object, e As EventArgs) Handles BntConfigurar.Click
        'For Each itm As ListViewItem In ListView1.Items
        '    'If itm.
        'Next
        'Session("idClient") = 'ListView1.SelectedDataKey.Value
        If CambiaStatusApp = True Then
            Dim OpeBD As New Conexion
            For Each itm As GridViewRow In gvInfoClientes.Rows
                Dim checksb As CheckBox = CType(gvInfoClientes.Rows(itm.RowIndex).FindControl("chkEdoApp"), CheckBox)
                'If checksb.Checked = True Then
                Dim id As String
                id = Trim(itm.Cells(0).Text)
                Dim result As String
                result = OpeBD.ActualizaEstatusApp(id, checksb.Checked)
                If result <> String.Empty Then
                    MsgBox("Ocurrió un problema, " & result)
                    Exit For
                End If
                'End If
            Next
        End If
        'Response.Redirect("~/Gestor/Servicio.aspx")
    End Sub

    'Private Sub ListView1_DataBinding(sender As Object, e As EventArgs) Handles ListView1.DataBinding

    'End Sub

    Private Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvInfoClientes.SelectedIndexChanged
        Dim ind As GridViewRow = gvInfoClientes.SelectedRow

        Dim idUsuario As String = Convert.ToString(ind.Cells(4).Text)
        Session("idClient") = idUsuario
    End Sub
End Class