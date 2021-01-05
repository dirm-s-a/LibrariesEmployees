
'	Project Employees
'		Employees Example
'	Entity	Usuario
'		Usuario Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class Usuario
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as String
			
	Private mNOMBRE as String
			
	Private mRRHH as Boolean
			
	Private mSUPERVISOR as Boolean
			
	Private mCLAVE as String
			
	Private mACTIVO as Boolean
			
	Private mDIRECTORRRHH as Boolean
#End Region

#Region "Description (Joins) Fields"
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "USUARIOS"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mNOMBRE = F_Set_NullValue(mNOMBRE)
		mRRHH = F_Set_NullValue(mRRHH)
		mSUPERVISOR = F_Set_NullValue(mSUPERVISOR)
		mCLAVE = F_Set_NullValue(mCLAVE)
		mACTIVO = F_Set_NullValue(mACTIVO)
		mDIRECTORRRHH = F_Set_NullValue(mDIRECTORRRHH)
	End Sub

	Public Sub New(
			Byval ID as String,
			Byval NOMBRE as String,
			Byval CLAVE as String)	
		Me.New()
		Me.BeginUpdate()
		Me.ID = ID
		Me.NOMBRE = NOMBRE
		Me.CLAVE = CLAVE
	End Sub



#Region	"Public Properties"

	
	Public Property ID() as String
        Get
            Return mID
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("ID", Value)
            mID = Value
        End Set
	End Property
	
	Public Property NOMBRE() as String
        Get
            Return mNOMBRE
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("NOMBRE", Value)
            mNOMBRE = Value
        End Set
	End Property
	
	Public Property RRHH() as Boolean
        Get
            Return mRRHH
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("RRHH", Value)
            mRRHH = Value
        End Set
	End Property
	
	Public Property SUPERVISOR() as Boolean
        Get
            Return mSUPERVISOR
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("SUPERVISOR", Value)
            mSUPERVISOR = Value
        End Set
	End Property
	
	Public Property CLAVE() as String
        Get
            Return mCLAVE
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("CLAVE", Value)
            mCLAVE = Value
        End Set
	End Property
	
	Public Property ACTIVO() as Boolean
        Get
            Return mACTIVO
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("ACTIVO", Value)
            mACTIVO = Value
        End Set
	End Property
	
	Public Property DIRECTORRRHH() as Boolean
        Get
            Return mDIRECTORRRHH
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("DIRECTORRRHH", Value)
            mDIRECTORRRHH = Value
        End Set
	End Property
#End Region

End Class

