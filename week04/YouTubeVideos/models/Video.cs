using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace YouTubeVideos.models
{
    public class Video
    {
        private string _title;
        private string _author;
        private int _lengthSeconds;
        private List<Comment> _comments = new List<Comment>();

        public Video(string title, string author, int lengthSeconds)
        {
            _title = title;
            _author = author;
            _lengthSeconds = lengthSeconds;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        public void Display()
        {
            Console.WriteLine("======================================");
            Console.WriteLine($"Title: {_title}");
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Length: {_lengthSeconds} seconds");
            Console.WriteLine($"Comments: {GetNumberOfComments()}");
            Console.WriteLine("--------------------------------------");

            foreach (Comment comment in _comments)
            {
                Console.WriteLine($"{comment.GetCommenterName()}: {comment.GetText()}");
            }
            Console.WriteLine("======================================\n");
        }
    }
}