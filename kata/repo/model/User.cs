using System.Collections.Generic;

namespace SocialNetwork.Kata.Model
{
    class User
    {

        public string Name { get; private set; }

        public IList<Post> Timeline { get; private set; }

        public IList<User> Followees { get; private set; }

        public User(string name)
        {
            Name = name;
            Timeline = new List<Post>();
            Followees = new List<User>() { this }; // user always follows zirself
        }

    }
}