Partial Public Class EventoFichada
    Private _HORARIO_Desc As String

    Public ReadOnly Property DIASEMANAENTRADA As String
        Get
            Select Case Weekday(Me.FECHAENTRADA, FirstDayOfWeek.Monday)
                Case 1 : Return "Lunes"
                Case 2 : Return "Martes"
                Case 3 : Return "Miércoles"
                Case 4 : Return "Jueves"
                Case 5 : Return "Viernes"
                Case 6 : Return "Sábado"
                Case Else : Return "Domingo"
            End Select
        End Get
    End Property

    Public ReadOnly Property DIASEMANASALIDA As String
        Get
            Select Case Weekday(Me.FECHASALIDA, FirstDayOfWeek.Sunday)
                Case 1 : Return "Lunes"
                Case 2 : Return "Martes"
                Case 3 : Return "Miércoles"
                Case 4 : Return "Jueves"
                Case 5 : Return "Viernes"
                Case 6 : Return "Sábado"
                Case 7 : Return "Domingo"
                Case Else : Return ""
            End Select
        End Get
    End Property

    Public Property HORARIO_Desc As String
        Get
            Return _HORARIO_Desc
        End Get
        Set(value As String)
            _HORARIO_Desc = value
        End Set
    End Property
End Class
