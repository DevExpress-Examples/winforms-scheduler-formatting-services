Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing
Imports DevExpress.XtraScheduler.Services
Imports System
Imports System.Windows.Forms

Namespace FormattingServicesExample

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            LoadData()
            CreateAppointmentFormatStringService()
            CreateTimeRulerFormatStringService()
            CreateHeaderCaptionService()
            CreateHeaderToolTipService()
            schedulerControl1.DayView.TopRowTime = New TimeSpan(9, 0, 0)
            schedulerControl1.WorkWeekView.TopRowTime = New TimeSpan(9, 0, 0)
        End Sub

        Private prevTimeRulerFormatStringService As ITimeRulerFormatStringService

        Private customTimeRulerFormatStringService As CustomTimeRulerFormatStringService

        Private prevAppointmentFormatStringService As IAppointmentFormatStringService

        Private customAppointmentFormatStringService As CustomAppointmentFormatStringService

        Private prevHeaderCaptionService As IHeaderCaptionService

        Private customHeaderCaptionService As CustomHeaderCaptionService

        Private prevHeaderToolTipService As IHeaderToolTipService

        Private customHeaderToolTipService As CustomHeaderToolTipService

        Public Sub CreateAppointmentFormatStringService()
            prevAppointmentFormatStringService = CType(schedulerControl1.GetService(GetType(IAppointmentFormatStringService)), IAppointmentFormatStringService)
            customAppointmentFormatStringService = New CustomAppointmentFormatStringService(prevAppointmentFormatStringService)
        End Sub

        Public Sub CreateTimeRulerFormatStringService()
            prevTimeRulerFormatStringService = CType(schedulerControl1.GetService(GetType(ITimeRulerFormatStringService)), ITimeRulerFormatStringService)
            customTimeRulerFormatStringService = New CustomTimeRulerFormatStringService(prevTimeRulerFormatStringService)
        End Sub

        Public Sub CreateHeaderCaptionService()
            prevHeaderCaptionService = CType(schedulerControl1.GetService(GetType(IHeaderCaptionService)), IHeaderCaptionService)
            customHeaderCaptionService = New CustomHeaderCaptionService(prevHeaderCaptionService)
        End Sub

        Public Sub CreateHeaderToolTipService()
            prevHeaderToolTipService = CType(schedulerControl1.GetService(GetType(IHeaderToolTipService)), IHeaderToolTipService)
            customHeaderToolTipService = New CustomHeaderToolTipService(prevHeaderToolTipService)
        End Sub

        Private Sub checkButton1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If checkButton1.Checked Then
                schedulerControl1.RemoveService(GetType(IAppointmentFormatStringService))
                schedulerControl1.AddService(GetType(IAppointmentFormatStringService), customAppointmentFormatStringService)
                schedulerControl1.RemoveService(GetType(ITimeRulerFormatStringService))
                schedulerControl1.AddService(GetType(ITimeRulerFormatStringService), customTimeRulerFormatStringService)
                schedulerControl1.RemoveService(GetType(IHeaderCaptionService))
                schedulerControl1.AddService(GetType(IHeaderCaptionService), customHeaderCaptionService)
                schedulerControl1.RemoveService(GetType(IHeaderToolTipService))
                schedulerControl1.AddService(GetType(IHeaderToolTipService), customHeaderToolTipService)
                schedulerControl1.ActiveView.LayoutChanged()
            Else
                schedulerControl1.RemoveService(GetType(IAppointmentFormatStringService))
                schedulerControl1.AddService(GetType(IAppointmentFormatStringService), prevAppointmentFormatStringService)
                schedulerControl1.RemoveService(GetType(ITimeRulerFormatStringService))
                schedulerControl1.AddService(GetType(ITimeRulerFormatStringService), prevTimeRulerFormatStringService)
                schedulerControl1.RemoveService(GetType(IHeaderCaptionService))
                schedulerControl1.AddService(GetType(IHeaderCaptionService), prevHeaderCaptionService)
                schedulerControl1.RemoveService(GetType(IHeaderToolTipService))
                schedulerControl1.AddService(GetType(IHeaderToolTipService), prevHeaderToolTipService)
                schedulerControl1.ActiveView.LayoutChanged()
            End If
        End Sub
    End Class

    Public Class CustomTimeRulerFormatStringService
        Inherits TimeRulerFormatStringServiceWrapper

        Public Sub New(ByVal service As ITimeRulerFormatStringService)
            MyBase.New(service)
        End Sub

'#Region "ITimeRulerFormatStringService Members"
        Public Overrides Function GetHalfDayHourFormat(ByVal ruler As TimeRuler) As String
            Return If(ruler.UseClientTimeZone, "hh:mm", "HH:mm")
        End Function

        Public Overrides Function GetHourFormat(ByVal ruler As TimeRuler) As String
            Return If(ruler.UseClientTimeZone, "hh:mm", "HH:mm")
        End Function

        Public Overrides Function GetHourOnlyFormat(ByVal ruler As TimeRuler) As String
            Return If(ruler.UseClientTimeZone, "hh", "HH")
        End Function

        Public Overrides Function GetMinutesOnlyFormat(ByVal ruler As TimeRuler) As String
            Return "mm"
        End Function

        Public Overrides Function GetTimeDesignatorOnlyFormat(ByVal ruler As TimeRuler) As String
            Return If(ruler.UseClientTimeZone, "tt", "mm")
        End Function
