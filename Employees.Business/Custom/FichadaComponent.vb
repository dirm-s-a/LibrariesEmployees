Imports Employees.Data
Imports System.Collections.Generic
Imports Employees.Entities
Imports Turnos.GlobalFunctions.Data

Partial Public Class FichadaComponent

    Public Function SaveCol(list As List(Of Fichada), Optional ByRef errMsj As String = "") As Boolean
        Dim oDAL As New FichadaData
        Dim bResul As Boolean = True
        Dim eFichada As Fichada
        Dim eFichadaAux As Fichada
        Dim ListFichada As List(Of Fichada)
        Dim objFichada As New FichadaComponent
        Dim objEmpleado As New EmpleadoComponent
        Dim eEmpleado As Empleado
        Dim ListHorarioEmpleado As List(Of HorarioEmpleado)
        Dim eHorarioEmpleado As HorarioEmpleado
        Dim objHorarioEmpleado As New HorarioEmpleadoComponent()

        Dim ListHorarioEmpleadoAdic As List(Of HorarioAdicEmpleado)
        Dim eHorarioEmpleadoAdic As HorarioAdicEmpleado
        Dim objHorarioEmpleadoAdic As New HorarioAdicEmpleadoComponent()

        Dim ListAusencia As List(Of AusenciaEmpleado)
        Dim eAusencia As AusenciaEmpleado
        Dim objAusencia As New AusenciaEmpleadoComponent()
        Dim dia As Integer
        Dim flgDiaAnterior As Boolean
        Dim Fecha As Date
        Dim flgIncongruencia As Boolean = False
        Dim flgHorarioEncontrado As Boolean = False

        Try
            oDAL.BeginTransaction()

            For Each eFichada In list
                flgDiaAnterior = False
                flgIncongruencia = False
                flgHorarioEncontrado = False

                If eFichada.FECHASALIDA <> Date.MinValue And eFichada.FECHAENTRADA = Date.MinValue Then
                    'COMO ES SALIDA, TENGO QUE BUSCAR A QUE ENTRADA SE CORRESPONDE
                    ' If eFichada.IDEMPLEADO = 48 Then Stop
                    Fecha = eFichada.FECHASALIDA

                    'BUSCO SI TIENE AUSENCIAS PARA ESE DIA
                    ListAusencia = objAusencia.GetByEmpleado(eFichada.IDEMPLEADO)
                    ListAusencia = ListAusencia.Where(Function(f) f.IDUSUARIOANULA = "" And f.IDUSUARIOAPRUEBA <> "" And f.IDUSUARIOAPRUEBA <> "").ToList

                    For Each eAusencia In ListAusencia
                        If Fecha >= eAusencia.FECHADESDE And Fecha <= eAusencia.FECHAHASTA Then
                            flgIncongruencia = True
                            Exit For
                        End If
                    Next

                    'BUSCO HORARIO ADICIONAL DEL EMPLEADO
                    ListHorarioEmpleadoAdic = objHorarioEmpleadoAdic.GetByEmpleado(eFichada.IDEMPLEADO)
                    If ListHorarioEmpleadoAdic.Count > 0 Then
                        For Each eHorarioEmpleadoAdic In ListHorarioEmpleadoAdic
                            If Fecha >= eHorarioEmpleadoAdic.FECHADESDE And Fecha <= eHorarioEmpleadoAdic.FECHADESDE Then
                                If eHorarioEmpleadoAdic.HORASALIDA < eHorarioEmpleadoAdic.HORAENTRADA Then flgDiaAnterior = True
                                flgHorarioEncontrado = True
                                Exit For
                            End If
                        Next

                        If flgHorarioEncontrado Then
                            If flgDiaAnterior Then
                                ListFichada = objFichada.GetPorEmpleadoFechaEntrada(DateAdd(DateInterval.Day, -1, Fecha), eFichada.IDEMPLEADO)
                            Else
                                ListFichada = objFichada.GetPorEmpleadoFechaEntrada(Fecha, eFichada.IDEMPLEADO)
                            End If

                            ListFichada = ListFichada.Where(Function(f) f.FECHASALIDA = Date.MinValue).ToList
                            If ListFichada.Count > 0 Then
                                eFichadaAux = ListFichada(0)
                                eFichadaAux.BeginUpdate()
                                eFichadaAux.FECHASALIDA = eFichada.FECHASALIDA
                                eFichadaAux.SALIDA = eFichada.SALIDA
                                If flgIncongruencia Then eFichadaAux.INCONGRUENCIAS = True
                                eFichadaAux.IDHORARIOADICEMPLEADO = eHorarioEmpleadoAdic.ID
                                eFichadaAux.HORASTRABAJADAS = restarHoraMilitar(eFichadaAux.SALIDA, eFichadaAux.ENTRADA)
                                'Calculo minutos tarde
                                calculaMinutosTarde(eFichadaAux,, eHorarioEmpleadoAdic)

                                If Not oDAL.UpdateSP(eFichadaAux) Then
                                    bResul = False
                                    Exit For
                                End If
                            Else
                                'SI NO SE LE CORRESPONDE UNA ENTRADA LO INSERTO IGUAL COMO INCONGRUENCIA
                                eFichada.BeginUpdate()
                                eFichada.INCONGRUENCIAS = True
                                eFichada.IDHORARIOADICEMPLEADO = eHorarioEmpleadoAdic.ID
                                If Not oDAL.InsertSP(eFichada) Then
                                    errMsj = "Error al guardar uno de los registros en la base de datos"
                                    bResul = False
                                    Exit For
                                End If
                            End If
                        Else
                            'BUSCO EL HORARIO DEL EMPLEADO
                            ListHorarioEmpleado = objHorarioEmpleado.GetByEmpleado(eFichada.IDEMPLEADO)

                            If ListHorarioEmpleado.Count > 0 Then
                                dia = Weekday(Fecha, FirstDayOfWeek.Monday)

                                'For Each eHorarioEmpleado In ListHorarioEmpleado
                                '    If Fecha >= eHorarioEmpleado.FECHADESDE And Fecha <= eHorarioEmpleado.FECHAHASTA Then
                                '        If dia >= eHorarioEmpleado.DIASEMANAENTRADA And dia <= eHorarioEmpleado.DIASEMANASALIDA Then
                                '            If eHorarioEmpleado.HORASALIDA < eHorarioEmpleado.HORAENTRADA Then flgDiaAnterior = True
                                '            flgHorarioEncontrado = True
                                '            Exit For
                                '        End If
                                '    End If
                                'Next

                                If flgHorarioEncontrado Then
                                    If flgDiaAnterior Then
                                        ListFichada = objFichada.GetPorEmpleadoFechaEntrada(DateAdd(DateInterval.Day, -1, Fecha), eFichada.IDEMPLEADO)
                                    Else
                                        ListFichada = objFichada.GetPorEmpleadoFechaEntrada(Fecha, eFichada.IDEMPLEADO)
                                    End If

                                    ListFichada = ListFichada.Where(Function(f) f.FECHASALIDA = Date.MinValue).ToList
                                    If ListFichada.Count > 0 Then
                                        eFichadaAux = ListFichada(0)
                                        eFichadaAux.BeginUpdate()
                                        eFichadaAux.FECHASALIDA = eFichada.FECHASALIDA
                                        eFichadaAux.SALIDA = eFichada.SALIDA
                                        If flgIncongruencia Then eFichadaAux.INCONGRUENCIAS = True
                                        eFichadaAux.IDHORARIOEMPLEADO = eHorarioEmpleado.ID
                                        eFichadaAux.HORASTRABAJADAS = restarHoraMilitar(eFichadaAux.SALIDA, eFichadaAux.ENTRADA)

                                        'Calculo minutos tarde
                                        calculaMinutosTarde(eFichadaAux, eHorarioEmpleado)

                                        If Not oDAL.UpdateSP(eFichadaAux) Then
                                            bResul = False
                                            Exit For
                                        End If
                                    Else
                                        'SI NO SE LE CORRESPONDE UNA ENTRADA LO INSERTO IGUAL COMO INCONGRUENCIA
                                        eFichada.BeginUpdate()
                                        eFichada.INCONGRUENCIAS = True
                                        eFichada.IDHORARIOEMPLEADO = eHorarioEmpleado.ID
                                        If Not oDAL.InsertSP(eFichada) Then
                                            errMsj = "Error al guardar uno de los registros en la base de datos"
                                            bResul = False
                                            Exit For
                                        End If
                                    End If
                                End If
                            Else
                                eEmpleado = objEmpleado.GetEntById(eFichada.IDEMPLEADO)
                                errMsj = "El empleado " & eEmpleado.NOMBRE & " no tiene cargado un horario"
                                bResul = False
                                Exit For
                            End If
                        End If
                    Else
                        'BUSCO EL HORARIO DEL EMPLEADO
                        ListHorarioEmpleado = objHorarioEmpleado.GetByEmpleado(eFichada.IDEMPLEADO)

                        If ListHorarioEmpleado.Count > 0 Then
                            dia = Weekday(Fecha, FirstDayOfWeek.Monday)

                            'For Each eHorarioEmpleado In ListHorarioEmpleado
                            '    If Fecha >= eHorarioEmpleado.FECHADESDE And Fecha <= eHorarioEmpleado.FECHAHASTA Then
                            '        If dia >= eHorarioEmpleado.DIASEMANAENTRADA And dia <= eHorarioEmpleado.DIASEMANASALIDA Then
                            '            If eHorarioEmpleado.HORASALIDA < eHorarioEmpleado.HORAENTRADA Then flgDiaAnterior = True
                            '            flgHorarioEncontrado = True
                            '            Exit For
                            '        End If
                            '    End If
                            'Next

                            If flgHorarioEncontrado Then
                                If flgDiaAnterior Then
                                    ListFichada = objFichada.GetPorEmpleadoFechaEntrada(DateAdd(DateInterval.Day, -1, Fecha), eFichada.IDEMPLEADO)
                                Else
                                    ListFichada = objFichada.GetPorEmpleadoFechaEntrada(Fecha, eFichada.IDEMPLEADO)
                                End If

                                ListFichada = ListFichada.Where(Function(f) f.FECHASALIDA = Date.MinValue).ToList
                                If ListFichada.Count > 0 Then
                                    eFichadaAux = ListFichada(0)
                                    eFichadaAux.BeginUpdate()
                                    eFichadaAux.FECHASALIDA = eFichada.FECHASALIDA
                                    eFichadaAux.SALIDA = eFichada.SALIDA
                                    If flgIncongruencia Then eFichadaAux.INCONGRUENCIAS = True
                                    eFichadaAux.IDHORARIOEMPLEADO = eHorarioEmpleado.ID
                                    eFichadaAux.HORASTRABAJADAS = restarHoraMilitar(eFichadaAux.SALIDA, eFichadaAux.ENTRADA)

                                    'Calculo minutos tarde
                                    calculaMinutosTarde(eFichadaAux, eHorarioEmpleado)

                                    If Not oDAL.UpdateSP(eFichadaAux) Then
                                        bResul = False
                                        Exit For
                                    End If
                                Else
                                    'SI NO SE LE CORRESPONDE UNA ENTRADA LO INSERTO IGUAL COMO INCONGRUENCIA
                                    eFichada.BeginUpdate()
                                    eFichada.INCONGRUENCIAS = True
                                    eFichada.IDHORARIOEMPLEADO = eHorarioEmpleado.ID
                                    If Not oDAL.InsertSP(eFichada) Then
                                        errMsj = "Error al guardar uno de los registros en la base de datos"
                                        bResul = False
                                        Exit For
                                    End If
                                End If
                            End If
                        End If
                    End If
                ElseIf eFichada.FECHASALIDA = Date.MinValue And eFichada.FECHAENTRADA <> Date.MinValue Then
                    'ENTRADA

                    Fecha = eFichada.FECHAENTRADA

                    'BUSCO SI TIENE AUSENCIAS PARA ESE DIA
                    ListAusencia = objAusencia.GetByEmpleado(eFichada.IDEMPLEADO)
                    ListAusencia = ListAusencia.Where(Function(f) f.IDUSUARIOANULA = "" And f.IDUSUARIOAPRUEBA <> "" And f.IDUSUARIOAPRUEBA <> "").ToList
                    For Each eAusencia In ListAusencia
                        If Fecha >= eAusencia.FECHADESDE And Fecha <= eAusencia.FECHAHASTA Then
                            eFichada.BeginUpdate()
                            eFichada.INCONGRUENCIAS = True
                            Exit For
                        End If
                    Next

                    If Not oDAL.InsertSP(eFichada) Then
                        errMsj = "Error al guardar uno de los registros en la base de datos"
                        bResul = False
                        Exit For
                    End If
                Else
                    errMsj = "Hay un error en las fechas de los registros"
                    bResul = False
                    Exit For
                End If
            Next

            If bResul Then
                oDAL.CommitTransaction()
            Else
                oDAL.CancelTransaction()
            End If

        Catch ex As Exception
            errMsj = ex.Message
            bResul = False
            oDAL.CancelTransaction()
        End Try

        Return bResul
    End Function

    Private Sub calculaHorasTrabajadas(ByRef entFichada As Fichada, Optional ByVal entHorario As HorarioEmpleado = Nothing, Optional ByVal entHorarioAdic As HorarioAdicEmpleado = Nothing)
        Try
            entFichada.BeginUpdate()
            If entHorarioAdic Is Nothing Then
                If Not entHorario Is Nothing Then

                End If
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub calculaMinutosTarde(ByRef entFichada As Fichada, Optional ByVal entHorario As HorarioEmpleado = Nothing, Optional ByVal entHorarioAdic As HorarioAdicEmpleado = Nothing)
        Try
            entFichada.BeginUpdate()
            If entHorarioAdic Is Nothing Then
                If Not entHorario Is Nothing Then
                    Call comprobarDiaHorario(entFichada, entHorario)
                End If
            Else
                Call comprobarDiaHorarioAdic(entFichada, entHorarioAdic)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub comprobarDiaHorario(ByRef entFichada As Fichada, ByRef entHorarioEmpleadoAux As HorarioEmpleado)
        Try
            'If entFichada.FECHAENTRADA.DayOfWeek >= entHorarioEmpleadoAux.DIASEMANAENTRADA And entFichada.FECHAENTRADA.DayOfWeek <= entHorarioEmpleadoAux.DIASEMANASALIDA And entFichada.FECHAENTRADA >= entHorarioEmpleadoAux.FECHADESDE And entFichada.FECHASALIDA < entHorarioEmpleadoAux.FECHAHASTA Then
            '    'Tomo el primer horario de entrada
            '    'Hago comparación para que en comidas, salidas de trámites, etc.. No me tome ningún horario
            '    If restarHoraMilitar(entFichada.ENTRADA, entHorarioEmpleadoAux.HORAENTRADA) < 100 Then
            '        If entFichada.ENTRADA > entHorarioEmpleadoAux.HORAENTRADA And entFichada.ENTRADA <> entFichada.SALIDA Then
            '            entFichada.MINUTOSTARDE = restarHoraMilitar(entFichada.ENTRADA, entHorarioEmpleadoAux.HORAENTRADA)
            '        Else
            '            entFichada.MINUTOSTARDE = 0
            '        End If
            '    Else
            '        'En el caso de que tenga horario cortado pasa por acá
            '        If entHorarioEmpleadoAux.HORAENTRADA1 <> -1 Then
            '            'Hago comparación para que en comidas, salidas de trámites, etc.. No me tome ningún horario
            '            If restarHoraMilitar(entFichada.SALIDA, entHorarioEmpleadoAux.HORASALIDA1) < 100 And restarHoraMilitar(entFichada.ENTRADA, entHorarioEmpleadoAux.HORAENTRADA1) < 100 Then
            '                If entFichada.ENTRADA > entHorarioEmpleadoAux.HORAENTRADA1 And entFichada.ENTRADA <> entFichada.SALIDA Then
            '                    entFichada.MINUTOSTARDE = restarHoraMilitar(entFichada.ENTRADA, entHorarioEmpleadoAux.HORAENTRADA1)
            '                End If
            '            End If
            '        ElseIf (entFichada.SALIDA = -1) Then
            '            'Si no fichó salida calculo igual los minutos que llega tarde
            '            If restarHoraMilitar(entFichada.ENTRADA, entHorarioEmpleadoAux.HORAENTRADA) < 100 And entFichada.ENTRADA > entHorarioEmpleadoAux.HORAENTRADA Then
            '                entFichada.MINUTOSTARDE = restarHoraMilitar(entFichada.ENTRADA, entHorarioEmpleadoAux.HORAENTRADA)
            '            Else
            '                entFichada.MINUTOSTARDE = 0
            '            End If
            '        End If

            '        If entHorarioEmpleadoAux.HORAENTRADA2 <> -1 Then
            '            entFichada.MINUTOSTARDE = restarHoraMilitar(entFichada.ENTRADA, entHorarioEmpleadoAux.HORAENTRADA2)
            '        End If
            '    End If
            '    entFichada.IDHORARIOEMPLEADO = entHorarioEmpleadoAux.ID
            'End If
        Catch ex As Exception
            'mobjLoger.SaveTXT(ex.Message & "; Proceso: calculaMinutosTarde()")
        End Try
    End Sub

    Private Sub comprobarDiaHorarioAdic(ByRef entFichada As Fichada, ByRef entHorarioAdicEmpleadoAux As HorarioAdicEmpleado)
        Try
            If entFichada.FECHAENTRADA >= entHorarioAdicEmpleadoAux.FECHADESDE And entFichada.FECHASALIDA <= entHorarioAdicEmpleadoAux.FECHADESDE Then
                If restarHoraMilitar(entFichada.ENTRADA, entHorarioAdicEmpleadoAux.HORAENTRADA) > 0 Then
                    entFichada.MINUTOSTARDE = restarHoraMilitar(entFichada.ENTRADA, entHorarioAdicEmpleadoAux.HORAENTRADA)
                Else
                    entFichada.MINUTOSTARDE = 0
                End If
                entFichada.IDHORARIOADICEMPLEADO = entHorarioAdicEmpleadoAux.ID
            End If
        Catch ex As Exception
            'mobjLoger.SaveTXT(ex.Message & "; Proceso: calculaMinutosTarde()")
        End Try
    End Sub

    Private Function restarHoraMilitar(ByVal horaHasta As Long, ByVal horaDesde As Long) As Long
        Dim hH As String = Convert.ToString(horaHasta)
        Dim hD As String = Convert.ToString(horaDesde)
        Dim minHasta As String
        Dim minDesde As String
        'Dim horaFinal As Long
        Dim minutosFinal As Long
        Dim horaTotalFinal As String

        If hH.Length > 1 Then
            minHasta = hH.Substring(hH.Length - 2, 2)
        Else
            minHasta = "00"
        End If

        If hD.Length > 1 Then
            minDesde = hD.Substring(hD.Length - 2, 2)
        Else
            minDesde = hD
        End If

        If hH.Length > 3 Then
            hH = hH.Substring(0, 2)
        Else
            If hH.Length > 2 Then
                hH = hH.Substring(0, 1)
            Else
                hH = "00"
            End If
        End If

        If hD.Length > 3 Then
            hD = hD.Substring(0, 2)
        Else
            If hD.Length > 2 Then
                hD = hD.Substring(0, 1)
            Else
                hD = "00"
            End If
        End If

        'horaFinal = CLng(hH) - CLng(hD)
        'minutosFinal = CLng(minHasta) - CLng(minDesde)

        Dim hInicial As New TimeSpan(CLng(hD), CLng(minDesde), 0)
        Dim hFinal As New TimeSpan(CLng(hH), CLng(minHasta), 0)
        Dim dif As TimeSpan = hFinal.Subtract(hInicial)

        horaTotalFinal = dif.Hours.ToString
        minutosFinal = dif.Minutes.ToString
        'If minutosFinal < 0 Then
        '    minutosFinal += 60
        '    If horaFinal < 0 Then horaFinal = horaFinal * -1
        '    horaFinal -= 1
        'End If

        If minutosFinal.ToString.Length = 1 Then
            horaTotalFinal = Math.Abs(CLng(horaTotalFinal)) & "0" & Math.Abs(CLng(minutosFinal))
        Else
            horaTotalFinal = Math.Abs(CLng(horaTotalFinal)) & Math.Abs(CLng(minutosFinal))
        End If

        Return CLng(horaTotalFinal)

    End Function

    Private Function sumarHoraMilitar(ByVal horaHasta As Long, ByVal horaDesde As Long) As Long
        Dim hH As String = Convert.ToString(horaHasta)
        Dim hD As String = Convert.ToString(horaDesde)
        Dim minHasta As String
        Dim minDesde As String
        'Dim horaFinal As Long
        Dim minutosFinal As Long
        Dim horaTotalFinal As String
        Dim diasTotal As Long

        If hH.Length > 1 Then
            minHasta = hH.Substring(hH.Length - 2, 2)
        Else
            minHasta = "00"
        End If

        If hD.Length > 1 Then
            minDesde = hD.Substring(hD.Length - 2, 2)
        Else
            minDesde = hD
        End If

        If hH.Length > 3 Then
            hH = hH.Substring(0, hH.Length - 2)
        Else
            If hH.Length > 2 Then
                hH = hH.Substring(0, 1)
            Else
                hH = "00"
            End If
        End If

        If hD.Length > 3 Then
            hD = hD.Substring(0, 2)
        Else
            If hD.Length > 2 Then
                hD = hD.Substring(0, 1)
            Else
                hD = "00"
            End If
        End If

        'horaFinal = CLng(hH) - CLng(hD)
        'minutosFinal = CLng(minHasta) - CLng(minDesde)

        Dim hInicial As New TimeSpan(CLng(hD), CLng(minDesde), 0)
        Dim hFinal As New TimeSpan(CLng(hH), CLng(minHasta), 0)
        Dim dif As TimeSpan = hFinal.Add(hInicial)

        horaTotalFinal = dif.Hours.ToString
        minutosFinal = dif.Minutes.ToString
        diasTotal = dif.Days * 24
        'If minutosFinal < 0 Then
        '    minutosFinal += 60
        '    If horaFinal < 0 Then horaFinal = horaFinal * -1
        '    horaFinal -= 1
        'End If

        If minutosFinal.ToString.Length = 1 Then
            horaTotalFinal = Math.Abs(CLng(horaTotalFinal + diasTotal)) & "0" & Math.Abs(CLng(minutosFinal))
        Else
            horaTotalFinal = Math.Abs(CLng(horaTotalFinal + diasTotal)) & Math.Abs(CLng(minutosFinal))
        End If

        Return CLng(horaTotalFinal)

    End Function

    Public Function GetTodoEntreFechas(ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal ExcluyeInactivos As Boolean) As List(Of Fichada)
        Try
            Dim obj As New FichadaData
            Dim list As List(Of Fichada)

            list = obj.GetTodoEntreFechas(FECHADESDE, FECHAHASTA, ExcluyeInactivos)
            Return list
        Catch ex As Exception

        End Try

        Return New List(Of Fichada)
    End Function

    Public Function GetTodoEntreFechasGrupo(ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal ExcluyeInactivos As Boolean, ByVal idGrupo As Long) As List(Of Fichada)
        Try
            Dim obj As New FichadaData
            Dim list As List(Of Fichada)

            list = obj.GetTodoEntreFechasGrupo(FECHADESDE, FECHAHASTA, ExcluyeInactivos, idGrupo)
            Return list
        Catch ex As Exception

        End Try

        Return New List(Of Fichada)
    End Function

End Class
