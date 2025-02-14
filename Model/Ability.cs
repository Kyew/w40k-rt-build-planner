using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public sealed class Ability : IDescribable
    {
        public enum AbilityId
        {
            Charge,
            Endure,
            Reckless_Strike,
            Sworn_Ennemy,
            Break_Through,
            Forceful_Strike,
            Taunting_Scream
        }

        public AbilityId Id { get; }
        public Description Description { get; }
        public Archetype.ArchetypeId ArchetypeId { get; }

        public Ability(AbilityId id, String description, Archetype.ArchetypeId archetypeId)
        {
            Id = id;
            Description = new Description(Id.ToString().Replace('_', ' '), description);
            ArchetypeId = archetypeId;
        }
    }
}
