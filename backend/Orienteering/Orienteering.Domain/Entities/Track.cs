using System;
using System.Collections.Generic;
using System.Text;

namespace Orienteering.Domain.Entities
{
    public class Track
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public virtual ICollection<Game> GamesWhereUsed { get; set; }
        public virtual ICollection<TrackPoint> TrackPoints { get; set; }
    }
}