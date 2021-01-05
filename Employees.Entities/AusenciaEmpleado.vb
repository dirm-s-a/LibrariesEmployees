
'	Project Employees
'		Employees Example
'	Entity	AusenciaEmpleado
'		AusenciaEmpleado Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class AusenciaEmpleado
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mIDEMPLEADO as Long
			
	Private mFECHADESDE as Date
			
	Private mFECHAHASTA as Date
			
	Private mIDTIPOAUSENCIA as Long
			
	Private mIDUSUARIOSOLICITA as String
			
	Private mFECHASOLICITUD as DateTime
			
	Private mIDUSUARIOVALIDA as String
			
	Private mFECHAVALIDACION as DateTime
			
	Private mIDUSUARIOAPRUEBA as String
			
	Private mFECHAAPROBACION as DateTime
			
	Private mIDUSUARIOANULA as String
			
	Private mFECHAANULACION as DateTime
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDEMPLEADO_Desc as String
			
	Private mIDTIPOAUSENCIA_Desc as String
			
	Private mIDUSUARIOSOLICITA_Desc as String
			
	Private mIDUSUARIOVALIDA_Desc as String
			
	Private mIDUSUARIOAPRUEBA_Desc as String
			
	Private mIDUSUARIOANULA_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "AUSENCIAEMPLEADOS"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mIDEMPLEADO = F_Set_NullValue(mIDEMPLEADO)
		mIDEMPLEADO_Desc = F_Set_NullValue(mIDEMPLEADO_Desc)
		mFECHADESDE = F_Set_NullValue(mFECHADESDE)
		mFECHAHASTA = F_Set_NullValue(mFECHAHASTA)
		mIDTIPOAUSENCIA = F_Set_NullValue(mIDTIPOAUSENCIA)
		mIDTIPOAUSENCIA_Desc = F_Set_NullValue(mIDTIPOAUSENCIA_Desc)
		mIDUSUARIOSOLICITA = F_Set_NullValue(mIDUSUARIOSOLICITA)
		mIDUSUARIOSOLICITA_Desc = F_Set_NullValue(mIDUSUARIOSOLICITA_Desc)
		mFECHASOLICITUD = F_Set_NullValue(mFECHASOLICITUD)
		mIDUSUARIOVALIDA = F_Set_NullValue(mIDUSUARIOVALIDA)
		mIDUSUARIOVALIDA_Desc = F_Set_NullValue(mIDUSUARIOVALIDA_Desc)
		mFECHAVALIDACION = F_Set_NullValue(mFECHAVALIDACION)
		mIDUSUARIOAPRUEBA = F_Set_NullValue(mIDUSUARIOAPRUEBA)
		mIDUSUARIOAPRUEBA_Desc = F_Set_NullValue(mIDUSUARIOAPRUEBA_Desc)
		mFECHAAPROBACION = F_Set_NullValue(mFECHAAPROBACION)
		mIDUSUARIOANULA = F_Set_NullValue(mIDUSUARIOANULA)
		mIDUSUARIOANULA_Desc = F_Set_NullValue(mIDUSUARIOANULA_Desc)
		mFECHAANULACION = F_Set_NullValue(mFECHAANULACION)
	End Sub

	Public Sub New(
			Byval IDEMPLEADO as Long,
			Byval FECHADESDE as Date,
			Byval FECHAHASTA as Date,
			Byval IDTIPOAUSENCIA as Long,
			Byval IDUSUARIOSOLICITA as String)	
		Me.New()
		Me.BeginUpdate()
		Me.IDEMPLEADO = IDEMPLEADO
		Me.FECHADESDE = FECHADESDE
		Me.FECHAHASTA = FECHAHASTA
		Me.IDTIPOAUSENCIA = IDTIPOAUSENCIA
		Me.IDUSUARIOSOLICITA = IDUSUARIOSOLICITA
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
	
	Public Property IDTIPOAUSENCIA() as Long
        Get
            Return mIDTIPOAUSENCIA
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("IDTIPOAUSENCIA", Value)
            mIDTIPOAUSENCIA = Value
        End Set
	End Property
	
	Public Property IDTIPOAUSENCIA_Desc() as String
        Get
            Return mIDTIPOAUSENCIA_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDTIPOAUSENCIA_Desc", Value)
            mIDTIPOAUSENCIA_Desc = Value
        End Set
	End Property
	
	Public Property IDUSUARIOSOLICITA() as String
        Get
            Return mIDUSUARIOSOLICITA
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOSOLICITA", Value)
            mIDUSUARIOSOLICITA = Value
        End Set
	End Property
	
	Public Property IDUSUARIOSOLICITA_Desc() as String
        Get
            Return mIDUSUARIOSOLICITA_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOSOLICITA_Desc", Value)
            mIDUSUARIOSOLICITA_Desc = Value
        End Set
	End Property
	
	Public Property FECHASOLICITUD() as DateTime
        Get
            Return mFECHASOLICITUD
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHASOLICITUD", Value)
            mFECHASOLICITUD = Value
        End Set
	End Property
	
	Public Property IDUSUARIOVALIDA() as String
        Get
            Return mIDUSUARIOVALIDA
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOVALIDA", Value)
            mIDUSUARIOVALIDA = Value
        End Set
	End Property
	
	Public Property IDUSUARIOVALIDA_Desc() as String
        Get
            Return mIDUSUARIOVALIDA_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOVALIDA_Desc", Value)
            mIDUSUARIOVALIDA_Desc = Value
        End Set
	End Property
	
	Public Property FECHAVALIDACION() as DateTime
        Get
            Return mFECHAVALIDACION
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHAVALIDACION", Value)
            mFECHAVALIDACION = Value
        End Set
	End Property
	
	Public Property IDUSUARIOAPRUEBA() as String
        Get
            Return mIDUSUARIOAPRUEBA
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOAPRUEBA", Value)
            mIDUSUARIOAPRUEBA = Value
        End Set
	End Property
	
	Public Property IDUSUARIOAPRUEBA_Desc() as String
        Get
            Return mIDUSUARIOAPRUEBA_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOAPRUEBA_Desc", Value)
            mIDUSUARIOAPRUEBA_Desc = Value
        End Set
	End Property
	
	Public Property FECHAAPROBACION() as DateTime
        Get
            Return mFECHAAPROBACION
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHAAPROBACION", Value)
            mFECHAAPROBACION = Value
        End Set
	End Property
	
	Public Property IDUSUARIOANULA() as String
        Get
            Return mIDUSUARIOANULA
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOANULA", Value)
            mIDUSUARIOANULA = Value
        End Set
	End Property
	
	Public Property IDUSUARIOANULA_Desc() as String
        Get
            Return mIDUSUARIOANULA_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOANULA_Desc", Value)
            mIDUSUARIOANULA_Desc = Value
        End Set
	End Property
	
	Public Property FECHAANULACION() as DateTime
        Get
            Return mFECHAANULACION
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHAANULACION", Value)
            mFECHAANULACION = Value
        End Set
	End Property
#End Region

End Class

