using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace BlitzedGrabberV12.Properties
{
	// Token: 0x02000004 RID: 4
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000022A1 File Offset: 0x000004A1
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000004 RID: 4
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
