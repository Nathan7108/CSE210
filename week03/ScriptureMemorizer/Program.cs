using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public bool IsHidden => _isHidden;

        public void Hide()
        {
            _isHidden = true;
        }

        public override string ToString()
        {
            if (!_isHidden)
                return _text;
            return new string('_', _text.Length);
        }
    }

    class ScriptureReference
    {
        public string Book { get; }
        public int Chapter { get; }
        public int StartVerse { get; }
        public int? EndVerse { get; }

        public ScriptureReference(string book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = verse;
            EndVerse = null;
        }

        public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            if (EndVerse.HasValue)
                return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
            return $"{Book} {Chapter}:{StartVerse}";
        }
    }

    class Scripture
    {
        private ScriptureReference _reference;
        private List<Word> _words;
        private Random _random = new Random();

        public Scripture(ScriptureReference reference, string text)
        {
            _reference = reference;
            _words = text
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => new Word(w))
                .ToList();
        }

        public void Display()
        {
            Console.WriteLine(_reference);
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", _words));
            Console.WriteLine();
        }

        public void HideRandomWords(int count)
        {
            var unhidden = _words.Where(w => !w.IsHidden).ToList();
            int toHide = Math.Min(count, unhidden.Count);

            for (int i = 0; i < toHide; i++)
            {
                int index = _random.Next(unhidden.Count);
                unhidden[index].Hide();
                unhidden.RemoveAt(index);
            }
        }

        public bool AllHidden => _words.All(w => w.IsHidden);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var reference = new ScriptureReference("John", 3, 16);
            var text = "For God so loved the world that he gave his one and only Son, " +
                       "that whoever believes in him shall not perish but have eternal life.";

            var scripture = new Scripture(reference, text);

            while (true)
            {
                Console.Clear();
                scripture.Display();

                if (scripture.AllHidden)
                    break;

                Console.Write("Press ENTER to hide words or type 'quit' to exit: ");
                var input = Console.ReadLine()?.Trim().ToLower();
                if (input == "quit")
                    break;

                scripture.HideRandomWords(3);
            }

            Console.Clear();
            scripture.Display();
            Console.WriteLine("All words have been hidden. Press ENTER to close.");
            Console.ReadLine();
        }
    }
}
