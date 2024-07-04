using System;
using System.Diagnostics;
using System.Windows.Forms;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000044 RID: 68
	public class DriverNVIDIA : IFeature
	{
		// Token: 0x060002B2 RID: 690 RVA: 0x0002AB48 File Offset: 0x00028D48
		public void Execute()
		{
			if (MessageBox.Show("Do you play Warzone / Apex / GTA?", "NVIDIA Drivers", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1)
				{
					Process.Start("https://drive.google.com/file/d/1blgSrF1FzONGYmNSoWrnMQFLjnaqWWmZ/view?usp=sharing");
				}
				if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 3)
				{
					Process.Start("https://drive.google.com/file/d/1blgSrF1FzONGYmNSoWrnMQFLjnaqWWmZ/view?usp=sharing");
				}
				if (Environment.OSVersion.Version.Major == 10)
				{
					Process.Start("https://drive.google.com/file/d/1JjYHMMcBJBQBYahKTqrHs-8LrNgKec0i/view?usp=sharing");
					return;
				}
			}
			else
			{
				if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1)
				{
					Process.Start("https://drive.google.com/file/d/1J1G3t4kNMf3hv7xeruZqsZke13yccOhJ/view?usp=sharing");
				}
				if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 3)
				{
					Process.Start("https://drive.google.com/file/d/1J1G3t4kNMf3hv7xeruZqsZke13yccOhJ/view?usp=sharing");
				}
				if (Environment.OSVersion.Version.Major == 10)
				{
					Process.Start("https://drive.google.com/file/d/1QxY0T6zZzHP7BK7D1pbhbegdLaDTW_AC/view?usp=sharing");
				}
			}
		}
	}
}
