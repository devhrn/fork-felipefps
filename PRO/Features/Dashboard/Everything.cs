using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x0200006E RID: 110
	public class Everything : IFeature
	{
		// Token: 0x06000352 RID: 850 RVA: 0x0002F764 File Offset: 0x0002D964
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Everything\\Everything.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\Everything\\", "Everything.exe", "", false);
				return;
			}
			Utils.Status("Downloading Everything...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/1258236120354000896/1258238837453488240/Everything.zip?ex=668751bb&is=6686003b&hm=f7b26d18b6fdf0b72c9d49b4df214ee15ebbe596d86dd0557814e63e85f8a25f&"), Path.GetTempPath() + "\\Everything.zip");
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0002F808 File Offset: 0x0002DA08
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Everything: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (2MB)");
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0002F859 File Offset: 0x0002DA59
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("Everything", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\Everything\\", "Everything.exe", "", true);
		}
	}
}
