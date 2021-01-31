using System;
using System.Collections.Generic;
using System.Text;

namespace Orienteering.Domain.Entities
{
    public class User
    {
        public User()
        {
            ParticipatingGames = new HashSet<Game>();
            CreatedGames = new HashSet<Game>();
            CreatedTracks = new HashSet<Track>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Game> ParticipatingGames { get; private set; }
        public virtual ICollection<Game> CreatedGames { get; private set; }
        public virtual ICollection<Track> CreatedTracks { get; private set; }
    }
}