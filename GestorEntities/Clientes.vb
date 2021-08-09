Public Class Clientes
    Private nombre_ As String
    Private calle_ As String
    Private noExt_ As String
    Private rfc_ As String
    Private cp_ As String
    Private edo As String
    Private col As String
    Private municp As String
    Private email_ As String
    Public Property Nombre As String
        Get
            Return nombre_
        End Get
        Set(ByVal value As String)
            nombre_ = value
        End Set
    End Property
    Public Property RFC As String
        Get
            Return rfc_
        End Get
        Set(ByVal value As String)
            rfc_ = value
        End Set
    End Property
    Public Property Calle As String
        Get
            Return calle_
        End Get
        Set(ByVal value As String)
            calle_ = value
        End Set
    End Property
    Public Property NoExt As String
        Get
            Return noExt_
        End Get
        Set(ByVal value As String)
            noExt_ = value
        End Set
    End Property
    Public Property Colonia As String
        Get
            Return col
        End Get
        Set(ByVal value As String)
            col = value
        End Set
    End Property
    Public Property Municipio As String
        Get
            Return municp
        End Get
        Set(ByVal value As String)
            municp = value
        End Set
    End Property
    Public Property CP As String
        Get
            Return cp_
        End Get
        Set(ByVal value As String)
            cp_ = value
        End Set
    End Property
    Public Property Email As String
        Get
            Return email_
        End Get
        Set(ByVal value As String)
            email_ = value
        End Set
    End Property
    Public Property Estado As String
        Get
            Return edo
        End Get
        Set(ByVal value As String)
            edo = value
        End Set
    End Property
End Class
