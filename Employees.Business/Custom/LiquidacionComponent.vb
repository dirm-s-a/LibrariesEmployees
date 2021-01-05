Imports Employees.Data
Imports System.Collections.Generic
Imports Employees.Entities
Imports Turnos.GlobalFunctions.Data


Public Class LiquidacionComponent
    Public Event PercentDone(ByVal Percent As Single, ByVal Observacion As String, ByVal Contador As Long, ByRef Cancel As Boolean)
    Public Sub LiquidarPeriodo(ByVal ListEmpleados As List(Of Empleado), ByVal FechaDesde As Date, ByVal FechaHasta As Date)
        Dim oDalEventoFichadaComponent As New EventoFichadaData
        Dim objEventoFichada As New EventoFichadaComponent
        Dim oDalEmpleado As New EmpleadoData
        Dim oDalConvenios As New ConvenioData
        'Dim oDalHorarioAdicEmpleado As New HorarioAdicEmpleadoData
        'Dim oDalHorarioEmpleado As New HorarioEmpleadoData
        Dim oDalFichadaLectura As New FichadaLecturaData
        Dim flgCancelado As Boolean = False
        Dim objAusenciaEmpleado As New AusenciaEmpleadoComponent
        Dim objTipoAusencia As New TipoAusenciaComponent

        Dim ListLiquidaciones As New List(Of Liquidacion)
        Dim ListAusenciaEmpleado As List(Of AusenciaEmpleado)
        Dim entEmpleado As Empleado = Nothing
        Dim flgPierdePresentismo As Boolean
        'Dim flgPierdePresentismoDia As Boolean
        'Dim flgPierdeMedioPresentismoDia As Boolean

        Try
            Dim ListTipoAusencia As List(Of TipoAusencia) = objTipoAusencia.GetALL()
            Dim ListEventosFichadas As List(Of EventoFichada) = oDalEventoFichadaComponent.GetTodoEntreFechasEntrada(FechaDesde, FechaHasta.AddDays(1))
            ListEventosFichadas = ListEventosFichadas.Where(Function(f) f.IDLIQUIDACION = -1).ToList()
            Dim Listconvenios As List(Of Convenio) = oDalConvenios.GetALL
            Dim ListfichadasLectura As List(Of FichadaLectura) = oDalFichadaLectura.GetTodoEntreFechas(FechaDesde, FechaHasta.AddDays(1))
            Dim ContadorEmpleados As Integer = 0

            For Each entEmpleado In ListEmpleados
                If ListfichadasLectura.Where(Function(f) f.IDEMPLEADO.Equals(entEmpleado.ID)).Count > 0 Then
                    'Tiene fichadas del mes
                    ListAusenciaEmpleado = objAusenciaEmpleado.GetByEmpleado(entEmpleado.ID)
                    flgPierdePresentismo = False
                    Dim entLiquidacion As New Liquidacion
                    entLiquidacion.BeginUpdate()
                    entLiquidacion.FECHADESDE = FechaDesde
                    entLiquidacion.FECHAHASTA = FechaHasta
                    entLiquidacion.IDEMPLEADO = entEmpleado.ID
                    entLiquidacion.PRESENTISMO = True 'Se pasa a false ante un evento que quite este estado
                    entLiquidacion.MINUTOSTARDE = 0
                    entLiquidacion.AUSENCIASCONPRESENTISMO = 0
                    entLiquidacion.AUSENCIASINJUSTIFICADAS = 0
                    entLiquidacion.AUSENCIASJUSTIFICADAS = 0
                    entLiquidacion.DIASMEDIOPRESENTISMO = 0
                    entLiquidacion.DIASSINPRESENTISMO = 0
                    entLiquidacion.INCONSISTENCIAS = 0
                    entLiquidacion.DIASTRABAJADOS = 0
                    entLiquidacion.IDCONVENIO = entEmpleado.IDCONVENIO

                    'Dim listHorarioAdicEmpleado As List(Of HorarioAdicEmpleado) = oDalHorarioAdicEmpleado.GetByEmpleado(entEmpleado.ID).Where(Function(f) f.ACTIVO = True AndAlso f.AUTORIZADO = True).ToList()
                    'Dim ListHorarioEmpleado As List(Of HorarioEmpleado) = oDalHorarioEmpleado.GetByEmpleado(entEmpleado.ID).Where(Function(f) f.ACTIVO = True).ToList()
                    Dim entConvenio As Convenio = Listconvenios.Where(Function(f) f.ID.Equals(entEmpleado.IDCONVENIO)).ToList(0)
                    Dim ListEventosEmpleado As List(Of EventoFichada) = ListEventosFichadas.Where(Function(f) f.IDEMPLEADO.Equals(entEmpleado.ID)).ToList
                    Dim FechaProceso As Date = FechaDesde

                    ContadorEmpleados += 1
                    RaiseEvent PercentDone(ContadorEmpleados * 100 / ListEmpleados.Count, entEmpleado.NOMBRE, ContadorEmpleados, flgCancelado)
                    If flgCancelado Then Exit Sub

                    Do Until FechaProceso > FechaHasta
                        'flgPierdeMedioPresentismoDia = False
                        'flgPierdePresentismoDia = False
                        Dim ListEventosEmpleadoDia As List(Of EventoFichada) = ListEventosEmpleado.Where(Function(f) f.FECHAENTRADA >= FechaProceso AndAlso f.FECHAENTRADA < FechaProceso.AddDays(1)).ToList
                        Dim MinTrabajadosDia As Integer = 0
                        Dim idHorarioEmpleado As Long = -1
                        Dim idHorarioAdicEmpleado As Long = -1

                        If ListEventosEmpleadoDia.Where(Function(f) f.AUSENTE = False).Count > 0 Then entLiquidacion.DIASTRABAJADOS += 1
                        For Each entEventoFichada As EventoFichada In ListEventosEmpleadoDia
                            If entEventoFichada.INCONSISTENCIA Then
                                If Not entConvenio.SINCONTROLES Then
                                    entLiquidacion.PRESENTISMO = False
                                    flgPierdePresentismo = True
                                    'flgPierdePresentismoDia = True
                                    entLiquidacion.INCONSISTENCIAS += 1
                                End If
                            ElseIf entEventoFichada.AUSENTE Then
                                'Falta mejorar el análisis para ver si son justificadas y con o sin pérdida del presentismo
                                If Not entConvenio.SINCONTROLES Then
                                    Dim entTipoAusencia As TipoAusencia = Nothing
                                    Dim entAusenciaEmpleado As AusenciaEmpleado = Nothing 'Traigo Ausencias aprobadas del empleado para el día en proceso
                                    If ListAusenciaEmpleado.Exists(Function(f) f.FECHADESDE <= FechaProceso AndAlso f.FECHAHASTA >= FechaProceso) Then
                                        entAusenciaEmpleado = ListAusenciaEmpleado.Where(Function(f) f.FECHADESDE <= FechaProceso AndAlso f.FECHAHASTA >= FechaProceso).ToList(0)
                                    End If
                                    If Not entAusenciaEmpleado Is Nothing Then entTipoAusencia = ListTipoAusencia.Where(Function(f) f.ID.Equals(entAusenciaEmpleado.IDTIPOAUSENCIA)).ToList(0)

                                    If entAusenciaEmpleado Is Nothing OrElse entTipoAusencia.PIERDEPRESENTISMO Then
                                        entLiquidacion.PRESENTISMO = False
                                        flgPierdePresentismo = True
                                        'flgPierdePresentismoDia = True
                                        entLiquidacion.AUSENCIASINJUSTIFICADAS += 1
                                    Else
                                        entLiquidacion.AUSENCIASJUSTIFICADAS += 1
                                    End If
                                End If
                            Else
                                idHorarioAdicEmpleado = entEventoFichada.IDHORARIOADICEMPLEADO
                                idHorarioEmpleado = entEventoFichada.IDHORARIOEMPLEADO
                                entLiquidacion.MINUTOSTARDE += entEventoFichada.MINUTOSTARDE
                                MinTrabajadosDia += entEventoFichada.MINUTOSTRABAJADOS
                            End If
                        Next

                        If Not entConvenio.SINCONTROLES AndAlso entConvenio.HORARIOFLEXIBLE AndAlso ListEventosEmpleadoDia.Count > 0 Then
                            Select Case Weekday(FechaProceso, FirstDayOfWeek.Monday)
                                Case 1, 2, 3, 4, 5
                                    If MinTrabajadosDia < entConvenio.MINUTOSLUNVIER Then
                                        entLiquidacion.PRESENTISMO = False
                                        flgPierdePresentismo = True
                                    End If
                                Case 6
                                    If MinTrabajadosDia < entConvenio.MINUTOSSABADO Then
                                        entLiquidacion.PRESENTISMO = False
                                        flgPierdePresentismo = True
                                    End If
                                Case 7
                                    If MinTrabajadosDia < entConvenio.MINUTOSDOMINGO Then
                                        entLiquidacion.PRESENTISMO = False
                                        flgPierdePresentismo = True
                                    End If
                            End Select
                        End If

                        FechaProceso = FechaProceso.AddDays(1)
                    Loop

                    If Not entConvenio.SINCONTROLES AndAlso entLiquidacion.PRESENTISMO Then
                        If entLiquidacion.MINUTOSTARDE > entConvenio.MINUTOSTOPE Then
                            entLiquidacion.PRESENTISMO = False
                        ElseIf entLiquidacion.MINUTOSTARDE > entConvenio.MINUTOSGRACIA Then
                            entLiquidacion.MEDIOPRESENTISMO = True
                            entLiquidacion.PRESENTISMO = False
                        End If
                    End If

                    If Save(entLiquidacion) Then
                        For Each entEventoFichada As EventoFichada In ListEventosEmpleado
                            entEventoFichada.BeginUpdate()
                            entEventoFichada.IDLIQUIDACION = entLiquidacion.ID
                            objEventoFichada.Save(entEventoFichada, False, True)
                        Next
                    End If

                End If
            Next
        Catch ex As Exception
            If entEmpleado Is Nothing Then
                Throw New Exception("Error al procesar evento fichada: " & ex.Message, ex.InnerException)
            Else
                Throw New Exception("Error al procesar empleado: " & entEmpleado.NOMBRE & Environment.NewLine & "Documento: " & entEmpleado.NRODOCUMENTO & Environment.NewLine & "Error: " & ex.Message, ex.InnerException)
            End If

        End Try
    End Sub
End Class
