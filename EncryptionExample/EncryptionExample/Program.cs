using System;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionExample
{
    static class Program
    {
        static void Main()
        {
            AsymetricExample();
            SymetricExamle();
            Console.ReadLine();
        }
        static void SymetricExamle()
        {
            var text = "My Sample Text to Test DES from C#";
            var encryptedText = ClsTripleDES.Encrypt(text);
            var decryptedText = ClsTripleDES.Decrypt(encryptedText);
            Console.WriteLine("Before TripleDES Encryption Text = " + text);
            Console.WriteLine("After TripleDES Encryption Text = " +
               encryptedText);
            Console.WriteLine("After TripleDES Decryption Text = " +
               decryptedText);
        }
        static void AsymetricExample()
        {
            var csp = new RSACryptoServiceProvider(2048);

            //how to get the private key
            var privKey = csp.ExportParameters(true);

            //and the public key ...
            var pubKey = csp.ExportParameters(false);

            //converting the public key into a string representation
            string pubKeyString;
            //we need some buffer
            var sw = new System.IO.StringWriter();
            //we need a serializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //serialize the key into the stream
            xs.Serialize(sw, pubKey);
            //get the string from the stream
            pubKeyString = sw.ToString();
            Console.WriteLine("Public key:{0}", pubKeyString);
            
            //converting it back
            //get a stream from the string
            var sr = new System.IO.StringReader(pubKeyString);
            //we need a deserializer
                xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            pubKey = (RSAParameters)xs.Deserialize(sr);
            
            //conversion for the private key is no black magic either ... omitted

            //we have a public key ... let's get a new csp and load that key
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(pubKey);

            //we need some data to encrypt
            var plainTextData = "foobar";

            //for encryption, always handle bytes...
            var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(plainTextData);
            //apply pkcs#1.5 padding and encrypt our data 
            var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);
           
            //we might want a string representation of our cypher text... base64 will do
            var cypherText = Convert.ToBase64String(bytesCypherText);
            Console.WriteLine("Encrypted by RSA:" + cypherText);

            /*
             * some transmission / storage / retrieval
             * 
             * and we want to decrypt our cypherText
             */

            //first, get our bytes back from the base64 string ...
            bytesCypherText = Convert.FromBase64String(cypherText);

            //we want to decrypt, therefore we need a csp and load our private key
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(privKey);

            //decrypt and strip pkcs#1.5 padding
            bytesPlainTextData = csp.Decrypt(bytesCypherText, false);

            //get our original plainText back...
            plainTextData = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);
            Console.WriteLine("Decrypted by RSA:" + plainTextData);
        }
    }
    public class ClsTripleDES
    {

        private const string mysecurityKey = "MyTestSampleKey";

        public static string Encrypt(string TextToEncrypt)
        {
            byte[] MyEncryptedArray = UTF8Encoding.UTF8
               .GetBytes(TextToEncrypt);

            MD5CryptoServiceProvider MyMD5CryptoService = new
               MD5CryptoServiceProvider();

            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash
               (UTF8Encoding.UTF8.GetBytes(mysecurityKey));

            MyMD5CryptoService.Clear();

            var MyTripleDESCryptoService = new
               TripleDESCryptoServiceProvider();

            MyTripleDESCryptoService.Key = MysecurityKeyArray;

            MyTripleDESCryptoService.Mode = CipherMode.ECB;

            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var MyCrytpoTransform = MyTripleDESCryptoService
               .CreateEncryptor();

            byte[] MyresultArray = MyCrytpoTransform
               .TransformFinalBlock(MyEncryptedArray, 0,
               MyEncryptedArray.Length);

            MyTripleDESCryptoService.Clear();

            return Convert.ToBase64String(MyresultArray, 0,
               MyresultArray.Length);
        }



        public static string Decrypt(string TextToDecrypt)
        {
            byte[] MyDecryptArray = Convert.FromBase64String
               (TextToDecrypt);

            MD5CryptoServiceProvider MyMD5CryptoService = new
               MD5CryptoServiceProvider();

            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash
               (UTF8Encoding.UTF8.GetBytes(mysecurityKey));

            MyMD5CryptoService.Clear();

            var MyTripleDESCryptoService = new
               TripleDESCryptoServiceProvider();

            MyTripleDESCryptoService.Key = MysecurityKeyArray;

            MyTripleDESCryptoService.Mode = CipherMode.ECB;

            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var MyCrytpoTransform = MyTripleDESCryptoService
               .CreateDecryptor();

            byte[] MyresultArray = MyCrytpoTransform
               .TransformFinalBlock(MyDecryptArray, 0,
               MyDecryptArray.Length);

            MyTripleDESCryptoService.Clear();

            return UTF8Encoding.UTF8.GetString(MyresultArray);
        }
    }
}
