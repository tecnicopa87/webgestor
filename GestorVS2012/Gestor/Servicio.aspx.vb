Imports System.Configuration
Imports System.Web
Imports gestorDataAcces

Public Class Servicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label2.Text = Date.Now
        If Request.Cookies("SESSION-GESTOR") Is Nothing Or Session("idClient") Is Nothing Then
            Response.Redirect("../Default.aspx")
        End If
        If Session("idAdmin") = "A00" Then
            TxtDominioServidor.Enabled = True
            TxtPuertoServidor.Enabled = True
            Button1.Enabled = True
        Else
            TxtDominioServidor.Enabled = False
            TxtPuertoServidor.Enabled = False
        End If
        LabelCliente.Text = Session("idClient")
        LblError.Text = ""

        If Page.IsPostBack = False Then

            Try
                'Dim param As String = Request.QueryString(0) 'menu TrabajarOnline envìa id=on
              
                'If param = "on" Then
                'Genero tablas d user en WebServer
                Dim ct As New Conexion
                Dim proc As String
                If Session("tabGeneradas") Is Nothing Then
                    proc = ct.GenerarTabUsuario(Session("idClient"))

                End If
                If proc <> String.Empty Then
                    ' MsgBox("procGenerarTabs tiene valor") 'solo test marzo-16
                    LblError.Text = proc
                    LblError.Visible = True
                Else
                    Session("tabGeneradas") = "si"
                    ' MsgBox("procGenerTabs es vacìo y asigna si") 'solo test
                    LblTipServicio.Text = " online"
                    LblConfig.Text = "Configurado correctamente"
                    LblConfig.Visible = True
                End If
                'End If            
            Catch ex As Exception
                LblError.Text = ex.Message
                LblError.Visible = True
            End Try

            'Dim cok As String
            'cok = FormsAuthentication.FormsCookieName <- cuando no conosco nombre d cookie

            'If Session("idClient") Is Nothing Then *- 2da opcion *
            'Response.Redirect("../Default.aspx")* <- valdría si no utilizo LoginView para cierre de sesion*
            'End If
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TxtDominioServidor.Text <> "" And TxtPuertoServidor.Text <> "" Then
            Dim Servicio As New Conexion

            Dim strConexion As String, exitoso As Boolean
            strConexion = TxtDominioServidor.Text & "," & TxtPuertoServidor.Text

            exitoso = Servicio.ConfiguraServicio(strConexion, Session("idClient"))
            'Dim configPersonalizada As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            '          ^  en caso de usar web.config externo para conexiones,configuraciones extras ^
            'Dim NuevaConexion As ConfigurationManager

            'configPersonalizada.AppSettings.Settings.Add("mikey", "mivalue")  ^ extra
            'configPersonalizada.Save(ConfigurationSaveMode.Modified, True) 'true<- guarda aun cuando no se haya modificado la config
            'ConfigurationManager.RefreshSection("appSettings")
            If exitoso = True Then
                Response.Redirect("~/")
                LblTipServicio.Text = " remoto"
            ElseIf exitoso = False Then
                LblError.Text = "No se pudo guardar la configuracion"
                LblError.Visible = True
            End If
        End If
    End Sub
End Class