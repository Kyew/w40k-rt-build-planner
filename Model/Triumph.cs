using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class Triumph : IDescribable
    {
        public enum TriumphId
        {
            Apex_Of_Brilliance,
            Illustrious_Glory,
            Feat_of_Greatness
        }

        public TriumphId Id { get; }
        public Description Description { get; }
        public SkillModifier SkillModifier { get; }

        public Triumph(TriumphId id, String description, SkillModifier skillModifier)
        {
            Id = id;
            Description = new Description(Enum.GetName(Id).Replace('_', ' '), description, new List<SkillModifier> { skillModifier });
            SkillModifier = skillModifier;
        }
    }
}
