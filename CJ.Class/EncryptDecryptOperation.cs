using System;
using System.IO;
using System.Security.Cryptography;

namespace CJ.Class
{
    public class EncryptDecryptOperation
    {
        public static void Main()
        {
            try
            {

                string original = "Here is some data to encrypt!";

                // Create a new instance of the Rijndael
                // class.  This generates a new key and initialization
                // vector (IV).
                using (Rijndael myRijndael = Rijndael.Create())
                {
                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV);

                    // Decrypt the bytes to a string.
                    string roundtrip = DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);

                    //Display the original data and the decrypted data.
                    Console.WriteLine("Original:   {0}", original);
                    Console.WriteLine("Round Trip: {0}", roundtrip);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}


//using System;
//using System.IO;
//using System.Security.Cryptography;
//using System.Text;


//namespace CJ.Class
//{
//    public class EncryptDecryptOperation
//    {

//        public static string EncryptString(string key, string plainText)
//        {
//            byte[] iv = new byte[16];
//            byte[] array;

//            using (Aes aes = Aes.Create())
//            {
//                aes.Key = Encoding.UTF8.GetBytes(key);
//                aes.IV = iv;

//                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

//                using (MemoryStream memoryStream = new MemoryStream())
//                {
//                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
//                    {
//                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
//                        {
//                            streamWriter.Write(plainText);
//                        }

//                        array = memoryStream.ToArray();
//                    }
//                }
//            }

//            return Convert.ToBase64String(array);
//        }

//        public static string DecryptString(string key, string cipherText)
//        {
//            byte[] iv = new byte[16];
//            byte[] buffer = Convert.FromBase64String(cipherText);

//            using (Aes aes = Aes.Create())
//            {
//                aes.Key = Encoding.UTF8.GetBytes(key);
//                aes.IV = iv;
//                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

//                using (MemoryStream memoryStream = new MemoryStream(buffer))
//                {
//                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
//                    {
//                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
//                        {
//                            return streamReader.ReadToEnd();
//                        }
//                    }
//                }
//            }
//        }
//    }
//}




//using System;
//using System.Runtime;
//using System.Text;
//using System.Security.Cryptography;
//using System.IO;
//using System.Linq;


//namespace CJ.Class
//{
//    public static class StringCipher
//    {
//        // This constant is used to determine the keysize of the encryption algorithm in bits.
//        // We divide this by 8 within the code below to get the equivalent number of bytes.
//        private const int Keysize = 256;

//        // This constant determines the number of iterations for the password bytes generation function.
//        private const int DerivationIterations = 1000;

//        public static string Encrypt(string plainText, string passPhrase)
//        {
//            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
//            // so that the same Salt and IV values can be used when decrypting.  
//            var saltStringBytes = Generate256BitsOfRandomEntropy();
//            var ivStringBytes = Generate256BitsOfRandomEntropy();
//            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
//            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
//            {
//                var keyBytes = password.GetBytes(Keysize / 8);
//                using (var symmetricKey = new RijndaelManaged())
//                {
//                    symmetricKey.BlockSize = 256;
//                    symmetricKey.Mode = CipherMode.CBC;
//                    symmetricKey.Padding = PaddingMode.PKCS7;
//                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
//                    {
//                        using (var memoryStream = new MemoryStream())
//                        {
//                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
//                            {
//                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
//                                cryptoStream.FlushFinalBlock();
//                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
//                                var cipherTextBytes = saltStringBytes;
//                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
//                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
//                                memoryStream.Close();
//                                cryptoStream.Close();
//                                return Convert.ToBase64String(cipherTextBytes);
//                            }
//                        }
//                    }
//                }
//            }
//        }

//        public static string Decrypt(string cipherText, string passPhrase)
//        {
//            // Get the complete stream of bytes that represent:
//            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
//            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
//            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
//            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
//            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
//            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
//            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
//            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

//            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
//            {
//                var keyBytes = password.GetBytes(Keysize / 8);
//                using (var symmetricKey = new RijndaelManaged())
//                {
//                    symmetricKey.BlockSize = 256;
//                    symmetricKey.Mode = CipherMode.CBC;
//                    symmetricKey.Padding = PaddingMode.PKCS7;
//                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
//                    {
//                        using (var memoryStream = new MemoryStream(cipherTextBytes))
//                        {
//                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
//                            {
//                                var plainTextBytes = new byte[cipherTextBytes.Length];
//                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
//                                memoryStream.Close();
//                                cryptoStream.Close();
//                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
//                            }
//                        }
//                    }
//                }
//            }
//        }

//        private static byte[] Generate256BitsOfRandomEntropy()
//        {
//            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
//            using (var  rngCsp = new RNGCryptoServiceProvider())
//            {
//                // Fill the array with cryptographically secure random bytes.
//                rngCsp.GetBytes(randomBytes);
//            }
//            return randomBytes;
//        }
//    }
//}