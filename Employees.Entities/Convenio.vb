
'	Project Employees
'		Employees Example
'	Entity	Convenio
'		Convenio Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class Convenio
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mDESCRIPCION as String
			
	Private mAUSENTISMO as Boolean
			
	Private mMINUTOSGRACIA as Integer
			
	Private mMINUTOSTOPE as Integer
			
	Private mHORARIOFLEXIBLE as Boolean
			
	Private mACTIVO as Boolean
			
	Private mFECHAALTA as DateTime
			
	Private mIDUDUARIOALTA as String
			
	Private mFECHAMODIFICACION as DateTime
			
	Private mIDUSUARIOMODIFICACION as String
			
	Private mSINCONTROLES as Boolean
			
	Private mMINUTOSLUNVIER as Integer
			
	Private mMINUTOSSABADO as Integer
			
	Private mMINUTOSDOMINGO as Integer
			
	Private mCONTROLDESCANSO as Boolean
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDUDUARIOALTA_Desc as String
			
	Private mIDUSUARIOMODIFICACION_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "CONVENIOS"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mDESCRIPCION = F_Set_NullValue(mDESCRIPCION)
		mAUSENTISMO = F_Set_NullValue(mAUSENTISMO)
		mMINUTOSGRACIA = F_Set_NullValue(mMINUTOSGRACIA)
		mMINUTOSTOPE = F_Set_NullValue(mMINUTOSTOPE)
		mHORARIOFLEXIBLE = F_Set_NullValue(mHORARIOFLEXIBLE)
		mACTIVO = F_Set_NullValue(mACTIVO)
		mFECHAALTA = F_Set_NullValue(mFECHAALTA)
		mIDUDUARIOALTA = F_Set_NullValue(mIDUDUARIOALTA)
		mIDUDUARIOALTA_Desc = F_Set_NullValue(mIDUDUARIOALTA_Desc)
		mFECHAMODIFICACION = F_Set_NullValue(mFECHAMODIFICACION)
		mIDUSUARIOMODIFICACION = F_Set_NullValue(mIDUSUARIOMODIFICACION)
		mIDUSUARIOMODIFICACION_Desc = F_Set_NullValue(mIDUSUARIOMODIFICACION_Desc)
		mSINCONTROLES = F_Set_NullValue(mSINCONTROLES)
		mMINUTOSLUNVIER = F_Set_NullValue(mMINUTOSLUNVIER)
		mMINUTOSSABADO = F_Set_NullValue(mMINUTOSSABADO)
		mMINUTOSDOMINGO = F_Set_NullValue(mMINUTOSDOMINGO)
		mCONTROLDESCANSO = F_Set_NullValue(mCONTROLDESCANSO)
	End Sub

	Public Sub New(
			Byval DESCRIPCION as String,
			Byval MINUTOSGRACIA as Integer,
			Byval MINUTOSTOPE as Integer,
			Byval IDUDUARIOALTA as String,
			Byval MINUTOSLUNVIER as Integer,
			Byval MINUTOSSABADO as Integer,
			Byval MINUTOSDOMINGO as Integer)	
		Me.New()
		Me.BeginUpdate()
		Me.DESCRIPCION = DESCRIPCION
		Me.MINUTOSGRACIA = MINUTOSGRACIA
		Me.MINUTOSTOPE = MINUTOSTOPE
		Me.IDUDUARIOALTA = IDUDUARIOALTA
		Me.MINUTOSLUNVIER = MINUTOSLUNVIER
		Me.MINUTOSSABADO = MINUTOSSABADO
		Me.MINUTOSDOMINGO = MINUTOSDOMINGO
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
	
	Public Property AUSENTISMO() as Boolean
        Get
            Return mAUSENTISMO
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("AUSENTISMO", Value)
            mAUSENTISMO = Value
        End Set
	End Property
	
	Public Property MINUTOSGRACIA() as Integer
        Get
            Return mMINUTOSGRACIA
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("MINUTOSGRACIA", Value)
            mMINUTOSGRACIA = Value
        End Set
	End Property
	
	Public Property MINUTOSTOPE() as Integer
        Get
            Return mMINUTOSTOPE
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("MINUTOSTOPE", Value)
            mMINUTOSTOPE = Value
        End Set
	End Property
	
	Public Property HORARIOFLEXIBLE() as Boolean
        Get
            Return mHORARIOFLEXIBLE
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("HORARIOFLEXIBLE", Value)
            mHORARIOFLEXIBLE = Value
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
	
	Public Property FECHAALTA() as DateTime
        Get
            Return mFECHAALTA
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHAALTA", Value)
            mFECHAALTA = Value
        End Set
	End Property
	
	Public Property IDUDUARIOALTA() as String
        Get
            Return mIDUDUARIOALTA
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUDUARIOALTA", Value)
            mIDUDUARIOALTA = Value
        End Set
	End Property
	
	Public Property IDUDUARIOALTA_Desc() as String
        Get
            Return mIDUDUARIOALTA_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUDUARIOALTA_Desc", Value)
            mIDUDUARIOALTA_Desc = Value
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
	
	Public Property SINCONTROLES() as Boolean
        Get
            Return mSINCONTROLES
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("SINCONTROLES", Value)
            mSINCONTROLES = Value
        End Set
	End Property
	
	Public Property MINUTOSLUNVIER() as Integer
        Get
            Return mMINUTOSLUNVIER
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("MINUTOSLUNVIER", Value)
            mMINUTOSLUNVIER = Value
        End Set
	End Property
	
	Public Property MINUTOSSABADO() as Integer
        Get
            Return mMINUTOSSABADO
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("MINUTOSSABADO", Value)
            mMINUTOSSABADO = Value
        End Set
	End Property
	
	Public Property MINUTOSDOMINGO() as Integer
        Get
            Return mMINUTOSDOMINGO
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("MINUTOSDOMINGO", Value)
            mMINUTOSDOMINGO = Value
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

