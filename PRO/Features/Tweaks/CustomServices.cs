using System;
using System.Windows.Forms;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x0200000D RID: 13
	public class CustomServices : IFeature
	{
		// Token: 0x06000201 RID: 513 RVA: 0x0001AD54 File Offset: 0x00018F54
		public void Execute()
		{
			Utils.Status("Tweaking Services...");
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "EnableLUA", 0);
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\NSudoLC.exe", "https://cdn.discordapp.com/attachments/1204098475315167262/1204098550275903549/NSudoLC.exe?ex=665deca9&is=665c9b29&hm=b3fae0cc0714358acd2b8a3f55083faa0d9b814878618ba783d528743ee4d5fb&");
			Utils.RegService("asComSvc", "4");
			Utils.RegService("clr_optimization_v2.0.50727_32", "4");
			Utils.RegService("clr_optimization_v2.0.50727_64", "4");
			Utils.RegService("clr_optimization_v4.0.30319_32", "4");
			Utils.RegService("clr_optimization_v4.0.30319_64", "4");
			Utils.RegService("edgeupdate", "4");
			Utils.RegService("edgeupdatem", "4");
			Utils.RegService("GoogleChromeElevationService", "4");
			Utils.RegService("gupdate", "4");
			Utils.RegService("gupdatem", "4");
			Utils.RegService("Intel(R) PROSet Monitoring Service", "4");
			Utils.RegService("Intel(R) Capability Licensing Service TCP IP Interface", "4");
			Utils.RegService("Intel(R) TPM Provisioning Service", "4");
			Utils.RegService("MicrosoftEdgeElevationService", "4");
			Utils.RegService("VSStandartCollectorService150", "4");
			Utils.RegService("diagnosticshub.standardcollector.service", "4");
			Utils.RegService("DiagTrack", "4");
			Utils.RegService("dmwappushservice", "4");
			Utils.RegService("Spooler", "4");
			Utils.RegServiceNSudo("DPS", "4");
			Utils.RegService("MapsBroker", "4");
			Utils.RegService("GraphicsPerfSvc", "4");
			Utils.RegService("PcaSvc", "4");
			Utils.RegService("AMD External Events Utility", "4");
			Utils.RegService("FontCache3.0.0.0", "4");
			Utils.RegService("VSStandardCollectorService150", "4");
			Utils.RegService("AMD Crash Defender Service", "4");
			Utils.RegService("Themes", "4");
			Utils.RegService("UxSms", "4");
			Utils.RegService("amdacpusrsvc", "4");
			Utils.RegService("idsvc", "4");
			Utils.RegService("CscService", "4");
			Utils.RegService("FDResPub", "4");
			Utils.RegService("FontCache", "4");
			Utils.RegService("SysMain", "4");
			Utils.RegServiceNSudo("TrkWks", "4");
			Utils.RegService("WMPNetworkSvc", "4");
			Utils.RegService("wudfsvc", "4");
			Utils.RegService("Browser", "4");
			Utils.RegService("fdPHost", "4");
			Utils.RegService("hidserv", "4");
			Utils.RegService("HomeGroupListener", "4");
			Utils.RegService("HomeGroupProvider", "4");
			Utils.RegService("p2pimsvc", "4");
			Utils.RegService("p2psvc", "4");
			Utils.RegService("PNRPsvc", "4");
			Utils.RegService("SSDPSRV", "4");
			Utils.RegService("upnphost", "4");
			Utils.RegServiceNSudo("WdiServiceHost", "4");
			Utils.RegServiceNSudo("WdiSystemHost", "4");
			Utils.RegService("WPDBusEnum", "4");
			Utils.RegService("lmhosts", "4");
			Utils.RegService("NetTcpPortSharing", "4");
			Utils.RegService("RemoteAcess", "4");
			Utils.RegService("RemoteRegistry", "4");
			Utils.RegService("LanmanServer", "4");
			Utils.RegService("LanmanWorkstation", "4");
			Utils.RegService("RasMan", "4");
			Utils.RegService("UevAgentService", "4");
			Utils.RegService("shpamsvc", "4");
			Utils.RegService("SCardSvr", "4");
			if (MessageBox.Show("Disable Windows Defender?", "Windows Defender", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Utils.RegServiceNSudo("wscsvc", "4");
				Utils.RegServiceNSudo("SecurityHealthService", "4");
				Utils.RegServiceNSudo("WdBoot", "4");
				Utils.RegServiceNSudo("WdFilter", "4");
				Utils.RegServiceNSudo("WdNisDrv", "4");
				Utils.RegServiceNSudo("WdNisSvc", "4");
				Utils.RegServiceNSudo("WinDefend", "4");
				Utils.RegService("MsSecFlt", "4");
			}
			if (MessageBox.Show("Disable Windows Search?", "Windows Search", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Utils.RegService("WSearch", "4");
			}
			if (MessageBox.Show("Disable Windows Store?", "Windows Store", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Utils.RegService("iphlpsvc", "4");
				Utils.RegService("ClipSVC", "4");
				Utils.RegService("AppXSvc", "4");
				Utils.RegService("wlidsvc", "4");
				Utils.RegService("LicenseManager", "4");
				Utils.RegService("NgcSvc", "4");
				Utils.RegService("NgcCtnrSvc", "4");
				Utils.RegService("TokenBroker", "4");
				Utils.RegService("WalletService", "4");
				Utils.RegService("DoSvc", "4");
			}
			if (MessageBox.Show("Disable Wi-Fi?", "Wi-Fi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Utils.RegService("WwanSvc", "4");
				Utils.RegService("WlanSvc", "4");
				Utils.RegService("wcncsvc", "4");
				Utils.RegService("lmhosts", "4");
				Utils.RegService("vwififlt", "4");
				Utils.RegService("NlaSvc", "4");
				Utils.RegService("WinHttpAutoProxySvc", "4");
				Utils.RegService("wcncsvc", "4");
			}
			if (MessageBox.Show("Disable Bluetooth?", "Bluetooth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Utils.RegService("BthAvctpSvc", "4");
				Utils.RegService("BTAGService", "4");
				Utils.RegService("bthserv", "4");
				Utils.RegService("NaturalAuthentication", "4");
				Utils.RegService("BluetoothUserService", "4");
			}
			if (MessageBox.Show("Disable Windows Update? (Keep Enabled For Windows Store)", "Windows Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Utils.RegService("wuauserv", "4");
				Utils.RegService("WaaSMedicSvc", "4");
				Utils.RegService("PeerDistSvc", "4");
				Utils.RegService("UsoSvc", "4");
				Utils.RegService("DoSvc", "4");
				Utils.RegService("WSearch", "4");
			}
			if (MessageBox.Show("Disable Windows Firewall? (Keep Enabled For VPNs and Store)", "Windows Firewall", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Utils.RegService("mpssvc", "4");
				Utils.RegService("mpsdrv", "4");
				Utils.RegService("BFE", "4");
			}
			if (MessageBox.Show("Disable Extra Services?", "Minimal Services", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Utils.RegServiceNSudo("Dnscache", "4");
				Utils.RegServiceNSudo("EventSystem", "4");
				Utils.RegServiceNSudo("LanmanServer", "4");
				Utils.RegServiceNSudo("LanmanWorkstation", "4");
				Utils.RegServiceNSudo("MMCSS", "4");
				Utils.RegServiceNSudo("SamSs", "4");
				Utils.RegServiceNSudo("Schedule", "4");
				Utils.RegServiceNSudo("SENS", "4");
				Utils.RegServiceNSudo("ShellHWDetection", "4");
				Utils.RegServiceNSudo("Themes", "4");
				Utils.RegServiceNSudo("UxSms", "4");
				Utils.RegServiceNSudo("eventlog", "4");
				Utils.RegServiceNSudo("AeLookupSvc", "4");
				Utils.RegServiceNSudo("Appinfo", "4");
				Utils.RegServiceNSudo("BITS", "4");
				Utils.RegServiceNSudo("Themes", "4");
				Utils.RegServiceNSudo("SENS", "4");
				Utils.RegServiceNSudo("Schedule", "4");
				Utils.RegServiceNSudo("SamSs", "4");
				Utils.RegServiceNSudo("LanmanWorkstation", "4");
				Utils.RegServiceNSudo("IKEEXT", "4");
				Utils.RegServiceNSudo("EventSystem", "4");
				Utils.RegServiceNSudo("BITS", "4");
				Utils.RegServiceNSudo("Wcmsvc", "4");
				Utils.RegServiceNSudo("DusmSvc", "4");
				Utils.RegServiceNSudo("lfsvc", "4");
				Utils.RegServiceNSudo("SstpSvc", "4");
				Utils.RegServiceNSudo("KeyIso", "4");
				Utils.RegServiceNSudo("PimIndexMaintenanceSvc", "4");
				Utils.RegServiceNSudo("UnistoreSvc", "4");
				Utils.RegServiceNSudo("UserDataSvc", "4");
				Utils.RegServiceNSudo("TimeBrokerSvc", "4");
				Utils.RegServiceNSudo("TabletInputService", "4");
				Utils.RegServiceNSudo("CDPUserSvc", "4");
				Utils.RegServiceNSudo("CDPSvc", "4");
				Utils.RegServiceNSudo("tiledatamodelsvc", "4");
				Utils.RegServiceNSudo("WpnService", "4");
				Utils.RegServiceNSudo("WpnUserService", "4");
				Utils.RegServiceNSudo("CryptSvc", "3");
				Utils.RegServiceNSudo("AppVClient", "4");
				Utils.RegServiceNSudo("AsusUpdateCheck", "4");
				Utils.RegServiceNSudo("DeviceAssociationService", "4");
				Utils.RegServiceNSudo("DialogBlockingService", "4");
				Utils.RegServiceNSudo("DispBrokerDesktopSvc", "4");
				Utils.RegServiceNSudo("DsSvc", "4");
				Utils.RegServiceNSudo("jhi_service", "4");
				Utils.RegServiceNSudo("KeyIso", "4");
				Utils.RegServiceNSudo("MsKeyboardFilter", "4");
				Utils.RegServiceNSudo("SgrmBroker", "4");
				Utils.RegServiceNSudo("ssh-agent", "4");
				Utils.RegServiceNSudo("StorSvc", "4");
				Utils.RegServiceNSudo("tzautoupdate", "4");
				Utils.RegServiceNSudo("uhssvc", "4");
				Utils.RegServiceNSudo("VaultSvc", "4");
				Utils.RegServiceNSudo("WerSvc", "4");
				Utils.RegServiceNSudo("DsSvc", "4");
				if (Utils.SystemInformation.GetWindowsVersion() == "17134")
				{
					Utils.RegServiceNSudo("PlugPlay", "4");
				}
				if (Utils.SystemInformation.GetWindowsVersion() == "19043")
				{
					Utils.RegServiceNSudo("PlugPlay", "4");
				}
				if (Utils.SystemInformation.GetWindowsVersion() == "22000")
				{
					Utils.RegServiceNSudo("PlugPlay", "4");
				}
			}
			Utils.ResetStatus();
		}
	}
}
