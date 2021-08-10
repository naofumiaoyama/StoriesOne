using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Utility
{
   public class EncryptDecrypt
    {
        public static string Encrypt(string value)
        {
            string toEncrypt = value;
            string key = "St0r1es";

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyArray = hashmd5.ComputeHash(UnicodeEncoding.Unicode.GetBytes(key));
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] toEncryptArray = UnicodeEncoding.Unicode.GetBytes(toEncrypt);
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            string finalString = Convert.ToBase64String(resultArray);
            return finalString;
        }

        public static string Decrypt(string value)
        {
            string key = "St0r1es";
            byte[] data = Convert.FromBase64String(value);
            using (MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = mD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }
    }
}
