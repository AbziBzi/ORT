using System;
using System.Collections.Generic;
using System.Text;

namespace Orienteering.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid CreatorId { get; set; }
        public Guid TrackId { get; set; }
        public virtual User Creator { get; set; }
        public virtual Track Track { get; set; }
        public virtual ICollection<User> Participants { get; set; }
    }
}