Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("MensajeUsuarioRegistrado") IsNot Nothing Then
            LabelInicial.Text = "Se ha registrado correctamente,espere un email para confirmar su acceso al sistema" & vbCrLf & "(este proceso puede demorar hasta 24horas)"
        End If
        If Request.Cookies("SESSION-GESTOR") IsNot Nothing Then
            LabelInicial.Text = " Ahora puedes revisar todas las opciones que Gestor Easy Control tiene para tí"
        End If
    End Sub
End Class