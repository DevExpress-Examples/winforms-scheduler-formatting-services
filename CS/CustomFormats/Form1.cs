using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Services;
using DevExpress.XtraScheduler.Drawing;

namespace CustomFormats {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
            LoadData();
			
            CreateAppointmentFormatStringService();
			CreateTimeRulerFormatStringService();
			CreateHeaderCaptionService();
			CreateHeaderToolTipService();

            schedulerControl1.DayView.TopRowTime = new TimeSpan(9, 0, 0);
            schedulerControl1.WorkWeekView.TopRowTime = new TimeSpan(9, 0, 0);
		}

		ITimeRulerFormatStringService prevTimeRulerFormatStringService;
		CustomTimeRulerFormatStringService customTimeRulerFormatStringService;
		IAppointmentFormatStringService prevAppointmentFormatStringService;
		CustomAppointmentFormatStringService customAppointmentFormatStringService;
		IHeaderCaptionService prevHeaderCaptionService;
		CustomHeaderCaptionService customHeaderCaptionService;
		IHeaderToolTipService prevHeaderToolTipService;
		CustomHeaderToolTipService customHeaderToolTipService;


		public void CreateAppointmentFormatStringService() {
			this.prevAppointmentFormatStringService = (IAppointmentFormatStringService)schedulerControl1.GetService(typeof(IAppointmentFormatStringService));
			this.customAppointmentFormatStringService = new CustomAppointmentFormatStringService(prevAppointmentFormatStringService);
		}
		public void CreateTimeRulerFormatStringService() {
			this.prevTimeRulerFormatStringService = (ITimeRulerFormatStringService)schedulerControl1.GetService(typeof(ITimeRulerFormatStringService));
			this.customTimeRulerFormatStringService = new CustomTimeRulerFormatStringService(prevTimeRulerFormatStringService);
		}
		public void CreateHeaderCaptionService() {
			this.prevHeaderCaptionService = (IHeaderCaptionService)schedulerControl1.GetService(typeof(IHeaderCaptionService));
			this.customHeaderCaptionService = new CustomHeaderCaptionService(prevHeaderCaptionService);
		}
		public void CreateHeaderToolTipService() {
			this.prevHeaderToolTipService = (IHeaderToolTipService)schedulerControl1.GetService(typeof(IHeaderToolTipService));
			this.customHeaderToolTipService = new CustomHeaderToolTipService(prevHeaderToolTipService);
		}


        private void checkButton1_CheckedChanged(object sender, EventArgs e) {
            if (checkButton1.Checked) {
                schedulerControl1.RemoveService(typeof(IAppointmentFormatStringService));
                schedulerControl1.AddService(typeof(IAppointmentFormatStringService), customAppointmentFormatStringService);

                schedulerControl1.RemoveService(typeof(ITimeRulerFormatStringService));
                schedulerControl1.AddService(typeof(ITimeRulerFormatStringService), customTimeRulerFormatStringService);

                schedulerControl1.RemoveService(typeof(IHeaderCaptionService));
                schedulerControl1.AddService(typeof(IHeaderCaptionService), customHeaderCaptionService);

                schedulerControl1.RemoveService(typeof(IHeaderToolTipService));
                schedulerControl1.AddService(typeof(IHeaderToolTipService), customHeaderToolTipService);

                schedulerControl1.ActiveView.LayoutChanged();
            }
            else {
                schedulerControl1.RemoveService(typeof(IAppointmentFormatStringService));
                schedulerControl1.AddService(typeof(IAppointmentFormatStringService), prevAppointmentFormatStringService);

                schedulerControl1.RemoveService(typeof(ITimeRulerFormatStringService));
                schedulerControl1.AddService(typeof(ITimeRulerFormatStringService), prevTimeRulerFormatStringService);

                schedulerControl1.RemoveService(typeof(IHeaderCaptionService));
                schedulerControl1.AddService(typeof(IHeaderCaptionService), prevHeaderCaptionService);

                schedulerControl1.RemoveService(typeof(IHeaderToolTipService));
                schedulerControl1.AddService(typeof(IHeaderToolTipService), prevHeaderToolTipService);

                schedulerControl1.ActiveView.LayoutChanged();
            }
        }
	}

	public class CustomTimeRulerFormatStringService : TimeRulerFormatStringServiceWrapper {
		public CustomTimeRulerFormatStringService(ITimeRulerFormatStringService service)
			: base(service) {
		}
		#region ITimeRulerFormatStringService Members
		public override string GetHalfDayHourFormat(TimeRuler ruler) {
            return ruler.UseClientTimeZone ? "hh:mm" : "HH:mm";
		}
		public override string GetHourFormat(TimeRuler ruler) {
            return ruler.UseClientTimeZone ? "hh:mm" : "HH:mm";
        }
		public override string GetHourOnlyFormat(TimeRuler ruler) {
            return ruler.UseClientTimeZone ? "hh" : "HH";
        }
		public override string GetMinutesOnlyFormat(TimeRuler ruler) {
            return "mm";
		}
		public override string GetTimeDesignatorOnlyFormat(TimeRuler ruler) {
            return ruler.UseClientTimeZone ? "tt" : "mm";
        }
		#endregion
	}

	public class CustomAppointmentFormatStringService : AppointmentFormatStringServiceWrapper {
		public CustomAppointmentFormatStringService(IAppointmentFormatStringService service)
			: base(service) {
		}
		#region IAppointmentFormatStringService Members
		public override string GetVerticalAppointmentStartFormat(IAppointmentViewInfo aptViewInfo) {
            return "{0: HHmm:ss}";
		}
		public override string GetVerticalAppointmentEndFormat(IAppointmentViewInfo aptViewInfo) {
            return "{0: HHmm:ss}";
		}
		public override string GetHorizontalAppointmentEndFormat(IAppointmentViewInfo aptViewInfo) {
            return "{0: HHmm}";
		}
		public override string GetHorizontalAppointmentStartFormat(IAppointmentViewInfo aptViewInfo) {
            return "{0: HHmm}";
		}
        public override string GetContinueItemStartFormat(IAppointmentViewInfo aptViewInfo)
        {
            return "{0: HHmm MMM dd}";
        }
        public override string GetContinueItemEndFormat(IAppointmentViewInfo aptViewInfo)
        {
            return "{0: HHmm MMM dd}";
        }
		#endregion
	}
