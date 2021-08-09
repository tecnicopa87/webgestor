Imports GestorEntities
Imports gestorDataAcces
Imports System.IO

Public Class WebForm5
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Cookies("SESSION-GESTOR") Is Nothing Then
            Response.Redirect("../Default.aspx")
        End If

        If Session("tabGeneradas") Is Nothing Then
            Response.Redirect("Servicio.aspx")
        End If
        If Page.IsPostBack = True Then
            Exit Sub
        End If
        Try
            Dim Emisor As New DatosEmpDAL
            Dim DatEmisor As New DatosEmpresa
            DatEmisor = Emisor.GetONE(Session("idClient"))
            TextBox1.Text = DatEmisor.Titulo
            TextBox8.Text = DatEmisor.RFC
            TextBox2.Text = DatEmisor.Dircalle
            TextBox3.Text = DatEmisor.noExt
            TextBox7.Text = DatEmisor.CP
            TextBox5.Text = DatEmisor.Municipio
            TextBox4.Text = DatEmisor.Colonia
            DropDownList1.Text = DatEmisor.Estado

        Catch ex As Exception

        End Try
       
    End Sub

    
    'Protected Sub BttnGuardar_Click(sender As Object, e As EventArgs) Handles BttnGuardar.Click


    '    Dim datEmp As New DatosEmpresa
    '    Dim Update As New DatosEmpDAL 'metodos de capa datos

    '    datEmp.Titulo = TextBox1.Text
    '    datEmp.Regimen = DropDownList2.Text
    '    datEmp.RFC = TextBox8.Text
    '    'datEmp.Email = TextBox1.Text <-se obtiene previamente cuando se registrò
    '    'datEmp.Pasword = TextBox2.Text<- '  '      '    '
    '    datEmp.fechAlta = Date.Today
    '    datEmp.Dircalle = TextBox2.Text
    '    datEmp.noExt = TextBox3.Text
    '    datEmp.CP = TextBox7.Text
    '    datEmp.Municipio = TextBox5.Text
    '    datEmp.Colonia = TextBox4.Text
    '    datEmp.Estado = DropDownList1.Text
    '    datEmp.Email = " " 'si no asigno tods genera excepcion "datos binarios se truncarìan"
    '    datEmp.Pasword = " "
    '    Try
    '        Update.UpdateEmp(datEmp, Session("idClient"))
    '        'limpiar campos
    '        TextBox1.Text = ""
    '        TextBox2.Text = ""
    '        TextBox3.Text = ""
    '        TextBox4.Text = ""
    '        TextBox5.Text = ""
    '        TextBox6.Text = ""
    '        TextBox7.Text = ""
    '        TextBox8.Text = ""
    '        DropDownList1.Text = ""
    '        DropDownList2.Text = ""

    '        Lbl_Respuesta.Text = "Se guardaron sus datos exitosamente"
    '        Lbl_Respuesta.ForeColor = Drawing.Color.PowderBlue

    '    Catch ex As Exception
    '        Lbl_Respuesta.Text = "No se pudieron actualizar los datos,verifique que contenga valores validos"
    '        Lbl_Respuesta.ForeColor = Drawing.Color.Red

    '    End Try
    '    Lbl_Respuesta.Visible = True
    'End Sub
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim datEmp As New DatosEmpresa
        Dim Update As New DatosEmpDAL 'metodos de capa datos

        datEmp.Titulo = TextBox1.Text
        datEmp.Regimen = DropDownList2.Text
        datEmp.RFC = TextBox8.Text
        'datEmp.Email = TextBox1.Text <-se obtiene previamente cuando se registrò
        'datEmp.Pasword = TextBox2.Text<- '  '      '    '
        datEmp.fechAlta = Date.Today
        datEmp.Dircalle = TextBox2.Text
        datEmp.noExt = TextBox3.Text
        datEmp.CP = TextBox7.Text
        datEmp.Municipio = TextBox5.Text
        datEmp.Colonia = TextBox4.Text
        datEmp.Estado = DropDownList1.Text
        datEmp.Email = " " 'si no asigno tods genera excepcion "datos binarios se truncarìan"
        datEmp.Pasword = " "
        Try
            Update.UpdateEmp(datEmp, Session("idClient"))
            'limpiar campos
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            DropDownList1.Text = ""
            DropDownList2.Text = ""

            Lbl_Respuesta.Text = "Se guardaron sus datos exitosamente"
            Lbl_Respuesta.ForeColor = Drawing.Color.PowderBlue

        Catch ex As Exception
            Lbl_Respuesta.Text = "No se pudieron actualizar los datos,verifique que contenga valores validos"
            Lbl_Respuesta.ForeColor = Drawing.Color.Red

        End Try
        Lbl_Respuesta.Visible = True
    End Sub


    Protected Sub bttnGuardaTodo_Click(sender As Object, e As EventArgs) Handles bttnGuardaTodo.Click
        If FileUpload1.FileName <> "" And FileUpload2.FileName <> "" Then

            Dim client As String
            client = Trim(Session("idClient"))
            Dim renomb_cer, renomb_key As String
            Try
                renomb_cer = "certificado" & client & ".cer" 'FileUpload1.FileName
                renomb_key = "llaveprivada" & client & ".key"
                If FileUpload1.PostedFile.ContentType = "image/jpg" Then

                End If

                'upload.ResolveClientUrl 
                'upload.PostedFile.SaveAs(Server.MapPath(rutadestino))
                FileUpload1.SaveAs(Server.MapPath("~/") + "/archivos/Certificados/" + renomb_cer)
                FileUpload2.SaveAs(Server.MapPath("~/") + "/archivos/Certificados/" + renomb_key)
                Dim ConfFact As New FacturasDAL
                Dim proc As String
                proc = ConfFact.HabilitaProcFact(Session("idClient"), Session("TipAcceso"))
                If proc = "exitoso" Then
                    Response.Write("<script>alert('Carga exitosa')</script>")
                Else
                    Dim pathServ As String = Server.MapPath("~/") + "archivos\Facturas"

                    Response.Write("<script>alert('Se cargaron sus archivos,pero hubo un problema al habilitar la facturación ')</script>")
                    Using writer As New StreamWriter(pathServ & "\logService.log")
                        writer.WriteLine(proc)
                        'writer.Close()
                    End Using
                End If


            Catch ex As Exception
                Response.Write("<script>alert('No se pudo cargar el archivo, intente otra vez')</script>")
            End Try
        Else
            If FileUpload1.FileName = "" Then
                Label1.Visible = True
            ElseIf FileUpload2.FileName = "" Then
                Label2.Visible = True
            End If

        End If
    End Sub

    Protected Sub Unnamed_ServerClick(sender As Object, e As EventArgs)
        MsgBox("simple ejecucion estando en container")
    End Sub
End Class