using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000012 RID: 18
	public class GPUAMD : IFeature
	{
		// Token: 0x0600020D RID: 525 RVA: 0x0001C04C File Offset: 0x0001A24C
		public void Execute()
		{
			Utils.Status("Tweaking GPU...");
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}", true);
			if (MainForm.SpyCheck())
			{
				Utils.FGA();
			}
			else
			{
				Regex regex = new Regex("\\d{4}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
				foreach (string text in registryKey.GetSubKeyNames())
				{
					if (regex.IsMatch(text))
					{
						RegistryKey registryKey2 = registryKey.CreateSubKey(text, true);
						if (registryKey2.GetValueNames().Contains("DriverDesc"))
						{
							registryKey2.SetValue("PP_ULPSDelayIntervalInMilliSeconds", 268435456, RegistryValueKind.DWord);
							registryKey2.SetValue("AsicOnLowPower", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("DalMPOAllowLinearTiling", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("DisableBlockWrite", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("DisableDMACopy", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("DisableDrmdmaPowerGating", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("DisableSAMUPowerGating", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("DisableUVDPowerGatingDynamic", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("DisableVCEPowerGating", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableUlps", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableUlps_NA", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableUvdClockGating", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("EnableVceSwClockGating", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("GCOOPTION_DisableGPIOPowerSaveMode", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("KMD_DeLagEnabled", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("KMD_DisableTilingAperture", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("KMD_EnableComputePreemption", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("KMD_EnableContextBasedPowerManagement", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("KMD_EnableGfxMidCmdPreemption", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("KMD_EnableP2PIOWriteCombineWorkaround", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("KMD_EnablePreemptionLogging", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("KMD_EnableSDMAPreemption", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("PP_GPUPowerDownEnabled", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("PP_SclkDeepSleepDisable", "1", RegistryValueKind.DWord);
							registryKey2.SetValue("PP_ThermalAutoThrottlingEnable", "0", RegistryValueKind.DWord);
							registryKey2.SetValue("StutterMode", "0", RegistryValueKind.DWord);
						}
					}
				}
				Regex regex2 = new Regex("\\d{4}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
				foreach (string text2 in registryKey.GetSubKeyNames())
				{
					if (regex2.IsMatch(text2))
					{
						RegistryKey registryKey3 = registryKey.CreateSubKey(text2, true);
						if (registryKey3.GetValueNames().Contains("DriverDesc"))
						{
							RegistryKey registryKey4 = registryKey3.CreateSubKey("UMD", true);
							string name = "AntiStuttering";
							byte[] array = new byte[2];
							array[0] = 49;
							registryKey4.SetValue(name, array, RegistryValueKind.Binary);
							string name2 = "Main3D";
							byte[] array2 = new byte[2];
							array2[0] = 48;
							registryKey4.SetValue(name2, array2, RegistryValueKind.Binary);
							registryKey4.SetValue("Main3D_DEF", "0");
							string name3 = "ShaderCache";
							byte[] array3 = new byte[2];
							array3[0] = 50;
							registryKey4.SetValue(name3, array3, RegistryValueKind.Binary);
							string name4 = "Tessellation";
							byte[] array4 = new byte[2];
							array4[0] = 49;
							registryKey4.SetValue(name4, array4, RegistryValueKind.Binary);
							string name5 = "Tessellation_OPTION";
							byte[] array5 = new byte[2];
							array5[0] = 50;
							registryKey4.SetValue(name5, array5, RegistryValueKind.Binary);
							string name6 = "VSyncControl";
							byte[] array6 = new byte[2];
							array6[0] = 48;
							registryKey4.SetValue(name6, array6, RegistryValueKind.Binary);
						}
					}
				}
			}
			Utils.ResetStatus();
		}
	}
}
