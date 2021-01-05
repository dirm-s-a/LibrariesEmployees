
'	Project Employees
'		Employees Example
'	Entity	Feriado
'		Feriado Entity
'	
'	Generado por Victor

Imports Turnos.GlobalFunctions.Data

<Serializable()> Public Partial Class Feriado
	Inherits BaseEntity
	
#Region	"Private Fields"

#Region "Table Fields"
			
	Private mID as Long
			
	Private mDESCRIPCION as String
			
	Private mFECHA as Date
			
	Private mACTIVO as Boolean
			
	Private mFECHAALTA as DateTime
			
	Private mFECHAANULACION as DateTime
#End Region

#Region "Description (Joins) Fields"
#End Region

#End Region

'	Default Constructor

	Public Sub New()
		MyBase.New()
		
		mTable = "FERIADOS"
		
		KeyFields.Add("ID", F_Set_NullValue(mID))

		mID = F_Set_NullValue(mID)
		mDESCRIPCION = F_Set_NullValue(mDESCRIPCION)
		mFECHA = F_Set_NullValue(mFECHA)
		mACTIVO = F_Set_NullValue(mACTIVO)
		mFECHAALTA = F_Set_NullValue(mFECHAALTA)
		mFECHAANULACION = F_Set_NullValue(mFECHAANULACION)
	End Sub

	Public Sub New(
			Byval DESCRIPCION as String,
			Byval FECHA as Date)	
		Me.New()
		Me.BeginUpdate()
		Me.DESCRIPCION = DESCRIPCION
		Me.FECHA = FECHA
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
	
	Public Property FECHA() as Date
        Get
            Return mFECHA
        End Get
        Set(ByVal Value As Date)
			MyBase.ChangeProperty("FECHA", Value)
            mFECHA = Value
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

