using System;
using System.Collections.Generic;
using System.Text;

namespace Orienteering.Domain.Entities
{
    public class Game
    {
        public Game()
        {
            Participants = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTme { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public virtual Track Track { get; set; }
        public virtual ICollection<User> Participants { get; private set; }
    }
}