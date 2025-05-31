using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
/* This exceeds requiremnts by adding a level up system in the goal manager. Every 200 points
the user levels up. I also added messages after something is completed like "good job" etc...
*/
