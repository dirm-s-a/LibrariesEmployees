
'
'	Project Employees
'		Employees Example
'	Entity	HorarioAdicEmpleado
'		HorarioAdicEmpleado Entity
'	
'

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Conexion

Imports Employees.Entities

Public Partial Class HorarioAdicEmpleadoData
	Inherits BaseData

	Public Sub New()
		MyBase.New()
	End Sub

#Region "Metodos Publicos"

	Public Overloads Function Insert(ByVal Entity As HorarioAdicEmpleado, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Insert(Entity.Table, Entity.DirtyFields)
    End Function

    Public Overloads Function Update(ByVal Entity As HorarioAdicEmpleado, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Update(Entity.Table, Entity.KeyFields, Entity.DirtyFields)
    End Function
	
	Public function InsertSP(Entity as HorarioAdicEmpleado, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_HorarioAdicEmpleado_I"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@IDEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDEMPLEADO)
			par = CType(oParams.Item("@FECHADESDE"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHADESDE)
			par = CType(oParams.Item("@FECHAHASTA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAHASTA)
			par = CType(oParams.Item("@HORAENTRADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORAENTRADA)
			par = CType(oParams.Item("@HORASALIDA"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORASALIDA)
			par = CType(oParams.Item("@HORAENTRADA1"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORAENTRADA1)
			par = CType(oParams.Item("@HORASALIDA1"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORASALIDA1)
			par = CType(oParams.Item("@HORAENTRADA2"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORAENTRADA2)
			par = CType(oParams.Item("@HORASALIDA2"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORASALIDA2)
			par = CType(oParams.Item("@ACTIVO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.ACTIVO, par)
			par = CType(oParams.Item("@FECHABAJA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHABAJA)
			par = CType(oParams.Item("@IDUSUARIOBAJA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOBAJA)
			par = CType(oParams.Item("@FECHAMODIFICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAMODIFICACION)
			par = CType(oParams.Item("@IDUSUARIOMODIFICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOMODIFICACION)
			par = CType(oParams.Item("@MINUTOSACUMPLIR"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSACUMPLIR)
			par = CType(oParams.Item("@AUTORIZADO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.AUTORIZADO, par)

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
				bOk = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo insertar la HorarioAdicEmpleado"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If
			par = CType(oParams.Item("@ID"), IDataParameter)
			Entity.ID = par.Value 
			par = CType(oParams.Item("@FECHAMODIFICACION"), IDataParameter)
			Entity.FECHAMODIFICACION = par.Value 
		Catch ex As Exception
			MyBase.ConError = True
		MyBase.Exception = ex
		MyBase.Error = "No se pudo insertar la HorarioAdicEmpleado"
		MyBase.InternalError = ex.Message
		bOk = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bOk
	End Function

	Public function UpdateSP(Entity as HorarioAdicEmpleado, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_HorarioAdicEmpleado_U"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@ID"), IDataParameter)
			par.Value = F_ValueToNull(entity.ID)
			par = CType(oParams.Item("@IDEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDEMPLEADO)
			par = CType(oParams.Item("@FECHADESDE"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHADESDE)
			par = CType(oParams.Item("@FECHAHASTA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAHASTA)
			par = CType(oParams.Item("@HORAENTRADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORAENTRADA)
			par = CType(oParams.Item("@HORASALIDA"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORASALIDA)
			par = CType(oParams.Item("@HORAENTRADA1"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORAENTRADA1)
			par = CType(oParams.Item("@HORASALIDA1"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORASALIDA1)
			par = CType(oParams.Item("@HORAENTRADA2"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORAENTRADA2)
			par = CType(oParams.Item("@HORASALIDA2"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORASALIDA2)
			par = CType(oParams.Item("@ACTIVO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.ACTIVO, par)
			par = CType(oParams.Item("@FECHABAJA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHABAJA)
			par = CType(oParams.Item("@IDUSUARIOBAJA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOBAJA)
			par = CType(oParams.Item("@FECHAMODIFICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAMODIFICACION)
			par = CType(oParams.Item("@IDUSUARIOMODIFICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOMODIFICACION)
			par = CType(oParams.Item("@MINUTOSACUMPLIR"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSACUMPLIR)
			par = CType(oParams.Item("@AUTORIZADO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.AUTORIZADO, par)
	
            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) >= 0 Then
				bok = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo actualizar la HorarioAdicEmpleado"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If

			
		Catch ex As Exception
			MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo actualizar la HorarioAdicEmpleado"
            MyBase.InternalError = ex.Message
			bok = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bok
	End Function

	Public Function GetDtTableById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String = "A_HorarioAdicEmpleadoGetById"
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
        Dim sql As String  = "A_HorarioAdicEmpleadoGetById"		
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
			MyBase.Error = "No se pudo buscar la HorarioAdicEmpleado"
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()	
		End Try
		
		Return drDatos
	End Function

	Public Function GetEntityById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As HorarioAdicEmpleado
		Dim entity as HorarioAdicEmpleado
	    Dim DtDatos As DataTable
		try
			DtDatos = GetDtTableById(ID, ThrowErr)
			If DtDatos.Rows.Count > 0 Then entity = Make(DtDatos.Rows(0))
        Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo buscar la HorarioAdicEmpleado"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()
		End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As HorarioAdicEmpleado, Optional ByVal ThrowErr As Boolean = False) As List(Of HorarioAdicEmpleado)
        Dim DtDatos As DataTable
        Dim listEntities As New List(Of HorarioAdicEmpleado)
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
            MyBase.Error = "No se pudo buscar la HorarioAdicEmpleado"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return listEntities
    End Function
	
	Private Function Make(reader as IDataReader, Optional ByVal ThrowErr As Boolean = False) as HorarioAdicEmpleado
		Dim entity as HorarioAdicEmpleado
		Try
			entity = new HorarioAdicEmpleado
			entity.[New] = false
				if reader("ID") is System.DbNull.Value then
					entity.ID = F_Set_nullValue(entity.ID)
				else
					entity.ID = CType(reader("ID"),Long)
				end if		
				if reader("IDEMPLEADO") is System.DbNull.Value then
					entity.IDEMPLEADO = F_Set_nullValue(entity.IDEMPLEADO)
				else
					entity.IDEMPLEADO = CType(reader("IDEMPLEADO"),Long)
				end if		
				if reader("IDEMPLEADO_Desc") is System.DbNull.Value then
					entity.IDEMPLEADO_Desc = F_Set_nullValue(entity.IDEMPLEADO_Desc)
				else
					entity.IDEMPLEADO_Desc = CType(reader("IDEMPLEADO_Desc"),String)
				end if		
				if reader("FECHADESDE") is System.DbNull.Value then
					entity.FECHADESDE = F_Set_nullValue(entity.FECHADESDE)
				else
					entity.FECHADESDE = CType(reader("FECHADESDE"),Date)
				end if		
				if reader("FECHAHASTA") is System.DbNull.Value then
					entity.FECHAHASTA = F_Set_nullValue(entity.FECHAHASTA)
				else
					entity.FECHAHASTA = CType(reader("FECHAHASTA"),Date)
				end if		
				if reader("HORAENTRADA") is System.DbNull.Value then
					entity.HORAENTRADA = F_Set_nullValue(entity.HORAENTRADA)
				else
					entity.HORAENTRADA = CType(reader("HORAENTRADA"),Integer)
				end if		
				if reader("HORASALIDA") is System.DbNull.Value then
					entity.HORASALIDA = F_Set_nullValue(entity.HORASALIDA)
				else
					entity.HORASALIDA = CType(reader("HORASALIDA"),Integer)
				end if		
				if reader("HORAENTRADA1") is System.DbNull.Value then
					entity.HORAENTRADA1 = F_Set_nullValue(entity.HORAENTRADA1)
				else
					entity.HORAENTRADA1 = CType(reader("HORAENTRADA1"),Integer)
				end if		
				if reader("HORASALIDA1") is System.DbNull.Value then
					entity.HORASALIDA1 = F_Set_nullValue(entity.HORASALIDA1)
				else
					entity.HORASALIDA1 = CType(reader("HORASALIDA1"),Integer)
				end if		
				if reader("HORAENTRADA2") is System.DbNull.Value then
					entity.HORAENTRADA2 = F_Set_nullValue(entity.HORAENTRADA2)
				else
					entity.HORAENTRADA2 = CType(reader("HORAENTRADA2"),Integer)
				end if		
				if reader("HORASALIDA2") is System.DbNull.Value then
					entity.HORASALIDA2 = F_Set_nullValue(entity.HORASALIDA2)
				else
					entity.HORASALIDA2 = CType(reader("HORASALIDA2"),Integer)
				end if		
				if reader("ACTIVO") is System.DbNull.Value then
					entity.ACTIVO = F_Set_nullValue(entity.ACTIVO)
				else
					entity.ACTIVO = F_ValueToBoolean(reader("ACTIVO"))
				end if		
				if reader("FECHABAJA") is System.DbNull.Value then
					entity.FECHABAJA = F_Set_nullValue(entity.FECHABAJA)
				else
					entity.FECHABAJA = CType(reader("FECHABAJA"),DateTime)
				end if		
				if reader("IDUSUARIOBAJA") is System.DbNull.Value then
					entity.IDUSUARIOBAJA = F_Set_nullValue(entity.IDUSUARIOBAJA)
				else
					entity.IDUSUARIOBAJA = CType(reader("IDUSUARIOBAJA"),String)
				end if		
				if reader("IDUSUARIOBAJA_Desc") is System.DbNull.Value then
					entity.IDUSUARIOBAJA_Desc = F_Set_nullValue(entity.IDUSUARIOBAJA_Desc)
				else
					entity.IDUSUARIOBAJA_Desc = CType(reader("IDUSUARIOBAJA_Desc"),String)
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
				if reader("MINUTOSACUMPLIR") is System.DbNull.Value then
					entity.MINUTOSACUMPLIR = F_Set_nullValue(entity.MINUTOSACUMPLIR)
				else
					entity.MINUTOSACUMPLIR = CType(reader("MINUTOSACUMPLIR"),Integer)
				end if		
				if reader("AUTORIZADO") is System.DbNull.Value then
					entity.AUTORIZADO = F_Set_nullValue(entity.AUTORIZADO)
				else
					entity.AUTORIZADO = F_ValueToBoolean(reader("AUTORIZADO"))
				end if		
		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la HorarioAdicEmpleado"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function

	
	Private Function Make(row as DataRow, Optional ByVal ThrowErr As Boolean = False) as HorarioAdicEmpleado
		Dim entity as HorarioAdicEmpleado
		Try
		
			entity = new HorarioAdicEmpleado
			entity.[New] = false

	if F_Contains(row, "ID") then
		if row("ID") is System.DbNull.Value then
			entity.ID = F_Set_nullValue(entity.ID)
		else
			entity.ID = CType(row("ID"),Long)
		end if
	end if
	if F_Contains(row, "IDEMPLEADO") then
		if row("IDEMPLEADO") is System.DbNull.Value then
			entity.IDEMPLEADO = F_Set_nullValue(entity.IDEMPLEADO)
		else
			entity.IDEMPLEADO = CType(row("IDEMPLEADO"),Long)
		end if
	end if
	if F_Contains(row, "IDEMPLEADO_Desc") then
		if row("IDEMPLEADO_Desc") is System.DbNull.Value then
			entity.IDEMPLEADO_Desc = F_Set_nullValue(entity.IDEMPLEADO_Desc)
		else
			entity.IDEMPLEADO_Desc = CType(row("IDEMPLEADO_Desc"),String)
		end if
	end if
	if F_Contains(row, "FECHADESDE") then
		if row("FECHADESDE") is System.DbNull.Value then
			entity.FECHADESDE = F_Set_nullValue(entity.FECHADESDE)
		else
			entity.FECHADESDE = CType(row("FECHADESDE"),Date)
		end if
	end if
	if F_Contains(row, "FECHAHASTA") then
		if row("FECHAHASTA") is System.DbNull.Value then
			entity.FECHAHASTA = F_Set_nullValue(entity.FECHAHASTA)
		else
			entity.FECHAHASTA = CType(row("FECHAHASTA"),Date)
		end if
	end if
	if F_Contains(row, "HORAENTRADA") then
		if row("HORAENTRADA") is System.DbNull.Value then
			entity.HORAENTRADA = F_Set_nullValue(entity.HORAENTRADA)
		else
			entity.HORAENTRADA = CType(row("HORAENTRADA"),Integer)
		end if
	end if
	if F_Contains(row, "HORASALIDA") then
		if row("HORASALIDA") is System.DbNull.Value then
			entity.HORASALIDA = F_Set_nullValue(entity.HORASALIDA)
		else
			entity.HORASALIDA = CType(row("HORASALIDA"),Integer)
		end if
	end if
	if F_Contains(row, "HORAENTRADA1") then
		if row("HORAENTRADA1") is System.DbNull.Value then
			entity.HORAENTRADA1 = F_Set_nullValue(entity.HORAENTRADA1)
		else
			entity.HORAENTRADA1 = CType(row("HORAENTRADA1"),Integer)
		end if
	end if
	if F_Contains(row, "HORASALIDA1") then
		if row("HORASALIDA1") is System.DbNull.Value then
			entity.HORASALIDA1 = F_Set_nullValue(entity.HORASALIDA1)
		else
			entity.HORASALIDA1 = CType(row("HORASALIDA1"),Integer)
		end if
	end if
	if F_Contains(row, "HORAENTRADA2") then
		if row("HORAENTRADA2") is System.DbNull.Value then
			entity.HORAENTRADA2 = F_Set_nullValue(entity.HORAENTRADA2)
		else
			entity.HORAENTRADA2 = CType(row("HORAENTRADA2"),Integer)
		end if
	end if
	if F_Contains(row, "HORASALIDA2") then
		if row("HORASALIDA2") is System.DbNull.Value then
			entity.HORASALIDA2 = F_Set_nullValue(entity.HORASALIDA2)
		else
			entity.HORASALIDA2 = CType(row("HORASALIDA2"),Integer)
		end if
	end if
	if F_Contains(row, "ACTIVO") then
		if row("ACTIVO") is System.DbNull.Value then
			entity.ACTIVO = F_Set_nullValue(entity.ACTIVO)
		else
			entity.ACTIVO = F_ValueToBoolean(row("ACTIVO"))
		end if
	end if
	if F_Contains(row, "FECHABAJA") then
		if row("FECHABAJA") is System.DbNull.Value then
			entity.FECHABAJA = F_Set_nullValue(entity.FECHABAJA)
		else
			entity.FECHABAJA = CType(row("FECHABAJA"),DateTime)
		end if
	end if
	if F_Contains(row, "IDUSUARIOBAJA") then
		if row("IDUSUARIOBAJA") is System.DbNull.Value then
			entity.IDUSUARIOBAJA = F_Set_nullValue(entity.IDUSUARIOBAJA)
		else
			entity.IDUSUARIOBAJA = CType(row("IDUSUARIOBAJA"),String)
		end if
	end if
	if F_Contains(row, "IDUSUARIOBAJA_Desc") then
		if row("IDUSUARIOBAJA_Desc") is System.DbNull.Value then
			entity.IDUSUARIOBAJA_Desc = F_Set_nullValue(entity.IDUSUARIOBAJA_Desc)
		else
			entity.IDUSUARIOBAJA_Desc = CType(row("IDUSUARIOBAJA_Desc"),String)
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
	if F_Contains(row, "MINUTOSACUMPLIR") then
		if row("MINUTOSACUMPLIR") is System.DbNull.Value then
			entity.MINUTOSACUMPLIR = F_Set_nullValue(entity.MINUTOSACUMPLIR)
		else
			entity.MINUTOSACUMPLIR = CType(row("MINUTOSACUMPLIR"),Integer)
		end if
	end if
	if F_Contains(row, "AUTORIZADO") then
		if row("AUTORIZADO") is System.DbNull.Value then
			entity.AUTORIZADO = F_Set_nullValue(entity.AUTORIZADO)
		else
			entity.AUTORIZADO = F_ValueToBoolean(row("AUTORIZADO"))
		end if
	end if

		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la HorarioAdicEmpleado"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function
	
#End Region

Public Function GetByEmpleado(Byval IDEMPLEADO as Long
) As List (of HorarioAdicEmpleado)
        Dim sql As String = "A_HORARIOADICEMPGETBYEMP"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of HorarioAdicEmpleado)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@IDEMPLEADO_I"), IDataParameter)
			par.Value = F_ValueToNull(IDEMPLEADO)
		
			Dim entity As HorarioAdicEmpleado
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

Public Function GetALL() As List (of HorarioAdicEmpleado)
        Dim sql As String = "A_HorarioAdicEmpGETALL"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of HorarioAdicEmpleado)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			Dim entity As HorarioAdicEmpleado
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

