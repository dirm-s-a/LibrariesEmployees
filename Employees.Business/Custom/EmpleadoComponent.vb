Imports Employees.Data
Imports System.Collections.Generic
Imports Employees.Entities
Imports Turnos.GlobalFunctions.Data

Partial Public Class EmpleadoComponent
    Public Function SaveConTraza(ByRef entity As Empleado, Optional ByVal sp As Boolean = True, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Dim flgOkSave As Boolean = False
        Dim Odal As New EmpleadoData
        Dim objEmpleado As New EmpleadoComponent()
        Dim objTrazaCambio As New TrazaCambioComponent()
        Dim entTrazaCambio As TrazaCambio
        Dim flgBeginTran As Boolean = False

        Try
            Dim flgNew As Boolean = (F_IsNullValue(entity.ID))

            Odal.BeginTransaction()
            flgBeginTran = True

            'Call ValidarDatos(entity)
            entity.FECHAMODIFICACION = Date.Now
            If Not Save(entity) Then
                Throw New Exception("Error al guardar el Empleado.")
            Else
                Dim entEmpleado As Empleado = objEmpleado.GetEntById(entity.ID)
                entTrazaCambio = New TrazaCambio
                entTrazaCambio.BeginUpdate()
                entTrazaCambio.IDUSUARIO = entity.IDUSUARIOMODIFICACION
                entTrazaCambio.IDAUXILIAR = entity.ID
                entTrazaCambio.TABLAAUXILIAR = "Empleado"
                entTrazaCambio.IDEMPLEADO = entity.ID
                If flgNew Then
                    entTrazaCambio.OBSERVACIONES = "Alta de Empleado: " & Environment.NewLine
                Else
                    If entity.INACTIVO = False Then
                        entTrazaCambio.OBSERVACIONES = "Modificación de Empleado" & Environment.NewLine
                    Else
                        entTrazaCambio.OBSERVACIONES = "Baja de Empleado" & Environment.NewLine
                        entTrazaCambio.IDUSUARIO = entity.IDUSUARIOMODIFICACION
                    End If
                End If

                entTrazaCambio.OBSERVACIONES &= "Empleado: " & entity.NOMBRE & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Nro. Documento: " & entity.NRODOCUMENTO & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Email: " & entity.EMAIL & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "id Convenio: " & entity.IDCONVENIO & " ( " & entEmpleado.IDCONVENIO_Desc & ")" & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Inactivo: " & entity.INACTIVO & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Sector: " & entity.SECTOR & Environment.NewLine
                If Not objTrazaCambio.Save(entTrazaCambio) Then
                    Throw New Exception("Error al guardar horario adicional del Empleado." & Environment.NewLine & "No se pudo guardar la traza del cambio")
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

    Public Function EliminarCompleto(ByVal idEmpleado As Long, ByVal idUsuario As String, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Dim Odal As New EmpleadoData
        Dim flgOkSave As Boolean = False
        Dim objEmpleado As New EmpleadoComponent()
        Dim objTrazaCambio As New TrazaCambioComponent()
        Dim entTrazaCambio As TrazaCambio

        Try
            Odal.BeginTransaction()
            Dim entEmpleado As Empleado = objEmpleado.GetEntById(idEmpleado)
            entTrazaCambio = New TrazaCambio
            entTrazaCambio.BeginUpdate()
            entTrazaCambio.IDUSUARIO = idUsuario
            entTrazaCambio.IDAUXILIAR = idEmpleado
            entTrazaCambio.OBSERVACIONES = "Eliminación de Empleado" & Environment.NewLine
            entTrazaCambio.OBSERVACIONES &= "Empleado: " & entEmpleado.NOMBRE & Environment.NewLine
            entTrazaCambio.OBSERVACIONES &= "Documento: " & entEmpleado.NRODOCUMENTO & Environment.NewLine

            flgOkSave = objTrazaCambio.Save(entTrazaCambio)
            If flgOkSave Then flgOkSave = Odal.EliminarCompleto(idEmpleado)

            If flgOkSave Then
                Odal.CommitTransaction()
            Else
                Odal.CancelTransaction()
            End If

        Catch ex As Exception
            Odal.CancelTransaction()
            Return False
        Finally
            Odal.Desconectar()
        End Try

        Return flgOkSave
    End Function

    Public Sub BuscaInasistenciaAhora(ByRef ListEmpleadosAusentes As List(Of Empleado))

        Dim Listempleados As List(Of Empleado)
        Dim objEmpleado As New EmpleadoComponent
        Dim ListConvenios As List(Of Convenio)

        Dim objConvenios As New ConvenioComponent
        Dim objFichadaLectura As New FichadaLecturaComponent
        Dim objFeriado As New FeriadoComponent
        Dim objAusenciaEmpleado As New AusenciaEmpleadoComponent
        Dim objHorarioAdicEmpleado As New HorarioAdicEmpleadoComponent
        Dim objHorarioEmpleado As New HorarioEmpleadoComponent
        Dim DiaSemanaFichada As Integer
        Dim entHorarioAdicEmpleado As HorarioAdicEmpleado
        Dim entHorarioEmpleado As HorarioEmpleado
        Dim flgInconsistencia As Boolean = False
        Dim entEmpleado As Empleado
        Dim flgConHorario As Boolean = False
        Dim ContadorEmpleados As Long = 0
        Dim Fecha As Date
        Dim HoraActual As Date
        Dim flgEmpleadoAusente As Boolean = False

        Try
            Fecha = Date.Today
            HoraActual = Date.Now
            ListEmpleadosAusentes = New List(Of Empleado)
            Listempleados = objEmpleado.GetALL()

            Dim entFeriado As New Feriado
            entFeriado.BeginUpdate()
            entFeriado.FECHA = Fecha
            entFeriado.ACTIVO = True
            Dim ListFeriados As List(Of Feriado) = objFeriado.GetListByEnt(entFeriado).ToList
            If ListFeriados.Count > 0 Then Exit Sub

            DiaSemanaFichada = Weekday(Fecha, FirstDayOfWeek.Monday)
            ListConvenios = objConvenios.GetALL
            Dim ListFichadasLectura As List(Of FichadaLectura) = objFichadaLectura.GetTodoEntreFechas(Fecha, Fecha.AddDays(1)).Where(Function(f) f.TIPOFICHADA.Equals("0") OrElse f.TIPOFICHADA.Equals("128") AndAlso f.DESCARTADA.Equals(False)).ToList

            For Each entEmpleado In Listempleados
                flgConHorario = False
                Dim entConvenio As Convenio = ListConvenios.Where(Function(f) f.ID.Equals(entEmpleado.IDCONVENIO)).ToList(0)
                'Me fijo si por convenio tiene excluido los controles o tiene horario flexible (porque puede venir en cualquier horario).
                If Not entConvenio.HORARIOFLEXIBLE AndAlso Not entConvenio.SINCONTROLES AndAlso F_IsNullValue(entEmpleado.FECHABAJA) AndAlso entEmpleado.INACTIVO = False Then
                    'Me fijo si ya tiene cargado un ausente.
                    If objAusenciaEmpleado.GetByEmpleado(entEmpleado.ID).Where(Function(f) Not f.IDUSUARIOAPRUEBA = "" AndAlso f.IDUSUARIOANULA = "" AndAlso f.FECHADESDE <= Fecha AndAlso f.FECHAHASTA >= Fecha).Count = 0 Then
                        entHorarioAdicEmpleado = Nothing
                        entHorarioEmpleado = Nothing
                        Dim ListHorarioAdicEmpleado As List(Of HorarioAdicEmpleado) = objHorarioAdicEmpleado.GetByEmpleado(entEmpleado.ID).Where(Function(f) f.ACTIVO = True AndAlso f.AUTORIZADO = True AndAlso f.FECHADESDE <= Fecha AndAlso f.FECHAHASTA >= Fecha).ToList()
                        Dim ListHorarioEmpleado As List(Of HorarioEmpleado) = objHorarioEmpleado.GetByEmpleado(entEmpleado.ID).Where(Function(f) f.ACTIVO = True AndAlso f.FECHADESDE <= Fecha AndAlso f.FECHAHASTA >= Fecha AndAlso f.DIASEMANAENTRADA = DiaSemanaFichada).ToList()
                        Dim ListFichadasLecturaEmpleado As List(Of FichadaLectura) = ListFichadasLectura.Where(Function(f) f.IDEMPLEADO.Equals(entEmpleado.ID)).ToList
                        ContadorEmpleados += 1

                        Dim MinutosAux As Integer = 9999
                        Dim FechaAux2 As Date = F_Set_NullValue(FechaAux2)
                        Dim Horas As Integer = F_Set_NullValue(Horas)
                        Dim Minutos As Integer = F_Set_NullValue(Horas)
                        Dim FechaAux As Date = F_Set_NullValue(FechaAux)

                        If ListHorarioAdicEmpleado.Count > 0 Then
                            flgConHorario = True
                            entHorarioAdicEmpleado = ListHorarioAdicEmpleado(0)

                            If Not F_IsNullValue(entHorarioAdicEmpleado.HORAENTRADA) Then
                                Horas = (Math.Truncate(entHorarioAdicEmpleado.HORAENTRADA / 100))
                                Minutos = entHorarioAdicEmpleado.HORAENTRADA - (Horas * 100)
                                FechaAux = Fecha.AddHours(Horas).AddMinutes(Minutos)
                                If DateDiff(DateInterval.Minute, FechaAux, HoraActual) > 30 Then
                                    flgEmpleadoAusente = True
                                    If ListFichadasLecturaEmpleado.Where(Function(f) DateDiff(DateInterval.Minute, FechaAux, f.FECHAFICHADA) < 60).Count > 0 Then flgEmpleadoAusente = False
                                End If
                            End If
                            If Not F_IsNullValue(entHorarioAdicEmpleado.HORAENTRADA1) Then
                                Horas = (Math.Truncate(entHorarioAdicEmpleado.HORAENTRADA1 / 100))
                                Minutos = entHorarioAdicEmpleado.HORAENTRADA1 - (Horas * 100)
                                If DateDiff(DateInterval.Minute, FechaAux, HoraActual) > 30 Then
                                    flgEmpleadoAusente = True
                                    If ListFichadasLecturaEmpleado.Where(Function(f) DateDiff(DateInterval.Minute, FechaAux, f.FECHAFICHADA) < 60).Count > 0 Then flgEmpleadoAusente = False
                                End If
                            End If
                            If Not F_IsNullValue(entHorarioAdicEmpleado.HORAENTRADA2) Then
                                Horas = (Math.Truncate(entHorarioAdicEmpleado.HORAENTRADA2 / 100))
                                Minutos = entHorarioAdicEmpleado.HORAENTRADA2 - (Horas * 100)
                                FechaAux = Fecha.AddHours(Horas).AddMinutes(Minutos)
                                If DateDiff(DateInterval.Minute, FechaAux, HoraActual) > 30 Then
                                    flgEmpleadoAusente = True
                                    If ListFichadasLecturaEmpleado.Where(Function(f) DateDiff(DateInterval.Minute, FechaAux, f.FECHAFICHADA) < 60).Count > 0 Then flgEmpleadoAusente = False
                                End If
                            End If


                        ElseIf ListHorarioEmpleado.Count > 0 Then
                            flgConHorario = True
                            entHorarioEmpleado = ListHorarioEmpleado(0)

                            If Not F_IsNullValue(entHorarioEmpleado.HORAENTRADA) Then
                                Horas = (Math.Truncate(entHorarioEmpleado.HORAENTRADA / 100))
                                Minutos = entHorarioEmpleado.HORAENTRADA - (Horas * 100)
                                FechaAux = Fecha.AddHours(Horas).AddMinutes(Minutos)
                                If DateDiff(DateInterval.Minute, FechaAux, HoraActual) > 30 Then
                                    flgEmpleadoAusente = True
                                    If ListFichadasLecturaEmpleado.Where(Function(f) DateDiff(DateInterval.Minute, FechaAux, f.FECHAFICHADA) < 60).Count > 0 Then flgEmpleadoAusente = False
                                End If
                            End If
                            If Not F_IsNullValue(entHorarioEmpleado.HORAENTRADA1) Then
                                Horas = (Math.Truncate(entHorarioEmpleado.HORAENTRADA1 / 100))
                                Minutos = entHorarioEmpleado.HORAENTRADA1 - (Horas * 100)
                                FechaAux = Fecha.AddHours(Horas).AddMinutes(Minutos)
                                If DateDiff(DateInterval.Minute, FechaAux, HoraActual) > 30 Then
                                    flgEmpleadoAusente = True
                                    If ListFichadasLecturaEmpleado.Where(Function(f) DateDiff(DateInterval.Minute, FechaAux, f.FECHAFICHADA) < 60).Count > 0 Then flgEmpleadoAusente = False
                                End If
                            End If
                            If Not F_IsNullValue(entHorarioEmpleado.HORAENTRADA2) Then
                                Horas = (Math.Truncate(entHorarioEmpleado.HORAENTRADA2 / 100))
                                Minutos = entHorarioEmpleado.HORAENTRADA2 - (Horas * 100)
                                FechaAux = Fecha.AddHours(Horas).AddMinutes(Minutos)
                                If DateDiff(DateInterval.Minute, FechaAux, HoraActual) > 30 Then
                                    flgEmpleadoAusente = True
                                    If ListFichadasLecturaEmpleado.Where(Function(f) DateDiff(DateInterval.Minute, FechaAux, f.FECHAFICHADA) < 60).Count > 0 Then flgEmpleadoAusente = False
                                End If
                            End If
                        Else
                            'No hay Horario asignado para la fichada del empleado
                            flgConHorario = False
                        End If

                        If flgConHorario AndAlso flgEmpleadoAusente Then
                            If ListFichadasLecturaEmpleado.Count > 0 Then entEmpleado.SECTOR = "*"
                            ListEmpleadosAusentes.Add(entEmpleado)
                        End If

                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("Error al procesar Ausencias: " & ex.Message, ex.InnerException)
        End Try
    End Sub

End Class
