
'
'	Project Employees
'		Employees Example
'	Entity	Usuario
'		Usuario Entity
'	
'

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Conexion

Imports Employees.Entities

Public Partial Class UsuarioData
	Inherits BaseData

	Public Sub New()
		MyBase.New()
	End Sub

#Region "Metodos Publicos"

	Public Overloads Function Insert(ByVal Entity As Usuario, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Insert(Entity.Table, Entity.DirtyFields)
    End Function

    Public Overloads Function Update(ByVal Entity As Usuario, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Update(Entity.Table, Entity.KeyFields, Entity.DirtyFields)
    End Function
	
	Public function InsertSP(Entity as Usuario, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Usuario_I"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@ID"), IDataParameter)
			par.Value = F_ValueToNull(entity.ID)
			par = CType(oParams.Item("@NOMBRE"), IDataParameter)
			par.Value = F_ValueToNull(entity.NOMBRE)
			par = CType(oParams.Item("@RRHH"), IDataParameter)
			par.Value = F_BooleanToValue(entity.RRHH, par)
			par = CType(oParams.Item("@SUPERVISOR"), IDataParameter)
			par.Value = F_BooleanToValue(entity.SUPERVISOR, par)
			par = CType(oParams.Item("@CLAVE"), IDataParameter)
			par.Value = F_ValueToNull(entity.CLAVE)
			par = CType(oParams.Item("@ACTIVO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.ACTIVO, par)
			par = CType(oParams.Item("@DIRECTORRRHH"), IDataParameter)
			par.Value = F_BooleanToValue(entity.DIRECTORRRHH, par)

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
				bOk = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo insertar la Usuario"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If
		Catch ex As Exception
			MyBase.ConError = True
		MyBase.Exception = ex
		MyBase.Error = "No se pudo insertar la Usuario"
		MyBase.InternalError = ex.Message
		bOk = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bOk
	End Function

	Public function UpdateSP(Entity as Usuario, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Usuario_U"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@ID"), IDataParameter)
			par.Value = F_ValueToNull(entity.ID)
			par = CType(oParams.Item("@NOMBRE"), IDataParameter)
			par.Value = F_ValueToNull(entity.NOMBRE)
			par = CType(oParams.Item("@RRHH"), IDataParameter)
			par.Value = F_BooleanToValue(entity.RRHH, par)
			par = CType(oParams.Item("@SUPERVISOR"), IDataParameter)
			par.Value = F_BooleanToValue(entity.SUPERVISOR, par)
			par = CType(oParams.Item("@CLAVE"), IDataParameter)
			par.Value = F_ValueToNull(entity.CLAVE)
			par = CType(oParams.Item("@ACTIVO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.ACTIVO, par)
			par = CType(oParams.Item("@DIRECTORRRHH"), IDataParameter)
			par.Value = F_BooleanToValue(entity.DIRECTORRRHH, par)
	
            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) >= 0 Then
				bok = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo actualizar la Usuario"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If

			
		Catch ex As Exception
			MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo actualizar la Usuario"
            MyBase.InternalError = ex.Message
			bok = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bok
	End Function

	Public Function GetDtTableById(Byval ID as String, Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String = "A_UsuarioGetById"
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

	Public Function GetDReaderById(Byval ID as String, Optional ByVal ThrowErr As Boolean = False)  As System.Data.IDataReader
        Dim sql As String  = "A_UsuarioGetById"		
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
			MyBase.Error = "No se pudo buscar la Usuario"
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()	
		End Try
		
		Return drDatos
	End Function

	Public Function GetEntityById(Byval ID as String, Optional ByVal ThrowErr As Boolean = False) As Usuario
		Dim entity as Usuario
	    Dim DtDatos As DataTable
		try
			DtDatos = GetDtTableById(ID, ThrowErr)
			If DtDatos.Rows.Count > 0 Then entity = Make(DtDatos.Rows(0))
        Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo buscar la Usuario"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()
		End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As Usuario, Optional ByVal ThrowErr As Boolean = False) As List(Of Usuario)
        Dim DtDatos As DataTable
        Dim listEntities As New List(Of Usuario)
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
            MyBase.Error = "No se pudo buscar la Usuario"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return listEntities
    End Function
	
	Private Function Make(reader as IDataReader, Optional ByVal ThrowErr As Boolean = False) as Usuario
		Dim entity as Usuario
		Try
			entity = new Usuario
			entity.[New] = false
				if reader("ID") is System.DbNull.Value then
					entity.ID = F_Set_nullValue(entity.ID)
				else
					entity.ID = CType(reader("ID"),String)
				end if		
				if reader("NOMBRE") is System.DbNull.Value then
					entity.NOMBRE = F_Set_nullValue(entity.NOMBRE)
				else
					entity.NOMBRE = CType(reader("NOMBRE"),String)
				end if		
				if reader("RRHH") is System.DbNull.Value then
					entity.RRHH = F_Set_nullValue(entity.RRHH)
				else
					entity.RRHH = F_ValueToBoolean(reader("RRHH"))
				end if		
				if reader("SUPERVISOR") is System.DbNull.Value then
					entity.SUPERVISOR = F_Set_nullValue(entity.SUPERVISOR)
				else
					entity.SUPERVISOR = F_ValueToBoolean(reader("SUPERVISOR"))
				end if		
				if reader("CLAVE") is System.DbNull.Value then
					entity.CLAVE = F_Set_nullValue(entity.CLAVE)
				else
					entity.CLAVE = CType(reader("CLAVE"),String)
				end if		
				if reader("ACTIVO") is System.DbNull.Value then
					entity.ACTIVO = F_Set_nullValue(entity.ACTIVO)
				else
					entity.ACTIVO = F_ValueToBoolean(reader("ACTIVO"))
				end if		
				if reader("DIRECTORRRHH") is System.DbNull.Value then
					entity.DIRECTORRRHH = F_Set_nullValue(entity.DIRECTORRRHH)
				else
					entity.DIRECTORRRHH = F_ValueToBoolean(reader("DIRECTORRRHH"))
				end if		
		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la Usuario"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function

	
	Private Function Make(row as DataRow, Optional ByVal ThrowErr As Boolean = False) as Usuario
		Dim entity as Usuario
		Try
		
			entity = new Usuario
			entity.[New] = false

	if F_Contains(row, "ID") then
		if row("ID") is System.DbNull.Value then
			entity.ID = F_Set_nullValue(entity.ID)
		else
			entity.ID = CType(row("ID"),String)
		end if
	end if
	if F_Contains(row, "NOMBRE") then
		if row("NOMBRE") is System.DbNull.Value then
			entity.NOMBRE = F_Set_nullValue(entity.NOMBRE)
		else
			entity.NOMBRE = CType(row("NOMBRE"),String)
		end if
	end if
	if F_Contains(row, "RRHH") then
		if row("RRHH") is System.DbNull.Value then
			entity.RRHH = F_Set_nullValue(entity.RRHH)
		else
			entity.RRHH = F_ValueToBoolean(row("RRHH"))
		end if
	end if
	if F_Contains(row, "SUPERVISOR") then
		if row("SUPERVISOR") is System.DbNull.Value then
			entity.SUPERVISOR = F_Set_nullValue(entity.SUPERVISOR)
		else
			entity.SUPERVISOR = F_ValueToBoolean(row("SUPERVISOR"))
		end if
	end if
	if F_Contains(row, "CLAVE") then
		if row("CLAVE") is System.DbNull.Value then
			entity.CLAVE = F_Set_nullValue(entity.CLAVE)
		else
			entity.CLAVE = CType(row("CLAVE"),String)
		end if
	end if
	if F_Contains(row, "ACTIVO") then
		if row("ACTIVO") is System.DbNull.Value then
			entity.ACTIVO = F_Set_nullValue(entity.ACTIVO)
		else
			entity.ACTIVO = F_ValueToBoolean(row("ACTIVO"))
		end if
	end if
	if F_Contains(row, "DIRECTORRRHH") then
		if row("DIRECTORRRHH") is System.DbNull.Value then
			entity.DIRECTORRRHH = F_Set_nullValue(entity.DIRECTORRRHH)
		else
			entity.DIRECTORRRHH = F_ValueToBoolean(row("DIRECTORRRHH"))
		end if
	end if

		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la Usuario"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function
	
#End Region

End Class

