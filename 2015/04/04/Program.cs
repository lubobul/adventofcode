using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace _04
{
    class Program
    {

        public static string CalculateMD5Hash(string input)
        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

        static void Main(string[] args)
        {
            int leadingNumber = 0;
            string hash = "11111";
            do
            {
                leadingNumber++;
                hash = CalculateMD5Hash($"bgvyzdsv{leadingNumber}");    
            } while (!hash.Substring(0, 6).Equals("000000"));

            Console.WriteLine($"Hash: {hash} Number: {leadingNumber}");
            Console.ReadKey();
        }
    }
}
