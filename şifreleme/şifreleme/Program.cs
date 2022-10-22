using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace şifreleme
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        public string DESSifrele(string strGiris)
        {
            string sonuc = "";
            if (strGiris == "" || strGiris == null)
            {
                throw new ArgumentNullException("Şifrelenecek veri yok");
            }
            else
            {
                byte[] aryKey = Byte8("12345678"); // BURAYA 8 bit string DEĞER GİRİN
                byte[] aryIV = Byte8("12345678"); // BURAYA 8 bit string DEĞER GİRİN
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(aryKey, aryIV), CryptoStreamMode.Write);
                StreamWriter writer = new StreamWriter(cs);
                writer.Write(strGiris);
                writer.Flush();
                cs.FlushFinalBlock();
                writer.Flush();
                sonuc = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
                writer.Dispose();
                cs.Dispose();
                ms.Dispose();
            }
            return sonuc;
        }

        public string DESCoz(string strGiris)
        {
            string strSonuc = "";
            if (strGiris == "" || strGiris == null)
            {
                throw new ArgumentNullException("Şifrelenecek veri yok.");
            }
            else
            {
                byte[] aryKey = Byte8("12345678");
                byte[] aryIV = Byte8("12345678");
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(Convert.FromBase64String(strGiris));
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(aryKey, aryIV), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cs);
                strSonuc = reader.ReadToEnd();
                reader.Dispose();
                cs.Dispose();
                ms.Dispose();
            }
            return strSonuc;
        }
    }
}
