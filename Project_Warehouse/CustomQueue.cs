using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
    internal class CustomQueue<T> : IQueueable<T>
    {
        private List<T> data = new List<T>();

        public void Enqueue(T item)
        {
            data.Add(item);
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new EmptyStructureException("Queue is empty");

            T item = data[0];
            data.RemoveAt(0);
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new EmptyStructureException("Queue is empty");

            return data[0];
        }

        public bool IsEmpty()
        {
            return data.Count == 0;
        }

    }
}

