
'
'	Project Employees
'		Employees Example
'	Entity	AusenciaEmpleado
'		AusenciaEmpleado Entity
'	
'

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Conexion

Imports Employees.Entities

Public Partial Class AusenciaEmpleadoData
	Inherits BaseData

	Public Sub New()
		MyBase.New()
	End Sub

#Region "Metodos Publicos"

	Public Overloads Function Insert(ByVal Entity As AusenciaEmpleado, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Insert(Entity.Table, Entity.DirtyFields)
    End Function

    Public Overloads Function Update(ByVal Entity As AusenciaEmpleado, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Update(Entity.Table, Entity.KeyFields, Entity.DirtyFields)
    End Function
	
	Public function InsertSP(Entity as AusenciaEmpleado, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_AusenciaEmpleado_I"
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
			par = CType(oParams.Item("@IDTIPOAUSENCIA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDTIPOAUSENCIA)
			par = CType(oParams.Item("@IDUSUARIOSOLICITA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOSOLICITA)
			par = CType(oParams.Item("@FECHASOLICITUD"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHASOLICITUD)
			par = CType(oParams.Item("@IDUSUARIOVALIDA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOVALIDA)
			par = CType(oParams.Item("@FECHAVALIDACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAVALIDACION)
			par = CType(oParams.Item("@IDUSUARIOAPRUEBA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOAPRUEBA)
			par = CType(oParams.Item("@FECHAAPROBACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAAPROBACION)

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
				bOk = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo insertar la AusenciaEmpleado"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If
			par = CType(oParams.Item("@ID"), IDataParameter)
			Entity.ID = par.Value 
			par = CType(oParams.Item("@FECHASOLICITUD"), IDataParameter)
			Entity.FECHASOLICITUD = par.Value 
		Catch ex As Exception
			MyBase.ConError = True
		MyBase.Exception = ex
		MyBase.Error = "No se pudo insertar la AusenciaEmpleado"
		MyBase.InternalError = ex.Message
		bOk = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bOk
	End Function

	Public function UpdateSP(Entity as AusenciaEmpleado, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_AusenciaEmpleado_U"
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
			par = CType(oParams.Item("@IDTIPOAUSENCIA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDTIPOAUSENCIA)
			par = CType(oParams.Item("@IDUSUARIOSOLICITA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOSOLICITA)
			par = CType(oParams.Item("@FECHASOLICITUD"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHASOLICITUD)
			par = CType(oParams.Item("@IDUSUARIOVALIDA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOVALIDA)
			par = CType(oParams.Item("@FECHAVALIDACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAVALIDACION)
			par = CType(oParams.Item("@IDUSUARIOAPRUEBA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOAPRUEBA)
			par = CType(oParams.Item("@FECHAAPROBACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAAPROBACION)
			par = CType(oParams.Item("@IDUSUARIOANULA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOANULA)
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
				MyBase.Error = "No se pudo actualizar la AusenciaEmpleado"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If

			
		Catch ex As Exception
			MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo actualizar la AusenciaEmpleado"
            MyBase.InternalError = ex.Message
			bok = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bok
	End Function

	Public Function GetDtTableById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String = "A_AusenciaEmpleadoGetById"
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
        Dim sql As String  = "A_AusenciaEmpleadoGetById"		
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
			MyBase.Error = "No se pudo buscar la AusenciaEmpleado"
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()	
		End Try
		
		Return drDatos
	End Function

	Public Function GetEntityById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As AusenciaEmpleado
		Dim entity as AusenciaEmpleado
	    Dim DtDatos As DataTable
		try
			DtDatos = GetDtTableById(ID, ThrowErr)
			If DtDatos.Rows.Count > 0 Then entity = Make(DtDatos.Rows(0))
        Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo buscar la AusenciaEmpleado"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()
		End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As AusenciaEmpleado, Optional ByVal ThrowErr As Boolean = False) As List(Of AusenciaEmpleado)
        Dim DtDatos As DataTable
        Dim listEntities As New List(Of AusenciaEmpleado)
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
            MyBase.Error = "No se pudo buscar la AusenciaEmpleado"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return listEntities
    End Function
	
	Private Function Make(reader as IDataReader, Optional ByVal ThrowErr As Boolean = False) as AusenciaEmpleado
		Dim entity as AusenciaEmpleado
		Try
			entity = new AusenciaEmpleado
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
				if reader("IDTIPOAUSENCIA") is System.DbNull.Value then
					entity.IDTIPOAUSENCIA = F_Set_nullValue(entity.IDTIPOAUSENCIA)
				else
					entity.IDTIPOAUSENCIA = CType(reader("IDTIPOAUSENCIA"),Long)
				end if		
				if reader("IDTIPOAUSENCIA_Desc") is System.DbNull.Value then
					entity.IDTIPOAUSENCIA_Desc = F_Set_nullValue(entity.IDTIPOAUSENCIA_Desc)
				else
					entity.IDTIPOAUSENCIA_Desc = CType(reader("IDTIPOAUSENCIA_Desc"),String)
				end if		
				if reader("IDUSUARIOSOLICITA") is System.DbNull.Value then
					entity.IDUSUARIOSOLICITA = F_Set_nullValue(entity.IDUSUARIOSOLICITA)
				else
					entity.IDUSUARIOSOLICITA = CType(reader("IDUSUARIOSOLICITA"),String)
				end if		
				if reader("IDUSUARIOSOLICITA_Desc") is System.DbNull.Value then
					entity.IDUSUARIOSOLICITA_Desc = F_Set_nullValue(entity.IDUSUARIOSOLICITA_Desc)
				else
					entity.IDUSUARIOSOLICITA_Desc = CType(reader("IDUSUARIOSOLICITA_Desc"),String)
				end if		
				if reader("FECHASOLICITUD") is System.DbNull.Value then
					entity.FECHASOLICITUD = F_Set_nullValue(entity.FECHASOLICITUD)
				else
					entity.FECHASOLICITUD = CType(reader("FECHASOLICITUD"),DateTime)
				end if		
				if reader("IDUSUARIOVALIDA") is System.DbNull.Value then
					entity.IDUSUARIOVALIDA = F_Set_nullValue(entity.IDUSUARIOVALIDA)
				else
					entity.IDUSUARIOVALIDA = CType(reader("IDUSUARIOVALIDA"),String)
				end if		
				if reader("IDUSUARIOVALIDA_Desc") is System.DbNull.Value then
					entity.IDUSUARIOVALIDA_Desc = F_Set_nullValue(entity.IDUSUARIOVALIDA_Desc)
				else
					entity.IDUSUARIOVALIDA_Desc = CType(reader("IDUSUARIOVALIDA_Desc"),String)
				end if		
				if reader("FECHAVALIDACION") is System.DbNull.Value then
					entity.FECHAVALIDACION = F_Set_nullValue(entity.FECHAVALIDACION)
				else
					entity.FECHAVALIDACION = CType(reader("FECHAVALIDACION"),DateTime)
				end if		
				if reader("IDUSUARIOAPRUEBA") is System.DbNull.Value then
					entity.IDUSUARIOAPRUEBA = F_Set_nullValue(entity.IDUSUARIOAPRUEBA)
				else
					entity.IDUSUARIOAPRUEBA = CType(reader("IDUSUARIOAPRUEBA"),String)
				end if		
				if reader("IDUSUARIOAPRUEBA_Desc") is System.DbNull.Value then
					entity.IDUSUARIOAPRUEBA_Desc = F_Set_nullValue(entity.IDUSUARIOAPRUEBA_Desc)
				else
					entity.IDUSUARIOAPRUEBA_Desc = CType(reader("IDUSUARIOAPRUEBA_Desc"),String)
				end if		
				if reader("FECHAAPROBACION") is System.DbNull.Value then
					entity.FECHAAPROBACION = F_Set_nullValue(entity.FECHAAPROBACION)
				else
					entity.FECHAAPROBACION = CType(reader("FECHAAPROBACION"),DateTime)
				end if		
				if reader("IDUSUARIOANULA") is System.DbNull.Value then
					entity.IDUSUARIOANULA = F_Set_nullValue(entity.IDUSUARIOANULA)
				else
					entity.IDUSUARIOANULA = CType(reader("IDUSUARIOANULA"),String)
				end if		
				if reader("IDUSUARIOANULA_Desc") is System.DbNull.Value then
					entity.IDUSUARIOANULA_Desc = F_Set_nullValue(entity.IDUSUARIOANULA_Desc)
				else
					entity.IDUSUARIOANULA_Desc = CType(reader("IDUSUARIOANULA_Desc"),String)
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
			MyBase.Error = "No se pudo cargar la AusenciaEmpleado"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function

	
	Private Function Make(row as DataRow, Optional ByVal ThrowErr As Boolean = False) as AusenciaEmpleado
		Dim entity as AusenciaEmpleado
		Try
		
			entity = new AusenciaEmpleado
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
	if F_Contains(row, "IDTIPOAUSENCIA") then
		if row("IDTIPOAUSENCIA") is System.DbNull.Value then
			entity.IDTIPOAUSENCIA = F_Set_nullValue(entity.IDTIPOAUSENCIA)
		else
			entity.IDTIPOAUSENCIA = CType(row("IDTIPOAUSENCIA"),Long)
		end if
	end if
	if F_Contains(row, "IDTIPOAUSENCIA_Desc") then
		if row("IDTIPOAUSENCIA_Desc") is System.DbNull.Value then
			entity.IDTIPOAUSENCIA_Desc = F_Set_nullValue(entity.IDTIPOAUSENCIA_Desc)
		else
			entity.IDTIPOAUSENCIA_Desc = CType(row("IDTIPOAUSENCIA_Desc"),String)
		end if
	end if
	if F_Contains(row, "IDUSUARIOSOLICITA") then
		if row("IDUSUARIOSOLICITA") is System.DbNull.Value then
			entity.IDUSUARIOSOLICITA = F_Set_nullValue(entity.IDUSUARIOSOLICITA)
		else
			entity.IDUSUARIOSOLICITA = CType(row("IDUSUARIOSOLICITA"),String)
		end if
	end if
	if F_Contains(row, "IDUSUARIOSOLICITA_Desc") then
		if row("IDUSUARIOSOLICITA_Desc") is System.DbNull.Value then
			entity.IDUSUARIOSOLICITA_Desc = F_Set_nullValue(entity.IDUSUARIOSOLICITA_Desc)
		else
			entity.IDUSUARIOSOLICITA_Desc = CType(row("IDUSUARIOSOLICITA_Desc"),String)
		end if
	end if
	if F_Contains(row, "FECHASOLICITUD") then
		if row("FECHASOLICITUD") is System.DbNull.Value then
			entity.FECHASOLICITUD = F_Set_nullValue(entity.FECHASOLICITUD)
		else
			entity.FECHASOLICITUD = CType(row("FECHASOLICITUD"),DateTime)
		end if
	end if
	if F_Contains(row, "IDUSUARIOVALIDA") then
		if row("IDUSUARIOVALIDA") is System.DbNull.Value then
			entity.IDUSUARIOVALIDA = F_Set_nullValue(entity.IDUSUARIOVALIDA)
		else
			entity.IDUSUARIOVALIDA = CType(row("IDUSUARIOVALIDA"),String)
		end if
	end if
	if F_Contains(row, "IDUSUARIOVALIDA_Desc") then
		if row("IDUSUARIOVALIDA_Desc") is System.DbNull.Value then
			entity.IDUSUARIOVALIDA_Desc = F_Set_nullValue(entity.IDUSUARIOVALIDA_Desc)
		else
			entity.IDUSUARIOVALIDA_Desc = CType(row("IDUSUARIOVALIDA_Desc"),String)
		end if
	end if
	if F_Contains(row, "FECHAVALIDACION") then
		if row("FECHAVALIDACION") is System.DbNull.Value then
			entity.FECHAVALIDACION = F_Set_nullValue(entity.FECHAVALIDACION)
		else
			entity.FECHAVALIDACION = CType(row("FECHAVALIDACION"),DateTime)
		end if
	end if
	if F_Contains(row, "IDUSUARIOAPRUEBA") then
		if row("IDUSUARIOAPRUEBA") is System.DbNull.Value then
			entity.IDUSUARIOAPRUEBA = F_Set_nullValue(entity.IDUSUARIOAPRUEBA)
		else
			entity.IDUSUARIOAPRUEBA = CType(row("IDUSUARIOAPRUEBA"),String)
		end if
	end if
	if F_Contains(row, "IDUSUARIOAPRUEBA_Desc") then
		if row("IDUSUARIOAPRUEBA_Desc") is System.DbNull.Value then
			entity.IDUSUARIOAPRUEBA_Desc = F_Set_nullValue(entity.IDUSUARIOAPRUEBA_Desc)
		else
			entity.IDUSUARIOAPRUEBA_Desc = CType(row("IDUSUARIOAPRUEBA_Desc"),String)
		end if
	end if
	if F_Contains(row, "FECHAAPROBACION") then
		if row("FECHAAPROBACION") is System.DbNull.Value then
			entity.FECHAAPROBACION = F_Set_nullValue(entity.FECHAAPROBACION)
		else
			entity.FECHAAPROBACION = CType(row("FECHAAPROBACION"),DateTime)
		end if
	end if
	if F_Contains(row, "IDUSUARIOANULA") then
		if row("IDUSUARIOANULA") is System.DbNull.Value then
			entity.IDUSUARIOANULA = F_Set_nullValue(entity.IDUSUARIOANULA)
		else
			entity.IDUSUARIOANULA = CType(row("IDUSUARIOANULA"),String)
		end if
	end if
	if F_Contains(row, "IDUSUARIOANULA_Desc") then
		if row("IDUSUARIOANULA_Desc") is System.DbNull.Value then
			entity.IDUSUARIOANULA_Desc = F_Set_nullValue(entity.IDUSUARIOANULA_Desc)
		else
			entity.IDUSUARIOANULA_Desc = CType(row("IDUSUARIOANULA_Desc"),String)
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
			MyBase.Error = "No se pudo cargar la AusenciaEmpleado"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function
	
#End Region

Public Function GetEntreFechas(Byval FECHADESDE as Date, Byval FECHAHASTA as Date
) As List (of AusenciaEmpleado)
        Dim sql As String = "A_AUSENCIAEMPGetByFechas"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of AusenciaEmpleado)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHADESDE_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHADESDE)
		
			par = CType(oParams.Item("@FECHAHASTA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAHASTA)
		
			Dim entity As AusenciaEmpleado
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

Public Function GetALL() As List (of AusenciaEmpleado)
        Dim sql As String = "A_AusenciaEmpGETALL"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of AusenciaEmpleado)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			Dim entity As AusenciaEmpleado
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

Public Function GetByEmpleado(Byval IDEMPLEADO as Long
) As List (of AusenciaEmpleado)
        Dim sql As String = "A_AUSENCIAEMPGetByEmp"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of AusenciaEmpleado)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@IDEMPLEADO_I"), IDataParameter)
			par.Value = F_ValueToNull(IDEMPLEADO)
		
			Dim entity As AusenciaEmpleado
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

Public Function GetByTipoAusencia(Byval IDTIPOAUSENCIA as Long
) As List (of AusenciaEmpleado)
        Dim sql As String = "A_AUSENCIAEMPGetByAus"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of AusenciaEmpleado)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@IDTIPOAUSENCIA_I"), IDataParameter)
			par.Value = F_ValueToNull(IDTIPOAUSENCIA)
		
			Dim entity As AusenciaEmpleado
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
) As List (of AusenciaEmpleado)
        Dim sql As String = "A_AUSENCIAEMPGETFECGRP"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of AusenciaEmpleado)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHADESDE_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHADESDE)
		
			par = CType(oParams.Item("@FECHAHASTA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAHASTA)
		
			par = CType(oParams.Item("@IDGRUPO_I"), IDataParameter)
			par.Value = F_ValueToNull(IDGRUPO)
		
			Dim entity As AusenciaEmpleado
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

