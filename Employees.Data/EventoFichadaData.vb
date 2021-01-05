
'
'	Project Employees
'		Employees Example
'	Entity	EventoFichada
'		EventoFichada Entity
'	
'

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Conexion

Imports Employees.Entities

Public Partial Class EventoFichadaData
	Inherits BaseData

	Public Sub New()
		MyBase.New()
	End Sub

#Region "Metodos Publicos"

	Public Overloads Function Insert(ByVal Entity As EventoFichada, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Insert(Entity.Table, Entity.DirtyFields)
    End Function

    Public Overloads Function Update(ByVal Entity As EventoFichada, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Update(Entity.Table, Entity.KeyFields, Entity.DirtyFields)
    End Function
	
	Public function InsertSP(Entity as EventoFichada, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_EventoFichada_I"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@IDEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDEMPLEADO)
			par = CType(oParams.Item("@IDCONVENIO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDCONVENIO)
			par = CType(oParams.Item("@FECHAENTRADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAENTRADA)
			par = CType(oParams.Item("@IDFICHADAENTRADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDFICHADAENTRADA)
			par = CType(oParams.Item("@FECHASALIDA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHASALIDA)
			par = CType(oParams.Item("@IDFICHADASALIDA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDFICHADASALIDA)
			par = CType(oParams.Item("@IDHORARIOEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDHORARIOEMPLEADO)
			par = CType(oParams.Item("@IDHORARIOADICEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDHORARIOADICEMPLEADO)
			par = CType(oParams.Item("@INCONSISTENCIA"), IDataParameter)
			par.Value = F_BooleanToValue(entity.INCONSISTENCIA, par)
			par = CType(oParams.Item("@MINUTOSTRABAJADOS"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSTRABAJADOS)
			par = CType(oParams.Item("@MINUTOSTARDE"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSTARDE)
			par = CType(oParams.Item("@AUSENTE"), IDataParameter)
			par.Value = F_BooleanToValue(entity.AUSENTE, par)
			par = CType(oParams.Item("@IDAUSENCIAEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDAUSENCIAEMPLEADO)
			par = CType(oParams.Item("@OBSERVACIONES"), IDataParameter)
			par.Value = F_ValueToNull(entity.OBSERVACIONES)
			par = CType(oParams.Item("@IDLIQUIDACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDLIQUIDACION)

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
				bOk = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo insertar la EventoFichada"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If
			par = CType(oParams.Item("@ID"), IDataParameter)
			Entity.ID = par.Value 
		Catch ex As Exception
			MyBase.ConError = True
		MyBase.Exception = ex
		MyBase.Error = "No se pudo insertar la EventoFichada"
		MyBase.InternalError = ex.Message
		bOk = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bOk
	End Function

	Public function UpdateSP(Entity as EventoFichada, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_EventoFichada_U"
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
			par = CType(oParams.Item("@FECHAENTRADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAENTRADA)
			par = CType(oParams.Item("@IDFICHADAENTRADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDFICHADAENTRADA)
			par = CType(oParams.Item("@FECHASALIDA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHASALIDA)
			par = CType(oParams.Item("@IDFICHADASALIDA"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDFICHADASALIDA)
			par = CType(oParams.Item("@IDHORARIOEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDHORARIOEMPLEADO)
			par = CType(oParams.Item("@IDHORARIOADICEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDHORARIOADICEMPLEADO)
			par = CType(oParams.Item("@INCONSISTENCIA"), IDataParameter)
			par.Value = F_BooleanToValue(entity.INCONSISTENCIA, par)
			par = CType(oParams.Item("@MINUTOSTRABAJADOS"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSTRABAJADOS)
			par = CType(oParams.Item("@MINUTOSTARDE"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSTARDE)
			par = CType(oParams.Item("@AUSENTE"), IDataParameter)
			par.Value = F_BooleanToValue(entity.AUSENTE, par)
			par = CType(oParams.Item("@IDAUSENCIAEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDAUSENCIAEMPLEADO)
			par = CType(oParams.Item("@OBSERVACIONES"), IDataParameter)
			par.Value = F_ValueToNull(entity.OBSERVACIONES)
			par = CType(oParams.Item("@IDLIQUIDACION"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDLIQUIDACION)
	
            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) >= 0 Then
				bok = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo actualizar la EventoFichada"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If

			
		Catch ex As Exception
			MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo actualizar la EventoFichada"
            MyBase.InternalError = ex.Message
			bok = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bok
	End Function

	Public Function GetDtTableById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String = "A_EventoFichadaGetById"
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
        Dim sql As String  = "A_EventoFichadaGetById"		
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
			MyBase.Error = "No se pudo buscar la EventoFichada"
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()	
		End Try
		
		Return drDatos
	End Function

	Public Function GetEntityById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As EventoFichada
		Dim entity as EventoFichada
	    Dim DtDatos As DataTable
		try
			DtDatos = GetDtTableById(ID, ThrowErr)
			If DtDatos.Rows.Count > 0 Then entity = Make(DtDatos.Rows(0))
        Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo buscar la EventoFichada"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()
		End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As EventoFichada, Optional ByVal ThrowErr As Boolean = False) As List(Of EventoFichada)
        Dim DtDatos As DataTable
        Dim listEntities As New List(Of EventoFichada)
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
            MyBase.Error = "No se pudo buscar la EventoFichada"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return listEntities
    End Function
	
	Private Function Make(reader as IDataReader, Optional ByVal ThrowErr As Boolean = False) as EventoFichada
		Dim entity as EventoFichada
		Try
			entity = new EventoFichada
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
				if reader("IDCONVENIO") is System.DbNull.Value then
					entity.IDCONVENIO = F_Set_nullValue(entity.IDCONVENIO)
				else
					entity.IDCONVENIO = CType(reader("IDCONVENIO"),Long)
				end if		
				if reader("FECHAENTRADA") is System.DbNull.Value then
					entity.FECHAENTRADA = F_Set_nullValue(entity.FECHAENTRADA)
				else
					entity.FECHAENTRADA = CType(reader("FECHAENTRADA"),DateTime)
				end if		
				if reader("IDFICHADAENTRADA") is System.DbNull.Value then
					entity.IDFICHADAENTRADA = F_Set_nullValue(entity.IDFICHADAENTRADA)
				else
					entity.IDFICHADAENTRADA = CType(reader("IDFICHADAENTRADA"),Long)
				end if		
				if reader("FECHASALIDA") is System.DbNull.Value then
					entity.FECHASALIDA = F_Set_nullValue(entity.FECHASALIDA)
				else
					entity.FECHASALIDA = CType(reader("FECHASALIDA"),DateTime)
				end if		
				if reader("IDFICHADASALIDA") is System.DbNull.Value then
					entity.IDFICHADASALIDA = F_Set_nullValue(entity.IDFICHADASALIDA)
				else
					entity.IDFICHADASALIDA = CType(reader("IDFICHADASALIDA"),Long)
				end if		
				if reader("IDHORARIOEMPLEADO") is System.DbNull.Value then
					entity.IDHORARIOEMPLEADO = F_Set_nullValue(entity.IDHORARIOEMPLEADO)
				else
					entity.IDHORARIOEMPLEADO = CType(reader("IDHORARIOEMPLEADO"),Long)
				end if		
				if reader("IDHORARIOADICEMPLEADO") is System.DbNull.Value then
					entity.IDHORARIOADICEMPLEADO = F_Set_nullValue(entity.IDHORARIOADICEMPLEADO)
				else
					entity.IDHORARIOADICEMPLEADO = CType(reader("IDHORARIOADICEMPLEADO"),Long)
				end if		
				if reader("INCONSISTENCIA") is System.DbNull.Value then
					entity.INCONSISTENCIA = F_Set_nullValue(entity.INCONSISTENCIA)
				else
					entity.INCONSISTENCIA = F_ValueToBoolean(reader("INCONSISTENCIA"))
				end if		
				if reader("MINUTOSTRABAJADOS") is System.DbNull.Value then
					entity.MINUTOSTRABAJADOS = F_Set_nullValue(entity.MINUTOSTRABAJADOS)
				else
					entity.MINUTOSTRABAJADOS = CType(reader("MINUTOSTRABAJADOS"),Integer)
				end if		
				if reader("MINUTOSTARDE") is System.DbNull.Value then
					entity.MINUTOSTARDE = F_Set_nullValue(entity.MINUTOSTARDE)
				else
					entity.MINUTOSTARDE = CType(reader("MINUTOSTARDE"),Integer)
				end if		
				if reader("AUSENTE") is System.DbNull.Value then
					entity.AUSENTE = F_Set_nullValue(entity.AUSENTE)
				else
					entity.AUSENTE = F_ValueToBoolean(reader("AUSENTE"))
				end if		
				if reader("IDAUSENCIAEMPLEADO") is System.DbNull.Value then
					entity.IDAUSENCIAEMPLEADO = F_Set_nullValue(entity.IDAUSENCIAEMPLEADO)
				else
					entity.IDAUSENCIAEMPLEADO = CType(reader("IDAUSENCIAEMPLEADO"),Long)
				end if		
				if reader("OBSERVACIONES") is System.DbNull.Value then
					entity.OBSERVACIONES = F_Set_nullValue(entity.OBSERVACIONES)
				else
					entity.OBSERVACIONES = CType(reader("OBSERVACIONES"),String)
				end if		
				if reader("IDLIQUIDACION") is System.DbNull.Value then
					entity.IDLIQUIDACION = F_Set_nullValue(entity.IDLIQUIDACION)
				else
					entity.IDLIQUIDACION = CType(reader("IDLIQUIDACION"),Long)
				end if		
		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la EventoFichada"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function

	
	Private Function Make(row as DataRow, Optional ByVal ThrowErr As Boolean = False) as EventoFichada
		Dim entity as EventoFichada
		Try
		
			entity = new EventoFichada
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
	if F_Contains(row, "IDCONVENIO") then
		if row("IDCONVENIO") is System.DbNull.Value then
			entity.IDCONVENIO = F_Set_nullValue(entity.IDCONVENIO)
		else
			entity.IDCONVENIO = CType(row("IDCONVENIO"),Long)
		end if
	end if
	if F_Contains(row, "FECHAENTRADA") then
		if row("FECHAENTRADA") is System.DbNull.Value then
			entity.FECHAENTRADA = F_Set_nullValue(entity.FECHAENTRADA)
		else
			entity.FECHAENTRADA = CType(row("FECHAENTRADA"),DateTime)
		end if
	end if
	if F_Contains(row, "IDFICHADAENTRADA") then
		if row("IDFICHADAENTRADA") is System.DbNull.Value then
			entity.IDFICHADAENTRADA = F_Set_nullValue(entity.IDFICHADAENTRADA)
		else
			entity.IDFICHADAENTRADA = CType(row("IDFICHADAENTRADA"),Long)
		end if
	end if
	if F_Contains(row, "FECHASALIDA") then
		if row("FECHASALIDA") is System.DbNull.Value then
			entity.FECHASALIDA = F_Set_nullValue(entity.FECHASALIDA)
		else
			entity.FECHASALIDA = CType(row("FECHASALIDA"),DateTime)
		end if
	end if
	if F_Contains(row, "IDFICHADASALIDA") then
		if row("IDFICHADASALIDA") is System.DbNull.Value then
			entity.IDFICHADASALIDA = F_Set_nullValue(entity.IDFICHADASALIDA)
		else
			entity.IDFICHADASALIDA = CType(row("IDFICHADASALIDA"),Long)
		end if
	end if
	if F_Contains(row, "IDHORARIOEMPLEADO") then
		if row("IDHORARIOEMPLEADO") is System.DbNull.Value then
			entity.IDHORARIOEMPLEADO = F_Set_nullValue(entity.IDHORARIOEMPLEADO)
		else
			entity.IDHORARIOEMPLEADO = CType(row("IDHORARIOEMPLEADO"),Long)
		end if
	end if
	if F_Contains(row, "IDHORARIOADICEMPLEADO") then
		if row("IDHORARIOADICEMPLEADO") is System.DbNull.Value then
			entity.IDHORARIOADICEMPLEADO = F_Set_nullValue(entity.IDHORARIOADICEMPLEADO)
		else
			entity.IDHORARIOADICEMPLEADO = CType(row("IDHORARIOADICEMPLEADO"),Long)
		end if
	end if
	if F_Contains(row, "INCONSISTENCIA") then
		if row("INCONSISTENCIA") is System.DbNull.Value then
			entity.INCONSISTENCIA = F_Set_nullValue(entity.INCONSISTENCIA)
		else
			entity.INCONSISTENCIA = F_ValueToBoolean(row("INCONSISTENCIA"))
		end if
	end if
	if F_Contains(row, "MINUTOSTRABAJADOS") then
		if row("MINUTOSTRABAJADOS") is System.DbNull.Value then
			entity.MINUTOSTRABAJADOS = F_Set_nullValue(entity.MINUTOSTRABAJADOS)
		else
			entity.MINUTOSTRABAJADOS = CType(row("MINUTOSTRABAJADOS"),Integer)
		end if
	end if
	if F_Contains(row, "MINUTOSTARDE") then
		if row("MINUTOSTARDE") is System.DbNull.Value then
			entity.MINUTOSTARDE = F_Set_nullValue(entity.MINUTOSTARDE)
		else
			entity.MINUTOSTARDE = CType(row("MINUTOSTARDE"),Integer)
		end if
	end if
	if F_Contains(row, "AUSENTE") then
		if row("AUSENTE") is System.DbNull.Value then
			entity.AUSENTE = F_Set_nullValue(entity.AUSENTE)
		else
			entity.AUSENTE = F_ValueToBoolean(row("AUSENTE"))
		end if
	end if
	if F_Contains(row, "IDAUSENCIAEMPLEADO") then
		if row("IDAUSENCIAEMPLEADO") is System.DbNull.Value then
			entity.IDAUSENCIAEMPLEADO = F_Set_nullValue(entity.IDAUSENCIAEMPLEADO)
		else
			entity.IDAUSENCIAEMPLEADO = CType(row("IDAUSENCIAEMPLEADO"),Long)
		end if
	end if
	if F_Contains(row, "OBSERVACIONES") then
		if row("OBSERVACIONES") is System.DbNull.Value then
			entity.OBSERVACIONES = F_Set_nullValue(entity.OBSERVACIONES)
		else
			entity.OBSERVACIONES = CType(row("OBSERVACIONES"),String)
		end if
	end if
	if F_Contains(row, "IDLIQUIDACION") then
		if row("IDLIQUIDACION") is System.DbNull.Value then
			entity.IDLIQUIDACION = F_Set_nullValue(entity.IDLIQUIDACION)
		else
			entity.IDLIQUIDACION = CType(row("IDLIQUIDACION"),Long)
		end if
	end if

		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la EventoFichada"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function
	
#End Region

Public Function Delete(Byval IDEMPLEADO as Integer, Byval FECHADESDE as Date, Byval FECHAHASTA as Date
) As Boolean
        Dim sql As String = "A_EVENTOFICHADA_DFECEMP"
        Dim oParams As IDataParameterCollection
        Dim par As IDataParameter
        Dim bOk As Boolean
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@IDEMPLEADO_I"), IDataParameter)
			par.Value = F_ValueToNull(IDEMPLEADO)
		
			par = CType(oParams.Item("@FECHADESDE_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHADESDE)
		
			par = CType(oParams.Item("@FECHAHASTA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAHASTA)
		
		
			If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) >= 0 Then
                bOk = True
            Else
                If Not IsNothing(oCon.Exception) Then
                    Me.InternalError = oCon.Exception.Message
                    Me.Exception = oCon.Exception
                End If
                Me.ConError = True
                Me.Error = "No se pudo borra el registro de la base"
                bOk = False
            End If

        Catch ex As Exception
            Me.ConError = True
            Me.Exception = ex
            Me.Error = "No se pudo borra el registro de la base"
            Me.InternalError = ex.Message
            bOk = False
        Finally
            oCon.DesConectar()
        End Try

        Return bOk
				
    End Function

Public Function Delete(Byval ID as Integer
) As Boolean
        Dim sql As String = "A_EVENTOFICHADA_D"
        Dim oParams As IDataParameterCollection
        Dim par As IDataParameter
        Dim bOk As Boolean
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@ID_I"), IDataParameter)
			par.Value = F_ValueToNull(ID)
		
		
			If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) >= 0 Then
                bOk = True
            Else
                If Not IsNothing(oCon.Exception) Then
                    Me.InternalError = oCon.Exception.Message
                    Me.Exception = oCon.Exception
                End If
                Me.ConError = True
                Me.Error = "No se pudo borra el registro de la base"
                bOk = False
            End If

        Catch ex As Exception
            Me.ConError = True
            Me.Exception = ex
            Me.Error = "No se pudo borra el registro de la base"
            Me.InternalError = ex.Message
            bOk = False
        Finally
            oCon.DesConectar()
        End Try

        Return bOk
				
    End Function

Public Function GetTodoEntreFechasEntrada(Byval FECHADESDE as Date, Byval FECHAHASTA as Date
) As List (of EventoFichada)
        Dim sql As String = "A_EVENTOFICHADAGETENTREFECENTR"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of EventoFichada)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHADESDE_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHADESDE)
		
			par = CType(oParams.Item("@FECHAHASTA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAHASTA)
		
			Dim entity As EventoFichada
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

Public Function GetTodoEntreFechaseEntradaGrupo(Byval FECHADESDE as Date, Byval FECHAHASTA as Date, Byval IDGRUPO as Integer
) As List (of EventoFichada)
        Dim sql As String = "A_EVENTOLECTURAGETFECGRP"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of EventoFichada)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHADESDE_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHADESDE)
		
			par = CType(oParams.Item("@FECHAHASTA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAHASTA)
		
			par = CType(oParams.Item("@IDGRUPO_I"), IDataParameter)
			par.Value = F_ValueToNull(IDGRUPO)
		
			Dim entity As EventoFichada
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

Public Function GetByIdLiquidacion(Byval IDLIQUIDACION as Integer
) As List (of EventoFichada)
        Dim sql As String = "A_EVENTOFICHADAGETBYIDLIQUIDAC"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of EventoFichada)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@IDLIQUIDACION_I"), IDataParameter)
			par.Value = F_ValueToNull(IDLIQUIDACION)
		
			Dim entity As EventoFichada
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

