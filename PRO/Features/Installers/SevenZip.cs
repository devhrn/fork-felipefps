using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000054 RID: 84
	public class SevenZip : IFeature
	{
		// Token: 0x060002F0 RID: 752 RVA: 0x0002BE54 File Offset: 0x0002A054
		public void Execute()
		{
			Registry.CurrentUser.CreateSubKey("Software\\7-Zip\\Options", true).SetValue("ElimDupExtract", "0", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("Software\\7-Zip\\Options", true).SetValue("ContextMenu", "4100", RegistryValueKind.DWord);
			Registry.CurrentUser.CreateSubKey("Software\\7-Zip\\Options", true).SetValue("RootFolder", new byte[]
			{
				1,
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
				4,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				160,
				0,
				0,
				0
			}, RegistryValueKind.Binary);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.001", true).SetValue("", "7-Zip.001", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.7z", true).SetValue("", "7-Zip.7z", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.arj", true).SetValue("", "7-Zip.arj", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.bz2", true).SetValue("", "7-Zip.bz2", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.bzip2", true).SetValue("", "7-Zip.bzip2", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.cab", true).SetValue("", "7-Zip.cab", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.cpio", true).SetValue("", "7-Zip.cpio", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.deb", true).SetValue("", "7-Zip.deb", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.dmg", true).SetValue("", "7-Zip.dmg", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.esd", true).SetValue("", "7-Zip.esd", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.fat", true).SetValue("", "7-Zip.fat", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.gz", true).SetValue("", "7-Zip.gz", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.gzip", true).SetValue("", "7-Zip.gzip", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.hfs", true).SetValue("", "7-Zip.hfs", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.iso", true).SetValue("", "7-Zip.iso", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.lha", true).SetValue("", "7-Zip.lha", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.lzh", true).SetValue("", "7-Zip.lzh", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.lzma", true).SetValue("", "7-Zip.lzma", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.nfts", true).SetValue("", "7-Zip.nfts", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.rar", true).SetValue("", "7-Zip.rar", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.rpm", true).SetValue("", "7-Zip.rpm", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.swm", true).SetValue("", "7-Zip.swm", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.tar", true).SetValue("", "7-Zip.tar", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.taz", true).SetValue("", "7-Zip.taz", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.tbz", true).SetValue("", "7-Zip.tbz", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.tbz2", true).SetValue("", "7-Zip.tbz2", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.tgz", true).SetValue("", "7-Zip.tgz", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.tpz", true).SetValue("", "7-Zip.tpz", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.txz", true).SetValue("", "7-Zip.txz", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.vhd", true).SetValue("", "7-Zip.vhd", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.wim", true).SetValue("", "7-Zip.wim", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.xar", true).SetValue("", "7-Zip.xar", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.xz", true).SetValue("", "7-Zip.xz", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.z", true).SetValue("", "7-Zip.z", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\.zip", true).SetValue("", "7-Zip.zip", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.7z", true).SetValue("", "7z Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.7z\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll, 0", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.7z\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.7z\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.7z\\shell\\open\\command", true).SetValue("", "C:\\Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.001", true).SetValue("", "001 Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.001\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll, 9", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.001\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.001\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.001\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.arj", true).SetValue("", "arj Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.arj\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,4", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.arj\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.arj\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.arj\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.bz2", true).SetValue("", "bz2 Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.bz2\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,2", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.bz2\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.bz2\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.bz2\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.bzip2", true).SetValue("", "bzip2 Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.bzip2\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,2", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.bzip2\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.bzip2\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.bzip2\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.cab", true).SetValue("", "cab Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.cab\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,7", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.cab\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.cab\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.cab\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.cpio", true).SetValue("", "cpio Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.cpio\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,12", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.cpio\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.cpio\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.cpio\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.deb", true).SetValue("", "deb Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.deb\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,11", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.deb\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.deb\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.deb\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.dmg", true).SetValue("", "dmg Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.dmg\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,17", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.dmg\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.dmg\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.dmg\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.esd", true).SetValue("", "esd Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.esd\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,15", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.esd\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.esd\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.esd\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.fat", true).SetValue("", "fat Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.fat\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,21", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.fat\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.fat\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.fat\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.gz", true).SetValue("", "gz Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.gz\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,14", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.gz\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.gz\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.gz\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.gzip", true).SetValue("", "gzip Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.gzip\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,14", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.gzip\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.gzip\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.gzip\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.hfs", true).SetValue("", "hfs Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.hfs\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,18", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.hfs\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.hfs\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.hfs\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.iso", true).SetValue("", "iso Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.iso\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,8", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.iso\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.iso\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.iso\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lha", true).SetValue("", "lha Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lha\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,6", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lha\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lha\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lha\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lzh", true).SetValue("", "lzh Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lzh\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,6", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lzh\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lzh\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lzh\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lzma", true).SetValue("", "lzma Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lzma\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,16", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lzma\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lzma\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.lzma\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.ntfs", true).SetValue("", "ntfs Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.ntfs\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,22", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.ntfs\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.ntfs\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.ntfs\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.rar", true).SetValue("", "rar Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.rar\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,3", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.rar\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.rar\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.rar\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.rpm", true).SetValue("", "rpm Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.rpm\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,10", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.rpm\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.rpm\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.rpm\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.swm", true).SetValue("", "swm Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.swm\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,15", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.swm\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.swm\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.swm\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tar", true).SetValue("", "tar Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tar\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,13", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tar\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tar\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tar\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.taz", true).SetValue("", "taz Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.taz\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,5", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.taz\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.taz\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.taz\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tbz", true).SetValue("", "tbz Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tbz2", true).SetValue("", "tbz2 Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tbz2\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,2", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tbz2\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tbz2\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tbz2\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tbz\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,2", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tbz\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tbz\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tbz\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tgz", true).SetValue("", "tgz Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tgz\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,14", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tgz\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tgz\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tgz\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tpz", true).SetValue("", "tpz Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tpz\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,14", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tpz\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tpz\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.tpz\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.txz", true).SetValue("", "txz Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.txz\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,23", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.txz\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.txz\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.txz\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.vhd", true).SetValue("", "vhd Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.vhd\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,20", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.vhd\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.vhd\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.vhd\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.wim", true).SetValue("", "wim Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.wim\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,15", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.wim\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.wim\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.wim\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.xar", true).SetValue("", "xar Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.xar\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,19", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.xar\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.xar\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.xar\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.xz", true).SetValue("", "xz Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.xz\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,23", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.xz\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.xz\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.xz\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.z", true).SetValue("", "z Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.z\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,5", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.z\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.z\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.z\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.zip", true).SetValue("", "zip Archive", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.zip\\DefaultIcon", true).SetValue("", "C:\\Program Files\\7-Zip\\7z.dll,1", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.zip\\shell", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.zip\\shell\\open", true).SetValue("", "", RegistryValueKind.String);
			Registry.CurrentUser.CreateSubKey("Software\\Classes\\7-Zip.zip\\shell\\open\\command", true).SetValue("", Utils.WinDrive + "Program Files\\7-Zip\\7zFM.exe \"%1\"", RegistryValueKind.String);
			if (File.Exists(Utils.AppData + "\\Felipe\\7z2002-x64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "7z2002-x64.exe", "/S", false);
				return;
			}
			Utils.Status("Downloading 7ZIP...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/766680501284241460/799131068858761256/7z2002-x64.exe"), Utils.AppData + "\\Felipe\\7z2002-x64.exe");
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0002DAFC File Offset: 0x0002BCFC
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading 7ZIP: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.4MB)");
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0002DB4D File Offset: 0x0002BD4D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "7z2002-x64.exe", "/S", true);
		}
	}
}
