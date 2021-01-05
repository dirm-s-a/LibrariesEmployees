Public Class AccesoDatos

#Region "Atributos"
    Protected oCon As Conexion.clConexionNET
    <ThreadStatic> Protected Shared mRegEdit As String
#End Region

#Region "Propiedades"
    Public Property RegEdit As String
        Get
            Return mRegEdit
        End Get
        Set(ByVal value As String)
            mRegEdit = value
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
        Dim nConnectionString As String
        If Not IsNothing(mRegEdit) AndAlso Len(Trim(mRegEdit)) > 0 Then
            If mRegEdit.Length < 20 Then
                nConnectionString = Turnos.GlobalFunctions.Registry.Read(mRegEdit, "connectionString")
            Else
                nConnectionString = mRegEdit
            End If
            If Not nConnectionString.ToUpper().Contains("USER") OrElse Not nConnectionString.ToUpper().Contains("CATALOG") Then
                'Si no tienen en la cadena "USER" y "CATALOG", asumo que es encriptada
                nConnectionString = Turnos.GlobalFunctions.Encript.Decrypt(nConnectionString)
            End If

            If Not IsNothing(nConnectionString) AndAlso Len(Trim(nConnectionString)) > 0 Then
                oCon = New Conexion.clConexionNET(nConnectionString, Conexion.tTipoConectionBD.Nativo, Conexion.tTipoBD.FireBird)
                oCon.Conectar()
            End If
        End If

    End Sub

    Public Sub New(ByVal nRegEdit As String)
        Dim nConnectionString As String

        mRegEdit = nRegEdit

        If mRegEdit.Length < 20 Then
            nConnectionString = Turnos.GlobalFunctions.Registry.Read(mRegEdit, "connectionString")
        Else
            nConnectionString = mRegEdit
        End If
        If Not nConnectionString.ToUpper().Contains("USER") OrElse Not nConnectionString.ToUpper().Contains("CATALOG") Then
            'Si no tienen en la cadena "USER" y "CATALOG", asumo que es encriptada
            nConnectionString = Turnos.GlobalFunctions.Encript.Decrypt(nConnectionString)
        End If

        oCon = New Conexion.clConexionNET(nConnectionString, Conexion.tTipoConectionBD.Nativo, Conexion.tTipoBD.FireBird)
        oCon.Conectar()
    End Sub
#End Region

#Region "Metodos Publicos"
    Public Function Desconectar() As Boolean
        Return oCon.DesConectar
    End Function

    Public Function BeginTransaction() As Boolean
        Return oCon.ComenzarTransaccion()
    End Function

    Public Function CommitTransaction() As Boolean
        Return oCon.AceptarTransaccion()
    End Function

    Public Function CancelTransaction() As Boolean
        Return oCon.CancelarTransaccion()
    End Function
#End Region

End Class