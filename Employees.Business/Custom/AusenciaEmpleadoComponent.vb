Imports Employees.Entities
Imports Employees.Data
Imports Turnos.GlobalFunctions.Data
Imports System.Collections.Generic
Partial Public Class AusenciaEmpleadoComponent
    Public Function SaveConTraza(ByRef entity As AusenciaEmpleado, ByVal idUsuarioProcesa As String, Optional ByVal sp As Boolean = True, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Dim flgOkSave As Boolean = False
        Dim Odal As New AusenciaEmpleadoData
        Dim objAusenciaEmpleado As New AusenciaEmpleadoComponent()
        Dim objTrazaCambio As New TrazaCambioComponent()
        Dim entTrazaCambio As TrazaCambio
        Dim flgBeginTran As Boolean = False

        Try
            Dim flgNew As Boolean = (F_IsNullValue(entity.ID))

            Odal.BeginTransaction()
            flgBeginTran = True

            If Not Save(entity, sp) Then
                Throw New Exception("Error al guardar el Ausencia Empleado.")
            Else
                Dim entAusenciaEmpleado As AusenciaEmpleado = objAusenciaEmpleado.GetEntById(entity.ID)
                entTrazaCambio = New TrazaCambio
                entTrazaCambio.BeginUpdate()
                entTrazaCambio.IDUSUARIO = idUsuarioProcesa
                entTrazaCambio.IDAUXILIAR = entity.ID
                entTrazaCambio.TABLAAUXILIAR = "AusenciaEmpleado"
                entTrazaCambio.IDEMPLEADO = entity.IDEMPLEADO
                If flgNew Then
                    entTrazaCambio.OBSERVACIONES = "Alta de AusenciaEmpleado: " & Environment.NewLine
                Else
                    If F_IsNullValue(entity.IDUSUARIOANULA) Then
                        entTrazaCambio.OBSERVACIONES = "Modificación de AusenciaEmpleado" & Environment.NewLine
                    Else
                        entTrazaCambio.OBSERVACIONES = "Baja de AusenciaEmpleado" & Environment.NewLine
                        entTrazaCambio.IDUSUARIO = idUsuarioProcesa
                    End If
                End If

                entTrazaCambio.OBSERVACIONES &= "Id Empleado: " & entAusenciaEmpleado.IDEMPLEADO & ", " & entAusenciaEmpleado.IDEMPLEADO_Desc & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Desde: " & entAusenciaEmpleado.FECHADESDE & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Hasta: " & entity.FECHAHASTA & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "id Tipo Ausentismo: " & entity.IDTIPOAUSENCIA & ", " & entAusenciaEmpleado.IDTIPOAUSENCIA_Desc & Environment.NewLine
                If Not F_IsNullValue(entity.IDUSUARIOSOLICITA) Then
                    entTrazaCambio.OBSERVACIONES &= "Solicita: " & entity.IDUSUARIOSOLICITA & ", " & entAusenciaEmpleado.IDUSUARIOSOLICITA_Desc & Environment.NewLine
                End If
                If Not F_IsNullValue(entity.IDUSUARIOVALIDA) Then
                    entTrazaCambio.OBSERVACIONES &= "Valida: " & entity.IDUSUARIOVALIDA & ", " & entAusenciaEmpleado.IDUSUARIOVALIDA_Desc & Environment.NewLine
                End If
                If Not F_IsNullValue(entity.IDUSUARIOAPRUEBA) Then
                    entTrazaCambio.OBSERVACIONES &= "Aprueba: " & entity.IDUSUARIOAPRUEBA & ", " & entAusenciaEmpleado.IDUSUARIOAPRUEBA_Desc & Environment.NewLine
                End If
                If Not F_IsNullValue(entity.IDUSUARIOANULA) Then
                    entTrazaCambio.OBSERVACIONES &= "Anula: " & entity.IDUSUARIOANULA & ", " & entAusenciaEmpleado.IDUSUARIOANULA_Desc & Environment.NewLine
                End If
                If Not objTrazaCambio.Save(entTrazaCambio) Then
                    Throw New Exception("Error al guardar horario adicional del AusenciaEmpleado." & Environment.NewLine & "No se pudo guardar la traza del cambio")
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
End Class
