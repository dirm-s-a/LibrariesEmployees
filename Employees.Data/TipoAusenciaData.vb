
'
'	Project Employees
'		Employees Example
'	Entity	TipoAusencia
'		TipoAusencia Entity
'	
'

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Conexion

Imports Employees.Entities

Public Partial Class TipoAusenciaData
	Inherits BaseData

	Public Sub New()
		MyBase.New()
	End Sub

#Region "Metodos Publicos"

	Public Overloads Function Insert(ByVal Entity As TipoAusencia, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Insert(Entity.Table, Entity.DirtyFields)
    End Function

    Public Overloads Function Update(ByVal Entity As TipoAusencia, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Update(Entity.Table, Entity.KeyFields, Entity.DirtyFields)
    End Function
	
	Public function InsertSP(Entity as TipoAusencia, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_TipoAusencia_I"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@DESCRIPCION"), IDataParameter)
			par.Value = F_ValueToNull(entity.DESCRIPCION)
			par = CType(oParams.Item("@JUSTIFICADA"), IDataParameter)
			par.Value = F_BooleanToValue(entity.JUSTIFICADA, par)
			par = CType(oParams.Item("@PIERDEPRESENTISMO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.PIERDEPRESENTISMO, par)
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

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
				bOk = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo insertar la TipoAusencia"
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
		MyBase.Error = "No se pudo insertar la TipoAusencia"
		MyBase.InternalError = ex.Message
		bOk = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bOk
	End Function

	Public function UpdateSP(Entity as TipoAusencia, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_TipoAusencia_U"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@ID"), IDataParameter)
			par.Value = F_ValueToNull(entity.ID)
			par = CType(oParams.Item("@DESCRIPCION"), IDataParameter)
			par.Value = F_ValueToNull(entity.DESCRIPCION)
			par = CType(oParams.Item("@JUSTIFICADA"), IDataParameter)
			par.Value = F_BooleanToValue(entity.JUSTIFICADA, par)
			par = CType(oParams.Item("@PIERDEPRESENTISMO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.PIERDEPRESENTISMO, par)
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
	
            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) >= 0 Then
				bok = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo actualizar la TipoAusencia"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If

			par = CType(oParams.Item("@FECHAMODIFICACION"), IDataParameter)
			Entity.FECHAMODIFICACION = par.Value 
			
		Catch ex As Exception
			MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo actualizar la TipoAusencia"
            MyBase.InternalError = ex.Message
			bok = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bok
	End Function

	Public Function GetDtTableById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String = "A_TipoAusenciaGetById"
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
        Dim sql As String  = "A_TipoAusenciaGetById"		
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
			MyBase.Error = "No se pudo buscar la TipoAusencia"
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()	
		End Try
		
		Return drDatos
	End Function

	Public Function GetEntityById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As TipoAusencia
		Dim entity as TipoAusencia
	    Dim DtDatos As DataTable
		try
			DtDatos = GetDtTableById(ID, ThrowErr)
			If DtDatos.Rows.Count > 0 Then entity = Make(DtDatos.Rows(0))
        Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo buscar la TipoAusencia"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()
		End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As TipoAusencia, Optional ByVal ThrowErr As Boolean = False) As List(Of TipoAusencia)
        Dim DtDatos As DataTable
        Dim listEntities As New List(Of TipoAusencia)
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
            MyBase.Error = "No se pudo buscar la TipoAusencia"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return listEntities
    End Function
	
	Private Function Make(reader as IDataReader, Optional ByVal ThrowErr As Boolean = False) as TipoAusencia
		Dim entity as TipoAusencia
		Try
			entity = new TipoAusencia
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
				if reader("JUSTIFICADA") is System.DbNull.Value then
					entity.JUSTIFICADA = F_Set_nullValue(entity.JUSTIFICADA)
				else
					entity.JUSTIFICADA = F_ValueToBoolean(reader("JUSTIFICADA"))
				end if		
				if reader("PIERDEPRESENTISMO") is System.DbNull.Value then
					entity.PIERDEPRESENTISMO = F_Set_nullValue(entity.PIERDEPRESENTISMO)
				else
					entity.PIERDEPRESENTISMO = F_ValueToBoolean(reader("PIERDEPRESENTISMO"))
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
		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la TipoAusencia"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function

	
	Private Function Make(row as DataRow, Optional ByVal ThrowErr As Boolean = False) as TipoAusencia
		Dim entity as TipoAusencia
		Try
		
			entity = new TipoAusencia
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
	if F_Contains(row, "JUSTIFICADA") then
		if row("JUSTIFICADA") is System.DbNull.Value then
			entity.JUSTIFICADA = F_Set_nullValue(entity.JUSTIFICADA)
		else
			entity.JUSTIFICADA = F_ValueToBoolean(row("JUSTIFICADA"))
		end if
	end if
	if F_Contains(row, "PIERDEPRESENTISMO") then
		if row("PIERDEPRESENTISMO") is System.DbNull.Value then
			entity.PIERDEPRESENTISMO = F_Set_nullValue(entity.PIERDEPRESENTISMO)
		else
			entity.PIERDEPRESENTISMO = F_ValueToBoolean(row("PIERDEPRESENTISMO"))
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

		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la TipoAusencia"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function
	
#End Region

Public Function GetALL() As List (of TipoAusencia)
        Dim sql As String = "A_TipoAusenciaGETALL"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of TipoAusencia)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			Dim entity As TipoAusencia
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

