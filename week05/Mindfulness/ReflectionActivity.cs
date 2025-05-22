public class ReflectionActivity : Activity
{
    private List<string> _promptPool;
    private List<string> _questionPool;
    private List<string> _usedPrompts = new();
    private List<string> _usedQuestions = new();

    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on times you’ve shown strength and resilience.")
    {
        _promptPool = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questionPool = new List<string>
        {
            "Why was this experience meaningful to you?",
            "How did you feel when it was complete?",
            "What did you learn about yourself through this experience?",
            "What made this time different than other times when you were not as successful?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        Start();

        if (_promptPool.Count == 0)
        {
            _promptPool.AddRange(_usedPrompts);
            _usedPrompts.Clear();
        }

        string prompt = GetUniqueItem(_promptPool, _usedPrompts);
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("Reflect on the following questions:");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            if (_questionPool.Count == 0)
            {
                _questionPool.AddRange(_usedQuestions);
                _usedQuestions.Clear();
            }

            string question = GetUniqueItem(_questionPool, _usedQuestions);
            Console.WriteLine(question);
            ShowSpinner(5);
        }

        End();
    }

    private string GetUniqueItem(List<string> pool, List<string> used)
    {
        var rand = new Random();
        int index = rand.Next(pool.Count);
        string item = pool[index];
        used.Add(item);
        pool.RemoveAt(index);
        return item;
    }
}
