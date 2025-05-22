using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var reference = new Reference("2 Nephi", 2, 25);
            string text = "Adam fell that men might be; and men are, that they might have joy.";

            var scripture = new Scripture(reference, text);

            while (true)
            {
                Console.Clear();
                scripture.Display();

                if (scripture.AllHidden())
                    break;

                Console.Write("Press ENTER to continue or type 'quit' to stop: ");
                var input = Console.ReadLine()?.Trim().ToLower();

                if (input == "quit")
                    break;

                scripture.HideWords(3);
            }

            Console.Clear();
            scripture.Display();
            Console.WriteLine("Done! Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}
