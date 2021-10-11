Imports System.Collections.Generic
Imports System.Linq
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports GestorEntities 'mis Entidades Definidas

Public Class DatosEmpDAL
    Public Shared Function GetALL() As List(Of DatosEmpresa)
        'Dim str As String = ""
        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            conn.Open()
            Dim query As String = "select * from MisClientes"

        End Using
        ' Return str
    End Function
    Public Function GetONE(ByVal id As String) As DatosEmpresa
        Dim empresa As DatosEmpresa = Nothing

        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)

            Dim query As String = "select Titulo,seudonimo,RFC,Regimen,Email,Pasword,fechAlta,CFDIs,Dircalle,noExt,CP,Municipio,Colonia,Estado from MisClientes where idCliente=@miclient"
            Dim ord As New SqlCommand(query, conn)
            ord.Parameters.AddWithValue("@miclient", id)
            conn.Open()

            Dim reader As SqlDataReader = ord.ExecuteReader

            'If reader.HasRows Then <- se omite xq no es muy funcional
            If reader.Read Then
                empresa = LoadEmpresa(reader)
                'End If
            End If

        End Using

        Return empresa

    End Function
    Public Shared Function UpdateEmp(ByVal emprs As DatosEmpresa, ByVal idclient As String) As DatosEmpresa

        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            conn.Open()
            '            *   Destino esta funcion a actualizar Solo Datos Basicos *
            Dim sql As String = "UPDATE MisClientes SET  " & _
                               "Titulo = @titulo, RFC=@_rfc, Regimen = @regm, " & _
                               "fechAlta=@fechActivServ, Dircalle = @calle, noExt = @no, " & _
                               "CP=@_cp,Municipio=@mun,Colonia=@col,Estado=@Edo " & _
                               "WHERE idCliente = @miclient"
            Dim ord As New SqlCommand(sql, conn)

            ord.Parameters.AddWithValue("@titulo", emprs.Titulo)
            ord.Parameters.AddWithValue("@_rfc", emprs.RFC)
            ord.Parameters.AddWithValue("@regm", emprs.Regimen)
            ord.Parameters.AddWithValue("@fechActivServ", emprs.fechAlta) 'fecha que activò el uso de GestorFacturas
            ord.Parameters.AddWithValue("@calle", emprs.Dircalle)
            ord.Parameters.AddWithValue("@no", emprs.noExt)
            ord.Parameters.AddWithValue("@_cp", emprs.CP)
            ord.Parameters.AddWithValue("@mun", emprs.Municipio)
            ord.Parameters.AddWithValue("@col", emprs.Colonia)
            ord.Parameters.AddWithValue("@Edo", emprs.Estado)
            ord.Parameters.AddWithValue("@miclient", idclient)

            ord.ExecuteNonQuery()
            
            Return emprs
        End Using
    End Function
    Public Function RegistraAccesoEmp(ByVal param, ByVal param1, ByVal param2, ByVal id) As Boolean

        Dim exitoso As Boolean
       
        Try
            Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
                conn.Open()
                '            *   Destino esta funcion a actualizar Solo Datos Basicos *
                Dim reciente As Boolean = False
                Dim sql As String = "INSERT INTO MisClientes(seudonimo,Email,Pasword,idCliente,Edo_App )" & _
                                   "values (@user,@email,@pass,@id,@edo)"

                Dim ord As New SqlCommand(sql, conn)

                ord.Parameters.AddWithValue("@user", param)
                ord.Parameters.AddWithValue("@email", param1)
                ord.Parameters.AddWithValue("@pass", param2)
                ord.Parameters.AddWithValue("@id", id)
                ord.Parameters.AddWithValue("@edo", reciente)

                ord.ExecuteNonQuery()

                exitoso = True
            End Using
        Catch ex As Exception
            exitoso = False
        End Try
        Return exitoso

    End Function
    Public Function AsignaIDClient() As String
        Dim idNuevo As String = Nothing

        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            conn.Open()
            Dim query As SqlCommand = New SqlCommand("select idCliente from MisClientes order by idCliente desc", conn)
            Dim reader As SqlDataReader = query.ExecuteReader
            If reader.Read Then
                Dim sig As Integer
                sig = Convert.ToInt32(reader(0))
                'idNuevo = CInt(sig) + 1
                idNuevo = Format(sig + 1, "000")
            Else
                idNuevo = "001"
            End If

        End Using

        Return idNuevo
    End Function
    Private Shared Function LoadEmpresa(ByVal reader As IDataReader) As DatosEmpresa
        Dim empresa As New DatosEmpresa

        Dim fechAlta As Date
        If String.IsNullOrEmpty(reader("fechAlta")) Then '#TEMPORALMENTE colocar manualmente en BD cuando Autorizo
            fechAlta = New DateTime
        Else
            fechAlta = reader("fechAlta")
        End If

        'empresa.idCliente = Convert.ToString(reader("idCliente"))
        empresa.Titulo = Convert.ToString(reader("Titulo"))
        empresa.seudonimo = Convert.ToString(reader("seudonimo"))
        empresa.RFC = Convert.ToString(reader("RFC"))
        empresa.Regimen = Convert.ToString(reader("Regimen"))
        empresa.Email = Convert.ToString(reader("Email")) 'para envio de factu
        empresa.Pasword = Convert.ToString(reader("Pasword")) 'p envìo de factura
        empresa.fechAlta = fechAlta '#PENDIENTE: Debe ser actualizada al momento de Autorizar cuenta
        empresa.Dircalle = Convert.ToString(reader("Dircalle"))
        empresa.noExt = Convert.ToString(reader("noExt"))
        empresa.Municipio = Convert.ToString(reader("Municipio"))
        empresa.Colonia = Convert.ToString(reader("Colonia"))
        empresa.CFDIs = Convert.ToInt32(reader("CFDIs"))
        empresa.CP = Convert.ToString(reader("CP"))
        empresa.Estado = Convert.ToString(reader("Estado"))

        Return empresa
    End Function
End Class
