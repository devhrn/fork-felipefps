using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000070 RID: 112
	public class GPUZ : IFeature
	{
		// Token: 0x0600035A RID: 858 RVA: 0x0002F9A0 File Offset: 0x0002DBA0
		public void Execute()
		{
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\techPowerUp\\GPU-Z", true).SetValue("Install_Dir", "no", RegistryValueKind.String);
			if (File.Exists(Utils.AppData + "\\Felipe\\GPUZ\\GPU-Z.2.40.0.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\GPUZ\\", "GPU-Z.2.40.0.exe", "", false);
				return;
			}
			Utils.Status("Downloading GPUZ...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/851595857542905886/GPUZ.zip"), Path.GetTempPath() + "\\GPUZ.zip");
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0002FA64 File Offset: 0x0002DC64
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading GPUZ: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (7.0MB)");
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0002FAB5 File Offset: 0x0002DCB5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("GPUZ", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\GPUZ\\", "GPU-Z.2.40.0.exe", "", true);
		}
	}
}
