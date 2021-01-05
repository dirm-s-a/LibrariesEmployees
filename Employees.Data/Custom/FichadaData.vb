Imports Employees.Entities
Imports Turnos.GlobalFunctions
Imports System.Collections.Generic

Partial Public Class FichadaData
    Inherits BaseData

    Public Function GetTodoEntreFechas(ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal ExcluyeInactivos As Boolean) As List(Of Fichada)
        Dim list As List(Of Fichada)
        Dim entity As Fichada

        Dim oDatos As DataTable
        Dim sql As String
        Try
            sql = "Select FICHADAS.ID, "
            sql &= "FICHADAS.IDEMPLEADO, "
            sql &= "FICHADAS.FECHAENTRADA, "
            sql &= "FICHADAS.ENTRADA, "
            sql &= "FICHADAS.FECHASALIDA, "
            sql &= "FICHADAS.SALIDA, "
            sql &= "FICHADAS.HORASTRABAJADAS, "
            sql &= "FICHADAS.MINUTOSTARDE, "
            sql &= "FICHADAS.INCONGRUENCIAS, "
            sql &= "FICHADAS.IDHORARIOEMPLEADO, "
            sql &= "FICHADAS.IDHORARIOADICEMPLEADO, "
            sql &= "FICHADAS.TIPO, "
            sql &= "FICHADAS.IDRELOJ, "
            sql &= "FICHADAS.BORRADO, "
            sql &= "FICHADAS.IDUSUARIOBORRADO, "
            sql &= "FICHADAS.FECHABORRADO, "
            sql &= "EMPLEADOS.NOMBRE As IDEMPLEADO_Desc, "
            sql &= "RELOJES.DESCRIPCION As IDRELOJ_Desc, "
            sql &= "USUARIOS.NOMBRE As IDUSUARIOBORRADO_Desc "
            sql &= "From FICHADAS "
            sql &= "INNER Join EMPLEADOS On FICHADAS.IDEMPLEADO = EMPLEADOS.ID "
            sql &= "Left OUTER JOIN RELOJES On FICHADAS.IDRELOJ = RELOJES.ID "
            sql &= "Left OUTER JOIN USUARIOS On FICHADAS.IDUSUARIOBORRADO = USUARIOS.ID "
            sql &= "Where "
            sql &= "FICHADAS.FECHAENTRADA >= '" & Format(FECHADESDE, "yyyy/MM/dd") & "' "
            sql &= "And FICHADAS.FECHAENTRADA <= '" & Format(FECHAHASTA, "yyyy/MM/dd") & "' "
            sql &= "And FICHADAS.BORRADO = '0' "
            If ExcluyeInactivos Then sql &= "And EMPLEADOS.INACTIVO = '0' "
            sql &= "UNION "
            sql &= "Select FICHADAS.ID, "
            sql &= "FICHADAS.IDEMPLEADO, "
            sql &= "FICHADAS.FECHAENTRADA, "
            sql &= "FICHADAS.ENTRADA, "
            sql &= "FICHADAS.FECHASALIDA, "
            sql &= "FICHADAS.SALIDA, "
            sql &= "FICHADAS.HORASTRABAJADAS, "
            sql &= "FICHADAS.MINUTOSTARDE, "
            sql &= "FICHADAS.INCONGRUENCIAS, "
            sql &= "FICHADAS.IDHORARIOEMPLEADO, "
            sql &= "FICHADAS.IDHORARIOADICEMPLEADO, "
            sql &= "FICHADAS.TIPO, "
            sql &= "FICHADAS.IDRELOJ, "
            sql &= "FICHADAS.BORRADO, "
            sql &= "FICHADAS.IDUSUARIOBORRADO, "
            sql &= "FICHADAS.FECHABORRADO, "
            sql &= "EMPLEADOS.NOMBRE As IDEMPLEADO_Desc, "
            sql &= "RELOJES.DESCRIPCION As IDRELOJ_Desc, "
            sql &= "USUARIOS.NOMBRE As IDUSUARIOBORRADO_Desc "
            sql &= "From FICHADAS "
            sql &= "INNER Join EMPLEADOS On FICHADAS.IDEMPLEADO = EMPLEADOS.ID "
            sql &= "Left OUTER JOIN RELOJES On FICHADAS.IDRELOJ = RELOJES.ID "
            sql &= "Left OUTER JOIN USUARIOS On FICHADAS.IDUSUARIOBORRADO = USUARIOS.ID "
            sql &= "Where "
            sql &= "FICHADAS.FECHASALIDA >='" & Format(FECHADESDE, "yyyy/MM/dd") & "' "
            sql &= "And FICHADAS.FECHASALIDA <='" & Format(FECHAHASTA, "yyyy/MM/dd") & "' "
            sql &= "And FICHADAS.BORRADO = '0' "
            If ExcluyeInactivos Then sql &= "And EMPLEADOS.INACTIVO = '0' "
            oDatos = oCon.EjecutarDataTable(CommandType.Text, sql)

            If Not IsNothing(oDatos) Then
                list = New List(Of Fichada)

                For Each DtRow As DataRow In oDatos.Rows
                    entity = Make(DtRow)
                    list.Add(entity)
                Next

                Return list
            End If

        Catch ex As Exception
            Throw New Exception("Imposible acceder a los cheques")
        Finally
            oCon.DesConectar()
        End Try

        Return New List(Of Fichada)
    End Function
    Public Function GetTodoEntreFechasGrupo(ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal ExcluyeInactivos As Boolean, ByVal idGrupo As Long) As List(Of Fichada)
        Dim list As List(Of Fichada)
        Dim entity As Fichada

        Dim oDatos As DataTable
        Dim sql As String
        Try
            sql = "Select FICHADAS.ID, "
            sql &= "FICHADAS.IDEMPLEADO, "
            sql &= "FICHADAS.FECHAENTRADA, "
            sql &= "FICHADAS.ENTRADA, "
            sql &= "FICHADAS.FECHASALIDA, "
            sql &= "FICHADAS.SALIDA, "
            sql &= "FICHADAS.HORASTRABAJADAS, "
            sql &= "FICHADAS.MINUTOSTARDE, "
            sql &= "FICHADAS.INCONGRUENCIAS, "
            sql &= "FICHADAS.IDHORARIOEMPLEADO, "
            sql &= "FICHADAS.IDHORARIOADICEMPLEADO, "
            sql &= "FICHADAS.TIPO, "
            sql &= "FICHADAS.IDRELOJ, "
            sql &= "FICHADAS.BORRADO, "
            sql &= "FICHADAS.IDUSUARIOBORRADO, "
            sql &= "FICHADAS.FECHABORRADO, "
            sql &= "EMPLEADOS.NOMBRE As IDEMPLEADO_Desc, "
            sql &= "RELOJES.DESCRIPCION As IDRELOJ_Desc, "
            sql &= "USUARIOS.NOMBRE As IDUSUARIOBORRADO_Desc "
            sql &= "From FICHADAS "
            sql &= "INNER Join EMPLEADOS On FICHADAS.IDEMPLEADO = EMPLEADOS.ID "
            sql &= "INNER Join gruposdetalles on fichadas.idempleado = gruposdetalles.idempleado "
            sql &= "Left OUTER JOIN RELOJES On FICHADAS.IDRELOJ = RELOJES.ID "
            sql &= "Left OUTER JOIN USUARIOS On FICHADAS.IDUSUARIOBORRADO = USUARIOS.ID "
            sql &= "Where "
            sql &= "FICHADAS.FECHAENTRADA >= '" & Format(FECHADESDE, "yyyy/MM/dd") & "' "
            sql &= "And FICHADAS.FECHAENTRADA <= '" & Format(FECHAHASTA, "yyyy/MM/dd") & "' "
            sql &= "And FICHADAS.BORRADO = '0' "
            sql &= "And gruposdetalles.IDGRUPO = " & CStr(idGrupo) & " "
            If ExcluyeInactivos Then sql &= "And EMPLEADOS.INACTIVO = '0' "
            sql &= "UNION "
            sql &= "Select FICHADAS.ID, "
            sql &= "FICHADAS.IDEMPLEADO, "
            sql &= "FICHADAS.FECHAENTRADA, "
            sql &= "FICHADAS.ENTRADA, "
            sql &= "FICHADAS.FECHASALIDA, "
            sql &= "FICHADAS.SALIDA, "
            sql &= "FICHADAS.HORASTRABAJADAS, "
            sql &= "FICHADAS.MINUTOSTARDE, "
            sql &= "FICHADAS.INCONGRUENCIAS, "
            sql &= "FICHADAS.IDHORARIOEMPLEADO, "
            sql &= "FICHADAS.IDHORARIOADICEMPLEADO, "
            sql &= "FICHADAS.TIPO, "
            sql &= "FICHADAS.IDRELOJ, "
            sql &= "FICHADAS.BORRADO, "
            sql &= "FICHADAS.IDUSUARIOBORRADO, "
            sql &= "FICHADAS.FECHABORRADO, "
            sql &= "EMPLEADOS.NOMBRE As IDEMPLEADO_Desc, "
            sql &= "RELOJES.DESCRIPCION As IDRELOJ_Desc, "
            sql &= "USUARIOS.NOMBRE As IDUSUARIOBORRADO_Desc "
            sql &= "From FICHADAS "
            sql &= "INNER Join EMPLEADOS On FICHADAS.IDEMPLEADO = EMPLEADOS.ID "
            sql &= "INNER Join gruposdetalles on fichadas.idempleado = gruposdetalles.idempleado "
            sql &= "Left OUTER JOIN RELOJES On FICHADAS.IDRELOJ = RELOJES.ID "
            sql &= "Left OUTER JOIN USUARIOS On FICHADAS.IDUSUARIOBORRADO = USUARIOS.ID "
            sql &= "Where "
            sql &= "FICHADAS.FECHASALIDA >='" & Format(FECHADESDE, "yyyy/MM/dd") & "' "
            sql &= "And FICHADAS.FECHASALIDA <='" & Format(FECHAHASTA, "yyyy/MM/dd") & "' "
            sql &= "And FICHADAS.BORRADO = '0' "
            sql &= "And gruposdetalles.IDGRUPO = " & CStr(idGrupo) & " "
            If ExcluyeInactivos Then sql &= "And EMPLEADOS.INACTIVO = '0' "
            oDatos = oCon.EjecutarDataTable(CommandType.Text, sql)

            If Not IsNothing(oDatos) Then
                list = New List(Of Fichada)

                For Each DtRow As DataRow In oDatos.Rows
                    entity = Make(DtRow)
                    list.Add(entity)
                Next

                Return list
            End If

        Catch ex As Exception
            Throw New Exception("Imposible acceder a los cheques")
        Finally
            oCon.DesConectar()
        End Try

        Return New List(Of Fichada)
    End Function

End Class
