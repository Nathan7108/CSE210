using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void End()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3);
        Console.WriteLine($"You completed the {_name} activity for {_duration} seconds.");
        Thread.Sleep(3000);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i++ % spinner.Length]);
            Thread.Sleep(700);
            Console.Write("\b \b");
        }
    }

    /// Was getting bugs so I had to make more complex, unsure why.
    /// It was not working when my breathe time was 2 digits... but it works now.
    protected void ShowCountdown(int seconds)
    {
        int previousLength = 0;

        for (int i = seconds; i > 0; i--)
        {
            string text = i.ToString();
            
            Console.Write(new string('\b', previousLength));
            Console.Write(new string(' ', previousLength));
            Console.Write(new string('\b', previousLength));
            
            Console.Write(text);
            previousLength = text.Length;

            Thread.Sleep(1000);
        }

        Console.Write(new string('\b', previousLength));
        Console.Write(new string(' ', previousLength));
        Console.Write(new string('\b', previousLength));
    }

}
