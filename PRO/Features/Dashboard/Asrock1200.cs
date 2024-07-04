using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x0200006A RID: 106
	public class Asrock1200 : IFeature
	{
		// Token: 0x06000344 RID: 836 RVA: 0x0002F298 File Offset: 0x0002D498
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Asrock Timing Configurator\\4.0.3 (z170 z270 z490)\\AsrTC.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\Asrock Timing Configurator\\4.0.3 (z170 z270 z490)\\", "AsrTC.exe", "", false);
				return;
			}
			Utils.Status("Downloading Asrock Timing Configurator...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/839022352062611456/AsrockTCPack.zip"), Path.GetTempPath() + "\\AsrockTCPack.zip");
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0002F33C File Offset: 0x0002D53C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Asrock Timing Configurator: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (12MB)");
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0002F38D File Offset: 0x0002D58D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("AsrockTCPack", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\Asrock Timing Configurator\\4.0.3 (z170 z270 z490)\\", "AsrTC.exe", "", false);
			Utils.ResetStatus();
		}
	}
}
