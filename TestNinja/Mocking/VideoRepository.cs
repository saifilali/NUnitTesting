﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }

    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetUnprocessedVideos()
        {
            using (VideoContext context = new VideoContext())
            {
                List<Video> videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();

                return videos;
            }                
        }
    }
}
