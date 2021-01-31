using System;
using System.Collections.Generic;
using System.Text;

namespace Orienteering.Domain.Entities
{
    public class TrackPoint
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description {get; set; }
        public GeoCoordinates Coordinates { get; set; } 
    }
}