Imports System.Collections.Generic

Public Class DatosEmpresa
    
    Private idclient As String
    Public Property idCliente As String
        Get
            Return idclient
        End Get
        Set(ByVal value As String)
            idclient = value
        End Set
    End Property

    Public Property Titulo As String
        Get
            Return tituloE
        End Get
        Set(ByVal value As String)
            tituloE = value
        End Set
    End Property
    Private tituloE As String
    Private _rfc As String
    Public Property RFC As String
        Get
            Return _rfc
        End Get
        Set(ByVal value As String)
            _rfc = value
        End Set
    End Property
    Public Property Regimen As String
        Get
            Return regimenE

        End Get
        Set(ByVal value As String)
            regimenE = value
        End Set
    End Property
    Private regimenE As String
    Public Property Email As String
        Get
            Return correo
        End Get
        Set(ByVal value As String)
            correo = value

        End Set
    End Property
    Private correo As String
    Public Property Pasword As String
        Get
            Return pass
        End Get
        Set(ByVal value As String)
            pass = value
        End Set
    End Property
    Private pass As String
    Public Property fechAlta As Date
        Get
            Return fechA
        End Get
        Set(ByVal value As Date)
            fechA = value
        End Set
    End Property
    Private fechA As Date
    Public Property CFDIs As Integer
        Get
            Return cfdi
        End Get
        Set(ByVal value As Integer)
            cfdi = value
        End Set
    End Property
    Private cfdi As Integer
    Private calle As String
    Public Property Dircalle As String
        Get
            Return calle
        End Get
        Set(ByVal value As String)
            calle = value
        End Set
    End Property
    Private no As String
    Public Property noExt As String
        Get
            Return no
        End Get
        Set(ByVal value As String)
            no = value
        End Set
    End Property
    Private col As String
    Public Property Colonia As String
        Get
            Return col
        End Get
        Set(ByVal value As String)
            col = value
        End Set
    End Property
    Private c_p As String
    Public Property CP As String
        Get
            Return c_p
        End Get
        Set(ByVal value As String)
            c_p = value
        End Set
    End Property
    Private mun As String
    Public Property Municipio As String
        Get
            Return mun
        End Get
        Set(ByVal value As String)
            mun = value
        End Set
    End Property
    Private edo As String
    Public Property Estado As String
        Get
            Return edo
        End Get
        Set(ByVal value As String)
            edo = value
        End Set
    End Property
    Private seudo As String
    Public Property seudonimo As String
        Get
            Return seudo
        End Get
        Set(ByVal value As String)
            seudo = value
        End Set
    End Property
End Class
