using System;
using System.IO;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000011 RID: 17
	public class Edge : IFeature
	{
		// Token: 0x0600020B RID: 523 RVA: 0x0001BDE4 File Offset: 0x00019FE4
		public void Execute()
		{
			Utils.Status("Uninstalling Edge...");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\SetUserFTA.exe", "https://cdn.discordapp.com/attachments/1204098475315167262/1218989778700210318/SetUserFTA.exe?ex=6686ea32&is=668598b2&hm=6ba60784a98066d8354afec800c25522c888970785355ef2e6fa8efd131170a2&");
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", "http \"\"", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", "https \"\"", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".bmp PhotoViewer.FileAssoc.Tiff", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".gif PhotoViewer.FileAssoc.Tiff", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".jpeg PhotoViewer.FileAssoc.Tiff", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".jpg PhotoViewer.FileAssoc.Tiff", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".png PhotoViewer.FileAssoc.Tiff", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".tif PhotoViewer.FileAssoc.Tiff", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".tiff PhotoViewer.FileAssoc.Tiff", false, false);
			Utils.ExecuteProcess("taskkill.exe", "/F /IM edge.exe", false, false);
			Utils.ExecuteProcess("cmd.exe", "/C for /D %i in (\"%ProgramFiles(x86)%\\Microsoft\\Edge\\Application\\*\") do if exist \"%i\\Installer\\setup.exe\" ( start \"\" /w \"%i\\Installer\\setup.exe\" --uninstall --force-uninstall --system-level )", false, false);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\EdgeUpdate", true).SetValue("DoNotUpdateToEdgeWithChromium", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\MicrosoftEdge\\Main", true).SetValue("AllowPrelaunch", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\MicrosoftEdge\\Main", true).SetValue("PreventFirstRunPage", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\MicrosoftEdge\\PhishingFilter", true).SetValue("EnabledV9", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\MicrosoftEdge\\TabPreloader", true).SetValue("AllowTabPreloading", "0", RegistryValueKind.DWord);
			Utils.ExecuteProcess("cmd.exe", "/c taskkill /F /FI \"IMAGENAME eq MicrosoftEdge.exe\"", true, false);
			Utils.ExecuteProcess("cmd.exe", "/c IF EXIST %WINDIR%\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdge.exe takeown /F %WINDIR%\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdge.exe /A & icacls %WINDIR%\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdge.exe /grant Administrators:(F)", true, false);
			Utils.ExecuteProcess("cmd.exe", "/c IF NOT EXIST %WINDIR%\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdge.old IF EXIST %WINDIR%\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdge.exe REN %WINDIR%\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdge.exe MicrosoftEdge.old", true, false);
			Utils.ExecuteProcess("cmd.exe", "/c taskkill /F /FI \"IMAGENAME eq MicrosoftEdgeCP.exe\"", true, false);
			Utils.ExecuteProcess("cmd.exe", "/c IF EXIST %WINDIR%\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdgeCP.exe takeown /F %WINDIR%\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdgeCP.exe /A & icacls %WINDIR%\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdgeCP.exe /grant Administrators:(F)", true, false);
			Utils.ExecuteProcess("cmd.exe", "/c IF NOT EXIST %WINDIR%\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdgeCP.old IF EXIST %WINDIR%\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdgeCP.exe REN %WINDIR%\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\MicrosoftEdgeCP.exe MicrosoftEdgeCP.old", true, false);
			File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory) + "\\Microsoft Edge.lnk");
			Utils.ResetStatus();
		}
	}
}
