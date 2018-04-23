using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraScheduler;
using DevExpress.Web.ASPxScheduler;

public partial class _Default : System.Web.UI.Page 
{
    int lastInsertedAppointmentId;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ASPxScheduler1_AppointmentRowInserted(object sender, DevExpress.Web.ASPxScheduler.ASPxSchedulerDataInsertedEventArgs e) {
        e.KeyFieldValue = this.lastInsertedAppointmentId;
    }
    protected void ASPxScheduler1_AppointmentRowInserting(object sender, DevExpress.Web.ASPxScheduler.ASPxSchedulerDataInsertingEventArgs e) {
        e.NewValues.Remove("ID");
    }
    protected void ASPxScheduler1_AppointmentsInserted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e) {
        int count = e.Objects.Count;
        System.Diagnostics.Debug.Assert(count == 1);
        Appointment apt = (Appointment)e.Objects[0];
        ASPxSchedulerStorage storage = (ASPxSchedulerStorage)sender;
        storage.SetAppointmentId(apt, this.lastInsertedAppointmentId);
    }
    protected void AppointmentDataSource_Inserted(object sender, LinqDataSourceStatusEventArgs e) {
        CarScheduling apt = e.Result as CarScheduling;
        if(apt == null)
            return;
        this.lastInsertedAppointmentId = apt.ID;
    }
}
