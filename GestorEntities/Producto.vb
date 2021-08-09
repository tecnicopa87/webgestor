Public Class Producto
    Private _codigo As String
    Public Property codigo As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property
    Private _descripcion As String
    Public Property descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Private _precio As Single
    Public Property precio As Single
        Get
            Return _precio
        End Get
        Set(ByVal value As Single)
            _precio = value
        End Set
    End Property
    Private _precio2 As Single
    Public Property precio2 As Single
        Get
            Return _precio2
        End Get
        Set(ByVal value As Single)
            _precio2 = value
        End Set
    End Property
    Private _precio3 As Single
    Public Property precio3 As Single
        Get
            Return _precio3
        End Get
        Set(ByVal value As Single)
            _precio3 = value
        End Set
    End Property
    Private _existencia_pzas As Single
    Public Property existencia_pzas As Single
        Get
            Return _existencia_pzas
        End Get
        Set(ByVal value As Single)
            _existencia_pzas = value
        End Set
    End Property
    Private _existencia_cajas As Single
    Public Property existencia_cajas As Single
        Get
            Return _existencia_cajas
        End Get
        Set(ByVal value As Single)
            _existencia_cajas = value
        End Set
    End Property
    Private _vigencia As Boolean
    Public Property vigencia As Boolean
        Get
            Return _vigencia
        End Get
        Set(ByVal value As Boolean)
            _vigencia = value
        End Set
    End Property
    Private _a_granel As Boolean
    Public Property a_granel As Boolean
        Get
            Return _a_granel
        End Get
        Set(ByVal value As Boolean)
            _a_granel = value
        End Set
    End Property
    Private _min_inventario As Single
    Public Property min_inventario As Single
        Get
            Return _min_inventario
        End Get
        Set(ByVal value As Single)
            _min_inventario = value
        End Set
    End Property
    Private _cve_provedor As String
    Public Property cve_provedor As String
        Get
            Return _cve_provedor
        End Get
        Set(ByVal value As String)
            _cve_provedor = value
        End Set
    End Property

    Private _und_p2 As Single
    Public Property und_precio2 As Single
        Get
            Return _und_p2
        End Get
        Set(ByVal value As Single)
            _und_p2 = value
        End Set
    End Property
    Private _und_p3 As Single
    Public Property und_precio3 As Single
        Get
            Return _und_p3
        End Get
        Set(ByVal value As Single)
            _und_p3 = value
        End Set
    End Property
    Private _und_min1 As Single
    Public Property und_min1 As Single
        Get
            Return _und_min1
        End Get
        Set(ByVal value As Single)
            _und_min1 = value
        End Set
    End Property
    Private _und_min2 As Single
    Public Property und_min2 As Single
        Get
            Return _und_min2
        End Get
        Set(ByVal value As Single)
            _und_min2 = value
        End Set
    End Property
    Private _precBase1 As Single
    Public Property precBase1 As Single
        Get
            Return _precBase1
        End Get
        Set(ByVal value As Single)
            _precBase1 = value
        End Set
    End Property
    Private _precBase2 As Single
    Public Property precBase2 As Single
        Get
            Return _precBase2
        End Get
        Set(ByVal value As Single)
            _precBase2 = value
        End Set
    End Property
    Private _precBasem As Single
    Public Property precBasem As Single
        Get
            Return _precBasem
        End Get
        Set(ByVal value As Single)
            _precBasem = value
        End Set
    End Property
    Private _costo As Single
    Public Property costo As Single
        Get
            Return _costo
        End Get
        Set(ByVal value As Single)
            _costo = value
        End Set
    End Property
    Private _iva As Single
    Public Property iva As Single
        Get
            Return _iva
        End Get
        Set(ByVal value As Single)
            _iva = value
        End Set
    End Property
    Private _ieps As Single
    Public Property ieps As Single
        Get
            Return _ieps
        End Get
        Set(ByVal value As Single)
            _ieps = value
        End Set
    End Property
    Private _utilidad As Single
    Public Property utilidad As Single
        Get
            Return _utilidad
        End Get
        Set(ByVal value As Single)
            _utilidad = value
        End Set
    End Property
    Private _catalogo As String
    Public Property catalogo As String
        Get
            Return _catalogo
        End Get
        Set(ByVal value As String)
            _catalogo = value
        End Set
    End Property
    Private _descuento As Single
    Public Property descuento As Single
        Get
            Return _descuento
        End Get
        Set(ByVal value As Single)
            _descuento = value
        End Set
    End Property
    Private _costoCaja As Single
    Public Property costoCaja As Single
        Get
            Return _costoCaja
        End Get
        Set(ByVal value As Single)
            _costoCaja = value
        End Set
    End Property
    Private _precCaja As Single
    Public Property precCaja As Single
        Get
            Return _precCaja
        End Get
        Set(ByVal value As Single)
            _precCaja = value
        End Set
    End Property
    Private _utilCaja As Single
    Public Property utilidadCaja As Single
        Get
            Return _utilCaja
        End Get
        Set(ByVal value As Single)
            _utilCaja = value
        End Set
    End Property
    Private _descripCaja As Single
    Public Property descripcionCaja As Single
        Get
            Return _descripCaja
        End Get
        Set(ByVal value As Single)
            _descripCaja = value
        End Set
    End Property
    Private _fechmov As DateTime
    Public Property fechamov As DateTime
        Get
            Return _fechmov
        End Get
        Set(ByVal value As DateTime)
            _fechmov = value
        End Set
    End Property
    Private _marcamov As String
    Public Property marcamov As String
        Get
            Return _marcamov
        End Get
        Set(ByVal value As String)
            _marcamov = value
        End Set
    End Property
    Private _ult_prov As String
    Public Property _ult_provedor As String
        Get
            Return _ult_prov
        End Get
        Set(ByVal value As String)
            _ult_prov = value
        End Set
    End Property
    Private _ult_venta As DateTime
    Public Property ult_venta As DateTime
        Get
            Return _ult_venta
        End Get
        Set(ByVal value As DateTime)
            _ult_venta = value
        End Set
    End Property
    Private _unidad As String
    Public Property unidad As String
        Get
            Return _unidad
        End Get
        Set(ByVal value As String)
            _unidad = value
        End Set
    End Property
    Private _cve_prodserCFDI As String
    Public Property cve_prodserCFDI As String
        Get
            Return _cve_prodserCFDI
        End Get
        Set(ByVal value As String)
            _cve_prodserCFDI = value
        End Set
    End Property
    Public Sub New()
        'Propiedad tipo List, requiere un contructor 
        Me.Lineasvent = New List(Of Producto)
    End Sub

    Private n_Lineap As List(Of Producto)
    Public Property Lineasvent As List(Of Producto)
        Get
            Return n_Lineap
        End Get
        Set(ByVal value As List(Of Producto))
            n_Lineap = value
        End Set
    End Property





End Class
