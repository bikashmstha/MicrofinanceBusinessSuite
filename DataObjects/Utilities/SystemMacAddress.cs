using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using BusinessObjects.BusinessRules;
using System.Web;


using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Linq;


namespace DataObjects.Utilities
{
    public class SystemMacAddress
    {

        public static string GetMACAddress()
        {
            string macAddresses = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += String.Join(":", nic.GetPhysicalAddress()
                                     .GetAddressBytes()
                                     .Select(b => b.ToString("X2"))
                                     .ToArray());

                    break;
                }
            }
            return macAddresses;
        }

        public static string GetMACAddressWithDash()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += String.Join("-", nic.GetPhysicalAddress()
                                     .GetAddressBytes()
                                     .Select(b => b.ToString("X2"))
                                     .ToArray());

                    break;
                }
            }

            return macAddresses;
        }

        public static string GetMACAddressWithSixteenByte()
        {
            String sMacAddress = "";
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
          
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == "")
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

    }
}
