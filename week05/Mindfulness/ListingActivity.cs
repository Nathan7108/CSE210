using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life.") { }

    public void Run()
    {
        Start();
        string prompt = _prompts[new Random().Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("You may begin in...");
        ShowCountdown(5);

        List<string> responses = new();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
                responses.Add(response);
        }

        Console.WriteLine("\nHere are the items you listed:");
        foreach (var item in responses)
        {
            Console.WriteLine($"- {item}");
            Thread.Sleep(300);
        }
        Console.WriteLine($"\nYou listed {responses.Count} items.");

        End();
    }
}
