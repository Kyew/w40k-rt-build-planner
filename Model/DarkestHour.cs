using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class DarkestHour : ADescribable
    {
        public enum DarkestHourId
        {
            Grim_Portents,
            Brand_of_Shame,
            Shadow_of_Torments
        }

        public DarkestHourId Id { get; }
        public SkillModifier SkillModifier { get; }

        public DarkestHour(DarkestHourId id, String description, SkillModifier skillModifier) : base(Enum.GetName(id).Replace('_', ' '), description)
        {
            Id = id;
            SkillModifier = skillModifier;
        }
    }
}
