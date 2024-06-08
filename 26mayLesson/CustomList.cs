using System;
using System.Collections;

namespace Task1
{
    public class CustomList<T>: IEnumerable
    {
        private T[] values;
        private int count;
        private int capacity;
        public T[] Values { get => values; }
        public int Capacity { get; set; }
        public int Count { get; set; }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public CustomList()
        {
            values = new T[0];
            capacity = values.Length;

        }

        public void Add(T value)
        {
            if (count == capacity)
            {
                Array.Resize(ref values, capacity == 0 ? 4 : values.Length * 2);
                capacity = values.Length;
            }
            values[count] = value;
            count++;
        }

        public void Remove(T value)
        {
            int index = Array.IndexOf(values, value);
            if (index != -1)
            {
                for (int i = index; i < count; i++)
                {
                    values[i] = values[i + 1];

                }
                count--;
            }

        }

        public void GetAll()
        {
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }

        }

        public bool Contains(T item)
        {
            int index = Array.IndexOf(values, item);
            if (index != -1)
            {
                return true;
            }
            return false;

        }

        public bool Any(Predicate<T> predicate=null)
        {
            if (values.Length > 0 && predicate is null)
            {
                return true;
            }
            for (int i = 0; i <= count; i++)
            {
                if (predicate(values[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            for (int i = 0; i < count; i++)
            {
                values[i] = default;
            }

            count = 0;
        }

        public T FirstOrDefault(Predicate<T> predicate = null)
        {
            if (count > 0 && predicate is null)
            {
                return values[0];
            }

            for(int i = 0; i <= count; i++)
            {
                if (predicate(values[i]))
                {
                    return values[i];
                }
            }

            return default;

        }

        public T ElementAtOrDefault(int index)
        {
            if (index > 0 && index < count)
            {
                return values[index];
            }

            return default;
            
        }

        public T LastOrDefault(Predicate<T> predicate=null)
        {
            if (Any() && predicate is null)
            {
                return values[count];
            }

            for (int i=count-1; i <= 0; i--)
            {
                if (predicate(values[i]))
                {
                    return values[i];
                }

            }

            return default;
        }

       


    }


}