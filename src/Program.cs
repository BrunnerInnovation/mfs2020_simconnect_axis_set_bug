using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.FlightSimulator.SimConnect;

namespace SimConnectManagedTest
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        private static SimConnect simConnect;

        const int WM_USER_SIMCONNECT = 0x0402;

        public enum Events
        {
            EventSteerAileron
        }
        enum NotificationGroups
        {
            Group0,
        }

        [STAThread]
        static void Main()
        {
            simConnect = new SimConnect("SimConnectTest", GetConsoleWindow(), WM_USER_SIMCONNECT, null, 0);

            simConnect.MapClientEventToSimEvent(Events.EventSteerAileron, "AILERON_SET");
            simConnect.AddClientEventToNotificationGroup(NotificationGroups.Group0, Events.EventSteerAileron, false);

            simConnect.SetNotificationGroupPriority(NotificationGroups.Group0, SimConnect.SIMCONNECT_GROUP_PRIORITY_HIGHEST);

            while (true)
            {
                Thread.Sleep(50);
                int d = (int)(Math.Sin((DateTime.Now - DateTime.Today).TotalSeconds / 2) * 16000);
                simConnect.TransmitClientEvent(0, Events.EventSteerAileron, (uint)d, NotificationGroups.Group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
            }
        }
    }
}
