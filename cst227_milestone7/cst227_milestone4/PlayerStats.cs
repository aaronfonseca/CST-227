using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cst227_milestone6
{
    // Create PlayerStats Class and make in Comparable
   public class PlayerStats : IComparable<PlayerStats>
    {
        // initials, level and time
        public string Initials { get; set; }
        public string level { get; set; }
        public TimeSpan time { get; set; }

        // Constructor for new playerstats
        public PlayerStats(string Initials, string level, TimeSpan time)
        {
            this.Initials = Initials;
            this.level = level;
            this.time = time;
        }

        // Compare the time to another PlayerStats object
        public int CompareTo(PlayerStats other)
        {
            return time.CompareTo(other.time);
        }
    }
}