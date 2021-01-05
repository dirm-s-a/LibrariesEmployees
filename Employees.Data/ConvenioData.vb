
'
'	Project Employees
'		Employees Example
'	Entity	Convenio
'		Convenio Entity
'	
'

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Conexion

Imports Employees.Entities

Public Partial Class ConvenioData
	Inherits BaseData

	Public Sub New()
		MyBase.New()
	End Sub

#Region "Metodos Publicos"

	Public Overloads Function Insert(ByVal Entity As Convenio, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Insert(Entity.Table, Entity.DirtyFields)
    End Function

    Public Overloads Function Update(ByVal Entity As Convenio, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Update(Entity.Table, Entity.KeyFields, Entity.DirtyFields)
    End Function
	
	Public function InsertSP(Entity as Convenio, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Convenio_I"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@DESCRIPCION"), IDataParameter)
			par.Value = F_ValueToNull(entity.DESCRIPCION)
			par = CType(oParams.Item("@AUSENTISMO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.AUSENTISMO, par)
			par = CType(oParams.Item("@MINUTOSGRACIA"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSGRACIA)
			par = CType(oParams.Item("@MINUTOSTOPE"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSTOPE)
			par = CType(oParams.Item("@HORARIOFLEXIBLE"), IDataParameter)
			par.Value = F_BooleanToValue(entity.HORARIOFLEXIBLE, par)
			par = CType(oParams.Item("@ACTIVO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.ACTIVO, par)
			par = CType(oParams.Item("@FECHAALTA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAALTA)
			par = CType(oParams.Item("@IDUDUARIOALTA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUDUARIOALTA)
			par = CType(oParams.Item("@FECHAMODIFICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAMODIFICACION)
			par = CType(oParams.Item("@IDUSUARIOMODIFICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOMODIFICACION)
			par = CType(oParams.Item("@SINCONTROLES"), IDataParameter)
			par.Value = F_BooleanToValue(entity.SINCONTROLES, par)
			par = CType(oParams.Item("@MINUTOSLUNVIER"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSLUNVIER)
			par = CType(oParams.Item("@MINUTOSSABADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSSABADO)
			par = CType(oParams.Item("@MINUTOSDOMINGO"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSDOMINGO)
			par = CType(oParams.Item("@CONTROLDESCANSO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.CONTROLDESCANSO, par)

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
				bOk = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo insertar la Convenio"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If
			par = CType(oParams.Item("@ID"), IDataParameter)
			Entity.ID = par.Value 
			par = CType(oParams.Item("@FECHAALTA"), IDataParameter)
			Entity.FECHAALTA = par.Value 
		Catch ex As Exception
			MyBase.ConError = True
		MyBase.Exception = ex
		MyBase.Error = "No se pudo insertar la Convenio"
		MyBase.InternalError = ex.Message
		bOk = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bOk
	End Function

	Public function UpdateSP(Entity as Convenio, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Convenio_U"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@ID"), IDataParameter)
			par.Value = F_ValueToNull(entity.ID)
			par = CType(oParams.Item("@DESCRIPCION"), IDataParameter)
			par.Value = F_ValueToNull(entity.DESCRIPCION)
			par = CType(oParams.Item("@AUSENTISMO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.AUSENTISMO, par)
			par = CType(oParams.Item("@MINUTOSGRACIA"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSGRACIA)
			par = CType(oParams.Item("@MINUTOSTOPE"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSTOPE)
			par = CType(oParams.Item("@HORARIOFLEXIBLE"), IDataParameter)
			par.Value = F_BooleanToValue(entity.HORARIOFLEXIBLE, par)
			par = CType(oParams.Item("@ACTIVO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.ACTIVO, par)
			par = CType(oParams.Item("@FECHAALTA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAALTA)
			par = CType(oParams.Item("@IDUDUARIOALTA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUDUARIOALTA)
			par = CType(oParams.Item("@FECHAMODIFICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAMODIFICACION)
			par = CType(oParams.Item("@IDUSUARIOMODIFICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOMODIFICACION)
			par = CType(oParams.Item("@SINCONTROLES"), IDataParameter)
			par.Value = F_BooleanToValue(entity.SINCONTROLES, par)
			par = CType(oParams.Item("@MINUTOSLUNVIER"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSLUNVIER)
			par = CType(oParams.Item("@MINUTOSSABADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSSABADO)
			par = CType(oParams.Item("@MINUTOSDOMINGO"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSDOMINGO)
			par = CType(oParams.Item("@CONTROLDESCANSO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.CONTROLDESCANSO, par)
	
            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) >= 0 Then
				bok = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo actualizar la Convenio"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If

			par = CType(oParams.Item("@FECHAMODIFICACION"), IDataParameter)
			Entity.FECHAMODIFICACION = par.Value 
			
		Catch ex As Exception
			MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo actualizar la Convenio"
            MyBase.InternalError = ex.Message
			bok = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bok
	End Function

	Public Function GetDtTableById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String = "A_ConvenioGetById"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
        Try
            oParams = oCon.ObtenerParametros(sql)
			par = CType(oParams.Item("@ID_I"), IDataParameter)
			par.Value = ID
            DtDatos = oCon.EjecutarDataTable(CommandType.StoredProcedure, sql, oParams)
        Catch ex As Exception
            If Not IsNothing(oCon) AndAlso Not IsNothing(oCon.Exception) Then
                MyBase.InternalError = oCon.Exception.Message
                MyBase.Exception = ex
            Else
                MyBase.Exception = ex
                MyBase.InternalError = ex.Message
            End If
            MyBase.ConError = True
            MyBase.Error = "No se pudo buscar la Turno"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
	    oCon.DesConectar()
        End Try

        Return DtDatos
    End Function

	Public Function GetDReaderById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False)  As System.Data.IDataReader
        Dim sql As String  = "A_ConvenioGetById"		
		Dim oParams As IDataParameterCollection
        Dim drDatos As IDataReader
		Dim par As IDataParameter 
		try		
		oParams = oCon.ObtenerParametros(sql)
			par = CType(oParams.Item("@ID_I"), IDataParameter)
			par.Value = ID
			drDatos = oCon.EjecutarDataReader(CommandType.StoredProcedure, sql, oParams)
		Catch ex As Exception
			If Not IsNothing(oCon) AndAlso Not IsNothing(oCon.Exception) Then
				MyBase.InternalError = oCon.Exception.Message
				MyBase.Exception = ex
			Else
				MyBase.Exception = ex
				MyBase.InternalError = ex.Message
			End If
			MyBase.ConError = True
			MyBase.Error = "No se pudo buscar la Convenio"
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()	
		End Try
		
		Return drDatos
	End Function

	Public Function GetEntityById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As Convenio
		Dim entity as Convenio
	    Dim DtDatos As DataTable
		try
			DtDatos = GetDtTableById(ID, ThrowErr)
			If DtDatos.Rows.Count > 0 Then entity = Make(DtDatos.Rows(0))
        Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo buscar la Convenio"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()
		End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As Convenio, Optional ByVal ThrowErr As Boolean = False) As List(Of Convenio)
        Dim DtDatos As DataTable
        Dim listEntities As New List(Of Convenio)
        Try
            DtDatos = [Select](entity.Table, entity.DirtyFields)
            for each DtRow as DataRow in DtDatos.Rows
                entity = Make(DtRow)

                listEntities.Add(entity)
            Next
        Catch ex As Exception
			listEntities = Nothing
            MyBase.InternalError = ex.Message
            MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo buscar la Convenio"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return listEntities
    End Function
	
	Private Function Make(reader as IDataReader, Optional ByVal ThrowErr As Boolean = False) as Convenio
		Dim entity as Convenio
		Try
			entity = new Convenio
			entity.[New] = false
				if reader("ID") is System.DbNull.Value then
					entity.ID = F_Set_nullValue(entity.ID)
				else
					entity.ID = CType(reader("ID"),Long)
				end if		
				if reader("DESCRIPCION") is System.DbNull.Value then
					entity.DESCRIPCION = F_Set_nullValue(entity.DESCRIPCION)
				else
					entity.DESCRIPCION = CType(reader("DESCRIPCION"),String)
				end if		
				if reader("AUSENTISMO") is System.DbNull.Value then
					entity.AUSENTISMO = F_Set_nullValue(entity.AUSENTISMO)
				else
					entity.AUSENTISMO = F_ValueToBoolean(reader("AUSENTISMO"))
				end if		
				if reader("MINUTOSGRACIA") is System.DbNull.Value then
					entity.MINUTOSGRACIA = F_Set_nullValue(entity.MINUTOSGRACIA)
				else
					entity.MINUTOSGRACIA = CType(reader("MINUTOSGRACIA"),Integer)
				end if		
				if reader("MINUTOSTOPE") is System.DbNull.Value then
					entity.MINUTOSTOPE = F_Set_nullValue(entity.MINUTOSTOPE)
				else
					entity.MINUTOSTOPE = CType(reader("MINUTOSTOPE"),Integer)
				end if		
				if reader("HORARIOFLEXIBLE") is System.DbNull.Value then
					entity.HORARIOFLEXIBLE = F_Set_nullValue(entity.HORARIOFLEXIBLE)
				else
					entity.HORARIOFLEXIBLE = F_ValueToBoolean(reader("HORARIOFLEXIBLE"))
				end if		
				if reader("ACTIVO") is System.DbNull.Value then
					entity.ACTIVO = F_Set_nullValue(entity.ACTIVO)
				else
					entity.ACTIVO = F_ValueToBoolean(reader("ACTIVO"))
				end if		
				if reader("FECHAALTA") is System.DbNull.Value then
					entity.FECHAALTA = F_Set_nullValue(entity.FECHAALTA)
				else
					entity.FECHAALTA = CType(reader("FECHAALTA"),DateTime)
				end if		
				if reader("IDUDUARIOALTA") is System.DbNull.Value then
					entity.IDUDUARIOALTA = F_Set_nullValue(entity.IDUDUARIOALTA)
				else
					entity.IDUDUARIOALTA = CType(reader("IDUDUARIOALTA"),String)
				end if		
				if reader("IDUDUARIOALTA_Desc") is System.DbNull.Value then
					entity.IDUDUARIOALTA_Desc = F_Set_nullValue(entity.IDUDUARIOALTA_Desc)
				else
					entity.IDUDUARIOALTA_Desc = CType(reader("IDUDUARIOALTA_Desc"),String)
				end if		
				if reader("FECHAMODIFICACION") is System.DbNull.Value then
					entity.FECHAMODIFICACION = F_Set_nullValue(entity.FECHAMODIFICACION)
				else
					entity.FECHAMODIFICACION = CType(reader("FECHAMODIFICACION"),DateTime)
				end if		
				if reader("IDUSUARIOMODIFICACION") is System.DbNull.Value then
					entity.IDUSUARIOMODIFICACION = F_Set_nullValue(entity.IDUSUARIOMODIFICACION)
				else
					entity.IDUSUARIOMODIFICACION = CType(reader("IDUSUARIOMODIFICACION"),String)
				end if		
				if reader("IDUSUARIOMODIFICACION_Desc") is System.DbNull.Value then
					entity.IDUSUARIOMODIFICACION_Desc = F_Set_nullValue(entity.IDUSUARIOMODIFICACION_Desc)
				else
					entity.IDUSUARIOMODIFICACION_Desc = CType(reader("IDUSUARIOMODIFICACION_Desc"),String)
				end if		
				if reader("SINCONTROLES") is System.DbNull.Value then
					entity.SINCONTROLES = F_Set_nullValue(entity.SINCONTROLES)
				else
					entity.SINCONTROLES = F_ValueToBoolean(reader("SINCONTROLES"))
				end if		
				if reader("MINUTOSLUNVIER") is System.DbNull.Value then
					entity.MINUTOSLUNVIER = F_Set_nullValue(entity.MINUTOSLUNVIER)
				else
					entity.MINUTOSLUNVIER = CType(reader("MINUTOSLUNVIER"),Integer)
				end if		
				if reader("MINUTOSSABADO") is System.DbNull.Value then
					entity.MINUTOSSABADO = F_Set_nullValue(entity.MINUTOSSABADO)
				else
					entity.MINUTOSSABADO = CType(reader("MINUTOSSABADO"),Integer)
				end if		
				if reader("MINUTOSDOMINGO") is System.DbNull.Value then
					entity.MINUTOSDOMINGO = F_Set_nullValue(entity.MINUTOSDOMINGO)
				else
					entity.MINUTOSDOMINGO = CType(reader("MINUTOSDOMINGO"),Integer)
				end if		
				if reader("CONTROLDESCANSO") is System.DbNull.Value then
					entity.CONTROLDESCANSO = F_Set_nullValue(entity.CONTROLDESCANSO)
				else
					entity.CONTROLDESCANSO = F_ValueToBoolean(reader("CONTROLDESCANSO"))
				end if		
		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la Convenio"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function

	
	Private Function Make(row as DataRow, Optional ByVal ThrowErr As Boolean = False) as Convenio
		Dim entity as Convenio
		Try
		
			entity = new Convenio
			entity.[New] = false

	if F_Contains(row, "ID") then
		if row("ID") is System.DbNull.Value then
			entity.ID = F_Set_nullValue(entity.ID)
		else
			entity.ID = CType(row("ID"),Long)
		end if
	end if
	if F_Contains(row, "DESCRIPCION") then
		if row("DESCRIPCION") is System.DbNull.Value then
			entity.DESCRIPCION = F_Set_nullValue(entity.DESCRIPCION)
		else
			entity.DESCRIPCION = CType(row("DESCRIPCION"),String)
		end if
	end if
	if F_Contains(row, "AUSENTISMO") then
		if row("AUSENTISMO") is System.DbNull.Value then
			entity.AUSENTISMO = F_Set_nullValue(entity.AUSENTISMO)
		else
			entity.AUSENTISMO = F_ValueToBoolean(row("AUSENTISMO"))
		end if
	end if
	if F_Contains(row, "MINUTOSGRACIA") then
		if row("MINUTOSGRACIA") is System.DbNull.Value then
			entity.MINUTOSGRACIA = F_Set_nullValue(entity.MINUTOSGRACIA)
		else
			entity.MINUTOSGRACIA = CType(row("MINUTOSGRACIA"),Integer)
		end if
	end if
	if F_Contains(row, "MINUTOSTOPE") then
		if row("MINUTOSTOPE") is System.DbNull.Value then
			entity.MINUTOSTOPE = F_Set_nullValue(entity.MINUTOSTOPE)
		else
			entity.MINUTOSTOPE = CType(row("MINUTOSTOPE"),Integer)
		end if
	end if
	if F_Contains(row, "HORARIOFLEXIBLE") then
		if row("HORARIOFLEXIBLE") is System.DbNull.Value then
			entity.HORARIOFLEXIBLE = F_Set_nullValue(entity.HORARIOFLEXIBLE)
		else
			entity.HORARIOFLEXIBLE = F_ValueToBoolean(row("HORARIOFLEXIBLE"))
		end if
	end if
	if F_Contains(row, "ACTIVO") then
		if row("ACTIVO") is System.DbNull.Value then
			entity.ACTIVO = F_Set_nullValue(entity.ACTIVO)
		else
			entity.ACTIVO = F_ValueToBoolean(row("ACTIVO"))
		end if
	end if
	if F_Contains(row, "FECHAALTA") then
		if row("FECHAALTA") is System.DbNull.Value then
			entity.FECHAALTA = F_Set_nullValue(entity.FECHAALTA)
		else
			entity.FECHAALTA = CType(row("FECHAALTA"),DateTime)
		end if
	end if
	if F_Contains(row, "IDUDUARIOALTA") then
		if row("IDUDUARIOALTA") is System.DbNull.Value then
			entity.IDUDUARIOALTA = F_Set_nullValue(entity.IDUDUARIOALTA)
		else
			entity.IDUDUARIOALTA = CType(row("IDUDUARIOALTA"),String)
		end if
	end if
	if F_Contains(row, "IDUDUARIOALTA_Desc") then
		if row("IDUDUARIOALTA_Desc") is System.DbNull.Value then
			entity.IDUDUARIOALTA_Desc = F_Set_nullValue(entity.IDUDUARIOALTA_Desc)
		else
			entity.IDUDUARIOALTA_Desc = CType(row("IDUDUARIOALTA_Desc"),String)
		end if
	end if
	if F_Contains(row, "FECHAMODIFICACION") then
		if row("FECHAMODIFICACION") is System.DbNull.Value then
			entity.FECHAMODIFICACION = F_Set_nullValue(entity.FECHAMODIFICACION)
		else
			entity.FECHAMODIFICACION = CType(row("FECHAMODIFICACION"),DateTime)
		end if
	end if
	if F_Contains(row, "IDUSUARIOMODIFICACION") then
		if row("IDUSUARIOMODIFICACION") is System.DbNull.Value then
			entity.IDUSUARIOMODIFICACION = F_Set_nullValue(entity.IDUSUARIOMODIFICACION)
		else
			entity.IDUSUARIOMODIFICACION = CType(row("IDUSUARIOMODIFICACION"),String)
		end if
	end if
	if F_Contains(row, "IDUSUARIOMODIFICACION_Desc") then
		if row("IDUSUARIOMODIFICACION_Desc") is System.DbNull.Value then
			entity.IDUSUARIOMODIFICACION_Desc = F_Set_nullValue(entity.IDUSUARIOMODIFICACION_Desc)
		else
			entity.IDUSUARIOMODIFICACION_Desc = CType(row("IDUSUARIOMODIFICACION_Desc"),String)
		end if
	end if
	if F_Contains(row, "SINCONTROLES") then
		if row("SINCONTROLES") is System.DbNull.Value then
			entity.SINCONTROLES = F_Set_nullValue(entity.SINCONTROLES)
		else
			entity.SINCONTROLES = F_ValueToBoolean(row("SINCONTROLES"))
		end if
	end if
	if F_Contains(row, "MINUTOSLUNVIER") then
		if row("MINUTOSLUNVIER") is System.DbNull.Value then
			entity.MINUTOSLUNVIER = F_Set_nullValue(entity.MINUTOSLUNVIER)
		else
			entity.MINUTOSLUNVIER = CType(row("MINUTOSLUNVIER"),Integer)
		end if
	end if
	if F_Contains(row, "MINUTOSSABADO") then
		if row("MINUTOSSABADO") is System.DbNull.Value then
			entity.MINUTOSSABADO = F_Set_nullValue(entity.MINUTOSSABADO)
		else
			entity.MINUTOSSABADO = CType(row("MINUTOSSABADO"),Integer)
		end if
	end if
	if F_Contains(row, "MINUTOSDOMINGO") then
		if row("MINUTOSDOMINGO") is System.DbNull.Value then
			entity.MINUTOSDOMINGO = F_Set_nullValue(entity.MINUTOSDOMINGO)
		else
			entity.MINUTOSDOMINGO = CType(row("MINUTOSDOMINGO"),Integer)
		end if
	end if
	if F_Contains(row, "CONTROLDESCANSO") then
		if row("CONTROLDESCANSO") is System.DbNull.Value then
			entity.CONTROLDESCANSO = F_Set_nullValue(entity.CONTROLDESCANSO)
		else
			entity.CONTROLDESCANSO = F_ValueToBoolean(row("CONTROLDESCANSO"))
		end if
	end if

		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la Convenio"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function
	
#End Region

Public Function GetALL() As List (of Convenio)
        Dim sql As String = "A_ConvenioGETALL"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Convenio)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			Dim entity As Convenio
			DtDatos = oCon.EjecutarDataTable(CommandType.StoredProcedure, sql, oParams)
            for each DtRow as DataRow in DtDatos.Rows
                entity = Make(DtRow)

                listEntities.Add(entity)
            Next
        Catch ex As Exception
            If Not IsNothing(oCon) AndAlso Not IsNothing(oCon.Exception) Then
                MyBase.InternalError = oCon.Exception.Message
                MyBase.Exception = ex
            Else
                MyBase.Exception = ex
                MyBase.InternalError = ex.Message
            End If
            MyBase.ConError = True
            MyBase.Error = "No se pudo buscar la Turno"

        Finally
	    oCon.DesConectar()
        End Try

        Return ListEntities
				
    End Function

End Class

