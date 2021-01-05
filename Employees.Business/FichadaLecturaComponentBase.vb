
'
'	Project Employees
'		Employees Example
'	Entity	FichadaLectura
'		FichadaLectura Entity
'	
'	Generado por Victor.

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Employees.Entities
Imports Employees.Data

Public Partial Class FichadaLecturaComponentBase
	Inherits BaseComponent
	
	#Region "Constructor"
		Public Sub New()
			MyBase.New()
		End Sub

		Public Sub New(ByVal nConnectionString As String)
			MyBase.New(nConnectionString)
		End Sub
	#End Region
	
	Public Overridable Function Validate(Byref entity as FichadaLectura) As Boolean
		Dim bOk As Boolean = True
        Try
			If Not entity.DirtyFields.ContainsKey("INCONSISTENCIA") Then
                entity.DirtyFields.Add("INCONSISTENCIA", entity.INCONSISTENCIA)
            End If
			If Not entity.DirtyFields.ContainsKey("DESCARTADA") Then
                entity.DirtyFields.Add("DESCARTADA", entity.DESCARTADA)
            End If

			if F_IsNullValue(entity.IDEMPLEADOLECTORA) Then
				bOk = False 
				Throw New Exception("IDEMPLEADOLECTORA required")
			End if
			if F_IsNullValue(entity.FECHAFICHADA) Then
				bOk = False 
				Throw New Exception("FECHAFICHADA required")
			End if
			if F_IsNullValue(entity.TIPOFICHADA) Then
				bOk = False 
				Throw New Exception("TIPOFICHADA required")
			End if
      Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la FichadaLectura"
            MyBase.ConError = True
            bOk = False
        End Try

        Return bOk
    End Function

	Public Overridable Function ValidateNew(Byref entity as FichadaLectura) As Boolean
		Dim bOk As Boolean = True
        Try
		
			If Not entity.DirtyFields.ContainsKey("INCONSISTENCIA") Then
                entity.DirtyFields.Add("INCONSISTENCIA", entity.INCONSISTENCIA)
            End If
			If Not entity.DirtyFields.ContainsKey("DESCARTADA") Then
                entity.DirtyFields.Add("DESCARTADA", entity.DESCARTADA)
            End If
		
			
			if F_IsNullValue(entity.IDEMPLEADOLECTORA) Then
				bOk = False 
				Throw New Exception("IDEMPLEADOLECTORA required")
			End if
			if F_IsNullValue(entity.FECHAFICHADA) Then
				bOk = False 
				Throw New Exception("FECHAFICHADA required")
			End if
			if F_IsNullValue(entity.TIPOFICHADA) Then
				bOk = False 
				Throw New Exception("TIPOFICHADA required")
			End if
	    Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la FichadaLectura"
            MyBase.ConError = True
            bOk = False
        End Try

        Return bOk
    End Function

	Public Overridable Function ValidateDelete(Byref entity as FichadaLectura) As Boolean
		Return False
	End Function


	Public Function Save(Byref col As List (of FichadaLectura), Optional ByVal sp as Boolean = true, Optional byref QInsert As Integer = 0, Optional ByRef QUpdate As Integer = 0, Optional ByVal ThrowErr As Boolean = False) As Boolean
		Dim FichadaLecturaDal as New FichadaLecturaData
		Dim bResul As Boolean = True
		Dim strError As String = String.Empty
		Dim flgHuboCambios As Boolean = False
		Try
			FichadaLecturaDal.BeginTransaction()
			For Each entity As FichadaLectura In col
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
				FichadaLecturaDal.CancelTransaction()
				If strError = String.Empty Then strError = "No hay nada para guardar."
				bResul = False
			End If
			If bResul = True Then
				FichadaLecturaDal.CommitTransaction()
			Else
				Throw New Exception(strError)
			End If
        	Catch ex As Exception
				FichadaLecturaDal.CancelTransaction()
				Dim strLog As String = ""
				strLog &= "Error FichadaLectura.Save (" & TimeOfDay.ToString("HH:mm:ss tt") & ")" & vbCrLf
				strLog &= "Mensje Error: " & ex.Message & vbCrLf
				mobjLog.SaveTXT(strLog)
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        	Finally
				FichadaLecturaDal.Desconectar()
        	End Try
        	Return bResul
	End Function


	Public Function Save(Byref entity As FichadaLectura, Optional ByVal sp as Boolean = true, Optional ByVal ThrowErr As Boolean = False) As Boolean
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

	Private Function Insert(Byref entity as FichadaLectura, Optional ByVal sp as Boolean = true, Optional ByVal ThrowErr As Boolean = False) As Boolean
		Dim oDal As New FichadaLecturaData
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
            MyBase.Error = "No se pudo insertar la FichadaLectura"
            MyBase.ConError = True
            bOk = False
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try

		Return bOk
	End Function
		
	Private Function Update(Byref entity as FichadaLectura, Optional ByVal sp as Boolean = true, Optional ByVal ThrowErr As Boolean = False) As Boolean
		Dim oDal As New FichadaLecturaData
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
            MyBase.Error = "No se pudo actualizar la FichadaLectura"
            MyBase.ConError = True
	    If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
            bOk = False
            If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try

        Return bOk
    End Function

	Public Function GetEntById(Byval ID as Long , Optional ByVal ThrowErr As Boolean = False) As FichadaLectura
		Dim oDal As New FichadaLecturaData
		Dim entity as FichadaLectura
		Try
	        entity = oDal.GetEntityById(ID, ThrowErr)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la FichadaLectura"
            MyBase.ConError = True
            entity = Nothing
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As FichadaLectura, Optional ByVal ThrowErr As Boolean = False) As List(Of FichadaLectura)
        Dim oDal As New FichadaLecturaData
        Dim listentity As New List(Of FichadaLectura)
        Try
            listentity = oDal.GetListByEnt(entity, ThrowErr)
        Catch ex As Exception
            listentity = Nothing
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la FichadaLectura"
            MyBase.ConError = True
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oDal = Nothing
        End Try

        Return listentity
    End Function
	
	Public Function GetDRById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As IDataReader
		Dim oDal As New FichadaLecturaData
		Dim oDatos as IDataReader
		Try
	        oDatos = oDal.GetDReaderById(ID, ThrowErr)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la FichadaLectura"
            MyBase.ConError = True
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try
		
		return oDatos
	End Function

	Public Function GetRepetido(
Byval IDEMPLEADOLECTORA as String, Byval FECHAFICHADA as Date, Byval IDRELOJ as String, Byval TIPOFICHADA as String
) As List (of FichadaLectura)
		Dim oDal As New FichadaLecturaData
		Try
	        Return oDal.GetRepetido(
IDEMPLEADOLECTORA, FECHAFICHADA, IDRELOJ, TIPOFICHADA
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la FichadaLectura"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	
	Public Function GetHuerfanos(
) As List (of FichadaLectura)
		Dim oDal As New FichadaLecturaData
		Try
	        Return oDal.GetHuerfanos(
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la FichadaLectura"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	
	Public Function GetxIdEmpleadoSinProcesar(
Byval IDEMPLEADO as Integer
) As List (of FichadaLectura)
		Dim oDal As New FichadaLecturaData
		Try
	        Return oDal.GetxIdEmpleadoSinProcesar(
IDEMPLEADO
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la FichadaLectura"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	
	Public Function GetTodoEntreFechas(
Byval FECHADESDE as Date, Byval FECHAHASTA as Date
) As List (of FichadaLectura)
		Dim oDal As New FichadaLecturaData
		Try
	        Return oDal.GetTodoEntreFechas(
FECHADESDE, FECHAHASTA
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la FichadaLectura"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	
	Public Function GetTodoEntreFechasGrupo(
Byval FECHADESDE as Date, Byval FECHAHASTA as Date, Byval IDGRUPO as Integer
) As List (of FichadaLectura)
		Dim oDal As New FichadaLecturaData
		Try
	        Return oDal.GetTodoEntreFechasGrupo(
FECHADESDE, FECHAHASTA, IDGRUPO
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la FichadaLectura"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	


End Class

