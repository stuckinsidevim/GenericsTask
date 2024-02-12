namespace GenericsTask
{

    public class SpecialQ<T> where T : class, new()
    {
        private T?[] elements;
        private int head;
        private int tail;
        private int capacity;
        private int Size => (tail - head + capacity) % capacity;

        public SpecialQ(int initialCapacity = 10)
        {
            capacity = initialCapacity;
            elements = new T?[capacity];
        }
        public void Enqueue(T? item = null)
        {
            if (IsFull())
            {
                Resize();
            }

            elements[tail] = item ?? new T();
            tail = (tail + 1) % capacity;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T item = elements[head] ?? throw new InvalidOperationException("Queue item unexpectedly null.");
            elements[head] = null;
            head = (head + 1) % capacity;
            return item;
        }

        public bool IsEmpty()
        {
            return head == tail && elements[head] == null;
        }

        public bool IsFull()
        {
            return head == tail && elements[head] != null;
        }

        private void Resize()
        {
            int newCapacity = capacity * 2;
            T?[] newElements = new T?[newCapacity];
            int currentSize = Size;

            for (int i = 0; i < currentSize; i++)
            {
                newElements[i] = elements[(head + i) % capacity];
            }

            capacity = newCapacity;
            head = 0;
            tail = currentSize;
            elements = newElements;
        }
    }
}
