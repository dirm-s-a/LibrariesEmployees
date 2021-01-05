
'	Project Employees
'		Employees Example
'	Entity	HorarioAdicEmpleado
'		HorarioAdicEmpleado Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class HorarioAdicEmpleado
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mIDEMPLEADO as Long
			
	Private mFECHADESDE as Date
			
	Private mFECHAHASTA as Date
			
	Private mHORAENTRADA as Integer
			
	Private mHORASALIDA as Integer
			
	Private mHORAENTRADA1 as Integer
			
	Private mHORASALIDA1 as Integer
			
	Private mHORAENTRADA2 as Integer
			
	Private mHORASALIDA2 as Integer
			
	Private mACTIVO as Boolean
			
	Private mFECHABAJA as DateTime
			
	Private mIDUSUARIOBAJA as String
			
	Private mFECHAMODIFICACION as DateTime
			
	Private mIDUSUARIOMODIFICACION as String
			
	Private mMINUTOSACUMPLIR as Integer
			
	Private mAUTORIZADO as Boolean
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDEMPLEADO_Desc as String
			
	Private mIDUSUARIOBAJA_Desc as String
			
	Private mIDUSUARIOMODIFICACION_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "HORARIOSADICEMPLEADOS"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mIDEMPLEADO = F_Set_NullValue(mIDEMPLEADO)
		mIDEMPLEADO_Desc = F_Set_NullValue(mIDEMPLEADO_Desc)
		mFECHADESDE = F_Set_NullValue(mFECHADESDE)
		mFECHAHASTA = F_Set_NullValue(mFECHAHASTA)
		mHORAENTRADA = F_Set_NullValue(mHORAENTRADA)
		mHORASALIDA = F_Set_NullValue(mHORASALIDA)
		mHORAENTRADA1 = F_Set_NullValue(mHORAENTRADA1)
		mHORASALIDA1 = F_Set_NullValue(mHORASALIDA1)
		mHORAENTRADA2 = F_Set_NullValue(mHORAENTRADA2)
		mHORASALIDA2 = F_Set_NullValue(mHORASALIDA2)
		mACTIVO = F_Set_NullValue(mACTIVO)
		mFECHABAJA = F_Set_NullValue(mFECHABAJA)
		mIDUSUARIOBAJA = F_Set_NullValue(mIDUSUARIOBAJA)
		mIDUSUARIOBAJA_Desc = F_Set_NullValue(mIDUSUARIOBAJA_Desc)
		mFECHAMODIFICACION = F_Set_NullValue(mFECHAMODIFICACION)
		mIDUSUARIOMODIFICACION = F_Set_NullValue(mIDUSUARIOMODIFICACION)
		mIDUSUARIOMODIFICACION_Desc = F_Set_NullValue(mIDUSUARIOMODIFICACION_Desc)
		mMINUTOSACUMPLIR = F_Set_NullValue(mMINUTOSACUMPLIR)
		mAUTORIZADO = F_Set_NullValue(mAUTORIZADO)
	End Sub

	Public Sub New(
			Byval IDEMPLEADO as Long,
			Byval FECHADESDE as Date,
			Byval FECHAHASTA as Date,
			Byval HORAENTRADA as Integer,
			Byval HORASALIDA as Integer,
			Byval IDUSUARIOMODIFICACION as String)	
		Me.New()
		Me.BeginUpdate()
		Me.IDEMPLEADO = IDEMPLEADO
		Me.FECHADESDE = FECHADESDE
		Me.FECHAHASTA = FECHAHASTA
		Me.HORAENTRADA = HORAENTRADA
		Me.HORASALIDA = HORASALIDA
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
	
	Public Property HORAENTRADA() as Integer
        Get
            Return mHORAENTRADA
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("HORAENTRADA", Value)
            mHORAENTRADA = Value
        End Set
	End Property
	
	Public Property HORASALIDA() as Integer
        Get
            Return mHORASALIDA
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("HORASALIDA", Value)
            mHORASALIDA = Value
        End Set
	End Property
	
	Public Property HORAENTRADA1() as Integer
        Get
            Return mHORAENTRADA1
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("HORAENTRADA1", Value)
            mHORAENTRADA1 = Value
        End Set
	End Property
	
	Public Property HORASALIDA1() as Integer
        Get
            Return mHORASALIDA1
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("HORASALIDA1", Value)
            mHORASALIDA1 = Value
        End Set
	End Property
	
	Public Property HORAENTRADA2() as Integer
        Get
            Return mHORAENTRADA2
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("HORAENTRADA2", Value)
            mHORAENTRADA2 = Value
        End Set
	End Property
	
	Public Property HORASALIDA2() as Integer
        Get
            Return mHORASALIDA2
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("HORASALIDA2", Value)
            mHORASALIDA2 = Value
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
	
	Public Property FECHABAJA() as DateTime
        Get
            Return mFECHABAJA
        End Get
        Set(ByVal Value As DateTime)
			MyBase.ChangeProperty("FECHABAJA", Value)
            mFECHABAJA = Value
        End Set
	End Property
	
	Public Property IDUSUARIOBAJA() as String
        Get
            Return mIDUSUARIOBAJA
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOBAJA", Value)
            mIDUSUARIOBAJA = Value
        End Set
	End Property
	
	Public Property IDUSUARIOBAJA_Desc() as String
        Get
            Return mIDUSUARIOBAJA_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOBAJA_Desc", Value)
            mIDUSUARIOBAJA_Desc = Value
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
	
	Public Property MINUTOSACUMPLIR() as Integer
        Get
            Return mMINUTOSACUMPLIR
        End Get
        Set(ByVal Value As Integer)
			MyBase.ChangeProperty("MINUTOSACUMPLIR", Value)
            mMINUTOSACUMPLIR = Value
        End Set
	End Property
	
	Public Property AUTORIZADO() as Boolean
        Get
            Return mAUTORIZADO
        End Get
        Set(ByVal Value As Boolean)
			MyBase.ChangeProperty("AUTORIZADO", Value)
            mAUTORIZADO = Value
        End Set
	End Property
#End Region

End Class

