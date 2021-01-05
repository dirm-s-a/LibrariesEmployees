
'	Project Employees
'		Employees Example
'	Entity	TipoAusencia
'		TipoAusencia Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class TipoAusencia
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mDESCRIPCION as String
			
	Private mJUSTIFICADA as Boolean
			
	Private mPIERDEPRESENTISMO as Boolean
			
	Private mACTIVO as Boolean
			
	Private mFECHAALTA as DateTime
			
	Private mIDUDUARIOALTA as String
			
	Private mFECHAMODIFICACION as DateTime
			
	Private mIDUSUARIOMODIFICACION as String
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDUDUARIOALTA_Desc as String
			
	Private mIDUSUARIOMODIFICACION_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "TIPOAUSENCIAS"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mDESCRIPCION = F_Set_NullValue(mDESCRIPCION)
		mJUSTIFICADA = F_Set_NullValue(mJUSTIFICADA)
		mPIERDEPRESENTISMO = F_Set_NullValue(mPIERDEPRESENTISMO)
		mACTIVO = F_Set_NullValue(mACTIVO)
		mFECHAALTA = F_Set_NullValue(mFECHAALTA)
		mIDUDUARIOALTA = F_Set_NullValue(mIDUDUARIOALTA)
		mIDUDUARIOALTA_Desc = F_Set_NullValue(mIDUDUARIOALTA_Desc)
		mFECHAMODIFICACION = F_Set_NullValue(mFECHAMODIFICACION)
		mIDUSUARIOMODIFICACION = F_Set_NullValue(mIDUSUARIOMODIFICACION)
		mIDUSUARIOMODIFICACION_Desc = F_Set_NullValue(mIDUSUARIOMODIFICACION_Desc)
	End Sub

	Public Sub New(
			Byval DESCRIPCION as String,
			Byval IDUDUARIOALTA as String)	
		Me.New()
		Me.BeginUpdate()
		Me.DESCRIPCION = DESCRIPCION
		Me.IDUDUARIOALTA = IDUDUARIOALTA
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
	
	Public Property JUSTIFICADA() as Boolean
        Get
            Return mJUSTIFICADA
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("JUSTIFICADA", Value)
            mJUSTIFICADA = Value
        End Set
	End Property
	
	Public Property PIERDEPRESENTISMO() as Boolean
        Get
            Return mPIERDEPRESENTISMO
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("PIERDEPRESENTISMO", Value)
            mPIERDEPRESENTISMO = Value
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
#End Region

End Class

