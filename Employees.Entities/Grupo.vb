
'	Project Employees
'		Employees Example
'	Entity	Grupo
'		Grupo Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class Grupo
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mDESCRIPCION as String
			
	Private mFECHAALTA as DateTime
			
	Private mIDUSUARIOALTA as String
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDUSUARIOALTA_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "GRUPOS"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mDESCRIPCION = F_Set_NullValue(mDESCRIPCION)
		mFECHAALTA = F_Set_NullValue(mFECHAALTA)
		mIDUSUARIOALTA = F_Set_NullValue(mIDUSUARIOALTA)
		mIDUSUARIOALTA_Desc = F_Set_NullValue(mIDUSUARIOALTA_Desc)
	End Sub

	Public Sub New(
			Byval DESCRIPCION as String,
			Byval IDUSUARIOALTA as String)	
		Me.New()
		Me.BeginUpdate()
		Me.DESCRIPCION = DESCRIPCION
		Me.IDUSUARIOALTA = IDUSUARIOALTA
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
	
	Public Property FECHAALTA() as DateTime
        Get
            Return mFECHAALTA
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHAALTA", Value)
            mFECHAALTA = Value
        End Set
	End Property
	
	Public Property IDUSUARIOALTA() as String
        Get
            Return mIDUSUARIOALTA
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOALTA", Value)
            mIDUSUARIOALTA = Value
        End Set
	End Property
	
	Public Property IDUSUARIOALTA_Desc() as String
        Get
            Return mIDUSUARIOALTA_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOALTA_Desc", Value)
            mIDUSUARIOALTA_Desc = Value
        End Set
	End Property
#End Region

End Class

