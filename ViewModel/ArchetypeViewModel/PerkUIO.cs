using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;

namespace W40KRogueTrader_BuildPlanner.ViewModel.ArchetypeViewModel
{
    public class PerkUIO : IDescribable
    {
        private object? id;

        private Description? description;
        public Description Description => description == null ? new Description(Text, "") : description;
        public Perk.PerkType Type { get; }
        public String Text { get; }
        public bool IsEditable { get; }
        public bool isEmpty
        {
            get
            {
                switch (Type)
                {
                    case Perk.PerkType.Other:
                        return false;
                    case Perk.PerkType.Ability:
                        return AbilityId == null;
                    case Perk.PerkType.Talent:
                    case Perk.PerkType.CommonTalent:
                        return TalentId == null;
                    case Perk.PerkType.SkillUpgrade:
                        return SkillId == null;
                    case Perk.PerkType.CharacteristicUpgrade:
                        return CharacteristicId == null;
                    case Perk.PerkType.UltimateUpgrade:
                        return UltimateUpgradeId == null;
                    default:
                        return false;
                }
            }
        }

        public Talent.TalentId? TalentId => id as Talent.TalentId?;
        public Ability.AbilityId? AbilityId => id as Ability.AbilityId?;
        public Skill.SkillId? SkillId => id as Skill.SkillId?;
        public Characteristic.CharacteristicId? CharacteristicId => id as Characteristic.CharacteristicId?;
        public UltimateUpgrade.UpgradeId? UltimateUpgradeId => id as UltimateUpgrade.UpgradeId?;

        public PerkUIO(object? id, Description? description, String text, Perk.PerkType type, bool isEditable)
        {
            this.id = id;
            Type = type;
            IsEditable = isEditable;
            Text = text;
        }

    }
}