public class CustomHeaderCaptionService : HeaderCaptionServiceWrapper {
	public CustomHeaderCaptionService(IHeaderCaptionService service) : base(service) {
	}

	#region IHeaderCaptionService Members
	public override string GetDayColumnHeaderCaption(DayHeader header) {
		DateTime date = header.Interval.Start.Date;
		if (date.Month == 1 && date.Day == 1)
            return "DayColumnHeader";
		else
			return base.GetDayColumnHeaderCaption(header);
	}

    public override string GetDayOfWeekAbbreviatedHeaderCaption(DayOfWeekHeader header) {
        DayOfWeek date = header.DayOfWeek;
        if (date == DayOfWeek.Thursday)
            return "DOW";
        else
            return base.GetDayOfWeekAbbreviatedHeaderCaption(header);
    }

    public override string GetDayOfWeekHeaderCaption(DayOfWeekHeader header) {
        DayOfWeek date = header.DayOfWeek;
        if (date == DayOfWeek.Thursday)
            return "DayOfWeekHeader";
        else
            return base.GetDayOfWeekHeaderCaption(header);
    }

    public override string GetHorizontalWeekCellHeaderCaption(SchedulerHeader header) {
        DateTime date = header.Interval.Start.Date;
        if (date.Month == 1 && date.Day == 1)
            return "HorizontalWeekCellHeader";
        else
            return base.GetHorizontalWeekCellHeaderCaption(header);

    }

    public override string GetTimeScaleHeaderCaption(TimeScaleHeader header) {
        DateTime date = header.Interval.Start.Date;
        if (date.Month == 1 && date.Day == 1)
            return "TimeScaleHeader";
        else
            return base.GetTimeScaleHeaderCaption(header);

    }

    public override string GetVerticalWeekCellHeaderCaption(SchedulerHeader header) {
        DateTime date = header.Interval.Start.Date;
        if (date.Month == 1 && date.Day == 1)
            return "VerticalWeekCellHeader";
        else
            return base.GetVerticalWeekCellHeaderCaption(header);

    }


	#endregion
}

	public class CustomHeaderToolTipService : HeaderToolTipServiceWrapper {
		public CustomHeaderToolTipService(IHeaderToolTipService service)
			: base(service) {
		}

		#region IHeaderToolTipService Members
		public override string GetDayColumnHeaderToolTip(DayHeader header) {
			DateTime date = header.Interval.Start.Date;
			if (date.Month == 1 && date.Day == 1)
				return "Let's celebrate!";
			else
				return base.GetDayColumnHeaderToolTip(header);
		}
        public override string GetDayOfWeekHeaderToolTip(DayOfWeekHeader header)
        {
            if (header.Interval.Contains(new DateTime(2009,1,1)))
                return "Let's celebrate!";
            else
                return base.GetDayOfWeekHeaderToolTip(header);       
        }
        public override string GetTimeScaleHeaderToolTip(TimeScaleHeader header)
        {
            if (header.Interval.Contains(new DateTime(2009,1,1)))
                return "Let's celebrate!";
            else
                return base.GetTimeScaleHeaderToolTip(header);           
        }
		#endregion
	}
}