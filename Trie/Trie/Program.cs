using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> map;
        public bool EoW;

        public TrieNode()
        {
            map = new Dictionary<char, TrieNode>();
            EoW = false;
        }

    }

    public class Trie
    {
        public TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode curr = root;
            foreach(char c in word)
            {
                TrieNode value;
                if(curr.map.TryGetValue(c,out value))
                {
                    curr = value;
                }
                else
                {
                    curr.map[c] = new TrieNode();
                    curr = curr.map[c];
                }
            }
            curr.EoW = true;
        }
        public bool Search(string word)
        {
            TrieNode curr = root;
            foreach(char c in word)
            {
                TrieNode temp;
                if (curr.map.TryGetValue(c, out temp))
                {
                    curr = temp;
                }
                else
                    return false;
            }
            if (curr.EoW)
            {
                return true;
            }
            return false;
        }
        public void Delete(TrieNode node,string word,int index)
        {
            TrieNode temp;
            if (node.map.TryGetValue(word[index],out temp))
            {
                if (index < word.Length - 1)
                    this.Delete(temp, word, index + 1);
                else
                {
                    if(temp.EoW == true)
                    {
                        if(temp.map.Keys.Count == 0)
                        {
                            node.map.Remove(word[index]);
                            return;
                        }
                        else
                        {
                            temp.EoW = false;
                            return;
                        }
                    }
                }
            }

            if(temp.map.Keys.Count == 0)
            {
                node.map.Remove(word[index]);
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Insert("geeks");
            trie.Insert("abc");
            trie.Insert("geekt");
            trie.Insert("geez");
            //trie.Insert("abde");
            //trie.Insert("abcd");

            //if (trie.Search("abde"))
            //{
            //    Console.WriteLine("found");
            //}
            trie.Delete(trie.root, "geek", 0);
        }
    }
}
