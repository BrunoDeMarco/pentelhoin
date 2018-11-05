using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace pentelhoin
{
    public class Block
    {
        public int Index { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Hash { get; set; }
        public string PreviousHash { get; set; }
        public int Nonce { get; set; } = 0;

        public Block(int index, IList<Transaction> transactions, DateTime timestamp, string previousHash)
        {
            Index = index;
            Transactions = transactions;
            TimeStamp = timestamp;
            Hash = CalculateHash();
            PreviousHash = previousHash;
        }

        public Block(DateTime timestamp, IList<Transaction> transactions)
        {
            TimeStamp = timestamp;
            Transactions = transactions;
        }

        public string CalculateHash()
        {
            string baseString = String.Format($"{TimeStamp}-{PreviousHash ?? ""}-{JsonConvert.SerializeObject(Transactions)}-{Nonce}");
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

        public void Mine(int difficulty)
        {
            var leadingZeros = new string('0', difficulty);
            while (this.Hash == null || this.Hash.Substring(0, difficulty) != leadingZeros)
            {
                this.Nonce++;
                this.Hash = this.CalculateHash();
            }
        }
    }
}
