using System;

public class Job
{
    public string _company;
    public string _title;
    public int    _startYear;
    public int    _endYear;

    public Job() { }

    public void Display()
    {
        Console.WriteLine($"{_title} ({_company}) {_startYear}-{_endYear}");
    }
}
