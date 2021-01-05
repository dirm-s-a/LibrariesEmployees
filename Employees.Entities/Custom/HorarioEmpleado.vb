Partial Public Class HorarioEmpleado
    Private ReadOnly _DIASEMANAENTRADA_Desc As String
    Private ReadOnly _DIASEMANASALIDA_Desc As String

    Public ReadOnly Property DIASEMANAENTRADA_Desc As String
        Get
            Select Case Me.DIASEMANAENTRADA
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

    Public ReadOnly Property DIASEMANASALIDA_Desc As String
        Get
            Select Case Me.DIASEMANASALIDA
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

    Public ReadOnly Property HORAENTRADA_Desc As String
        Get
            Dim str As String = Right("0000" & CStr(Me.HORAENTRADA), 4)
            If str = "00-1" Then Return String.Empty
            Return Left(str, 2) & ":" & Right(str, 2)
        End Get
    End Property

    Public ReadOnly Property HORAENTRADA1_Desc As String
        Get
            Dim str As String = Right("0000" & CStr(Me.HORAENTRADA1), 4)
            If str = "00-1" Then Return String.Empty
            Return Left(str, 2) & ":" & Right(str, 2)
        End Get
    End Property
    Public ReadOnly Property HORAENTRAD2_Desc As String
        Get
            Dim str As String = Right("0000" & CStr(Me.HORAENTRADA2), 4)
            If str = "00-1" Then Return String.Empty
            Return Left(str, 2) & ":" & Right(str, 2)
        End Get
    End Property

    Public ReadOnly Property HORASALIDA_Desc As String
        Get
            Dim str As String = Right("0000" & CStr(Me.HORASALIDA), 4)
            If str = "00-1" Then Return String.Empty
            Return Left(str, 2) & ":" & Right(str, 2)
        End Get
    End Property

    Public ReadOnly Property HORASALIDA1_Desc As String
        Get
            Dim str As String = Right("0000" & CStr(Me.HORASALIDA1), 4)
            If str = "00-1" Then Return String.Empty
            Return Left(str, 2) & ":" & Right(str, 2)
        End Get
    End Property
    Public ReadOnly Property HORASALIDA2_Desc As String
        Get
            Dim str As String = Right("0000" & CStr(Me.HORASALIDA2), 4)
            If str = "00-1" Then Return String.Empty
            Return Left(str, 2) & ":" & Right(str, 2)
        End Get
    End Property

End Class
