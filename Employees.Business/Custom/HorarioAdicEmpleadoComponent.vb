Imports Employees.Entities
Imports Employees.Data
Imports Turnos.GlobalFunctions.Data
Imports System.Collections.Generic

Partial Public Class HorarioAdicEmpleadoComponent
    Public Function SaveConTraza(ByRef entity As HorarioAdicEmpleado, Optional ByVal sp As Boolean = True, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Dim flgOkSave As Boolean = False
        Dim Odal As New HorarioAdicEmpleadoData
        Dim objEmpleado As New EmpleadoComponent()
        Dim objTrazaCambio As New TrazaCambioComponent()
        Dim entTrazaCambio As TrazaCambio
        Dim flgBeginTran As Boolean = False

        Try
            Dim flgNew As Boolean = (F_IsNullValue(entity.ID))

            Odal.BeginTransaction()
            flgBeginTran = True

            Call ValidarDatos(entity)
            entity.FECHAMODIFICACION = Date.Now
            If Not Save(entity) Then
                Throw New Exception("Error al guardar horario adicional del empleado.")
            Else
                Dim entEmpleado As Empleado = objEmpleado.GetEntById(entity.IDEMPLEADO)
                entTrazaCambio = New TrazaCambio
                entTrazaCambio.BeginUpdate()
                entTrazaCambio.IDUSUARIO = entity.IDUSUARIOMODIFICACION
                entTrazaCambio.IDEMPLEADO = entity.IDEMPLEADO
                entTrazaCambio.IDAUXILIAR = entity.ID
                entTrazaCambio.TABLAAUXILIAR = "HorarioAdicEmpleado"
                If flgNew Then
                    entTrazaCambio.OBSERVACIONES = "Alta de horario adicional" & Environment.NewLine
                Else
                    If entity.ACTIVO = True Then
                        entTrazaCambio.OBSERVACIONES = "Modificación de horario adicional" & Environment.NewLine
                    Else
                        entTrazaCambio.OBSERVACIONES = "Baja de horario adicional" & Environment.NewLine
                        entTrazaCambio.IDUSUARIO = entity.IDUSUARIOBAJA
                    End If
                End If

                entTrazaCambio.OBSERVACIONES &= "Empleado: " & entEmpleado.NOMBRE & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Documento: " & entEmpleado.NRODOCUMENTO & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Fecha Desde: " & Format(entity.FECHADESDE, "dd/MM/yyyy") & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Fecha Hasta: " & Format(entity.FECHAHASTA, "dd/MM/yyyy") & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Horario Entrada: " & entity.HORAENTRADA & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Horario Salida: " & entity.HORASALIDA & Environment.NewLine
                If Not F_IsNullValue(entity.HORAENTRADA1) Then entTrazaCambio.OBSERVACIONES &= "Horario Entrada 1: " & entity.HORAENTRADA1 & Environment.NewLine
                If Not F_IsNullValue(entity.HORASALIDA1) Then entTrazaCambio.OBSERVACIONES &= "Horario Salida 1: " & entity.HORASALIDA1 & Environment.NewLine
                If Not F_IsNullValue(entity.HORAENTRADA2) Then entTrazaCambio.OBSERVACIONES &= "Horario Entrada 2: " & entity.HORAENTRADA2 & Environment.NewLine
                If Not F_IsNullValue(entity.HORASALIDA2) Then entTrazaCambio.OBSERVACIONES &= "Horario Salida 2: " & entity.HORASALIDA2 & Environment.NewLine
                If Not objTrazaCambio.Save(entTrazaCambio) Then
                    Throw New Exception("Error al guardar horario adicional del empleado." & Environment.NewLine & "No se pudo guardar la traza del cambio")
                Else
                    flgOkSave = True
                End If
            End If

            If flgOkSave Then
                Odal.CommitTransaction()
            Else
                If flgBeginTran Then Odal.CancelTransaction()
            End If

        Catch ex As Exception
            If flgBeginTran Then Odal.CancelTransaction()
            MyBase.InternalError = ex.Message
            MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "Error al guardar"
            If ThrowErr Then Throw New System.Exception(ex.Message, ex)
        Finally
            Odal.Desconectar()
        End Try

        Return flgOkSave
    End Function

    Private Sub ValidarDatos(ByVal entity As HorarioAdicEmpleado)
        Dim listHorarioAdicEmpleado As List(Of HorarioAdicEmpleado)

        Try
            Dim Fecha As Date = entity.FECHADESDE
            Dim idAux As Long = entity.ID

            'Valido FEcha
            If Fecha.Year < 2000 Or Fecha.Year > 2100 Then Throw New Exception("Fecha fuera del rango admitido.")
            listHorarioAdicEmpleado = GetByEmpleado(entity.IDEMPLEADO)
            listHorarioAdicEmpleado = listHorarioAdicEmpleado.Where(Function(f) f.ACTIVO).ToList
            If Not entity.IsNew Then listHorarioAdicEmpleado = listHorarioAdicEmpleado.Where(Function(f) Not f.ID.Equals(entity.ID)).ToList
            listHorarioAdicEmpleado = listHorarioAdicEmpleado.Where(Function(f) (f.FECHADESDE <= entity.FECHADESDE AndAlso f.FECHAHASTA >= entity.FECHADESDE) OrElse (f.FECHADESDE <= entity.FECHAHASTA AndAlso f.FECHAHASTA >= entity.FECHAHASTA)).ToList
            If listHorarioAdicEmpleado.Count > 0 Then Throw New Exception("Ya existe un horario adicional definido dentro de ese rango de fechas !")

            'ValidoHoras
            Call ValidaHoraMilitarDesdeHasta(entity.HORAENTRADA, entity.HORASALIDA)
            If Not F_IsNullValue(entity.HORAENTRADA1) Or Not F_IsNullValue(entity.HORASALIDA1) Then
                Call ValidaHoraMilitarDesdeHasta(entity.HORAENTRADA1, entity.HORASALIDA1)
                If entity.HORAENTRADA1 > entity.HORAENTRADA AndAlso entity.HORAENTRADA1 < entity.HORASALIDA Then Throw New Exception("Tiene horas superpuestas en la definición")
                If entity.HORASALIDA1 > entity.HORAENTRADA AndAlso entity.HORASALIDA1 < entity.HORASALIDA Then Throw New Exception("Tiene horas superpuestas en la definición")
            End If
            If Not F_IsNullValue(entity.HORAENTRADA2) Or Not F_IsNullValue(entity.HORASALIDA2) Then
                Call ValidaHoraMilitarDesdeHasta(entity.HORAENTRADA2, entity.HORASALIDA2)
                If entity.HORAENTRADA2 > entity.HORAENTRADA AndAlso entity.HORAENTRADA2 < entity.HORASALIDA Then Throw New Exception("Tiene horas superpuestas en la definición")
                If entity.HORASALIDA2 > entity.HORAENTRADA AndAlso entity.HORASALIDA2 < entity.HORASALIDA Then Throw New Exception("Tiene horas superpuestas en la definición")
                If entity.HORAENTRADA2 > entity.HORAENTRADA1 AndAlso entity.HORAENTRADA2 < entity.HORASALIDA1 Then Throw New Exception("Tiene horas superpuestas en la definición")
                If entity.HORASALIDA2 > entity.HORAENTRADA1 AndAlso entity.HORASALIDA2 < entity.HORASALIDA1 Then Throw New Exception("Tiene horas superpuestas en la definición")
            End If

        Catch ex As Exception
            Throw New System.Exception(ex.Message, ex)
        End Try
    End Sub

    Private Sub ValidaHoraMilitarDesdeHasta(ByVal HoraEntrada As Integer, ByVal HoraSalida As Integer)
        If F_IsNullValue(HoraEntrada) OrElse F_IsNullValue(HoraSalida) Then Throw New Exception("Hay horarios faltantes en la definición.")

        Dim strHoraEntrada As String = Strings.StrDup(4 - CStr(HoraEntrada).Length, "0") & HoraEntrada
        Dim strHoraSalida As String = Strings.StrDup(4 - CStr(HoraSalida).Length, "0") & HoraSalida

        If HoraEntrada < 0 OrElse CInt(Strings.Left(strHoraEntrada, 2)) > 24 OrElse CInt(Strings.Right(strHoraEntrada, 2)) > 60 Then Throw New Exception("Horario con formato inválido.")
        If HoraSalida < 0 OrElse CInt(Strings.Left(strHoraSalida, 2)) > 24 OrElse CInt(Strings.Right(strHoraSalida, 2)) > 60 Then Throw New Exception("Horario con formato inválido.")

        If HoraEntrada >= HoraSalida Then Throw New Exception("Horario superpuestos.")
    End Sub


End Class
