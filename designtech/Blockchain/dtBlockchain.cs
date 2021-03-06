﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace dtBlockchain
{
    class Blockchain
    {
        internal Blockchain()
        {

        }

        #region CreateBlock
        /// <summary>
        /// Creates a block for the block chain
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="timestamp">timestamp</param>
        /// <param name="data">data</param>
        /// <param name="hash">hash</param>
        /// <param name="previousHash">previousHash</param>
        /// <param name="block">output</param>
        /// <search>
        /// create, block, hash, sha256, blockchain
        /// </search>
        private static object CreateBlock(int index, DateTime timestamp, string data, object hash, string previousHash)
        {
            List<object> list = new List<object>();
            list.Add("Index: " + index.ToString());
            list.Add("Timestamp: " + timestamp.ToString());
            list.Add("Data: " + data.ToString());
            list.Add("Hash: " + hash.ToString());
            list.Add("Previous Hash: " + previousHash.ToString());
            return list;

        }
        #endregion

        #region CreateBlockchain
        /// <summary>
        /// Creates the initial genesis block used in a blockchain
        /// </summary>
        /// <param name="count">count</param>
        /// <search>
        /// blockchain, create
        /// </search>
        private static object CreateBlockchain(int count)
        {
            var blockchain = dtBlockchain.Blockchain.CreateGenesisBlock();
            List<object> blockList = new List<object>();
            blockList.Add(blockchain);


            for (int i = 0; i < count; i++)
            {
                var addBlock = dtBlockchain.Blockchain.NextBlock(blockList);
                blockList.Add(addBlock);
            }
            return blockList;

        }
        #endregion

        #region CreateGenesisBlock
        /// <summary>
        /// Creates the initial genesis block used in a blockchain
        /// </summary>
        /// <param name="block">output</param>
        /// <search>
        /// create, block, hash, sha256, blockchain, genesis, start
        /// </search>
        private static object CreateGenesisBlock()
        {
            int index = 0;
            DateTime timestamp = DateTime.Now;
            string data = "Genesis Block";
            string str = index.ToString() + timestamp.ToString() + data.ToString();
            SHA256 hash = SHA256.Create(str);
            string previousHash = "";
            object blk = dtBlockchain.Blockchain.CreateBlock(index, timestamp, data, hash, previousHash);
            return blk;
        }
        #endregion

        #region NextBlock
        /// <summary>
        /// Creates the next block in the blockchain
        /// </summary>
        /// <param name="lastBlock">index</param>
        /// <param name="nextBlock">output</param>
        /// <search>
        /// create, block, hash, sha256, blockchain, next
        /// </search>
        private static object NextBlock(List<object> lastBlock)
        {
            string str = lastBlock[0].ToString();
            string rep = str.Replace(" ", "");
            string s = ":";
            char[] c = s.ToCharArray();
            string[] split = rep.Split(c);
            int thisIndex = (Int32.Parse(split[1])) + 1;
            DateTime thisTimestamp = DateTime.Now;
            string thisData = "block" + thisIndex.ToString() + "data";
            string hashString = thisIndex.ToString() + thisTimestamp.ToString() + thisData.ToString();
            SHA256 thisHash = SHA256.Create(hashString);
            string str2 = lastBlock[3].ToString();
            string rep2 = str2.Replace(" ", "");
            string[] split2 = rep2.Split(c);
            string thisPreviousHash = split2[1];
            var blk = dtBlockchain.Blockchain.CreateBlock(thisIndex, thisTimestamp, thisData, thisHash, thisPreviousHash);
            return blk;

        }
        #endregion

    }
}
