using System;

public class BreathingActivity : Activity
{
    private int _breatheInTime = 4;
    private int _breatheOutTime = 6;

    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by guiding you through slow breathing.") { }

    public void Run()
    {
        Start();

        Console.Write("Enter inhale duration in seconds (default 4): ");
        if (int.TryParse(Console.ReadLine(), out int customIn)) _breatheInTime = customIn;

        Console.Write("Enter exhale duration in seconds (default 6): ");
        if (int.TryParse(Console.ReadLine(), out int customOut)) _breatheOutTime = customOut;

        Console.WriteLine("Starting breathing cycle...\n");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(_breatheInTime);
            Console.Write("Breathe out... ");
            ShowCountdown(_breatheOutTime);
            Console.WriteLine();
        }

        End();
    }
}
