using SocialNetwork.Kata.Model;
using SocialNetwork.Kata.Repo;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Kata
{

    class Kata : IKata
    {

        private IRepo Repo { get; set; }

        public Kata() => Repo = new Repo.Repo();

        public void Post(string name, string text) => Repo.GetOrAdd(name).Timeline.Add(new Post(text));

        public IList<(string, string, long)> Read(string name) => Repo.GetOrNull(name)?.Timeline.Select(post => (name, post.Text, post.Instant.Ticks)).ToList();

        public void Follow(string name, string another) => Repo.GetOrAdd(name).Followees.Add(Repo.GetOrAdd(another));

        public IList<(string, string, long)> Wall(string name) => Repo.GetOrAdd(name).Followees.SelectMany(user => Read(user.Name)).ToList();

    }

}