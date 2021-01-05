
'
'	Project Employees
'		Employees Example
'	Entity	EventoFichada
'		EventoFichada Entity
'	
'

Imports Employees.Entities
Imports Employees.Data

<Serializable()> Public Partial Class EventoFichadaComponent
	Inherits EventoFichadaComponentBase

	#Region "Constructor"
		Public Sub New()
			MyBase.New()
		End Sub

		Public Sub New(ByVal nConnectionString As String)
			MyBase.New(nConnectionString)
		End Sub
	#End Region

	Public Overrides Function Validate(Byref entity as EventoFichada) As Boolean
		Dim bOk As Boolean = false
		Try
		
			bOk = MyBase.Validate(entity)
		
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la EventoFichada"
            MyBase.ConError = True
            bOk = False
		Finally

        End Try

        Return bOk
	End Function

	Public Overrides Function ValidateNew(Byref entity as EventoFichada) As Boolean
		Dim bOk As Boolean = false
		Try
		
			bOk = MyBase.ValidateNew(entity)
		
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la EventoFichada"
            MyBase.ConError = True
            bOk = False
		Finally

        End Try

        Return bOk
	End Function

	Public Overrides Function ValidateDelete(Byref entity as EventoFichada) As Boolean
		Dim bOk As Boolean = false
		Try
		
			bOk = MyBase.ValidateDelete(entity)
		
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la EventoFichada"
            MyBase.ConError = True
            bOk = False
		Finally

        End Try

        Return bOk
	End Function
End Class

