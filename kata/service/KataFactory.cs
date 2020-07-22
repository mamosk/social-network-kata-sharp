using SocialNetwork.Kata.Simple;
using System;

namespace SocialNetwork.Kata
{
    class KataFactory
    {

        private static readonly Lazy<IKata> kata = new Lazy<IKata>(NewKata);

        public static IKata Kata => kata.Value;

        private static IKata NewKata()
        {
            switch (Environment.GetEnvironmentVariable("KATA"))
            {
                default:
                    return new SimpleKata();
            }
        }

    }
}
