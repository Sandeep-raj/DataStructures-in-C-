using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class MinHeap
    {
        public int[] arr;
        public int capacity;
        public int upperIndex;

        public MinHeap(int capacity)
        {
            this.capacity = capacity;
            arr = new int[capacity];
            upperIndex = -1;
        }
        public MinHeap()
        {
            this.capacity = 32;
            arr = new int[32];
            upperIndex = -1;
        }

        public void Insert(int data)
        {
            if (upperIndex + 1 < capacity)
            {
                upperIndex++;
                arr[upperIndex] = data;
                HeapifyUp(arr, upperIndex);
            }
        }

        public int GetMinimum()
        {
            int min = arr[0];
            arr[0] = arr[upperIndex];
            upperIndex--;
            HeapifyDown(arr, 0);
            return min;
        }

        public int getParent(int index)
        {
            return (index - 1) / 2;
        }

        public int getMinimumChild(int index)
        {
            int temp = -1;
            if(2*index + 2 <= upperIndex)
            {
                temp = (arr[2 * index + 1] > arr[2 * index + 2] ? 2 * index + 2 : 2 * index + 1);
            }
            else if(2*index + 1 == upperIndex)
            {
                temp = 2 * index + 1;
            }

            if(temp != -1)
            {
                temp = arr[temp] > arr[index] ? -1 : temp;
            }

            return temp;
        }

        public void HeapifyUp(int[] arr, int index)
        {
            if (getParent(index) >= 0 && arr[index] < arr[getParent(index)])
            {
                int temp = arr[getParent(index)];
                arr[getParent(index)] = arr[index];
                arr[index] = temp;
                HeapifyUp(arr, getParent(index));
            }
        }

        public void HeapifyDown(int[] arr, int index)
        {
            int minIndex = getMinimumChild(index);
            if (minIndex != -1)
            {
                int temp = arr[minIndex];
                arr[minIndex] = arr[index];
                arr[index] = temp;
                HeapifyDown(arr, minIndex);
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MinHeap heap = new MinHeap();
            heap.Insert(23);
            heap.Insert(3);
            heap.Insert(78);
            heap.Insert(15);
            heap.Insert(67);
            heap.Insert(41);
            heap.Insert(11);
            for(int i=0;i<7;i++)
                Console.WriteLine(heap.GetMinimum());
        }
    }
}
