<Serializable()> Public Class BaseEntity

#Region "Atributos"
    Protected mTable As String

    Private mflgIsBeginUpdate As Boolean
    Private mflgIsNew As Boolean
    Private mflgIsDirty As Boolean

    Private mcolDirtyFields As Generic.SortedList(Of String, Object)
    Private mcolKeyFields As Generic.SortedList(Of String, Object)
#End Region

#Region "Propiedades"
    Public Property Table As String
        Get
            Return mTable
        End Get
        Set(ByVal value As String)
            mTable = value
        End Set
    End Property

    Friend WriteOnly Property Dirty As Boolean
        Set(ByVal value As Boolean)
            mflgIsDirty = value
        End Set
    End Property
    Friend WriteOnly Property [New] As Boolean
        Set(ByVal value As Boolean)
            mflgIsNew = value
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
        mflgIsNew = True
        mcolDirtyFields = New Generic.SortedList(Of String, Object)
        mcolKeyFields = New Generic.SortedList(Of String, Object)
    End Sub
#End Region

#Region "Metodos Privados"
    Protected Sub ChangeProperty(ByVal nProperty As String, ByVal nValue As Object)
        If mflgIsBeginUpdate Then
            If Not mcolDirtyFields.ContainsKey(nProperty) Then
                mcolDirtyFields.Add(nProperty, nValue)
            Else
                mcolDirtyFields(nProperty) = nValue
            End If

            If mcolKeyFields.ContainsKey(nProperty) Then
                If mflgIsNew Then
                    'Ver si utiliza generador
                    'Throw New Exception("Violacion Clave Primaria")
                Else
                    Throw New Exception("Violacion Clave Primaria")
                End If
            End If
            Dirty = True
        Else
            If mcolKeyFields.ContainsKey(nProperty) Then
                mcolKeyFields(nProperty) = nValue
            End If
        End If

    End Sub
#End Region

#Region "Metodos Publicos"
    Public Sub BeginUpdate()
        If mflgIsBeginUpdate Then
            'Inidcar error
            'Throw New Exception("
        Else
            mflgIsBeginUpdate = True
            If mflgIsDirty Then 'Tirame un error

            End If

        End If
    End Sub

    Friend Sub EndUpdate()
        If mflgIsBeginUpdate Then
            mflgIsBeginUpdate = False
            mflgIsDirty = False
            mflgIsNew = False
            mcolDirtyFields.Clear()
        Else
            'Inidcar error
        End If
    End Sub

    Public Function IsNew() As Boolean
        Return mflgIsNew
    End Function

    Public Function IsDirty() As Boolean
        Return mflgIsDirty
    End Function

    Public Function DirtyFields() As Generic.SortedList(Of String, Object)
        Return mcolDirtyFields
    End Function

    Public Function KeyFields() As Generic.SortedList(Of String, Object)
        Return mcolKeyFields
    End Function
#End Region

End Class
