using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class Perk
    {
        public enum PerkType
        {
            Talent,
            CommonTalent,
            SkillUpgrade,
            CharacteristicUpgrade,
            UltimateUpgrade,
            Ability,
            Other
        }

        public PerkType Type { get; }
        public bool IsEditable { get; }

        public Talent.TalentId? TalentId { get; set; }
        public Skill.SkillId? SkillId { get; set;  }
        public Characteristic.CharacteristicId? CharacteristicId { get; set; }
        public UltimateUpgrade.UpgradeId? UltimateUpgradeId { get; set; }
        public Ability.AbilityId? AbilityId { get; set; }

        public Perk(PerkType type)
        {
            Type = type;
            IsEditable = true;
        }

        public Perk(Talent.TalentId talentId)
        {
            Type = PerkType.Talent;
            TalentId = talentId;
            IsEditable = false;
        }

        public Perk(Skill.SkillId skillId)
        {
            Type = PerkType.SkillUpgrade;
            SkillId = skillId;
            IsEditable = false;
        }

        public Perk(Characteristic.CharacteristicId characteristicId)
        {
            Type = PerkType.CharacteristicUpgrade;
            CharacteristicId = characteristicId;
            IsEditable = false;
        }

        public Perk(UltimateUpgrade.UpgradeId ultimateUpgradeId)
        {
            Type = PerkType.UltimateUpgrade;
            UltimateUpgradeId = ultimateUpgradeId;
            IsEditable = false;
        }

        public Perk(Ability.AbilityId abilityId)
        {
            Type = PerkType.Ability;
            AbilityId = abilityId;
            IsEditable = false;
        }

    }
}
