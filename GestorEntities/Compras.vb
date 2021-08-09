Public Class Compras

    Private _folComp As Integer
    Public Property FolComp As Integer
        Get
            Return _folComp
        End Get
        Set(value As Integer)
            _folComp = value
        End Set
    End Property
    Private _monto As Single
    Public Property Monto As Single
        Get
            Return _monto
        End Get
        Set(value As Single)
            _monto = value
        End Set
    End Property
    Public Sub New()
        Me.Lineasfact = New List(Of LineasFactura)

    End Sub

    Private n_lineas As List(Of LineasFactura)
    Public Property Lineasfact As List(Of LineasFactura)
        Get
            Return n_Lineas
        End Get
        Set(ByVal value As List(Of LineasFactura))
            n_Lineas = value
        End Set
    End Property

End Class
