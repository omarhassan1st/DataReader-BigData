using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.Classes
{
    class Cryptography
    {

        public static readonly string Hash = "Pass";
        public static string DeCrypt(string Txt, string Hash)
        {
            try
            {
                byte[] data = Convert.FromBase64String(Txt);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())

                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
                    using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })

                    {
                        ICryptoTransform transform = tripleDES.CreateDecryptor();
                        byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                        Txt = UTF8Encoding.UTF8.GetString(result);
                    }
                }
                return Txt;
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string EnCrypt(string Txt, string Hash)
        {
            try
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(Txt);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())

                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
                    using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })

                    {
                        ICryptoTransform transform = tripleDES.CreateEncryptor();
                        byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                        Hash = Convert.ToBase64String(result, 0, result.Length);
                    }
                }
                return Hash;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }

    }
}
