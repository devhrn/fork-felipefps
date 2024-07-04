using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PRO.Core
{
	// Token: 0x020000A2 RID: 162
	public static class Utils
	{
		// Token: 0x06000415 RID: 1045 RVA: 0x00033B64 File Offset: 0x00031D64
		internal static string gethash(string id)
		{
			MD5 md = new MD5CryptoServiceProvider();
			byte[] bytes = new ASCIIEncoding().GetBytes(id);
			for (int i = 0; i < bytes.Length; i++)
			{
				byte b = bytes[i];
				int num = (int)(b & 15);
				int num2 = b >> 4 & 15;
				if (num2 > 9)
				{
					id += ((char)(num2 - 10 + 65)).ToString();
				}
				else
				{
					id += num2.ToString();
				}
				if (num > 9)
				{
					id += ((char)(num - 10 + 65)).ToString();
				}
				else
				{
					id += num.ToString();
				}
				if (i + 1 != bytes.Length && (i + 1) % 2 == 0)
				{
					id += "-";
				}
			}
			return string.Join<byte>(string.Empty, md.ComputeHash(bytes));
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00033C40 File Offset: 0x00031E40
		internal static string getid(string x, string danske)
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT " + x + ", Name FROM " + danske))
			{
				foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					if (managementObject[x] != null && !(managementObject[x].ToString() == string.Empty))
					{
						return Utils.gethash(managementObject[x].ToString()).Replace("Not Applicable", "").Replace("Default string", "").Replace("/", "").Replace("-", "").Replace("-", "").Replace("None", "").Replace("To be filled by O.E.M.", "").Replace(" ", "").Replace(".", "");
					}
				}
			}
			return "";
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00033D8C File Offset: 0x00031F8C
		public static void StartProcess(string path, string name, string arguments, bool printEnd = false)
		{
			new Process
			{
				StartInfo = 
				{
					FileName = path + name,
					WorkingDirectory = Environment.ExpandEnvironmentVariables(path),
					Arguments = arguments
				}
			}.Start();
			if (printEnd)
			{
				Utils.ResetStatus();
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00033DDC File Offset: 0x00031FDC
		public static void StartProcessCmd(string environmentpath, string arguments, bool printEnd = false)
		{
			new Process
			{
				StartInfo = 
				{
					FileName = "cmd.exe",
					WorkingDirectory = Environment.ExpandEnvironmentVariables(environmentpath),
					Arguments = arguments
				}
			}.Start();
			if (printEnd)
			{
				Utils.ResetStatus();
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00033E2C File Offset: 0x0003202C
		public static void SysNativeCmd(string arguments)
		{
			new Process
			{
				StartInfo = 
				{
					FileName = Utils.cmdFullFileName,
					Arguments = "/c " + arguments,
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true
				}
			}.Start();
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00033E84 File Offset: 0x00032084
		public static void ExecuteProcess(string filePath, string arguments, bool waitForExit = false, bool printEnd = false)
		{
			Process process = new Process
			{
				StartInfo = 
				{
					FileName = filePath,
					Arguments = arguments,
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true
				}
			};
			process.Start();
			if (waitForExit)
			{
				process.WaitForExit();
			}
			if (printEnd)
			{
				Utils.ResetStatus();
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00033EDF File Offset: 0x000320DF
		public static void ResetStatus()
		{
			MainForm.Main.Status.Text = "dsc.gg/felipe";
			Application.DoEvents();
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00033EFA File Offset: 0x000320FA
		public static void Status(string title)
		{
			MainForm.Main.Status.Text = title;
			Application.DoEvents();
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00033F11 File Offset: 0x00032111
		public static void CreateFolder(string folderPath)
		{
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00033F25 File Offset: 0x00032125
		public static void NeedDownload(string folderPath, string link)
		{
			if (!File.Exists(folderPath))
			{
				new WebClient
				{
					Headers = 
					{
						"User-Agent: Other"
					}
				}.DownloadFile(link, folderPath);
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00033F50 File Offset: 0x00032150
		public static void RegServiceNSudo(string code, string value)
		{
			string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Felipe\\NSudoLC.exe";
			string arguments = string.Concat(new string[]
			{
				"-U:T -P:E -ShowWindowMode:Hide cmd /c reg add \"HKLM\\System\\CurrentControlSet\\Services\\",
				code,
				"\" /v Start /t REG_DWORD /d ",
				value,
				" /f"
			});
			Utils.ExecuteProcess(filePath, arguments, false, false);
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00033FA4 File Offset: 0x000321A4
		public static void RegService(string servicename, string value)
		{
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\" + servicename, true).SetValue("Start", value, RegistryValueKind.DWord);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00033FC8 File Offset: 0x000321C8
		public static void UnZip(string name, bool printEnd = false)
		{
			using (ZipArchive zipArchive = ZipFile.OpenRead(Path.GetTempPath() + "\\" + name + ".zip"))
			{
				foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
				{
					string text = Path.Combine(Utils.AppData + "\\Felipe", zipArchiveEntry.FullName);
					string directoryName = Path.GetDirectoryName(text);
					if (!Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					if (!string.IsNullOrEmpty(Path.GetFileName(text)))
					{
						zipArchiveEntry.ExtractToFile(text, true);
					}
				}
			}
			if (printEnd)
			{
				Utils.ResetStatus();
			}
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00034098 File Offset: 0x00032298
		public static void UnZipDesktop(string name, bool printEnd = false)
		{
			using (ZipArchive zipArchive = ZipFile.OpenRead(Path.GetTempPath() + "\\" + name + ".zip"))
			{
				foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
				{
					string text = Path.Combine(Utils.Desktop, zipArchiveEntry.FullName);
					string directoryName = Path.GetDirectoryName(text);
					if (!Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					if (!string.IsNullOrEmpty(Path.GetFileName(text)))
					{
						zipArchiveEntry.ExtractToFile(text, true);
					}
				}
			}
			if (printEnd)
			{
				Utils.ResetStatus();
			}
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0003415C File Offset: 0x0003235C
		public static void DiscordSendMessage(string url, string username, string content)
		{
			WebClient webClient = new WebClient();
			try
			{
				webClient.UploadValues(url, new NameValueCollection
				{
					{
						"content",
						content
					},
					{
						"username",
						username
					}
				});
			}
			catch
			{
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x000341AC File Offset: 0x000323AC
		// (set) Token: 0x06000425 RID: 1061 RVA: 0x000341B3 File Offset: 0x000323B3
		public static bool GPUName { get; internal set; }

		// Token: 0x06000426 RID: 1062 RVA: 0x000341BC File Offset: 0x000323BC
		public static void FB()
		{
			Utils.NeedDownload(Utils.WinDrive + "Windows\\System32\\StartLayoutFile.xml", "https://cdn.discordapp.com/attachments/1258236120354000896/1258236456309227530/StartLayoutFile.xml?ex=66874f84&is=6685fe04&hm=4f103e9e146358d42288a317984350e04d2cf5e55310bfd33d33243f4b6b5d81&");
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("StartLayoutFile", Utils.WinDrive + "Windows\\System32\\StartLayoutFile.xml", RegistryValueKind.ExpandString);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("LockedStartLayout", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Diagnostics\\DiagTrack", true).SetValue("DiagTrackStatus", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoDriveTypeAutoRun", "255", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoPublishingWizard", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoOnlinePrintsWizard", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoWebServices", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoInternetOpenWith", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\MobilityCenter", true).SetValue("NoMobilityCenter", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\PresentationSettings", true).SetValue("NoPresentationSettings", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("MSAOptional", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\TextInput", true).SetValue("AllowLinguisticDataCollection", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Windows", true).SetValue("TurnOffWinCal", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Windows\\Sidebar", true).SetValue("TurnOffSidebar", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\AppV\\CEIP", true).SetValue("CEIPEnable", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\AppV\\Client", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Assistance\\Client\\1.0", true).SetValue("NoActiveHelp", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Conferencing", true).SetValue("NoRDS", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\DeviceHealthAttestationService", true).SetValue("EnableDeviceHealthAttestationService", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\EventViewer", true).SetValue("MicrosoftEventVwrDisableLinks", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\FindMyDevice", true).SetValue("AllowFindMyDevice", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Personalization\\Settings", true).SetValue("AcceptedPrivacyPolicy", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\InputPersonalization\\TrainedDataStore", true).SetValue("HarvestContacts", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\InputPersonalization", true).SetValue("RestrictImplicitTextCollection", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\InputPersonalization", true).SetValue("RestrictImplicitInkCollection", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Internet Explorer\\Feeds", true).SetValue("BackgroundSyncStatus", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Messenger\\Client", true).SetValue("CEIP", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\MicrosoftEdge\\PhishingFilter", true).SetValue("EnabledV9", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\PassportForWork", true).SetValue("DisableSmartCardNode", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\PCHealth\\ErrorReporting", true).SetValue("DoReport", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\PCHealth\\HelpSvc", true).SetValue("Headlines", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\PCHealth\\HelpSvc", true).SetValue("MicrosoftKBSearch", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Peernet", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\PenTraining", true).SetValue("DisablePenTraining", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\SearchCompanion", true).SetValue("DisableContentFileUpdates", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\SQMClient\\Windows", true).SetValue("CEIPEnable", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\TabletPC", true).SetValue("TurnOffButtons", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\TabletPC", true).SetValue("DisableNoteWriterPrinting", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\TabletPC", true).SetValue("DisableInkball", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\TabletPC", true).SetValue("TurnOffTouchInput", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\TabletPC", true).SetValue("TurnOffPanning", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\TabletPC", true).SetValue("TurnOffPenFeedback", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\TabletPC", true).SetValue("DisableJournal", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\TabletTip\\1.7", true).SetValue("DisablePrediction", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\AdvertisingInfo", true).SetValue("DisabledByGroupPolicy", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\AppCompat", true).SetValue("DisableInventory", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\AppCompat", true).SetValue("AITEnable", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\AppCompat", true).SetValue("DisableEngine", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\AppCompat", true).SetValue("SbEnable", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\AppCompat", true).SetValue("DisablePCA", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\AppCompat", true).SetValue("DisableUAR", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableCloudOptimizedContent", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableWindowsConsumerFeatures", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableSoftLanding", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("ConfigureWindowsSpotlight", "2", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableTailoredExperiencesWithDiagnosticData", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableThirdPartySuggestions", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableWindowsSpotlightFeatures", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableWindowsSpotlightOnActionCenter", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableWindowsSpotlightOnSettings", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableWindowsSpotlightWindowsWelcomeExperience", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("IncludeEnterpriseSpotlight", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\CurrentVersion\\MDM", true).SetValue("DisableRegistration", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", true).SetValue("NoCloudApplicationNotification", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("DisableDiagnosticDataViewer", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("AllowTelemetry", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("DisableDeviceDelete", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\DeviceGuard", true).SetValue("HVCIMATRequired", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\DeviceGuard", true).SetValue("EnableVirtualizationBasedSecurity", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\EdgeUI", true).SetValue("DisableHelpSticker", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("NoDataExecutionPrevention", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("NoHeapTerminationOnCorruption", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\FileHistory", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\HandwritingErrorReports", true).SetValue("PreventHandwritingErrorReports", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\LocationAndSensors", true).SetValue("DisableSensors", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\LocationAndSensors", true).SetValue("DisableLocation", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\LocationAndSensors", true).SetValue("DisableLocationScripting", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\LocationAndSensors", true).SetValue("DisableWindowsLocationProvider", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Maps", true).SetValue("AutoDownloadAndUpdateMapData", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Maps", true).SetValue("AllowUntriggeredNetworkTrafficOnSettingsPage", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\NetCache", true).SetValue("NoReminders", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\NetCache", true).SetValue("WorkOfflineDisabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\NetworkConnectivityStatusIndicator", true).SetValue("NoActiveProbe", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\PowerShell", true).SetValue("ExecutionPolicy", "Unrestricted", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\PowerShell", true).SetValue("EnableScripts", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Psched", true).SetValue("TimerResolution", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\ScheduledDiagnostics", true).SetValue("EnabledExecution", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\ScriptedDiagnostics", true).SetValue("ValidateTrust", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\System", true).SetValue("EnableSmartScreen", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\TabletPC", true).SetValue("PreventHandwritingDataSharing", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{186f47ef-626c-4670-800a-4a30756babad}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{2698178D-FDAD-40AE-9D3C-1371703ADC5B}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{29689E29-2CE9-4751-B4FC-8EFF5066E3FD}", true).SetValue("EnabledScenarioExecutionLevel", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{29689E29-2CE9-4751-B4FC-8EFF5066E3FD}", true).SetValue("ScenarioExecutionEnabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{3af8b24a-c441-4fa4-8c5c-bed591bfa867}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{54077489-683b-4762-86c8-02cf87a33423}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{67144949-5132-4859-8036-a737b43825d8}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{8519d925-541e-4a2b-8b1e-8059d16082f2}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{86432a0b-3c7d-4ddf-a89c-172faa90485d}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{9c5a40da-b965-4fc3-8781-88dd50a6299d}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{a7a5847a-7511-4e4e-90b1-45ad2a002f51}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{C295FBBA-FD47-46ac-8BEE-B1715EC634E5}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{dc42ff48-e40d-4a60-8675-e71f7e64aa9a}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{dc42ff48-e40d-4a60-8675-e71f7e64aa9a}", true).SetValue("EnabledScenarioExecutionLevel", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{eb73b633-3f4e-4ba0-8f60-8f3c6f53168f}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{eb73b633-3f4e-4ba0-8f60-8f3c6f53168f}", true).SetValue("EnabledScenarioExecutionLevel", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{ecfb03d1-58ee-4cc7-a1b5-9bc6febcb915}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WDI\\{ffc42108-4920-4acf-a4fc-8abdcc68ada4}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Windows Error Reporting", true).SetValue("DontSendAdditionalData", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Windows Error Reporting", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Windows Error Reporting", true).SetValue("LoggingDisabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Error Reporting", true).SetValue("AutoApproveOSDumps", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Error Reporting", true).SetValue("DontShowUI", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("AllowSearchToUseLocation", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("DisableWebSearch", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("ConnectedSearchUseWebOverMeteredConnections", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("ConnectedSearchUseWeb", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU", true).SetValue("NoAutoUpdate", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("System\\ControlSet001\\Control\\DeviceGuard", true).SetValue("RequirePlatformSecurityFeatures", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("System\\ControlSet001\\Control\\DeviceGuard", true).SetValue("Locked", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("System\\ControlSet001\\Control\\DeviceGuard", true).SetValue("EnableVirtualizationBasedSecurity", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("System\\ControlSet001\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("System\\ControlSet001\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity", true).SetValue("HVCIMATRequired", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("System\\ControlSet001\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity", true).SetValue("Locked", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("System\\ControlSet001\\Control\\Lsa", true).SetValue("LsaCfgFlags", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("System\\ControlSet001\\Services\\BITS", true).SetValue("Start", "3", RegistryValueKind.DWord);
			Registry.ClassesRoot.CreateSubKey(".pow", true).SetValue("", "Power Plan", RegistryValueKind.String);
			Registry.ClassesRoot.CreateSubKey(".pow", true).SetValue("FriendlyTypeName", "Power Plan", RegistryValueKind.String);
			Registry.ClassesRoot.CreateSubKey(".pow\\DefaultIcon", true).SetValue("", "%SystemRoot%\\System32\\powercfg.cpl,-202", RegistryValueKind.ExpandString);
			Registry.ClassesRoot.CreateSubKey(".pow\\shell\\Import\\command", true).SetValue("", "powercfg /import \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Colors", true).SetValue("Background", "23 24 27", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("Wallpaper", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ControlPanel", true).SetValue("AllItemsIconView", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ControlPanel", true).SetValue("StartupPage", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Multimedia\\Audio", true).SetValue("UserDuckingPreference", "3", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility", true).SetValue("DynamicScrollbars", "0", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("AutoEndTasks", "1", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("HungAppTimeout", "1000", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("LowLevelHooksTimeout", "1000", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("MenuShowDelay", "0", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("ScreenSaverIsSecure", "0", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("WaitToKillAppTimeout", "1000", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Mouse", true).SetValue("MouseSpeed", "0", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Mouse", true).SetValue("MouseThreshold1", "0", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Mouse", true).SetValue("MouseThreshold2", "0", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Sound", true).SetValue("Beep", "No", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Control Panel\\Sound", true).SetValue("ExtendedSounds", "No", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("DisallowCpl", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("1", "File History", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("2", "RemoteApp and Desktop Connections", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("3", "Storage Spaces", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("4", "Troubleshooting", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("5", "Autoplay", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("6", "Credential Manager", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("7", "Security and Maintenance", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("8", "Sync Center", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("9", "Backup and Restore (Windows 7)", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("10", "Ease of Access Center", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("11", "Indexing Options", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("12", "Bitlocker Drive Encryption", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("13", "Phone and Modem", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("14", "Speech Recognition", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowCpl", true).SetValue("15", "Work Folders", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CDP", true).SetValue("CdpSessionUserAuthzPolicy", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CDP", true).SetValue("NearShareChannelUserAuthzPolicy", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CDP", true).SetValue("RomeSdkChannelUserAuthzPolicy", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications", true).SetValue("GlobalUserDisabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\E2A4F912-2574-4A75-9BB0-0D023378592B_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\E2A4F912-2574-4A75-9BB0-0D023378592B_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\E2A4F912-2574-4A75-9BB0-0D023378592B_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.AAD.BrokerPlugin_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.AAD.BrokerPlugin_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.AAD.BrokerPlugin_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.AccountsControl_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.AccountsControl_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.AccountsControl_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.BingWeather_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.BingWeather_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.BingWeather_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.DesktopAppInstaller_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.DesktopAppInstaller_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.DesktopAppInstaller_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.GetHelp_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.GetHelp_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.GetHelp_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Getstarted_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Getstarted_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Getstarted_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Microsoft3DViewer_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Microsoft3DViewer_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Microsoft3DViewer_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MicrosoftOfficeHub_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MicrosoftOfficeHub_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MicrosoftOfficeHub_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MicrosoftSolitaireCollection_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MicrosoftSolitaireCollection_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MicrosoftSolitaireCollection_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MicrosoftStickyNotes_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MicrosoftStickyNotes_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MicrosoftStickyNotes_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MSPaint_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MSPaint_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.MSPaint_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Office.OneNote_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Office.OneNote_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Office.OneNote_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.People_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.People_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.People_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.ScreenSketch_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.ScreenSketch_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.ScreenSketch_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.SkypeApp_kzf8qxf38zg5c", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.SkypeApp_kzf8qxf38zg5c", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.SkypeApp_kzf8qxf38zg5c", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.StorePurchaseApp_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.StorePurchaseApp_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.StorePurchaseApp_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Wallet_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Wallet_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Wallet_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Win32WebViewHost_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Win32WebViewHost_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Win32WebViewHost_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.CapturePicker_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.CapturePicker_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.CapturePicker_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.CloudExperienceHost_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.CloudExperienceHost_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.CloudExperienceHost_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.OOBENetworkCaptivePortal_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.OOBENetworkCaptivePortal_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.OOBENetworkCaptivePortal_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.OOBENetworkConnectionFlow_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.OOBENetworkConnectionFlow_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.OOBENetworkConnectionFlow_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.Photos_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.Photos_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.Photos_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.Search_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.Search_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.Search_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.SecHealthUI_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.SecHealthUI_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.SecHealthUI_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.ShellExperienceHost_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.ShellExperienceHost_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.ShellExperienceHost_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.StartMenuExperienceHost_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.StartMenuExperienceHost_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Windows.StartMenuExperienceHost_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsAlarms_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsAlarms_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsAlarms_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsCalculator_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsCalculator_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsCalculator_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsCamera_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsCamera_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsCamera_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\microsoft.windowscommunicationsapps_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\microsoft.windowscommunicationsapps_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\microsoft.windowscommunicationsapps_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsFeedbackHub_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsFeedbackHub_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsFeedbackHub_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsMaps_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsMaps_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsMaps_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsSoundRecorder_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsSoundRecorder_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsSoundRecorder_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsStore_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsStore_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.WindowsStore_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Xbox.TCUI_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Xbox.TCUI_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.Xbox.TCUI_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxApp_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxApp_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxApp_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxGameCallableUI_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxGameCallableUI_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxGameCallableUI_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxGameOverlay_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxGameOverlay_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxGameOverlay_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxGamingOverlay_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxGamingOverlay_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxGamingOverlay_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxIdentityProvider_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxIdentityProvider_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxIdentityProvider_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxSpeechToTextOverlay_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxSpeechToTextOverlay_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.XboxSpeechToTextOverlay_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.YourPhone_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.YourPhone_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.YourPhone_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.ZuneMusic_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.ZuneMusic_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.ZuneMusic_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.ZuneVideo_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.ZuneVideo_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Microsoft.ZuneVideo_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\MicrosoftWindows.Client.CBS_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\MicrosoftWindows.Client.CBS_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\MicrosoftWindows.Client.CBS_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\MicrosoftWindows.UndockedDevKit_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\MicrosoftWindows.UndockedDevKit_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\MicrosoftWindows.UndockedDevKit_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\NcsiUwpApp_8wekyb3d8bbwe", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\NcsiUwpApp_8wekyb3d8bbwe", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\NcsiUwpApp_8wekyb3d8bbwe", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\windows.immersivecontrolpanel_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\windows.immersivecontrolpanel_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\windows.immersivecontrolpanel_cw5n1h2txyewy", true).SetValue("IgnoreBatterySaver", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Windows.PrintDialog_cw5n1h2txyewy", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\\Windows.PrintDialog_cw5n1h2txyewy", true).SetValue("DisabledByUser", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appDiagnostics", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appointments", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\bluetoothSync", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\broadFileSystemAccess", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\cellularData", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\chat", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\contacts", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\documentsLibrary", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\email", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\gazeInput", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\microphone\\Microsoft.Windows.Photos_8wekyb3d8bbwe", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\phoneCall", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\phoneCallHistory", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\picturesLibrary", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\radios", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userAccountInformation", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userDataTasks", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userNotificationListener", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\videosLibrary", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\webcam\\Microsoft.Windows.Photos_8wekyb3d8bbwe", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("ContentDeliveryAllowed", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("OemPreInstalledAppsEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("PreInstalledAppsEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("PreInstalledAppsEverEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("RotatingLockScreenEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("RotatingLockScreenOverlayEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SilentInstalledAppsEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SoftLandingEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-310093Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-314559Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-314563Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-338387Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-338388Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-338389Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-338393Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-353694Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-353696Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-353698Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContentEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SystemPaneSuggestionsEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", true).SetValue("SearchboxTaskbarMode", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", true).SetValue("BackgroundAppGlobalToggle", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", true).SetValue("CortanaEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", true).SetValue("DeviceHistoryEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", true).SetValue("HistoryViewEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("AllowCloudSearch", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("AllowSearchToUseLocation", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("AlwaysUseAutoLangDetection", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("BingSearchEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("ConnectedSearchPrivacy", "3", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("ConnectedSearchSafeSearch", "3", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("ConnectedSearchUseWeb", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("ConnectedSearchUseWebOverMeteredConnections", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("DisableWebSearch", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("PrimaryIntranetSearchScopeUrl", "http://www.google.com/search?q={searchTerms}", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", true).SetValue("SecondaryIntranetSearchScopeUrl", "https://duckduckgo.com/?kae=t&q={searchTerms}", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", true).SetValue("CortanaIsReplaceable", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", true).SetValue("DisableWebSearch", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings", true).SetValue("NOC_GLOBAL_SETTING_ALLOW_CRITICAL_TOASTS_ABOVE_LOCK", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings", true).SetValue("NOC_GLOBAL_SETTING_ALLOW_TOASTS_ABOVE_LOCK", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings\\Windows.SystemToast.SecurityAndMaintenance", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", true).SetValue("DatabaseMigrationCompleted", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", true).SetValue("LockScreenToastEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", true).SetValue("ToastEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", true).SetValue("NoTileApplicationNotification", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", true).SetValue("NoToastApplicationNotification", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", true).SetValue("NoToastApplicationNotificationOnLockScreen", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows Defender Security Center\\Virus and threat protection", true).SetValue("SummaryNotificationDisabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\MRT", true).SetValue("DoNotShowFeedbackNotifications", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\MRT", true).SetValue("DontOfferThroughWUAU", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\MRT", true).SetValue("DontReportInfectionInformation", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Speech", true).SetValue("AllowSpeechModelUpdate", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableSoftLanding", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableWindowsConsumerFeatures", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableWindowsSpotlightFeatures", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true).SetValue("CallLegacyWCMPolicies", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Cache", true).SetValue("Persistent", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", true).SetValue("NoCloudApplicationNotification", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppHost", true).SetValue("EnableWebContentEvaluation", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization\\Config", true).SetValue("DODownloadMode", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization\\Settings", true).SetValue("DownloadMode", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("AllowBuildPreview", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("AllowCommercialDataPipeline", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("AllowDeviceNameInTelemetry", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("AllowTelemetry", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("DisableEnterpriseAuthProxy", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("DisableTelemetryOptInChangeNotification", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("DisableTelemetryOptInSettingsUx", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("DoNotShowFeedbackNotifications", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("LimitEnhancedDiagnosticDataWindowsAnalytics", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("MaxTelemetryAllowed", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("MicrosoftEdgeDataOptIn", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection", true).SetValue("AllowTelemetry", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\TextInput", true).SetValue("AllowLanguageFeaturesUninstall", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\TextInput", true).SetValue("AllowLinguisticDataCollection", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Privacy", true).SetValue("TailoredExperiencesWithDiagnosticDataEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SmartGlass", true).SetValue("UserAuthPolicy", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Spectrum", true).SetValue("SharedExperiencesEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\WUDF", true).SetValue("LogLevel", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\WlanSvc\\AnqpCache", true).SetValue("OsuRegistrationStatus", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\AppHVSI", true).SetValue("AllowAppHVSI_ProviderSet", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\AppHVSI", true).SetValue("AuditApplicationGuard", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Biometrics", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Biometrics\\Credential Provider", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\EventViewer", true).SetValue("MicrosoftEventVwrDisableLinks", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Explorer\\AutoComplete", true).SetValue("AutoSuggest", "no", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\FVE", true).SetValue("DisableExternalDMAUnderLock", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\TabletTip\\1.7", true).SetValue("EnableAutocorrection", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\TabletTip\\1.7", true).SetValue("EnableDoubleTapSpace", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\TabletTip\\1.7", true).SetValue("EnableInkingWithTouch", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\TabletTip\\1.7", true).SetValue("EnablePredictionSpaceInsertion", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\TabletTip\\1.7", true).SetValue("EnableSpellchecking", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\TabletTip\\1.7", true).SetValue("EnableTextPrediction", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Siuf\\Rules", true).SetValue("NumberOfSIUFInPeriod", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Siuf\\Rules", true).SetValue("PeriodInNanoSeconds", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppHost", true).SetValue("EnableWebContentEvaluation", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Authentication\\LogonUI\\AccessPage\\Camera", true).SetValue("CameraEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Input\\Settings", true).SetValue("EnableHwkbAutocorrection", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Input\\Settings", true).SetValue("EnableHwkbTextPrediction", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Input\\Settings", true).SetValue("InsightsEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Input\\Settings", true).SetValue("MultilingualEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Input\\TIPC", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Narrator\\NoRoam", true).SetValue("WinEnterLaunchEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Personalization\\Settings", true).SetValue("RestrictImplicitInkCollection", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\LooselyCoupled", true).SetValue("InitialAppValue", "Unspecified", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\LooselyCoupled", true).SetValue("Type", "InterfaceClass", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\LooselyCoupled", true).SetValue("Value", "Deny", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PenWorkspace", true).SetValue("PenWorkspaceAppSuggestionsEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Privacy", true).SetValue("TailoredExperiencesWithDiagnosticDataEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SmartGlass", true).SetValue("PenWorkspaceAppSuggestionsEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UserProfileEngagement", true).SetValue("ScoobeSystemSettingEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Assistance\\Client\\1.0", true).SetValue("NoExplicitFeedback", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Assistance\\Client\\1.0", true).SetValue("NoImplicitFeedback", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Assistance\\Client\\1.0", true).SetValue("NoOnlineAssist", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Messenger\\Client", true).SetValue("CEIP", "2", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat", true).SetValue("DisablePCA", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Input\\Settings", true).SetValue("InsightsEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Input\\Settings", true).SetValue("PredictionDisabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Input\\Settings", true).SetValue("UserStatsEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Input\\TIPC", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Speech_OneCore\\Preferences", true).SetValue("ModelDownloadAllowed", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\TabletTip\\1.7", true).SetValue("EnableDoubleTapSpace", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\TabletTip\\1.7", true).SetValue("EnablePredictionSpaceInsertion", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\TabletTip\\1.7", true).SetValue("EnableTextPrediction", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Tracing", true).SetValue("EnableAutoFileTracing", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Tracing", true).SetValue("EnableFileTracing", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsInkWorkspace", true).SetValue("AllowSuggestedAppsInWindowsInkWorkspace", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\WindowsInkWorkspace", true).SetValue("AllowSuggestedAppsInWindowsInkWorkspace", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\WindowsInkWorkspace", true).SetValue("AllowWindowsInkWorkspace", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Remote Assistance", true).SetValue("fAllowToGetHelp", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\HandwritingErrorReports", true).SetValue("PreventHandwritingErrorReports", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\LocationAndSensors", true).SetValue("DisableLocation", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\LocationAndSensors", true).SetValue("DisableLocationScripting", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\LocationAndSensors", true).SetValue("DisableSensors", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\LocationAndSensors", true).SetValue("DisableWindowsLocationProvider", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Maps", true).SetValue("AllowUntriggeredNetworkTrafficOnSettingsPage", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Maps", true).SetValue("AutoDownloadAndUpdateMapData", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\Maps", true).SetValue("AutoUpdateEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Messaging", true).SetValue("AllowMessageSync", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\NetCache", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Network Connections", true).SetValue("NC_ShowSharedAccessUI", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("AllowTelemetry", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Personalization", true).SetValue("NoLockScreen", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Personalization", true).SetValue("NoLockScreenCamera", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\PreviewBuilds", true).SetValue("AllowBuildPreview", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\PreviewBuilds", true).SetValue("EnableConfigFlighting", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Registration Wizard Control", true).SetValue("NoRegistration", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\ScheduledDiagnostics", true).SetValue("EnabledExecution", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Schedule\\Maintenance", true).SetValue("MaintenanceDisabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Sensor\\Overrides\\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}", true).SetValue("SensorPermissionState", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("AllowOnlineTips", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("HideSCAHealth", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("HideSCAMeetNow", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoInstrumentation", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", true).SetValue("AicEnabled", "Anywhere", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", true).SetValue("GlobalAssocChangedCounter", "15", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", true).SetValue("SmartScreenEnabled", "Off", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("ShowSyncProviderNotifications", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FlyoutMenuSettings", true).SetValue("ShowHibernateOption", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FlyoutMenuSettings", true).SetValue("ShowLockOption", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FlyoutMenuSettings", true).SetValue("ShowSleepOption", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Serialize", true).SetValue("StartupDelayInMSec", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("ClearTilesOnExit", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("DisableNotificationCenter", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("DisableSearchBoxSuggestions", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("EnableLegacyBalloonNotifications", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("HidePeopleBar", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("HideSCAHealth", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("NoAutoTrayNotify", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("NoBalloonFeatureAdvertisements", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("NoDataExecutionPrevention", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("NoHeapTerminationOnCorruption", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("NoNewAppAlert", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("ShowHibernateOption", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", true).SetValue("link", new byte[4], RegistryValueKind.Binary);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("DisallowShaking", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("DontPrettyPath", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("EnableBalloonTips", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("FolderContentsInfoTip", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("HideFileExt", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("ListviewShadow", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("NoStartMenuHelp", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("SharingWizardOn", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("ShowCompColor", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("ShowCortanaButton", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("ShowEncryptCompressedColor", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("ShowInfoTip", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("ShowSyncProviderNotifications", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("ShowTaskViewButton", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("StartButtonBalloonTip", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("Start_ShowHelp", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("Start_TrackDocs", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("Start_TrackProgs", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("TaskbarAnimations", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("TaskbarAppsVisibleInTabletMode", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("TaskbarAutoHideInTabletMode", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("UseOLEDTaskbarTransparency", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\People", true).SetValue("PeopleBand", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\People", true).SetValue("TaskbarCapacity", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MultitaskingView\\AllUpView", true).SetValue("AllUpView", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MultiTaskingView\\AllUpView", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MultitaskingView\\AllUpView", true).SetValue("Remove TaskView", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("HideSCAMeetNow", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("LinkResolveIgnoreLinkInfo", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoCDBurning", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoDriveTypeAutoRun", "255", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoInternetOpenWith", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoLowDiskSpaceChecks", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoNetConnectDisconnect", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoOnlinePrintsWizard", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoPublishingWizard", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoResolveSearch", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoResolveTrack", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoWebServices", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ImmersiveShell\\EdgeUi", true).SetValue("AllowEdgeSwipe", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ImmersiveShell\\EdgeUi", true).SetValue("CharmsBarDesktopDelay", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ImmersiveShell\\EdgeUi", true).SetValue("CharmsBarImmersiveDelay", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ImmersiveShell\\EdgeUi", true).SetValue("DisableCharms", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ImmersiveShell\\EdgeUi", true).SetValue("DisableMFUTracking", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ImmersiveShell\\EdgeUi", true).SetValue("DisableRecentApps", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ImmersiveShell\\EdgeUi", true).SetValue("DisableTLCorner", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ImmersiveShell\\EdgeUi", true).SetValue("DisableTRCorner", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ImmersiveShell\\EdgeUi", true).SetValue("TurnOffBackstack", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\EdgeUI", true).SetValue("DisableHelpSticker", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\EdgeUI", true).SetValue("DisableMFUTracking", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\EdgeUI", true).SetValue("DisableHelpSticker", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableApplicationSettingSync", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableApplicationSettingSyncUserOverride", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableCredentialsSettingSync", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableCredentialsSettingSyncUserOverride", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableDesktopThemeSettingSync", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableDesktopThemeSettingSyncUserOverride", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisablePersonalizationSettingSync", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisablePersonalizationSettingSyncUserOverride", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableSettingSync", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableSettingSyncUserOverride", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableStartLayoutSettingSync", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableStartLayoutSettingSyncUserOverride", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableSyncOnPaidNetwork", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableWebBrowserSettingSync", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableWebBrowserSettingSyncUserOverride", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableWindowsSettingSync", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableWindowsSettingSyncUserOverride", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("EnableBackupForWin8Apps", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync", true).SetValue("SyncPolicy", "5", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\Accessibility", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\AppSync", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\BrowserSettings", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\Credentials", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\Language", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\Personalization", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\Windows", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("EnableWindowColorization", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("ColorizationGlassAttribute", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("ColorPrevalence", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("AlwaysHibernateThumbnails", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("Animations", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("Blur", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("EnableAeroPeek", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true).SetValue("AppsUseLightTheme", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true).SetValue("ColorPrevalence", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true).SetValue("EnableTransparency", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true).SetValue("SystemUseLightTheme", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true).SetValue("SystemUsesLightTheme", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\Dwm", true).SetValue("AnimationAttributionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\Dwm", true).SetValue("AnimationAttributionHashingEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\Dwm", true).SetValue("EnableDesktopOverlays", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\Dwm\\ExtendedComposition", true).SetValue("ExclusiveModeFramerateAveragingPeriodMs", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\Dwm\\ExtendedComposition", true).SetValue("ExclusiveModeFramerateThresholdPercent", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("AnimationAttributionEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("Composition", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("CompositionPolicy", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("DisableHologramCompositor", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("DisallowAnimations", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("DisallowFlip3d", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("DWMWA_TRANSITIONS_FORCEDISABLED", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("Composition", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("OverlayTestMode", "5", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-AppV-Client/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-AppV-Client/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-AppV-Client/Virtual Applications", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Client-Licensing-Platform/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-AAD/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Application-Experience/Program-Compatibility-Assistant", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Application-Experience/Program-Compatibility-Troubleshooter", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Application-Experience/Program-Inventory", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Application-Experience/Program-Telemetry", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Application-Experience/Steps-Recorder", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-AppLocker/EXE and DLL", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-AppLocker/MSI and Script", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-AppLocker/Packaged app-Deployment", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-AppLocker/Packaged app-Execution", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-AppModel-Runtime/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-AppReadiness/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-AppReadiness/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-BackgroundTaskInfrastructure/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Bits-Client/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Bluetooth-BthLEPrepairing/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Bluetooth-MTPEnum/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-CertificateServicesClient-Lifecycle-System/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-CertificateServicesClient-Lifecycle-User/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Cleanmgr/Diagnostic", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-CloudStore/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-CodeIntegrity/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Containers-BindFlt/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Containers-Wcifs/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Containers-Wcnfs/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-CorruptedFileRecovery-Client/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-CorruptedFileRecovery-Server/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Crypto-DPAPI/BackUpKeySvc", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Crypto-DPAPI/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Crypto-NCrypt/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-DAL-Provider/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-DataIntegrityScan/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-DataIntegrityScan/CrashRecovery", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-DateTimeControlPanel/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-DeviceSetupManager/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-DeviceSetupManager/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-DeviceSync/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-DeviceUpdateAgent/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Dhcpv6-Client/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Diagnosis-DPS/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Diagnosis-PCW/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Diagnosis-PLA/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Diagnosis-Scheduled/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Diagnosis-ScriptedDiagnosticsProvider/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Diagnosis-Scripted/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Diagnosis-Scripted/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-DiskDiagnosticDataCollector/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-DiskDiagnostic/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-DiskDiagnosticResolver/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-DSC/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-DSC/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-EapHost/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-EapMethods-RasChap/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-EapMethods-RasTls/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-EapMethods-Sim/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-EapMethods-Ttls/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-FMS/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Folder Redirection/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Forwarding/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-GenericRoaming/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-GroupPolicy/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-HelloForBusiness/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Help/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-HomeGroup Control Panel/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Hyper-V-Hypervisor-Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Hyper-V-Hypervisor-Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Hyper-V-VID-Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-IdCtrls/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-IKE/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-International-RegionalOptionsControlPanel/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Iphlpsvc/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-IPxlatCfg/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-KdsSvc/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Kernel-ApphelpCache/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Kernel-LiveDump/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Kernel-PnP/Configuration", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Kernel-PnP/Driver Watchdog", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Kernel-Power/Thermal-Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Kernel-ShimEngine/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Kernel-StoreMgr/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Kernel-WDI/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Kernel-WHEA/Errors", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Kernel-WHEA/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Known Folders API Service", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-LanguagePackSetup/Analytic", true).SetValue("Enabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-LanguagePackSetup/Debug", true).SetValue("Enabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-LiveId/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-ModernDeployment-Diagnostics-Provider/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-ModernDeployment-Diagnostics-Provider/Autopilot", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-ModernDeployment-Diagnostics-Provider/ManagementService", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-MUI/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-MUI/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-NcdAutoSetup/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-NCSI/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-NlaSvc/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Ntfs/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Ntfs/WHC", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-NTLM/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-OneBackup/Debug", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-OOBE-Machine-DUI/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-PackageStateRoaming/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-PersistentMemory-Nvdimm/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-PersistentMemory-PmemDisk/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-PersistentMemory-ScmBus/Certification", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-PersistentMemory-ScmBus/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Policy/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-PowerShell-DesiredStateConfiguration-FileDownloadManager/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-PrintBRM/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Privacy-Auditing/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Program-Compatibility-Assistant/CompatAfterUpgrade", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-PushNotification-Platform/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-PushNotification-Platform/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-ReFS/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-SearchUI/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Security-Adminless/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Security-Audit-Configuration-Client/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Security-EnterpriseData-FileRevocationManager/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Security-LessPrivilegedAppContainer/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Security-Mitigations/KernelMode", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Security-Mitigations/UserMode", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Security-Netlogon/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Security-SPP-UX-GenuineCenter-Logging/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Security-SPP-UX-Notifications/ActionCenter", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Security-UserConsentVerifier/Audit", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-SecurityMitigationsBroker/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Shell-Core/ActionCenter", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Shell-Core/LogonTasksChannel", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-ShellCommon-StartLayoutPopulation/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-SmbClient/Audit", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-SmbClient/Connectivity", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-SMBClient/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-SmbClient/Security", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-SMBServer/Audit", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-SMBServer/Connectivity", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-SMBServer/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-SMBServer/Security", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-SMBWitnessClient/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-SMBWitnessClient/Informational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Storage-ClassPnP/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Storage-Storport/Health", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Storage-Storport/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-StorageSettings/Diagnostic", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Storsvc/Diagnostic", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-TaskScheduler/Maintenance", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-TerminalServices-ClientUSBDevices/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-TerminalServices-ClientUSBDevices/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-TerminalServices-LocalSessionManager/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-TerminalServices-LocalSessionManager/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Time-Service-PTP-Provider/PTP-Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Time-Service/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-TWinUI/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-TZSync/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-TZUtil/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-UAC-FileVirtualization/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-User-Loader/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-User Device Registration/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-UserPnp/ActionCenter", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-VerifyHardwareSecurity/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-VHDMP-Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-VolumeSnapshot-Driver/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-VPN/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Wcmsvc/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-WebAuthN/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-WFP/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-WindowsUpdateClient/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-WinINet-Config/ProxyConfigChanged", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Winlogon/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Winsock-WS2HELP/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-WMI-Activity/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-Workplace Join/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-WPD-ClassInstaller/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-WPD-CompositeClassDriver/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\Microsoft-Windows-WPD-MTPClassDriver/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\OpenSSH/Admin", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\OpenSSH/Operational", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WINEVT\\Channels\\SMSApi", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\CompatTelRunner.exe", true).SetValue("Debugger", Utils.WinDrive + "Windows\\System32\\taskkill.exe", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\csrss.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "4", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\csrss.exe\\PerfOptions", true).SetValue("IoPriority", "3", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\dwm.exe\\PerfOptions", true).SetValue("IoPriority", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\EpicWebHelper.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\EpicWebHelper.exe\\PerfOptions", true).SetValue("IoPriority", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\EpicWebHelper.exe\\PerfOptions", true).SetValue("PagePriority", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\GameOverlayUI.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\GameOverlayUI.exe\\PerfOptions", true).SetValue("IoPriority", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\GameOverlayUI.exe\\PerfOptions", true).SetValue("PagePriority", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\OriginWebHelperService.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\OriginWebHelperService.exe\\PerfOptions", true).SetValue("IoPriority", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\OriginWebHelperService.exe\\PerfOptions", true).SetValue("PagePriority", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\QtWebEngineProcess.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\QtWebEngineProcess.exe\\PerfOptions", true).SetValue("IoPriority", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\QtWebEngineProcess.exe\\PerfOptions", true).SetValue("PagePriority", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\RiotClientCrashHandler.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\RiotClientCrashHandler.exe\\PerfOptions", true).SetValue("IoPriority", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\RiotClientCrashHandler.exe\\PerfOptions", true).SetValue("PagePriority", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\RiotClientUx.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\RiotClientUx.exe\\PerfOptions", true).SetValue("IoPriority", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\RiotClientUx.exe\\PerfOptions", true).SetValue("PagePriority", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\RiotClientUxRender.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\RiotClientUxRender.exe\\PerfOptions", true).SetValue("IoPriority", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\RiotClientUxRender.exe\\PerfOptions", true).SetValue("PagePriority", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\SteamService.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\SteamService.exe\\PerfOptions", true).SetValue("IoPriority", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\SteamService.exe\\PerfOptions", true).SetValue("PagePriority", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\steamwebhelper.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\steamwebhelper.exe\\PerfOptions", true).SetValue("IoPriority", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\steamwebhelper.exe\\PerfOptions", true).SetValue("PagePriority", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\SystemSettings.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\SystemSettings.exe\\PerfOptions", true).SetValue("IoPriority", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\SystemSettings.exe\\PerfOptions", true).SetValue("PagePriority", "5", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\UplayWebCore.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\UplayWebCore.exe\\PerfOptions", true).SetValue("IoPriority", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\UplayWebCore.exe\\PerfOptions", true).SetValue("PagePriority", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\vgtray.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\vgtray.exe\\PerfOptions", true).SetValue("IoPriority", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\vgtray.exe\\PerfOptions", true).SetValue("PagePriority", "2", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", true).SetValue("AlwaysOn", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", true).SetValue("LazyModeTimeout", "150000", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", true).SetValue("NoLazyMode", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", true).SetValue("Priority", "6", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\PriorityControl", true).SetValue("Win32PrioritySeparation", "38", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\OOBE", true).SetValue("DisablePrivacyExperience", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\OOBE", true).SetValue("DisableVoice", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\OOBE", true).SetValue("EnableCortanaVoice", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\OOBE", true).SetValue("HideEULAPage", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\OOBE", true).SetValue("HideLocalAccountScreen", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\OOBE", true).SetValue("HideOEMRegistrationScreen", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\OOBE", true).SetValue("HideOnlineAccountScreens", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\OOBE", true).SetValue("HideWirelessSetupInOOBE", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\OOBE", true).SetValue("SkipMachineOOBE", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\OOBE", true).SetValue("SkipUserOOBE", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("ConsentPromptBehaviorAdmin", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("DisableAutomaticRestartSignOn", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("DisableStartupSound", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("EnableInstallerDetection", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("EnableLUA", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("EnableSecureUIAPaths", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("EnableVirtualization", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("LocalAccountTokenFilterPolicy", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("PromptOnSecureDesktop", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("VerboseStatus", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("AllowBlockingAppsAtShutdown", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("AllowCrossDeviceClipboard", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("DisableAcrylicBackgroundOnLogon", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("DisableHHDEP", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("DisableLockScreenAppNotifications", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("DisableLogonBackgroundImage", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("DontDisplayNetworkSelectionUI", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("EnableActivityFeed", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("EnableCdp", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("EnableMmx", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("EnableSmartScreen", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("HiberbootEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("NoLocalPasswordResetQuestions", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("PublishUserActivities", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("ShellSmartScreenLevel", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("Start", "Warn", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("UploadUserActivities", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WcmSvc\\Local", true).SetValue("WCMPresent", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WCN\\UI", true).SetValue("DisableWcnUi", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\FeatureManagement\\Overrides\\4\\4095660171", true).SetValue("EnabledState", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Power\\PowerSettings\\94ac6d29-73ce-41a6-809f-6363ba21b47e", true).SetValue("ACSettingIndex", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power\\ModernSleep", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power\\PowerSettings\\54533251-82be-4824-96c1-47b60b740d00\\5d76a2ca-e8c0-402f-a133-2158492d58ad", true).SetValue("Attributes", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("CsEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("DisableSensorWatchdog", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("DisableVsyncLatencyUpdate", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("EnergyEstimationEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("EventProcessorEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("HibernateEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("HibernateEnabledDefault", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("QosManagesIdleProcessors", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("SleepReliabilityDetailedDiagnostics", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("SleepStudyDisabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power\\EnergyEstimation\\TaggedEnergy", true).SetValue("DisableTaggedEnergyLogging", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power\\EnergyEstimation\\TaggedEnergy", true).SetValue("TelemetryMaxApplication", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power\\EnergyEstimation\\TaggedEnergy", true).SetValue("TelemetryMaxTagPerApplication", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power", true).SetValue("HiberbootEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power", true).SetValue("HibernateEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power", true).SetValue("SleepStudyDisabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Lsa", true).SetValue("LsaCfgFlags", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard", true).SetValue("EnableVirtualizationBasedSecurity", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard", true).SetValue("Locked", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard", true).SetValue("RequirePlatformSecurityFeatures", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios", true).SetValue("HypervisorEnforcedCodeIntegrity", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity", true).SetValue("HVCIMATRequired", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity", true).SetValue("Locked", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DeviceGuard", true).SetValue("DeployConfigCIPolicy", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DeviceGuard", true).SetValue("EnableVirtualizationBasedSecurity", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DeviceGuard", true).SetValue("HVCIMATRequired", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DeviceGuard", true).SetValue("HypervisorEnforcedCodeIntegrity", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DeviceGuard", true).SetValue("LsaCfgFlags", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments", true).SetValue("SaveZoneInformation", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments", true).SetValue("ScanWithAntiVirus", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\ScheduledDiagnostics", true).SetValue("EnabledExecution", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WDI\\{9c5a40da-b965-4fc3-8781-88dd50a6299d}", true).SetValue("ScenarioExecutionEnabled", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\HandwritingErrorReports", true).SetValue("PreventHandwritingErrorReports", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Network Connections", true).SetValue("NC_ShowSharedAccessUI", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\Driver Signing", true).SetValue("BehaviorOnFailedVerify", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\StorageSense", true).SetValue("AllowStorageSenseGlobal", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\FTH", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters", true).SetValue("EnableBootTrace", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters", true).SetValue("EnablePrefetcher", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters", true).SetValue("EnableSuperfetch", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters", true).SetValue("WaitToKillServiceTimeout", "2000", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\FileSystem", true).SetValue("DontVerifyRandomDrivers", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\FileSystem", true).SetValue("NtfsDisable8dot3NameCreation", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\FileSystem", true).SetValue("SuppressInheritanceSupport", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control", true).SetValue("WaitToKillServiceTimeout", "2000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Policies\\Microsoft\\Windows\\Network Connections", true).SetValue("NC_ShowSharedAccessUI", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("DisableExceptionChainValidation", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("DpcQueueDepth", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("DpcWatchdogPeriod", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("DpcWatchdogProfileOffset", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("EAFWatchdogEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("EAFModules", "", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("ForceIdleGracePeriod", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("InterruptSteeringDisabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("KernelSEHOPEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Executive", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power\\ModernSleep", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).DeleteValue("DisablePagingCombining", false);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).DeleteValue("DisablePagingExecutive", false);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).DeleteValue("LargeSystemCache", false);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("ApplicationFrameHost.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("csrss.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("ctfmon.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("dllhost.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("dwm.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("explorer.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("fontdrvhost.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("lsass.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("ntoskrnl.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("NVDisplay.Container.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("RuntimeBroker.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("SearchApp.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("SearchIndexer.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("services.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("ShellExperienceHost.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("sihost.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("smss.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("sppsvc.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("StartMenu.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("StartMenuExperienceHost.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("svchost.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("TextInputHost.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("wininit.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("winlogin.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\MitigationOptions\\ProcessMitigationOptions", true).SetValue("WmiPrvSE.exe", "00000000000000000000000000000000", RegistryValueKind.String);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("FeatureSettings", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("FeatureSettingsOverride", "3", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("FeatureSettingsOverrideMask", "3", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("EnableCfg", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager", true).SetValue("ProtectionMode", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\SCMConfig", true).SetValue("EnableSvchostMitigationPolicy", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\AppModel", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\AutoLogger-Diagtrack-Listener", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\AutoLogger-Diagtrack-Listener", true).SetValue("Status", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\Cellcore", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\Circular Kernel Context Logger", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\CloudExperienceHostOobe", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\DefenderApiLogger", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\DefenderAuditLogger", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\DiagLog", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\EventLog-System\\{1b562e86-b7aa-4131-badc-b6f3a001407e}", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\iclsClient", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\iclsProxy", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\LwtNetLog", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\MellanoxSoftware\\Microsoft\\Windows NT\\CurrentVersion\\SPP\\Clients-Kernel", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\Microsoft-Windows-Rdp-Graphics-RdpIdd-Trace", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\NtfsLog", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\SocketHeciServer", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\Tpm", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\TPMProvisioningService", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\UBPM", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\WdiContextLog", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\WiFiDriverIHVSession", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\WiFiSession", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\WinPhoneCritical", true).SetValue("Start", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\DNSClient", true).SetValue("DisableSmartNameResolution", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\DNSClient", true).SetValue("EnableMulticast", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Psched", true).SetValue("TimerResolution", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\LanmanWorkstation\\Parameters", true).SetValue("DisableBandwidthThrottling", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\NDIS\\Parameters", true).SetValue("DebugLoggingMode", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\NDIS\\Parameters", true).SetValue("DisableNDISWatchDog", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\NDIS\\Parameters", true).SetValue("DisableWDIWatchdogForceBugcheck", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\NDIS\\Parameters", true).SetValue("DmaRemappingCompatible", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\NDIS\\Parameters", true).SetValue("EnableNicAutoPowerSaverInSleepStudy", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\NDIS\\Parameters", true).SetValue("ForceLogsInMiniDump", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\NDIS\\Parameters", true).SetValue("ImplicitPowerRefManagement", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\NDIS\\Parameters", true).SetValue("LogPages", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\NDIS\\Parameters", true).SetValue("TrackNblOwner", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\Spooler\\Performance", true).SetValue("Disable Performance Counters", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\WinSock2\\Parameters", true).SetValue("Ws2_32NumHandleBuckets", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\stornvme\\Parameters\\Device", true).SetValue("ContiguousMemoryFromAnyNode", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\stornvme\\Parameters\\Device", true).SetValue("DiagnosticFlags", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\stornvme\\Parameters\\Device", true).SetValue("IdlePowerMode", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\stornvme\\Parameters\\Device", true).SetValue("LogSize", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate", true).SetValue("NoAutoUpdate", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU", true).SetValue("NoAutoUpdate", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings", true).SetValue("ExcludeWUDriversInQualityUpdate", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DriverSearching", true).SetValue("SearchOrderConfig", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\WindowsStore", true).SetValue("DisableOSUpgrade", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching", true).SetValue("DontPromptForWindowsUpdate", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching", true).SetValue("DontSearchWindowsUpdate", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DriverSearching", true).SetValue("SearchOrderConfig", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Device Metadata", true).SetValue("PreventDeviceMetadataFromNetwork", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DriverSearching", true).SetValue("SearchOrderConfig", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DeviceInstall\\Settings", true).SetValue("DisableSendGenericDriverNotFoundToWER", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DeviceInstall\\Settings", true).SetValue("DisableSendRequestAdditionalSoftwareToWER", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Device Metadata", true).SetValue("PreventDeviceMetadataFromNetwork", "1", RegistryValueKind.DWord);
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0003C4C8 File Offset: 0x0003A6C8
		public static void FGA()
		{
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("AsicOnLowPower", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("BGM_EnableLTR", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("ChillEnabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("DalDisableCursorCache", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("DalDisableCursorCaching", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("DalDisableStutter", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("DalPowerGatingLb", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("DalPowerGatingPipe", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("Disable2560", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("DisableBlockWrite", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("DisableDMACopy", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("DisableSWInterrupt", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("DisableTiling", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("EnableUlps", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("EnableUlps_NA", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("ExtendedPowerControl", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("FastZClearEnabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("GCOOPTION_DisableGPIOPowerSaveMode", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("KD_TilingMode", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("KMD_DeLagEnabled", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("KMD_EnableComputePreemption", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("KMD_EnableContextBasedPowerManagement", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("KMD_EnableGfxMidCmdPreemption", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("KMD_EnableP2PIOWriteCombineWorkaround", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("KMD_EnablePreemptionLogging", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("KMD_EnableSDMAPreemption", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("KMD_LogLevel_DOPP", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("KMD_LogLevel_SDI", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("PCIEPowerControl", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("PP_DisablePowerContainment", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("PP_EnableChillOptimization", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("PP_GPUPowerDownEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("PP_SclkDeepSleepDisable", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("PP_ThermalAutoThrottlingEnable", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("PP_ULPSDelayIntervalInMilliSeconds", 268435456, RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("RMGpcTileMap", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("RMHdcpKeyglobZero", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("RMJTPowerControl", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000").SetValue("StutterMode", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").SetValue("AAF_NA", "0");
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD");
			string name = "ACE";
			byte[] array = new byte[2];
			array[0] = 49;
			registryKey.SetValue(name, array, RegistryValueKind.Binary);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").SetValue("AntiAlias_NA", "0");
			RegistryKey registryKey2 = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD");
			string name2 = "AntiStuttering";
			byte[] array2 = new byte[2];
			array2[0] = 49;
			registryKey2.SetValue(name2, array2, RegistryValueKind.Binary);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").SetValue("AreaAniso_NA", "0");
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").SetValue("ASTT_DEF", "0");
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").SetValue("ATMS_NA", "0");
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").SetValue("CFM_DEF", "1");
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").SetValue("EQAA_DEF", "0");
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").SetValue("GI_DEF", "1");
			RegistryKey registryKey3 = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD");
			string name3 = "Main3D";
			byte[] array3 = new byte[2];
			array3[0] = 48;
			registryKey3.SetValue(name3, array3, RegistryValueKind.Binary);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").SetValue("Main3D_DEF", "0");
			RegistryKey registryKey4 = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD");
			string name4 = "ShaderCache";
			byte[] array4 = new byte[2];
			array4[0] = 50;
			registryKey4.SetValue(name4, array4, RegistryValueKind.Binary);
			RegistryKey registryKey5 = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD");
			string name5 = "Tessellation";
			byte[] array5 = new byte[4];
			array5[0] = 54;
			array5[2] = 52;
			registryKey5.SetValue(name5, array5, RegistryValueKind.Binary);
			RegistryKey registryKey6 = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD");
			string name6 = "Tessellation_OPTION";
			byte[] array6 = new byte[2];
			array6[0] = 50;
			registryKey6.SetValue(name6, array6, RegistryValueKind.Binary);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").SetValue("TextureLod_DEF", "3");
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD").SetValue("TextureLod_NA", "3");
			RegistryKey registryKey7 = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\UMD");
			string name7 = "VSyncControl";
			byte[] array7 = new byte[2];
			array7[0] = 48;
			registryKey7.SetValue(name7, array7, RegistryValueKind.Binary);
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0003CC1C File Offset: 0x0003AE1C
		public static void FGN()
		{
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("AllowTiledDisplayOverride", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("AslmCfg", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("AudioTimer", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("ComputePreemptionLevel", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("DCPerfLimitNonSLI", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("DisablePreemption", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("DisableWriteCombining", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("DISABLE_DSC", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("EnableAdaptiveSync", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("EnableBugcheckDisplay", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("EnableCheckSyncPolarity", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("EnableCoprocPowerControl", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("EnableCrossFunctionPowerTracking", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("EnableNonContiguousSVM", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("EnablePerformanceMode", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("EnableRuntimePowerManagement", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("EnableSystemMemoryTiling", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("EnableTiledDisplay", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("ExtendedPowerControl", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("GlitchFreeMClk", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("GpuPreemptionLevel", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("KMD51487632904", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("PCIEPowerControl", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("PCIEPowerControl_8086191f50001458", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("PCIEPowerControl_8086590f79961462_10de1c828c961462", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("PowerSaverHsyncOn", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("PowerSavingTweaks", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("PreferSystemMemoryContiguous", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("PreferSystemMemoryScratch", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("ReportPageFaultInterrupt", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("RM545179", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("Rm719476", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("Rm1536122", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("RmClkPowerOffDramPllWhenUnused", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("RMDeepL1EntryLatencyUsec", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("RMDisableGpuASPMFlags", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("RmDisableHdcp22", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("RmDisableHwFaultBuffer", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("RMDisableNoncontigAlloc", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("RMEnableL1ECC", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("RMEnableSHMECC", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("RMEnableSMECC", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("RMGpcTileMap", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("RMGpcTileMap", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("RMHdcpKeyglobZero", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("RMJTPowerControl", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("RmMIONoPowerOff", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("RMNoECCFBScrub", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("RmSkipHdcp22Init", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("SKIP_POWEROFF_EDP_IN_HEAD_DETACH", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", true).SetValue("TrackResetEngine", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", true).SetValue("ValidateBlitSubRects", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers", true).SetValue("DisableBadDriverCheckForHwProtection", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("AllowdGPUPassthrough", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("AllowTiledDisplayOverride", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("BuffersInFlight", "32", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("ComputePreemption", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("DisableBugcheckCallback", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("DisableCudaContextPreemption", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("DisablePreemption", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("DisablePreemptionOnS3S4", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("DisableWriteCombining", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableAsyncMidBufferPreemption", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableCEPreemption", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableCrossAdapterResource", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableMidBufferPreemption", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableMidGfxPreemption", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableMidGfxPreemptionVGPU", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnablePageFaultDebugOutput", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnablePerformanceMode", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableRuntimePowerManagement", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\nvlddmkm", true).SetValue("EnableSCGMidBufferPreemption", "0", RegistryValueKind.DWord);
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
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\nvidiaProfileInspector.exe", "https://cdn.discordapp.com/attachments/1258236120354000896/1258236830747332639/nvidiaProfileInspector.exe?ex=66874fdd&is=6685fe5d&hm=980229a3694d106fb5648b0c43f99e1bd2f2a4eb8d28253d0b7f2af529e28867&");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\Reference.xml", "https://cdn.discordapp.com/attachments/1258236120354000896/1258236906257383504/Reference.xml?ex=66874fef&is=6685fe6f&hm=36449bc648b54fc1e7e9799369d8b94dd6eab9353ae7c08a7f8bf8ef010f636c&");
			new WebClient
			{
				Headers = 
				{
					"User-Agent: Other"
				}
			}.DownloadFile("https://cdn.discordapp.com/attachments/1258236120354000896/1258237141461241917/Profile.nip?ex=66875027&is=6685fea7&hm=80572829b6006a9b5395948fec9211d37a62ae745db3e877096a17ea9e0907dd&", Utils.AppData + "\\Felipe\\Profile.nip");
			Utils.ExecuteProcess("\"" + Utils.AppData + "\\Felipe\\nvidiaProfileInspector.exe\"", "\"" + Utils.AppData + "\\Felipe\\Profile.nip\"", true, false);
		}

		// Token: 0x040000F2 RID: 242
		public static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

		// Token: 0x040000F3 RID: 243
		public static readonly string WinDrive = Path.GetPathRoot(Environment.SystemDirectory);

		// Token: 0x040000F4 RID: 244
		public static readonly string ProgramFilesX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

		// Token: 0x040000F5 RID: 245
		public static readonly string ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

		// Token: 0x040000F6 RID: 246
		public static readonly string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

		// Token: 0x040000F7 RID: 247
		public static readonly string LocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

		// Token: 0x040000F8 RID: 248
		public static readonly string cmdFullFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), (Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess) ? "Sysnative\\cmd.exe" : "System32\\cmd.exe");

		// Token: 0x020000A6 RID: 166
		internal static class SystemInformation
		{
			// Token: 0x06000432 RID: 1074 RVA: 0x0003D818 File Offset: 0x0003BA18
			internal static string GetWMIProperty(string Class, string PropertyName)
			{
				string text = string.Empty;
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT " + PropertyName + " FROM " + Class);
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						text = ((ManagementObject)enumerator.Current)[PropertyName].ToString();
					}
				}
				if (managementObjectSearcher != null)
				{
					managementObjectSearcher.Dispose();
					managementObjectSearcher = null;
				}
				return text.Trim();
			}

			// Token: 0x17000085 RID: 133
			// (get) Token: 0x06000433 RID: 1075 RVA: 0x0003D8A0 File Offset: 0x0003BAA0
			internal static string GPUName
			{
				get
				{
					return Utils.SystemInformation.GetWMIProperty("Win32_VideoController", "Caption");
				}
			}

			// Token: 0x17000086 RID: 134
			// (get) Token: 0x06000434 RID: 1076 RVA: 0x0003D8B1 File Offset: 0x0003BAB1
			internal static string RAMSize
			{
				get
				{
					return Utils.SystemInformation.GetWMIProperty("Win32_PhysicalMemory", "Capacity");
				}
			}

			// Token: 0x17000087 RID: 135
			// (get) Token: 0x06000435 RID: 1077 RVA: 0x0003D8C2 File Offset: 0x0003BAC2
			internal static string NumberOfCores
			{
				get
				{
					return Utils.SystemInformation.GetWMIProperty("Win32_Processor", "NumberOfCores");
				}
			}

			// Token: 0x17000088 RID: 136
			// (get) Token: 0x06000436 RID: 1078 RVA: 0x0003D8D3 File Offset: 0x0003BAD3
			internal static string NumberOfLogicalProcessors
			{
				get
				{
					return Utils.SystemInformation.GetWMIProperty("Win32_Processor", "NumberOfLogicalProcessors");
				}
			}

			// Token: 0x17000089 RID: 137
			// (get) Token: 0x06000437 RID: 1079 RVA: 0x0003D8E4 File Offset: 0x0003BAE4
			internal static string SocketDesignation
			{
				get
				{
					return Utils.SystemInformation.GetWMIProperty("Win32_Processor", "socketdesignation");
				}
			}

			// Token: 0x1700008A RID: 138
			// (get) Token: 0x06000438 RID: 1080 RVA: 0x0003D8F8 File Offset: 0x0003BAF8
			internal static ulong SvchostValue
			{
				get
				{
					ulong num = 0UL;
					foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory").Get())
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						num += (ulong)managementObject["Capacity"] / 1024UL / 1024UL / 1024UL;
					}
					return num;
				}
			}

			// Token: 0x1700008B RID: 139
			// (get) Token: 0x06000439 RID: 1081 RVA: 0x0003D978 File Offset: 0x0003BB78
			internal static string SystemType
			{
				get
				{
					return Utils.SystemInformation.GetWMIProperty("Win32_ComputerSystem", "PCSystemType");
				}
			}

			// Token: 0x0600043A RID: 1082 RVA: 0x0003D98C File Offset: 0x0003BB8C
			internal static string GetWindowsVersion()
			{
				string result = "";
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
				if (registryKey != null)
				{
					result = (string)registryKey.GetValue("CurrentBuild");
				}
				return result;
			}
		}
	}
}
