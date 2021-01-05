Imports Employees.Entities
Imports Turnos.GlobalFunctions
Imports System.Collections.Generic
Partial Public Class EmpleadoData
    Public Function EliminarCompleto(ByVal idEmpleado As Long, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Dim sql As String = "M_EMPLEADOELIMINARCOMPLETO"
        Dim oParams As IDataParameterCollection
        Dim par As IDataParameter
        Dim bOk As Boolean
        Try
            oParams = oCon.ObtenerParametros(sql)
            par = CType(oParams.Item("@IDEMPLEADO"), IDataParameter)
            par.Value = idEmpleado

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
                bOk = True
            Else
                If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
                    MyBase.Exception = oCon.Exception
                End If
                MyBase.ConError = True
                MyBase.Error = "No se pudo eliminar el empleado"
                bOk = False
                If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
            End If
        Catch ex As Exception
            MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo eliminar el empleado"
            MyBase.InternalError = ex.Message
            bOk = False
            If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return bOk
    End Function


End Class
