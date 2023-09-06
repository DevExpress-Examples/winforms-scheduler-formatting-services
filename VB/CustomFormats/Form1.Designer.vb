Namespace CustomFormats

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Dim timeScaleYear1 As DevExpress.XtraScheduler.TimeScaleYear = New DevExpress.XtraScheduler.TimeScaleYear()
            Dim timeScaleQuarter1 As DevExpress.XtraScheduler.TimeScaleQuarter = New DevExpress.XtraScheduler.TimeScaleQuarter()
            Dim timeScaleMonth1 As DevExpress.XtraScheduler.TimeScaleMonth = New DevExpress.XtraScheduler.TimeScaleMonth()
            Dim timeScaleWeek1 As DevExpress.XtraScheduler.TimeScaleWeek = New DevExpress.XtraScheduler.TimeScaleWeek()
            Dim timeScaleDay1 As DevExpress.XtraScheduler.TimeScaleDay = New DevExpress.XtraScheduler.TimeScaleDay()
            Dim timeScaleHour1 As DevExpress.XtraScheduler.TimeScaleHour = New DevExpress.XtraScheduler.TimeScaleHour()
            Dim timeScaleFixedInterval1 As DevExpress.XtraScheduler.TimeScaleFixedInterval = New DevExpress.XtraScheduler.TimeScaleFixedInterval()
            Dim timeRuler3 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.checkButton1 = New DevExpress.XtraEditors.CheckButton()
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 38)
            Me.schedulerControl1.LookAndFeel.UseDefaultLookAndFeel = False
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.OptionsView.ResourceHeaders.ImageSize = New System.Drawing.Size(10, 10)
            Me.schedulerControl1.OptionsView.ResourceHeaders.ImageSizeMode = DevExpress.XtraScheduler.HeaderImageSizeMode.Normal
            Me.schedulerControl1.OptionsView.ResourceHeaders.RotateCaption = False
            Me.schedulerControl1.OptionsView.ToolTipVisibility = DevExpress.XtraScheduler.ToolTipVisibility.Always
            Me.schedulerControl1.Size = New System.Drawing.Size(650, 342)
            Me.schedulerControl1.Start = New System.DateTime(2009, 1, 1, 0, 0, 0, 0)
            Me.schedulerControl1.Storage = Me.schedulerStorage1
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.AppointmentDisplayOptions.ContinueArrowDisplayType = DevExpress.XtraScheduler.AppointmentContinueArrowDisplayType.ArrowWithText
            Me.schedulerControl1.Views.DayView.AppointmentDisplayOptions.EndTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Always
            Me.schedulerControl1.Views.DayView.AppointmentDisplayOptions.StartTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Always
            Me.schedulerControl1.Views.DayView.DayCount = 3
            Me.schedulerControl1.Views.DayView.ResourcesPerPage = 3
            timeRuler1.Caption = "Local Time"
            timeRuler1.ShowMinutes = True
            timeRuler2.Caption = "GMT"
            timeRuler2.ShowMinutes = True
            timeRuler2.TimeZone.Id = DevExpress.XtraScheduler.TimeZoneId.Greenwich
            timeRuler2.UseClientTimeZone = False
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler2)
            Me.schedulerControl1.Views.MonthView.ResourcesPerPage = 3
            Me.schedulerControl1.Views.TimelineView.AppointmentDisplayOptions.AppointmentAutoHeight = True
            Me.schedulerControl1.Views.TimelineView.AppointmentDisplayOptions.ContinueArrowDisplayType = DevExpress.XtraScheduler.AppointmentContinueArrowDisplayType.ArrowWithText
            Me.schedulerControl1.Views.TimelineView.AppointmentDisplayOptions.EndTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Always
            Me.schedulerControl1.Views.TimelineView.AppointmentDisplayOptions.StartTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Always
            Me.schedulerControl1.Views.TimelineView.AppointmentDisplayOptions.TimeDisplayType = DevExpress.XtraScheduler.AppointmentTimeDisplayType.Text
            Me.schedulerControl1.Views.TimelineView.ResourcesPerPage = 3
            timeScaleYear1.Enabled = False
            timeScaleQuarter1.Enabled = False
            timeScaleMonth1.Enabled = False
            timeScaleDay1.Width = 100
            timeScaleHour1.Enabled = False
            timeScaleFixedInterval1.Enabled = False
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleYear1)
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleQuarter1)
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleMonth1)
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleWeek1)
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleDay1)
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleHour1)
            Me.schedulerControl1.Views.TimelineView.Scales.Add(timeScaleFixedInterval1)
            Me.schedulerControl1.Views.WeekView.ResourcesPerPage = 3
            Me.schedulerControl1.Views.WorkWeekView.AppointmentDisplayOptions.EndTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Always
            Me.schedulerControl1.Views.WorkWeekView.AppointmentDisplayOptions.StartTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Always
            Me.schedulerControl1.Views.WorkWeekView.ResourcesPerPage = 3
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3)
            ' 
            ' panelControl1
            ' 
            Me.panelControl1.Controls.Add(Me.checkButton1)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelControl1.Location = New System.Drawing.Point(0, 0)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(650, 38)
            Me.panelControl1.TabIndex = 6
            ' 
            ' checkButton1
            ' 
            Me.checkButton1.Location = New System.Drawing.Point(5, 5)
            Me.checkButton1.Name = "checkButton1"
            Me.checkButton1.Size = New System.Drawing.Size(92, 23)
            Me.checkButton1.TabIndex = 6
            Me.checkButton1.Text = "Custom Format"
            AddHandler Me.checkButton1.CheckedChanged, New System.EventHandler(AddressOf Me.checkButton1_CheckedChanged)
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(650, 380)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Controls.Add(Me.panelControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl

        Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage

        Private panelControl1 As DevExpress.XtraEditors.PanelControl

        Private checkButton1 As DevExpress.XtraEditors.CheckButton
    End Class
End Namespace
