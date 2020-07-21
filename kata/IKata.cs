using System.Collections.Generic;

namespace social_network_kata_sharp.kata
{

    interface IKata
    {

        public void Post(string user);

        public List<string> Read(string user);

        public void Follow(string user, string another);

        public List<string> Wall(string user);

    }

}