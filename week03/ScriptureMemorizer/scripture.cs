using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ')
                         .Select(w => new Word(w))
                         .ToList();
        }

        public void Display()
        {
            Console.WriteLine(_reference.ToString());
            Console.WriteLine();
            foreach (var word in _words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine("\n");
        }

        public void HideWords(int amount)
        {
            var visible = _words.Where(w => !w.IsHidden).ToList();
            int count = Math.Min(amount, visible.Count);

            for (int i = 0; i < count; i++)
            {
                int index = _random.Next(visible.Count);
                visible[index].Hide();
                visible.RemoveAt(index);
            }
        }

        public bool AllHidden()
        {
            return _words.All(w => w.IsHidden);
        }
    }
}
