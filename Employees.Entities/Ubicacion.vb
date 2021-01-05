
'	Project Employees
'		Employees Example
'	Entity	Ubicacion
'		Ubicacion Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class Ubicacion
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mDESCRIPCION as String
#End Region

#Region "Description (Joins) Fields"
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "UBICACIONES"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mDESCRIPCION = F_Set_NullValue(mDESCRIPCION)
	End Sub

	Public Sub New(
			Byval DESCRIPCION as String)	
		Me.New()
		Me.BeginUpdate()
		Me.DESCRIPCION = DESCRIPCION
	End Sub



#Region	"Public Properties"

	
	Public Property ID() as Long
        Get
            Return mID
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("ID", Value)
            mID = Value
        End Set
	End Property
	
	Public Property DESCRIPCION() as String
        Get
            Return mDESCRIPCION
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("DESCRIPCION", Value)
            mDESCRIPCION = Value
        End Set
	End Property
#End Region

End Class

