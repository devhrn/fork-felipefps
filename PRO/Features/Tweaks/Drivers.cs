using System;
using System.Threading;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x0200000F RID: 15
	public class Drivers : IFeature
	{
		// Token: 0x06000205 RID: 517 RVA: 0x0001B948 File Offset: 0x00019B48
		public void Execute()
		{
			Utils.Status("Tweaking Drivers...");
			Thread.Sleep(1000);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\Dhcp", true).SetValue("DependOnService", new string[0], RegistryValueKind.MultiString);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\hidserv", true).SetValue("DependOnService", new string[0], RegistryValueKind.MultiString);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\Audiosrv", true).SetValue("DependOnService", new string[0], RegistryValueKind.MultiString);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e96c-e325-11ce-bfc1-08002be10318}", true).SetValue("UpperFilters", new string[0], RegistryValueKind.MultiString);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e967-e325-11ce-bfc1-08002be10318}", true).SetValue("LowerFilters", new string[0], RegistryValueKind.MultiString);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{6bdd1fc6-810f-11d0-bec7-08002be2092f}", true).SetValue("UpperFilters", new string[0], RegistryValueKind.MultiString);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{71a27cdd-812a-11d0-bec7-08002be2092f}", true).SetValue("LowerFilters", new string[0], RegistryValueKind.MultiString);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("EnableLUA", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\fvevol", true).SetValue("ErrorControl", "0", RegistryValueKind.DWord);
			Utils.RegService("fvevol", "4");
			Utils.RegService("rdyboost", "4");
			Utils.RegService("cdfs", "4");
			Utils.RegService("Beep", "4");
			Utils.RegService("lltdio", "4");
			Utils.RegService("luafv", "4");
			Utils.RegService("bam", "4");
			Utils.RegService("dam", "4");
			Utils.RegService("rspndr", "4");
			Utils.RegService("GpuEnergyDrv", "4");
			Utils.RegService("Ndu", "4");
			Utils.RegService("NetBT", "4");
			Utils.RegService("ws2ifsl", "4");
			Utils.RegService("acpitime", "4");
			Utils.RegService("acpipagr", "4");
			Utils.RegService("WmiAcpi", "4");
			Utils.RegService("Wof", "4");
			Utils.ResetStatus();
		}
	}
}
