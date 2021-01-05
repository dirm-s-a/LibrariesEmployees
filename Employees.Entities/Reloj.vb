
'	Project Employees
'		Employees Example
'	Entity	Reloj
'		Reloj Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class Reloj
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as String
			
	Private mDESCRIPCION as String
			
	Private mIDUBICACION as Long
			
	Private mIP4 as String
			
	Private mIP6 as String
			
	Private mMARCA as String
			
	Private mCONTROLINGRESO as Boolean
			
	Private mCONTROLDESCANSO as Boolean
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDUBICACION_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "RELOJES"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mDESCRIPCION = F_Set_NullValue(mDESCRIPCION)
		mIDUBICACION = F_Set_NullValue(mIDUBICACION)
		mIDUBICACION_Desc = F_Set_NullValue(mIDUBICACION_Desc)
		mIP4 = F_Set_NullValue(mIP4)
		mIP6 = F_Set_NullValue(mIP6)
		mMARCA = F_Set_NullValue(mMARCA)
		mCONTROLINGRESO = F_Set_NullValue(mCONTROLINGRESO)
		mCONTROLDESCANSO = F_Set_NullValue(mCONTROLDESCANSO)
	End Sub

	Public Sub New(
			Byval ID as String,
			Byval DESCRIPCION as String,
			Byval IDUBICACION as Long)	
		Me.New()
		Me.BeginUpdate()
		Me.ID = ID
		Me.DESCRIPCION = DESCRIPCION
		Me.IDUBICACION = IDUBICACION
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
	
	Public Property DESCRIPCION() as String
        Get
            Return mDESCRIPCION
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("DESCRIPCION", Value)
            mDESCRIPCION = Value
        End Set
	End Property
	
	Public Property IDUBICACION() as Long
        Get
            Return mIDUBICACION
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("IDUBICACION", Value)
            mIDUBICACION = Value
        End Set
	End Property
	
	Public Property IDUBICACION_Desc() as String
        Get
            Return mIDUBICACION_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUBICACION_Desc", Value)
            mIDUBICACION_Desc = Value
        End Set
	End Property
	
	Public Property IP4() as String
        Get
            Return mIP4
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IP4", Value)
            mIP4 = Value
        End Set
	End Property
	
	Public Property IP6() as String
        Get
            Return mIP6
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IP6", Value)
            mIP6 = Value
        End Set
	End Property
	
	Public Property MARCA() as String
        Get
            Return mMARCA
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("MARCA", Value)
            mMARCA = Value
        End Set
	End Property
	
	Public Property CONTROLINGRESO() as Boolean
        Get
            Return mCONTROLINGRESO
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("CONTROLINGRESO", Value)
            mCONTROLINGRESO = Value
        End Set
	End Property
	
	Public Property CONTROLDESCANSO() as Boolean
        Get
            Return mCONTROLDESCANSO
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("CONTROLDESCANSO", Value)
            mCONTROLDESCANSO = Value
        End Set
	End Property
#End Region

End Class

