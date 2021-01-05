
'
'	Project Employees
'		Employees Example
'	Entity	Fichada
'		Fichada Entity
'	
'

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Conexion

Imports Employees.Entities

Public Partial Class FichadaData
	Inherits BaseData

	Public Sub New()
		MyBase.New()
	End Sub

#Region "Metodos Publicos"

	Public Overloads Function Insert(ByVal Entity As Fichada, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Insert(Entity.Table, Entity.DirtyFields)
    End Function

    Public Overloads Function Update(ByVal Entity As Fichada, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Return MyBase.Update(Entity.Table, Entity.KeyFields, Entity.DirtyFields)
    End Function
	
	Public function InsertSP(Entity as Fichada, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Fichada_I"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@IDEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDEMPLEADO)
			par = CType(oParams.Item("@FECHAENTRADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAENTRADA)
			par = CType(oParams.Item("@ENTRADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.ENTRADA)
			par = CType(oParams.Item("@FECHASALIDA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHASALIDA)
			par = CType(oParams.Item("@SALIDA"), IDataParameter)
			par.Value = F_ValueToNull(entity.SALIDA)
			par = CType(oParams.Item("@HORASTRABAJADAS"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORASTRABAJADAS)
			par = CType(oParams.Item("@MINUTOSTARDE"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSTARDE)
			par = CType(oParams.Item("@INCONGRUENCIAS"), IDataParameter)
			par.Value = F_BooleanToValue(entity.INCONGRUENCIAS, par)
			par = CType(oParams.Item("@IDHORARIOEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDHORARIOEMPLEADO)
			par = CType(oParams.Item("@IDHORARIOADICEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDHORARIOADICEMPLEADO)
			par = CType(oParams.Item("@TIPO"), IDataParameter)
			par.Value = F_ValueToNull(entity.TIPO)
			par = CType(oParams.Item("@IDRELOJ"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDRELOJ)
			par = CType(oParams.Item("@BORRADO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.BORRADO, par)
			par = CType(oParams.Item("@IDUSUARIOBORRADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOBORRADO)

            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) > 0 Then
				bOk = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo insertar la Fichada"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If
			par = CType(oParams.Item("@ID"), IDataParameter)
			Entity.ID = par.Value 
		Catch ex As Exception
			MyBase.ConError = True
		MyBase.Exception = ex
		MyBase.Error = "No se pudo insertar la Fichada"
		MyBase.InternalError = ex.Message
		bOk = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bOk
	End Function

	Public function UpdateSP(Entity as Fichada, Optional ByVal ThrowErr As Boolean = False) as Boolean
        Dim sql As String = "A_Fichada_U"
        Dim oParams As IDataParameterCollection 
        Dim par As IDataParameter
		Dim bOk as Boolean
		Try
			oParams = oCon.ObtenerParametros(Sql)
			par = CType(oParams.Item("@ID"), IDataParameter)
			par.Value = F_ValueToNull(entity.ID)
			par = CType(oParams.Item("@IDEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDEMPLEADO)
			par = CType(oParams.Item("@FECHAENTRADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHAENTRADA)
			par = CType(oParams.Item("@ENTRADA"), IDataParameter)
			par.Value = F_ValueToNull(entity.ENTRADA)
			par = CType(oParams.Item("@FECHASALIDA"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHASALIDA)
			par = CType(oParams.Item("@SALIDA"), IDataParameter)
			par.Value = F_ValueToNull(entity.SALIDA)
			par = CType(oParams.Item("@HORASTRABAJADAS"), IDataParameter)
			par.Value = F_ValueToNull(entity.HORASTRABAJADAS)
			par = CType(oParams.Item("@MINUTOSTARDE"), IDataParameter)
			par.Value = F_ValueToNull(entity.MINUTOSTARDE)
			par = CType(oParams.Item("@INCONGRUENCIAS"), IDataParameter)
			par.Value = F_BooleanToValue(entity.INCONGRUENCIAS, par)
			par = CType(oParams.Item("@IDHORARIOEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDHORARIOEMPLEADO)
			par = CType(oParams.Item("@IDHORARIOADICEMPLEADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDHORARIOADICEMPLEADO)
			par = CType(oParams.Item("@TIPO"), IDataParameter)
			par.Value = F_ValueToNull(entity.TIPO)
			par = CType(oParams.Item("@IDRELOJ"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDRELOJ)
			par = CType(oParams.Item("@BORRADO"), IDataParameter)
			par.Value = F_BooleanToValue(entity.BORRADO, par)
			par = CType(oParams.Item("@IDUSUARIOBORRADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.IDUSUARIOBORRADO)
			par = CType(oParams.Item("@FECHABORRADO"), IDataParameter)
			par.Value = F_ValueToNull(entity.FECHABORRADO)
	
            If oCon.EjecutarNonQuery(CommandType.StoredProcedure, sql, oParams) >= 0 Then
				bok = true
			Else
				If Not IsNothing(oCon.Exception) Then
                    MyBase.InternalError = oCon.Exception.Message
					MyBase.Exception = oCon.Exception
                End If
				MyBase.ConError = True
				MyBase.Error = "No se pudo actualizar la Fichada"
				bOk = false
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
			End If

			
		Catch ex As Exception
			MyBase.ConError = True
            MyBase.Exception = ex
            MyBase.Error = "No se pudo actualizar la Fichada"
            MyBase.InternalError = ex.Message
			bok = false
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

		return bok
	End Function

	Public Function GetDtTableById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As DataTable
        Dim sql As String = "A_FichadaGetById"
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
        Dim sql As String  = "A_FichadaGetById"		
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
			MyBase.Error = "No se pudo buscar la Fichada"
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()	
		End Try
		
		Return drDatos
	End Function

	Public Function GetEntityById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As Fichada
		Dim entity as Fichada
	    Dim DtDatos As DataTable
		try
			DtDatos = GetDtTableById(ID, ThrowErr)
			If DtDatos.Rows.Count > 0 Then entity = Make(DtDatos.Rows(0))
        Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo buscar la Fichada"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oCon.DesConectar()
		End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As Fichada, Optional ByVal ThrowErr As Boolean = False) As List(Of Fichada)
        Dim DtDatos As DataTable
        Dim listEntities As New List(Of Fichada)
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
            MyBase.Error = "No se pudo buscar la Fichada"
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oCon.DesConectar()
        End Try

        Return listEntities
    End Function
	
	Private Function Make(reader as IDataReader, Optional ByVal ThrowErr As Boolean = False) as Fichada
		Dim entity as Fichada
		Try
			entity = new Fichada
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
				if reader("FECHAENTRADA") is System.DbNull.Value then
					entity.FECHAENTRADA = F_Set_nullValue(entity.FECHAENTRADA)
				else
					entity.FECHAENTRADA = CType(reader("FECHAENTRADA"),DateTime)
				end if		
				if reader("ENTRADA") is System.DbNull.Value then
					entity.ENTRADA = F_Set_nullValue(entity.ENTRADA)
				else
					entity.ENTRADA = CType(reader("ENTRADA"),Long)
				end if		
				if reader("FECHASALIDA") is System.DbNull.Value then
					entity.FECHASALIDA = F_Set_nullValue(entity.FECHASALIDA)
				else
					entity.FECHASALIDA = CType(reader("FECHASALIDA"),DateTime)
				end if		
				if reader("SALIDA") is System.DbNull.Value then
					entity.SALIDA = F_Set_nullValue(entity.SALIDA)
				else
					entity.SALIDA = CType(reader("SALIDA"),Long)
				end if		
				if reader("HORASTRABAJADAS") is System.DbNull.Value then
					entity.HORASTRABAJADAS = F_Set_nullValue(entity.HORASTRABAJADAS)
				else
					entity.HORASTRABAJADAS = CType(reader("HORASTRABAJADAS"),Long)
				end if		
				if reader("MINUTOSTARDE") is System.DbNull.Value then
					entity.MINUTOSTARDE = F_Set_nullValue(entity.MINUTOSTARDE)
				else
					entity.MINUTOSTARDE = CType(reader("MINUTOSTARDE"),Long)
				end if		
				if reader("INCONGRUENCIAS") is System.DbNull.Value then
					entity.INCONGRUENCIAS = F_Set_nullValue(entity.INCONGRUENCIAS)
				else
					entity.INCONGRUENCIAS = F_ValueToBoolean(reader("INCONGRUENCIAS"))
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
				if reader("TIPO") is System.DbNull.Value then
					entity.TIPO = F_Set_nullValue(entity.TIPO)
				else
					entity.TIPO = CType(reader("TIPO"),String)
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
				if reader("BORRADO") is System.DbNull.Value then
					entity.BORRADO = F_Set_nullValue(entity.BORRADO)
				else
					entity.BORRADO = F_ValueToBoolean(reader("BORRADO"))
				end if		
				if reader("IDUSUARIOBORRADO") is System.DbNull.Value then
					entity.IDUSUARIOBORRADO = F_Set_nullValue(entity.IDUSUARIOBORRADO)
				else
					entity.IDUSUARIOBORRADO = CType(reader("IDUSUARIOBORRADO"),String)
				end if		
				if reader("IDUSUARIOBORRADO_Desc") is System.DbNull.Value then
					entity.IDUSUARIOBORRADO_Desc = F_Set_nullValue(entity.IDUSUARIOBORRADO_Desc)
				else
					entity.IDUSUARIOBORRADO_Desc = CType(reader("IDUSUARIOBORRADO_Desc"),String)
				end if		
				if reader("FECHABORRADO") is System.DbNull.Value then
					entity.FECHABORRADO = F_Set_nullValue(entity.FECHABORRADO)
				else
					entity.FECHABORRADO = CType(reader("FECHABORRADO"),DateTime)
				end if		
		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la Fichada"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function

	
	Private Function Make(row as DataRow, Optional ByVal ThrowErr As Boolean = False) as Fichada
		Dim entity as Fichada
		Try
		
			entity = new Fichada
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
	if F_Contains(row, "FECHAENTRADA") then
		if row("FECHAENTRADA") is System.DbNull.Value then
			entity.FECHAENTRADA = F_Set_nullValue(entity.FECHAENTRADA)
		else
			entity.FECHAENTRADA = CType(row("FECHAENTRADA"),DateTime)
		end if
	end if
	if F_Contains(row, "ENTRADA") then
		if row("ENTRADA") is System.DbNull.Value then
			entity.ENTRADA = F_Set_nullValue(entity.ENTRADA)
		else
			entity.ENTRADA = CType(row("ENTRADA"),Long)
		end if
	end if
	if F_Contains(row, "FECHASALIDA") then
		if row("FECHASALIDA") is System.DbNull.Value then
			entity.FECHASALIDA = F_Set_nullValue(entity.FECHASALIDA)
		else
			entity.FECHASALIDA = CType(row("FECHASALIDA"),DateTime)
		end if
	end if
	if F_Contains(row, "SALIDA") then
		if row("SALIDA") is System.DbNull.Value then
			entity.SALIDA = F_Set_nullValue(entity.SALIDA)
		else
			entity.SALIDA = CType(row("SALIDA"),Long)
		end if
	end if
	if F_Contains(row, "HORASTRABAJADAS") then
		if row("HORASTRABAJADAS") is System.DbNull.Value then
			entity.HORASTRABAJADAS = F_Set_nullValue(entity.HORASTRABAJADAS)
		else
			entity.HORASTRABAJADAS = CType(row("HORASTRABAJADAS"),Long)
		end if
	end if
	if F_Contains(row, "MINUTOSTARDE") then
		if row("MINUTOSTARDE") is System.DbNull.Value then
			entity.MINUTOSTARDE = F_Set_nullValue(entity.MINUTOSTARDE)
		else
			entity.MINUTOSTARDE = CType(row("MINUTOSTARDE"),Long)
		end if
	end if
	if F_Contains(row, "INCONGRUENCIAS") then
		if row("INCONGRUENCIAS") is System.DbNull.Value then
			entity.INCONGRUENCIAS = F_Set_nullValue(entity.INCONGRUENCIAS)
		else
			entity.INCONGRUENCIAS = F_ValueToBoolean(row("INCONGRUENCIAS"))
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
	if F_Contains(row, "TIPO") then
		if row("TIPO") is System.DbNull.Value then
			entity.TIPO = F_Set_nullValue(entity.TIPO)
		else
			entity.TIPO = CType(row("TIPO"),String)
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
	if F_Contains(row, "BORRADO") then
		if row("BORRADO") is System.DbNull.Value then
			entity.BORRADO = F_Set_nullValue(entity.BORRADO)
		else
			entity.BORRADO = F_ValueToBoolean(row("BORRADO"))
		end if
	end if
	if F_Contains(row, "IDUSUARIOBORRADO") then
		if row("IDUSUARIOBORRADO") is System.DbNull.Value then
			entity.IDUSUARIOBORRADO = F_Set_nullValue(entity.IDUSUARIOBORRADO)
		else
			entity.IDUSUARIOBORRADO = CType(row("IDUSUARIOBORRADO"),String)
		end if
	end if
	if F_Contains(row, "IDUSUARIOBORRADO_Desc") then
		if row("IDUSUARIOBORRADO_Desc") is System.DbNull.Value then
			entity.IDUSUARIOBORRADO_Desc = F_Set_nullValue(entity.IDUSUARIOBORRADO_Desc)
		else
			entity.IDUSUARIOBORRADO_Desc = CType(row("IDUSUARIOBORRADO_Desc"),String)
		end if
	end if
	if F_Contains(row, "FECHABORRADO") then
		if row("FECHABORRADO") is System.DbNull.Value then
			entity.FECHABORRADO = F_Set_nullValue(entity.FECHABORRADO)
		else
			entity.FECHABORRADO = CType(row("FECHABORRADO"),DateTime)
		end if
	end if

		Catch ex As Exception
			MyBase.InternalError = ex.Message
			MyBase.ConError = True
			MyBase.Exception = ex
			MyBase.Error = "No se pudo cargar la Fichada"
			entity = nothing
			If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally

		End Try

		return entity
	End Function
	
#End Region

Public Function GetEntreFechas(Byval FECHADESDE as Date, Byval FECHAHASTA as Date
) As List (of Fichada)
        Dim sql As String = "A_FICHADAGETENTREFECHA"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Fichada)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHADESDE_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHADESDE)
		
			par = CType(oParams.Item("@FECHAHASTA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAHASTA)
		
			Dim entity As Fichada
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

Public Function GetEntreFechasSalida(Byval FECHADESDE as Date, Byval FECHAHASTA as Date
) As List (of Fichada)
        Dim sql As String = "A_FICHADAGETENTREFECHASALIDA"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Fichada)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHADESDE_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHADESDE)
		
			par = CType(oParams.Item("@FECHAHASTA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAHASTA)
		
			Dim entity As Fichada
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

Public Function GetPorEmpleadoFechaEntrada(Byval FECHAENTRADA as Date, Byval IDEMPLEADO as Long
) As List (of Fichada)
        Dim sql As String = "A_FICHADAGETEMPFECHAENTRADA"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Fichada)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHAENTRADA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAENTRADA)
		
			par = CType(oParams.Item("@IDEMPLEADO_I"), IDataParameter)
			par.Value = F_ValueToNull(IDEMPLEADO)
		
			Dim entity As Fichada
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

Public Function GetPorEmpleadoEntrada(Byval FECHAENTRADA as Date, Byval ENTRADA as Long, Byval IDEMPLEADO as Long
) As List (of Fichada)
        Dim sql As String = "A_FICHADAGETEMPLEADOENTRADA"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Fichada)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHAENTRADA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAENTRADA)
		
			par = CType(oParams.Item("@ENTRADA_I"), IDataParameter)
			par.Value = F_ValueToNull(ENTRADA)
		
			par = CType(oParams.Item("@IDEMPLEADO_I"), IDataParameter)
			par.Value = F_ValueToNull(IDEMPLEADO)
		
			Dim entity As Fichada
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

Public Function GetPorEmpleadoSalida(Byval FECHASALIDA as Date, Byval SALIDA as Long, Byval IDEMPLEADO as Long
) As List (of Fichada)
        Dim sql As String = "A_FICHADAGETEMPLEADOSALIDA"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Fichada)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHASALIDA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHASALIDA)
		
			par = CType(oParams.Item("@SALIDA_I"), IDataParameter)
			par.Value = F_ValueToNull(SALIDA)
		
			par = CType(oParams.Item("@IDEMPLEADO_I"), IDataParameter)
			par.Value = F_ValueToNull(IDEMPLEADO)
		
			Dim entity As Fichada
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

Public Function GetPorEmpleadoFechaSalida(Byval FECHASALIDA as Date, Byval IDEMPLEADO as Long
) As List (of Fichada)
        Dim sql As String = "A_FICHADAGETEMPFECHASALIDA"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Fichada)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHASALIDA_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHASALIDA)
		
			par = CType(oParams.Item("@IDEMPLEADO_I"), IDataParameter)
			par.Value = F_ValueToNull(IDEMPLEADO)
		
			Dim entity As Fichada
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

Public Function GetByRelojEntreFechas(Byval FECHAENTRADAD as Date, Byval FECHAENTRADAH as Date, Byval IDRELOJ as String
) As List (of Fichada)
        Dim sql As String = "A_FICHADAGETBYRELOJENTREFECHA"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Fichada)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@FECHAENTRADAD_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAENTRADAD)
		
			par = CType(oParams.Item("@FECHAENTRADAH_I"), IDataParameter)
			par.Value = F_ValueToNull(FECHAENTRADAH)
		
			par = CType(oParams.Item("@IDRELOJ_I"), IDataParameter)
			par.Value = F_ValueToNull(IDRELOJ)
		
			Dim entity As Fichada
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

Public Function GetByReloj(Byval IDRELOJ as String
) As List (of Fichada)
        Dim sql As String = "A_FICHADAGETBYRELOJ"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Fichada)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			par = CType(oParams.Item("@IDRELOJ_I"), IDataParameter)
			par.Value = F_ValueToNull(IDRELOJ)
		
			Dim entity As Fichada
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

Public Function GetIncongruencias() As List (of Fichada)
        Dim sql As String = "A_FICHADAGETINCONGRUENCIAS"
        Dim oParams As IDataParameterCollection
        Dim DtDatos As DataTable
        Dim par As IDataParameter
		Dim listEntities as New List (of Fichada)
	
        Try
            oParams = oCon.ObtenerParametros(sql)		
			Dim entity As Fichada
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

