using System;
using System.Collections.Generic;
using System.Text;

namespace pentelhoin
{
    public class Blockchain
    {
        public IList<Block> Chain { get; set; }
        public int Difficulty { get; set; }

        public Blockchain()
        {
            InitializeChain();
            AddGenesisBlock();
        }

        public void InitializeChain()
        {
            Chain = new List<Block>();
        }

        private void AddGenesisBlock()
        {
            Chain.Add(CreateGenesisBlock());
        }

        public Block CreateGenesisBlock()
        {
            return new Block(0, "Ma nigga Jones", new DateTime(1999, 7, 23), null);
        }

        public Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }

        public void AddBlock(Block block)
        {
            Block latestBlock = GetLatestBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Mine(this.Difficulty);
            Chain.Add(block);
        }
    }
}
