using System;
using SocialNetwork.Kata.Model;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Kata.Repo
{

    interface IRepo
    {

        public User GetOrAdd(string name);

        public User GetOrNull(string name);

    }

}