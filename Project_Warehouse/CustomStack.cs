using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
     class CustomStack<T>
     {
        private List<T> data = new List<T>();

        public void Push(T item)
        {
            data.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new EmptyStructureException("Stack is Empty");

            int last = data.Count - 1;
            T item = data[last];
            data.RemoveAt(last);
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new EmptyStructureException("Stack is Empty");
            return data[data.Count - 1];
        }

        public bool IsEmpty()
        {
            return data.Count == 0;
        }

     }
}
