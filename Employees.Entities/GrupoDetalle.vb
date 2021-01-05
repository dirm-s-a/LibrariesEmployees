
'	Project Employees
'		Employees Example
'	Entity	GrupoDetalle
'		GrupoDetalle Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class GrupoDetalle
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mIDGRUPO as Long
			
	Private mIDEMPLEADO as Long
#End Region

#Region "Description (Joins) Fields"
			
	Private mIDGRUPO_Desc as String
			
	Private mIDEMPLEADO_Desc as String
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "GRUPOSDETALLES"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mIDGRUPO = F_Set_NullValue(mIDGRUPO)
		mIDGRUPO_Desc = F_Set_NullValue(mIDGRUPO_Desc)
		mIDEMPLEADO = F_Set_NullValue(mIDEMPLEADO)
		mIDEMPLEADO_Desc = F_Set_NullValue(mIDEMPLEADO_Desc)
	End Sub

	Public Sub New(
			Byval IDGRUPO as Long,
			Byval IDEMPLEADO as Long)	
		Me.New()
		Me.BeginUpdate()
		Me.IDGRUPO = IDGRUPO
		Me.IDEMPLEADO = IDEMPLEADO
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

