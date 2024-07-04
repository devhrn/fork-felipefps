using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x0200009C RID: 156
	public class Superposition : IFeature
	{
		// Token: 0x06000402 RID: 1026 RVA: 0x000336EC File Offset: 0x000318EC
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Unigine_Superposition-1.1.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Unigine_Superposition-1.1.exe", "", false);
				return;
			}
			Utils.Status("Downloading Unigine Superposition...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://assets.unigine.com/d/Unigine_Superposition-1.1.exe"), Utils.AppData + "\\Felipe\\Unigine_Superposition-1.1.exe");
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00033790 File Offset: 0x00031990
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Unigine Superposition: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.2GB)");
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x000337E1 File Offset: 0x000319E1
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Unigine_Superposition-1.1.exe", "", true);
		}
	}
}
