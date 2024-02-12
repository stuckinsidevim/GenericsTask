namespace GenericsTask
{
    public class SpecialStackk<T> where T : struct
    {
        private readonly T[] elements;
        private int size;
        private const int capacity = 10;

        public SpecialStackk()
        {
            elements = new T[capacity];
        }

        public void Push(T item = default)
        {
            if (size == capacity)
            {
                throw new InvalidOperationException("Stack is full.");
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
    }
}
