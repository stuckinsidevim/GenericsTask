namespace GenericsTask
{
    public class Program
    {
        private static readonly SpecialStackk<int> stack = new();
        private static readonly SpecialQ<ChatMessage> queue = new();
        private static int messageIdCounter;

        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Special Stack and Message Queue Console!");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Work with Stack (integers only)");
                Console.WriteLine("2. Work with Message Queue (ChatMessage)");
                Console.WriteLine("3. Exit");
                Console.Write("Input :: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StackOperations();
                        break;
                    case "2":
                        QueueOperations();
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        public static void StackOperations()
        {
            Console.WriteLine("Stack Operations:");
            Console.WriteLine("1. Push");
            Console.WriteLine("2. Pop");
            Console.WriteLine("3. Peek");
            Console.WriteLine("4. Check if Empty");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Input :: ");

            string? operation = Console.ReadLine();

            try
            {
                switch (operation)
                {
                    case "1":
                        Console.WriteLine("Enter an integer to push onto the stack:");
                        if (int.TryParse(Console.ReadLine(), out int number))
                        {
                            stack.Push(number);
                            Console.WriteLine($"{number} pushed onto the stack.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter an integer.");
                        }
                        break;
                    case "2":
                        var popped = stack.Pop();
                        Console.WriteLine($"{popped} popped from the stack.");
                        break;
                    case "3":
                        var peeked = stack.Peek();
                        Console.WriteLine($"{peeked} is on top of the stack.");
                        break;
                    case "4":
                        Console.WriteLine(stack.IsEmpty() ? "Stack is empty." : "Stack is not empty.");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid operation. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

            }
        }


        public static void QueueOperations()
        {
            Console.WriteLine("Queue Operations:");
            Console.WriteLine("1. Enqueue");
            Console.WriteLine("2. Dequeue");
            Console.WriteLine("3. Check if Empty");
            Console.WriteLine("4. Check if Full");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Input :: ");

            string? operation = Console.ReadLine();

            try
            {
                switch (operation)
                {
                    case "1":
                        Console.WriteLine("Enter the content of the ChatMessage:");
                        string content = Console.ReadLine() ?? string.Empty;
                        queue.Enqueue(new ChatMessage
                        {
                            MessageId = ++messageIdCounter,
                            Content = content,
                            TimeStamp = DateTime.Now,
                            SourceId = new Random().Next(1000)
                        });
                        Console.WriteLine("ChatMessage enqueued.");
                        break;
                    case "2":
                        ChatMessage dequeuedMessage = queue.Dequeue();
                        Console.WriteLine($"Dequeued message: ID {dequeuedMessage.MessageId}, Content: {dequeuedMessage.Content}, TimeStamp: {dequeuedMessage.TimeStamp}, SourceId: {dequeuedMessage.SourceId}");
                        break;
                    case "3":
                        Console.WriteLine(queue.IsEmpty() ? "Queue is empty." : "Queue is not empty.");
                        break;
                    case "4":
                        Console.WriteLine(queue.IsFull() ? "Queue is full." : "Queue is not full.");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid operation. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

}
