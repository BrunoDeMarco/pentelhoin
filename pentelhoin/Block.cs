﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace pentelhoin
{
    public class Block
    {
        public int Index { get; set; }
        public string Data { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Hash { get; set; }
        public string PreviousHash { get; set; }

        public Block(int index, string data, DateTime timestamp, string previousHash)
        {
            Index = index;
            Data = data;
            TimeStamp = timestamp;
            Hash = CalculateHash();
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
