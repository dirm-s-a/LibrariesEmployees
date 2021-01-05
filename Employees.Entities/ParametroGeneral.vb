
'	Project Employees
'		Employees Example
'	Entity	ParametroGeneral
'		ParametroGeneral Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class ParametroGeneral
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mPERIODODIADESDE as Integer
			
	Private mPERIODODIAHASTA as Integer
			
	Private mINCLUYEINACTIVOSLIQ as Boolean
#End Region

#Region "Description (Joins) Fields"
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "PARAMTEROSGENERALES"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mPERIODODIADESDE = F_Set_NullValue(mPERIODODIADESDE)
		mPERIODODIAHASTA = F_Set_NullValue(mPERIODODIAHASTA)
		mINCLUYEINACTIVOSLIQ = F_Set_NullValue(mINCLUYEINACTIVOSLIQ)
	End Sub

	Public Sub New(
			Byval PERIODODIADESDE as Integer,
			Byval PERIODODIAHASTA as Integer)	
		Me.New()
		Me.BeginUpdate()
		Me.PERIODODIADESDE = PERIODODIADESDE
		Me.PERIODODIAHASTA = PERIODODIAHASTA
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
	
	Public Property PERIODODIADESDE() as Integer
        Get
            Return mPERIODODIADESDE
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("PERIODODIADESDE", Value)
            mPERIODODIADESDE = Value
        End Set
	End Property
	
	Public Property PERIODODIAHASTA() as Integer
        Get
            Return mPERIODODIAHASTA
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("PERIODODIAHASTA", Value)
            mPERIODODIAHASTA = Value
        End Set
	End Property
	
	Public Property INCLUYEINACTIVOSLIQ() as Boolean
        Get
            Return mINCLUYEINACTIVOSLIQ
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("INCLUYEINACTIVOSLIQ", Value)
            mINCLUYEINACTIVOSLIQ = Value
        End Set
	End Property
#End Region

End Class

