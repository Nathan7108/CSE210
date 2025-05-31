public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus, int completed = 0)
        : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = completed;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted == _target)
            return _points + _bonus;
        else
            return _points;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString() => $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description}) -- Completed: {_amountCompleted}/{_target}";

    public override string GetStringRepresentation() => $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
}
