using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        foreach (Entry e in _entries)
        {
            e.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Date,Prompt,Response");

            foreach (Entry e in _entries)
            {
                string date = $"\"{e._date}\"";
                string prompt = $"\"{e._prompt.Replace("\"", "\"\"")}\"";
                string response = $"\"{e._response.Replace("\"", "\"\"")}\"";

                writer.WriteLine($"{date},{prompt},{response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        for (int i = 1; i < lines.Length; i++) 
        {
            string[] parts = lines[i].Split(new[] { "\",\"" }, StringSplitOptions.None);

            if (parts.Length == 3)
            {
                string date = parts[0].Trim('"');
                string prompt = parts[1].Trim('"');
                string response = parts[2].Trim('"');

                _entries.Add(new Entry(date, prompt, response));
            }
        }
    }
}
