namespace GenericsTask
{

    public class SpecialQ<T> where T : class, new()
    {
        private readonly T?[] elements; // Notice the nullable reference type declaration
        private int head;
        private int tail;
        private const int capacity = 10;

        public SpecialQ()
        {
            elements = new T?[capacity];
        }

        public void Enqueue(T? item = null)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Queue is full.");
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
    }
}
