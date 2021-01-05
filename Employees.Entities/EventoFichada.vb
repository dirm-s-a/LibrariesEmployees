
'	Project Employees
'		Employees Example
'	Entity	EventoFichada
'		EventoFichada Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class EventoFichada
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mIDEMPLEADO as Long
			
	Private mIDCONVENIO as Long
			
	Private mFECHAENTRADA as DateTime
			
	Private mIDFICHADAENTRADA as Long
			
	Private mFECHASALIDA as DateTime
			
	Private mIDFICHADASALIDA as Long
			
	Private mIDHORARIOEMPLEADO as Long
			
	Private mIDHORARIOADICEMPLEADO as Long
			
	Private mINCONSISTENCIA as Boolean
			
	Private mMINUTOSTRABAJADOS as Integer
			
	Private mMINUTOSTARDE as Integer
			
	Private mAUSENTE as Boolean
			
	Private mIDAUSENCIAEMPLEADO as Long
			
	Private mOBSERVACIONES as String
			
	Private mIDLIQUIDACION as Long
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDEMPLEADO_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "EVENTOSFICHADAS"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mIDEMPLEADO = F_Set_NullValue(mIDEMPLEADO)
		mIDEMPLEADO_Desc = F_Set_NullValue(mIDEMPLEADO_Desc)
		mIDCONVENIO = F_Set_NullValue(mIDCONVENIO)
		mFECHAENTRADA = F_Set_NullValue(mFECHAENTRADA)
		mIDFICHADAENTRADA = F_Set_NullValue(mIDFICHADAENTRADA)
		mFECHASALIDA = F_Set_NullValue(mFECHASALIDA)
		mIDFICHADASALIDA = F_Set_NullValue(mIDFICHADASALIDA)
		mIDHORARIOEMPLEADO = F_Set_NullValue(mIDHORARIOEMPLEADO)
		mIDHORARIOADICEMPLEADO = F_Set_NullValue(mIDHORARIOADICEMPLEADO)
		mINCONSISTENCIA = F_Set_NullValue(mINCONSISTENCIA)
		mMINUTOSTRABAJADOS = F_Set_NullValue(mMINUTOSTRABAJADOS)
		mMINUTOSTARDE = F_Set_NullValue(mMINUTOSTARDE)
		mAUSENTE = F_Set_NullValue(mAUSENTE)
		mIDAUSENCIAEMPLEADO = F_Set_NullValue(mIDAUSENCIAEMPLEADO)
		mOBSERVACIONES = F_Set_NullValue(mOBSERVACIONES)
		mIDLIQUIDACION = F_Set_NullValue(mIDLIQUIDACION)
	End Sub

	Public Sub New(
			Byval IDEMPLEADO as Long,
			Byval IDCONVENIO as Long)	
		Me.New()
		Me.BeginUpdate()
		Me.IDEMPLEADO = IDEMPLEADO
		Me.IDCONVENIO = IDCONVENIO
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
	
	Public Property IDCONVENIO() as Long
        Get
            Return mIDCONVENIO
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("IDCONVENIO", Value)
            mIDCONVENIO = Value
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
	
	Public Property IDFICHADAENTRADA() as Long
        Get
            Return mIDFICHADAENTRADA
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("IDFICHADAENTRADA", Value)
            mIDFICHADAENTRADA = Value
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
	
	Public Property IDFICHADASALIDA() as Long
        Get
            Return mIDFICHADASALIDA
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("IDFICHADASALIDA", Value)
            mIDFICHADASALIDA = Value
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
	
	Public Property INCONSISTENCIA() as Boolean
        Get
            Return mINCONSISTENCIA
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("INCONSISTENCIA", Value)
            mINCONSISTENCIA = Value
        End Set
	End Property
	
	Public Property MINUTOSTRABAJADOS() as Integer
        Get
            Return mMINUTOSTRABAJADOS
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("MINUTOSTRABAJADOS", Value)
            mMINUTOSTRABAJADOS = Value
        End Set
	End Property
	
	Public Property MINUTOSTARDE() as Integer
        Get
            Return mMINUTOSTARDE
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("MINUTOSTARDE", Value)
            mMINUTOSTARDE = Value
        End Set
	End Property
	
	Public Property AUSENTE() as Boolean
        Get
            Return mAUSENTE
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("AUSENTE", Value)
            mAUSENTE = Value
        End Set
	End Property
	
	Public Property IDAUSENCIAEMPLEADO() as Long
        Get
            Return mIDAUSENCIAEMPLEADO
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("IDAUSENCIAEMPLEADO", Value)
            mIDAUSENCIAEMPLEADO = Value
        End Set
	End Property
	
	Public Property OBSERVACIONES() as String
        Get
            Return mOBSERVACIONES
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("OBSERVACIONES", Value)
            mOBSERVACIONES = Value
        End Set
	End Property
	
	Public Property IDLIQUIDACION() as Long
        Get
            Return mIDLIQUIDACION
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("IDLIQUIDACION", Value)
            mIDLIQUIDACION = Value
        End Set
	End Property
#End Region

End Class

