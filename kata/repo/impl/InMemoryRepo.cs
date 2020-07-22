using SocialNetwork.Kata.Model;
using System.Collections.Generic;

namespace SocialNetwork.Kata.Repo.InMemory
{

    class InMemoryRepo : IRepo
    {

        private IDictionary<string, User> Users { get; set; }

        public InMemoryRepo() => Users = new Dictionary<string, User>();

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
            return (Users.TryGetValue(name, out user)) ? user : null;
        }

    }

}