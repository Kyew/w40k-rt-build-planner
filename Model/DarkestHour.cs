using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class DarkestHour : IDescribable
    {
        public enum DarkestHourId
        {
            Grim_Portents,
            Brand_of_Shame,
            Shadow_of_Torments
        }

        public DarkestHourId Id { get; }
        public Description Description { get; }
        public SkillModifier SkillModifier { get; }

        public DarkestHour(DarkestHourId id, String description, SkillModifier skillModifier)
        {
            Id = id;
            Description = new Description(Enum.GetName(Id).Replace('_', ' '), description);
            SkillModifier = skillModifier;
        }
    }
}
