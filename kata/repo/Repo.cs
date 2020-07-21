using System;
using SocialNetwork.Kata.Model;
using System.Collections.Generic;

namespace SocialNetwork.Kata.Repo
{

    class Repo : IRepo
    {

        private IDictionary<string, User> Users { get; set; }

        public Repo() => Users = new Dictionary<string, User>();

        public User GetOrAdd(string name)
        {
            User user;
            if (!Users.TryGetValue(name, out user))
            {
                user = new User(name);
                Users.Add(name, user);
            }
            return user;
        }

        public User GetOrNull(string name)
        {
            User user;
            if (Users.TryGetValue(name, out user))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

    }

}