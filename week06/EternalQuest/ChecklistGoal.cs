public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus)
        : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }
    
    public ChecklistGoal(string name, string desc, int points, int target, int bonus, int amountCompleted)
        : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        _amountCompleted = _amountCompleted + 1;
        
        Console.WriteLine($"You have done this {_amountCompleted} times out of {_target}");
        
        if (_amountCompleted == _target)
        {
            Console.WriteLine($"Bonus achieved! You get {_bonus} extra points!");
            return _points + _bonus;
        }
        return _points;
    }

    public override bool IsComplete()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        }
        return false;
    }

    public override string GetDetailsString()
    {
        string checkMark = " ";
        if (IsComplete())
        {
            checkMark = "X";
        }

        return $"[{checkMark}] {_shortName} ({_description}) -- Done: {_amountCompleted}/{_target} times -- Bonus: {_bonus} points";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
    }
}
