
'
'	Project Employees
'		Employees Example
'	Entity	Feriado
'		Feriado Entity
'	
'

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Conexion

Imports Employees.Entities

Public Partial Class FeriadoData
	Inherits BaseData

	Public Sub New()
		MyBase.New()
	End Sub

#Region "Metodos Publicos"

	Public Overloads Function Insert(ByVal Entity As Feriado, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Insert(Entity.Table, Entity.DirtyFields)
    End Function

    Public Overloads Function Update(ByVal Entity As Feriado, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Update(Entity.Table, Entity.KeyFields, Entity.DirtyFields)
    End Function
	
	Public function InsertSP(Entity as Feriado, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Feriado_I"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@DESCRIPCION"), IDataParameter)
			par.Value = F_ValueToNull(entity.DESCRIPCION)
			par = CType(oParams.Item("@FECHA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHA)
			par = CType(oParams.Item("@ACTIVO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.ACTIVO, par)
			par = CType(oParams.Item("@FECHAALTA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAALTA)
			par = CType(oParams.Item("@FECHAANULACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAANULACION)

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
				bOk = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo insertar la Feriado"
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
		MyBase.Error = "No se pudo insertar la Feriado"
		MyBase.InternalError = ex.Message
		bOk = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bOk
	End Function

	Public function UpdateSP(Entity as Feriado, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Feriado_U"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@ID"), IDataParameter)
			par.Value = F_ValueToNull(entity.ID)
			par = CType(oParams.Item("@DESCRIPCION"), IDataParameter)
			par.Value = F_ValueToNull(entity.DESCRIPCION)
			par = CType(oParams.Item("@FECHA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHA)
			par = CType(oParams.Item("@ACTIVO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.ACTIVO, par)
			par = CType(oParams.Item("@FECHAANULACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAANULACION)
	
            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) >= 0 Then
				bok = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo actualizar la Feriado"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If

			
		Catch ex As Exception
			MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo actualizar la Feriado"
            MyBase.InternalError = ex.Message
			bok = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bok
	End Function

	Public Function GetDtTableById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String = "A_FeriadoGetById"
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
        Dim sql As String  = "A_FeriadoGetById"		
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
			MyBase.Error = "No se pudo buscar la Feriado"
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()	
		End Try
		
		Return drDatos
	End Function

	Public Function GetEntityById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As Feriado
		Dim entity as Feriado
	    Dim DtDatos As DataTable
		try
			DtDatos = GetDtTableById(ID, ThrowErr)
			If DtDatos.Rows.Count > 0 Then entity = Make(DtDatos.Rows(0))
        Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo buscar la Feriado"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()
		End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As Feriado, Optional ByVal ThrowErr As Boolean = False) As List(Of Feriado)
        Dim DtDatos As DataTable
        Dim listEntities As New List(Of Feriado)
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
            MyBase.Error = "No se pudo buscar la Feriado"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return listEntities
    End Function
	
	Private Function Make(reader as IDataReader, Optional ByVal ThrowErr As Boolean = False) as Feriado
		Dim entity as Feriado
		Try
			entity = new Feriado
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
				if reader("FECHA") is System.DbNull.Value then
					entity.FECHA = F_Set_nullValue(entity.FECHA)
				else
					entity.FECHA = CType(reader("FECHA"),Date)
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
				if reader("FECHAANULACION") is System.DbNull.Value then
					entity.FECHAANULACION = F_Set_nullValue(entity.FECHAANULACION)
				else
					entity.FECHAANULACION = CType(reader("FECHAANULACION"),DateTime)
				end if		
		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la Feriado"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function

	
	Private Function Make(row as DataRow, Optional ByVal ThrowErr As Boolean = False) as Feriado
		Dim entity as Feriado
		Try
		
			entity = new Feriado
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
	if F_Contains(row, "FECHA") then
		if row("FECHA") is System.DbNull.Value then
			entity.FECHA = F_Set_nullValue(entity.FECHA)
		else
			entity.FECHA = CType(row("FECHA"),Date)
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
	if F_Contains(row, "FECHAANULACION") then
		if row("FECHAANULACION") is System.DbNull.Value then
			entity.FECHAANULACION = F_Set_nullValue(entity.FECHAANULACION)
		else
			entity.FECHAANULACION = CType(row("FECHAANULACION"),DateTime)
		end if
	end if

		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la Feriado"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function
	
#End Region

End Class

