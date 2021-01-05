
'
'	Project Employees
'		Employees Example
'	Entity	Liquidacion
'		Liquidacion Entity
'	
'

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Conexion

Imports Employees.Entities

Public Partial Class LiquidacionData
	Inherits BaseData

	Public Sub New()
		MyBase.New()
	End Sub

#Region "Metodos Publicos"

	Public Overloads Function Insert(ByVal Entity As Liquidacion, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Insert(Entity.Table, Entity.DirtyFields)
    End Function

    Public Overloads Function Update(ByVal Entity As Liquidacion, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Update(Entity.Table, Entity.KeyFields, Entity.DirtyFields)
    End Function
	
	Public function InsertSP(Entity as Liquidacion, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Liquidacion_I"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@FECHALIQUDACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHALIQUDACION)
			par = CType(oParams.Item("@IDEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDEMPLEADO)
			par = CType(oParams.Item("@IDCONVENIO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDCONVENIO)
			par = CType(oParams.Item("@FECHADESDE"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHADESDE)
			par = CType(oParams.Item("@FECHAHASTA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAHASTA)
			par = CType(oParams.Item("@AUSENCIASCONPRESENTISMO"), IDataParameter)
			par.Value = F_ValueToNull(entity.AUSENCIASCONPRESENTISMO)
			par = CType(oParams.Item("@AUSENCIASJUSTIFICADAS"), IDataParameter)
			par.Value = F_ValueToNull(entity.AUSENCIASJUSTIFICADAS)
			par = CType(oParams.Item("@AUSENCIASINJUSTIFICADAS"), IDataParameter)
			par.Value = F_ValueToNull(entity.AUSENCIASINJUSTIFICADAS)
			par = CType(oParams.Item("@DIASTRABAJADOS"), IDataParameter)
			par.Value = F_ValueToNull(entity.DIASTRABAJADOS)
			par = CType(oParams.Item("@DIASSINPRESENTISMO"), IDataParameter)
			par.Value = F_ValueToNull(entity.DIASSINPRESENTISMO)
			par = CType(oParams.Item("@DIASMEDIOPRESENTISMO"), IDataParameter)
			par.Value = F_ValueToNull(entity.DIASMEDIOPRESENTISMO)
			par = CType(oParams.Item("@MINUTOSTARDE"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSTARDE)
			par = CType(oParams.Item("@INCONSISTENCIAS"), IDataParameter)
			par.Value = F_ValueToNull(entity.INCONSISTENCIAS)
			par = CType(oParams.Item("@PRESENTISMO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.PRESENTISMO, par)
			par = CType(oParams.Item("@MEDIOPRESENTISMO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.MEDIOPRESENTISMO, par)

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
				bOk = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo insertar la Liquidacion"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If
			par = CType(oParams.Item("@ID"), IDataParameter)
			Entity.ID = par.Value 
			par = CType(oParams.Item("@FECHALIQUDACION"), IDataParameter)
			Entity.FECHALIQUDACION = par.Value 
		Catch ex As Exception
			MyBase.ConError = True
		MyBase.Exception = ex
		MyBase.Error = "No se pudo insertar la Liquidacion"
		MyBase.InternalError = ex.Message
		bOk = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bOk
	End Function

	Public function UpdateSP(Entity as Liquidacion, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Liquidacion_U"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@ID"), IDataParameter)
			par.Value = F_ValueToNull(entity.ID)
			par = CType(oParams.Item("@IDEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDEMPLEADO)
			par = CType(oParams.Item("@IDCONVENIO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDCONVENIO)
			par = CType(oParams.Item("@FECHADESDE"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHADESDE)
			par = CType(oParams.Item("@FECHAHASTA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAHASTA)
			par = CType(oParams.Item("@AUSENCIASCONPRESENTISMO"), IDataParameter)
			par.Value = F_ValueToNull(entity.AUSENCIASCONPRESENTISMO)
			par = CType(oParams.Item("@AUSENCIASJUSTIFICADAS"), IDataParameter)
			par.Value = F_ValueToNull(entity.AUSENCIASJUSTIFICADAS)
			par = CType(oParams.Item("@AUSENCIASINJUSTIFICADAS"), IDataParameter)
			par.Value = F_ValueToNull(entity.AUSENCIASINJUSTIFICADAS)
			par = CType(oParams.Item("@DIASTRABAJADOS"), IDataParameter)
			par.Value = F_ValueToNull(entity.DIASTRABAJADOS)
			par = CType(oParams.Item("@DIASSINPRESENTISMO"), IDataParameter)
			par.Value = F_ValueToNull(entity.DIASSINPRESENTISMO)
			par = CType(oParams.Item("@DIASMEDIOPRESENTISMO"), IDataParameter)
			par.Value = F_ValueToNull(entity.DIASMEDIOPRESENTISMO)
			par = CType(oParams.Item("@MINUTOSTARDE"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSTARDE)
			par = CType(oParams.Item("@INCONSISTENCIAS"), IDataParameter)
			par.Value = F_ValueToNull(entity.INCONSISTENCIAS)
			par = CType(oParams.Item("@PRESENTISMO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.PRESENTISMO, par)
			par = CType(oParams.Item("@MEDIOPRESENTISMO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.MEDIOPRESENTISMO, par)
	
            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) >= 0 Then
				bok = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo actualizar la Liquidacion"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If

			
		Catch ex As Exception
			MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo actualizar la Liquidacion"
            MyBase.InternalError = ex.Message
			bok = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bok
	End Function

	Public Function GetDtTableById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String = "A_LiquidacionGetById"
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
        Dim sql As String  = "A_LiquidacionGetById"		
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
			MyBase.Error = "No se pudo buscar la Liquidacion"
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()	
		End Try
		
		Return drDatos
	End Function

	Public Function GetEntityById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As Liquidacion
		Dim entity as Liquidacion
	    Dim DtDatos As DataTable
		try
			DtDatos = GetDtTableById(ID, ThrowErr)
			If DtDatos.Rows.Count > 0 Then entity = Make(DtDatos.Rows(0))
        Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo buscar la Liquidacion"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()
		End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As Liquidacion, Optional ByVal ThrowErr As Boolean = False) As List(Of Liquidacion)
        Dim DtDatos As DataTable
        Dim listEntities As New List(Of Liquidacion)
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
            MyBase.Error = "No se pudo buscar la Liquidacion"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return listEntities
    End Function
	
	Private Function Make(reader as IDataReader, Optional ByVal ThrowErr As Boolean = False) as Liquidacion
		Dim entity as Liquidacion
		Try
			entity = new Liquidacion
			entity.[New] = false
				if reader("ID") is System.DbNull.Value then
					entity.ID = F_Set_nullValue(entity.ID)
				else
					entity.ID = CType(reader("ID"),Long)
				end if		
				if reader("FECHALIQUDACION") is System.DbNull.Value then
					entity.FECHALIQUDACION = F_Set_nullValue(entity.FECHALIQUDACION)
				else
					entity.FECHALIQUDACION = CType(reader("FECHALIQUDACION"),DateTime)
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
				if reader("IDCONVENIO") is System.DbNull.Value then
					entity.IDCONVENIO = F_Set_nullValue(entity.IDCONVENIO)
				else
					entity.IDCONVENIO = CType(reader("IDCONVENIO"),Long)
				end if		
				if reader("IDCONVENIO_Desc") is System.DbNull.Value then
					entity.IDCONVENIO_Desc = F_Set_nullValue(entity.IDCONVENIO_Desc)
				else
					entity.IDCONVENIO_Desc = CType(reader("IDCONVENIO_Desc"),String)
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
				if reader("AUSENCIASCONPRESENTISMO") is System.DbNull.Value then
					entity.AUSENCIASCONPRESENTISMO = F_Set_nullValue(entity.AUSENCIASCONPRESENTISMO)
				else
					entity.AUSENCIASCONPRESENTISMO = CType(reader("AUSENCIASCONPRESENTISMO"),Integer)
				end if		
				if reader("AUSENCIASJUSTIFICADAS") is System.DbNull.Value then
					entity.AUSENCIASJUSTIFICADAS = F_Set_nullValue(entity.AUSENCIASJUSTIFICADAS)
				else
					entity.AUSENCIASJUSTIFICADAS = CType(reader("AUSENCIASJUSTIFICADAS"),Integer)
				end if		
				if reader("AUSENCIASINJUSTIFICADAS") is System.DbNull.Value then
					entity.AUSENCIASINJUSTIFICADAS = F_Set_nullValue(entity.AUSENCIASINJUSTIFICADAS)
				else
					entity.AUSENCIASINJUSTIFICADAS = CType(reader("AUSENCIASINJUSTIFICADAS"),Integer)
				end if		
				if reader("DIASTRABAJADOS") is System.DbNull.Value then
					entity.DIASTRABAJADOS = F_Set_nullValue(entity.DIASTRABAJADOS)
				else
					entity.DIASTRABAJADOS = CType(reader("DIASTRABAJADOS"),Integer)
				end if		
				if reader("DIASSINPRESENTISMO") is System.DbNull.Value then
					entity.DIASSINPRESENTISMO = F_Set_nullValue(entity.DIASSINPRESENTISMO)
				else
					entity.DIASSINPRESENTISMO = CType(reader("DIASSINPRESENTISMO"),Integer)
				end if		
				if reader("DIASMEDIOPRESENTISMO") is System.DbNull.Value then
					entity.DIASMEDIOPRESENTISMO = F_Set_nullValue(entity.DIASMEDIOPRESENTISMO)
				else
					entity.DIASMEDIOPRESENTISMO = CType(reader("DIASMEDIOPRESENTISMO"),Integer)
				end if		
				if reader("MINUTOSTARDE") is System.DbNull.Value then
					entity.MINUTOSTARDE = F_Set_nullValue(entity.MINUTOSTARDE)
				else
					entity.MINUTOSTARDE = CType(reader("MINUTOSTARDE"),Integer)
				end if		
				if reader("INCONSISTENCIAS") is System.DbNull.Value then
					entity.INCONSISTENCIAS = F_Set_nullValue(entity.INCONSISTENCIAS)
				else
					entity.INCONSISTENCIAS = CType(reader("INCONSISTENCIAS"),Integer)
				end if		
				if reader("PRESENTISMO") is System.DbNull.Value then
					entity.PRESENTISMO = F_Set_nullValue(entity.PRESENTISMO)
				else
					entity.PRESENTISMO = F_ValueToBoolean(reader("PRESENTISMO"))
				end if		
				if reader("MEDIOPRESENTISMO") is System.DbNull.Value then
					entity.MEDIOPRESENTISMO = F_Set_nullValue(entity.MEDIOPRESENTISMO)
				else
					entity.MEDIOPRESENTISMO = F_ValueToBoolean(reader("MEDIOPRESENTISMO"))
				end if		
		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la Liquidacion"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function

	
	Private Function Make(row as DataRow, Optional ByVal ThrowErr As Boolean = False) as Liquidacion
		Dim entity as Liquidacion
		Try
		
			entity = new Liquidacion
			entity.[New] = false

	if F_Contains(row, "ID") then
		if row("ID") is System.DbNull.Value then
			entity.ID = F_Set_nullValue(entity.ID)
		else
			entity.ID = CType(row("ID"),Long)
		end if
	end if
	if F_Contains(row, "FECHALIQUDACION") then
		if row("FECHALIQUDACION") is System.DbNull.Value then
			entity.FECHALIQUDACION = F_Set_nullValue(entity.FECHALIQUDACION)
		else
			entity.FECHALIQUDACION = CType(row("FECHALIQUDACION"),DateTime)
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
	if F_Contains(row, "IDCONVENIO") then
		if row("IDCONVENIO") is System.DbNull.Value then
			entity.IDCONVENIO = F_Set_nullValue(entity.IDCONVENIO)
		else
			entity.IDCONVENIO = CType(row("IDCONVENIO"),Long)
		end if
	end if
	if F_Contains(row, "IDCONVENIO_Desc") then
		if row("IDCONVENIO_Desc") is System.DbNull.Value then
			entity.IDCONVENIO_Desc = F_Set_nullValue(entity.IDCONVENIO_Desc)
		else
			entity.IDCONVENIO_Desc = CType(row("IDCONVENIO_Desc"),String)
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
	if F_Contains(row, "AUSENCIASCONPRESENTISMO") then
		if row("AUSENCIASCONPRESENTISMO") is System.DbNull.Value then
			entity.AUSENCIASCONPRESENTISMO = F_Set_nullValue(entity.AUSENCIASCONPRESENTISMO)
		else
			entity.AUSENCIASCONPRESENTISMO = CType(row("AUSENCIASCONPRESENTISMO"),Integer)
		end if
	end if
	if F_Contains(row, "AUSENCIASJUSTIFICADAS") then
		if row("AUSENCIASJUSTIFICADAS") is System.DbNull.Value then
			entity.AUSENCIASJUSTIFICADAS = F_Set_nullValue(entity.AUSENCIASJUSTIFICADAS)
		else
			entity.AUSENCIASJUSTIFICADAS = CType(row("AUSENCIASJUSTIFICADAS"),Integer)
		end if
	end if
	if F_Contains(row, "AUSENCIASINJUSTIFICADAS") then
		if row("AUSENCIASINJUSTIFICADAS") is System.DbNull.Value then
			entity.AUSENCIASINJUSTIFICADAS = F_Set_nullValue(entity.AUSENCIASINJUSTIFICADAS)
		else
			entity.AUSENCIASINJUSTIFICADAS = CType(row("AUSENCIASINJUSTIFICADAS"),Integer)
		end if
	end if
	if F_Contains(row, "DIASTRABAJADOS") then
		if row("DIASTRABAJADOS") is System.DbNull.Value then
			entity.DIASTRABAJADOS = F_Set_nullValue(entity.DIASTRABAJADOS)
		else
			entity.DIASTRABAJADOS = CType(row("DIASTRABAJADOS"),Integer)
		end if
	end if
	if F_Contains(row, "DIASSINPRESENTISMO") then
		if row("DIASSINPRESENTISMO") is System.DbNull.Value then
			entity.DIASSINPRESENTISMO = F_Set_nullValue(entity.DIASSINPRESENTISMO)
		else
			entity.DIASSINPRESENTISMO = CType(row("DIASSINPRESENTISMO"),Integer)
		end if
	end if
	if F_Contains(row, "DIASMEDIOPRESENTISMO") then
		if row("DIASMEDIOPRESENTISMO") is System.DbNull.Value then
			entity.DIASMEDIOPRESENTISMO = F_Set_nullValue(entity.DIASMEDIOPRESENTISMO)
		else
			entity.DIASMEDIOPRESENTISMO = CType(row("DIASMEDIOPRESENTISMO"),Integer)
		end if
	end if
	if F_Contains(row, "MINUTOSTARDE") then
		if row("MINUTOSTARDE") is System.DbNull.Value then
			entity.MINUTOSTARDE = F_Set_nullValue(entity.MINUTOSTARDE)
		else
			entity.MINUTOSTARDE = CType(row("MINUTOSTARDE"),Integer)
		end if
	end if
	if F_Contains(row, "INCONSISTENCIAS") then
		if row("INCONSISTENCIAS") is System.DbNull.Value then
			entity.INCONSISTENCIAS = F_Set_nullValue(entity.INCONSISTENCIAS)
		else
			entity.INCONSISTENCIAS = CType(row("INCONSISTENCIAS"),Integer)
		end if
	end if
	if F_Contains(row, "PRESENTISMO") then
		if row("PRESENTISMO") is System.DbNull.Value then
			entity.PRESENTISMO = F_Set_nullValue(entity.PRESENTISMO)
		else
			entity.PRESENTISMO = F_ValueToBoolean(row("PRESENTISMO"))
		end if
	end if
	if F_Contains(row, "MEDIOPRESENTISMO") then
		if row("MEDIOPRESENTISMO") is System.DbNull.Value then
			entity.MEDIOPRESENTISMO = F_Set_nullValue(entity.MEDIOPRESENTISMO)
		else
			entity.MEDIOPRESENTISMO = F_ValueToBoolean(row("MEDIOPRESENTISMO"))
		end if
	end if

		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la Liquidacion"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function
	
#End Region

Public Function GetTodoEntreFechas(Byval FECHADESDE as Date, Byval FECHAHASTA as Date
) As List (of Liquidacion)
        Dim sql As String = "A_LIQUIDACIONGETENTREFECHAS"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Liquidacion)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHADESDE_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHADESDE)
		
			par = CType(oParams.Item("@FECHAHASTA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAHASTA)
		
			Dim entity As Liquidacion
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

Public Function GetTodoEntreFechasLiq(Byval FECHADESDE as Date, Byval FECHAHASTA as Date
) As List (of Liquidacion)
        Dim sql As String = "A_LIQUIDACIONGETENTREFECLIQ"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Liquidacion)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHADESDE_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHADESDE)
		
			par = CType(oParams.Item("@FECHAHASTA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAHASTA)
		
			Dim entity As Liquidacion
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

Public Function GetTodoByidEmpleado(Byval IDEMPLEADO as Integer
) As List (of Liquidacion)
        Dim sql As String = "A_LIQUIDACIONGETBYIDEMP"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Liquidacion)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@IDEMPLEADO_I"), IDataParameter)
			par.Value = F_ValueToNull(IDEMPLEADO)
		
			Dim entity As Liquidacion
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

