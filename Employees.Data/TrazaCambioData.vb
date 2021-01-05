
'
'	Project Employees
'		Employees Example
'	Entity	TrazaCambio
'		TrazaCambio Entity
'	
'

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Conexion

Imports Employees.Entities

Public Partial Class TrazaCambioData
	Inherits BaseData

	Public Sub New()
		MyBase.New()
	End Sub

#Region "Metodos Publicos"

	Public Overloads Function Insert(ByVal Entity As TrazaCambio, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Insert(Entity.Table, Entity.DirtyFields)
    End Function

    Public Overloads Function Update(ByVal Entity As TrazaCambio, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Update(Entity.Table, Entity.KeyFields, Entity.DirtyFields)
    End Function
	
	Public function InsertSP(Entity as TrazaCambio, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_TrazaCambio_I"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@IDUSUARIO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIO)
			par = CType(oParams.Item("@FECHA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHA)
			par = CType(oParams.Item("@IDFICHADALECTURA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDFICHADALECTURA)
			par = CType(oParams.Item("@OBSERVACIONES"), IDataParameter)
			par.Value = F_ValueToNull(entity.OBSERVACIONES)
			par = CType(oParams.Item("@TABLAAUXILIAR"), IDataParameter)
			par.Value = F_ValueToNull(entity.TABLAAUXILIAR)
			par = CType(oParams.Item("@IDAUXILIAR"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDAUXILIAR)
			par = CType(oParams.Item("@IDEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDEMPLEADO)

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
				bOk = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo insertar la TrazaCambio"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If
			par = CType(oParams.Item("@ID"), IDataParameter)
			Entity.ID = par.Value 
			par = CType(oParams.Item("@FECHA"), IDataParameter)
			Entity.FECHA = par.Value 
		Catch ex As Exception
			MyBase.ConError = True
		MyBase.Exception = ex
		MyBase.Error = "No se pudo insertar la TrazaCambio"
		MyBase.InternalError = ex.Message
		bOk = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bOk
	End Function

	Public function UpdateSP(Entity as TrazaCambio, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_TrazaCambio_U"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@ID"), IDataParameter)
			par.Value = F_ValueToNull(entity.ID)
			par = CType(oParams.Item("@IDUSUARIO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIO)
			par = CType(oParams.Item("@IDFICHADALECTURA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDFICHADALECTURA)
			par = CType(oParams.Item("@OBSERVACIONES"), IDataParameter)
			par.Value = F_ValueToNull(entity.OBSERVACIONES)
			par = CType(oParams.Item("@TABLAAUXILIAR"), IDataParameter)
			par.Value = F_ValueToNull(entity.TABLAAUXILIAR)
			par = CType(oParams.Item("@IDAUXILIAR"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDAUXILIAR)
			par = CType(oParams.Item("@IDEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDEMPLEADO)
	
            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) >= 0 Then
				bok = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo actualizar la TrazaCambio"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If

			
		Catch ex As Exception
			MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo actualizar la TrazaCambio"
            MyBase.InternalError = ex.Message
			bok = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bok
	End Function

	Public Function GetDtTableById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String = "A_TrazaCambioGetById"
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
        Dim sql As String  = "A_TrazaCambioGetById"		
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
			MyBase.Error = "No se pudo buscar la TrazaCambio"
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()	
		End Try
		
		Return drDatos
	End Function

	Public Function GetEntityById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As TrazaCambio
		Dim entity as TrazaCambio
	    Dim DtDatos As DataTable
		try
			DtDatos = GetDtTableById(ID, ThrowErr)
			If DtDatos.Rows.Count > 0 Then entity = Make(DtDatos.Rows(0))
        Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo buscar la TrazaCambio"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()
		End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As TrazaCambio, Optional ByVal ThrowErr As Boolean = False) As List(Of TrazaCambio)
        Dim DtDatos As DataTable
        Dim listEntities As New List(Of TrazaCambio)
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
            MyBase.Error = "No se pudo buscar la TrazaCambio"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return listEntities
    End Function
	
	Private Function Make(reader as IDataReader, Optional ByVal ThrowErr As Boolean = False) as TrazaCambio
		Dim entity as TrazaCambio
		Try
			entity = new TrazaCambio
			entity.[New] = false
				if reader("ID") is System.DbNull.Value then
					entity.ID = F_Set_nullValue(entity.ID)
				else
					entity.ID = CType(reader("ID"),Long)
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
				if reader("FECHA") is System.DbNull.Value then
					entity.FECHA = F_Set_nullValue(entity.FECHA)
				else
					entity.FECHA = CType(reader("FECHA"),DateTime)
				end if		
				if reader("IDFICHADALECTURA") is System.DbNull.Value then
					entity.IDFICHADALECTURA = F_Set_nullValue(entity.IDFICHADALECTURA)
				else
					entity.IDFICHADALECTURA = CType(reader("IDFICHADALECTURA"),Long)
				end if		
				if reader("OBSERVACIONES") is System.DbNull.Value then
					entity.OBSERVACIONES = F_Set_nullValue(entity.OBSERVACIONES)
				else
					entity.OBSERVACIONES = CType(reader("OBSERVACIONES"),String)
				end if		
				if reader("TABLAAUXILIAR") is System.DbNull.Value then
					entity.TABLAAUXILIAR = F_Set_nullValue(entity.TABLAAUXILIAR)
				else
					entity.TABLAAUXILIAR = CType(reader("TABLAAUXILIAR"),String)
				end if		
				if reader("IDAUXILIAR") is System.DbNull.Value then
					entity.IDAUXILIAR = F_Set_nullValue(entity.IDAUXILIAR)
				else
					entity.IDAUXILIAR = CType(reader("IDAUXILIAR"),String)
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
		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la TrazaCambio"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function

	
	Private Function Make(row as DataRow, Optional ByVal ThrowErr As Boolean = False) as TrazaCambio
		Dim entity as TrazaCambio
		Try
		
			entity = new TrazaCambio
			entity.[New] = false

	if F_Contains(row, "ID") then
		if row("ID") is System.DbNull.Value then
			entity.ID = F_Set_nullValue(entity.ID)
		else
			entity.ID = CType(row("ID"),Long)
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
	if F_Contains(row, "FECHA") then
		if row("FECHA") is System.DbNull.Value then
			entity.FECHA = F_Set_nullValue(entity.FECHA)
		else
			entity.FECHA = CType(row("FECHA"),DateTime)
		end if
	end if
	if F_Contains(row, "IDFICHADALECTURA") then
		if row("IDFICHADALECTURA") is System.DbNull.Value then
			entity.IDFICHADALECTURA = F_Set_nullValue(entity.IDFICHADALECTURA)
		else
			entity.IDFICHADALECTURA = CType(row("IDFICHADALECTURA"),Long)
		end if
	end if
	if F_Contains(row, "OBSERVACIONES") then
		if row("OBSERVACIONES") is System.DbNull.Value then
			entity.OBSERVACIONES = F_Set_nullValue(entity.OBSERVACIONES)
		else
			entity.OBSERVACIONES = CType(row("OBSERVACIONES"),String)
		end if
	end if
	if F_Contains(row, "TABLAAUXILIAR") then
		if row("TABLAAUXILIAR") is System.DbNull.Value then
			entity.TABLAAUXILIAR = F_Set_nullValue(entity.TABLAAUXILIAR)
		else
			entity.TABLAAUXILIAR = CType(row("TABLAAUXILIAR"),String)
		end if
	end if
	if F_Contains(row, "IDAUXILIAR") then
		if row("IDAUXILIAR") is System.DbNull.Value then
			entity.IDAUXILIAR = F_Set_nullValue(entity.IDAUXILIAR)
		else
			entity.IDAUXILIAR = CType(row("IDAUXILIAR"),String)
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

		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la TrazaCambio"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function
	
#End Region

Public Function GetALL() As List (of TrazaCambio)
        Dim sql As String = "A_TRAZACAMBIOGETALL"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of TrazaCambio)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			Dim entity As TrazaCambio
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

Public Function GetEntreFechas(Byval FECHADESDE as Date, Byval FECHAHASTA as Date
) As List (of TrazaCambio)
        Dim sql As String = "A_TRAZACAMBIOGETENTREFECHAS"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of TrazaCambio)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHADESDE_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHADESDE)
		
			par = CType(oParams.Item("@FECHAHASTA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAHASTA)
		
			Dim entity As TrazaCambio
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

