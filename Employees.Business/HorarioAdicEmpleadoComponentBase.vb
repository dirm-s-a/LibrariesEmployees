
'
'	Project Employees
'		Employees Example
'	Entity	HorarioAdicEmpleado
'		HorarioAdicEmpleado Entity
'	
'	Generado por Victor.

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Employees.Entities
Imports Employees.Data

Public Partial Class HorarioAdicEmpleadoComponentBase
	Inherits BaseComponent
	
	#Region "Constructor"
		Public Sub New()
			MyBase.New()
		End Sub

		Public Sub New(ByVal nConnectionString As String)
			MyBase.New(nConnectionString)
		End Sub
	#End Region
	
	Public Overridable Function Validate(Byref entity as HorarioAdicEmpleado) As Boolean
		Dim bOk As Boolean = True
        Try
			If Not entity.DirtyFields.ContainsKey("ACTIVO") Then
                entity.DirtyFields.Add("ACTIVO", entity.ACTIVO)
            End If
			If Not entity.DirtyFields.ContainsKey("AUTORIZADO") Then
                entity.DirtyFields.Add("AUTORIZADO", entity.AUTORIZADO)
            End If

			if F_IsNullValue(entity.IDEMPLEADO) Then
				bOk = False 
				Throw New Exception("IDEMPLEADO required")
			End if
			if F_IsNullValue(entity.FECHADESDE) Then
				bOk = False 
				Throw New Exception("FECHADESDE required")
			End if
			if F_IsNullValue(entity.FECHAHASTA) Then
				bOk = False 
				Throw New Exception("FECHAHASTA required")
			End if
			if F_IsNullValue(entity.HORAENTRADA) Then
				bOk = False 
				Throw New Exception("HORAENTRADA required")
			End if
			if F_IsNullValue(entity.HORASALIDA) Then
				bOk = False 
				Throw New Exception("HORASALIDA required")
			End if
			if F_IsNullValue(entity.IDUSUARIOMODIFICACION) Then
				bOk = False 
				Throw New Exception("IDUSUARIOMODIFICACION required")
			End if
      Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la HorarioAdicEmpleado"
            MyBase.ConError = True
            bOk = False
        End Try

        Return bOk
    End Function

	Public Overridable Function ValidateNew(Byref entity as HorarioAdicEmpleado) As Boolean
		Dim bOk As Boolean = True
        Try
		
			If Not entity.DirtyFields.ContainsKey("ACTIVO") Then
                entity.DirtyFields.Add("ACTIVO", entity.ACTIVO)
            End If
			If Not entity.DirtyFields.ContainsKey("AUTORIZADO") Then
                entity.DirtyFields.Add("AUTORIZADO", entity.AUTORIZADO)
            End If
		
			
			if F_IsNullValue(entity.IDEMPLEADO) Then
				bOk = False 
				Throw New Exception("IDEMPLEADO required")
			End if
			if F_IsNullValue(entity.FECHADESDE) Then
				bOk = False 
				Throw New Exception("FECHADESDE required")
			End if
			if F_IsNullValue(entity.FECHAHASTA) Then
				bOk = False 
				Throw New Exception("FECHAHASTA required")
			End if
			if F_IsNullValue(entity.HORAENTRADA) Then
				bOk = False 
				Throw New Exception("HORAENTRADA required")
			End if
			if F_IsNullValue(entity.HORASALIDA) Then
				bOk = False 
				Throw New Exception("HORASALIDA required")
			End if
			if F_IsNullValue(entity.IDUSUARIOMODIFICACION) Then
				bOk = False 
				Throw New Exception("IDUSUARIOMODIFICACION required")
			End if
	    Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la HorarioAdicEmpleado"
            MyBase.ConError = True
            bOk = False
        End Try

        Return bOk
    End Function

	Public Overridable Function ValidateDelete(Byref entity as HorarioAdicEmpleado) As Boolean
		Return False
	End Function


	Public Function Save(Byref col As List (of HorarioAdicEmpleado), Optional ByVal sp as Boolean = true, Optional byref QInsert As Integer = 0, Optional ByRef QUpdate As Integer = 0, Optional ByVal ThrowErr As Boolean = False) As Boolean
		Dim HorarioAdicEmpleadoDal as New HorarioAdicEmpleadoData
		Dim bResul As Boolean = True
		Dim strError As String = String.Empty
		Dim flgHuboCambios As Boolean = False
		Try
			HorarioAdicEmpleadoDal.BeginTransaction()
			For Each entity As HorarioAdicEmpleado In col
				If entity.IsDirty Then
					If entity.IsNew Then
						If Insert(entity, sp, ThrowErr) = False Then
							strError = "Error al insertar cambios"
							bResul = False
							Exit For
						Else
							flgHuboCambios = True
							QInsert += 1
						End If
					Else
						If Update(entity, sp, ThrowErr) = False Then
							strError = "Error al actualizar cambios"
							bResul = False
							Exit For
						Else
							flgHuboCambios = True
							QUpdate += 1
						End If
					End If
				End If
			Next				
			If Not flgHuboCambios Then
				HorarioAdicEmpleadoDal.CancelTransaction()
				If strError = String.Empty Then strError = "No hay nada para guardar."
				bResul = False
			End If
			If bResul = True Then
				HorarioAdicEmpleadoDal.CommitTransaction()
			Else
				Throw New Exception(strError)
			End If
        	Catch ex As Exception
				HorarioAdicEmpleadoDal.CancelTransaction()
				Dim strLog As String = ""
				strLog &= "Error HorarioAdicEmpleado.Save (" & TimeOfDay.ToString("HH:mm:ss tt") & ")" & vbCrLf
				strLog &= "Mensje Error: " & ex.Message & vbCrLf
				mobjLog.SaveTXT(strLog)
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        	Finally
				HorarioAdicEmpleadoDal.Desconectar()
        	End Try
        	Return bResul
	End Function


	Public Function Save(Byref entity As HorarioAdicEmpleado, Optional ByVal sp as Boolean = true, Optional ByVal ThrowErr As Boolean = False) As Boolean
		Dim bOk As Boolean = False
		Try
			If entity.IsDirty Then
				If entity.IsNew Then
					bOk = Insert(entity, sp, ThrowErr)
				Else
					bOk = Update(entity, sp, ThrowErr)
				End If
			Else
				Throw New Exception("No hay datos para actualizar o cargar en la tabla")
				Return False
			End if
	        Catch ex As Exception
	            MyBase.InternalError = ex.Message
        	    MyBase.ConError = True
	            MyBase.Exception = ex
        	    MyBase.Error = "Error al guardar"
	            If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
	        End Try

		Return bOk
	End Function

	Private Function Insert(Byref entity as HorarioAdicEmpleado, Optional ByVal sp as Boolean = true, Optional ByVal ThrowErr As Boolean = False) As Boolean
		Dim oDal As New HorarioAdicEmpleadoData
		Dim bOk As Boolean = false
		Try
			If ValidateNew(entity) Then
				If sp Then
					bOk = oDal.InsertSP(entity, ThrowErr) 
				Else
					bOk = oDal.Insert(entity, ThrowErr) 
				End If
				
				If Not bOk Then
					MyBase.Exception = oDal.Exception 
					MyBase.InternalError = oDal.InternalError
					MyBase.Error = oDal.Error
					MyBase.ConError = True
					If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
				Else
					entity.EndUpdate()
				End If
			End If
		
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo insertar la HorarioAdicEmpleado"
            MyBase.ConError = True
            bOk = False
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try

		Return bOk
	End Function
		
	Private Function Update(Byref entity as HorarioAdicEmpleado, Optional ByVal sp as Boolean = true, Optional ByVal ThrowErr As Boolean = False) As Boolean
		Dim oDal As New HorarioAdicEmpleadoData
		Dim bOk As Boolean = false
		Try
			If Validate(entity) Then
				If sp Then
					bOk = oDal.UpdateSP(entity, ThrowErr) 
				Else
					bOk = oDal.Update(entity, ThrowErr) 
				End If
				
				If Not bOk Then
					MyBase.Exception = oDal.Exception 
					MyBase.InternalError = oDal.InternalError
					MyBase.Error = oDal.Error
					MyBase.ConError = True
					If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
				Else
					entity.EndUpdate()
				End IF
			End If
			
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo actualizar la HorarioAdicEmpleado"
            MyBase.ConError = True
	    If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
            bOk = False
            If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try

        Return bOk
    End Function

	Public Function GetEntById(Byval ID as Long , Optional ByVal ThrowErr As Boolean = False) As HorarioAdicEmpleado
		Dim oDal As New HorarioAdicEmpleadoData
		Dim entity as HorarioAdicEmpleado
		Try
	        entity = oDal.GetEntityById(ID, ThrowErr)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la HorarioAdicEmpleado"
            MyBase.ConError = True
            entity = Nothing
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As HorarioAdicEmpleado, Optional ByVal ThrowErr As Boolean = False) As List(Of HorarioAdicEmpleado)
        Dim oDal As New HorarioAdicEmpleadoData
        Dim listentity As New List(Of HorarioAdicEmpleado)
        Try
            listentity = oDal.GetListByEnt(entity, ThrowErr)
        Catch ex As Exception
            listentity = Nothing
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la HorarioAdicEmpleado"
            MyBase.ConError = True
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oDal = Nothing
        End Try

        Return listentity
    End Function
	
	Public Function GetDRById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As IDataReader
		Dim oDal As New HorarioAdicEmpleadoData
		Dim oDatos as IDataReader
		Try
	        oDatos = oDal.GetDReaderById(ID, ThrowErr)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la HorarioAdicEmpleado"
            MyBase.ConError = True
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try
		
		return oDatos
	End Function

	Public Function GetByEmpleado(
Byval IDEMPLEADO as Long
) As List (of HorarioAdicEmpleado)
		Dim oDal As New HorarioAdicEmpleadoData
		Try
	        Return oDal.GetByEmpleado(
IDEMPLEADO
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la HorarioAdicEmpleado"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	
	Public Function GetALL(
) As List (of HorarioAdicEmpleado)
		Dim oDal As New HorarioAdicEmpleadoData
		Try
	        Return oDal.GetALL(
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la HorarioAdicEmpleado"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	


End Class

