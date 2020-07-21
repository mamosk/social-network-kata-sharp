using System;

namespace SocialNetwork.Kata.Model
{

    public class Post
    {

        #region properties
        public string Text { get; private set; }
        public DateTime Instant { get; private set; } // second

        #endregion properties

        #region constructors

        public Post(string text)
        {
            Text = text;
            Instant = DateTime.UtcNow;
        }

        #endregion constructors

    }
}