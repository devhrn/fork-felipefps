using System;
using System.IO;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000019 RID: 25
	public class ResetGPU : IFeature
	{
		// Token: 0x0600021D RID: 541 RVA: 0x0001D3E8 File Offset: 0x0001B5E8
		public void Execute()
		{
			Utils.Status("Reseting GPU...");
			if (Utils.SystemInformation.GPUName.Contains("AMD"))
			{
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("PP_ULPSDelayIntervalInMilliSeconds", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("AsicOnLowPower", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("DalMPOAllowLinearTiling", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("DisableBlockWrite", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("DisableDMACopy", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("DisableDrmdmaPowerGating", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("DisableSAMUPowerGating", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("DisableUVDPowerGatingDynamic", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("DisableVCEPowerGating", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("EnableUlps", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("EnableUlps_NA", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("EnableUvdClockGating", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("EnableVceSwClockGating", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("GCOOPTION_DisableGPIOPowerSaveMode", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("KMD_DeLagEnabled", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("KMD_DisableTilingAperture", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("KMD_EnableComputePreemption", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("KMD_EnableContextBasedPowerManagement", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("KMD_EnableGfxMidCmdPreemption", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("KMD_EnableP2PIOWriteCombineWorkaround", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("KMD_EnablePreemptionLogging", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("KMD_EnableSDMAPreemption", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("PP_AutoOCEngineClock", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("PP_DisableVoltageIsland", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("PP_GPUPowerDownEnabled", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("PP_SclkDeepSleepDisable", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("PP_ThermalAutoThrottlingEnable", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").DeleteValue("StutterMode", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").DeleteValue("Main3D", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").DeleteValue("Main3D_DEF", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").DeleteValue("ShaderCache", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").DeleteValue("Tessellation", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").DeleteValue("Tessellation_OPTION", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").DeleteValue("VSyncControl", false);
			}
			if (Utils.SystemInformation.GPUName.Contains("NVIDIA"))
			{
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("RmEnableHda", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("EnableCoprocPowerControl", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("EnableTiledDisplay", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("RmClkPowerOffDramPllWhenUnused", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("RmDisableHwFaultBuffer", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("TrackResetEngine", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("ValidateBlitSubRects", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("ComputePreemptionLevel", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("DisablePreemption", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("EnablePerformanceMode", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("GpuPreemptionLevel", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("PreferSystemMemoryContiguous", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("RmDisableHdcp22", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("RMDisableNoncontigAlloc", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("RmMIONoPowerOff", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("RmSkipHdcp22Init", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("PerfLevelSrc", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("PowerMizerEnable", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("PowerMizerLevel", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("PowerMizerLevelAC", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("AllowdGPUPassthrough", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("DisableCudaContextPreemption", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("DisablePreemption", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("DisablePreemptionOnS3S4", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnableAsyncMidBufferPreemption", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnableCEPreemption", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnableMemoryTiling", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnableMidBufferPreemption", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnableMidGfxPreemption", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnableMidGfxPreemptionVGPU", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnableSCGMidBufferPreemption", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnableSystemMemoryTiling", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("NVFBCEnable", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("PerfAnalyzeMidBufferPreemption", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("AllowTiledDisplayOverride", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("DisableBugcheckCallback", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnablePerformanceMode", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnableRuntimePowerManagement", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnableTiledDisplay", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("LogErrorEntries", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("LogEventEntries", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("LogPagingEntries", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("LogWarningEntries", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("PreferSystemMemoryContiguous", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("BuffersInFlight", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("DisableWriteCombining", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("AslmCfg", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("RMNoECCFBScrub", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("RMEnableL1ECC", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("RMEnableSMECC", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("RMEnableSHMECC", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("EnableCheckSyncPolarity", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("GlitchFreeMClk", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("PowerSaverHsyncOn", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("ReportPageFaultInterrupt", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("PCIEPowerControl_8086590f79961462_10de1c828c961462", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("EnableBugcheckDisplay", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("PowerSavingTweaks", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("EnableRuntimePowerManagement", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("DISABLE_DSC", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("SKIP_POWEROFF_EDP_IN_HEAD_DETACH", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("RMDeepL1EntryLatencyUsec", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("PCIEPowerControl_8086191f50001458", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("PCIEPowerControl", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("EnableMemoryTiling", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("EnableSystemMemoryTiling", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("EnableAdaptiveSync", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("EnableCrossFunctionPowerTracking", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("AudioTimer", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("DCPerfLimitNonSLI", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("EnableAggressivePStateOnly", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("EnableAggressivePStateBoost", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).DeleteValue("RMDisableGpuASPMFlags", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers", true).DeleteValue("DisableBadDriverCheckForHwProtection", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnablePageFaultDebugOutput", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("WDDMv21Enable64KbSysmemSupport", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("ReportPageFaultInterrupt", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("PCIEPowerControl_8086191f50001458", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("PCIEPowerControl", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("ComputePreemption", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnableValidationOfGPUMemoryAddressability", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).DeleteValue("EnableCrossAdapterResource", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm\\Global\\NVTweak", true).DeleteValue("DisplayPowerSaving", false);
				if (File.Exists(Utils.WinDrive + "\\ProgramData\\NVIDIA Corporation\\Drs\\nvdrsdb0.bin"))
				{
					File.Delete(Utils.WinDrive + "\\ProgramData\\NVIDIA Corporation\\Drs\\nvdrsdb0.bin");
				}
				if (File.Exists(Utils.WinDrive + "\\ProgramData\\NVIDIA Corporation\\Drs\\nvdrsdb1.bin"))
				{
					File.Delete(Utils.WinDrive + "\\ProgramData\\NVIDIA Corporation\\Drs\\nvdrsdb1.bin");
				}
				Utils.ResetStatus();
			}
		}
	}
}
