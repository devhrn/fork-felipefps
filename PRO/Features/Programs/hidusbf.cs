using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x0200002E RID: 46
	public class hidusbf : IFeature
	{
		// Token: 0x0600025E RID: 606 RVA: 0x00029214 File Offset: 0x00027414
		public void Execute()
		{
			new WebClient
			{
				Headers = 
				{
					"User-Agent: Other"
				}
			}.DownloadFile("https://cdn.discordapp.com/attachments/762398248655913004/839013764769644564/SweetLow.CER", Path.GetTempPath() + "SweetLow.cer");
			X509Store x509Store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
			x509Store.Open(OpenFlags.ReadWrite);
			x509Store.Add(new X509Certificate2(X509Certificate.CreateFromCertFile(Path.GetTempPath() + "SweetLow.CER")));
			x509Store.Close();
			if (File.Exists(Utils.AppData + "\\Felipe\\hidusbf\\Setup.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\hidusbf\\", "Setup.exe", "", false);
				return;
			}
			Utils.Status("Downloading hidusbf...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/839011282854084648/hidusbf.zip"), Path.GetTempPath() + "\\hidusbf.zip");
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00029318 File Offset: 0x00027518
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading hidusbf: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (55KB)");
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00029369 File Offset: 0x00027569
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("hidusbf", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\hidusbf\\", "Setup.exe", "", true);
		}
	}
}
