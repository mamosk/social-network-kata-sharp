using System;

namespace SocialNetwork.Kata.Model
{

    public class Post
    {

        #region properties
        public string Text { get; private set; }
        public uint Instant { get; private set; } // second

        #endregion properties

        #region constructors

        public Post(string text)
        {
            Text = text;
            Instant = (uint)Math.Round(DateTime.UtcNow.Ticks * 1.0 / TimeSpan.TicksPerSecond, 0);
        }

        #endregion constructors

    }
}