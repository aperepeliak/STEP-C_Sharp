using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_5._2_generics_collections
{
    class MyList<T>
    {
        T[] arr;
        private int size;

        public MyList()
        {
            arr = null;
            size = 0;
        }

        // Read-only property for total number of elements
        public int Size
        {
            get { return size; }
        }

        public void Add(T newElement)
        {
            if (size == 0)
            {
                size++;
                arr = new T[size];
                arr[size - 1] = newElement;
            }
            else
            {
                size++;
                T[] tmp = new T[size];
                for (int i = 0; i < tmp.Length - 1; i++)
                {
                    tmp[i] = arr[i];
                }
                tmp[size - 1] = newElement;
                arr = tmp;
            }
        }

        // Indexer
        public T this[int key]
        {
            get
            {
                return arr[key];
            }
            set
            {
                arr[key] = value;
            }
        }


    }
}
