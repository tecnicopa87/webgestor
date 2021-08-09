Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Imports GestorEntities

Public Class ClientsDAL
    Dim tabClients As String

    Public Function GetALL(ByVal idSes As String) As List(Of Clientes)
        Dim ListClients As New List(Of Clientes)

        Dim con As New Conexion
        Dim cadenaConexion As String
        cadenaConexion = con.ConfiguracionEmpresa(idSes) 'determina si local o remota

        If cadenaConexion = "" Then
            tabClients = "Clientes" & idSes
            'Dim str As String = ""
            Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
                conn.Open()
                Dim query As String = "select * from " & tabClients
                Dim cmd As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader

                While reader.Read
                    '      se hace uso de funcion auxiliar
                    ListClients.Add(LoadCliente(reader))

                End While
                reader.Close()

            End Using

        Else
            tabClients = "Clientes"
            'Dim str As String = ""
            Dim Scon As New SqlConnection(cadenaConexion)  'www.dominiosql.com:00
            Scon.Open()
            Dim query As String = "select * from " & tabClients
            Dim cmd As New SqlCommand(query, Scon)
            Dim reader As SqlDataReader = cmd.ExecuteReader

            While reader.Read
                '      se hace uso de funcion auxiliar
                ListClients.Add(LoadCliente(reader))

            End While
            reader.Close()

        End If
        
        Return ListClients

    End Function
    '                              Utiliza ReaderIndexado para leer columnas
    Private Shared Function LoadCliente(ByVal reader As IDataReader) As Clientes
        Dim client As New Clientes
        client.Nombre = Convert.ToString(reader("Nombre"))
        client.RFC = Convert.ToString(reader("RFC"))
        client.Calle = Convert.ToString(reader("Calle"))
        client.NoExt = Convert.ToString(reader("NoExt"))
        client.Colonia = Convert.ToString(reader("Colonia"))
        client.Municipio = Convert.ToString(reader("Municipio"))
        client.CP = Convert.ToString(reader("CP"))
        client.Email = Convert.ToString(reader("Email"))

        Return client

    End Function
    Public Function GuardaCliente(ByVal idSes As String, ByVal cliente As Clientes) As Boolean
        Dim ListClients As New List(Of Clientes)

        Dim con As New Conexion
        Dim cmd As SqlCommand
        Dim cadenaConexion As String
        cadenaConexion = con.ConfiguracionEmpresa(idSes) 'determina si local o remota

        If cadenaConexion = "" Then
            tabClients = "Clientes" & idSes

            Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
                conn.Open()
                cmd = New SqlCommand("insert into " & tabClients & " values (@Nombre,@RFC) ", conn)
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre)


            End Using
        End If

    End Function

End Class
