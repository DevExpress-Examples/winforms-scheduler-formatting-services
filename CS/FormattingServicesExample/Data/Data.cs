using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraScheduler;

namespace FormattingServicesExample {
    public partial class Form1 {

        public static string[] Users = new string[] { "Peter Dolan", "Ryan Fischer", "Andrew Miller", "Tom Hamlett",
                                                        "Jerry Campbell", "Carl Lucas", "Mark Hamilton", "Steve Lee" };


        private void LoadData() {
            FillResources(schedulerStorage1, int.MaxValue);
            schedulerControl1.GroupType = SchedulerGroupType.Resource;
            schedulerStorage1.Appointments.ResourceSharing = true;
            PrepareMeetings(schedulerControl1.Start);
        }

        public static void FillResources(SchedulerDataStorage storage, int count) {
            ResourceCollection resources = storage.Resources.Items;
            int cnt = Math.Min(count, Users.Length);
            for(int i = 1; i <= cnt; i++)
                resources.Add(storage.CreateResource(i, Users[i - 1]));

        }


        void PrepareMeetings(DateTime refTime) {
            int resourceCount = schedulerStorage1.Resources.Count;
            System.Diagnostics.Debug.Assert(resourceCount == 8);

            Appointment apt = CreateMeeting("Morning meeting", refTime + TimeSpan.FromHours(9), new int[] { 1, 3, 5 });
            apt.StatusKey = 2;
            apt.LabelKey = 2;
            schedulerStorage1.Appointments.Add(apt);

            apt = CreateMeeting("Product delivery planning", refTime + TimeSpan.FromHours(12), new int[] { 2, 4, 5 });
            apt.StatusKey = 2;
            apt.LabelKey = 5;
            schedulerStorage1.Appointments.Add(apt);

            apt = CreateMeeting("New product concept presentation", refTime + TimeSpan.FromHours(14), new int[] { 2, 3, 6 });
            apt.StatusKey = 1;
            apt.LabelKey = 6;
            schedulerStorage1.Appointments.Add(apt);

            apt = CreateMeeting("Discussion", refTime + TimeSpan.FromHours(16), new int[] { 1, 2, 3, 5 });
            apt.StatusKey = 2;
            apt.LabelKey = 5;
            schedulerStorage1.Appointments.Add(apt);

            apt = CreateMeeting("New employee interview", refTime + TimeSpan.FromHours(11), new int[] { 2, 3 });
            apt.StatusKey = 1;
            apt.LabelKey = 4;
            schedulerStorage1.Appointments.Add(apt);
        }
        Appointment CreateMeeting(string subject, DateTime date, int[] participants) {
            Appointment apt = schedulerStorage1.CreateAppointment(AppointmentType.Normal, date, TimeSpan.FromHours(1), subject);
            string description = "The following persons are invited:\r\n";
            int count = participants.Length;
            for(int i = 0; i < count; i++) {
                Resource resource = schedulerStorage1.Resources[participants[i]];
                description += String.Format("{0}\r\n", resource.Caption);
                apt.ResourceIds.Add(resource.Id);
            }
            apt.Description = description;
            return apt;
        }

    }
}
