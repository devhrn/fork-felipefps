using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x0200004E RID: 78
	public class NvCleanstall : IFeature
	{
		// Token: 0x060002D8 RID: 728 RVA: 0x0002B778 File Offset: 0x00029978
		public void Execute()
		{
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings", true).SetValue("ExcludeWUDriversInQualityUpdate", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DriverSearching", true).SetValue("SearchOrderConfig", "0", RegistryValueKind.DWord);
			if (File.Exists(Utils.AppData + "\\Felipe\\NVCleanstall_1.8.0.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "NVCleanstall_1.8.0.exe", "", false);
				return;
			}
			Utils.Status("Downloading NVCleanstall...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/836674020995891250/NVCleanstall_1.8.0.exe"), Utils.AppData + "\\Felipe\\NVCleanstall_1.8.0.exe");
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0002B85C File Offset: 0x00029A5C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading NVCleanstall: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (3.2MB)");
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0002B8AD File Offset: 0x00029AAD
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "NVCleanstall_1.8.0.exe", "", true);
		}
	}
}
