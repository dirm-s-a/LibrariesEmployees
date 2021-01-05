
'	Project Employees
'		Employees Example
'	Entity	FichadaLectura
'		FichadaLectura Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class FichadaLectura
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mIDEMPLEADOLECTORA as String
			
	Private mIDEMPLEADO as Long
			
	Private mFECHAFICHADA as DateTime
			
	Private mIDRELOJ as String
			
	Private mFECHALECTURA as DateTime
			
	Private mTIPOFICHADA as String
			
	Private mFECHAPROCESO as DateTime
			
	Private mOBSERVACIONESPROCESO as String
			
	Private mTIPOFICHADASUPERVISOR as String
			
	Private mIDUSUARIOSUPERVISORCAMBIO as String
			
	Private mFECHAFICHADASUPERVISOR as DateTime
			
	Private mINCONSISTENCIA as Boolean
			
	Private mDESCARTADA as Boolean
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDEMPLEADO_Desc as String
			
	Private mIDRELOJ_Desc as String
			
	Private mIDUSUARIOSUPERVISORCAMBIO_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "FICHADAS_LECTURA"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mIDEMPLEADOLECTORA = F_Set_NullValue(mIDEMPLEADOLECTORA)
		mIDEMPLEADO = F_Set_NullValue(mIDEMPLEADO)
		mIDEMPLEADO_Desc = F_Set_NullValue(mIDEMPLEADO_Desc)
		mFECHAFICHADA = F_Set_NullValue(mFECHAFICHADA)
		mIDRELOJ = F_Set_NullValue(mIDRELOJ)
		mIDRELOJ_Desc = F_Set_NullValue(mIDRELOJ_Desc)
		mFECHALECTURA = F_Set_NullValue(mFECHALECTURA)
		mTIPOFICHADA = F_Set_NullValue(mTIPOFICHADA)
		mFECHAPROCESO = F_Set_NullValue(mFECHAPROCESO)
		mOBSERVACIONESPROCESO = F_Set_NullValue(mOBSERVACIONESPROCESO)
		mTIPOFICHADASUPERVISOR = F_Set_NullValue(mTIPOFICHADASUPERVISOR)
		mIDUSUARIOSUPERVISORCAMBIO = F_Set_NullValue(mIDUSUARIOSUPERVISORCAMBIO)
		mIDUSUARIOSUPERVISORCAMBIO_Desc = F_Set_NullValue(mIDUSUARIOSUPERVISORCAMBIO_Desc)
		mFECHAFICHADASUPERVISOR = F_Set_NullValue(mFECHAFICHADASUPERVISOR)
		mINCONSISTENCIA = F_Set_NullValue(mINCONSISTENCIA)
		mDESCARTADA = F_Set_NullValue(mDESCARTADA)
	End Sub

	Public Sub New(
			Byval IDEMPLEADOLECTORA as String,
			Byval FECHAFICHADA as DateTime,
			Byval TIPOFICHADA as String)	
		Me.New()
		Me.BeginUpdate()
		Me.IDEMPLEADOLECTORA = IDEMPLEADOLECTORA
		Me.FECHAFICHADA = FECHAFICHADA
		Me.TIPOFICHADA = TIPOFICHADA
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
	
	Public Property IDEMPLEADOLECTORA() as String
        Get
            Return mIDEMPLEADOLECTORA
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDEMPLEADOLECTORA", Value)
            mIDEMPLEADOLECTORA = Value
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
	
	Public Property FECHAFICHADA() as DateTime
        Get
            Return mFECHAFICHADA
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHAFICHADA", Value)
            mFECHAFICHADA = Value
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
	
	Public Property FECHALECTURA() as DateTime
        Get
            Return mFECHALECTURA
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHALECTURA", Value)
            mFECHALECTURA = Value
        End Set
	End Property
	
	Public Property TIPOFICHADA() as String
        Get
            Return mTIPOFICHADA
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("TIPOFICHADA", Value)
            mTIPOFICHADA = Value
        End Set
	End Property
	
	Public Property FECHAPROCESO() as DateTime
        Get
            Return mFECHAPROCESO
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHAPROCESO", Value)
            mFECHAPROCESO = Value
        End Set
	End Property
	
	Public Property OBSERVACIONESPROCESO() as String
        Get
            Return mOBSERVACIONESPROCESO
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("OBSERVACIONESPROCESO", Value)
            mOBSERVACIONESPROCESO = Value
        End Set
	End Property
	
	Public Property TIPOFICHADASUPERVISOR() as String
        Get
            Return mTIPOFICHADASUPERVISOR
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("TIPOFICHADASUPERVISOR", Value)
            mTIPOFICHADASUPERVISOR = Value
        End Set
	End Property
	
	Public Property IDUSUARIOSUPERVISORCAMBIO() as String
        Get
            Return mIDUSUARIOSUPERVISORCAMBIO
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOSUPERVISORCAMBIO", Value)
            mIDUSUARIOSUPERVISORCAMBIO = Value
        End Set
	End Property
	
	Public Property IDUSUARIOSUPERVISORCAMBIO_Desc() as String
        Get
            Return mIDUSUARIOSUPERVISORCAMBIO_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOSUPERVISORCAMBIO_Desc", Value)
            mIDUSUARIOSUPERVISORCAMBIO_Desc = Value
        End Set
	End Property
	
	Public Property FECHAFICHADASUPERVISOR() as DateTime
        Get
            Return mFECHAFICHADASUPERVISOR
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHAFICHADASUPERVISOR", Value)
            mFECHAFICHADASUPERVISOR = Value
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
	
	Public Property DESCARTADA() as Boolean
        Get
            Return mDESCARTADA
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("DESCARTADA", Value)
            mDESCARTADA = Value
        End Set
	End Property
#End Region

End Class

