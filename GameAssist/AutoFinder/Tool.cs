/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/7/7
 * Time: 22:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Microsoft.Win32;
using System.Management;

namespace AutoFinder
{
	/// <summary>
	/// Description of Tool.
	/// </summary>
	public class Tool
	{
		public Tool()
		{
		}
		
		public string GetCpuID()
		{
			string[] strArray = new string[10];
			ManagementObjectCollection instances = new ManagementClass("Win32_Processor").GetInstances();
			int num = 0;
			foreach (ManagementObject obj2 in instances)
			{
				strArray[num++] = obj2["ProcessorId"].ToString();
			}
			return strArray[0];
		}

		public string GetDriveID()
		{
			string[] strArray = new string[10];
			ManagementObjectCollection instances = new ManagementClass("Win32_DiskDrive").GetInstances();
			int num = 0;
			foreach (ManagementObject obj2 in instances)
			{
				strArray[num++] = obj2["Model"].ToString();
			}
			return strArray[0];
		}

		public string GetMacID()
		{
			string[] strArray = new string[10];
			try
			{
				ManagementObjectCollection instances = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
				int num = 0;
				foreach (ManagementObject obj2 in instances)
				{
					if ((bool) obj2["IPEnabled"])
					{
						strArray[num++] = obj2["MacAddress"].ToString();
					}
				}
			}
			catch(Exception e)
			{
				
			}
			return strArray[0];
		}
	}
}
