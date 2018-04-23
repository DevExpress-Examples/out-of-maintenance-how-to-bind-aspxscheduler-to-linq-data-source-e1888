<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v15.2" Namespace="DevExpress.Web.ASPxScheduler"
    TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.XtraScheduler.v15.2.Core, Version=15.2.0.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4"
    Namespace="DevExpress.XtraScheduler" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" AppointmentDataSourceID="AppointmentDataSource"
            OnAppointmentRowInserted="ASPxScheduler1_AppointmentRowInserted" OnAppointmentRowInserting="ASPxScheduler1_AppointmentRowInserting"
            OnAppointmentsInserted="ASPxScheduler1_AppointmentsInserted" ResourceDataSourceID="ResourceDataSource" Start="2008-07-23">
            <Storage>
                <Appointments >
                    <Mappings AppointmentId="ID" Status="Status" Subject="Subject" Description="Description" Label="Label" End="EndTime" Start="StartTime" Location="Location" AllDay="AllDay" Type="EventType" RecurrenceInfo="RecurrenceInfo" ReminderInfo="ReminderInfo" ResourceId="CarId" />
                </Appointments>
                <Resources>
                    <Mappings ResourceId="ID" Caption="Model" />                    
                </Resources>
            </Storage>
            <Views>
                <DayView>
                    <TimeRulers>
                        <dx:TimeRuler>
                        </dx:TimeRuler>
                    </TimeRulers>
                </DayView>
                <WorkWeekView>
                    <TimeRulers>
                        <dx:TimeRuler>
                        </dx:TimeRuler>
                    </TimeRulers>
                </WorkWeekView>
            </Views>
        </dxwschs:ASPxScheduler>
        <asp:LinqDataSource ID="AppointmentDataSource" runat="server" ContextTypeName="DataClassesDataContext"
            EnableDelete="True" EnableInsert="True" EnableUpdate="True" EnableViewState="False"
            StoreOriginalValuesInViewState="False" TableName="CarSchedulings" 
            oninserted="AppointmentDataSource_Inserted">
        </asp:LinqDataSource>
        <asp:LinqDataSource ID="ResourceDataSource" runat="server" ContextTypeName="DataClassesDataContext"
            EnableViewState="False" StoreOriginalValuesInViewState="False" TableName="Cars">
        </asp:LinqDataSource>
    </div>
    </form>
</body>
</html>
