public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points)
        : base(name, desc, points) { }

    public override int RecordEvent() => _points;

    public override bool IsComplete() => false;

    public override string GetDetailsString() => $"[ ] {_shortName} ({_description})";

    public override string GetStringRepresentation() => $"EternalGoal:{_shortName},{_description},{_points}";
}
