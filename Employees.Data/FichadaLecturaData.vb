
'
'	Project Employees
'		Employees Example
'	Entity	FichadaLectura
'		FichadaLectura Entity
'	
'

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Conexion

Imports Employees.Entities

Public Partial Class FichadaLecturaData
	Inherits BaseData

	Public Sub New()
		MyBase.New()
	End Sub

#Region "Metodos Publicos"

	Public Overloads Function Insert(ByVal Entity As FichadaLectura, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Insert(Entity.Table, Entity.DirtyFields)
    End Function

    Public Overloads Function Update(ByVal Entity As FichadaLectura, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Update(Entity.Table, Entity.KeyFields, Entity.DirtyFields)
    End Function
	
	Public function InsertSP(Entity as FichadaLectura, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_FichadaLectura_I"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@IDEMPLEADOLECTORA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDEMPLEADOLECTORA)
			par = CType(oParams.Item("@IDEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDEMPLEADO)
			par = CType(oParams.Item("@FECHAFICHADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAFICHADA)
			par = CType(oParams.Item("@IDRELOJ"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDRELOJ)
			par = CType(oParams.Item("@FECHALECTURA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHALECTURA)
			par = CType(oParams.Item("@TIPOFICHADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.TIPOFICHADA)
			par = CType(oParams.Item("@OBSERVACIONESPROCESO"), IDataParameter)
			par.Value = F_ValueToNull(entity.OBSERVACIONESPROCESO)
			par = CType(oParams.Item("@TIPOFICHADASUPERVISOR"), IDataParameter)
			par.Value = F_ValueToNull(entity.TIPOFICHADASUPERVISOR)
			par = CType(oParams.Item("@IDUSUARIOSUPERVISORCAMBIO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOSUPERVISORCAMBIO)
			par = CType(oParams.Item("@FECHAFICHADASUPERVISOR"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAFICHADASUPERVISOR)
			par = CType(oParams.Item("@INCONSISTENCIA"), IDataParameter)
			par.Value = F_BooleanToValue(entity.INCONSISTENCIA, par)
			par = CType(oParams.Item("@DESCARTADA"), IDataParameter)
			par.Value = F_BooleanToValue(entity.DESCARTADA, par)

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
				bOk = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo insertar la FichadaLectura"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If
			par = CType(oParams.Item("@ID"), IDataParameter)
			Entity.ID = par.Value 
			par = CType(oParams.Item("@FECHALECTURA"), IDataParameter)
			Entity.FECHALECTURA = par.Value 
		Catch ex As Exception
			MyBase.ConError = True
		MyBase.Exception = ex
		MyBase.Error = "No se pudo insertar la FichadaLectura"
		MyBase.InternalError = ex.Message
		bOk = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bOk
	End Function

	Public function UpdateSP(Entity as FichadaLectura, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_FichadaLectura_U"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@ID"), IDataParameter)
			par.Value = F_ValueToNull(entity.ID)
			par = CType(oParams.Item("@IDEMPLEADOLECTORA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDEMPLEADOLECTORA)
			par = CType(oParams.Item("@IDEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDEMPLEADO)
			par = CType(oParams.Item("@FECHAFICHADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAFICHADA)
			par = CType(oParams.Item("@IDRELOJ"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDRELOJ)
			par = CType(oParams.Item("@TIPOFICHADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.TIPOFICHADA)
			par = CType(oParams.Item("@FECHAPROCESO"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAPROCESO)
			par = CType(oParams.Item("@OBSERVACIONESPROCESO"), IDataParameter)
			par.Value = F_ValueToNull(entity.OBSERVACIONESPROCESO)
			par = CType(oParams.Item("@TIPOFICHADASUPERVISOR"), IDataParameter)
			par.Value = F_ValueToNull(entity.TIPOFICHADASUPERVISOR)
			par = CType(oParams.Item("@IDUSUARIOSUPERVISORCAMBIO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOSUPERVISORCAMBIO)
			par = CType(oParams.Item("@FECHAFICHADASUPERVISOR"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAFICHADASUPERVISOR)
			par = CType(oParams.Item("@INCONSISTENCIA"), IDataParameter)
			par.Value = F_BooleanToValue(entity.INCONSISTENCIA, par)
			par = CType(oParams.Item("@DESCARTADA"), IDataParameter)
			par.Value = F_BooleanToValue(entity.DESCARTADA, par)
	
            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) >= 0 Then
				bok = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo actualizar la FichadaLectura"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If

			
		Catch ex As Exception
			MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo actualizar la FichadaLectura"
            MyBase.InternalError = ex.Message
			bok = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bok
	End Function

	Public Function GetDtTableById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String = "A_FichadaLecturaGetById"
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
        Dim sql As String  = "A_FichadaLecturaGetById"		
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
			MyBase.Error = "No se pudo buscar la FichadaLectura"
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()	
		End Try
		
		Return drDatos
	End Function

	Public Function GetEntityById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As FichadaLectura
		Dim entity as FichadaLectura
	    Dim DtDatos As DataTable
		try
			DtDatos = GetDtTableById(ID, ThrowErr)
			If DtDatos.Rows.Count > 0 Then entity = Make(DtDatos.Rows(0))
        Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo buscar la FichadaLectura"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()
		End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As FichadaLectura, Optional ByVal ThrowErr As Boolean = False) As List(Of FichadaLectura)
        Dim DtDatos As DataTable
        Dim listEntities As New List(Of FichadaLectura)
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
            MyBase.Error = "No se pudo buscar la FichadaLectura"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return listEntities
    End Function
	
	Private Function Make(reader as IDataReader, Optional ByVal ThrowErr As Boolean = False) as FichadaLectura
		Dim entity as FichadaLectura
		Try
			entity = new FichadaLectura
			entity.[New] = false
				if reader("ID") is System.DbNull.Value then
					entity.ID = F_Set_nullValue(entity.ID)
				else
					entity.ID = CType(reader("ID"),Long)
				end if		
				if reader("IDEMPLEADOLECTORA") is System.DbNull.Value then
					entity.IDEMPLEADOLECTORA = F_Set_nullValue(entity.IDEMPLEADOLECTORA)
				else
					entity.IDEMPLEADOLECTORA = CType(reader("IDEMPLEADOLECTORA"),String)
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
				if reader("FECHAFICHADA") is System.DbNull.Value then
					entity.FECHAFICHADA = F_Set_nullValue(entity.FECHAFICHADA)
				else
					entity.FECHAFICHADA = CType(reader("FECHAFICHADA"),DateTime)
				end if		
				if reader("IDRELOJ") is System.DbNull.Value then
					entity.IDRELOJ = F_Set_nullValue(entity.IDRELOJ)
				else
					entity.IDRELOJ = CType(reader("IDRELOJ"),String)
				end if		
				if reader("IDRELOJ_Desc") is System.DbNull.Value then
					entity.IDRELOJ_Desc = F_Set_nullValue(entity.IDRELOJ_Desc)
				else
					entity.IDRELOJ_Desc = CType(reader("IDRELOJ_Desc"),String)
				end if		
				if reader("FECHALECTURA") is System.DbNull.Value then
					entity.FECHALECTURA = F_Set_nullValue(entity.FECHALECTURA)
				else
					entity.FECHALECTURA = CType(reader("FECHALECTURA"),DateTime)
				end if		
				if reader("TIPOFICHADA") is System.DbNull.Value then
					entity.TIPOFICHADA = F_Set_nullValue(entity.TIPOFICHADA)
				else
					entity.TIPOFICHADA = CType(reader("TIPOFICHADA"),String)
				end if		
				if reader("FECHAPROCESO") is System.DbNull.Value then
					entity.FECHAPROCESO = F_Set_nullValue(entity.FECHAPROCESO)
				else
					entity.FECHAPROCESO = CType(reader("FECHAPROCESO"),DateTime)
				end if		
				if reader("OBSERVACIONESPROCESO") is System.DbNull.Value then
					entity.OBSERVACIONESPROCESO = F_Set_nullValue(entity.OBSERVACIONESPROCESO)
				else
					entity.OBSERVACIONESPROCESO = CType(reader("OBSERVACIONESPROCESO"),String)
				end if		
				if reader("TIPOFICHADASUPERVISOR") is System.DbNull.Value then
					entity.TIPOFICHADASUPERVISOR = F_Set_nullValue(entity.TIPOFICHADASUPERVISOR)
				else
					entity.TIPOFICHADASUPERVISOR = CType(reader("TIPOFICHADASUPERVISOR"),String)
				end if		
				if reader("IDUSUARIOSUPERVISORCAMBIO") is System.DbNull.Value then
					entity.IDUSUARIOSUPERVISORCAMBIO = F_Set_nullValue(entity.IDUSUARIOSUPERVISORCAMBIO)
				else
					entity.IDUSUARIOSUPERVISORCAMBIO = CType(reader("IDUSUARIOSUPERVISORCAMBIO"),String)
				end if		
				if reader("IDUSUARIOSUPERVISORCAMBIO_Desc") is System.DbNull.Value then
					entity.IDUSUARIOSUPERVISORCAMBIO_Desc = F_Set_nullValue(entity.IDUSUARIOSUPERVISORCAMBIO_Desc)
				else
					entity.IDUSUARIOSUPERVISORCAMBIO_Desc = CType(reader("IDUSUARIOSUPERVISORCAMBIO_Desc"),String)
				end if		
				if reader("FECHAFICHADASUPERVISOR") is System.DbNull.Value then
					entity.FECHAFICHADASUPERVISOR = F_Set_nullValue(entity.FECHAFICHADASUPERVISOR)
				else
					entity.FECHAFICHADASUPERVISOR = CType(reader("FECHAFICHADASUPERVISOR"),DateTime)
				end if		
				if reader("INCONSISTENCIA") is System.DbNull.Value then
					entity.INCONSISTENCIA = F_Set_nullValue(entity.INCONSISTENCIA)
				else
					entity.INCONSISTENCIA = F_ValueToBoolean(reader("INCONSISTENCIA"))
				end if		
				if reader("DESCARTADA") is System.DbNull.Value then
					entity.DESCARTADA = F_Set_nullValue(entity.DESCARTADA)
				else
					entity.DESCARTADA = F_ValueToBoolean(reader("DESCARTADA"))
				end if		
		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la FichadaLectura"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function

	
	Private Function Make(row as DataRow, Optional ByVal ThrowErr As Boolean = False) as FichadaLectura
		Dim entity as FichadaLectura
		Try
		
			entity = new FichadaLectura
			entity.[New] = false

	if F_Contains(row, "ID") then
		if row("ID") is System.DbNull.Value then
			entity.ID = F_Set_nullValue(entity.ID)
		else
			entity.ID = CType(row("ID"),Long)
		end if
	end if
	if F_Contains(row, "IDEMPLEADOLECTORA") then
		if row("IDEMPLEADOLECTORA") is System.DbNull.Value then
			entity.IDEMPLEADOLECTORA = F_Set_nullValue(entity.IDEMPLEADOLECTORA)
		else
			entity.IDEMPLEADOLECTORA = CType(row("IDEMPLEADOLECTORA"),String)
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
	if F_Contains(row, "FECHAFICHADA") then
		if row("FECHAFICHADA") is System.DbNull.Value then
			entity.FECHAFICHADA = F_Set_nullValue(entity.FECHAFICHADA)
		else
			entity.FECHAFICHADA = CType(row("FECHAFICHADA"),DateTime)
		end if
	end if
	if F_Contains(row, "IDRELOJ") then
		if row("IDRELOJ") is System.DbNull.Value then
			entity.IDRELOJ = F_Set_nullValue(entity.IDRELOJ)
		else
			entity.IDRELOJ = CType(row("IDRELOJ"),String)
		end if
	end if
	if F_Contains(row, "IDRELOJ_Desc") then
		if row("IDRELOJ_Desc") is System.DbNull.Value then
			entity.IDRELOJ_Desc = F_Set_nullValue(entity.IDRELOJ_Desc)
		else
			entity.IDRELOJ_Desc = CType(row("IDRELOJ_Desc"),String)
		end if
	end if
	if F_Contains(row, "FECHALECTURA") then
		if row("FECHALECTURA") is System.DbNull.Value then
			entity.FECHALECTURA = F_Set_nullValue(entity.FECHALECTURA)
		else
			entity.FECHALECTURA = CType(row("FECHALECTURA"),DateTime)
		end if
	end if
	if F_Contains(row, "TIPOFICHADA") then
		if row("TIPOFICHADA") is System.DbNull.Value then
			entity.TIPOFICHADA = F_Set_nullValue(entity.TIPOFICHADA)
		else
			entity.TIPOFICHADA = CType(row("TIPOFICHADA"),String)
		end if
	end if
	if F_Contains(row, "FECHAPROCESO") then
		if row("FECHAPROCESO") is System.DbNull.Value then
			entity.FECHAPROCESO = F_Set_nullValue(entity.FECHAPROCESO)
		else
			entity.FECHAPROCESO = CType(row("FECHAPROCESO"),DateTime)
		end if
	end if
	if F_Contains(row, "OBSERVACIONESPROCESO") then
		if row("OBSERVACIONESPROCESO") is System.DbNull.Value then
			entity.OBSERVACIONESPROCESO = F_Set_nullValue(entity.OBSERVACIONESPROCESO)
		else
			entity.OBSERVACIONESPROCESO = CType(row("OBSERVACIONESPROCESO"),String)
		end if
	end if
	if F_Contains(row, "TIPOFICHADASUPERVISOR") then
		if row("TIPOFICHADASUPERVISOR") is System.DbNull.Value then
			entity.TIPOFICHADASUPERVISOR = F_Set_nullValue(entity.TIPOFICHADASUPERVISOR)
		else
			entity.TIPOFICHADASUPERVISOR = CType(row("TIPOFICHADASUPERVISOR"),String)
		end if
	end if
	if F_Contains(row, "IDUSUARIOSUPERVISORCAMBIO") then
		if row("IDUSUARIOSUPERVISORCAMBIO") is System.DbNull.Value then
			entity.IDUSUARIOSUPERVISORCAMBIO = F_Set_nullValue(entity.IDUSUARIOSUPERVISORCAMBIO)
		else
			entity.IDUSUARIOSUPERVISORCAMBIO = CType(row("IDUSUARIOSUPERVISORCAMBIO"),String)
		end if
	end if
	if F_Contains(row, "IDUSUARIOSUPERVISORCAMBIO_Desc") then
		if row("IDUSUARIOSUPERVISORCAMBIO_Desc") is System.DbNull.Value then
			entity.IDUSUARIOSUPERVISORCAMBIO_Desc = F_Set_nullValue(entity.IDUSUARIOSUPERVISORCAMBIO_Desc)
		else
			entity.IDUSUARIOSUPERVISORCAMBIO_Desc = CType(row("IDUSUARIOSUPERVISORCAMBIO_Desc"),String)
		end if
	end if
	if F_Contains(row, "FECHAFICHADASUPERVISOR") then
		if row("FECHAFICHADASUPERVISOR") is System.DbNull.Value then
			entity.FECHAFICHADASUPERVISOR = F_Set_nullValue(entity.FECHAFICHADASUPERVISOR)
		else
			entity.FECHAFICHADASUPERVISOR = CType(row("FECHAFICHADASUPERVISOR"),DateTime)
		end if
	end if
	if F_Contains(row, "INCONSISTENCIA") then
		if row("INCONSISTENCIA") is System.DbNull.Value then
			entity.INCONSISTENCIA = F_Set_nullValue(entity.INCONSISTENCIA)
		else
			entity.INCONSISTENCIA = F_ValueToBoolean(row("INCONSISTENCIA"))
		end if
	end if
	if F_Contains(row, "DESCARTADA") then
		if row("DESCARTADA") is System.DbNull.Value then
			entity.DESCARTADA = F_Set_nullValue(entity.DESCARTADA)
		else
			entity.DESCARTADA = F_ValueToBoolean(row("DESCARTADA"))
		end if
	end if

		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la FichadaLectura"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function
	
#End Region

Public Function GetRepetido(Byval IDEMPLEADOLECTORA as String, Byval FECHAFICHADA as Date, Byval IDRELOJ as String, Byval TIPOFICHADA as String
) As List (of FichadaLectura)
        Dim sql As String = "A_FICHADALECTURAGETREPETIDO"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of FichadaLectura)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@IDEMPLEADOLECTORA_I"), IDataParameter)
			par.Value = F_ValueToNull(IDEMPLEADOLECTORA)
		
			par = CType(oParams.Item("@FECHAFICHADA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAFICHADA)
		
			par = CType(oParams.Item("@IDRELOJ_I"), IDataParameter)
			par.Value = F_ValueToNull(IDRELOJ)
		
			par = CType(oParams.Item("@TIPOFICHADA_I"), IDataParameter)
			par.Value = F_ValueToNull(TIPOFICHADA)
		
			Dim entity As FichadaLectura
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

Public Function GetHuerfanos() As List (of FichadaLectura)
        Dim sql As String = "A_FICHADALECTURAGETHUERFANOS"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of FichadaLectura)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			Dim entity As FichadaLectura
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

Public Function GetxIdEmpleadoSinProcesar(Byval IDEMPLEADO as Integer
) As List (of FichadaLectura)
        Dim sql As String = "A_FICHADALECTURAGETSINPROCESAR"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of FichadaLectura)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@IDEMPLEADO_I"), IDataParameter)
			par.Value = F_ValueToNull(IDEMPLEADO)
		
			Dim entity As FichadaLectura
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

Public Function GetTodoEntreFechas(Byval FECHADESDE as Date, Byval FECHAHASTA as Date
) As List (of FichadaLectura)
        Dim sql As String = "A_FICHADALECTURAGETENTREFECHAS"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of FichadaLectura)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHADESDE_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHADESDE)
		
			par = CType(oParams.Item("@FECHAHASTA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAHASTA)
		
			Dim entity As FichadaLectura
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

Public Function GetTodoEntreFechasGrupo(Byval FECHADESDE as Date, Byval FECHAHASTA as Date, Byval IDGRUPO as Integer
) As List (of FichadaLectura)
        Dim sql As String = "A_FICHADALECTURAGETFECGRP"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of FichadaLectura)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHADESDE_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHADESDE)
		
			par = CType(oParams.Item("@FECHAHASTA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAHASTA)
		
			par = CType(oParams.Item("@IDGRUPO_I"), IDataParameter)
			par.Value = F_ValueToNull(IDGRUPO)
		
			Dim entity As FichadaLectura
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

