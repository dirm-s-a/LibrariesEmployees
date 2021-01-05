Imports Employees.Entities
Imports Employees.Data
Imports Turnos.GlobalFunctions.Data
Imports System.Collections.Generic
Public Class TipoAusenciaComponent
    Public Function SaveConTraza(ByRef entity As TipoAusencia, Optional ByVal sp As Boolean = True, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Dim flgOkSave As Boolean = False
        Dim Odal As New TipoAusenciaData
        Dim objConvenio As New TipoAusenciaComponent()
        Dim objTrazaCambio As New TrazaCambioComponent()
        Dim entTrazaCambio As TrazaCambio
        Dim flgBeginTran As Boolean = False

        Try
            Dim flgNew As Boolean = (F_IsNullValue(entity.ID))

            Odal.BeginTransaction()
            flgBeginTran = True

            'Call ValidarDatos(entity)
            If Not Save(entity) Then
                Throw New Exception("Error al guardar el el Tipo de ausencia.")
            Else
                Dim entConvenio As TipoAusencia = objConvenio.GetEntById(entity.ID)
                entTrazaCambio = New TrazaCambio
                entTrazaCambio.BeginUpdate()
                entTrazaCambio.IDUSUARIO = entity.IDUSUARIOMODIFICACION
                entTrazaCambio.IDAUXILIAR = entity.ID
                entTrazaCambio.TABLAAUXILIAR = "TipoAusencia"
                If flgNew Then
                    entTrazaCambio.OBSERVACIONES = "Alta de Tipo de ausencia: " & Environment.NewLine
                Else
                    If entity.ACTIVO = True Then
                        entTrazaCambio.OBSERVACIONES = "Modificación de Tipo de ausencia" & Environment.NewLine
                    Else
                        entTrazaCambio.OBSERVACIONES = "Baja de Tipo de ausencia" & Environment.NewLine
                    End If
                End If

                entTrazaCambio.OBSERVACIONES &= "Convenio: " & entConvenio.DESCRIPCION & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Pierde Presentismo: " & entConvenio.PIERDEPRESENTISMO & Environment.NewLine
                entTrazaCambio.OBSERVACIONES &= "Justificada: " & entConvenio.JUSTIFICADA & Environment.NewLine
                If Not objTrazaCambio.Save(entTrazaCambio) Then
                    Throw New Exception("Error al guardar Tipo de Ausencia." & Environment.NewLine & "No se pudo guardar la traza del cambio")
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
