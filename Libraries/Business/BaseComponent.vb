Public Class BaseComponent

#Region "Atributos"
    Private mInternalError As String
    Private mError As String
    Private mConError As Boolean

    Private mException As Exception

    <ThreadStatic> Protected Shared mConnectionString As String
    Public mobjLog As Turnos.GlobalFunctions.Logger
#End Region

#Region "Propiedades"
    Public Property InternalError As String
        Get
            Return mInternalError
        End Get
        Set(ByVal value As String)
            Me.mInternalError = value
        End Set
    End Property

    Public Property [Error] As String
        Get
            Return mError
        End Get
        Set(ByVal value As String)
            mError = value
        End Set
    End Property

    Public Property ConError As Boolean
        Get
            Return mConError
        End Get
        Set(ByVal value As Boolean)
            mConError = value
        End Set
    End Property

    Public Property [Exception] As Exception
        Get
            Return mException
        End Get
        Set(ByVal value As Exception)
            mException = value
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
        mError = String.Empty
        mConError = False
        mobjLog = New Turnos.GlobalFunctions.Logger
        mobjLog.Name = "Bussines"
        mobjLog.Path = My.Application.Info.DirectoryPath & "\Log"
    End Sub

    Public Sub New(ByVal nConnectionString As String)
        Me.New()
        Dim oDal As New Data.BaseData(nConnectionString)

        mConnectionString = nConnectionString
        If IsNothing(oDal.RegEdit) OrElse oDal.RegEdit <> nConnectionString Then
            oDal.RegEdit = nConnectionString
        End If
    End Sub
#End Region

End Class
