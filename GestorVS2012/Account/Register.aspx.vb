'Imports Microsoft.AspNet.Membership.OpenAuth
Imports gestorDataAcces
Imports GestorEntities

Public Class Register
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        RegisterUser.ContinueDestinationPageUrl = Request.QueryString("ReturnUrl")
    End Sub

    Protected Sub RegisterUser_CreatedUser(ByVal sender As Object, ByVal e As EventArgs) Handles RegisterUser.CreatedUser
        ' FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie:=False)

        'Dim continueUrl As String = RegisterUser.ContinueDestinationPageUrl
        'If Not OpenAuth.IsLocalUrl(continueUrl) Then
        '    continueUrl = "~/"
        'End If
        'Response.Redirect(continueUrl)
        'FormsAuthentication.SetAuthCookie(RegisterUser.UserName, False)
        Dim id As String
        Dim generarid As New DatosEmpDAL
        id = generarid.AsignaIDClient() ' id 'con formato 001

        Dim foo As Boolean = False
        foo = generarid.RegistraAccesoEmp(RegisterUser.UserName, RegisterUser.Email, RegisterUser.Password, id)
        If foo = False Then
            Response.Write("Ocurriò un error al registrar,intente mas tarde o contacte al admin")
            Exit Sub
        End If
        Dim continueUrl As String = RegisterUser.ContinueDestinationPageUrl
        If String.IsNullOrEmpty(continueUrl) Then
            continueUrl = "~/"
        End If
        'Dim miembrode As MembershipUser
        'miembrode .UserName .ToString 
        Session("MensajeUsuarioRegistrado") = "correcto"
        'Response.Redirect(continueUrl)
        Response.Redirect("~/Default.aspx")
    End Sub
End Class