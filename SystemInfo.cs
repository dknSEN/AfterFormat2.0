using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AfterFormat_2._0
{
    class SystemInfo
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);
        public static PerformanceCounter theCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        public static PerformanceCounter theRAMCounter = new PerformanceCounter("Memory", "Available MBytes");
        public static ManagementObjectSearcher myGPU = new ManagementObjectSearcher("select * from Win32_VideoController");
        public static ManagementObjectSearcher myCPU = new ManagementObjectSearcher("select * from Win32_Processor");
        public static ManagementObjectSearcher myOperatingSystem = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
        public static ManagementObjectSearcher mySystem = new ManagementObjectSearcher("select * from Win32_BIOS");
        public static ManagementObjectSearcher myBaseBoard = new ManagementObjectSearcher("select * from Win32_BaseBoard");
        public static ManagementObjectSearcher myBattery = new ManagementObjectSearcher("select * from Win32_Battery");
        public static ManagementObjectSearcher myTemp = new ManagementObjectSearcher("select * from Win32_TemperatureProbe");

        

    }
}
