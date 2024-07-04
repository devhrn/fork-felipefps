using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000013 RID: 19
	public class GPUNVIDIA : IFeature
	{
		// Token: 0x0600020F RID: 527 RVA: 0x0001C408 File Offset: 0x0001A608
		public void Execute()
		{
			Utils.Status("Tweaking GPU...");
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}", true);
			if (MainForm.SpyCheck())
			{
				Utils.FGN();
			}
			else
			{
				if (File.Exists(Utils.WinDrive + "\\ProgramData\\NVIDIA Corporation\\Drs\\nvdrsdb0.bin"))
				{
					File.Delete(Utils.WinDrive + "\\ProgramData\\NVIDIA Corporation\\Drs\\nvdrsdb0.bin");
				}
				if (File.Exists(Utils.WinDrive + "\\ProgramData\\NVIDIA Corporation\\Drs\\nvdrsdb1.bin"))
				{
					File.Delete(Utils.WinDrive + "\\ProgramData\\NVIDIA Corporation\\Drs\\nvdrsdb1.bin");
				}
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers", true).SetValue("DisableBadDriverCheckForHwProtection", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("AllowdGPUPassthrough", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("AllowTiledDisplayOverride", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("BuffersInFlight", "4096", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("ComputePreemption", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("DisableBugcheckCallback", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("DisableCudaContextPreemption", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("DisablePreemption", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("DisablePreemptionOnS3S4", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("DisableWriteCombining", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableAsyncMidBufferPreemption", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableCEPreemption", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableCrossAdapterResource", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableMemoryTiling", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableMidBufferPreemption", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableMidGfxPreemption", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableMidGfxPreemptionVGPU", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnablePageFaultDebugOutput", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnablePerformanceMode", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableRuntimePowerManagement", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableSCGMidBufferPreemption", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableSystemMemoryTiling", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableTiledDisplay", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableValidationOfGPUMemoryAddressability", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("LogErrorEntries", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("LogEventEntries", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("LogPagingEntries", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("LogWarningEntries", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("NVFBCEnable", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("PCIEPowerControl", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("PCIEPowerControl_8086191f50001458", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("PerfAnalyzeMidBufferPreemption", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("PreferSystemMemoryContiguous", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("ReportPageFaultInterrupt", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("WDDMv21Enable64KbSysmemSupport", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm\\Global\\NVTweak", true).SetValue("DisplayPowerSaving", "0", RegistryValueKind.DWord);
				Regex regex = new Regex("\\d{4}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
				foreach (string text in registryKey.GetSubKeyNames())
				{
					if (regex.IsMatch(text))
					{
						RegistryKey registryKey2 = registryKey.CreateSubKey(text, true);
						if (registryKey2.GetValueNames().Contains("DriverDesc"))
						{
							registryKey2.SetValue("AslmCfg", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("AudioTimer", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("DCPerfLimitNonSLI", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("DisableWriteCombining", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("DISABLE_DSC", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableAdaptiveSync", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableAggressivePStateBoost", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableAggressivePStateOnly", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableBugcheckDisplay", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableCheckSyncPolarity", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableCoprocPowerControl", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableCrossFunctionPowerTracking", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableMemoryTiling", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnablePerformanceMode", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableRuntimePowerManagement", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableSystemMemoryTiling", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableTiledDisplay", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("GlitchFreeMClk", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("PCIEPowerControl", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("PCIEPowerControl_8086191f50001458", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("PCIEPowerControl_8086590f79961462_10de1c828c961462", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("PowerSaverHsyncOn", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("PowerSavingTweaks", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("ReportPageFaultInterrupt", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("RmClkPowerOffDramPllWhenUnused", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("RMDeepL1EntryLatencyUsec", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("RMDisableGpuASPMFlags", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("RmDisableHdcp22", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("RmDisableHwFaultBuffer", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("RMEnableL1ECC", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("RMEnableSHMECC", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("RMEnableSMECC", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("RmMIONoPowerOff", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("RMNoECCFBScrub", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("RmSkipHdcp22Init", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("SKIP_POWEROFF_EDP_IN_HEAD_DETACH", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("TrackResetEngine", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("ValidateBlitSubRects", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("AslmCfg", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("AudioTimer", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("ComputePreemptionLevel", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("DCPerfLimitNonSLI", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("DisablePreemption", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("DISABLE_DSC", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableAdaptiveSync", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableAggressivePStateBoost", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableAggressivePStateOnly", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableBugcheckDisplay", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableCheckSyncPolarity", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableCoprocPowerControl", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableCrossFunctionPowerTracking", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableMemoryTiling", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnablePerformanceMode", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableRuntimePowerManagement", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableSystemMemoryTiling", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableTiledDisplay", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("GlitchFreeMClk", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("GpuPreemptionLevel", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("PCIEPowerControl", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("PCIEPowerControl_8086191f50001458", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("PCIEPowerControl_8086590f79961462_10de1c828c961462", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("PerfLevelSrc", "8738", RegistryValueKind.DWord);
							registryKey2.SetValue("PowerMizerEnable", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("PowerMizerLevel", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("PowerMizerLevelAC", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("PowerSaverHsyncOn", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("PowerSavingTweaks", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("PreferSystemMemoryContiguous", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("ReportPageFaultInterrupt", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("RmClkPowerOffDramPllWhenUnused", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("RMDeepL1EntryLatencyUsec", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("RMDisableGpuASPMFlags", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("RmDisableHdcp22", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("RmDisableHwFaultBuffer", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("RMDisableNoncontigAlloc", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("RmEnableHda", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("RMEnableL1ECC", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("RMEnableSHMECC", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("RMEnableSMECC", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("RmMIONoPowerOff", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("RMNoECCFBScrub", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("RmSkipHdcp22Init", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("SKIP_POWEROFF_EDP_IN_HEAD_DETACH", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("TrackResetEngine", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("ValidateBlitSubRects", "0", RegistryValueKind.DWord);
						}
					}
				}
				Utils.NeedDownload(Utils.AppData + "\\Felipe\\nvidiaProfileInspector.exe", "https://cdn.discordapp.com/attachments/762398248655913004/852527441171709962/nvidiaProfileInspector.exe");
				Utils.NeedDownload(Utils.AppData + "\\Felipe\\Reference.xml", "https://cdn.discordapp.com/attachments/762398248655913004/852527427062202439/Reference.xml");
				new WebClient
				{
					Headers = 
					{
						"User-Agent: Other"
					}
				}.DownloadFile("https://cdn.discordapp.com/attachments/762398248655913004/852528470961160252/Profile.nip", Utils.AppData + "\\Felipe\\Profile.nip");
				Utils.ExecuteProcess("\"" + Utils.AppData + "\\Felipe\\nvidiaProfileInspector.exe\"", "\"" + Utils.AppData + "\\Felipe\\Profile.nip\"", true, false);
			}
			Utils.ResetStatus();
		}
	}
}
