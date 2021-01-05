Imports Turnos.GlobalFunctions.Data

Public Class BaseData
    Inherits AccesoDatos

#Region "Atributos"
    Private mInternalError As String
    Private mError As String
    Private mConError As Boolean

    Private mException As Exception
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
        mobjLog.Name = "Data"
        mobjLog.Path = My.Application.Info.DirectoryPath & "\Log"
    End Sub

    Public Sub New(ByVal nConnectionString As String)
        MyBase.New(nConnectionString)
    End Sub
#End Region

#Region "Metodos Publicos"
    Friend Overloads Function Insert(ByVal pTable As String, ByRef pcolDirtyFields As Generic.SortedList(Of String, Object), Optional ByVal ThrowErr As Boolean = False) As Boolean
        Dim sql As String
        Dim sqlcolumns As String
        Dim sqlvalues As String
        Dim obj As Object

        Dim bOk As Boolean
        Try

            sql = "INSERT INTO <table> (<columns>) VALUES (<values>)"

            sqlcolumns = String.Empty
            sqlvalues = String.Empty

            For Each DirtyField As String In pcolDirtyFields.Keys
                sqlcolumns &= DirtyField & ", "
            Next
            If sqlcolumns.EndsWith(", ") Then
                sqlcolumns = sqlcolumns.Substring(0, sqlcolumns.Length - 2)
            End If

            For Each DirtyField As String In pcolDirtyFields.Keys
                obj = pcolDirtyFields(DirtyField)
                sqlvalues &= F_ValueToBD(obj) & ", "
            Next
            If sqlvalues.EndsWith(", ") Then
                sqlvalues = sqlvalues.Substring(0, sqlvalues.Length - 2)
            End If

            sql = sql.Replace("<table>", pTable)
            sql = sql.Replace("<columns>", sqlcolumns)
            sql = sql.Replace("<values>", sqlvalues)

            If oCon.EjecutarNonQuery(CommandType.Text, sql) >= 0 Then
                bOk = True
            Else
                If Not IsNothing(oCon.Exception) Then
                    Me.InternalError = oCon.Exception.Message
                    Me.Exception = oCon.Exception
                End If
                Me.ConError = True
                Me.Error = "No se pudo insertar en " & pTable
                bOk = False
            End If

        Catch ex As Exception
            Me.ConError = True
            Me.Exception = ex
            Me.Error = "No se pudo insertar en " & pTable
            Me.InternalError = ex.Message
            bOk = False
            If ThrowErr Then Throw New System.Exception(Me.InternalError, Me.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return bOk
    End Function

    Friend Overloads Function Update(ByVal pTable As String, ByRef pcolKeyFields As Generic.SortedList(Of String, Object), ByRef pcolDirtyFields As Generic.SortedList(Of String, Object), Optional ByVal ThrowErr As Boolean = False) As Boolean
        Dim sql As String
        Dim sqlSet As String
        Dim sqlwhere As String
        Dim obj As Object

        Dim bOk As Boolean
        Try

            sql = "UPDATE <table> SET <set> WHERE <where>"

            sqlSet = String.Empty
            sqlwhere = String.Empty

            For Each DirtyField As String In pcolDirtyFields.Keys
                obj = pcolDirtyFields(DirtyField)
                sqlSet &= DirtyField & "=" & F_ValueToBD(obj) & ", "
            Next
            If sqlSet.EndsWith(", ") Then
                sqlSet = sqlSet.Substring(0, sqlSet.Length - 2)
            End If

            For Each KeyField As String In pcolKeyFields.Keys
                obj = pcolKeyFields(KeyField)
                sqlwhere &= KeyField & "=" & F_ValueToBD(obj) & " AND "
            Next
            If sqlwhere.EndsWith(" AND ") Then
                sqlwhere = sqlwhere.Substring(0, sqlwhere.Length - 5)
            End If

            sql = sql.Replace("<table>", pTable)
            sql = sql.Replace("<set>", sqlSet)
            sql = sql.Replace("<where>", sqlwhere)

            If oCon.EjecutarNonQuery(CommandType.Text, sql) >= 0 Then
                bOk = True
            Else
                If Not IsNothing(oCon.Exception) Then
                    Me.InternalError = oCon.Exception.Message
                    Me.Exception = oCon.Exception
                End If
                Me.ConError = True
                Me.Error = "No se pudo actualizar la " & pTable
                bOk = False
            End If

        Catch ex As Exception
            Me.ConError = True
            Me.Exception = ex
            Me.Error = "No se pudo actualizar la " & pTable
            Me.InternalError = ex.Message
            bOk = False
            If ThrowErr Then Throw New System.Exception(Me.InternalError, Me.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return bOk
    End Function

    Friend Overloads Function [SELECT](ByVal pTable As String, ByRef pcolDirtyFields As Generic.SortedList(Of String, Object), Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String
        Dim sqlwhere As String
        Dim obj As Object

        Dim datos As DataTable
        Try

            sql = "SELECT * FROM <table> WHERE <where>"

            sqlwhere = String.Empty

            For Each DirtyField As String In pcolDirtyFields.Keys
                obj = pcolDirtyFields(DirtyField)

                If Not F_IsNullValue(obj) Then
                    sqlwhere &= DirtyField & "=" & F_ValueToBD(obj) & " AND "
                End If
            Next
            If sqlwhere.EndsWith(" AND ") Then
                sqlwhere = sqlwhere.Substring(0, sqlwhere.Length - 5)
            End If

            sql = sql.Replace("<table>", pTable)
            sql = sql.Replace("<where>", sqlwhere)
            If Len(Trim(sqlwhere)) = 0 Then
                sql = sql.Replace("WHERE", "")
            End If
            datos = oCon.EjecutarDataTable(CommandType.Text, sql)

        Catch ex As Exception
            If Not IsNothing(oCon.Exception) Then
                Me.InternalError = oCon.Exception.Message
                Me.Exception = oCon.Exception
            Else
                Me.Exception = ex
                Me.InternalError = ex.Message
            End If
            Me.ConError = True
            Me.Error = "No se pudo buscar la " & pTable
            If ThrowErr Then Throw New System.Exception(Me.InternalError, Me.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return datos
    End Function
#End Region

End Class
