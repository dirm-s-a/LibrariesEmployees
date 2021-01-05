
Partial Public Class FichadaLectura
    Public ReadOnly Property DIASEMANAFICHADA As String
        Get
            Select Case Weekday(Me.FECHAFICHADA, DayOfWeek.Monday) - 1
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
    Public ReadOnly Property TipoFichadaDesc() As String
        Get
            Select Case Me.TIPOFICHADASUPERVISOR
                Case 0, 128
                    Return "*ENTRADA"
                Case 1, 129
                    Return "*SALIDA"
                Case 2, 130
                    Return "*F2"
                Case 3, 131
                    Return "*F3"
                Case 4, 132
                    Return "*F4"
                Case 5, 133
                    Return "*F5"
                Case 6, 134
                    Return "*F6"
                Case Else
                    Select Case Me.TIPOFICHADA
                        Case 0, 128
                            Return "ENTRADA"
                        Case 1, 129
                            Return "SALIDA"
                        Case 2, 130
                            Return "F2"
                        Case 3, 131
                            Return "F3"
                        Case 4, 132
                            Return "F4"
                        Case 5, 133
                            Return "F5"
                        Case 6, 134
                            Return "F6"
                        Case 228
                            Return "INICIO ALMUERZO"
                        Case 229
                            Return "FIN ALMUERZO"
                        Case Else
                    End Select
            End Select
            Return String.Empty
        End Get
    End Property
End Class