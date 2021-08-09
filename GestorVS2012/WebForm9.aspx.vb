Imports System
Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class WebForm9
    Inherits System.Web.UI.Page
    Friend conexion As MySqlConnection
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        conexion.ConnectionString = "server=mysql.webcindario.com;database=misrespaldos;user id=misrespaldos;password=server87;"
        conexion.Open()
        Dim cmd = New MySqlCommand("UPDATE central_ip SET ip_internet=@internet ", conexion)
        cmd.Parameters.AddWithValue("@internet", TextBox1.Text)
        cmd.ExecuteNonQuery()

        conexion.Close()
    End Sub
End Class