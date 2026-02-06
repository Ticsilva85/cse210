using System;
using System.Collections.Generic;
using YouTubeVideos.models;

class Program
{
    static void Main(string[] args)
    {
       List<Video> videos = new List<Video>();

        // Video 1
        Video v1 = new Video("C# Basics in 10 Minutes", "CodeTeacher", 600);
        v1.AddComment(new Comment("Ana", "Very clear explanation!"));
        v1.AddComment(new Comment("Tiago", "This helped me a lot."));
        v1.AddComment(new Comment("Lucas", "Can you make a part 2?"));
        videos.Add(v1);

        // Video 2
        Video v2 = new Video("OOP: Classes and Objects", "DevWorld", 780);
        v2.AddComment(new Comment("Maria", "Now I finally understand OOP."));
        v2.AddComment(new Comment("João", "Great examples."));
        v2.AddComment(new Comment("Bea", "Loved the pacing."));
        videos.Add(v2);

        // Video 3
        Video v3 = new Video("Abstraction Explained", "LearnFast", 540);
        v3.AddComment(new Comment("Rafa", "Abstraction makes sense now."));
        v3.AddComment(new Comment("Carol", "Nice real-world comparison."));
        v3.AddComment(new Comment("Pedro", "Short and useful!"));
        videos.Add(v3);

        // (Optional) Video 4
        Video v4 = new Video("Encapsulation in Practice", "CS Concepts", 720);
        v4.AddComment(new Comment("Sofia", "Perfect for beginners."));
        v4.AddComment(new Comment("Henrique", "Good use of examples."));
        v4.AddComment(new Comment("Nina", "Thanks for this lesson."));
        videos.Add(v4);

        // Display all videos
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}