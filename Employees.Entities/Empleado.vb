
'	Project Employees
'		Employees Example
'	Entity	Empleado
'		Empleado Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class Empleado
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mNOMBRE as String
			
	Private mSECTOR as String
			
	Private mNRODOCUMENTO as String
			
	Private mINACTIVO as Boolean
			
	Private mFECHABAJA as DateTime
			
	Private mIDUSUARIO as String
			
	Private mEMAIL as String
			
	Private mIDCONVENIO as Long
			
	Private mIDUSUARIOALTA as String
			
	Private mFECHAALTA as DateTime
			
	Private mIDUSUARIOMODIFICACION as String
			
	Private mFECHAMODIFICACION as DateTime
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDUSUARIO_Desc as String
			
	Private mIDCONVENIO_Desc as String
			
	Private mIDUSUARIOALTA_Desc as String
			
	Private mIDUSUARIOMODIFICACION_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "EMPLEADOS"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mNOMBRE = F_Set_NullValue(mNOMBRE)
		mSECTOR = F_Set_NullValue(mSECTOR)
		mNRODOCUMENTO = F_Set_NullValue(mNRODOCUMENTO)
		mINACTIVO = F_Set_NullValue(mINACTIVO)
		mFECHABAJA = F_Set_NullValue(mFECHABAJA)
		mIDUSUARIO = F_Set_NullValue(mIDUSUARIO)
		mIDUSUARIO_Desc = F_Set_NullValue(mIDUSUARIO_Desc)
		mEMAIL = F_Set_NullValue(mEMAIL)
		mIDCONVENIO = F_Set_NullValue(mIDCONVENIO)
		mIDCONVENIO_Desc = F_Set_NullValue(mIDCONVENIO_Desc)
		mIDUSUARIOALTA = F_Set_NullValue(mIDUSUARIOALTA)
		mIDUSUARIOALTA_Desc = F_Set_NullValue(mIDUSUARIOALTA_Desc)
		mFECHAALTA = F_Set_NullValue(mFECHAALTA)
		mIDUSUARIOMODIFICACION = F_Set_NullValue(mIDUSUARIOMODIFICACION)
		mIDUSUARIOMODIFICACION_Desc = F_Set_NullValue(mIDUSUARIOMODIFICACION_Desc)
		mFECHAMODIFICACION = F_Set_NullValue(mFECHAMODIFICACION)
	End Sub

	Public Sub New(
			Byval NOMBRE as String,
			Byval NRODOCUMENTO as String,
			Byval IDCONVENIO as Long,
			Byval IDUSUARIOALTA as String,
			Byval IDUSUARIOMODIFICACION as String)	
		Me.New()
		Me.BeginUpdate()
		Me.NOMBRE = NOMBRE
		Me.NRODOCUMENTO = NRODOCUMENTO
		Me.IDCONVENIO = IDCONVENIO
		Me.IDUSUARIOALTA = IDUSUARIOALTA
		Me.IDUSUARIOMODIFICACION = IDUSUARIOMODIFICACION
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
	
	Public Property NOMBRE() as String
        Get
            Return mNOMBRE
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("NOMBRE", Value)
            mNOMBRE = Value
        End Set
	End Property
	
	Public Property SECTOR() as String
        Get
            Return mSECTOR
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("SECTOR", Value)
            mSECTOR = Value
        End Set
	End Property
	
	Public Property NRODOCUMENTO() as String
        Get
            Return mNRODOCUMENTO
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("NRODOCUMENTO", Value)
            mNRODOCUMENTO = Value
        End Set
	End Property
	
	Public Property INACTIVO() as Boolean
        Get
            Return mINACTIVO
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("INACTIVO", Value)
            mINACTIVO = Value
        End Set
	End Property
	
	Public Property FECHABAJA() as DateTime
        Get
            Return mFECHABAJA
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHABAJA", Value)
            mFECHABAJA = Value
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
	
	Public Property EMAIL() as String
        Get
            Return mEMAIL
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("EMAIL", Value)
            mEMAIL = Value
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
	
	Public Property FECHAALTA() as DateTime
        Get
            Return mFECHAALTA
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHAALTA", Value)
            mFECHAALTA = Value
        End Set
	End Property
	
	Public Property IDUSUARIOMODIFICACION() as String
        Get
            Return mIDUSUARIOMODIFICACION
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOMODIFICACION", Value)
            mIDUSUARIOMODIFICACION = Value
        End Set
	End Property
	
	Public Property IDUSUARIOMODIFICACION_Desc() as String
        Get
            Return mIDUSUARIOMODIFICACION_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOMODIFICACION_Desc", Value)
            mIDUSUARIOMODIFICACION_Desc = Value
        End Set
	End Property
	
	Public Property FECHAMODIFICACION() as DateTime
        Get
            Return mFECHAMODIFICACION
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHAMODIFICACION", Value)
            mFECHAMODIFICACION = Value
        End Set
	End Property
#End Region

End Class

