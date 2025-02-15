using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;
using W40KRogueTrader_BuildPlanner.Repository;
using W40KRogueTrader_BuildPlanner.ViewModel.ArchetypeViewModel;
using static W40KRogueTrader_BuildPlanner.Model.Ability;
using static W40KRogueTrader_BuildPlanner.Model.Characteristic;
using static W40KRogueTrader_BuildPlanner.Model.Skill;
using static W40KRogueTrader_BuildPlanner.Model.Talent;

namespace W40KRogueTrader_BuildPlanner.Factory
{
    public class PerkUIOFactory
    {
        private TalentRepository talentRepository;
        private AbilityRepository abilityRepository;
        private SkillRepository skillRepository;
        private CharacteristicsRepository characteristicsRepository;
        private UltimateUpgradeRepository ultimateUpgradeRepository;

        public PerkUIOFactory() : this(TalentRepository.Instance, AbilityRepository.Instance, SkillRepository.Instance, CharacteristicsRepository.Instance, UltimateUpgradeRepository.Instance)
        {
        }

        public PerkUIOFactory(TalentRepository talentRepository, AbilityRepository abilityRepository, SkillRepository skillRepository, CharacteristicsRepository characteristicsRepository, UltimateUpgradeRepository ultimateUpgradeRepository) 
        {
            this.talentRepository = talentRepository;
            this.abilityRepository = abilityRepository;
            this.skillRepository = skillRepository;
            this.characteristicsRepository = characteristicsRepository;
            this.ultimateUpgradeRepository = ultimateUpgradeRepository;
        }

        public PerkUIO fromPerk(Perk perk, Archetype archetype)
        {
            object? id;
            String? text;
            Description? description = null;

            switch (perk.Type)
            {
                case Perk.PerkType.Other:
                    id = null;
                    text = "Fixed Perk";
                    break;
                case Perk.PerkType.Ability:
                    id = perk.AbilityId;
                    description = abilityRepository.Abilities.Find(ability => ability.Id == perk.AbilityId)?.Description;
                    break;
                case Perk.PerkType.Talent:
                case Perk.PerkType.CommonTalent:
                    id = perk.TalentId;
                    description = talentRepository.AllTalents.Find(talent => talent.Id == perk.TalentId)?.Description;
                    break;
                case Perk.PerkType.SkillUpgrade:
                    id = perk.SkillId;
                    description = skillRepository.Skills.Find(skill => skill.Id == perk.SkillId)?.Description;
                    break;
                case Perk.PerkType.CharacteristicUpgrade:
                    id = perk.CharacteristicId;
                    description = characteristicsRepository.Characteristics.Find(characteristic => characteristic.Id == perk.CharacteristicId)?.Description;
                    break;
                case Perk.PerkType.UltimateUpgrade:
                    id = perk.UltimateUpgradeId;
                    description = ultimateUpgradeRepository.UltimateUpgrades[archetype.Id]?.Find(upgrade => upgrade.Id == perk.UltimateUpgradeId)?.Description;
                    break;
                default:
                    id = null;
                    break;
            }

            if (id != null)
            {
                text = id?.ToString();
                
            }
            else
            {
                text = "Select " + perk.Type.ToString() + "...";
            }

            return new PerkUIO(id, description, text == null ? "" : text, perk.Type, perk.IsEditable);
        }
    }
}
