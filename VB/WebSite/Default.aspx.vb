Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.XtraScheduler
Imports DevExpress.Web.ASPxScheduler

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private lastInsertedAppointmentId As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Protected Sub ASPxScheduler1_AppointmentRowInserted(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxScheduler.ASPxSchedulerDataInsertedEventArgs)
        e.KeyFieldValue = Me.lastInsertedAppointmentId
    End Sub
    Protected Sub ASPxScheduler1_AppointmentRowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxScheduler.ASPxSchedulerDataInsertingEventArgs)
        e.NewValues.Remove("ID")
    End Sub
    Protected Sub ASPxScheduler1_AppointmentsInserted(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.PersistentObjectsEventArgs)
        Dim count As Integer = e.Objects.Count
        System.Diagnostics.Debug.Assert(count = 1)
        Dim apt As Appointment = CType(e.Objects(0), Appointment)
        Dim storage As ASPxSchedulerStorage = DirectCast(sender, ASPxSchedulerStorage)
        storage.SetAppointmentId(apt, Me.lastInsertedAppointmentId)
    End Sub
    Protected Sub AppointmentDataSource_Inserted(ByVal sender As Object, ByVal e As LinqDataSourceStatusEventArgs)
        Dim apt As CarScheduling = TryCast(e.Result, CarScheduling)
        If apt Is Nothing Then
            Return
        End If
        Me.lastInsertedAppointmentId = apt.ID
    End Sub
End Class
