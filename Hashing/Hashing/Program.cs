using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    public class Hash<T>
    {
        T[][] hashTable;
        int capacity;
        double loadFactor;
        int count;
        public Hash(int Capacity, double LoadFactor)
        {
            capacity = Capacity;
            loadFactor = LoadFactor;
            hashTable = new T[capacity][];
            for(int i = 0; i < capacity; i++)
            {
                hashTable[i] = new T[4];
            }
        }
        public Hash()
        {
            capacity = 10037;
            loadFactor = 0.75;
            hashTable = new T[capacity][];
            for (int i = 0; i < capacity; i++)
            {
                hashTable[i] = new T[4];
            }
        }
        public string getType()
        {
            if (typeof(T).Name.ToLower().Contains("string"))
                return "string";
            if (typeof(T).Name.ToLower().Contains("int"))
                return "int";
            else
                return "null";
        }
        public long hashFunction(T item)
        {
            long hashValue = 0;
            if(this.getType() == "string")
            {
                foreach(char c in item as string)
                {
                    hashValue += 37 * hashValue + (int)c;
                }
                hashValue = hashValue % capacity;
                if (hashValue < 0)
                {
                    hashValue += capacity;
                }
            }
            if (this.getType() == "int")
            {
                var value = (int)(object)item;
                hashValue = value % capacity;
            }
            return hashValue;
        }
        public void Add(T item)
        {
            long hashvalue = hashFunction(item);
            if(this.getType() == "int")
            {
                for(int i = 0; i < hashTable[hashvalue].Length; i++)
                {
                    if((int)(object)hashTable[hashvalue][i] == default(int))
                    {
                        hashTable[hashvalue][i] = item;
                        this.count++;
                        if (capacity * loadFactor < hashTable.Count(x => (int)(object)x[0] != default(int)))
                        {
                            Hashing();
                        }
                        return;
                    }
                }
            }
            if (this.getType() == "string")
            {
                for (int i = 0; i < hashTable[hashvalue].Length; i++)
                {
                    if ((string)(object)hashTable[hashvalue][i] == default(string))
                    {
                        hashTable[hashvalue][i] = item;
                        this.count++;
                        if (capacity * loadFactor < hashTable.Count(x => (string)(object)x[0] != default(string)))
                        {
                            Hashing();
                        }
                        return;
                    }
                }
            }
            
        }
        public void Remove(T item)
        {
            long hashvalue = hashFunction(item);
            if (this.getType() == "int")
            {
                for (int i = 0; i < hashTable[hashvalue].Length; i++)
                {
                    if ((int)(object)hashTable[hashvalue][i] == (int)(object)item)
                    {
                       for(int k = i+1; k < hashTable[hashvalue].Length; k++)
                        {
                            if ((int)(object)hashTable[hashvalue][k] != default(int))
                            {
                                hashTable[hashvalue][k-1] = hashTable[hashvalue][k];
                            }
                            else if ((int)(object)hashTable[hashvalue][k] == default(int))
                            {
                                hashTable[hashvalue][k - 1] = hashTable[hashvalue][k];
                                break;
                            }
                        }
                        count--;
                        return;
                    }
                    else if((int)(object)hashTable[hashvalue][i] != default(int))
                    {
                        return;
                    }
                }
            }
            if (this.getType() == "string")
            {
                for (int i = 0; i < hashTable[hashvalue].Length; i++)
                {
                    if (hashTable[hashvalue][i].ToString() == item.ToString())
                    {
                        for (int k = i + 1; k < hashTable[hashvalue].Length; k++)
                        {
                            if ((string)(object)hashTable[hashvalue][k] != default(string))
                            {
                                hashTable[hashvalue][k - 1] = hashTable[hashvalue][k];
                            }
                            else if ((string)(object)hashTable[hashvalue][k] == default(string))
                            {
                                hashTable[hashvalue][k - 1] = hashTable[hashvalue][k];
                                break;
                            }
                                
                        }
                        count--;
                        return;
                    }
                    else if ((string)(object)hashTable[hashvalue][i] != default(string))
                    {
                        return;
                    }
                }
            }
        }                                                     
        public void Hashing()
        {
            this.capacity *= 2;
            T[][] newHashTable = new T[capacity][];
            for(int i =0;i<capacity; i++)
            {
                newHashTable[i] = new T[4];
            }
            if(this.getType() == "int")
            {
                for(int i = 0; i < capacity / 2; i++)
                {
                    foreach(T item in hashTable[i])
                    {
                        if ((int)(object)item != default(int))
                        {
                            long value = hashFunction(item);
                            for (int j = 0; j <= newHashTable[value].Length; j++)
                            {
                                if ((int)(object)newHashTable[value][j] == default(int))
                                {
                                    newHashTable[value][j] = item;
                                    break;
                                }
                            }
                        }
                        else
                            break;
                    }
                }
            }
            if (this.getType() == "string")
            {
                for (int i = 0; i < capacity / 2; i++)
                {
                    foreach (T item in hashTable[i])
                    {
                        if ((string)(object)item != default(string))
                        {
                            long value = hashFunction(item);
                            for (int j = 0; j <= newHashTable[value].Length; j++)
                            {
                                if ((string)(object)newHashTable[value][j] == default(string))
                                {
                                    newHashTable[value][j] = item;
                                    break;
                                }
                            }
                        }
                        else
                            break;
                    }
                }
            }


            hashTable = newHashTable;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Hash<int> hash = new Hash<int>(7,0.75);
            hash.Add(0);
            hash.Add(1);
            hash.Add(2);
            hash.Add(3);
            hash.Add(4);
            hash.Add(5);
            hash.Add(6);
            Console.ReadKey();
        }
    }
}
