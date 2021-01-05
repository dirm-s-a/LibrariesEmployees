
'	Project Employees
'		Employees Example
'	Entity	TrazaCambio
'		TrazaCambio Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class TrazaCambio
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mIDUSUARIO as String
			
	Private mFECHA as DateTime
			
	Private mIDFICHADALECTURA as Long
			
	Private mOBSERVACIONES as String
			
	Private mTABLAAUXILIAR as String
			
	Private mIDAUXILIAR as String
			
	Private mIDEMPLEADO as Long
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDUSUARIO_Desc as String
			
	Private mIDEMPLEADO_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "TRAZACAMBIOS"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mIDUSUARIO = F_Set_NullValue(mIDUSUARIO)
		mIDUSUARIO_Desc = F_Set_NullValue(mIDUSUARIO_Desc)
		mFECHA = F_Set_NullValue(mFECHA)
		mIDFICHADALECTURA = F_Set_NullValue(mIDFICHADALECTURA)
		mOBSERVACIONES = F_Set_NullValue(mOBSERVACIONES)
		mTABLAAUXILIAR = F_Set_NullValue(mTABLAAUXILIAR)
		mIDAUXILIAR = F_Set_NullValue(mIDAUXILIAR)
		mIDEMPLEADO = F_Set_NullValue(mIDEMPLEADO)
		mIDEMPLEADO_Desc = F_Set_NullValue(mIDEMPLEADO_Desc)
	End Sub

	Public Sub New(
			Byval IDUSUARIO as String,
			Byval OBSERVACIONES as String,
			Byval TABLAAUXILIAR as String,
			Byval IDAUXILIAR as String)	
		Me.New()
		Me.BeginUpdate()
		Me.IDUSUARIO = IDUSUARIO
		Me.OBSERVACIONES = OBSERVACIONES
		Me.TABLAAUXILIAR = TABLAAUXILIAR
		Me.IDAUXILIAR = IDAUXILIAR
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
	
	Public Property IDUSUARIO() as String
        Get
            Return mIDUSUARIO
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIO", Value)
            mIDUSUARIO = Value
        End Set
	End Property
	
	Public Property IDUSUARIO_Desc() as String
        Get
            Return mIDUSUARIO_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIO_Desc", Value)
            mIDUSUARIO_Desc = Value
        End Set
	End Property
	
	Public Property FECHA() as DateTime
        Get
            Return mFECHA
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHA", Value)
            mFECHA = Value
        End Set
	End Property
	
	Public Property IDFICHADALECTURA() as Long
        Get
            Return mIDFICHADALECTURA
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("IDFICHADALECTURA", Value)
            mIDFICHADALECTURA = Value
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
	
	Public Property TABLAAUXILIAR() as String
        Get
            Return mTABLAAUXILIAR
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("TABLAAUXILIAR", Value)
            mTABLAAUXILIAR = Value
        End Set
	End Property
	
	Public Property IDAUXILIAR() as String
        Get
            Return mIDAUXILIAR
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDAUXILIAR", Value)
            mIDAUXILIAR = Value
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
#End Region

End Class

