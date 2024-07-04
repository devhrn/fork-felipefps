using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x02000033 RID: 51
	public class MorePowerTool : IFeature
	{
		// Token: 0x06000272 RID: 626 RVA: 0x000298D0 File Offset: 0x00027AD0
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\MorePowerTool.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "MorePowerTool.exe", "", false);
				return;
			}
			Utils.Status("Downloading MorePowerTool...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/856271185415372881/MorePowerTool.exe"), Utils.AppData + "\\Felipe\\MorePowerTool.exe");
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00029974 File Offset: 0x00027B74
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading MorePowerTool: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (4.05MB)");
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000299C8 File Offset: 0x00027BC8
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}", true);
			Regex regex = new Regex("\\d{4}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
			foreach (string text in registryKey.GetSubKeyNames())
			{
				if (regex.IsMatch(text))
				{
					RegistryKey registryKey2 = registryKey.CreateSubKey(text, true);
					if (registryKey2.GetValueNames().Contains("DriverDesc"))
					{
						registryKey2.SetValue("PP_ForceHighDPMLevel", "1", RegistryValueKind.DWord);
						registryKey2.SetValue("PP_Force3DPerformanceMode", "1", RegistryValueKind.DWord);
					}
				}
			}
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "MorePowerTool.exe", "", true);
		}
	}
}
