using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace pentelhoin
{
    public class Block
    {
        private int Index { get; set; }
        private string Data { get; set; }
        private DateTime TimeStamp { get; set; }
        private string Hash { get; set; }
        private string PreviousHash { get; set; }

        public Block(int index, string data, DateTime timestamp, string hash, string previousHash)
        {
            Index = index;
            Data = data;
            TimeStamp = timestamp;
            Hash = hash;
            PreviousHash = previousHash;
        }

        public string CalculateHash()
        {
            string baseString = String.Format($"{TimeStamp}-{PreviousHash ?? ""}-{Data}");
            StringBuilder stringBuilder = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(encoding.GetBytes(baseString));

                foreach (Byte b in result)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
            }
            return stringBuilder.ToString();
        }
    }
}
