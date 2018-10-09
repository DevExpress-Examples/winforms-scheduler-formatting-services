Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraScheduler

Namespace FormattingServicesExample
    Partial Public Class Form1

        Public Shared Users() As String = { "Peter Dolan", "Ryan Fischer", "Andrew Miller", "Tom Hamlett", "Jerry Campbell", "Carl Lucas", "Mark Hamilton", "Steve Lee" }


        Private Sub LoadData()
            FillResources(schedulerStorage1, Integer.MaxValue)
            schedulerControl1.GroupType = SchedulerGroupType.Resource
            schedulerStorage1.Appointments.ResourceSharing = True
            PrepareMeetings(schedulerControl1.Start)
        End Sub

        Public Shared Sub FillResources(ByVal storage As SchedulerDataStorage, ByVal count As Integer)
            Dim resources As ResourceCollection = storage.Resources.Items
            Dim cnt As Integer = Math.Min(count, Users.Length)
            For i As Integer = 1 To cnt
                resources.Add(storage.CreateResource(i, Users(i - 1)))
            Next i

        End Sub


        Private Sub PrepareMeetings(ByVal refTime As Date)
            Dim resourceCount As Integer = schedulerStorage1.Resources.Count
            System.Diagnostics.Debug.Assert(resourceCount = 8)

            Dim apt As Appointment = CreateMeeting("Morning meeting", refTime.Add(TimeSpan.FromHours(9)), New Integer() { 1, 3, 5 })
            apt.StatusKey = 2
            apt.LabelKey = 2
            schedulerStorage1.Appointments.Add(apt)

            apt = CreateMeeting("Product delivery planning", refTime.Add(TimeSpan.FromHours(12)), New Integer() { 2, 4, 5 })
            apt.StatusKey = 2
            apt.LabelKey = 5
            schedulerStorage1.Appointments.Add(apt)

            apt = CreateMeeting("New product concept presentation", refTime.Add(TimeSpan.FromHours(14)), New Integer() { 2, 3, 6 })
            apt.StatusKey = 1
            apt.LabelKey = 6
            schedulerStorage1.Appointments.Add(apt)

            apt = CreateMeeting("Discussion", refTime.Add(TimeSpan.FromHours(16)), New Integer() { 1, 2, 3, 5 })
            apt.StatusKey = 2
            apt.LabelKey = 5
            schedulerStorage1.Appointments.Add(apt)

            apt = CreateMeeting("New employee interview", refTime.Add(TimeSpan.FromHours(11)), New Integer() { 2, 3 })
            apt.StatusKey = 1
            apt.LabelKey = 4
            schedulerStorage1.Appointments.Add(apt)
        End Sub
        Private Function CreateMeeting(ByVal subject As String, ByVal [date] As Date, ByVal participants() As Integer) As Appointment
            Dim apt As Appointment = schedulerStorage1.CreateAppointment(AppointmentType.Normal, [date], TimeSpan.FromHours(1), subject)
            Dim description As String = "The following persons are invited:" & ControlChars.CrLf
            Dim count As Integer = participants.Length
            For i As Integer = 0 To count - 1
                Dim resource As Resource = schedulerStorage1.Resources(participants(i))
                description &= String.Format("{0}" & ControlChars.CrLf, resource.Caption)
                apt.ResourceIds.Add(resource.Id)
            Next i
            apt.Description = description
            Return apt
        End Function

    End Class
End Namespace
