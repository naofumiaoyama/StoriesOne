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

    }
}
