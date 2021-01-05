
'	Project Employees
'		Employees Example
'	Entity	GrupoSupervisor
'		GrupoSupervisor Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class GrupoSupervisor
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mIDGRUPO as Long
			
	Private mIDUSUARIOSUP as String
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDGRUPO_Desc as String
			
	Private mIDUSUARIOSUP_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "GRUPOSSUPERVISORES"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mIDGRUPO = F_Set_NullValue(mIDGRUPO)
		mIDGRUPO_Desc = F_Set_NullValue(mIDGRUPO_Desc)
		mIDUSUARIOSUP = F_Set_NullValue(mIDUSUARIOSUP)
		mIDUSUARIOSUP_Desc = F_Set_NullValue(mIDUSUARIOSUP_Desc)
	End Sub

	Public Sub New(
			Byval IDGRUPO as Long,
			Byval IDUSUARIOSUP as String)	
		Me.New()
		Me.BeginUpdate()
		Me.IDGRUPO = IDGRUPO
		Me.IDUSUARIOSUP = IDUSUARIOSUP
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
	
	Public Property IDGRUPO() as Long
        Get
            Return mIDGRUPO
        End Get
        Set(ByVal Value As Long)
			MyBase.ChangeProperty("IDGRUPO", Value)
            mIDGRUPO = Value
        End Set
	End Property
	
	Public Property IDGRUPO_Desc() as String
        Get
            Return mIDGRUPO_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDGRUPO_Desc", Value)
            mIDGRUPO_Desc = Value
        End Set
	End Property
	
	Public Property IDUSUARIOSUP() as String
        Get
            Return mIDUSUARIOSUP
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOSUP", Value)
            mIDUSUARIOSUP = Value
        End Set
	End Property
	
	Public Property IDUSUARIOSUP_Desc() as String
        Get
            Return mIDUSUARIOSUP_Desc
        End Get
        Set(ByVal Value As String)
			MyBase.ChangeProperty("IDUSUARIOSUP_Desc", Value)
            mIDUSUARIOSUP_Desc = Value
        End Set
	End Property
#End Region

End Class

