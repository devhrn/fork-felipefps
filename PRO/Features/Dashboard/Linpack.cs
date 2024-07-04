using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000072 RID: 114
	public class Linpack : IFeature
	{
		// Token: 0x06000362 RID: 866 RVA: 0x0002FC28 File Offset: 0x0002DE28
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Linpack Xtreme\\LinpackXtreme_x64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\Linpack Xtreme\\", "LinpackXtreme_x64.exe", "", false);
				return;
			}
			Utils.Status("Downloading Linpack Xtreme Windows...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/865147333866684446/Linpack_Xtreme.zip"), Path.GetTempPath() + "\\LinpackXtreme.zip");
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0002FCCC File Offset: 0x0002DECC
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Linpack Xtreme Windows: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (8.49MB)");
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0002FD1D File Offset: 0x0002DF1D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("LinpackXtreme", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\Linpack Xtreme\\", "LinpackXtreme_x64.exe", "", true);
		}
	}
}
