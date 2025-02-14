using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class UltimateUpgrade : IDescribable
    {
        public enum UpgradeId
        {
            I,
            II,
            III,
            IV
        }

        public UpgradeId Id { get; }
        public Description Description { get; }
        public Archetype.ArchetypeId ArchetypeId { get; }

        public UltimateUpgrade(UpgradeId id, Archetype.ArchetypeId archetypeId, String name = "", String description = "")
        {
            Id = id;
            ArchetypeId = archetypeId;
            Description = new Description(Id.ToString() + " " + name, description);
        }
    }
}
