Imports System.Collections.Generic
Imports Turnos.GlobalFunctions.Data
Imports Conexion
Imports Employees.Entities
Partial Public Class FichadaLecturaData
    Public Function LimpiarFichada(ByVal id As Long, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Dim sql As String = "M_FICHADALECTURALIMPIAR"
        Dim oParams As IDataParameterCollection
        Dim par As IDataParameter
        Dim bOk As Boolean
        Try
            oParams = oCon.ObtenerParametros(sql)
            par = CType(oParams.Item("@ID"), IDataParameter)
            par.Value = F_ValueToNull(id)

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
                bOk = True
            Else
                If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
                    MyBase.Exception = oCon.Exception
                End If
                MyBase.ConError = True
                MyBase.Error = "No se pudo insertar la FichadaLectura"
                bOk = False
                If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
            End If
        Catch ex As Exception
            MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo insertar la FichadaLectura"
            MyBase.InternalError = ex.Message
            bOk = False
            If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return bOk

    End Function
End Class
