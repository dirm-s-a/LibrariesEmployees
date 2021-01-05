
'
'	Project Employees
'		Employees Example
'	Entity	TipoAusencia
'		TipoAusencia Entity
'	
'	Generado por Victor.

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Employees.Entities
Imports Employees.Data

Public Partial Class TipoAusenciaComponentBase
	Inherits BaseComponent
	
	#Region "Constructor"
		Public Sub New()
			MyBase.New()
		End Sub

		Public Sub New(ByVal nConnectionString As String)
			MyBase.New(nConnectionString)
		End Sub
	#End Region
	
	Public Overridable Function Validate(Byref entity as TipoAusencia) As Boolean
		Dim bOk As Boolean = True
        Try
			If Not entity.DirtyFields.ContainsKey("JUSTIFICADA") Then
                entity.DirtyFields.Add("JUSTIFICADA", entity.JUSTIFICADA)
            End If
			If Not entity.DirtyFields.ContainsKey("PIERDEPRESENTISMO") Then
                entity.DirtyFields.Add("PIERDEPRESENTISMO", entity.PIERDEPRESENTISMO)
            End If
			If Not entity.DirtyFields.ContainsKey("ACTIVO") Then
                entity.DirtyFields.Add("ACTIVO", entity.ACTIVO)
            End If

			if F_IsNullValue(entity.DESCRIPCION) Then
				bOk = False 
				Throw New Exception("DESCRIPCION required")
			End if
			if F_IsNullValue(entity.IDUDUARIOALTA) Then
				bOk = False 
				Throw New Exception("IDUDUARIOALTA required")
			End if
      Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la TipoAusencia"
            MyBase.ConError = True
            bOk = False
        End Try

        Return bOk
    End Function

	Public Overridable Function ValidateNew(Byref entity as TipoAusencia) As Boolean
		Dim bOk As Boolean = True
        Try
		
			If Not entity.DirtyFields.ContainsKey("JUSTIFICADA") Then
                entity.DirtyFields.Add("JUSTIFICADA", entity.JUSTIFICADA)
            End If
			If Not entity.DirtyFields.ContainsKey("PIERDEPRESENTISMO") Then
                entity.DirtyFields.Add("PIERDEPRESENTISMO", entity.PIERDEPRESENTISMO)
            End If
			If Not entity.DirtyFields.ContainsKey("ACTIVO") Then
                entity.DirtyFields.Add("ACTIVO", entity.ACTIVO)
            End If
		
			
			if F_IsNullValue(entity.DESCRIPCION) Then
				bOk = False 
				Throw New Exception("DESCRIPCION required")
			End if
			if F_IsNullValue(entity.IDUDUARIOALTA) Then
				bOk = False 
				Throw New Exception("IDUDUARIOALTA required")
			End if
	    Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la TipoAusencia"
            MyBase.ConError = True
            bOk = False
        End Try

        Return bOk
    End Function

	Public Overridable Function ValidateDelete(Byref entity as TipoAusencia) As Boolean
		Return False
	End Function


	Public Function Save(Byref col As List (of TipoAusencia), Optional ByVal sp as Boolean = true, Optional byref QInsert As Integer = 0, Optional ByRef QUpdate As Integer = 0, Optional ByVal ThrowErr As Boolean = False) As Boolean
		Dim TipoAusenciaDal as New TipoAusenciaData
		Dim bResul As Boolean = True
		Dim strError As String = String.Empty
		Dim flgHuboCambios As Boolean = False
		Try
			TipoAusenciaDal.BeginTransaction()
			For Each entity As TipoAusencia In col
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
				TipoAusenciaDal.CancelTransaction()
				If strError = String.Empty Then strError = "No hay nada para guardar."
				bResul = False
			End If
			If bResul = True Then
				TipoAusenciaDal.CommitTransaction()
			Else
				Throw New Exception(strError)
			End If
        	Catch ex As Exception
				TipoAusenciaDal.CancelTransaction()
				Dim strLog As String = ""
				strLog &= "Error TipoAusencia.Save (" & TimeOfDay.ToString("HH:mm:ss tt") & ")" & vbCrLf
				strLog &= "Mensje Error: " & ex.Message & vbCrLf
				mobjLog.SaveTXT(strLog)
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        	Finally
				TipoAusenciaDal.Desconectar()
        	End Try
        	Return bResul
	End Function


	Public Function Save(Byref entity As TipoAusencia, Optional ByVal sp as Boolean = true, Optional ByVal ThrowErr As Boolean = False) As Boolean
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

	Private Function Insert(Byref entity as TipoAusencia, Optional ByVal sp as Boolean = true, Optional ByVal ThrowErr As Boolean = False) As Boolean
		Dim oDal As New TipoAusenciaData
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
            MyBase.Error = "No se pudo insertar la TipoAusencia"
            MyBase.ConError = True
            bOk = False
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try

		Return bOk
	End Function
		
	Private Function Update(Byref entity as TipoAusencia, Optional ByVal sp as Boolean = true, Optional ByVal ThrowErr As Boolean = False) As Boolean
		Dim oDal As New TipoAusenciaData
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
            MyBase.Error = "No se pudo actualizar la TipoAusencia"
            MyBase.ConError = True
	    If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
            bOk = False
            If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try

        Return bOk
    End Function

	Public Function GetEntById(Byval ID as Long , Optional ByVal ThrowErr As Boolean = False) As TipoAusencia
		Dim oDal As New TipoAusenciaData
		Dim entity as TipoAusencia
		Try
	        entity = oDal.GetEntityById(ID, ThrowErr)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la TipoAusencia"
            MyBase.ConError = True
            entity = Nothing
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As TipoAusencia, Optional ByVal ThrowErr As Boolean = False) As List(Of TipoAusencia)
        Dim oDal As New TipoAusenciaData
        Dim listentity As New List(Of TipoAusencia)
        Try
            listentity = oDal.GetListByEnt(entity, ThrowErr)
        Catch ex As Exception
            listentity = Nothing
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la TipoAusencia"
            MyBase.ConError = True
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oDal = Nothing
        End Try

        Return listentity
    End Function
	
	Public Function GetDRById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As IDataReader
		Dim oDal As New TipoAusenciaData
		Dim oDatos as IDataReader
		Try
	        oDatos = oDal.GetDReaderById(ID, ThrowErr)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la TipoAusencia"
            MyBase.ConError = True
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try
		
		return oDatos
	End Function

	Public Function GetALL(
) As List (of TipoAusencia)
		Dim oDal As New TipoAusenciaData
		Try
	        Return oDal.GetALL(
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la TipoAusencia"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	


End Class

