using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class Archetype : IDescribable
    {
        public enum ArchetypeId
        {
            Warrior,
            Officer,
            Operative,
            Soldier,
            Blade_Dancer,
            Assassin,
            Vanguard,
            Bounty_Hunter,
            Master_Tactician,
            Grand_Strategist,
            Arch_Militant,
            Executioner,
            Exemplar
        }

        public enum ArchetypeType
        {
            Base,
            Intermediate,
            Final
        }

        public int NumberOfLevels
        {
            get
            {
                switch(Type)
                {
                    case ArchetypeType.Base:
                        return 15;
                    case ArchetypeType.Intermediate:
                        return 0;
                    case ArchetypeType.Final:
                        return 0;
                    default:
                        return 0;
                }
            }
        }
        
        public ArchetypeId Id { get; }
        public ArchetypeType Type { get; }
        public List<ArchetypeLevel> Levels { get; }
        public List<Archetype>? PossibleNextArchetypes { get; }

        public Description Description { get; }

        public Archetype(ArchetypeId id, ArchetypeType type, List<ArchetypeLevel> levels, String description = "", List<Archetype>? possibleNextArchetypes = null)
        {
            Id = id;
            Type = type;
            Levels = levels;
            Description = new Description(Id.ToString().Replace('_', ' '), description);
            PossibleNextArchetypes = possibleNextArchetypes;
        }
    }
}

