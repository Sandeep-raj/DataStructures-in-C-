using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hashing;

namespace Set
{

    public interface HashSet<T>
    {
        void Add(T item);
        void Remove(T item);
        int GetCount();
        void SetCount(int count);
        int GetCapacity();
        object GetData();
        object Union(object set);
        object Intersection(object set);
        object Difference(object set);
        bool IsSubset(object set);
    }

    public class intHashSet : HashSet<int>
    {
        byte[] bytearr;
        public int Count;
        public int Capacity;
        public intHashSet()
        {
            Capacity = 1000;
            bytearr = new byte[Capacity];
        }
        public intHashSet(int capacity)
        {
            Capacity = capacity;
            bytearr = new byte[Capacity];
        }
        public int GetCount()
        {
            return this.Count;
        }
        public void SetCount(int count)
        {
            this.Count = count;
        }
        public int GetCapacity()
        {
            return this.Capacity;
        }
        public object GetData()
        {
            return this.bytearr;
        }
        public void Add(int item)
        {
            ((byte[])GetData())[item] = 1;
            SetCount(GetCount() + 1);
        }
        public void Remove(int item)
        {
            ((byte[])GetData())[item] = 0;
        }
        public object Union(object set)
        {
            intHashSet temp = null;
            if (this.GetCapacity() >= ((intHashSet)set).GetCapacity())
            {
                temp = new intHashSet(this.GetCapacity());
                for (int i = 0; i < this.GetCapacity(); i++)
                {
                    if (i < ((intHashSet)set).GetCapacity())
                    {
                        if ((((byte[])GetData())[i] | ((byte[])((intHashSet)set).GetData())[i]) == 1)
                        {
                            ((byte[])temp.GetData())[i] = 1;
                            temp.SetCount(temp.GetCount() + 1);
                        }
                    }
                    else
                    {
                        if (((byte[])GetData())[i] == 1)
                        {
                            ((byte[])temp.GetData())[i] = 1;
                            temp.SetCount(temp.GetCount() + 1);
                        }
                    }
                }
            }
            else
            {
                temp = new intHashSet(((intHashSet)set).GetCapacity());
                for (int i = 0; i < ((intHashSet)set).GetCapacity(); i++)
                {
                    if (i < this.GetCapacity())
                    {
                        if ((((byte[])GetData())[i] | ((byte[])((intHashSet)set).GetData())[i]) == 1)
                        {
                            ((byte[])temp.GetData())[i] = 1;
                            temp.SetCount(temp.GetCount() + 1);
                        }
                    }
                    else
                    {
                        if (((byte[])((intHashSet)set).GetData())[i] == 1)
                        {
                            ((byte[])temp.GetData())[i] = 1;
                            temp.SetCount(temp.GetCount() + 1);
                        }
                    }
                }
            }
            return temp;
        }
        public object Intersection(object set)
        {
            intHashSet temp = null;
            if (this.GetCapacity() >= ((intHashSet)set).GetCapacity())
            {
                temp = new intHashSet(((intHashSet)set).GetCapacity());
                for (int i = 0; i < ((intHashSet)set).GetCapacity(); i++)
                {
                    if ((((byte[])GetData())[i] & ((byte[])((intHashSet)set).GetData())[i]) == 1)
                    {
                        ((byte[])temp.GetData())[i] = 1;
                        temp.SetCount(temp.GetCount() + 1);

                    }
                }
            }
            else
            {
                temp = new intHashSet(this.GetCapacity());
                for (int i = 0; i < this.GetCapacity(); i++)
                {
                    if ((((byte[])GetData())[i] & ((byte[])((intHashSet)set).GetData())[i]) == 1)
                    {
                        ((byte[])temp.GetData())[i] = 1;
                        temp.SetCount(temp.GetCount() + 1);

                    }
                }
            }
            return temp;
        }
        public object Difference(object set)
        {
            intHashSet temp = new intHashSet(this.GetCapacity());
            for (int i = 0; i < this.GetCapacity(); i++)
            {
                if (i < ((intHashSet)set).GetCapacity())
                {
                    if (((byte[])GetData())[i] == 1 && ((byte[])((intHashSet)set).GetData())[i] == 0)
                    {
                        ((byte[])temp.GetData())[i] = 1;
                        temp.SetCount(temp.GetCount() + 1);
                    }
                }
                else
                {
                    ((byte[])temp.GetData())[i] = ((byte[])GetData())[i];
                    temp.SetCount(temp.GetCount() + 1);
                }
            }
            return temp;
        }
        public bool IsSubset(object set)
        {
            if (this.GetCount() <= ((intHashSet)set).GetCount())
            {
                for (int i = 0; i < GetCapacity(); i++)
                {
                    if (((byte[])GetData())[i] != 0)
                        if (((byte[])GetData())[i] != ((byte[])((intHashSet)set).GetData())[i])
                            return false;
                }
                return true;
            }
            return false;
        }
    }

