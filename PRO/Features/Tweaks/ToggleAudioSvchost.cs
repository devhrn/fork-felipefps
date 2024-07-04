using System;
using System.Drawing;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x0200001D RID: 29
	public class ToggleAudioSvchost : IFeature
	{
		// Token: 0x06000225 RID: 549 RVA: 0x0002484C File Offset: 0x00022A4C
		public void Execute()
		{
			Utils.Status("Tweaking AudioSvchost...");
			if (ToggleAudioSvchost.Settings.GetValue("AudioSvchost") != null)
			{
				ToggleAudioSvchost.Settings.DeleteValue("AudioSvchost", false);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\Audiosrv", true).SetValue("ImagePath", "%SystemRoot%\\System32\\svchost.exe -k LocalServiceNetworkRestricted -p", RegistryValueKind.ExpandString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\AudioEndpointBuilder", true).SetValue("ImagePath", "%SystemRoot%\\System32\\svchost.exe -k LocalSystemNetworkRestricted -p", RegistryValueKind.ExpandString);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\StartMenuExperienceHost.exe\\PerfOptions", true).DeleteValue("CpuPriorityClass", false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\StartMenuExperienceHost.exe\\PerfOptions", true).DeleteValue("IoPriority", false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\StartMenu.exe\\PerfOptions", true).DeleteValue("CpuPriorityClass", false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\StartMenu.exe\\PerfOptions", true).DeleteValue("IoPriority", false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\svchost.exe\\PerfOptions", true).DeleteValue("CpuPriorityClass", false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\svchost.exe\\PerfOptions", true).DeleteValue("IoPriority", false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\csrss.exe\\PerfOptions", true).DeleteValue("CpuPriorityClass", false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\csrss.exe\\PerfOptions", true).DeleteValue("IoPriority", false);
				MainForm.Main.button65.BackColor = Color.FromArgb(5, 8, 10);
			}
			else
			{
				Utils.SysNativeCmd("copy /y %windir%\\System32\\svchost.exe %windir%\\System32\\audiosvchost.exe");
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\Audiosrv", true).SetValue("ImagePath", "%SystemRoot%\\System32\\audiosvchost.exe -k LocalServiceNetworkRestricted -p", RegistryValueKind.ExpandString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\Audiosrv", true).SetValue("DependOnService", new string[]
				{
					""
				}, RegistryValueKind.MultiString);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\AudioEndpointBuilder", true).SetValue("ImagePath", "%SystemRoot%\\System32\\audiosvchost.exe -k LocalSystemNetworkRestricted -p", RegistryValueKind.ExpandString);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\StartMenuExperienceHost.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\StartMenuExperienceHost.exe\\PerfOptions", true).SetValue("IoPriority", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\StartMenu.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\StartMenu.exe\\PerfOptions", true).SetValue("IoPriority", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\svchost.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\svchost.exe\\PerfOptions", true).SetValue("IoPriority", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\csrss.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "4", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\csrss.exe\\PerfOptions", true).SetValue("IoPriority", "3", RegistryValueKind.DWord);
				ToggleAudioSvchost.Settings.SetValue("AudioSvchost", "1", RegistryValueKind.DWord);
				MainForm.Main.button65.BackColor = Color.FromArgb(5, 88, 10);
			}
			Utils.ResetStatus();
		}

		// Token: 0x040000E8 RID: 232
		public static RegistryKey Settings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Felipe", true);
	}
}
