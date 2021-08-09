Public Class Preventa_nousado
    Private ds As DataSet
    Public Property Dset As DataSet 'para devolver conjunto de datos
        Get
            Return ds
        End Get
        Set(ByVal value As DataSet)
            ds = value
        End Set
    End Property
    Private import As Decimal
    Public Property Importe As Decimal ' para devolver un total
        Get
            Return import
        End Get
        Set(ByVal value As Decimal)
            import = value
        End Set
    End Property
    Private _iva As Decimal
    Public Property Iva As Decimal 'para devolver impuesto
        Get
            Return _iva
        End Get
        Set(ByVal value As Decimal)
            _iva = value
        End Set
    End Property
    Private _ieps As Decimal
    Public Property IEPS As Decimal
        Get
            Return _ieps
        End Get
        Set(ByVal value As Decimal)
            _ieps = value
        End Set
    End Property

End Class
