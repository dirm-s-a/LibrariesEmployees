
'	Project Employees
'		Employees Example
'	Entity	Fichada
'		Fichada Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class Fichada
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mIDEMPLEADO as Long
			
	Private mFECHAENTRADA as DateTime
			
	Private mENTRADA as Long
			
	Private mFECHASALIDA as DateTime
			
	Private mSALIDA as Long
			
	Private mHORASTRABAJADAS as Long
			
	Private mMINUTOSTARDE as Long
			
	Private mINCONGRUENCIAS as Boolean
			
	Private mIDHORARIOEMPLEADO as Long
			
	Private mIDHORARIOADICEMPLEADO as Long
			
	Private mTIPO as String
			
	Private mIDRELOJ as String
			
	Private mBORRADO as Boolean
			
	Private mIDUSUARIOBORRADO as String
			
	Private mFECHABORRADO as DateTime
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDEMPLEADO_Desc as String
			
	Private mIDRELOJ_Desc as String
			
	Private mIDUSUARIOBORRADO_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "FICHADAS"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mIDEMPLEADO = F_Set_NullValue(mIDEMPLEADO)
		mIDEMPLEADO_Desc = F_Set_NullValue(mIDEMPLEADO_Desc)
		mFECHAENTRADA = F_Set_NullValue(mFECHAENTRADA)
		mENTRADA = F_Set_NullValue(mENTRADA)
		mFECHASALIDA = F_Set_NullValue(mFECHASALIDA)
		mSALIDA = F_Set_NullValue(mSALIDA)
		mHORASTRABAJADAS = F_Set_NullValue(mHORASTRABAJADAS)
		mMINUTOSTARDE = F_Set_NullValue(mMINUTOSTARDE)
		mINCONGRUENCIAS = F_Set_NullValue(mINCONGRUENCIAS)
		mIDHORARIOEMPLEADO = F_Set_NullValue(mIDHORARIOEMPLEADO)
		mIDHORARIOADICEMPLEADO = F_Set_NullValue(mIDHORARIOADICEMPLEADO)
		mTIPO = F_Set_NullValue(mTIPO)
		mIDRELOJ = F_Set_NullValue(mIDRELOJ)
		mIDRELOJ_Desc = F_Set_NullValue(mIDRELOJ_Desc)
		mBORRADO = F_Set_NullValue(mBORRADO)
		mIDUSUARIOBORRADO = F_Set_NullValue(mIDUSUARIOBORRADO)
		mIDUSUARIOBORRADO_Desc = F_Set_NullValue(mIDUSUARIOBORRADO_Desc)
		mFECHABORRADO = F_Set_NullValue(mFECHABORRADO)
	End Sub

	Public Sub New(
			Byval IDEMPLEADO as Long,
			Byval FECHAENTRADA as DateTime,
			Byval FECHASALIDA as DateTime,
			Byval TIPO as String)	
		Me.New()
		Me.BeginUpdate()
		Me.IDEMPLEADO = IDEMPLEADO
		Me.FECHAENTRADA = FECHAENTRADA
		Me.FECHASALIDA = FECHASALIDA
		Me.TIPO = TIPO
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
	
	Public Property IDEMPLEADO() as Long
        Get
            Return mIDEMPLEADO
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("IDEMPLEADO", Value)
            mIDEMPLEADO = Value
        End Set
	End Property
	
	Public Property IDEMPLEADO_Desc() as String
        Get
            Return mIDEMPLEADO_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDEMPLEADO_Desc", Value)
            mIDEMPLEADO_Desc = Value
        End Set
	End Property
	
	Public Property FECHAENTRADA() as DateTime
        Get
            Return mFECHAENTRADA
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHAENTRADA", Value)
            mFECHAENTRADA = Value
        End Set
	End Property
	
	Public Property ENTRADA() as Long
        Get
            Return mENTRADA
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("ENTRADA", Value)
            mENTRADA = Value
        End Set
	End Property
	
	Public Property FECHASALIDA() as DateTime
        Get
            Return mFECHASALIDA
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHASALIDA", Value)
            mFECHASALIDA = Value
        End Set
	End Property
	
	Public Property SALIDA() as Long
        Get
            Return mSALIDA
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("SALIDA", Value)
            mSALIDA = Value
        End Set
	End Property
	
	Public Property HORASTRABAJADAS() as Long
        Get
            Return mHORASTRABAJADAS
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("HORASTRABAJADAS", Value)
            mHORASTRABAJADAS = Value
        End Set
	End Property
	
	Public Property MINUTOSTARDE() as Long
        Get
            Return mMINUTOSTARDE
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("MINUTOSTARDE", Value)
            mMINUTOSTARDE = Value
        End Set
	End Property
	
	Public Property INCONGRUENCIAS() as Boolean
        Get
            Return mINCONGRUENCIAS
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("INCONGRUENCIAS", Value)
            mINCONGRUENCIAS = Value
        End Set
	End Property
	
	Public Property IDHORARIOEMPLEADO() as Long
        Get
            Return mIDHORARIOEMPLEADO
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("IDHORARIOEMPLEADO", Value)
            mIDHORARIOEMPLEADO = Value
        End Set
	End Property
	
	Public Property IDHORARIOADICEMPLEADO() as Long
        Get
            Return mIDHORARIOADICEMPLEADO
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("IDHORARIOADICEMPLEADO", Value)
            mIDHORARIOADICEMPLEADO = Value
        End Set
	End Property
	
	Public Property TIPO() as String
        Get
            Return mTIPO
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("TIPO", Value)
            mTIPO = Value
        End Set
	End Property
	
	Public Property IDRELOJ() as String
        Get
            Return mIDRELOJ
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDRELOJ", Value)
            mIDRELOJ = Value
        End Set
	End Property
	
	Public Property IDRELOJ_Desc() as String
        Get
            Return mIDRELOJ_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDRELOJ_Desc", Value)
            mIDRELOJ_Desc = Value
        End Set
	End Property
	
	Public Property BORRADO() as Boolean
        Get
            Return mBORRADO
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("BORRADO", Value)
            mBORRADO = Value
        End Set
	End Property
	
	Public Property IDUSUARIOBORRADO() as String
        Get
            Return mIDUSUARIOBORRADO
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOBORRADO", Value)
            mIDUSUARIOBORRADO = Value
        End Set
	End Property
	
	Public Property IDUSUARIOBORRADO_Desc() as String
        Get
            Return mIDUSUARIOBORRADO_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOBORRADO_Desc", Value)
            mIDUSUARIOBORRADO_Desc = Value
        End Set
	End Property
	
	Public Property FECHABORRADO() as DateTime
        Get
            Return mFECHABORRADO
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHABORRADO", Value)
            mFECHABORRADO = Value
        End Set
	End Property
#End Region

End Class

