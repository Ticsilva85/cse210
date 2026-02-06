using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouTubeVideos.models
{
    public class VideoLibrary
    {
        private List<Video> _videos = new List<Video>();

        public void AddVideo(Video video)
        {
            _videos.Add(video);
        }

        public List<Video> GetVideos()
        {
            return _videos;
        }
        public void DisplayAll()
        {
        foreach (Video video in _videos)
            {
                video.Display();
            }
        }
    }
}