
'	Project Employees
'		Employees Example
'	Entity	MapeoSupervisor
'		MapeoSupervisor Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class MapeoSupervisor
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mIDEMPLEADO as Long
			
	Private mIDUSUARIO as String
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDEMPLEADO_Desc as String
			
	Private mIDUSUARIO_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "MAPEOSUPERVISORES"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mIDEMPLEADO = F_Set_NullValue(mIDEMPLEADO)
		mIDEMPLEADO_Desc = F_Set_NullValue(mIDEMPLEADO_Desc)
		mIDUSUARIO = F_Set_NullValue(mIDUSUARIO)
		mIDUSUARIO_Desc = F_Set_NullValue(mIDUSUARIO_Desc)
	End Sub

	Public Sub New(
			Byval IDEMPLEADO as Long,
			Byval IDUSUARIO as String)	
		Me.New()
		Me.BeginUpdate()
		Me.IDEMPLEADO = IDEMPLEADO
		Me.IDUSUARIO = IDUSUARIO
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
#End Region

End Class

