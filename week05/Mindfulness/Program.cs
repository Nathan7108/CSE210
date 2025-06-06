using System;

class Program
{
    static Dictionary<string, int> activityLog = new Dictionary<string, int>();
    
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program\n");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

        if (activityLog.Count == 0)
        {
            activityLog["Breathing"] = 0;
            activityLog["Reflection"] = 0;
            activityLog["Listing"] = 0;
        }

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                        activityLog["Breathing"]++;
                        break;
                case "2":
                    new ReflectionActivity().Run();
                    activityLog["Reflection"]++;
                    break;

                case "3":
                    new ListingActivity().Run();
                    activityLog["Listing"]++;
                    break;
                case "4":
                    Console.WriteLine("\nSession Summary:");
                    foreach (var activity in activityLog)
                    {
                        Console.WriteLine($"{activity.Key} Activity ran {activity.Value} time(s)");
                    }

                    Console.WriteLine("\nGoodbye!");
                    return;
            }
        }
    }
}

/* Added:
Tracks how many times each activity was performed in the session
and prints a summary before quitting.

Session Summary:
Breathing Activity ran 0 time(s)
Reflection Activity ran 0 time(s)
Listing Activity ran 1 time(s)
*/
