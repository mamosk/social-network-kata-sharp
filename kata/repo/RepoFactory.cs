using SocialNetwork.Kata.Repo.InMemory;
using System;

namespace SocialNetwork.Kata.Repo
{
    class RepoFactory
    {

        private static readonly Lazy<IRepo> repo = new Lazy<IRepo>(NewRepo);

        public static IRepo Repo => repo.Value;

        private static IRepo NewRepo()
        {
            switch (Environment.GetEnvironmentVariable("KATA_REPO"))
            {
                default:
                    return new InMemoryRepo();
            }
        }

    }
}
