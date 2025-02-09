using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class Archetype : ADescribable
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
        
        public ArchetypeId Id { get; }
        public List<Archetype>? PossibleNextArchetypes { get; }

        public Archetype(ArchetypeId id, String description = "", List<Archetype>? possibleNextArchetypes = null) : base(Enum.GetName(id).Replace('_', ' '), description)
        {
            Id = id;
            PossibleNextArchetypes = possibleNextArchetypes;
        }
    }
}
