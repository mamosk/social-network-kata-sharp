using System.Collections.Generic;

namespace SocialNetwork.Kata
{

    interface IKata
    {

        public void Post(string user, string post);

        public IList<(string, string, uint)> Read(string user);

        public void Follow(string user, string another);

        public IList<(string, string, uint)> Wall(string user);

    }

}