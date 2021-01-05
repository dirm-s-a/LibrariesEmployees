
'
'	Project Employees
'		Employees Example
'	Entity	Reloj
'		Reloj Entity
'	
'

Imports Employees.Entities
Imports Employees.Data

<Serializable()> Public Partial Class RelojComponent
	Inherits RelojComponentBase

	#Region "Constructor"
		Public Sub New()
			MyBase.New()
		End Sub

		Public Sub New(ByVal nConnectionString As String)
			MyBase.New(nConnectionString)
		End Sub
	#End Region

	Public Overrides Function Validate(Byref entity as Reloj) As Boolean
		Dim bOk As Boolean = false
		Try
		
			bOk = MyBase.Validate(entity)
		
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la Reloj"
            MyBase.ConError = True
            bOk = False
		Finally

        End Try

        Return bOk
	End Function

	Public Overrides Function ValidateNew(Byref entity as Reloj) As Boolean
		Dim bOk As Boolean = false
		Try
		
			bOk = MyBase.ValidateNew(entity)
		
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la Reloj"
            MyBase.ConError = True
            bOk = False
		Finally

        End Try

        Return bOk
	End Function

	Public Overrides Function ValidateDelete(Byref entity as Reloj) As Boolean
		Dim bOk As Boolean = false
		Try
		
			bOk = MyBase.ValidateDelete(entity)
		
		Catch ex As Exception
            MyBase.Exception = ex
            MyBase.InternalError = ex.Message
            MyBase.Error = "No se pudo validar la Reloj"
            MyBase.ConError = True
            bOk = False
		Finally

        End Try

        Return bOk
	End Function
End Class

