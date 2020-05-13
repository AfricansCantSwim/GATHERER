using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Management;

namespace GatherEr
{
    public class Internet
    {
        public static string IPAddress()
        {
            WebClient wc = new WebClient();//create a new webclient so that i can use it later :P
            
            string ipaddress = wc.DownloadString("https://api.ipify.org/");//initate a GET request to the site 
            return ipaddress;//return IPaddress

        }
    }

    public class hardware
    {
    }
    public class user
    {
    }
    public class machine
    {
        public static string Proccessor()
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }
        public static string Harddrive()
        {
            ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
            dsk.Get();
            string id = dsk["VolumeSerialNumber"].ToString();
            return id;
        }
        public static string Motherboard()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            string serial = "";
            foreach (ManagementObject mo in moc)
            {
                serial = (string)mo["SerialNumber"];
            }
            return serial;
        }
        public static string OS()
        {
            string OS = Environment.OSVersion.ToString();
            return OS;
        }
        public static string MachineName()
        {
            string MachineName = Environment.MachineName;
            return MachineName;
        }
    }
    public class sentry
    {

    }
}