    public class stringHashSet : HashSet<string>
    {
        private Hash<string> hashTable;
        public int Count;
        public int Capacity;
        public stringHashSet()
        {
            hashTable = new Hash<string>();
            Count = 0;
        }
        public int GetCount()
        {
            return this.Count;
        }
        public void SetCount(int count)
        {
            this.Count = count;
        }
        public int GetCapacity()
        {
            return this.Capacity;
        }
        public object GetData()
        {
            return this.hashTable;
        }
        public void Remove(string item)
        {
            ((Hash<string>)GetData()).Remove(item);
        }
        public void Add(string item)
        {
            if (!((Hash<string>)GetData()).Find(item))
            {
                ((Hash<string>)GetData()).Add(item);
                SetCount(this.GetCount() + 1);
            }
        }
        public object Intersection(object set)
        {
            stringHashSet temp = new stringHashSet();
            if (this.Count > ((stringHashSet)set).Count)
            {
                foreach (string s in ((Hash<string>)((stringHashSet)set).GetData()).Getelements())
                {
                    if (((Hash<string>)GetData()).Find(s))
                    {
                        temp.Add(s);
                    }
                }
            }
            else
            {
                foreach (string s in ((Hash<string>)GetData()).Getelements())
                {
                    if (((Hash<string>)((stringHashSet)set).GetData()).Find(s))
                    {
                        temp.Add(s);
                    }
                }
            }
            return temp;
        }
        public object Union(object set)
        {
            stringHashSet temp = new stringHashSet();
            foreach (string s in ((Hash<string>)GetData()).Getelements())
            {
                temp.Add(s);
            }
            foreach (string s in ((Hash<string>)((stringHashSet)set).GetData()).Getelements())
            {
                if (!((Hash<string>)temp.GetData()).Find(s))
                {
                    temp.Add(s);
                }
            }

            return temp;
        }
        public object Difference(object set)
        {
            stringHashSet temp = new stringHashSet();
            foreach (string s in ((Hash<string>)GetData()).Getelements())
            {
                if (!((Hash<string>)((stringHashSet)set).GetData()).Find(s))
                {
                    temp.Add(s);
                }
            }

            return temp;
        }
        public bool IsSubset(object set)
        {
            if (this.GetCount() <= ((stringHashSet)set).GetCount())
            {
                foreach (string s in ((Hash<string>)this.GetData()).Getelements())
                {
                    if (s != default(string))
                        if (!((Hash<string>)(set as stringHashSet).GetData()).Find(s))
                        {
                            return false;
                        }
                }
                return true;
            }
            return false;
        }
    }

    public class CSet<T>
    {
        HashSet<T> Set;
        public CSet()
        {
            if (typeof(T) == typeof(int))
            {
                Set = (HashSet<T>)new intHashSet();
            }
            if (typeof(T) == typeof(string))
            {
                Set = (HashSet<T>)new stringHashSet();
            }
        }

        public void Add(T item)
        {
            Set.Add(item);
        }
        public void Remove(T item)
        {
            Set.Remove(item);
        }
        public CSet<T> Union(CSet<T> item)
        {
            HashSet<T> res = (HashSet<T>)Set.Union(item.Set);
            CSet<T> temp = new CSet<T>();
            temp.Set = res;
            return temp;
        }
        public CSet<T> Intersection(CSet<T> item)
        {
            HashSet<T> res = (HashSet<T>)Set.Intersection(item.Set);
            CSet<T> temp = new CSet<T>();
            temp.Set = res;
            return temp;
        }
        public CSet<T> Difference(CSet<T> item)
        {
            HashSet<T> res = (HashSet<T>)Set.Difference(item.Set);
            CSet<T> temp = new CSet<T>();
            temp.Set = res;
            return temp;
        }
        public bool IsSubset(CSet<T> item)
        {
            return this.Set.IsSubset(item.Set);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CSet<int> set = new CSet<int>();
            set.Add(7);
            set.Add(2);
            set.Add(6);

            CSet<int> set2 = new CSet<int>();
            set2.Add(1);
            set2.Add(2);
            set2.Add(0);

            CSet<int> set3 = new CSet<int>();
            set3.Add(2);
            set3.Add(7);

            CSet<int> res = set.Union(set2);
            CSet<int> res2 = set.Intersection(set2);
            CSet<int> res3 = set.Difference(set2);
            var res4 = set3.IsSubset(set);

            CSet<string> set4 = new CSet<string>();
            set4.Add("Sandeep");
            set4.Add("Shivu");
            set4.Add("Rahul");

            CSet<string> set5 = new CSet<string>();
            set5.Add("Gaurav");
            set5.Add("Abhishek");

            CSet<string> res5 = set4.Union(set5);
            CSet<string> res6 = res5.Intersection(set4);
            CSet<string> res7 = res6.Difference(set4);
            var res8 = set4.IsSubset(res5);
        }
    }
}
