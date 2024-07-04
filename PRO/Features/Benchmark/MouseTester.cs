using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x02000097 RID: 151
	public class MouseTester : IFeature
	{
		// Token: 0x060003EE RID: 1006 RVA: 0x0003315C File Offset: 0x0003135C
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\MouseTester\\MouseTester.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\MouseTester\\", "MouseTester.exe", "", false);
				return;
			}
			Utils.Status("Downloading MouseTester...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/855286138864795688/MouseTester.zip"), Path.GetTempPath() + "\\MouseTester.zip");
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00033200 File Offset: 0x00031400
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading MouseTester: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (147KB)");
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00033251 File Offset: 0x00031451
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("MouseTester", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\MouseTester\\", "MouseTester.exe", "", true);
		}
	}
}
