using SocialNetwork.Kata.Model;

namespace SocialNetwork.Kata.Repo
{

    interface IRepo
    {

        public User GetOrAdd(string name);

        public User GetOrNull(string name);

    }

}