
'	Project Employees
'		Employees Example
'	Entity	Liquidacion
'		Liquidacion Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class Liquidacion
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mFECHALIQUDACION as DateTime
			
	Private mIDEMPLEADO as Long
			
	Private mIDCONVENIO as Long
			
	Private mFECHADESDE as Date
			
	Private mFECHAHASTA as Date
			
	Private mAUSENCIASCONPRESENTISMO as Integer
			
	Private mAUSENCIASJUSTIFICADAS as Integer
			
	Private mAUSENCIASINJUSTIFICADAS as Integer
			
	Private mDIASTRABAJADOS as Integer
			
	Private mDIASSINPRESENTISMO as Integer
			
	Private mDIASMEDIOPRESENTISMO as Integer
			
	Private mMINUTOSTARDE as Integer
			
	Private mINCONSISTENCIAS as Integer
			
	Private mPRESENTISMO as Boolean
			
	Private mMEDIOPRESENTISMO as Boolean
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDEMPLEADO_Desc as String
			
	Private mIDCONVENIO_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "LIQUIDACIONES"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mFECHALIQUDACION = F_Set_NullValue(mFECHALIQUDACION)
		mIDEMPLEADO = F_Set_NullValue(mIDEMPLEADO)
		mIDEMPLEADO_Desc = F_Set_NullValue(mIDEMPLEADO_Desc)
		mIDCONVENIO = F_Set_NullValue(mIDCONVENIO)
		mIDCONVENIO_Desc = F_Set_NullValue(mIDCONVENIO_Desc)
		mFECHADESDE = F_Set_NullValue(mFECHADESDE)
		mFECHAHASTA = F_Set_NullValue(mFECHAHASTA)
		mAUSENCIASCONPRESENTISMO = F_Set_NullValue(mAUSENCIASCONPRESENTISMO)
		mAUSENCIASJUSTIFICADAS = F_Set_NullValue(mAUSENCIASJUSTIFICADAS)
		mAUSENCIASINJUSTIFICADAS = F_Set_NullValue(mAUSENCIASINJUSTIFICADAS)
		mDIASTRABAJADOS = F_Set_NullValue(mDIASTRABAJADOS)
		mDIASSINPRESENTISMO = F_Set_NullValue(mDIASSINPRESENTISMO)
		mDIASMEDIOPRESENTISMO = F_Set_NullValue(mDIASMEDIOPRESENTISMO)
		mMINUTOSTARDE = F_Set_NullValue(mMINUTOSTARDE)
		mINCONSISTENCIAS = F_Set_NullValue(mINCONSISTENCIAS)
		mPRESENTISMO = F_Set_NullValue(mPRESENTISMO)
		mMEDIOPRESENTISMO = F_Set_NullValue(mMEDIOPRESENTISMO)
	End Sub

	Public Sub New(
			Byval IDEMPLEADO as Long,
			Byval IDCONVENIO as Long,
			Byval FECHADESDE as Date,
			Byval FECHAHASTA as Date,
			Byval AUSENCIASCONPRESENTISMO as Integer,
			Byval AUSENCIASJUSTIFICADAS as Integer,
			Byval AUSENCIASINJUSTIFICADAS as Integer,
			Byval DIASTRABAJADOS as Integer,
			Byval DIASSINPRESENTISMO as Integer,
			Byval DIASMEDIOPRESENTISMO as Integer,
			Byval MINUTOSTARDE as Integer,
			Byval INCONSISTENCIAS as Integer)	
		Me.New()
		Me.BeginUpdate()
		Me.IDEMPLEADO = IDEMPLEADO
		Me.IDCONVENIO = IDCONVENIO
		Me.FECHADESDE = FECHADESDE
		Me.FECHAHASTA = FECHAHASTA
		Me.AUSENCIASCONPRESENTISMO = AUSENCIASCONPRESENTISMO
		Me.AUSENCIASJUSTIFICADAS = AUSENCIASJUSTIFICADAS
		Me.AUSENCIASINJUSTIFICADAS = AUSENCIASINJUSTIFICADAS
		Me.DIASTRABAJADOS = DIASTRABAJADOS
		Me.DIASSINPRESENTISMO = DIASSINPRESENTISMO
		Me.DIASMEDIOPRESENTISMO = DIASMEDIOPRESENTISMO
		Me.MINUTOSTARDE = MINUTOSTARDE
		Me.INCONSISTENCIAS = INCONSISTENCIAS
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
	
	Public Property FECHALIQUDACION() as DateTime
        Get
            Return mFECHALIQUDACION
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHALIQUDACION", Value)
            mFECHALIQUDACION = Value
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
	
	Public Property IDCONVENIO_Desc() as String
        Get
            Return mIDCONVENIO_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDCONVENIO_Desc", Value)
            mIDCONVENIO_Desc = Value
        End Set
	End Property
	
	Public Property FECHADESDE() as Date
        Get
            Return mFECHADESDE
        End Get
        Set(ByVal Value As Date)
			MyBase.ChangeProperty("FECHADESDE", Value)
            mFECHADESDE = Value
        End Set
	End Property
	
	Public Property FECHAHASTA() as Date
        Get
            Return mFECHAHASTA
        End Get
        Set(ByVal Value As Date)
			MyBase.ChangeProperty("FECHAHASTA", Value)
            mFECHAHASTA = Value
        End Set
	End Property
	
	Public Property AUSENCIASCONPRESENTISMO() as Integer
        Get
            Return mAUSENCIASCONPRESENTISMO
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("AUSENCIASCONPRESENTISMO", Value)
            mAUSENCIASCONPRESENTISMO = Value
        End Set
	End Property
	
	Public Property AUSENCIASJUSTIFICADAS() as Integer
        Get
            Return mAUSENCIASJUSTIFICADAS
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("AUSENCIASJUSTIFICADAS", Value)
            mAUSENCIASJUSTIFICADAS = Value
        End Set
	End Property
	
	Public Property AUSENCIASINJUSTIFICADAS() as Integer
        Get
            Return mAUSENCIASINJUSTIFICADAS
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("AUSENCIASINJUSTIFICADAS", Value)
            mAUSENCIASINJUSTIFICADAS = Value
        End Set
	End Property
	
	Public Property DIASTRABAJADOS() as Integer
        Get
            Return mDIASTRABAJADOS
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("DIASTRABAJADOS", Value)
            mDIASTRABAJADOS = Value
        End Set
	End Property
	
	Public Property DIASSINPRESENTISMO() as Integer
        Get
            Return mDIASSINPRESENTISMO
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("DIASSINPRESENTISMO", Value)
            mDIASSINPRESENTISMO = Value
        End Set
	End Property
	
	Public Property DIASMEDIOPRESENTISMO() as Integer
        Get
            Return mDIASMEDIOPRESENTISMO
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("DIASMEDIOPRESENTISMO", Value)
            mDIASMEDIOPRESENTISMO = Value
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
	
	Public Property INCONSISTENCIAS() as Integer
        Get
            Return mINCONSISTENCIAS
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("INCONSISTENCIAS", Value)
            mINCONSISTENCIAS = Value
        End Set
	End Property
	
	Public Property PRESENTISMO() as Boolean
        Get
            Return mPRESENTISMO
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("PRESENTISMO", Value)
            mPRESENTISMO = Value
        End Set
	End Property
	
	Public Property MEDIOPRESENTISMO() as Boolean
        Get
            Return mMEDIOPRESENTISMO
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("MEDIOPRESENTISMO", Value)
            mMEDIOPRESENTISMO = Value
        End Set
	End Property
#End Region

End Class

