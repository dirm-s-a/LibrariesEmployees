Imports Employees.Entities
Imports Employees.Data
Imports Turnos.GlobalFunctions.Data
Imports System.Collections.Generic
Public Class ConvenioComponent
    Public Function SaveConTraza(ByRef entity As Convenio, Optional ByVal sp As Boolean = True, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Dim flgOkSave As Boolean = False
        Dim Odal As New ConvenioData
        Dim objConvenio As New ConvenioComponent()
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
                Throw New Exception("Error al guardar el convenio.")
            Else
                Dim entConvenio As Convenio = objConvenio.GetEntById(entity.ID)
                entTrazaCambio = New TrazaCambio
                entTrazaCambio.BeginUpdate()
                entTrazaCambio.IDUSUARIO = entity.IDUSUARIOMODIFICACION
                entTrazaCambio.IDAUXILIAR = entity.ID
                entTrazaCambio.TABLAAUXILIAR = "Convenio"
                If flgNew Then
                    entTrazaCambio.OBSERVACIONES = "Alta de Convenio: " & Environment.NewLine
                Else
                    If entity.ACTIVO = True Then
                        entTrazaCambio.OBSERVACIONES = "Modificación de Convenio" & Environment.NewLine
                    Else
                        entTrazaCambio.OBSERVACIONES = "Baja de Convenio" & Environment.NewLine
                        entTrazaCambio.IDUSUARIO = entity.IDUSUARIOMODIFICACION
                    End If
                End If

                entTrazaCambio.OBSERVACIONES &= "Convenio: " & entConvenio.DESCRIPCION & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Ausentismo: " & entConvenio.AUSENTISMO & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Horario Flexible: " & entity.HORARIOFLEXIBLE & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Minutos de gracia: " & entity.MINUTOSGRACIA & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Sin Controles: " & entity.SINCONTROLES & Environment.NewLine
                If Not objTrazaCambio.Save(entTrazaCambio) Then
                    Throw New Exception("Error al guardar horario adicional del Convenio." & Environment.NewLine & "No se pudo guardar la traza del cambio")
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
