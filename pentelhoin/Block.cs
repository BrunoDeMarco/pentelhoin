using System;
using System.Collections.Generic;
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
    }
}
