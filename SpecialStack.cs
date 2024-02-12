namespace GenericsTask
{
    public class SpecialStackk<T> where T : struct
    {
        private T[] elements;
        private int size;
        private int capacity;

        public SpecialStackk(int initialCapacity = 10)
        {
            capacity = initialCapacity;
            elements = new T[capacity];
        }

        public void Push(T item = default)
        {
            if (size == capacity)
            {
                Resize();
            }

            elements[size++] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T item = elements[--size];
            elements[size] = default;
            return item;
        }

        public T Peek()
        {
            return !IsEmpty() ? elements[size - 1] : throw new InvalidOperationException("Stack is empty.");
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        private void Resize()
        {
            int newCapacity = capacity * 2;
            T[] newElements = new T[newCapacity];
            Array.Copy(elements, newElements, size);
            capacity = newCapacity;
            elements = newElements;
        }
    }
}
