using System.Collections.Generic;

namespace SocialNetwork.Kata.Model
{
    public class User
    {

        #region properties

        public string Name { get; private set; }

        public IList<Post> Timeline { get; private set; }

        public IList<User> Followees { get; private set; }

        #endregion properties

        #region constructors

        public User(string name)
        {
            Name = name;
            Timeline = new List<Post>();
            Followees = new List<User>() { this }; // user always follows zirself
        }

        #endregion constructors

    }
}