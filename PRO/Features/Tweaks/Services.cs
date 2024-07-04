﻿using System;
using System.Threading;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x0200001C RID: 28
	public class Services : IFeature
	{
		// Token: 0x06000223 RID: 547 RVA: 0x000222B4 File Offset: 0x000204B4
		public void Execute()
		{
			Utils.Status("Tweaking Services...");
			Thread.Sleep(400);
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\NSudoLC.exe", "https://cdn.discordapp.com/attachments/1258236120354000896/1258238388436336660/NSudoLC.exe?ex=66875150&is=6685ffd0&hm=5bcd0730110a96d5836e1e4e2db9675915131d69202e894a0286cffd2075f605&");
			Utils.RegService("amdacpusrsvc", "4");
			Utils.RegService("AMD Crash Defender Service", "4");
			Utils.RegService("AMD External Events Utility", "4");
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
			Utils.RegService("Intel(R) Capability Licensing Service TCP IP Interface", "4");
			Utils.RegService("Intel(R) PROSet Monitoring Service", "4");
			Utils.RegService("Intel(R) TPM Provisioning Service", "4");
			Utils.RegService("MicrosoftEdgeElevationService", "4");
			Utils.RegService("VSStandartCollectorService150", "4");
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "EnableLUA", 0);
			if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1)
			{
				Utils.RegServiceNSudo("AeLookupSvc", "3");
				Utils.RegServiceNSudo("ALG", "4");
				Utils.RegServiceNSudo("AppIDSvc", "4");
				Utils.RegServiceNSudo("Appinfo", "3");
				Utils.RegServiceNSudo("AppMgmt", "4");
				Utils.RegServiceNSudo("aspnet_state", "4");
				Utils.RegServiceNSudo("AudioEndpointBuilder", "2");
				Utils.RegServiceNSudo("AudioSrv", "2");
				Utils.RegServiceNSudo("AxInstSV", "4");
				Utils.RegServiceNSudo("BDESVC", "4");
				Utils.RegServiceNSudo("BFE", "2");
				Utils.RegServiceNSudo("BITS", "4");
				Utils.RegServiceNSudo("Browser", "4");
				Utils.RegServiceNSudo("bthserv", "4");
				Utils.RegServiceNSudo("CertPropSvc", "4");
				Utils.RegServiceNSudo("COMSysApp", "3");
				Utils.RegServiceNSudo("CryptSvc", "2");
				Utils.RegServiceNSudo("CscService", "4");
				Utils.RegServiceNSudo("DcomLaunch", "2");
				Utils.RegServiceNSudo("defragsvc", "3");
				Utils.RegServiceNSudo("Dhcp", "2");
				Utils.RegServiceNSudo("DiagTrack", "4");
				Utils.RegServiceNSudo("Dnscache", "2");
				Utils.RegServiceNSudo("dot3svc", "4");
				Utils.RegServiceNSudo("DPS", "4");
				Utils.RegServiceNSudo("EapHost", "4");
				Utils.RegServiceNSudo("EFS", "4");
				Utils.RegServiceNSudo("ehRecvr", "4");
				Utils.RegServiceNSudo("ehSched", "4");
				Utils.RegServiceNSudo("eventlog", "2");
				Utils.RegServiceNSudo("EventSystem", "2");
				Utils.RegServiceNSudo("Fax", "4");
				Utils.RegServiceNSudo("fdPHost", "4");
				Utils.RegServiceNSudo("FDResPub", "4");
				Utils.RegServiceNSudo("FontCache3.0.0.0", "3");
				Utils.RegServiceNSudo("FontCache", "4");
				Utils.RegServiceNSudo("gpsvc", "2");
				Utils.RegServiceNSudo("hidserv", "3");
				Utils.RegServiceNSudo("hkmsvc", "4");
				Utils.RegServiceNSudo("HomeGroupProvider", "4");
				Utils.RegServiceNSudo("idsvc", "4");
				Utils.RegServiceNSudo("IEEtwCollectorService", "4");
				Utils.RegServiceNSudo("IKEEXT", "4");
				Utils.RegServiceNSudo("IPBusEnum", "3");
				Utils.RegServiceNSudo("iphlpsvc", "4");
				Utils.RegServiceNSudo("KeyIso", "3");
				Utils.RegServiceNSudo("KtmRm", "4");
				Utils.RegServiceNSudo("LanmanServer", "4");
				Utils.RegServiceNSudo("LanmanWorkstation", "4");
				Utils.RegServiceNSudo("lltdsvc", "4");
				Utils.RegServiceNSudo("lmhosts", "4");
				Utils.RegServiceNSudo("Mcx2Svc", "4");
				Utils.RegServiceNSudo("MMCSS", "2");
				Utils.RegServiceNSudo("MpsSvc", "4");
				Utils.RegServiceNSudo("MSDTC", "4");
				Utils.RegServiceNSudo("MSiSCSI", "4");
				Utils.RegServiceNSudo("msiserver", "3");
				Utils.RegServiceNSudo("napagent", "4");
				Utils.RegServiceNSudo("Netlogon", "4");
				Utils.RegServiceNSudo("Netman", "3");
				Utils.RegServiceNSudo("NetMsmqActivator", "4");
				Utils.RegServiceNSudo("NetPipeActivator", "4");
				Utils.RegServiceNSudo("netprofm", "3");
				Utils.RegServiceNSudo("NetTcpActivator", "4");
				Utils.RegServiceNSudo("NetTcpPortSharing", "4");
				Utils.RegServiceNSudo("NlaSvc", "2");
				Utils.RegServiceNSudo("nsi", "2");
				Utils.RegServiceNSudo("p2pimsvc", "4");
				Utils.RegServiceNSudo("p2psvc", "4");
				Utils.RegServiceNSudo("PcaSvc", "2");
				Utils.RegServiceNSudo("PeerDistSvc", "3");
				Utils.RegServiceNSudo("PerfHost", "3");
				Utils.RegServiceNSudo("pla", "4");
				Utils.RegServiceNSudo("PlugPlay", "2");
				Utils.RegServiceNSudo("PNRPAutoReg", "4");
				Utils.RegServiceNSudo("PNRPsvc", "4");
				Utils.RegServiceNSudo("PolicyAgent", "4");
				Utils.RegServiceNSudo("Power", "2");
				Utils.RegServiceNSudo("ProfSvc", "2");
				Utils.RegServiceNSudo("ProtectedStorage", "3");
				Utils.RegServiceNSudo("QWAVE", "3");
				Utils.RegServiceNSudo("RasAuto", "4");
				Utils.RegServiceNSudo("RasMan", "4");
				Utils.RegServiceNSudo("RemoteAccess", "4");
				Utils.RegServiceNSudo("RemoteRegistry", "4");
				Utils.RegServiceNSudo("RpcEptMapper", "2");
				Utils.RegServiceNSudo("RpcLocator", "4");
				Utils.RegServiceNSudo("RpcSs", "2");
				Utils.RegServiceNSudo("SamSs", "2");
				Utils.RegServiceNSudo("SCardSvr", "4");
				Utils.RegServiceNSudo("Schedule", "2");
				Utils.RegServiceNSudo("SCPolicySvc", "4");
				Utils.RegServiceNSudo("SDRSVC", "4");
				Utils.RegServiceNSudo("seclogon", "3");
				Utils.RegServiceNSudo("SensrSvc", "4");
				Utils.RegServiceNSudo("SENS", "2");
				Utils.RegServiceNSudo("SessionEnv", "4");
				Utils.RegServiceNSudo("SharedAccess", "4");
				Utils.RegServiceNSudo("ShellHWDetection", "2");
				Utils.RegServiceNSudo("SNMPTRAP", "4");
				Utils.RegServiceNSudo("Spooler", "4");
				Utils.RegServiceNSudo("sppsvc", "2");
				Utils.RegServiceNSudo("sppuinotify", "3");
				Utils.RegServiceNSudo("SSDPSRV", "4");
				Utils.RegServiceNSudo("SstpSvc", "3");
				Utils.RegServiceNSudo("stisvc", "4");
				Utils.RegServiceNSudo("StorSvc", "4");
				Utils.RegServiceNSudo("swprv", "3");
				Utils.RegServiceNSudo("SysMain", "4");
				Utils.RegServiceNSudo("TabletInputService", "4");
				Utils.RegServiceNSudo("TapiSrv", "4");
				Utils.RegServiceNSudo("TermService", "4");
				Utils.RegServiceNSudo("Themes", "4");
				Utils.RegServiceNSudo("THREADORDER", "3");
				Utils.RegServiceNSudo("TrkWks", "4");
				Utils.RegServiceNSudo("TrustedInstaller", "3");
				Utils.RegServiceNSudo("UI0Detect", "4");
				Utils.RegServiceNSudo("UmRdpService", "4");
				Utils.RegServiceNSudo("upnphost", "4");
				Utils.RegServiceNSudo("UxSms", "4");
				Utils.RegServiceNSudo("VaultSvc", "4");
				Utils.RegServiceNSudo("vds", "3");
				Utils.RegServiceNSudo("VSS", "3");
				Utils.RegServiceNSudo("W32Time", "3");
				Utils.RegServiceNSudo("WatAdminSvc", "4");
				Utils.RegServiceNSudo("wbengine", "4");
				Utils.RegServiceNSudo("WbioSrvc", "4");
				Utils.RegServiceNSudo("wcncsvc", "4");
				Utils.RegServiceNSudo("WcsPlugInService", "3");
				Utils.RegServiceNSudo("WdiServiceHost", "4");
				Utils.RegServiceNSudo("WdiSystemHost", "4");
				Utils.RegServiceNSudo("WebClient", "4");
				Utils.RegServiceNSudo("Wecsvc", "3");
				Utils.RegServiceNSudo("wercplsupport", "4");
				Utils.RegServiceNSudo("WerSvc", "4");
				Utils.RegServiceNSudo("WinDefend", "4");
				Utils.RegServiceNSudo("WinHttpAutoProxySvc", "3");
				Utils.RegServiceNSudo("Winmgmt", "3");
				Utils.RegServiceNSudo("WinRM", "4");
				Utils.RegServiceNSudo("Wlansvc", "2");
				Utils.RegServiceNSudo("wmiApSrv", "3");
				Utils.RegServiceNSudo("WMPNetworkSvc", "4");
				Utils.RegServiceNSudo("WPCSvc", "4");
				Utils.RegServiceNSudo("WPDBusEnum", "4");
				Utils.RegServiceNSudo("wscsvc", "4");
				Utils.RegServiceNSudo("WSearch", "4");
				Utils.RegServiceNSudo("wuauserv", "2");
				Utils.RegServiceNSudo("wudfsvc", "3");
				Utils.RegServiceNSudo("WwanSvc", "4");
			}
			if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 3)
			{
				Utils.RegServiceNSudo("AeLookupSvc", "3");
				Utils.RegServiceNSudo("ALG", "4");
				Utils.RegServiceNSudo("AppIDSvc", "3");
				Utils.RegServiceNSudo("Appinfo", "3");
				Utils.RegServiceNSudo("AppMgmt", "3");
				Utils.RegServiceNSudo("AppReadiness", "3");
				Utils.RegServiceNSudo("AudioEndpointBuilder", "2");
				Utils.RegServiceNSudo("Audiosrv", "2");
				Utils.RegServiceNSudo("AxInstSV", "3");
				Utils.RegServiceNSudo("BDESVC", "4");
				Utils.RegServiceNSudo("BFE", "2");
				Utils.RegServiceNSudo("BITS", "2");
				Utils.RegServiceNSudo("Browser", "4");
				Utils.RegServiceNSudo("BthHFSrv", "4");
				Utils.RegServiceNSudo("bthserv", "3");
				Utils.RegServiceNSudo("CertPropSvc", "3");
				Utils.RegServiceNSudo("COMSysApp", "3");
				Utils.RegServiceNSudo("CryptSvc", "2");
				Utils.RegServiceNSudo("CscService", "4");
				Utils.RegServiceNSudo("defragsvc", "3");
				Utils.RegServiceNSudo("DeviceAssociationService", "3");
				Utils.RegServiceNSudo("DeviceInstall", "3");
				Utils.RegServiceNSudo("Dhcp", "2");
				Utils.RegServiceNSudo("Dnscache", "4");
				Utils.RegServiceNSudo("dot3svc", "3");
				Utils.RegServiceNSudo("DPS", "4");
				Utils.RegServiceNSudo("DsmSvc", "3");
				Utils.RegServiceNSudo("Eaphost", "3");
				Utils.RegServiceNSudo("EFS", "3");
				Utils.RegServiceNSudo("EventLog", "3");
				Utils.RegServiceNSudo("EventSystem", "2");
				Utils.RegServiceNSudo("Fax", "4");
				Utils.RegServiceNSudo("fdPHost", "3");
				Utils.RegServiceNSudo("FDResPub", "3");
				Utils.RegServiceNSudo("fhsvc", "4");
				Utils.RegServiceNSudo("FontCache", "4");
				Utils.RegServiceNSudo("hidserv", "3");
				Utils.RegServiceNSudo("hkmsvc", "3");
				Utils.RegServiceNSudo("HomeGroupProvider", "4");
				Utils.RegServiceNSudo("IEEtwCollectorService", "4");
				Utils.RegServiceNSudo("IKEEXT", "3");
				Utils.RegServiceNSudo("iphlpsvc", "2");
				Utils.RegServiceNSudo("KeyIso", "3");
				Utils.RegServiceNSudo("KtmRm", "3");
				Utils.RegServiceNSudo("LanmanServer", "2");
				Utils.RegServiceNSudo("LanmanWorkstation", "2");
				Utils.RegServiceNSudo("lfsvc", "4");
				Utils.RegServiceNSudo("lltdsvc", "3");
				Utils.RegServiceNSudo("lmhosts", "4");
				Utils.RegServiceNSudo("MMCSS", "2");
				Utils.RegServiceNSudo("MpsSvc", "2");
				Utils.RegServiceNSudo("MSDTC", "3");
				Utils.RegServiceNSudo("MSiSCSI", "3");
				Utils.RegServiceNSudo("MsKeyboardFilter", "4");
				Utils.RegServiceNSudo("napagent", "3");
				Utils.RegServiceNSudo("NcaSvc", "3");
				Utils.RegServiceNSudo("NcbService", "3");
				Utils.RegServiceNSudo("NcdAutoSetup", "3");
				Utils.RegServiceNSudo("Netlogon", "3");
				Utils.RegServiceNSudo("Netman", "3");
				Utils.RegServiceNSudo("netprofm", "3");
				Utils.RegServiceNSudo("NetTcpPortSharing", "4");
				Utils.RegServiceNSudo("NlaSvc", "2");
				Utils.RegServiceNSudo("nsi", "2");
				Utils.RegServiceNSudo("p2pimsvc", "3");
				Utils.RegServiceNSudo("p2psvc", "3");
				Utils.RegServiceNSudo("PcaSvc", "4");
				Utils.RegServiceNSudo("PeerDistSvc", "4");
				Utils.RegServiceNSudo("PerfHost", "3");
				Utils.RegServiceNSudo("pla", "4");
				Utils.RegServiceNSudo("PlugPlay", "3");
				Utils.RegServiceNSudo("PNRPAutoReg", "3");
				Utils.RegServiceNSudo("PNRPsvc", "3");
				Utils.RegServiceNSudo("PolicyAgent", "3");
				Utils.RegServiceNSudo("Power", "2");
				Utils.RegServiceNSudo("PrintNotify", "3");
				Utils.RegServiceNSudo("ProfSvc", "2");
				Utils.RegServiceNSudo("QWAVE", "3");
				Utils.RegServiceNSudo("RasAuto", "3");
				Utils.RegServiceNSudo("RasMan", "3");
				Utils.RegServiceNSudo("RemoteAccess", "4");
				Utils.RegServiceNSudo("RemoteRegistry", "4");
				Utils.RegServiceNSudo("RpcLocator", "4");
				Utils.RegServiceNSudo("SamSs", "2");
				Utils.RegServiceNSudo("SCardSvr", "4");
				Utils.RegServiceNSudo("ScDeviceEnum", "3");
				Utils.RegServiceNSudo("SCPolicySvc", "3");
				Utils.RegServiceNSudo("seclogon", "3");
				Utils.RegServiceNSudo("SensrSvc", "3");
				Utils.RegServiceNSudo("SENS", "2");
				Utils.RegServiceNSudo("SessionEnv", "4");
				Utils.RegServiceNSudo("SharedAccess", "4");
				Utils.RegServiceNSudo("ShellHWDetection", "3");
				Utils.RegServiceNSudo("smphost", "3");
				Utils.RegServiceNSudo("SNMPTRAP", "3");
				Utils.RegServiceNSudo("Spooler", "3");
				Utils.RegServiceNSudo("SSDPSRV", "3");
				Utils.RegServiceNSudo("SstpSvc", "3");
				Utils.RegServiceNSudo("stisvc", "3");
				Utils.RegServiceNSudo("StorSvc", "3");
				Utils.RegServiceNSudo("svsvc", "3");
				Utils.RegServiceNSudo("swprv", "3");
				Utils.RegServiceNSudo("SysMain", "4");
				Utils.RegServiceNSudo("TabletInputService", "3");
				Utils.RegServiceNSudo("TapiSrv", "3");
				Utils.RegServiceNSudo("TermService", "4");
				Utils.RegServiceNSudo("Themes", "2");
				Utils.RegServiceNSudo("THREADORDER", "3");
				Utils.RegServiceNSudo("TrkWks", "2");
				Utils.RegServiceNSudo("TrustedInstaller", "3");
				Utils.RegServiceNSudo("UI0Detect", "3");
				Utils.RegServiceNSudo("UmRdpService", "3");
				Utils.RegServiceNSudo("upnphost", "3");
				Utils.RegServiceNSudo("VaultSvc", "3");
				Utils.RegServiceNSudo("vds", "3");
				Utils.RegServiceNSudo("vmicguestinterface", "4");
				Utils.RegServiceNSudo("vmicheartbeat", "4");
				Utils.RegServiceNSudo("vmickvpexchange", "4");
				Utils.RegServiceNSudo("vmicrdv", "4");
				Utils.RegServiceNSudo("vmicshutdown", "4");
				Utils.RegServiceNSudo("vmictimesync", "4");
				Utils.RegServiceNSudo("vmicvss", "4");
				Utils.RegServiceNSudo("VSS", "3");
				Utils.RegServiceNSudo("W32Time", "3");
				Utils.RegServiceNSudo("wbengine", "3");
				Utils.RegServiceNSudo("WbioSrvc", "4");
				Utils.RegServiceNSudo("Wcmsvc", "2");
				Utils.RegServiceNSudo("wcncsvc", "3");
				Utils.RegServiceNSudo("WcsPlugInService", "3");
				Utils.RegServiceNSudo("WdiServiceHost", "4");
				Utils.RegServiceNSudo("WdiSystemHost", "4");
				Utils.RegServiceNSudo("WebClient", "3");
				Utils.RegServiceNSudo("Wecsvc", "4");
				Utils.RegServiceNSudo("WEPHOSTSVC", "3");
				Utils.RegServiceNSudo("wercplsupport", "4");
				Utils.RegServiceNSudo("WerSvc", "4");
				Utils.RegServiceNSudo("WiaRpc", "3");
				Utils.RegServiceNSudo("WinHttpAutoProxySvc", "4");
				Utils.RegServiceNSudo("Winmgmt", "3");
				Utils.RegServiceNSudo("WinRM", "4");
				Utils.RegServiceNSudo("WlanSvc", "2");
				Utils.RegServiceNSudo("wlidsvc", "3");
				Utils.RegServiceNSudo("wmiApSrv", "3");
				Utils.RegServiceNSudo("WMPNetworkSvc", "3");
				Utils.RegServiceNSudo("workfolderssvc", "3");
				Utils.RegServiceNSudo("WPCSvc", "4");
				Utils.RegServiceNSudo("WPDBusEnum", "3");
				Utils.RegServiceNSudo("wscsvc", "4");
				Utils.RegServiceNSudo("WSearch", "4");
				Utils.RegServiceNSudo("wuauserv", "3");
				Utils.RegServiceNSudo("wudfsvc", "3");
				Utils.RegServiceNSudo("WwanSvc", "3");
				Utils.RegServiceNSudo("AppXSvc", "3");
				Utils.RegServiceNSudo("BrokerInfrastructure", "2");
				Utils.RegServiceNSudo("DcomLaunch", "2");
				Utils.RegServiceNSudo("gpsvc", "2");
				Utils.RegServiceNSudo("LSM", "2");
				Utils.RegServiceNSudo("msiserver", "3");
				Utils.RegServiceNSudo("RpcEptMapper", "2");
				Utils.RegServiceNSudo("RpcSs", "2");
				Utils.RegServiceNSudo("Schedule", "2");
				Utils.RegServiceNSudo("sppsvc", "2");
				Utils.RegServiceNSudo("SystemEventsBroker", "2");
				Utils.RegServiceNSudo("TimeBroker", "3");
				Utils.RegServiceNSudo("WdNisSvc", "4");
				Utils.RegServiceNSudo("WinDefend", "4");
				Utils.RegServiceNSudo("WSService", "4");
			}
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
			if (registryKey.GetValue("ReleaseId") != null)
			{
				if (registryKey.GetValue("ReleaseId").ToString() == "2009")
				{
					Utils.RegService("AarSvc", "4");
					Utils.RegService("AJRouter", "4");
					Utils.RegService("ALG", "4");
					Utils.RegServiceNSudo("AppIDSvc", "3");
					Utils.RegService("Appinfo", "3");
					Utils.RegService("AppMgmt", "3");
					Utils.RegService("AppReadiness", "3");
					Utils.RegService("AppVClient", "4");
					Utils.RegServiceNSudo("AppXSvc", "3");
					Utils.RegService("AssignedAccessManagerSvc", "4");
					Utils.RegService("AudioEndpointBuilder", "2");
					Utils.RegService("Audiosrv", "2");
					Utils.RegService("autotimesvc", "4");
					Utils.RegService("AxInstSV", "4");
					Utils.RegService("BcastDVRUserService", "3");
					Utils.RegService("BDESVC", "4");
					Utils.RegServiceNSudo("BFE", "2");
					Utils.RegService("BITS", "3");
					Utils.RegService("BluetoothUserService", "4");
					Utils.RegServiceNSudo("BrokerInfrastructure", "2");
					Utils.RegService("BTAGService", "4");
					Utils.RegService("BthAvctpSvc", "4");
					Utils.RegService("bthserv", "4");
					Utils.RegService("camsvc", "3");
					Utils.RegService("CaptureService", "3");
					Utils.RegService("cbdhsvc", "2");
					Utils.RegService("CDPSvc", "2");
					Utils.RegService("CDPUserSvc", "2");
					Utils.RegService("CertPropSvc", "4");
					Utils.RegServiceNSudo("ClipSVC", "3");
					Utils.RegService("COMSysApp", "3");
					Utils.RegService("ConsentUxUserSvc", "3");
					Utils.RegServiceNSudo("CoreMessagingRegistrar", "2");
					Utils.RegServiceNSudo("CredentialEnrollmentManagerUserSvc", "3");
					Utils.RegService("CryptSvc", "2");
					Utils.RegService("CscService", "4");
					Utils.RegServiceNSudo("DcomLaunch", "2");
					Utils.RegService("defragsvc", "4");
					Utils.RegServiceNSudo("DeviceAssociationBrokerSvc", "3");
					Utils.RegService("DeviceAssociationService", "3");
					Utils.RegService("DeviceInstall", "3");
					Utils.RegService("DevicePickerUserSvc", "3");
					Utils.RegService("DevicesFlowUserSvc", "3");
					Utils.RegService("DevQueryBroker", "3");
					Utils.RegService("Dhcp", "2");
					Utils.RegService("diagnosticshub.standardcollector.service", "4");
					Utils.RegService("diagsvc", "4");
					Utils.RegService("DiagTrack", "4");
					Utils.RegService("DispBrokerDesktopSvc", "4");
					Utils.RegService("DisplayEnhancementService", "3");
					Utils.RegService("DmEnrollmentSvc", "3");
					Utils.RegService("dmwappushservice", "4");
					Utils.RegServiceNSudo("Dnscache", "2");
					Utils.RegServiceNSudo("DoSvc", "3");
					Utils.RegService("dot3svc", "3");
					Utils.RegServiceNSudo("DPS", "4");
					Utils.RegService("DsmSvc", "3");
					Utils.RegService("DsSvc", "3");
					Utils.RegService("DusmSvc", "4");
					Utils.RegService("Eaphost", "3");
					Utils.RegService("edgeupdatem", "4");
					Utils.RegService("edgeupdate", "4");
					Utils.RegService("EFS", "3");
					Utils.RegServiceNSudo("embeddedmode", "4");
					Utils.RegServiceNSudo("EntAppSvc", "4");
					Utils.RegService("EventLog", "2");
					Utils.RegService("EventSystem", "2");
					Utils.RegService("Fax", "4");
					Utils.RegService("fdPHost", "3");
					Utils.RegService("FDResPub", "3");
					Utils.RegService("fhsvc", "4");
					Utils.RegService("FontCache3.0.0.0", "4");
					Utils.RegService("FontCache", "4");
					Utils.RegService("FrameServer", "3");
					Utils.RegServiceNSudo("gpsvc", "2");
					Utils.RegService("GraphicsPerfSvc", "3");
					Utils.RegService("hidserv", "3");
					Utils.RegService("HvHost", "4");
					Utils.RegService("icssvc", "4");
					Utils.RegService("IKEEXT", "3");
					Utils.RegService("InstallService", "3");
					Utils.RegService("iphlpsvc", "2");
					Utils.RegService("IpxlatCfgSvc", "3");
					Utils.RegService("KeyIso", "3");
					Utils.RegService("KtmRm", "3");
					Utils.RegService("LanmanServer", "4");
					Utils.RegService("LanmanWorkstation", "4");
					Utils.RegService("lfsvc", "4");
					Utils.RegService("LicenseManager", "3");
					Utils.RegService("lltdsvc", "4");
					Utils.RegService("lmhosts", "4");
					Utils.RegServiceNSudo("LSM", "2");
					Utils.RegService("LxpSvc", "3");
					Utils.RegService("MapsBroker", "4");
					Utils.RegService("MessagingService", "4");
					Utils.RegService("MicrosoftEdgeElevationService", "4");
					Utils.RegService("MixedRealityOpenXRSvc", "4");
					Utils.RegService("MSDTC", "3");
					Utils.RegService("MSiSCSI", "4");
					Utils.RegServiceNSudo("msiserver", "3");
					Utils.RegService("NaturalAuthentication", "4");
					Utils.RegService("NcaSvc", "4");
					Utils.RegService("NcbService", "3");
					Utils.RegService("NcdAutoSetup", "3");
					Utils.RegService("Netlogon", "3");
					Utils.RegService("Netman", "3");
					Utils.RegService("netprofm", "3");
					Utils.RegService("NetSetupSvc", "3");
					Utils.RegService("NetTcpPortSharing", "4");
					Utils.RegServiceNSudo("NgcCtnrSvc", "3");
					Utils.RegServiceNSudo("NgcSvc", "3");
					Utils.RegService("NlaSvc", "2");
					Utils.RegService("nsi", "2");
					Utils.RegService("OneSyncSvc", "4");
					Utils.RegService("p2pimsvc", "4");
					Utils.RegService("p2psvc", "4");
					Utils.RegService("PcaSvc", "3");
					Utils.RegService("PeerDistSvc", "4");
					Utils.RegService("perceptionsimulation", "4");
					Utils.RegService("PerfHost", "3");
					Utils.RegService("PhoneSvc", "4");
					Utils.RegService("PimIndexMaintenanceSvc", "3");
					Utils.RegService("pla", "3");
					Utils.RegService("PlugPlay", "3");
					Utils.RegService("PNRPAutoReg", "4");
					Utils.RegService("PNRPsvc", "4");
					Utils.RegService("PolicyAgent", "3");
					Utils.RegService("Power", "2");
					Utils.RegService("PrintNotify", "3");
					Utils.RegServiceNSudo("PrintWorkflowUserSvc", "3");
					Utils.RegService("ProfSvc", "2");
					Utils.RegService("PushToInstall", "3");
					Utils.RegService("QWAVE", "4");
					Utils.RegService("RasAuto", "4");
					Utils.RegService("RasMan", "3");
					Utils.RegService("RemoteAccess", "4");
					Utils.RegService("RemoteRegistry", "4");
					Utils.RegService("RetailDemo", "4");
					Utils.RegService("RmSvc", "4");
					Utils.RegServiceNSudo("RpcEptMapper", "2");
					Utils.RegService("RpcLocator", "4");
					Utils.RegServiceNSudo("RpcSs", "2");
					Utils.RegServiceNSudo("SamSs", "2");
					Utils.RegService("SCardSvr", "3");
					Utils.RegService("ScDeviceEnum", "3");
					Utils.RegServiceNSudo("Schedule", "2");
					Utils.RegService("SCPolicySvc", "4");
					Utils.RegService("SDRSVC", "4");
					Utils.RegService("seclogon", "3");
					Utils.RegService("SEMgrSvc", "4");
					Utils.RegService("SensorDataService", "4");
					Utils.RegService("SensorService", "4");
					Utils.RegService("SensrSvc", "4");
					Utils.RegService("SENS", "2");
					Utils.RegService("SessionEnv", "4");
					Utils.RegServiceNSudo("SgrmBroker", "4");
					Utils.RegService("SharedAccess", "4");
					Utils.RegService("SharedRealitySvc", "4");
					Utils.RegService("ShellHWDetection", "4");
					Utils.RegService("shpamsvc", "4");
					Utils.RegService("smphost", "4");
					Utils.RegService("SmsRouter", "4");
					Utils.RegService("SNMPTRAP", "3");
					Utils.RegService("spectrum", "3");
					Utils.RegService("Spooler", "4");
					Utils.RegServiceNSudo("sppsvc", "2");
					Utils.RegService("SSDPSRV", "3");
					Utils.RegService("ssh-agent", "4");
					Utils.RegService("SstpSvc", "3");
					Utils.RegServiceNSudo("StateRepository", "3");
					Utils.RegService("stisvc", "3");
					Utils.RegService("StorSvc", "2");
					Utils.RegService("svsvc", "3");
					Utils.RegService("swprv", "3");
					Utils.RegService("SysMain", "4");
					Utils.RegServiceNSudo("SystemEventsBroker", "2");
					Utils.RegService("TabletInputService", "3");
					Utils.RegService("TapiSrv", "4");
					Utils.RegService("TermService", "4");
					Utils.RegService("Themes", "4");
					Utils.RegService("TieringEngineService", "4");
					Utils.RegServiceNSudo("TimeBrokerSvc", "3");
					Utils.RegService("TokenBroker", "3");
					Utils.RegServiceNSudo("TrkWks", "4");
					Utils.RegService("TroubleshootingSvc", "4");
					Utils.RegServiceNSudo("TrustedInstaller", "3");
					Utils.RegService("tzautoupdate", "4");
					Utils.RegService("UdkUserSvc", "3");
					Utils.RegService("UevAgentService", "4");
					Utils.RegService("UmRdpService", "4");
					Utils.RegService("UnistoreSvc", "3");
					Utils.RegService("upnphost", "3");
					Utils.RegService("UserDataSvc", "3");
					Utils.RegService("UserManager", "2");
					Utils.RegServiceNSudo("UsoSvc", "2");
					Utils.RegService("VacSvc", "4");
					Utils.RegService("VaultSvc", "3");
					Utils.RegService("vds", "3");
					Utils.RegService("vmicguestinterface", "4");
					Utils.RegService("vmicheartbeat", "4");
					Utils.RegService("vmickvpexchange", "4");
					Utils.RegService("vmicrdv", "4");
					Utils.RegService("vmicshutdown", "4");
					Utils.RegService("vmictimesync", "4");
					Utils.RegService("vmicvmsession", "4");
					Utils.RegService("vmicvss", "4");
					Utils.RegService("VSS", "3");
					Utils.RegService("W32Time", "3");
					Utils.RegServiceNSudo("WaaSMedicSvc", "3");
					Utils.RegService("WalletService", "3");
					Utils.RegService("WarpJITSvc", "3");
					Utils.RegService("wbengine", "4");
					Utils.RegService("WbioSrvc", "4");
					Utils.RegService("Wcmsvc", "2");
					Utils.RegService("wcncsvc", "4");
					Utils.RegServiceNSudo("WdiServiceHost", "3");
					Utils.RegServiceNSudo("WdiSystemHost", "3");
					Utils.RegService("WebClient", "3");
					Utils.RegService("Wecsvc", "3");
					Utils.RegService("WEPHOSTSVC", "3");
					Utils.RegService("wercplsupport", "4");
					Utils.RegService("WerSvc", "4");
					Utils.RegService("WFDSConMgrSvc", "4");
					Utils.RegService("WiaRpc", "3");
					Utils.RegServiceNSudo("WinHttpAutoProxySvc", "3");
					Utils.RegService("Winmgmt", "2");
					Utils.RegService("WinRM", "4");
					Utils.RegService("wisvc", "4");
					Utils.RegService("WlanSvc", "2");
					Utils.RegService("wlidsvc", "3");
					Utils.RegService("wlpasvc", "4");
					Utils.RegService("WManSvc", "3");
					Utils.RegService("wmiApSrv", "3");
					Utils.RegService("WMPNetworkSvc", "4");
					Utils.RegService("workfolderssvc", "4");
					Utils.RegService("WpcMonSvc", "4");
					Utils.RegService("WPDBusEnum", "4");
					Utils.RegService("WpnService", "4");
					Utils.RegService("WpnUserService", "2");
					Utils.RegService("WSearch", "2");
					Utils.RegServiceNSudo("wuauserv", "3");
					Utils.RegService("WwanSvc", "4");
					Utils.RegService("XblAuthManager", "3");
					Utils.RegService("XblGameSave", "3");
					Utils.RegService("XboxGipSvc", "3");
					Utils.RegService("XboxNetApiSvc", "3");
				}
				if (registryKey.GetValue("ReleaseId") != null && registryKey.GetValue("ReleaseId").ToString() == "1803")
				{
					Utils.RegServiceNSudo("BthAvctpSvc", "4");
					Utils.RegServiceNSudo("DiagTrack", "4");
					Utils.RegServiceNSudo("EventLog", "4");
					Utils.RegServiceNSudo("hidserv", "4");
					Utils.RegServiceNSudo("IKEEXT", "4");
					Utils.RegServiceNSudo("KeyIso", "4");
					Utils.RegServiceNSudo("NcbService", "4");
					Utils.RegServiceNSudo("NcdAutoSetup", "4");
					Utils.RegServiceNSudo("PolicyAgent", "4");
					Utils.RegServiceNSudo("RasMan", "4");
					Utils.RegServiceNSudo("SamSs", "4");
					Utils.RegServiceNSudo("Schedule", "4");
					Utils.RegServiceNSudo("sedsvc", "4");
					Utils.RegServiceNSudo("Spooler", "4");
					Utils.RegServiceNSudo("TabletInputService", "4");
					Utils.RegServiceNSudo("Themes", "4");
					Utils.RegServiceNSudo("WdiServiceHost", "4");
					Utils.RegServiceNSudo("WdiSystemHost", "4");
					Utils.RegServiceNSudo("SstpSvc", "4");
					Utils.RegServiceNSudo("BFE", "4");
					Utils.RegServiceNSudo("FontCache", "4");
					Utils.RegServiceNSudo("DPS", "4");
					Utils.RegServiceNSudo("SENS", "4");
					Utils.RegServiceNSudo("ShellHWDetection", "4");
					Utils.RegServiceNSudo("WSearch", "4");
					Utils.RegServiceNSudo("TrkWks", "4");
					Utils.RegServiceNSudo("DusmSvc", "4");
					Utils.RegServiceNSudo("AppXSvc", "4");
					Utils.RegServiceNSudo("DsmSvc", "4");
					Utils.RegServiceNSudo("WinHttpAutoProxySvc", "4");
					Utils.RegServiceNSudo("wuauserv", "4");
					Utils.RegServiceNSudo("WPDBusEnum", "4");
					Utils.RegServiceNSudo("EventSystem", "4");
					Utils.RegServiceNSudo("DoSvc", "4");
					Utils.RegServiceNSudo("StorSvc", "4");
					Utils.RegServiceNSudo("TimeBroker", "4");
					Utils.RegServiceNSudo("UsoSvc", "4");
					Utils.RegServiceNSudo("WpnService", "4");
					Utils.RegServiceNSudo("wlidsvc", "4");
					Utils.RegServiceNSudo("TokenBroker", "4");
					Utils.RegServiceNSudo("PlugPlay", "4");
					Utils.RegServiceNSudo("CDPUserSvc", "4");
				}
			}
			Utils.ResetStatus();
		}
	}
}