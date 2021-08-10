Public Class CabezalVenta
    Private _folVenta As Integer
    Public Property FolVenta As Integer
        Get
            Return _folVenta
        End Get
        Set(value As Integer)
            _folVenta = value
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
    Private _fecha As DateTime
    Public Property FechaRealizacion As DateTime
        Get
            Return _fecha
        End Get
        Set(value As DateTime)
            _fecha = value
        End Set
    End Property
    Private _usuario As String
    Public Property Usuario As String
        Get
            Return _usuario
        End Get
        Set(value As String)
            _usuario = value
        End Set
    End Property
    Private _totiva As Single
    Public Property Totiva As Single
        Get
            Return _totiva
        End Get
        Set(value As Single)
            _totiva = value
        End Set
    End Property
    Private _totieps As Single
    Public Property Totieps As Single
        Get
            Return _totieps
        End Get
        Set(value As Single)
            _totieps = value
        End Set
    End Property
    Private _folFactura As String
    Public Property FolFactura As String
        Get
            Return _folFactura
        End Get
        Set(value As String)
            _folFactura = value
        End Set
    End Property
    Private _venta As Single
    Public Property Ventas As Single 'Por compatibilidad Punto de Venta Desktop
        Get
            Return _venta
        End Get
        Set(value As Single)
            _venta = value
        End Set
    End Property
    Private _utilidad As Single
    Public Property Utilidad As Single '
        Get
            Return Utilidad
        End Get
        Set(value As Single)
            _utilidad = value
        End Set
    End Property
End Class
