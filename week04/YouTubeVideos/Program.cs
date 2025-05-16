using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Comment
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }

        public Comment(string authorName, string text)
        {
            AuthorName = authorName;
            Text = text;
        }
    }

    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        public List<Comment> Comments { get; set; }

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return Comments.Count;
        }

        public string GetFormattedLength()
        {
            TimeSpan time = TimeSpan.FromSeconds(LengthInSeconds);
            return time.ToString(@"hh\:mm\:ss");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length: {GetFormattedLength()}");
            Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            
            foreach (var comment in Comments)
            {
                Console.WriteLine($"- {comment.AuthorName}: {comment.Text}");
            }

            Console.WriteLine("\n" + new string('-', 40) + "\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Video video1 = new Video("C# Tutorial", "John Doe", 300);
            Video video2 = new Video("ASP.NET Basics", "Jane Smith", 420);
            Video video3 = new Video("Docker for Beginners", "Mike Johnson", 3600);

            video1.AddComment(new Comment("Alice", "Great tutorial!"));
            video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
            video1.AddComment(new Comment("Charlie", "Can you do a follow-up?"));

            video2.AddComment(new Comment("Dave", "I love ASP.NET!"));
            video2.AddComment(new Comment("Eve", "This was really clear."));

            video3.AddComment(new Comment("Frank", "Docker makes life easier."));
            video3.AddComment(new Comment("Grace", "Perfect explanation!"));
            video3.AddComment(new Comment("Heidi", "Looking forward to more."));

            List<Video> videos = new List<Video> { video1, video2, video3 };

            foreach (var video in videos)
            {
                video.DisplayInfo();
            }
        }
    }
}