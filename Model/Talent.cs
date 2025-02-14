using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class Talent : IDescribable
    {
        public enum TalentId
        {
            //Common
            Common_BaseSkillAthletics,
            Common_SwiftMovements,
            //Death world
            DW_BrutalHunter,
            //Astra Militarum Commander
            AMC_ShouldToShoulder,
            AMC_FieldOfFire,
            //Commissar
            Com_Motivation,
            Com_DutyAndHonour,
            //Warrior
            War_RammingSpeed,
            War_Impetus,
            War_RigorousTraining
        }

        public TalentId Id { get; }
        public HomeWorld.HomeWorldId? HomeWorldId { get; }
        public Origin.OriginId? OriginId { get; }
        public Archetype.ArchetypeId? ArchetypeId { get; }

        public bool IsCommonTalent => ArchetypeId == null;

        public Description Description { get; }

        public Talent(TalentId id, String name = "", String description = "", List<SkillModifier>? skillModifiers = null, List<CharacteristicModifier>? characteristicModifiers = null, HomeWorld.HomeWorldId? homeWorldId = null, Origin.OriginId? originId = null, Archetype.ArchetypeId? archetypeId = null)
        {
            Id = id;
            HomeWorldId = homeWorldId;
            OriginId = originId;
            ArchetypeId = archetypeId;
            Description = new Description(name, description, skillModifiers, characteristicModifiers);
        }
    }
}
