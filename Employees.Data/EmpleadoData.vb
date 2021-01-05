
'
'	Project Employees
'		Employees Example
'	Entity	Empleado
'		Empleado Entity
'	
'

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Conexion

Imports Employees.Entities

Public Partial Class EmpleadoData
	Inherits BaseData

	Public Sub New()
		MyBase.New()
	End Sub

#Region "Metodos Publicos"

	Public Overloads Function Insert(ByVal Entity As Empleado, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Insert(Entity.Table, Entity.DirtyFields)
    End Function

    Public Overloads Function Update(ByVal Entity As Empleado, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Update(Entity.Table, Entity.KeyFields, Entity.DirtyFields)
    End Function
	
	Public function InsertSP(Entity as Empleado, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Empleado_I"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@NOMBRE"), IDataParameter)
			par.Value = F_ValueToNull(entity.NOMBRE)
			par = CType(oParams.Item("@SECTOR"), IDataParameter)
			par.Value = F_ValueToNull(entity.SECTOR)
			par = CType(oParams.Item("@NRODOCUMENTO"), IDataParameter)
			par.Value = F_ValueToNull(entity.NRODOCUMENTO)
			par = CType(oParams.Item("@INACTIVO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.INACTIVO, par)
			par = CType(oParams.Item("@FECHABAJA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHABAJA)
			par = CType(oParams.Item("@IDUSUARIO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIO)
			par = CType(oParams.Item("@EMAIL"), IDataParameter)
			par.Value = F_ValueToNull(entity.EMAIL)
			par = CType(oParams.Item("@IDCONVENIO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDCONVENIO)
			par = CType(oParams.Item("@IDUSUARIOALTA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOALTA)
			par = CType(oParams.Item("@FECHAALTA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAALTA)
			par = CType(oParams.Item("@IDUSUARIOMODIFICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOMODIFICACION)
			par = CType(oParams.Item("@FECHAMODIFICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAMODIFICACION)

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
				bOk = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo insertar la Empleado"
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
		MyBase.Error = "No se pudo insertar la Empleado"
		MyBase.InternalError = ex.Message
		bOk = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bOk
	End Function

	Public function UpdateSP(Entity as Empleado, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Empleado_U"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@ID"), IDataParameter)
			par.Value = F_ValueToNull(entity.ID)
			par = CType(oParams.Item("@NOMBRE"), IDataParameter)
			par.Value = F_ValueToNull(entity.NOMBRE)
			par = CType(oParams.Item("@SECTOR"), IDataParameter)
			par.Value = F_ValueToNull(entity.SECTOR)
			par = CType(oParams.Item("@NRODOCUMENTO"), IDataParameter)
			par.Value = F_ValueToNull(entity.NRODOCUMENTO)
			par = CType(oParams.Item("@INACTIVO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.INACTIVO, par)
			par = CType(oParams.Item("@FECHABAJA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHABAJA)
			par = CType(oParams.Item("@IDUSUARIO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIO)
			par = CType(oParams.Item("@EMAIL"), IDataParameter)
			par.Value = F_ValueToNull(entity.EMAIL)
			par = CType(oParams.Item("@IDCONVENIO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDCONVENIO)
			par = CType(oParams.Item("@IDUSUARIOALTA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOALTA)
			par = CType(oParams.Item("@FECHAALTA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAALTA)
			par = CType(oParams.Item("@IDUSUARIOMODIFICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOMODIFICACION)
			par = CType(oParams.Item("@FECHAMODIFICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAMODIFICACION)
	
            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) >= 0 Then
				bok = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo actualizar la Empleado"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If

			par = CType(oParams.Item("@FECHAMODIFICACION"), IDataParameter)
			Entity.FECHAMODIFICACION = par.Value 
			
		Catch ex As Exception
			MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo actualizar la Empleado"
            MyBase.InternalError = ex.Message
			bok = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bok
	End Function

	Public Function GetDtTableById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String = "A_EmpleadoGetById"
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
        Dim sql As String  = "A_EmpleadoGetById"		
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
			MyBase.Error = "No se pudo buscar la Empleado"
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()	
		End Try
		
		Return drDatos
	End Function

	Public Function GetEntityById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As Empleado
		Dim entity as Empleado
	    Dim DtDatos As DataTable
		try
			DtDatos = GetDtTableById(ID, ThrowErr)
			If DtDatos.Rows.Count > 0 Then entity = Make(DtDatos.Rows(0))
        Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo buscar la Empleado"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()
		End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As Empleado, Optional ByVal ThrowErr As Boolean = False) As List(Of Empleado)
        Dim DtDatos As DataTable
        Dim listEntities As New List(Of Empleado)
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
            MyBase.Error = "No se pudo buscar la Empleado"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return listEntities
    End Function
	
	Private Function Make(reader as IDataReader, Optional ByVal ThrowErr As Boolean = False) as Empleado
		Dim entity as Empleado
		Try
			entity = new Empleado
			entity.[New] = false
				if reader("ID") is System.DbNull.Value then
					entity.ID = F_Set_nullValue(entity.ID)
				else
					entity.ID = CType(reader("ID"),Long)
				end if		
				if reader("NOMBRE") is System.DbNull.Value then
					entity.NOMBRE = F_Set_nullValue(entity.NOMBRE)
				else
					entity.NOMBRE = CType(reader("NOMBRE"),String)
				end if		
				if reader("SECTOR") is System.DbNull.Value then
					entity.SECTOR = F_Set_nullValue(entity.SECTOR)
				else
					entity.SECTOR = CType(reader("SECTOR"),String)
				end if		
				if reader("NRODOCUMENTO") is System.DbNull.Value then
					entity.NRODOCUMENTO = F_Set_nullValue(entity.NRODOCUMENTO)
				else
					entity.NRODOCUMENTO = CType(reader("NRODOCUMENTO"),String)
				end if		
				if reader("INACTIVO") is System.DbNull.Value then
					entity.INACTIVO = F_Set_nullValue(entity.INACTIVO)
				else
					entity.INACTIVO = F_ValueToBoolean(reader("INACTIVO"))
				end if		
				if reader("FECHABAJA") is System.DbNull.Value then
					entity.FECHABAJA = F_Set_nullValue(entity.FECHABAJA)
				else
					entity.FECHABAJA = CType(reader("FECHABAJA"),DateTime)
				end if		
				if reader("IDUSUARIO") is System.DbNull.Value then
					entity.IDUSUARIO = F_Set_nullValue(entity.IDUSUARIO)
				else
					entity.IDUSUARIO = CType(reader("IDUSUARIO"),String)
				end if		
				if reader("IDUSUARIO_Desc") is System.DbNull.Value then
					entity.IDUSUARIO_Desc = F_Set_nullValue(entity.IDUSUARIO_Desc)
				else
					entity.IDUSUARIO_Desc = CType(reader("IDUSUARIO_Desc"),String)
				end if		
				if reader("EMAIL") is System.DbNull.Value then
					entity.EMAIL = F_Set_nullValue(entity.EMAIL)
				else
					entity.EMAIL = CType(reader("EMAIL"),String)
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
				if reader("IDUSUARIOALTA") is System.DbNull.Value then
					entity.IDUSUARIOALTA = F_Set_nullValue(entity.IDUSUARIOALTA)
				else
					entity.IDUSUARIOALTA = CType(reader("IDUSUARIOALTA"),String)
				end if		
				if reader("IDUSUARIOALTA_Desc") is System.DbNull.Value then
					entity.IDUSUARIOALTA_Desc = F_Set_nullValue(entity.IDUSUARIOALTA_Desc)
				else
					entity.IDUSUARIOALTA_Desc = CType(reader("IDUSUARIOALTA_Desc"),String)
				end if		
				if reader("FECHAALTA") is System.DbNull.Value then
					entity.FECHAALTA = F_Set_nullValue(entity.FECHAALTA)
				else
					entity.FECHAALTA = CType(reader("FECHAALTA"),DateTime)
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
				if reader("FECHAMODIFICACION") is System.DbNull.Value then
					entity.FECHAMODIFICACION = F_Set_nullValue(entity.FECHAMODIFICACION)
				else
					entity.FECHAMODIFICACION = CType(reader("FECHAMODIFICACION"),DateTime)
				end if		
		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la Empleado"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function

	
	Private Function Make(row as DataRow, Optional ByVal ThrowErr As Boolean = False) as Empleado
		Dim entity as Empleado
		Try
		
			entity = new Empleado
			entity.[New] = false

	if F_Contains(row, "ID") then
		if row("ID") is System.DbNull.Value then
			entity.ID = F_Set_nullValue(entity.ID)
		else
			entity.ID = CType(row("ID"),Long)
		end if
	end if
	if F_Contains(row, "NOMBRE") then
		if row("NOMBRE") is System.DbNull.Value then
			entity.NOMBRE = F_Set_nullValue(entity.NOMBRE)
		else
			entity.NOMBRE = CType(row("NOMBRE"),String)
		end if
	end if
	if F_Contains(row, "SECTOR") then
		if row("SECTOR") is System.DbNull.Value then
			entity.SECTOR = F_Set_nullValue(entity.SECTOR)
		else
			entity.SECTOR = CType(row("SECTOR"),String)
		end if
	end if
	if F_Contains(row, "NRODOCUMENTO") then
		if row("NRODOCUMENTO") is System.DbNull.Value then
			entity.NRODOCUMENTO = F_Set_nullValue(entity.NRODOCUMENTO)
		else
			entity.NRODOCUMENTO = CType(row("NRODOCUMENTO"),String)
		end if
	end if
	if F_Contains(row, "INACTIVO") then
		if row("INACTIVO") is System.DbNull.Value then
			entity.INACTIVO = F_Set_nullValue(entity.INACTIVO)
		else
			entity.INACTIVO = F_ValueToBoolean(row("INACTIVO"))
		end if
	end if
	if F_Contains(row, "FECHABAJA") then
		if row("FECHABAJA") is System.DbNull.Value then
			entity.FECHABAJA = F_Set_nullValue(entity.FECHABAJA)
		else
			entity.FECHABAJA = CType(row("FECHABAJA"),DateTime)
		end if
	end if
	if F_Contains(row, "IDUSUARIO") then
		if row("IDUSUARIO") is System.DbNull.Value then
			entity.IDUSUARIO = F_Set_nullValue(entity.IDUSUARIO)
		else
			entity.IDUSUARIO = CType(row("IDUSUARIO"),String)
		end if
	end if
	if F_Contains(row, "IDUSUARIO_Desc") then
		if row("IDUSUARIO_Desc") is System.DbNull.Value then
			entity.IDUSUARIO_Desc = F_Set_nullValue(entity.IDUSUARIO_Desc)
		else
			entity.IDUSUARIO_Desc = CType(row("IDUSUARIO_Desc"),String)
		end if
	end if
	if F_Contains(row, "EMAIL") then
		if row("EMAIL") is System.DbNull.Value then
			entity.EMAIL = F_Set_nullValue(entity.EMAIL)
		else
			entity.EMAIL = CType(row("EMAIL"),String)
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
	if F_Contains(row, "IDUSUARIOALTA") then
		if row("IDUSUARIOALTA") is System.DbNull.Value then
			entity.IDUSUARIOALTA = F_Set_nullValue(entity.IDUSUARIOALTA)
		else
			entity.IDUSUARIOALTA = CType(row("IDUSUARIOALTA"),String)
		end if
	end if
	if F_Contains(row, "IDUSUARIOALTA_Desc") then
		if row("IDUSUARIOALTA_Desc") is System.DbNull.Value then
			entity.IDUSUARIOALTA_Desc = F_Set_nullValue(entity.IDUSUARIOALTA_Desc)
		else
			entity.IDUSUARIOALTA_Desc = CType(row("IDUSUARIOALTA_Desc"),String)
		end if
	end if
	if F_Contains(row, "FECHAALTA") then
		if row("FECHAALTA") is System.DbNull.Value then
			entity.FECHAALTA = F_Set_nullValue(entity.FECHAALTA)
		else
			entity.FECHAALTA = CType(row("FECHAALTA"),DateTime)
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
	if F_Contains(row, "FECHAMODIFICACION") then
		if row("FECHAMODIFICACION") is System.DbNull.Value then
			entity.FECHAMODIFICACION = F_Set_nullValue(entity.FECHAMODIFICACION)
		else
			entity.FECHAMODIFICACION = CType(row("FECHAMODIFICACION"),DateTime)
		end if
	end if

		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la Empleado"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function
	
#End Region

Public Function GetByDocumento(Byval NRODOCUMENTO as String
) As List (of Empleado)
        Dim sql As String = "A_EMPLEADOGETBYDOC"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Empleado)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@NRODOCUMENTO_I"), IDataParameter)
			par.Value = F_ValueToNull(NRODOCUMENTO)
		
			Dim entity As Empleado
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

Public Function GetALL() As List (of Empleado)
        Dim sql As String = "A_EmpleadoGETALL"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Empleado)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			Dim entity As Empleado
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

Public Function GetAllActivos() As List (of Empleado)
        Dim sql As String = "A_EmpleadoGETACTIVOS"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Empleado)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			Dim entity As Empleado
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

Public Function GetAllActivosVisiblesPorUsuario(Byval IDUSUARIO as String
) As List (of Empleado)
        Dim sql As String = "A_EmpleadoGETACTIVOSDELGRUPO"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Empleado)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@IDUSUARIO_I"), IDataParameter)
			par.Value = F_ValueToNull(IDUSUARIO)
		
			Dim entity As Empleado
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

