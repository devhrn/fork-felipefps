using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000071 RID: 113
	public class HWiNFO : IFeature
	{
		// Token: 0x0600035E RID: 862 RVA: 0x0002FAE4 File Offset: 0x0002DCE4
		public void Execute()
		{
			Registry.CurrentUser.CreateSubKey("Software\\HWiNFO64\\Sensors\\F0EC0502_0", true).SetValue("WarningShow", "0", RegistryValueKind.DWord);
			if (File.Exists(Utils.AppData + "\\Felipe\\HWiNFO\\HWiNFO64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\HWiNFO\\", "HWiNFO64.exe", "", false);
				return;
			}
			Utils.Status("Downloading HWiNFO...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/866481826700591104/HWiNFO.zip"), Path.GetTempPath() + "\\HWiNFO.zip");
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0002FBA8 File Offset: 0x0002DDA8
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading HWiNFO: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (5.76MB)");
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0002FBF9 File Offset: 0x0002DDF9
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("HWiNFO", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\HWiNFO\\", "HWiNFO64.exe", "", true);
		}
	}
}
