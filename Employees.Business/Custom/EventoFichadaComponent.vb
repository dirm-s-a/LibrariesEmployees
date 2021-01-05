Imports Employees.Data
Imports System.Collections.Generic
Imports Employees.Entities
Imports Turnos.GlobalFunctions.Data
Partial Public Class EventoFichadaComponent
    Public Event PercentDone(ByVal Percent As Single, ByVal Observacion As String, ByVal Contador As Long, ByRef Cancel As Boolean)
    Public Sub Desprocesar(ByRef Listempleados As List(Of Empleado), ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByRef flgCancelado As Boolean)
        'Dim objFichadaLecura As New FichadaLecturaComponent
        Dim flgBeginTran As Boolean = False
        Dim Contador As Long = 0
        Try
            'Dim Listfichadas As List(Of FichadaLectura) = objFichadaLecura.GetTodoEntreFechas(FechaDesde, FechaHasta.AddDays(1))
            flgCancelado = False
            'Dim ListEventoFichadas As List(Of EventoFichada) = GetTodoEntreFechasEntrada(FechaDesde, FechaHasta)
            For Each entEmpleado As Empleado In Listempleados
                Contador += 1
                RaiseEvent PercentDone(Contador * 100 / Listempleados.Count, entEmpleado.NOMBRE, Contador, flgCancelado)
                If flgCancelado Then Exit Sub
                Delete(entEmpleado.ID, FechaDesde, FechaHasta.AddDays(1))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try

    End Sub

    Public Sub ProcesaFichadas(ByRef Listempleados As List(Of Empleado),
                               ByVal FechaDesde As Date,
                               ByVal FechaHasta As Date,
                               ByRef ListEmpleadosInconsistencias As List(Of Empleado),
                               ByRef flgCancelado As Boolean,
                               Optional ByVal flgProcesaInconsistencias As Boolean = False)

        Dim objConvenios As New ConvenioComponent
        Dim objFichadaLectura As New FichadaLecturaComponent
        Dim objFeriado As New FeriadoComponent
        Dim objAusenciaEmpleado As New AusenciaEmpleadoComponent
        Dim ListEventosFichada As List(Of EventoFichada)
        Dim ListAusenciasEmpleado As List(Of AusenciaEmpleado)
        Dim Contador As Long = 0
        Dim objHorarioAdicEmpleado As New HorarioAdicEmpleadoComponent
        Dim objHorarioEmpleado As New HorarioEmpleadoComponent
        Dim DiaSemanaFichada As Integer
        Dim entHorarioAdicEmpleado As HorarioAdicEmpleado
        Dim entHorarioEmpleado As HorarioEmpleado
        Dim entEventoFichada As EventoFichada
        Dim flgInconsistencia As Boolean = False
        Dim entEmpleado As Empleado
        Dim flgHorarioEntreDias As Boolean
        Dim flgConHorario As Boolean
        Dim flgAusente As Boolean
        Dim flgConEventosPrevios As Boolean = False
        Dim ContadorEmpleados As Long = 0
        Try
            Dim ListConvenios As List(Of Convenio) = objConvenios.GetALL
            Dim ListEventosPrevios As List(Of EventoFichada) = GetTodoEntreFechasEntrada(FechaDesde, FechaHasta)
            Dim ListFeriados As List(Of Feriado) = objFeriado.GetListByEnt(New Feriado).Where(Function(f) f.FECHAANULACION < New DateTime(2000, 1, 1)).ToList

            For Each entEmpleado In Listempleados
                entEventoFichada = Nothing
                flgInconsistencia = False
                ListEventosFichada = New List(Of EventoFichada)
                ListAusenciasEmpleado = Nothing
                ListAusenciasEmpleado = objAusenciaEmpleado.GetByEmpleado(entEmpleado.ID).Where(Function(f) Not f.IDUSUARIOAPRUEBA = "" AndAlso f.IDUSUARIOANULA = "").ToList()

                Dim ListHorarioAdicEmpleado As List(Of HorarioAdicEmpleado) = objHorarioAdicEmpleado.GetByEmpleado(entEmpleado.ID).Where(Function(f) f.ACTIVO = True AndAlso f.AUTORIZADO = True).ToList()
                Dim ListHorarioEmpleado As List(Of HorarioEmpleado) = objHorarioEmpleado.GetByEmpleado(entEmpleado.ID).Where(Function(f) f.ACTIVO = True).ToList()
                Dim ListFichadasLectura As List(Of FichadaLectura) = objFichadaLectura.GetxIdEmpleadoSinProcesar(entEmpleado.ID)
                Dim entConvenio As Convenio = ListConvenios.Where(Function(f) f.ID.Equals(entEmpleado.IDCONVENIO)).ToList(0)
                Dim FechaProceso As Date = FechaDesde

                ContadorEmpleados += 1
                RaiseEvent PercentDone(ContadorEmpleados * 100 / Listempleados.Count, entEmpleado.NOMBRE, ContadorEmpleados, flgCancelado)

                Do Until FechaProceso > FechaHasta
                    If Not entEventoFichada Is Nothing Then
                        'Vengo de otro día con una sola fichada en el evento
                        If F_IsNullValue(entEventoFichada.FECHAENTRADA) Then
                            entEventoFichada.FECHAENTRADA = entEventoFichada.FECHASALIDA
                            entEventoFichada.OBSERVACIONES = "Sin fichada de entrada."
                        Else
                            entEventoFichada.OBSERVACIONES = "Sin fichada de salida."
                        End If
                        entEventoFichada.INCONSISTENCIA = True
                        ListEventosFichada.Add(entEventoFichada)
                        entEventoFichada = Nothing
                    End If
                    entHorarioAdicEmpleado = Nothing
                    entHorarioEmpleado = Nothing

                    Dim entAusenciaEmpleado As AusenciaEmpleado = Nothing
                    If ListAusenciasEmpleado.Exists(Function(f) f.FECHADESDE <= FechaProceso AndAlso f.FECHAHASTA >= FechaProceso) Then
                        entAusenciaEmpleado = ListAusenciasEmpleado.Where(Function(f) f.FECHADESDE <= FechaProceso AndAlso f.FECHAHASTA >= FechaProceso).ToList(0)
                    End If

                    If ListFeriados.Where(Function(f) f.FECHA.Equals(FechaProceso)).Count = 0 Then
                        flgConEventosPrevios = ListEventosPrevios.Where(Function(f) f.IDEMPLEADO.Equals(entEmpleado.ID) AndAlso f.FECHAENTRADA >= FechaProceso AndAlso f.FECHAENTRADA < FechaProceso.AddDays(1)).Count > 0
                        flgConHorario = False
                        flgHorarioEntreDias = False
                        DiaSemanaFichada = Weekday(FechaProceso, FirstDayOfWeek.Monday)
                        If listHorarioAdicEmpleado.Where(Function(f) f.FECHADESDE <= FechaProceso AndAlso f.FECHAHASTA >= FechaProceso).Count = 1 Then
                            flgConHorario = True
                            entHorarioAdicEmpleado = listHorarioAdicEmpleado.Where(Function(f) f.FECHADESDE <= FechaProceso AndAlso f.FECHAHASTA >= FechaProceso).ToList(0)
                            If entHorarioAdicEmpleado.HORAENTRADA > entHorarioAdicEmpleado.HORASALIDA OrElse
                                entHorarioAdicEmpleado.HORAENTRADA1 > entHorarioAdicEmpleado.HORASALIDA1 OrElse
                                entHorarioAdicEmpleado.HORAENTRADA2 > entHorarioAdicEmpleado.HORASALIDA2 Then
                                flgHorarioEntreDias = True
                            End If
                        ElseIf ListHorarioEmpleado.Where(Function(f) f.DIASEMANAENTRADA <= DiaSemanaFichada AndAlso f.DIASEMANASALIDA >= DiaSemanaFichada AndAlso f.FECHADESDE <= FechaProceso AndAlso f.FECHAHASTA >= FechaProceso).Count = 1 Then
                            flgConHorario = True
                            entHorarioEmpleado = ListHorarioEmpleado.Where(Function(f) f.DIASEMANAENTRADA <= DiaSemanaFichada AndAlso f.DIASEMANASALIDA >= DiaSemanaFichada AndAlso f.FECHADESDE <= FechaProceso AndAlso f.FECHAHASTA >= FechaProceso).ToList(0)
                            If entHorarioEmpleado.HORAENTRADA > entHorarioEmpleado.HORASALIDA OrElse
                                entHorarioEmpleado.HORAENTRADA1 > entHorarioEmpleado.HORASALIDA1 OrElse
                                entHorarioEmpleado.HORAENTRADA2 > entHorarioEmpleado.HORASALIDA2 Then
                                flgHorarioEntreDias = True
                            End If
                        Else
                            'No hay Horario asignado para la fichada del empleado
                            flgConHorario = False
                        End If
                        If flgConHorario OrElse flgProcesaInconsistencias Then
                            Dim ListFichadasLecturaAux As List(Of FichadaLectura) = ListFichadasLectura.Where(Function(f) f.FECHAFICHADA >= FechaProceso AndAlso f.FECHAFICHADA < FechaProceso.AddDays(1)).ToList
                            If flgHorarioEntreDias Then
                                If ListFichadasLectura.Where(Function(f) f.FECHAFICHADA >= FechaProceso.AddDays(1) AndAlso f.FECHAFICHADA < FechaProceso.AddDays(2)).Count > 0 Then
                                    Dim entAux As FichadaLectura = ListFichadasLectura.Where(Function(f) f.FECHAFICHADA >= FechaProceso.AddDays(1) AndAlso f.FECHAFICHADA < FechaProceso.AddDays(2)).OrderBy(Function(o) o.FECHAFICHADA).ToList(0)
                                    Dim TipoFichada As String = IIf(F_IsNullValue(entAux.TIPOFICHADASUPERVISOR), entAux.TIPOFICHADA, entAux.TIPOFICHADASUPERVISOR)

                                    If (TipoFichada = "1" OrElse TipoFichada = "129") Then
                                        ListFichadasLecturaAux.Add(entAux)
                                        ListFichadasLectura.Remove(entAux)
                                    End If
                                End If
                            End If
                            ListFichadasLecturaAux.OrderBy(Function(o) o.FECHAFICHADA).ToList

                            If ListFichadasLecturaAux.Count = 0 Then
                                If Not flgConEventosPrevios AndAlso flgConHorario Then
                                    entEventoFichada = New EventoFichada
                                    entEventoFichada.BeginUpdate()
                                    entEventoFichada.IDCONVENIO = entConvenio.ID
                                    entEventoFichada.IDEMPLEADO = entEmpleado.ID
                                    entEventoFichada.MINUTOSTARDE = 0
                                    entEventoFichada.FECHAENTRADA = New DateTime(FechaProceso.Year, FechaProceso.Month, FechaProceso.Day, 8, 0, 0)
                                    entEventoFichada.FECHASALIDA = New DateTime(FechaProceso.Year, FechaProceso.Month, FechaProceso.Day, 17, 0, 0)
                                    entEventoFichada.MINUTOSTRABAJADOS = 0
                                    entEventoFichada.AUSENTE = True
                                    entEventoFichada.OBSERVACIONES = "Ausente. "
                                    If Not entAusenciaEmpleado Is Nothing Then
                                        entEventoFichada.IDAUSENCIAEMPLEADO = entAusenciaEmpleado.ID
                                        entEventoFichada.OBSERVACIONES &= entAusenciaEmpleado.IDTIPOAUSENCIA_Desc
                                    End If
                                    If Not entHorarioEmpleado Is Nothing Then entEventoFichada.IDHORARIOEMPLEADO = entHorarioEmpleado.ID
                                    If Not entHorarioAdicEmpleado Is Nothing Then entEventoFichada.IDHORARIOADICEMPLEADO = entHorarioAdicEmpleado.ID
                                    ListEventosFichada.Add(entEventoFichada)
                                    entEventoFichada = Nothing
                                End If
                                flgAusente = True 'Tengo o eventos previos lo marco para no calcular Puntualidad
                            Else
                                flgAusente = False
                                Contador = 0
                                entEventoFichada = Nothing
                                For Each entFichadaLectura As FichadaLectura In ListFichadasLecturaAux
                                    If entFichadaLectura.INCONSISTENCIA AndAlso flgProcesaInconsistencias = False Then
                                        ListEmpleadosInconsistencias.Add(entEmpleado)
                                        flgInconsistencia = True
                                        Exit Do
                                    Else
                                        Dim TipoFichada As String = IIf(F_IsNullValue(entFichadaLectura.TIPOFICHADASUPERVISOR), entFichadaLectura.TIPOFICHADA, entFichadaLectura.TIPOFICHADASUPERVISOR)
                                        If (TipoFichada = "1" OrElse TipoFichada = "129") AndAlso Contador = 0 AndAlso flgHorarioEntreDias Then
                                            'La primer fichada de salida puede venir de un presentisomo del día anterior, sin procesar.
                                        ElseIf (TipoFichada = "0" OrElse TipoFichada = "128") Then
                                            If Not entEventoFichada Is Nothing Then
                                                'Inconsistencia. Dos fichadas de entrada juntas
                                                If flgProcesaInconsistencias Then
                                                    'entEventoFichada.FECHASALIDA = entEventoFichada.FECHAENTRADA
                                                    entEventoFichada.INCONSISTENCIA = True
                                                    entEventoFichada.OBSERVACIONES = "Sin fichada de salida."
                                                    ListEventosFichada.Add(entEventoFichada)
                                                    entEventoFichada = Nothing
                                                Else
                                                    flgInconsistencia = True
                                                    Exit Do
                                                End If
                                            End If

                                            entEventoFichada = New EventoFichada
                                            entEventoFichada.BeginUpdate()
                                            entEventoFichada.IDCONVENIO = entConvenio.ID
                                            entEventoFichada.IDEMPLEADO = entFichadaLectura.IDEMPLEADO
                                            entEventoFichada.FECHAENTRADA = entFichadaLectura.FECHAFICHADA
                                            entEventoFichada.IDFICHADAENTRADA = entFichadaLectura.ID
                                            entEventoFichada.AUSENTE = False
                                            entEventoFichada.MINUTOSTARDE = 0
                                            If Not entHorarioEmpleado Is Nothing Then entEventoFichada.IDHORARIOEMPLEADO = entHorarioEmpleado.ID
                                            If Not entHorarioAdicEmpleado Is Nothing Then entEventoFichada.IDHORARIOADICEMPLEADO = entHorarioAdicEmpleado.ID
                                        ElseIf (TipoFichada = "1" OrElse TipoFichada = "129") Then
                                            If entEventoFichada Is Nothing Then
                                                entEventoFichada = New EventoFichada
                                                entEventoFichada.BeginUpdate()
                                                entEventoFichada.IDCONVENIO = entConvenio.ID
                                                entEventoFichada.IDEMPLEADO = entFichadaLectura.IDEMPLEADO
                                                entEventoFichada.INCONSISTENCIA = True
                                                entEventoFichada.MINUTOSTARDE = 0
                                                entEventoFichada.FECHAENTRADA = entFichadaLectura.FECHAFICHADA
                                                entEventoFichada.OBSERVACIONES = "Sin fichada de entrada."
                                            End If
                                            entEventoFichada.FECHASALIDA = entFichadaLectura.FECHAFICHADA
                                            entEventoFichada.IDFICHADASALIDA = entFichadaLectura.ID
                                            If entAusenciaEmpleado IsNot Nothing Then
                                                entEventoFichada.INCONSISTENCIA = True
                                                entEventoFichada.OBSERVACIONES = "Fichada con ausentismo aprobado este día."
                                            End If
                                            If Not entEventoFichada.INCONSISTENCIA Then
                                                entEventoFichada.MINUTOSTRABAJADOS = DateDiff(DateInterval.Minute, entEventoFichada.FECHAENTRADA, entEventoFichada.FECHASALIDA)
                                            End If
                                            If Not flgConHorario Then entEventoFichada.OBSERVACIONES &= "Evento sin horario cargado."
                                            ListEventosFichada.Add(entEventoFichada)
                                            entEventoFichada = Nothing
                                        End If
                                        Contador += 1
                                    End If
                                Next
                                If flgInconsistencia Then Exit Do
                            End If
                        End If
                        If entConvenio.AUSENTISMO AndAlso Not flgAusente And flgConHorario Then
                            'Calculo puntualidad
                            If Not entHorarioAdicEmpleado Is Nothing Then
                                Dim DifAux As Integer = 999
                                If Not F_IsNullValue(entHorarioAdicEmpleado.HORAENTRADA) Then
                                    DifAux = 999
                                    Dim entEventoFichadaAux As EventoFichada = Nothing
                                    For Each eEventoFichada As EventoFichada In ListEventosFichada.Where(Function(f) f.FECHAENTRADA >= FechaProceso AndAlso f.FECHAENTRADA < FechaProceso.AddDays(1) AndAlso f.INCONSISTENCIA = False).ToList
                                        If eEventoFichada.MINUTOSTARDE = 0 Then
                                            Dim Horas As Integer = (Math.Truncate(entHorarioAdicEmpleado.HORAENTRADA / 100))
                                            Dim Minutos As Integer = entHorarioAdicEmpleado.HORAENTRADA - (Horas * 100)
                                            Dim FechaAux As Date = FechaProceso.AddHours(Horas).AddMinutes(Minutos)
                                            If DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA) < DifAux Then
                                                DifAux = DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA)
                                                entEventoFichadaAux = eEventoFichada
                                            End If
                                        End If
                                    Next
                                    If Not entEventoFichadaAux Is Nothing Then entEventoFichadaAux.MINUTOSTARDE = DifAux
                                End If
                                If Not F_IsNullValue(entHorarioAdicEmpleado.HORAENTRADA1) Then
                                    DifAux = 999
                                    Dim entEventoFichadaAux As EventoFichada = Nothing
                                    For Each eEventoFichada As EventoFichada In ListEventosFichada.Where(Function(f) f.FECHAENTRADA >= FechaProceso AndAlso f.FECHAENTRADA < FechaProceso.AddDays(1) AndAlso f.INCONSISTENCIA = False).ToList
                                        If eEventoFichada.MINUTOSTARDE = 0 Then
                                            Dim Horas As Integer = (Math.Truncate(entHorarioAdicEmpleado.HORAENTRADA1 / 100))
                                            Dim Minutos As Integer = entHorarioAdicEmpleado.HORAENTRADA1 - (Horas * 100)
                                            Dim FechaAux As Date = FechaProceso.AddHours(Horas).AddMinutes(Minutos)
                                            If DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA) < DifAux Then
                                                DifAux = DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA)
                                                entEventoFichadaAux = eEventoFichada
                                            End If
                                        End If
                                    Next
                                    If Not entEventoFichadaAux Is Nothing Then entEventoFichadaAux.MINUTOSTARDE = DifAux
                                End If
                                If Not F_IsNullValue(entHorarioAdicEmpleado.HORAENTRADA2) Then
                                    DifAux = 999
                                    Dim entEventoFichadaAux As EventoFichada = Nothing
                                    For Each eEventoFichada As EventoFichada In ListEventosFichada.Where(Function(f) f.FECHAENTRADA >= FechaProceso AndAlso f.FECHAENTRADA < FechaProceso.AddDays(1) AndAlso f.INCONSISTENCIA = False).ToList
                                        If eEventoFichada.MINUTOSTARDE = 0 Then
                                            Dim Horas As Integer = (Math.Truncate(entHorarioAdicEmpleado.HORAENTRADA2 / 100))
                                            Dim Minutos As Integer = entHorarioAdicEmpleado.HORAENTRADA2 - (Horas * 100)
                                            Dim FechaAux As Date = FechaProceso.AddHours(Horas).AddMinutes(Minutos)
                                            If DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA) < DifAux Then
                                                DifAux = DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA)
                                                entEventoFichadaAux = eEventoFichada
                                            End If

                                        End If
                                    Next
                                    If Not entEventoFichadaAux Is Nothing Then entEventoFichadaAux.MINUTOSTARDE = DifAux
                                End If
                            ElseIf Not entHorarioEmpleado Is Nothing Then
                                Dim DifAux As Integer = 999
                                If Not F_IsNullValue(entHorarioEmpleado.HORAENTRADA) Then
                                    DifAux = 999
                                    Dim entEventoFichadaAux As EventoFichada = Nothing
                                    For Each eEventoFichada As EventoFichada In ListEventosFichada.Where(Function(f) f.FECHAENTRADA >= FechaProceso AndAlso f.FECHAENTRADA < FechaProceso.AddDays(1) AndAlso f.INCONSISTENCIA = False).ToList
                                        If eEventoFichada.MINUTOSTARDE = 0 Then
                                            Dim Horas As Integer = (Math.Truncate(entHorarioEmpleado.HORAENTRADA / 100))
                                            Dim Minutos As Integer = entHorarioEmpleado.HORAENTRADA - (Horas * 100)
                                            Dim FechaAux As Date = FechaProceso.AddHours(Horas).AddMinutes(Minutos)
                                            If DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA) < DifAux Then
                                                DifAux = DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA)
                                                entEventoFichadaAux = eEventoFichada
                                            End If
                                        End If
                                    Next
                                    If Not entEventoFichadaAux Is Nothing Then entEventoFichadaAux.MINUTOSTARDE = DifAux
                                End If
                                If Not F_IsNullValue(entHorarioEmpleado.HORAENTRADA1) Then
                                    DifAux = 999
                                    Dim entEventoFichadaAux As EventoFichada = Nothing
                                    For Each eEventoFichada As EventoFichada In ListEventosFichada.Where(Function(f) f.FECHAENTRADA >= FechaProceso AndAlso f.FECHAENTRADA < FechaProceso.AddDays(1) AndAlso f.INCONSISTENCIA = False).ToList
                                        If eEventoFichada.MINUTOSTARDE = 0 Then
                                            Dim Horas As Integer = (Math.Truncate(entHorarioEmpleado.HORAENTRADA1 / 100))
                                            Dim Minutos As Integer = entHorarioEmpleado.HORAENTRADA1 - (Horas * 100)
                                            Dim FechaAux As Date = FechaProceso.AddHours(Horas).AddMinutes(Minutos)
                                            If DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA) < DifAux Then
                                                DifAux = DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA)
                                                entEventoFichadaAux = eEventoFichada
                                            End If
                                        End If
                                    Next
                                    If Not entEventoFichadaAux Is Nothing Then entEventoFichadaAux.MINUTOSTARDE = DifAux
                                End If
                                If Not F_IsNullValue(entHorarioEmpleado.HORAENTRADA2) Then
                                    DifAux = 999
                                    Dim entEventoFichadaAux As EventoFichada = Nothing
                                    For Each eEventoFichada As EventoFichada In ListEventosFichada.Where(Function(f) f.FECHAENTRADA >= FechaProceso AndAlso f.FECHAENTRADA < FechaProceso.AddDays(1) AndAlso f.INCONSISTENCIA = False).ToList
                                        If eEventoFichada.MINUTOSTARDE = 0 Then
                                            Dim Horas As Integer = (Math.Truncate(entHorarioEmpleado.HORAENTRADA2 / 100))
                                            Dim Minutos As Integer = entHorarioEmpleado.HORAENTRADA2 - (Horas * 100)
                                            Dim FechaAux As Date = FechaProceso.AddHours(Horas).AddMinutes(Minutos)
                                            If DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA) < DifAux Then
                                                DifAux = DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA)
                                                entEventoFichadaAux = eEventoFichada
                                            End If
                                        End If
                                    Next
                                    If Not entEventoFichadaAux Is Nothing Then entEventoFichadaAux.MINUTOSTARDE = DifAux
                                End If
                            End If
                        End If
                    End If
                    FechaProceso = FechaProceso.AddDays(1)
                Loop

                If Not flgInconsistencia Or flgProcesaInconsistencias Then Call GuardarEventos(ListEventosFichada)
            Next

        Catch ex As Exception
            If entEmpleado Is Nothing Then
                Throw New Exception("Error al procesar evento fichada: " & ex.Message, ex.InnerException)
            Else
                Throw New Exception("Error al procesar empleado: " & entEmpleado.NOMBRE & Environment.NewLine & "Documento: " & entEmpleado.NRODOCUMENTO & Environment.NewLine & "Error: " & ex.Message, ex.InnerException)
            End If
        End Try
    End Sub

    Private Sub CalculoPuntualidad(ByVal ListEventosFichada As List(Of EventoFichada),
                                   ByVal FechaProceso As Date,
                                   Optional ByVal entHorarioAdicEmpleado As HorarioAdicEmpleado = Nothing,
                                   Optional ByVal entHorarioEmpleado As HorarioEmpleado = Nothing)

        Try
            'Calculo puntualidad
            If Not entHorarioAdicEmpleado Is Nothing Then
                Dim DifAux As Integer = 999
                If Not F_IsNullValue(entHorarioAdicEmpleado.HORAENTRADA) Then
                    Dim DifAux2 As Integer = DifHoraria(ListEventosFichada, FechaProceso, entHorarioAdicEmpleado.HORAENTRADA)
                End If
                If Not F_IsNullValue(entHorarioAdicEmpleado.HORAENTRADA1) Then
                    Dim DifAux2 As Integer = DifHoraria(ListEventosFichada, FechaProceso, entHorarioAdicEmpleado.HORAENTRADA1)
                End If
                If Not F_IsNullValue(entHorarioAdicEmpleado.HORAENTRADA2) Then
                    Dim DifAux2 As Integer = DifHoraria(ListEventosFichada, FechaProceso, entHorarioAdicEmpleado.HORAENTRADA2)
                End If
            ElseIf Not entHorarioEmpleado Is Nothing Then
                Dim DifAux As Integer = 999
                If Not F_IsNullValue(entHorarioEmpleado.HORAENTRADA) Then
                    Dim DifAux2 As Integer = DifHoraria(ListEventosFichada, FechaProceso, entHorarioEmpleado.HORAENTRADA)
                End If
                If Not F_IsNullValue(entHorarioEmpleado.HORAENTRADA1) Then
                    Dim DifAux2 As Integer = DifHoraria(ListEventosFichada, FechaProceso, entHorarioEmpleado.HORAENTRADA)
                End If
                If Not F_IsNullValue(entHorarioEmpleado.HORAENTRADA2) Then
                    Dim DifAux2 As Integer = DifHoraria(ListEventosFichada, FechaProceso, entHorarioEmpleado.HORAENTRADA)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function DifHoraria(ByRef ListEventosFichada As List(Of EventoFichada), ByVal FechaProceso As Date, ByVal HoraEntrada As Integer) As Integer
        Try
            Dim DifAux As Integer = 999
            If Not F_IsNullValue(HoraEntrada) Then
                DifAux = 999
                Dim entEventoFichadaAux As EventoFichada = Nothing
                For Each eEventoFichada As EventoFichada In ListEventosFichada.Where(Function(f) f.FECHAENTRADA >= FechaProceso AndAlso f.FECHAENTRADA < FechaProceso.AddDays(1) AndAlso f.INCONSISTENCIA = False).ToList
                    If eEventoFichada.MINUTOSTARDE = 0 Then
                        Dim Horas As Integer = (Math.Truncate(HoraEntrada / 100))
                        Dim Minutos As Integer = HoraEntrada - (Horas * 100)
                        Dim FechaAux As Date = FechaProceso.AddHours(Horas).AddMinutes(Minutos)
                        If DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA) < DifAux Then
                            DifAux = DateDiff(DateInterval.Minute, FechaAux, eEventoFichada.FECHAENTRADA)
                            entEventoFichadaAux = eEventoFichada
                        End If
                    End If
                Next
                If Not entEventoFichadaAux Is Nothing Then entEventoFichadaAux.MINUTOSTARDE = DifAux
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function GuardarEventos(ByRef ListEventosFichadas As List(Of EventoFichada)) As Boolean
        Dim objFichadaLectura As New FichadaLecturaComponent
        Dim entFichadaLectura As FichadaLectura
        'Dim Odal As New EventoFichadaData
        Dim mflgOkSave As Boolean = True

        Try
            'Odal.BeginTransaction()
            For Each entFichadaEvento As EventoFichada In ListEventosFichadas
                If entFichadaEvento.MINUTOSTARDE < 0 Then entFichadaEvento.MINUTOSTARDE = 0
                If Not Save(entFichadaEvento) Then
                    mflgOkSave = False
                    Exit For
                End If
                If Not F_IsNullValue(entFichadaEvento.IDFICHADAENTRADA) Then
                    entFichadaLectura = objFichadaLectura.GetEntById(entFichadaEvento.IDFICHADAENTRADA)
                    entFichadaLectura.BeginUpdate()
                    entFichadaLectura.FECHAPROCESO = F_CurrentTimeStamp()
                    entFichadaLectura.OBSERVACIONESPROCESO = "Pre Procesada"
                    If Not objFichadaLectura.Save(entFichadaLectura, False) Then
                        mflgOkSave = False
                        Exit For
                    End If
                End If
                If Not F_IsNullValue(entFichadaEvento.IDFICHADASALIDA) Then
                    entFichadaLectura = objFichadaLectura.GetEntById(entFichadaEvento.IDFICHADASALIDA)
                    entFichadaLectura.BeginUpdate()
                    entFichadaLectura.FECHAPROCESO = F_CurrentTimeStamp()
                    entFichadaLectura.OBSERVACIONESPROCESO = "Pre Procesada"
                    If Not objFichadaLectura.Save(entFichadaLectura, False) Then
                        mflgOkSave = False
                        Exit For
                    End If
                End If
            Next

            'If mflgOkSave Then
            '    Odal.CommitTransaction()
            'Else
            '    Odal.CancelTransaction()
            'End If


        Catch ex As Exception
            'Odal.CancelTransaction()
        Finally
            'Odal.Desconectar()
        End Try
        Return mflgOkSave
    End Function


End Class