'#End Region
    End Class

    Public Class CustomAppointmentFormatStringService
        Inherits AppointmentFormatStringServiceWrapper

        Public Sub New(ByVal service As IAppointmentFormatStringService)
            MyBase.New(service)
        End Sub

'#Region "IAppointmentFormatStringService Members"
        Public Overrides Function GetVerticalAppointmentStartFormat(ByVal aptViewInfo As IAppointmentViewInfo) As String
            Return "{0: HHmm:ss}"
        End Function

        Public Overrides Function GetVerticalAppointmentEndFormat(ByVal aptViewInfo As IAppointmentViewInfo) As String
            Return "{0: HHmm:ss}"
        End Function

        Public Overrides Function GetHorizontalAppointmentEndFormat(ByVal aptViewInfo As IAppointmentViewInfo) As String
            Return "{0: HHmm}"
        End Function

        Public Overrides Function GetHorizontalAppointmentStartFormat(ByVal aptViewInfo As IAppointmentViewInfo) As String
            Return "{0: HHmm}"
        End Function

        Public Overrides Function GetContinueItemStartFormat(ByVal aptViewInfo As IAppointmentViewInfo) As String
            Return "{0: HHmm MMM dd}"
        End Function

        Public Overrides Function GetContinueItemEndFormat(ByVal aptViewInfo As IAppointmentViewInfo) As String
            Return "{0: HHmm MMM dd}"
        End Function
'#End Region
    End Class

    Public Class CustomHeaderCaptionService
        Inherits HeaderCaptionServiceWrapper

        Public Sub New(ByVal service As IHeaderCaptionService)
            MyBase.New(service)
        End Sub

'#Region "IHeaderCaptionService Members"
        Public Overrides Function GetDayColumnHeaderCaption(ByVal header As DayHeader) As String
            Dim [date] As Date = header.Interval.Start.Date
            If [date].Month = 1 AndAlso [date].Day = 1 Then
                Return "DayColumnHeader"
            Else
                Return MyBase.GetDayColumnHeaderCaption(header)
            End If
        End Function

        Public Overrides Function GetDayOfWeekAbbreviatedHeaderCaption(ByVal header As DayOfWeekHeader) As String
            Dim [date] As DayOfWeek = header.DayOfWeek
            If [date] = DayOfWeek.Thursday Then
                Return "DOW"
            Else
                Return MyBase.GetDayOfWeekAbbreviatedHeaderCaption(header)
            End If
        End Function

        Public Overrides Function GetDayOfWeekHeaderCaption(ByVal header As DayOfWeekHeader) As String
            Dim [date] As DayOfWeek = header.DayOfWeek
            If [date] = DayOfWeek.Thursday Then
                Return "DayOfWeekHeader"
            Else
                Return MyBase.GetDayOfWeekHeaderCaption(header)
            End If
        End Function

        Public Overrides Function GetHorizontalWeekCellHeaderCaption(ByVal header As SchedulerHeader) As String
            Dim [date] As Date = header.Interval.Start.Date
            If [date].Month = 1 AndAlso [date].Day = 1 Then
                Return "HorizontalWeekCellHeader"
            Else
                Return MyBase.GetHorizontalWeekCellHeaderCaption(header)
            End If
        End Function

        Public Overrides Function GetTimeScaleHeaderCaption(ByVal header As TimeScaleHeader) As String
            Dim [date] As Date = header.Interval.Start.Date
            If [date].Month = 1 AndAlso [date].Day = 1 Then
                Return "TimeScaleHeader"
            Else
                Return MyBase.GetTimeScaleHeaderCaption(header)
            End If
        End Function

        Public Overrides Function GetVerticalWeekCellHeaderCaption(ByVal header As SchedulerHeader) As String
            Dim [date] As Date = header.Interval.Start.Date
            If [date].Month = 1 AndAlso [date].Day = 1 Then
                Return "VerticalWeekCellHeader"
            Else
                Return MyBase.GetVerticalWeekCellHeaderCaption(header)
            End If
        End Function
'#End Region
    End Class

    Public Class CustomHeaderToolTipService
        Inherits HeaderToolTipServiceWrapper

        Public Sub New(ByVal service As IHeaderToolTipService)
            MyBase.New(service)
        End Sub

'#Region "IHeaderToolTipService Members"
        Public Overrides Function GetDayColumnHeaderToolTip(ByVal header As DayHeader) As String
            Dim [date] As Date = header.Interval.Start.Date
            If [date].Month = 1 AndAlso [date].Day = 1 Then
                Return "Let's celebrate!"
            Else
                Return MyBase.GetDayColumnHeaderToolTip(header)
            End If
        End Function

        Public Overrides Function GetDayOfWeekHeaderToolTip(ByVal header As DayOfWeekHeader) As String
            If header.Interval.Contains(New DateTime(2009, 1, 1)) Then
                Return "Let's celebrate!"
            Else
                Return MyBase.GetDayOfWeekHeaderToolTip(header)
            End If
        End Function

        Public Overrides Function GetTimeScaleHeaderToolTip(ByVal header As TimeScaleHeader) As String
            If header.Interval.Contains(New DateTime(2009, 1, 1)) Then
                Return "Let's celebrate!"
            Else
                Return MyBase.GetTimeScaleHeaderToolTip(header)
            End If
        End Function
'#End Region
    End Class
End Namespace
