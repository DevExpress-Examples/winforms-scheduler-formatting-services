<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128633627/18.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E507)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WinForms Scheduler - Formatting services

The WinForms scheduler control implements a set of services that make common tasks easier to implement (such as navigation, selection, formatting, keyboard and mouse event handling, etc.). 

This example demonstrates [formatting services](https://docs.devexpress.com/WindowsForms/4747/controls-and-libraries/scheduler/services/formatting-services):

```csharp
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
```

## Documentation

* [Scheduler Services](https://docs.devexpress.com/WindowsForms/4106/controls-and-libraries/scheduler/services)
