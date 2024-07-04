using System;
using System.Diagnostics;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000043 RID: 67
	public class DriverAMD : IFeature
	{
		// Token: 0x060002B0 RID: 688 RVA: 0x0002AAB4 File Offset: 0x00028CB4
		public void Execute()
		{
			if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1)
			{
				Process.Start("https://drive.google.com/file/d/1q5IePZv4nZnnx0B9eR0yYxwipqfVQOn9/view?usp=sharing");
			}
			if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 3)
			{
				Process.Start("https://drive.google.com/file/d/1q5IePZv4nZnnx0B9eR0yYxwipqfVQOn9/view?usp=sharing");
			}
			if (Environment.OSVersion.Version.Major == 10)
			{
				Process.Start("https://drive.google.com/file/d/1EgyUU1nZ9fKKFUuqmsIh1i51Ptla90T-/view?usp=sharing");
			}
		}
	}
}
