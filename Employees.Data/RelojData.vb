
'
'	Project Employees
'		Employees Example
'	Entity	Reloj
'		Reloj Entity
'	
'

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Conexion

Imports Employees.Entities

Public Partial Class RelojData
	Inherits BaseData

	Public Sub New()
		MyBase.New()
	End Sub

#Region "Metodos Publicos"

	Public Overloads Function Insert(ByVal Entity As Reloj, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Insert(Entity.Table, Entity.DirtyFields)
    End Function

    Public Overloads Function Update(ByVal Entity As Reloj, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Update(Entity.Table, Entity.KeyFields, Entity.DirtyFields)
    End Function
	
	Public function InsertSP(Entity as Reloj, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Reloj_I"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@ID"), IDataParameter)
			par.Value = F_ValueToNull(entity.ID)
			par = CType(oParams.Item("@DESCRIPCION"), IDataParameter)
			par.Value = F_ValueToNull(entity.DESCRIPCION)
			par = CType(oParams.Item("@IDUBICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUBICACION)
			par = CType(oParams.Item("@IP4"), IDataParameter)
			par.Value = F_ValueToNull(entity.IP4)
			par = CType(oParams.Item("@IP6"), IDataParameter)
			par.Value = F_ValueToNull(entity.IP6)
			par = CType(oParams.Item("@MARCA"), IDataParameter)
			par.Value = F_ValueToNull(entity.MARCA)
			par = CType(oParams.Item("@CONTROLINGRESO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.CONTROLINGRESO, par)
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
				MyBase.Error = "No se pudo insertar la Reloj"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If
		Catch ex As Exception
			MyBase.ConError = True
		MyBase.Exception = ex
		MyBase.Error = "No se pudo insertar la Reloj"
		MyBase.InternalError = ex.Message
		bOk = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bOk
	End Function

	Public function UpdateSP(Entity as Reloj, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Reloj_U"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@ID"), IDataParameter)
			par.Value = F_ValueToNull(entity.ID)
			par = CType(oParams.Item("@DESCRIPCION"), IDataParameter)
			par.Value = F_ValueToNull(entity.DESCRIPCION)
			par = CType(oParams.Item("@IDUBICACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUBICACION)
			par = CType(oParams.Item("@IP4"), IDataParameter)
			par.Value = F_ValueToNull(entity.IP4)
			par = CType(oParams.Item("@IP6"), IDataParameter)
			par.Value = F_ValueToNull(entity.IP6)
			par = CType(oParams.Item("@MARCA"), IDataParameter)
			par.Value = F_ValueToNull(entity.MARCA)
			par = CType(oParams.Item("@CONTROLINGRESO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.CONTROLINGRESO, par)
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
				MyBase.Error = "No se pudo actualizar la Reloj"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If

			
		Catch ex As Exception
			MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo actualizar la Reloj"
            MyBase.InternalError = ex.Message
			bok = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bok
	End Function

	Public Function GetDtTableById(Byval ID as String, Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String = "A_RelojGetById"
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
        Dim sql As String  = "A_RelojGetById"		
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
			MyBase.Error = "No se pudo buscar la Reloj"
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()	
		End Try
		
		Return drDatos
	End Function

	Public Function GetEntityById(Byval ID as String, Optional ByVal ThrowErr As Boolean = False) As Reloj
		Dim entity as Reloj
	    Dim DtDatos As DataTable
		try
			DtDatos = GetDtTableById(ID, ThrowErr)
			If DtDatos.Rows.Count > 0 Then entity = Make(DtDatos.Rows(0))
        Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo buscar la Reloj"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()
		End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As Reloj, Optional ByVal ThrowErr As Boolean = False) As List(Of Reloj)
        Dim DtDatos As DataTable
        Dim listEntities As New List(Of Reloj)
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
            MyBase.Error = "No se pudo buscar la Reloj"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return listEntities
    End Function
	
	Private Function Make(reader as IDataReader, Optional ByVal ThrowErr As Boolean = False) as Reloj
		Dim entity as Reloj
		Try
			entity = new Reloj
			entity.[New] = false
				if reader("ID") is System.DbNull.Value then
					entity.ID = F_Set_nullValue(entity.ID)
				else
					entity.ID = CType(reader("ID"),String)
				end if		
				if reader("DESCRIPCION") is System.DbNull.Value then
					entity.DESCRIPCION = F_Set_nullValue(entity.DESCRIPCION)
				else
					entity.DESCRIPCION = CType(reader("DESCRIPCION"),String)
				end if		
				if reader("IDUBICACION") is System.DbNull.Value then
					entity.IDUBICACION = F_Set_nullValue(entity.IDUBICACION)
				else
					entity.IDUBICACION = CType(reader("IDUBICACION"),Long)
				end if		
				if reader("IDUBICACION_Desc") is System.DbNull.Value then
					entity.IDUBICACION_Desc = F_Set_nullValue(entity.IDUBICACION_Desc)
				else
					entity.IDUBICACION_Desc = CType(reader("IDUBICACION_Desc"),String)
				end if		
				if reader("IP4") is System.DbNull.Value then
					entity.IP4 = F_Set_nullValue(entity.IP4)
				else
					entity.IP4 = CType(reader("IP4"),String)
				end if		
				if reader("IP6") is System.DbNull.Value then
					entity.IP6 = F_Set_nullValue(entity.IP6)
				else
					entity.IP6 = CType(reader("IP6"),String)
				end if		
				if reader("MARCA") is System.DbNull.Value then
					entity.MARCA = F_Set_nullValue(entity.MARCA)
				else
					entity.MARCA = CType(reader("MARCA"),String)
				end if		
				if reader("CONTROLINGRESO") is System.DbNull.Value then
					entity.CONTROLINGRESO = F_Set_nullValue(entity.CONTROLINGRESO)
				else
					entity.CONTROLINGRESO = F_ValueToBoolean(reader("CONTROLINGRESO"))
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
			MyBase.Error = "No se pudo cargar la Reloj"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function

	
	Private Function Make(row as DataRow, Optional ByVal ThrowErr As Boolean = False) as Reloj
		Dim entity as Reloj
		Try
		
			entity = new Reloj
			entity.[New] = false

	if F_Contains(row, "ID") then
		if row("ID") is System.DbNull.Value then
			entity.ID = F_Set_nullValue(entity.ID)
		else
			entity.ID = CType(row("ID"),String)
		end if
	end if
	if F_Contains(row, "DESCRIPCION") then
		if row("DESCRIPCION") is System.DbNull.Value then
			entity.DESCRIPCION = F_Set_nullValue(entity.DESCRIPCION)
		else
			entity.DESCRIPCION = CType(row("DESCRIPCION"),String)
		end if
	end if
	if F_Contains(row, "IDUBICACION") then
		if row("IDUBICACION") is System.DbNull.Value then
			entity.IDUBICACION = F_Set_nullValue(entity.IDUBICACION)
		else
			entity.IDUBICACION = CType(row("IDUBICACION"),Long)
		end if
	end if
	if F_Contains(row, "IDUBICACION_Desc") then
		if row("IDUBICACION_Desc") is System.DbNull.Value then
			entity.IDUBICACION_Desc = F_Set_nullValue(entity.IDUBICACION_Desc)
		else
			entity.IDUBICACION_Desc = CType(row("IDUBICACION_Desc"),String)
		end if
	end if
	if F_Contains(row, "IP4") then
		if row("IP4") is System.DbNull.Value then
			entity.IP4 = F_Set_nullValue(entity.IP4)
		else
			entity.IP4 = CType(row("IP4"),String)
		end if
	end if
	if F_Contains(row, "IP6") then
		if row("IP6") is System.DbNull.Value then
			entity.IP6 = F_Set_nullValue(entity.IP6)
		else
			entity.IP6 = CType(row("IP6"),String)
		end if
	end if
	if F_Contains(row, "MARCA") then
		if row("MARCA") is System.DbNull.Value then
			entity.MARCA = F_Set_nullValue(entity.MARCA)
		else
			entity.MARCA = CType(row("MARCA"),String)
		end if
	end if
	if F_Contains(row, "CONTROLINGRESO") then
		if row("CONTROLINGRESO") is System.DbNull.Value then
			entity.CONTROLINGRESO = F_Set_nullValue(entity.CONTROLINGRESO)
		else
			entity.CONTROLINGRESO = F_ValueToBoolean(row("CONTROLINGRESO"))
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
			MyBase.Error = "No se pudo cargar la Reloj"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function
	
#End Region

Public Function GetALL() As List (of Reloj)
        Dim sql As String = "A_RelojGETALL"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Reloj)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			Dim entity As Reloj
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

