using System;

namespace SocialNetwork.Kata.Model
{

    class Post
    {
        public string Text { get; private set; }
        public uint Instant { get; private set; } // precision: 1 second

        public Post(string text)
        {
            Text = text;
            Instant = (uint)Math.Round(DateTime.UtcNow.Ticks * 1.0 / TimeSpan.TicksPerSecond, 0);
        }

    }
}