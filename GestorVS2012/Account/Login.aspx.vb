Imports System.Data.SqlClient
Imports System.Configuration

Public Class Login
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'RegisterHyperLink.NavigateUrl = "Register.aspx"
        'OpenAuthLogin.ReturnUrl = Request.QueryString("ReturnUrl")

        'Dim returnUrl = HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
        'If Not String.IsNullOrEmpty(returnUrl) Then
        '    RegisterHyperLink.NavigateUrl &= "?ReturnUrl=" & returnUrl
        'End If
        If Request.QueryString("ct") = "0" Then
            Label1.Visible = True
        End If
    End Sub

    Private Sub LoginUser_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles LoginUser.Authenticate

        Dim Autenticado As Boolean = False
        Autenticado = VerificaLogin(LoginUser.UserName, LoginUser.Password)
        e.Authenticated = Autenticado
        If Autenticado = True Then
            '*--segundo metodo
            ' FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)
            If Session("NoCFDIs") = "null" And Session("idClient") <> "A00" Then
                LoginUser.FailureText = "Su cuenta no ha sido activada"
                Response.Redirect("Login.aspx?ct=0")
                'Exit Sub
            End If
            '*----------------
            Dim Remember As Boolean = LoginUser.RememberMeSet  'obtiene si coockie persistente
            Dim tkt As FormsAuthenticationTicket
            Dim cockiestr As String
            Dim htpck As HttpCookie '                                          fecha-hora,1 min caducidad
            tkt = New FormsAuthenticationTicket(1, LoginUser.UserName, DateTime.Now, DateTime.Now.AddMinutes(3), Remember, "RecordSesion")
            'la cokie se almacenarìa en texto plano y podrìa ser leìda facilmente !
            cockiestr = FormsAuthentication.Encrypt(tkt) 'entonces la encriptamos
            htpck = New HttpCookie(FormsAuthentication.FormsCookieName, cockiestr)

            Dim UrlAutorizada As String
            'verifico si la sesion es persistente:
            If Remember = True Then
                htpck.Expires = tkt.Expiration
                htpck.Path = FormsAuthentication.FormsCookiePath
                Response.Cookies.Add(htpck)

                If Session("idClient") = "A00" Then
                    'pagina para director o admin
                    UrlAutorizada = "~/Gestor/Admin.aspx"
                Else

                    UrlAutorizada = "~/" 'Request.QueryString("ReturnUrl")
                End If

            ElseIf Remember = False Then
                htpck.Expires = tkt.Expiration
                htpck.Path = FormsAuthentication.FormsCookiePath
                Response.Cookies.Add(htpck)

                ' -* Verifico si activò aplicacion *-
                Dim edo As Boolean
                edo = VerificAppClient(Session("idClient"))
                If edo = True Then
                    Session("tabGeneradas") = "si"
                    'para cargar catalogo de productos *
                    Dim cokieprod As New HttpCookie("tbProducts", "Productos" & Trim(Session("idClient")))
                    Response.Cookies.Add(cokieprod)
                End If

                If Session("idClient") = "A00" Then
                    'pagina para director o admin
                    UrlAutorizada = "~/Gestor/Admin.aspx"
                    Response.Redirect(UrlAutorizada, True)
                Else
                    UrlAutorizada = "~/" 'Request.QueryString ("ReturnUrl")
                    Response.Redirect(UrlAutorizada, True)
                End If
            End If
            '                  (urldestino,true <--si la ejecución actual debe terminar)
            'Response.Redirect(UrlAutorizada, True) **ESTO NO ES NECESARIO COMENTAR**

            'Si no es usuario autenticado
        Else
            Session("intentosLog") = Session("intentosLog") + 1
            LoginUser.UserName = ""

            If Session("intentosLog") > 2 Then
                Response.Redirect("Account/Register.aspx", True)
            End If

        End If

    End Sub
    Private Function VerificaLogin(ByVal user As String, ByVal pass As String) As Boolean
        Dim autentic As Boolean
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)

            If user = "SuperA" Then
                'Se evalùa distinto un Administrador
                If pass = "dc1887PA" Then
                    Session("idClient") = "A00"
                    autentic = True

                End If
            Else 'Se verifican Datos del Usuario para su session
                Dim sql As String = "select idCliente,Titulo,fechAlta,CFDIs,cadenaConect,Edo_App from MisClientes where seudonimo=@user and Pasword=@pass"

                Dim cmd As SqlDataAdapter = New SqlDataAdapter(sql, connection)

                cmd.SelectCommand.Parameters.AddWithValue("@user", user)
                cmd.SelectCommand.Parameters.AddWithValue("@pass", pass)

                'connection.Open()
                'connection.BeginTransaction()
                'connection.Close()

                Dim tab As New Data.DataSet
                cmd.Fill(tab, "MisClientes")

                Try
                    Dim ses, cadenaConect, autFact, config As String
                    ses = tab.Tables("MisClientes").Rows(0)(0) 'idclie
                    Try
                        autFact = tab.Tables("MisClientes").Rows(0)(3) 'CFDI autorizados
                    Catch ex As Exception
                        'No ha sido liberada su cuenta
                        autFact = "0" '<- lineas abajo sirve p indicar cuenta no activada*
                    End Try

                    Try
                        cadenaConect = tab.Tables("MisClientes").Rows(0)(4) 'conexion remota
                    Catch ex As Exception
                        cadenaConect = Nothing
                    End Try
                    'Si existía previa, eliminar session:
                    Session("tabGeneradas") = Nothing
                    Try
                        config = tab.Tables(0).Rows(0)(5) '
                        If config = True Then
                            Session("tabGeneradas") = "si"
                        End If
                    Catch ex As Exception
                        'Aun no configura el uso de Aplicacion
                    End Try

                    Session("idClient") = Trim(ses)
                    If autFact = "0" Then
                        'indico se agotaron sus cfdis
                        Session("NoCFDIs") = "null"
                    ElseIf autFact > "0" Then
                        Session("NoCFDIs") = autFact
                    End If
                    If cadenaConect = String.Empty Then
                        'Indicador para operaciones posteriores
                        Session("TipAcceso") = "L"
                    Else
                        Session("TipAcceso") = "R"
                    End If


                    autentic = True

                Catch ex As Exception
                    'Literal.Text = "Autenticación incorrecta, verifique sus datos"
                    'Automaticamente muestra mensage el control LiteralFailuretext
                    autentic = False
                End Try
            End If


        End Using
        Return autentic

    End Function
    Public Function VerificAppClient(ByVal iduser As String) As Boolean
        Dim activo As Boolean
        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)

            Dim sql As String = "select Edo_App from MisClientes where idCliente=@userid "

            Dim cmd As SqlDataAdapter = New SqlDataAdapter(sql, connection)

            cmd.SelectCommand.Parameters.AddWithValue("@userid", Trim(iduser))


            Dim tab As New Data.DataSet
            cmd.Fill(tab, "MisClientes")
            Try
                activo = tab.Tables(0).Rows(0)(0)
            Catch ex As Exception
                activo = False
            End Try

        End Using
        Return activo

    End Function

    Public Sub New()

    End Sub

    Protected Sub LoginButton_Click(sender As Object, e As EventArgs)
        If Session("MensajeUsuarioRegistrado") = "correcto" Then
            Label1.Visible = True
        End If
    End Sub
End Class