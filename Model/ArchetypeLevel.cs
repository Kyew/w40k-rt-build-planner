using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class ArchetypeLevel
    {
        public int Id { get; }
        public List<Perk> Perks { get; }

        public ArchetypeLevel(int id, List<Perk> perks)
        {
            Id = id;
            Perks = perks;
        }
    }
}
