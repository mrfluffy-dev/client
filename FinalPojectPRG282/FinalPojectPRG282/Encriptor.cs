using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace FinalPojectPRG282
{
    class Encriptor
    {
        public string Encript(string toEncript)
        {
            try
            {
                string Encripted = "";
                string PublicKey = "password";
                string SecretKey = "drowssap";
                byte[] SecretKeyByte = { };
                SecretKeyByte = Encoding.UTF8.GetBytes(SecretKey);
                byte[] PublicKeyByte = { };
                PublicKeyByte = Encoding.UTF8.GetBytes(PublicKey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = Encoding.UTF8.GetBytes(toEncript);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(PublicKeyByte, SecretKeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encripted = Convert.ToBase64String(ms.ToArray());
                }
                return Encripted;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public string Decript(string toDecript)
        {
            try
            {
                string UnEncripted = "";
                string PublicKey = "password";
                string SecretKey = "drowssap";
                byte[] SecretKeyByte = { };
                SecretKeyByte = Encoding.UTF8.GetBytes(SecretKey);
                byte[] PublicKeyByte = { };
                PublicKeyByte = Encoding.UTF8.GetBytes(PublicKey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[toDecript.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(toDecript.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(PublicKeyByte, SecretKeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    UnEncripted = encoding.GetString(ms.ToArray());
                }
                return UnEncripted;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }
    }
}
