Public Class Facturas
    Private fol As String
    Public Property folio As String
        Get
            Return fol
        End Get
        Set(ByVal value As String)
            fol = value
        End Set
    End Property
    Private serief As String
    Public Property serie As String
        Get
            Return serief
        End Get
        Set(ByVal value As String)
            serief = value
        End Set
    End Property
    Private fech As Date
    Public Property fecha As Date
        Get
            Return fech
        End Get
        Set(ByVal value As Date)
            fech = value
        End Set
    End Property
    Private mont As Decimal
    Public Property monto As Decimal
        Get
            Return mont
        End Get
        Set(ByVal value As Decimal)
            mont = value
        End Set
    End Property
    Private condic As String
    Public Property condicion As String
        Get
            Return condic
        End Get
        Set(ByVal value As String)
            condic = value
        End Set
    End Property
    Private folAutoriz As Integer
    Public Property fol_Autoriz As Integer
        Get
            Return folAutoriz
        End Get
        Set(ByVal value As Integer)
            folAutoriz = value
        End Set
    End Property
    Private tipCmpt As String
    Public Property TpoCmpvte As String
        Get
            Return tipCmpt
        End Get
        Set(ByVal value As String)
            tipCmpt = value
        End Set
    End Property
    Private foltik As Integer
    Public Property folvnta As Integer
        Get
            Return foltik
        End Get
        Set(ByVal value As Integer)
            foltik = value
        End Set
    End Property
    Public Sub New()
        'Propiedad tipo List, requiere un contructor 
        Me.Lineasfact = New List(Of LineasFactura)
    End Sub

    Private n_Lineas As List(Of LineasFactura)
    Public Property Lineasfact As List(Of LineasFactura)
        Get
            Return n_Lineas
        End Get
        Set(ByVal value As List(Of LineasFactura))
            n_Lineas = value
        End Set
    End Property
End Class
