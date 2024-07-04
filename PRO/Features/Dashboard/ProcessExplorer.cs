﻿using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x0200007B RID: 123
	public class ProcessExplorer : IFeature
	{
		// Token: 0x06000382 RID: 898 RVA: 0x0003041C File Offset: 0x0002E61C
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\procexp64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "procexp64.exe", "", false);
				return;
			}
			Utils.Status("Downloading ProcessExplorer...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/842146713086984192/procexp64.exe"), Utils.AppData + "\\Felipe\\procexp64.exe");
		}

		// Token: 0x06000383 RID: 899 RVA: 0x000304C0 File Offset: 0x0002E6C0
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading ProcessExplorer: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1MB)");
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00030514 File Offset: 0x0002E714
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("DbgHelpPath", "C:\\Windows\\SYSTEM32\\dbghelp.dll", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ProcessSortColumn", "4294967295", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("SymbolPath", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("EulaAccepted", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("Windowplacement", new byte[]
			{
				44,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				131,
				byte.MaxValue,
				byte.MaxValue,
				0,
				131,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				57,
				2,
				0,
				0,
				47,
				0,
				0,
				0,
				229,
				6,
				0,
				0,
				143,
				3,
				0,
				0
			}, RegistryValueKind.Binary);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("FindWindowplacement", new byte[]
			{
				44,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				150,
				0,
				0,
				0,
				150,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			}, RegistryValueKind.Binary);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("SysinfoWindowplacement", new byte[]
			{
				44,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				40,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				43,
				3,
				0,
				0,
				43,
				2,
				0,
				0
			}, RegistryValueKind.Binary);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("PropWindowplacement", new byte[]
			{
				44,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				40,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				231,
				1,
				0,
				0,
				159,
				2,
				0,
				0
			}, RegistryValueKind.Binary);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("DllPropWindowplacement", new byte[]
			{
				44,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			}, RegistryValueKind.Binary);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("UnicodeFont", new byte[]
			{
				8,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				144,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				77,
				0,
				83,
				0,
				32,
				0,
				83,
				0,
				104,
				0,
				101,
				0,
				108,
				0,
				108,
				0,
				32,
				0,
				68,
				0,
				108,
				0,
				103,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			}, RegistryValueKind.Binary);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("Divider", new byte[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				240,
				63
			}, RegistryValueKind.Binary);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("SavedDivider", new byte[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				224,
				63
			}, RegistryValueKind.Binary);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ProcessImageColumnWidth", "200", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowUnnamedHandles", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowDllView", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HandleSortColumn", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HandleSortDirection", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("DllSortColumn", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("DllSortDirection", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ProcessSortDirection", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HighlightServices", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HighlightOwnProcesses", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HighlightRelocatedDlls", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HighlightJobs", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HighlightNewProc", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HighlightDelProc", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HighlightImmersive", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HighlightProtected", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HighlightPacked", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HighlightNetProcess", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HighlightSuspend", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HighlightDuration", "1000", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowCpuFractions", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowLowerpane", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowAllUsers", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowProcessTree", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("SymbolWarningShown", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HideWhenMinimized", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("AlwaysOntop", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("OneInstance", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("NumColumnSets", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ConfirmKill", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("RefreshRate", "1000", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("PrcessColumnCount", "11", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("DllColumnCount", "4", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("HandleColumnCount", "2", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("DefaultProcPropPage", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("DefaultSysInfoPage", "4", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("DefaultDllPropPage", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ColorPacked", "16711808", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ColorImmersive", "15395328", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ColorOwn", "16765136", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ColorServices", "13684991", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ColorRelocatedDlls", "10551295", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ColorGraphBk", "15790320", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ColorJobs", "27856", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ColorDelProc", "4605695", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ColorNewProc", "4652870", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ColorNet", "10551295", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ColorProtected", "8388863", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowHeatmaps", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ColorSuspend", "8421504", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("StatusBarColumns", "8213", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowAllCpus", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowAllGpus", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("Opacity", "100", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("GpuNodeUsageMask", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("GpuNodeUsageMask1", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("VerifySignatures", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("VirusTotalCheck", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("VirusTotalSubmitUnknown", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ToolbarBands", new byte[]
			{
				6,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				75,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				75,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				75,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				75,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				75,
				0,
				0,
				0,
				5,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				75,
				0,
				0,
				0,
				6,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				75,
				0,
				0,
				0,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			}, RegistryValueKind.Binary);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("UseGoogle", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowNewProcesses", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("TrayCPUHistory", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowIoTray", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowNetTray", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowDiskTray", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowPhysTray", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowCommitTray", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ShowGpuTray", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("FormatIoBytes", "1", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("StackWindowPlacement", new byte[44], RegistryValueKind.Binary);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer", true).SetValue("ETWstandardUserWarning", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\DllColumnMap", true).SetValue("0", "26", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\DllColumnMap", true).SetValue("1", "42", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\DllColumnMap", true).SetValue("2", "1033", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\DllColumnMap", true).SetValue("3", "1111", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\DllColumns", true).SetValue("0", "110", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\DllColumns", true).SetValue("1", "180", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\DllColumns", true).SetValue("2", "140", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\DllColumns", true).SetValue("3", "300", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\HandleColumnMap", true).SetValue("0", "21", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\HandleColumnMap", true).SetValue("1", "22", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\HandleColumns", true).SetValue("0", "100", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\HandleColumns", true).SetValue("1", "450", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumnMap", true).SetValue("0", "3", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumnMap", true).SetValue("1", "1055", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumnMap", true).SetValue("2", "1060", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumnMap", true).SetValue("3", "1063", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumnMap", true).SetValue("4", "4", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumnMap", true).SetValue("5", "1200", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumnMap", true).SetValue("6", "1092", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumnMap", true).SetValue("7", "1333", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumnMap", true).SetValue("8", "5", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumnMap", true).SetValue("9", "1340", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumnMap", true).SetValue("10", "1191", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumns", true).SetValue("0", "200", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumns", true).SetValue("1", "40", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumns", true).SetValue("2", "80", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumns", true).SetValue("3", "80", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumns", true).SetValue("4", "40", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumns", true).SetValue("5", "100", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumns", true).SetValue("6", "78", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumns", true).SetValue("7", "81", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumns", true).SetValue("8", "31", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumns", true).SetValue("9", "53", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\Sysinternals\\Process Explorer\\ProcessColumns", true).SetValue("10", "100", RegistryValueKind.DWord);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "procexp64.exe", "", true);
		}
	}
}
