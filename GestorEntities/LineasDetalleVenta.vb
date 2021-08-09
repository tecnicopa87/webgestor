Public Class LineasDetalleVenta
    Private novnta As Integer

    Public Property no_ventas As Integer
        Get
            Return novnta
        End Get
        Set(ByVal value As Integer)
            novnta = value
        End Set
    End Property
    Private notck As Integer
    Public Property no_ticket As Integer
        Get
            Return notck
        End Get
        Set(ByVal value As Integer)
            notck = value
        End Set
    End Property
    Private _cod As String
    Public Property codigo As String
        Get
            Return _cod
        End Get
        Set(value As String)
            _cod = value
        End Set
    End Property
    Private unid As String
    Public Property unidad As String
        Get
            Return unid
        End Get
        Set(ByVal value As String)
            unid = value
        End Set
    End Property
    Private cant As Decimal
    Public Property cantidad As Decimal
        Get
            Return cant
        End Get
        Set(ByVal value As Decimal)
            cant = value
        End Set
    End Property
    Private desc As String
    Public Property descripcion As String
        Get
            Return desc
        End Get
        Set(ByVal value As String)
            desc = value
        End Set
    End Property
    Private prec As Decimal
    Public Property precio As Decimal
        Get
            Return prec
        End Get
        Set(ByVal value As Decimal)
            prec = value
        End Set
    End Property
    Private imp As Decimal
    Public Property importe As Decimal
        Get
            Return imp
        End Get
        Set(ByVal value As Decimal)
            imp = value
        End Set
    End Property
    Private tmay As Integer
    Public Property tot_may As Integer
        Get
            Return tmay
        End Get
        Set(ByVal value As Integer)
            tmay = value
        End Set
    End Property
    Private maq As String
    Public Property maquina As String
        Get
            Return maq
        End Get
        Set(ByVal value As String)
            maq = value
        End Set
    End Property
    Private cvepro As String
    Public Property cve_pro As String
        Get
            Return cvepro
        End Get
        Set(ByVal value As String)
            cvepro = value
        End Set
    End Property
    Private dcto As Decimal
    Public Property descto As Decimal
        Get
            Return dcto
        End Get
        Set(ByVal value As Decimal)
            dcto = value
        End Set
    End Property

    Private _iva As Decimal
    Public Property iva_aplic As Decimal
        Get
            Return _iva
        End Get
        Set(ByVal value As Decimal)
            _iva = value

        End Set
    End Property
    Private _ieps As Decimal
    Public Property ieps_aplic As Decimal
        Get
            Return _ieps
        End Get
        Set(ByVal value As Decimal)
            _ieps = value

        End Set
    End Property
    Private ahorr As Decimal
    Public Property ahorro As Decimal
        Get
            Return ahorr
        End Get
        Set(ByVal value As Decimal)
            ahorr = value
        End Set
    End Property
End Class
