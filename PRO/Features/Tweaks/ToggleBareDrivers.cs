using System;
using System.Diagnostics;
using System.Drawing;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x0200001F RID: 31
	public class ToggleBareDrivers : IFeature
	{
		// Token: 0x0600022B RID: 555 RVA: 0x00024CA4 File Offset: 0x00022EA4
		public void Execute()
		{
			Utils.Status("Tweaking Bare Drivers...");
			if (ToggleBareDrivers.Settings.GetValue("BareDrivers") != null)
			{
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e96c-e325-11ce-bfc1-08002be10318}", true).SetValue("UpperFilters", new string[]
				{
					"ksthunk"
				}, RegistryValueKind.MultiString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e967-e325-11ce-bfc1-08002be10318}", true).SetValue("LowerFilters", new string[]
				{
					"EhStorClass"
				}, RegistryValueKind.MultiString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{6bdd1fc6-810f-11d0-bec7-08002be2092f}", true).SetValue("UpperFilters", new string[]
				{
					"ksthunk"
				}, RegistryValueKind.MultiString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{71a27cdd-812a-11d0-bec7-08002be2092f}", true).SetValue("LowerFilters", new string[]
				{
					"fvevol",
					"iorate",
					"rdyboost"
				}, RegistryValueKind.MultiString);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("EnableLUA", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\fvevol", true).SetValue("ErrorControl", "3", RegistryValueKind.DWord);
				Utils.RegService("fvevol", "0");
				Utils.RegService("rdyboost", "0");
				Utils.RegService("cdfs", "4");
				Utils.RegService("Beep", "1");
				Utils.RegService("lltdio", "2");
				Utils.RegService("luafv", "2");
				Utils.RegService("bam", "1");
				Utils.RegService("dam", "1");
				Utils.RegService("rspndr", "2");
				Utils.RegService("GpuEnergyDrv", "1");
				Utils.RegService("Ndu", "2");
				Utils.RegService("NetBT", "1");
				Utils.RegService("ws2ifsl", "4");
				Utils.RegService("acpitime", "3");
				Utils.RegService("acpipagr", "3");
				Utils.RegService("WmiAcpi", "3");
				Utils.RegService("Wof", "0");
				ToggleBareDrivers.Settings.DeleteValue("BareDrivers", false);
				if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1)
				{
					Utils.RegServiceNSudo("mssmbios", "1");
					Utils.RegServiceNSudo("msisadrv", "0");
					Utils.RegServiceNSudo("AcpiPmi", "3");
					Utils.RegServiceNSudo("Beep", "1");
					Utils.RegServiceNSudo("blbdrive", "1");
					Utils.RegServiceNSudo("bowser", "3");
					Utils.RegServiceNSudo("CLFS", "0");
					Utils.RegServiceNSudo("CompositeBus", "3");
					Utils.RegServiceNSudo("CSC", "1");
					Utils.RegServiceNSudo("dfsc", "1");
					Utils.RegServiceNSudo("discache", "1");
					Utils.RegServiceNSudo("fastfat", "3");
					Utils.RegServiceNSudo("FileInfo", "0");
					Utils.RegServiceNSudo("fvevol", "0");
					Utils.RegServiceNSudo("KSecPkg", "0");
					Utils.RegServiceNSudo("ksthunk", "3");
					Utils.RegServiceNSudo("lltdio", "2");
					Utils.RegServiceNSudo("luafv", "2");
					Utils.RegServiceNSudo("Modem", "3");
					Utils.RegServiceNSudo("Mpsdrv", "3");
					Utils.RegServiceNSudo("Mrxsmb10", "3");
					Utils.RegServiceNSudo("Mrxsmb20", "3");
					Utils.RegServiceNSudo("mrxsmb", "3");
					Utils.RegServiceNSudo("NdisTapi", "3");
					Utils.RegServiceNSudo("NdisWan", "3");
					Utils.RegServiceNSudo("Ndproxy", "3");
					Utils.RegServiceNSudo("NetBIOS", "3");
					Utils.RegServiceNSudo("NetBT", "3");
					Utils.RegServiceNSudo("Null", "1");
					Utils.RegServiceNSudo("PEAUTH", "2");
					Utils.RegServiceNSudo("PptpMiniport", "3");
					Utils.RegServiceNSudo("Psched", "1");
					Utils.RegServiceNSudo("RasAgileVpn", "3");
					Utils.RegServiceNSudo("Rasl2tp", "3");
					Utils.RegServiceNSudo("RasPppoe", "3");
					Utils.RegServiceNSudo("RasSstp", "3");
					Utils.RegServiceNSudo("rdbss", "1");
					Utils.RegServiceNSudo("Rdpbus", "3");
					Utils.RegServiceNSudo("rdyboost", "0");
					Utils.RegServiceNSudo("rspndr", "2");
					Utils.RegServiceNSudo("spldr", "0");
					Utils.RegServiceNSudo("srv2", "3");
					Utils.RegServiceNSudo("Srvnet", "3");
					Utils.RegServiceNSudo("tcpipreg", "2");
					Utils.RegServiceNSudo("tdx", "1");
					Utils.RegServiceNSudo("TermDD", "1");
					Utils.RegServiceNSudo("UMBus", "3");
					Utils.RegServiceNSudo("vdrvroot", "0");
					Utils.RegServiceNSudo("VgaSave", "1");
					Utils.RegServiceNSudo("Volmgrx", "0");
					Utils.RegServiceNSudo("Wanarp", "3");
					Utils.RegServiceNSudo("Wanarpv6", "1");
					Utils.RegServiceNSudo("WmiAcpi", "3");
				}
				if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 3)
				{
					Utils.RegServiceNSudo("mssmbios", "1");
					Utils.RegServiceNSudo("msisadrv", "0");
					Utils.RegServiceNSudo("acpipagr", "3");
					Utils.RegServiceNSudo("AcpiPmi", "3");
					Utils.RegServiceNSudo("Acpitime", "3");
					Utils.RegServiceNSudo("ahcache", "1");
					Utils.RegServiceNSudo("Beep", "1");
					Utils.RegServiceNSudo("bowser", "3");
					Utils.RegServiceNSudo("cdrom", "1");
					Utils.RegServiceNSudo("CLFS", "0");
					Utils.RegServiceNSudo("CompositeBus", "3");
					Utils.RegServiceNSudo("condrv", "3");
					Utils.RegServiceNSudo("CSC", "1");
					Utils.RegServiceNSudo("dam", "1");
					Utils.RegServiceNSudo("dfsc", "1");
					Utils.RegServiceNSudo("EhStorClass", "0");
					Utils.RegServiceNSudo("fastfat", "3");
					Utils.RegServiceNSudo("FileInfo", "0");
					Utils.RegServiceNSudo("fvevol", "0");
					Utils.RegServiceNSudo("Kdnic", "3");
					Utils.RegServiceNSudo("KSecPkg", "0");
					Utils.RegServiceNSudo("ksthunk", "3");
					Utils.RegServiceNSudo("lltdio", "2");
					Utils.RegServiceNSudo("luafv", "2");
					Utils.RegServiceNSudo("Modem", "3");
					Utils.RegServiceNSudo("Mrxsmb10", "2");
					Utils.RegServiceNSudo("Mrxsmb20", "3");
					Utils.RegServiceNSudo("mrxsmb", "3");
					Utils.RegServiceNSudo("NdisCap", "3");
					Utils.RegServiceNSudo("NdisTapi", "3");
					Utils.RegServiceNSudo("NdisVirtualBus", "3");
					Utils.RegServiceNSudo("NdisWan", "3");
					Utils.RegServiceNSudo("Ndproxy", "3");
					Utils.RegServiceNSudo("ndu", "2");
					Utils.RegServiceNSudo("NetBIOS", "1");
					Utils.RegServiceNSudo("NetBT", "1");
					Utils.RegServiceNSudo("Npsvctrig", "1");
					Utils.RegServiceNSudo("Null", "1");
					Utils.RegServiceNSudo("PEAUTH", "2");
					Utils.RegServiceNSudo("Psched", "1");
					Utils.RegServiceNSudo("QWAVEdrv", "3");
					Utils.RegServiceNSudo("RasAcd", "3");
					Utils.RegServiceNSudo("RasPppoe", "3");
					Utils.RegServiceNSudo("rdbss", "1");
					Utils.RegServiceNSudo("Rdpbus", "3");
					Utils.RegServiceNSudo("rdyboost", "0");
					Utils.RegServiceNSudo("rspndr", "2");
					Utils.RegServiceNSudo("Secdrv", "2");
					Utils.RegServiceNSudo("Spaceport", "0");
					Utils.RegServiceNSudo("srv2", "3");
					Utils.RegServiceNSudo("Srvnet", "3");
					Utils.RegServiceNSudo("Tcpip6", "3");
					Utils.RegServiceNSudo("tcpipreg", "2");
					Utils.RegServiceNSudo("tdx", "1");
					Utils.RegServiceNSudo("TPM", "3");
					Utils.RegServiceNSudo("tunnel", "3");
					Utils.RegServiceNSudo("UMBus", "3");
					Utils.RegServiceNSudo("vdrvroot", "0");
					Utils.RegServiceNSudo("VerifierExt", "3");
					Utils.RegServiceNSudo("Vid", "3");
					Utils.RegServiceNSudo("Volmgrx", "0");
					Utils.RegServiceNSudo("WmiAcpi", "3");
				}
				if (Environment.OSVersion.Version.Major == 10)
				{
					Utils.RegService("mssmbios", "1");
					Utils.RegService("msisadrv", "0");
					Utils.RegService("AcpiDev", "3");
					Utils.RegService("acpiex", "0");
					Utils.RegService("acpipagr", "3");
					Utils.RegService("AcpiPmi", "3");
					Utils.RegService("Acpitime", "3");
					Utils.RegService("afunix", "1");
					Utils.RegService("bam", "1");
					Utils.RegService("Beep", "1");
					Utils.RegService("bindflt", "2");
					Utils.RegService("bowser", "3");
					Utils.RegService("CAD", "3");
					Utils.RegService("cdrom", "1");
					Utils.RegService("CimFS", "1");
					Utils.RegService("CldFlt", "2");
					Utils.RegServiceNSudo("CLFS", "0");
					Utils.RegService("CompositeBus", "3");
					Utils.RegService("condrv", "3");
					Utils.RegService("CSC", "1");
					Utils.RegService("dam", "1");
					Utils.RegService("dfsc", "1");
					Utils.RegService("EhStorClass", "0");
					Utils.RegService("fastfat", "3");
					Utils.RegService("FileCrypt", "1");
					Utils.RegService("FileInfo", "0");
					Utils.RegService("fvevol", "0");
					Utils.RegService("GpuEnergyDrv", "1");
					Utils.RegService("iorate", "0");
					Utils.RegService("kdnic", "3");
					Utils.RegService("KSecPkg", "0");
					Utils.RegService("ksthunk", "3");
					Utils.RegService("lltdio", "2");
					Utils.RegService("luafv", "2");
					Utils.RegService("Modem", "3");
					Utils.RegService("Mrxsmb20", "3");
					Utils.RegService("mrxsmb", "3");
					Utils.RegService("MsLldp", "2");
					Utils.RegService("MsQuic", "3");
					Utils.RegService("MsSecFlt", "0");
					Utils.RegService("NdisCap", "1");
					Utils.RegService("NdisVirtualBus", "3");
					Utils.RegService("Ndu", "2");
					Utils.RegService("NetBIOS", "1");
					Utils.RegService("NetBT", "1");
					Utils.RegService("npsvctrig", "1");
					Utils.RegService("PEAUTH", "2");
					Utils.RegService("Psched", "1");
					Utils.RegService("rdbss", "1");
					Utils.RegService("rdpbus", "3");
					Utils.RegService("rdyboost", "0");
					Utils.RegService("rspndr", "2");
					Utils.RegService("spaceport", "0");
					Utils.RegService("srv2", "3");
					Utils.RegService("srvnet", "3");
					Utils.RegService("tcpipreg", "2");
					Utils.RegService("tdx", "1");
					Utils.RegService("Telemetry", "0");
					Utils.RegService("umbus", "3");
					Utils.RegService("vdrvroot", "0");
					Utils.RegService("Vid", "1");
					Utils.RegService("Volmgrx", "0");
					Utils.RegService("volsnap", "0");
					Utils.RegService("Wcifs", "2");
					Utils.RegService("WindowsTrustedRTProxy", "0");
					Utils.RegService("WindowsTrustedRT", "0");
					Utils.RegService("WmiAcpi", "3");
				}
				MainForm.Main.button8.BackColor = Color.FromArgb(5, 8, 10);
			}
			else
			{
				if (Utils.SystemInformation.SystemType.ToString() == "1")
				{
					Utils.RegServiceNSudo("msisadrv", "4");
				}
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("EnableLUA", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\fvevol", true).SetValue("ErrorControl", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\Dhcp", true).SetValue("DependOnService", new string[0], RegistryValueKind.MultiString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\hidserv", true).SetValue("DependOnService", new string[0], RegistryValueKind.MultiString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\Audiosrv", true).SetValue("DependOnService", new string[0], RegistryValueKind.MultiString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e96c-e325-11ce-bfc1-08002be10318}", true).SetValue("UpperFilters", new string[0], RegistryValueKind.MultiString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e967-e325-11ce-bfc1-08002be10318}", true).SetValue("LowerFilters", new string[0], RegistryValueKind.MultiString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{6bdd1fc6-810f-11d0-bec7-08002be2092f}", true).SetValue("UpperFilters", new string[0], RegistryValueKind.MultiString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{71a27cdd-812a-11d0-bec7-08002be2092f}", true).SetValue("LowerFilters", new string[0], RegistryValueKind.MultiString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{71a27cdd-812a-11d0-bec7-08002be2092f}", true).SetValue("UpperFilters", new string[0], RegistryValueKind.MultiString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{ca3e7ab9-b4c3-4ae6-8251-579ef933890f}", true).SetValue("UpperFilters", new string[0], RegistryValueKind.MultiString);
				if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1)
				{
					Utils.RegServiceNSudo("AcpiPmi", "4");
					Utils.RegServiceNSudo("Beep", "4");
					Utils.RegServiceNSudo("blbdrive", "4");
					Utils.RegServiceNSudo("bowser", "4");
					Utils.RegServiceNSudo("CAD", "4");
					Utils.RegServiceNSudo("cdfs", "4");
					Utils.RegServiceNSudo("CLFS", "4");
					Utils.RegServiceNSudo("CompositeBus", "4");
					Utils.RegServiceNSudo("CSC", "4");
					Utils.RegServiceNSudo("dfsc", "4");
					Utils.RegServiceNSudo("discache", "4");
					Utils.RegServiceNSudo("fastfat", "4");
					Utils.RegServiceNSudo("FileInfo", "4");
					Utils.RegServiceNSudo("fvevol", "4");
					Utils.RegServiceNSudo("KSecPkg", "4");
					Utils.RegServiceNSudo("ksthunk", "4");
					Utils.RegServiceNSudo("lltdio", "4");
					Utils.RegServiceNSudo("luafv", "4");
					Utils.RegServiceNSudo("Modem", "4");
					Utils.RegServiceNSudo("Mpsdrv", "4");
					Utils.RegServiceNSudo("Mrxsmb10", "4");
					Utils.RegServiceNSudo("Mrxsmb20", "4");
					Utils.RegServiceNSudo("mrxsmb", "4");
					Utils.RegServiceNSudo("NdisTapi", "4");
					Utils.RegServiceNSudo("NdisWan", "4");
					Utils.RegServiceNSudo("Ndproxy", "4");
					Utils.RegServiceNSudo("ndu", "4");
					Utils.RegServiceNSudo("NetBIOS", "4");
					Utils.RegServiceNSudo("NetBT", "4");
					Utils.RegServiceNSudo("Null", "4");
					Utils.RegServiceNSudo("PEAUTH", "4");
					Utils.RegServiceNSudo("PptpMiniport", "4");
					Utils.RegServiceNSudo("Psched", "4");
					Utils.RegServiceNSudo("RasAgileVpn", "4");
					Utils.RegServiceNSudo("Rasl2tp", "4");
					Utils.RegServiceNSudo("RasPppoe", "4");
					Utils.RegServiceNSudo("RasSstp", "4");
					Utils.RegServiceNSudo("rdbss", "4");
					Utils.RegServiceNSudo("Rdpbus", "4");
					Utils.RegServiceNSudo("rdyboost", "4");
					Utils.RegServiceNSudo("rspndr", "4");
					Utils.RegServiceNSudo("Secdrv", "4");
					Utils.RegServiceNSudo("spldr", "4");
					Utils.RegServiceNSudo("srv2", "4");
					Utils.RegServiceNSudo("Srvnet", "4");
					Utils.RegServiceNSudo("tcpipreg", "4");
					Utils.RegServiceNSudo("tdx", "4");
					Utils.RegServiceNSudo("TermDD", "4");
					Utils.RegServiceNSudo("udfs", "4");
					Utils.RegServiceNSudo("UMBus", "4");
					Utils.RegServiceNSudo("vdrvroot", "4");
					Utils.RegServiceNSudo("Volmgrx", "4");
					Utils.RegServiceNSudo("Wanarp", "4");
					Utils.RegServiceNSudo("Wanarpv6", "4");
					Utils.RegServiceNSudo("WindowsTrustedRTProxy", "4");
					Utils.RegServiceNSudo("WindowsTrustedRT", "4");
					Utils.RegServiceNSudo("WmiAcpi", "4");
					Utils.RegServiceNSudo("ws2ifsl", "4");
				}
				if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 3)
				{
					Utils.RegServiceNSudo("acpipagr", "4");
					Utils.RegServiceNSudo("AcpiPmi", "4");
					Utils.RegServiceNSudo("Acpitime", "4");
					Utils.RegServiceNSudo("afunix", "4");
					Utils.RegServiceNSudo("ahcache", "4");
					Utils.RegServiceNSudo("bam", "4");
					Utils.RegServiceNSudo("Beep", "4");
					Utils.RegServiceNSudo("bowser", "4");
					Utils.RegServiceNSudo("cdfs", "4");
					Utils.RegServiceNSudo("cdrom", "4");
					Utils.RegServiceNSudo("CLFS", "4");
					Utils.RegServiceNSudo("CompositeBus", "4");
					Utils.RegServiceNSudo("condrv", "4");
					Utils.RegServiceNSudo("CSC", "4");
					Utils.RegServiceNSudo("dam", "4");
					Utils.RegServiceNSudo("dfsc", "4");
					Utils.RegServiceNSudo("EhStorClass", "4");
					Utils.RegServiceNSudo("fastfat", "4");
					Utils.RegServiceNSudo("FileInfo", "4");
					Utils.RegServiceNSudo("fvevol", "4");
					Utils.RegServiceNSudo("iorate", "4");
					Utils.RegServiceNSudo("Kdnic", "4");
					Utils.RegServiceNSudo("KSecPkg", "4");
					Utils.RegServiceNSudo("ksthunk", "4");
					Utils.RegServiceNSudo("lltdio", "4");
					Utils.RegServiceNSudo("luafv", "4");
					Utils.RegServiceNSudo("Modem", "4");
					Utils.RegServiceNSudo("Mrxsmb10", "4");
					Utils.RegServiceNSudo("Mrxsmb20", "4");
					Utils.RegServiceNSudo("mrxsmb", "4");
					Utils.RegServiceNSudo("MsLldp", "4");
					Utils.RegServiceNSudo("NdisCap", "4");
					Utils.RegServiceNSudo("NdisTapi", "4");
					Utils.RegServiceNSudo("NdisVirtualBus", "4");
					Utils.RegServiceNSudo("NdisWan", "4");
					Utils.RegServiceNSudo("Ndproxy", "4");
					Utils.RegServiceNSudo("ndu", "4");
					Utils.RegServiceNSudo("NetBIOS", "4");
					Utils.RegServiceNSudo("NetBT", "4");
					Utils.RegServiceNSudo("Npsvctrig", "4");
					Utils.RegServiceNSudo("Null", "4");
					Utils.RegServiceNSudo("PEAUTH", "4");
					Utils.RegServiceNSudo("Psched", "4");
					Utils.RegServiceNSudo("QWAVEdrv", "4");
					Utils.RegServiceNSudo("RasAcd", "4");
					Utils.RegServiceNSudo("RasPppoe", "4");
					Utils.RegServiceNSudo("rdbss", "4");
					Utils.RegServiceNSudo("Rdpbus", "4");
					Utils.RegServiceNSudo("rdyboost", "4");
					Utils.RegServiceNSudo("rspndr", "4");
					Utils.RegServiceNSudo("Secdrv", "4");
					Utils.RegServiceNSudo("Spaceport", "4");
					Utils.RegServiceNSudo("srv2", "4");
					Utils.RegServiceNSudo("Srvnet", "4");
					Utils.RegServiceNSudo("Tcpip6", "4");
					Utils.RegServiceNSudo("tcpipreg", "4");
					Utils.RegServiceNSudo("tdx", "4");
					Utils.RegServiceNSudo("TPM", "4");
					Utils.RegServiceNSudo("tunnel", "4");
					Utils.RegServiceNSudo("udfs", "4");
					Utils.RegServiceNSudo("UMBus", "4");
					Utils.RegServiceNSudo("vdrvroot", "4");
					Utils.RegServiceNSudo("VerifierExt", "4");
					Utils.RegServiceNSudo("Vid", "4");
					Utils.RegServiceNSudo("Volmgrx", "4");
					Utils.RegServiceNSudo("WmiAcpi", "4");
					Utils.RegServiceNSudo("ws2ifsl", "4");
				}
				if (Environment.OSVersion.Version.Major == 10)
				{
					Utils.RegService("AcpiDev", "4");
					Utils.RegService("acpiex", "4");
					Utils.RegService("acpipagr", "4");
					Utils.RegService("AcpiPmi", "4");
					Utils.RegService("Acpitime", "4");
					Utils.RegService("afunix", "4");
					Utils.RegService("bam", "4");
					Utils.RegService("Beep", "4");
					Utils.RegService("bindflt", "4");
					Utils.RegService("bowser", "4");
					Utils.RegService("CAD", "4");
					Utils.RegService("cdfs", "4");
					Utils.RegService("cdrom", "4");
					Utils.RegService("CimFS", "4");
					Utils.RegService("CldFlt", "4");
					Utils.RegServiceNSudo("CLFS", "4");
					Utils.RegService("cnghwassist", "4");
					Utils.RegService("CompositeBus", "4");
					Utils.RegService("condrv", "4");
					Utils.RegService("CSC", "4");
					Utils.RegService("dam", "4");
					Utils.RegService("Dfsc", "4");
					Utils.RegService("dfsc", "4");
					Utils.RegService("EhStorClass", "4");
					Utils.RegService("fastfat", "4");
					Utils.RegService("FileCrypt", "4");
					Utils.RegService("FileInfo", "4");
					Utils.RegService("fvevol", "4");
					Utils.RegService("GpuEnergyDrv", "4");
					Utils.RegService("iorate", "4");
					Utils.RegService("kdnic", "4");
					Utils.RegService("KSecPkg", "4");
					Utils.RegService("ksthunk", "4");
					Utils.RegService("LanmanServer", "4");
					Utils.RegService("lltdio", "4");
					Utils.RegService("luafv", "4");
					Utils.RegService("MEIx64", "4");
					Utils.RegService("Modem", "4");
					Utils.RegService("mrxsmb", "4");
					Utils.RegService("Mrxsmb10", "4");
					Utils.RegService("Mrxsmb20", "4");
					Utils.RegService("MsLldp", "4");
					Utils.RegService("MsQuic", "4");
					Utils.RegService("MsSecFlt", "4");
					Utils.RegService("NdisCap", "4");
					Utils.RegService("Ndisuio", "4");
					Utils.RegService("NdisVirtualBus", "4");
					Utils.RegService("Ndu", "4");
					Utils.RegService("NetBIOS", "4");
					Utils.RegService("NetBT", "4");
					Utils.RegService("npsvctrig", "4");
					Utils.RegService("PEAUTH", "4");
					Utils.RegService("Psched", "4");
					Utils.RegService("rdbss", "4");
					Utils.RegService("rdpbus", "4");
					Utils.RegService("rdyboost", "4");
					Utils.RegService("rspndr", "4");
					Utils.RegService("secdrv", "4");
					Utils.RegServiceNSudo("Sense", "4");
					Utils.RegService("SgrmAgent", "4");
					Utils.RegService("spaceport", "4");
					Utils.RegService("srv2", "4");
					Utils.RegService("srvnet", "4");
					Utils.RegService("tcpipreg", "4");
					Utils.RegService("tdx", "4");
					Utils.RegService("Telemetry", "4");
					Utils.RegService("udfs", "4");
					Utils.RegService("umbus", "4");
					Utils.RegService("vdrvroot", "4");
					Utils.RegService("Vid", "4");
					Utils.RegService("Volmgrx", "4");
					Utils.RegService("volsnap", "4");
					Utils.RegService("Wcifs", "4");
					Utils.RegService("WdBoot", "4");
					Utils.RegService("WdFilter", "4");
					Utils.RegService("WdNisDrv", "4");
					Utils.RegServiceNSudo("WdNisSvc", "4");
					Utils.RegServiceNSudo("WinDefend", "4");
					Utils.RegService("WindowsTrustedRT", "4");
					Utils.RegService("WindowsTrustedRTProxy", "4");
					Utils.RegService("WmiAcpi", "4");
					Utils.RegService("Wof", "4");
					Utils.RegService("ws2ifsl", "4");
				}
				ToggleBareDrivers.Settings.SetValue("BareDrivers", "1", RegistryValueKind.DWord);
				MainForm.Main.button8.BackColor = Color.FromArgb(5, 88, 10);
				if (Environment.OSVersion.Version.Major == 10)
				{
					Process.Start("ms-settings:yourinfo");
				}
			}
			Utils.ResetStatus();
		}

		// Token: 0x040000EA RID: 234
		public static RegistryKey Settings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Felipe", true);
	}
}
