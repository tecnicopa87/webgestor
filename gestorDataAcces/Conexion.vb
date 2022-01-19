Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web

Public Class Conexion
    Private tipoStr As String
    Private numerico As Decimal
    Public Sub New()
        'TeamString = "Visual Basic Code"
        numerico = 13.1416

    End Sub
    Public Function ConfiguracionEmpresa(ByVal sesion As String) As String
        Dim conexion As String = String.Empty

        Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
        Dim comand As SqlCommand = New SqlCommand("select cadenaConect from MisClientes where idCliente=@idclient", Scon)

        comand.Parameters.AddWithValue("@idclient", sesion)

        Scon.Open()
        Dim reader As SqlDataReader = comand.ExecuteReader()

        'If (reader.HasRows) Then
        ' -* opcional seguridad 'System.AppDomain.CurrentDomain.BaseDirectory
        '                        ConfigurationManager.AppSettings["userDB"]
        Dim strcadena As String = ""
        If reader.Read() Then ' Lee la cadenaconexion *
            Dim csb As New SqlConnectionStringBuilder
            csb.DataSource = Convert.ToString(reader(0))
            strcadena = Convert.ToString(reader(0))
            If csb.DataSource <> String.Empty Then
                csb.InitialCatalog = "negocios"
                csb.UserID = "EasyControl"
                csb.Password = "Ws7283k7z"
                csb.IntegratedSecurity = False

                conexion = csb.ConnectionString
            End If
            'Else 'Conexion por Defecto 
            'If strcadena = "" Then
            '    conexion = ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString

            'End If

        End If
              

        reader.Close() '

        Return conexion '<-determina si local o servidor remoto
    End Function
    Public Function ConfiguraServicio(ByVal cadena As String, ByVal sesion As String) As Boolean
        Dim exitoso As Boolean
        Try
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            Dim comand As SqlCommand = New SqlCommand("update MisClientes set cadenaConect=@dominioSQL where idCliente=@id", Scon)

            comand.Parameters.AddWithValue("@dominioSQL", cadena)
            comand.Parameters.AddWithValue("@id", sesion)

            Scon.Open()
            comand.ExecuteNonQuery()
            Scon.Close()
            exitoso = True

        Catch ex As Exception
            exitoso = False
        End Try

        Return exitoso

    End Function
    Public Function GenerarTabUsuario(ByVal idclient As String) As String
        Dim err As String = String.Empty

        Dim id As String = Trim(idclient)
        Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
        Scon.Open()
        '     Se define una transacion
        Dim sqltran As SqlTransaction = Scon.BeginTransaction()
        '    Se agrega el comando
        Dim comand As SqlCommand = Scon.CreateCommand
        comand.Transaction = sqltran
        Try
            comand.CommandText = ("EXEC spCreaTablas '" & id & "'")

            comand.ExecuteNonQuery()

            Dim act As Boolean = True
            comand.CommandText = "update MisClientes set Edo_App=@active,fechAlta=@fechConfigurado where idCliente=@cliente"
            comand.Parameters.AddWithValue("@active", act)
            comand.Parameters.AddWithValue("@fechConfigurado", Date.Today)
            comand.Parameters.AddWithValue("@cliente", id)

            comand.ExecuteNonQuery()
            sqltran.Commit()

        Catch ex As Exception
            sqltran.Rollback()
            err = "no se pudieron generar," & ex.Message
        End Try
        Return err

    End Function
    Public Function AutorizCuentaUsuario(ByVal idclient As String, Nocfdis As Integer) As String
        Dim err As String = String.Empty
        Try
            Dim id As String = Trim(idclient)
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            Dim comand As SqlCommand ' = New SqlCommand("EXEC CreaTablas " & id, Scon)

            'Scon.Open()
            'comand.ExecuteNonQuery()
            ' Scon.Close()

            'Dim act As Boolean = True
            comand = New SqlCommand("update MisClientes set CFDIs=@No where idCliente=@cliente", Scon)
            'comand.Parameters.AddWithValue("@active", act)
            comand.Parameters.AddWithValue("@cliente", id)
            comand.Parameters.AddWithValue("@No", Nocfdis)

            Scon.Open()
            comand.ExecuteNonQuery()
            Scon.Close()

        Catch ex As Exception
            err = "no se pudieron generar," & ex.Message
        End Try
        Return err

    End Function
    Public Function GenerarTablatmp() As Boolean
        Dim exitoso As Boolean = False
        Try

        Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            Dim comand As SqlCommand = New SqlCommand("CREATE TABLE dbo.VntaTMP " &
                                                      "(no_ticket int NULL," &
     "unidad nchar(10) NULL," &
     "cantidad float(53) NULL," &
     "descripcion varchar(50) NULL," &
     "precio decimal(18, 2) NULL," &
     "importe decimal(18, 2) NULL," &          
     "cve_pro nchar(5) NULL," &
     "descto decimal(18, 2) NULL," &
     "iva_aplic decimal(18, 2) NULL," &
     "ieps_aplic decimal(18, 2) NULL," &
    "ahorro_client decimal(18, 2) NULL," &
    "edo_fact nchar(10) NULL," &
    "no_ventas int NOT NULL " &
     ")  ON [PRIMARY]", Scon)

            Scon.Open()
            comand.ExecuteNonQuery()
            Scon.Close()

            exitoso = True
        Catch ex As Exception

            exitoso = False
        End Try
        Return exitoso
    End Function
    Public Function ActualizaEstatusApp(ByVal idUser As String, ByVal checked As Boolean) As String
        Dim error_ As String = ""
        Try
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            Scon.Open()
            Dim cmd As New SqlCommand("update MisClientes set Edo_App=@chk where idCliente=@idUsuario", Scon)
            cmd.Parameters.AddWithValue("@chk", checked)
            cmd.Parameters.AddWithValue("@idUsuario", idUser)
            cmd.ExecuteNonQuery()
            Scon.Close()
        Catch ex As Exception
            error_ = ex.Message
        End Try     

        Return error_
    End Function
    Public Function VolcarDatos(queryPeticion As String) As DataSet
        Dim dt As New DataSet
        Try
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            Dim adapter As SqlDataAdapter
            'Dim comand As SqlCommand = New SqlCommand("" & queryPeticion & "", Scon)
            adapter = New SqlDataAdapter("" & queryPeticion & "", Scon)

            adapter.Fill(dt, "query")

        Catch ex As Exception

        End Try
        Return dt

    End Function
End Class

