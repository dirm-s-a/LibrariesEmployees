
'
'	Project Employees
'		Employees Example
'	Entity	Fichada
'		Fichada Entity
'	
'	Generado por Victor.

Imports System.Collections.Generic

Imports Turnos.GlobalFunctions.Data
Imports Employees.Entities
Imports Employees.Data

Public Partial Class FichadaComponentBase
	Inherits BaseComponent
	
	#Region "Constructor"
		Public Sub New()
			MyBase.New()
		End Sub

		Public Sub New(ByVal nConnectionString As String)
			MyBase.New(nConnectionString)
		End Sub
	#End Region
	
	Public Overridable Function Validate(Byref entity as Fichada) As Boolean
		Dim bOk As Boolean = True
        Try
			If Not entity.DirtyFields.ContainsKey("INCONGRUENCIAS") Then
                entity.DirtyFields.Add("INCONGRUENCIAS", entity.INCONGRUENCIAS)
            End If
			If Not entity.DirtyFields.ContainsKey("BORRADO") Then
                entity.DirtyFields.Add("BORRADO", entity.BORRADO)
            End If

			if F_IsNullValue(entity.IDEMPLEADO) Then
				bOk = False 
				Throw New Exception("IDEMPLEADO required")
			End if
			if F_IsNullValue(entity.FECHAENTRADA) Then
				bOk = False 
				Throw New Exception("FECHAENTRADA required")
			End if
			if F_IsNullValue(entity.FECHASALIDA) Then
				bOk = False 
				Throw New Exception("FECHASALIDA required")
			End if
			if F_IsNullValue(entity.TIPO) Then
				bOk = False 
				Throw New Exception("TIPO required")
			End if
      Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la Fichada"
            MyBase.ConError = True
            bOk = False
        End Try

        Return bOk
    End Function

	Public Overridable Function ValidateNew(Byref entity as Fichada) As Boolean
		Dim bOk As Boolean = True
        Try
		
			If Not entity.DirtyFields.ContainsKey("INCONGRUENCIAS") Then
                entity.DirtyFields.Add("INCONGRUENCIAS", entity.INCONGRUENCIAS)
            End If
			If Not entity.DirtyFields.ContainsKey("BORRADO") Then
                entity.DirtyFields.Add("BORRADO", entity.BORRADO)
            End If
		
			
			if F_IsNullValue(entity.IDEMPLEADO) Then
				bOk = False 
				Throw New Exception("IDEMPLEADO required")
			End if
			if F_IsNullValue(entity.FECHAENTRADA) Then
				bOk = False 
				Throw New Exception("FECHAENTRADA required")
			End if
			if F_IsNullValue(entity.FECHASALIDA) Then
				bOk = False 
				Throw New Exception("FECHASALIDA required")
			End if
			if F_IsNullValue(entity.TIPO) Then
				bOk = False 
				Throw New Exception("TIPO required")
			End if
	    Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la Fichada"
            MyBase.ConError = True
            bOk = False
        End Try

        Return bOk
    End Function

	Public Overridable Function ValidateDelete(Byref entity as Fichada) As Boolean
		Return False
	End Function


	Public Function Save(Byref col As List (of Fichada), Optional ByVal sp as Boolean = true, Optional byref QInsert As Integer = 0, Optional ByRef QUpdate As Integer = 0, Optional ByVal ThrowErr As Boolean = False) As Boolean
		Dim FichadaDal as New FichadaData
		Dim bResul As Boolean = True
		Dim strError As String = String.Empty
		Dim flgHuboCambios As Boolean = False
		Try
			FichadaDal.BeginTransaction()
			For Each entity As Fichada In col
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
				FichadaDal.CancelTransaction()
				If strError = String.Empty Then strError = "No hay nada para guardar."
				bResul = False
			End If
			If bResul = True Then
				FichadaDal.CommitTransaction()
			Else
				Throw New Exception(strError)
			End If
        	Catch ex As Exception
				FichadaDal.CancelTransaction()
				Dim strLog As String = ""
				strLog &= "Error Fichada.Save (" & TimeOfDay.ToString("HH:mm:ss tt") & ")" & vbCrLf
				strLog &= "Mensje Error: " & ex.Message & vbCrLf
				mobjLog.SaveTXT(strLog)
				If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        	Finally
				FichadaDal.Desconectar()
        	End Try
        	Return bResul
	End Function


	Public Function Save(Byref entity As Fichada, Optional ByVal sp as Boolean = true, Optional ByVal ThrowErr As Boolean = False) As Boolean
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

	Private Function Insert(Byref entity as Fichada, Optional ByVal sp as Boolean = true, Optional ByVal ThrowErr As Boolean = False) As Boolean
		Dim oDal As New FichadaData
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
            MyBase.Error = "No se pudo insertar la Fichada"
            MyBase.ConError = True
            bOk = False
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try

		Return bOk
	End Function
		
	Private Function Update(Byref entity as Fichada, Optional ByVal sp as Boolean = true, Optional ByVal ThrowErr As Boolean = False) As Boolean
		Dim oDal As New FichadaData
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
            MyBase.Error = "No se pudo actualizar la Fichada"
            MyBase.ConError = True
	    If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
            bOk = False
            If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try

        Return bOk
    End Function

	Public Function GetEntById(Byval ID as Long , Optional ByVal ThrowErr As Boolean = False) As Fichada
		Dim oDal As New FichadaData
		Dim entity as Fichada
		Try
	        entity = oDal.GetEntityById(ID, ThrowErr)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la Fichada"
            MyBase.ConError = True
            entity = Nothing
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try
		
		return entity
	End Function

	Public Function GetListByEnt(ByVal entity As Fichada, Optional ByVal ThrowErr As Boolean = False) As List(Of Fichada)
        Dim oDal As New FichadaData
        Dim listentity As New List(Of Fichada)
        Try
            listentity = oDal.GetListByEnt(entity, ThrowErr)
        Catch ex As Exception
            listentity = Nothing
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la Fichada"
            MyBase.ConError = True
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
        Finally
            oDal = Nothing
        End Try

        Return listentity
    End Function
	
	Public Function GetDRById(Byval ID as Long, Optional ByVal ThrowErr As Boolean = False) As IDataReader
		Dim oDal As New FichadaData
		Dim oDatos as IDataReader
		Try
	        oDatos = oDal.GetDReaderById(ID, ThrowErr)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la Fichada"
            MyBase.ConError = True
		If ThrowErr Then Throw New System.Exception(MyBase.InternalError, MyBase.Exception)
		Finally
			oDal = Nothing
        End Try
		
		return oDatos
	End Function

	Public Function GetEntreFechas(
Byval FECHADESDE as Date, Byval FECHAHASTA as Date
) As List (of Fichada)
		Dim oDal As New FichadaData
		Try
	        Return oDal.GetEntreFechas(
FECHADESDE, FECHAHASTA
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la Fichada"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	
	Public Function GetEntreFechasSalida(
Byval FECHADESDE as Date, Byval FECHAHASTA as Date
) As List (of Fichada)
		Dim oDal As New FichadaData
		Try
	        Return oDal.GetEntreFechasSalida(
FECHADESDE, FECHAHASTA
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la Fichada"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	
	Public Function GetPorEmpleadoFechaEntrada(
Byval FECHAENTRADA as Date, Byval IDEMPLEADO as Long
) As List (of Fichada)
		Dim oDal As New FichadaData
		Try
	        Return oDal.GetPorEmpleadoFechaEntrada(
FECHAENTRADA, IDEMPLEADO
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la Fichada"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	
	Public Function GetPorEmpleadoEntrada(
Byval FECHAENTRADA as Date, Byval ENTRADA as Long, Byval IDEMPLEADO as Long
) As List (of Fichada)
		Dim oDal As New FichadaData
		Try
	        Return oDal.GetPorEmpleadoEntrada(
FECHAENTRADA, ENTRADA, IDEMPLEADO
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la Fichada"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	
	Public Function GetPorEmpleadoSalida(
Byval FECHASALIDA as Date, Byval SALIDA as Long, Byval IDEMPLEADO as Long
) As List (of Fichada)
		Dim oDal As New FichadaData
		Try
	        Return oDal.GetPorEmpleadoSalida(
FECHASALIDA, SALIDA, IDEMPLEADO
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la Fichada"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	
	Public Function GetPorEmpleadoFechaSalida(
Byval FECHASALIDA as Date, Byval IDEMPLEADO as Long
) As List (of Fichada)
		Dim oDal As New FichadaData
		Try
	        Return oDal.GetPorEmpleadoFechaSalida(
FECHASALIDA, IDEMPLEADO
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la Fichada"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	
	Public Function GetByRelojEntreFechas(
Byval FECHAENTRADAD as Date, Byval FECHAENTRADAH as Date, Byval IDRELOJ as String
) As List (of Fichada)
		Dim oDal As New FichadaData
		Try
	        Return oDal.GetByRelojEntreFechas(
FECHAENTRADAD, FECHAENTRADAH, IDRELOJ
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la Fichada"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	
	Public Function GetByReloj(
Byval IDRELOJ as String
) As List (of Fichada)
		Dim oDal As New FichadaData
		Try
	        Return oDal.GetByReloj(
IDRELOJ
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la Fichada"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	
	Public Function GetIncongruencias(
) As List (of Fichada)
		Dim oDal As New FichadaData
		Try
	        Return oDal.GetIncongruencias(
)
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo buscar la Fichada"
            MyBase.ConError = True
		Finally
			oDal = Nothing
        End Try
		
	End Function
	


End Class

