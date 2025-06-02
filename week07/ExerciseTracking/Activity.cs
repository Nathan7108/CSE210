public class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return GetDate() + " " + this.GetType().Name + " (" + GetMinutes() + " min) - Distance: "
            + GetDistance().ToString("0.0") + " miles, Speed: "
            + GetSpeed().ToString("0.0") + " mph, Pace: "
            + GetPace().ToString("0.0") + " min per mile";
    }
    
}
