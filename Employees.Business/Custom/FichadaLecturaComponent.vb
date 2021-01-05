Imports Employees.Data
Imports System.Collections.Generic
Imports Employees.Entities
Partial Public Class FichadaLecturaComponent
    Public Function SaveCol(list As List(Of FichadaLectura), Optional ByRef errMsj As String = "") As Boolean
        Dim oDAL As New FichadaLecturaData
        Dim bResul As Boolean = True

        Try
            oDAL.BeginTransaction()

            For Each eFichada As FichadaLectura In list
                If Not Save(eFichada) Then
                    bResul = False
                    Exit For
                End If
            Next

            If bResul Then
                oDAL.CommitTransaction()
            Else
                oDAL.CancelTransaction()
            End If

        Catch ex As Exception
            errMsj = ex.Message
            bResul = False
            oDAL.CancelTransaction()
        End Try

        Return bResul
    End Function

    Public Function AnalizaHuerfanos(ByRef strSinCruzar As String) As Boolean
        Dim List As List(Of FichadaLectura)
        Dim objEmpleados As New EmpleadoComponent
        Try
            List = GetHuerfanos()
            For Each ent As FichadaLectura In List
                Dim ListEmpleados As List(Of Empleado) = objEmpleados.GetByDocumento(ent.IDEMPLEADOLECTORA)
                ListEmpleados = ListEmpleados.Where(Function(f) f.INACTIVO = False).ToList
                If ListEmpleados.Count = 1 Then
                    ent.BeginUpdate()
                    ent.IDEMPLEADO = ListEmpleados(0).ID
                    Save(ent, False)
                Else
                    If Not strSinCruzar.Contains(ent.IDEMPLEADOLECTORA) Then strSinCruzar &= "IDEMPLEADOLECTORA: " & ent.IDEMPLEADOLECTORA & vbCrLf
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function LimpiarFichada(ByRef ID As Long, ByVal idUsuario As String, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Dim oDAL As New FichadaLecturaData
        Dim fljOk As Boolean = False
        Try
            oDAL.BeginTransaction()

            If oDAL.LimpiarFichada(ID, ThrowErr) Then
                Dim objTrazaCambio As New TrazaCambioComponent
                Dim entTrazaCambio As New TrazaCambio
                entTrazaCambio.BeginUpdate()
                entTrazaCambio.IDFICHADALECTURA = ID
                entTrazaCambio.IDAUXILIAR = ID
                entTrazaCambio.TABLAAUXILIAR = "FichadaLectura"
                entTrazaCambio.OBSERVACIONES = "Se deshacen cambios en la fichada."
                entTrazaCambio.IDUSUARIO = idUsuario

                fljOk = objTrazaCambio.Save(entTrazaCambio)
            End If

            If fljOk Then
                oDAL.CommitTransaction()
            Else
                oDAL.CancelTransaction()
            End If
        Catch ex As Exception
            oDAL.CancelTransaction()
        Finally
            oDAL.Desconectar()
        End Try

        Return fljOk
    End Function

    Public Function CambioEstado(ByRef ent As FichadaLectura, ByVal idUsuario As String, ByVal Mensaje As String, ByRef MensajeError As String, Optional ByVal ThrowErr As Boolean = False) As Boolean
        Dim oDAL As New FichadaLecturaData
        Dim fljOk As Boolean = False
        Dim objUsuario As New UsuarioComponent
        Dim entUsuario As Usuario
        Dim entOriginal As FichadaLectura
        Try
            entUsuario = objUsuario.GetEntById(idUsuario)
            If entUsuario Is Nothing Then
                MensajeError = "No tiene derechos para realizar esta operación"
                Return False
            End If
            entOriginal = GetEntById(ent.ID)
            If entOriginal Is Nothing Then Return False

            oDAL.BeginTransaction()

            If Save(ent, False, ThrowErr) Then
                Dim objTrazaCambio As New TrazaCambioComponent
                Dim entTrazaCambio As New TrazaCambio
                entTrazaCambio.BeginUpdate()
                entTrazaCambio.IDFICHADALECTURA = ent.ID
                entTrazaCambio.IDAUXILIAR = ent.ID
                entTrazaCambio.TABLAAUXILIAR = "FichadaLectura"
                entTrazaCambio.OBSERVACIONES = Mensaje
                entTrazaCambio.IDUSUARIO = idUsuario

                fljOk = objTrazaCambio.Save(entTrazaCambio)
            End If

            If fljOk Then
                oDAL.CommitTransaction()
            Else
                oDAL.CancelTransaction()
            End If
        Catch ex As Exception
            oDAL.CancelTransaction()
        Finally
            oDAL.Desconectar()
        End Try

        Return fljOk
    End Function
End Class
