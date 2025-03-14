﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Factory;
using W40KRogueTrader_BuildPlanner.Model;
using W40KRogueTrader_BuildPlanner.Repository;
using W40KRogueTrader_BuildPlanner.Utils.Extensions;
using static W40KRogueTrader_BuildPlanner.Model.Ability;
using static W40KRogueTrader_BuildPlanner.Model.Characteristic;
using static W40KRogueTrader_BuildPlanner.Model.Skill;
using static W40KRogueTrader_BuildPlanner.Model.Talent;

namespace W40KRogueTrader_BuildPlanner.ViewModel.ArchetypeViewModel
{
    public record ArchetypeLevelUIO(PerkUIO Perk1, PerkUIO? Perk2, PerkUIO? Perk3);
    public record SelectedPerkUIO(int Row, int Col, PerkUIO Perk);

    public class ArchetypeViewModel : ViewModelBase
    {
        private AbilityRepository abilityRepository;
        private TalentRepository talentRepository;
        private SkillRepository skillRepository;
        private CharacteristicsRepository characteristicsRepository;
        private UltimateUpgradeRepository ultimateUpgradeRepository;
        private DescriptionRepository descriptionRepository;

        public Archetype Archetype { get; }

        private SelectedPerkUIO? selectedPerk;
        public SelectedPerkUIO? SelectedPerk
        {
            get => selectedPerk;
            set
            {
                if (selectedPerk != value)
                {
                    selectedPerk = value;
                    populateSelectedPerkOptions();
                }
            }
        }

        public ObservableCollection<IDescribable> SelectedPerkOptions { get; private set; } = new ObservableCollection<IDescribable>();

        private void populateSelectedPerkOptions()
        {
            SelectedPerkOptions.Clear();

            if (selectedPerk == null)
            {
                return;
            }

            if (!selectedPerk.Perk.IsEditable)
            {
                return;
            }

            switch (selectedPerk.Perk.Type)
            {
                case Perk.PerkType.Ability:
                    SelectedPerkOptions.CopyFrom(abilityRepository.Abilities.FindAll(ability => ability.ArchetypeId == Archetype.Id).ConvertAll<IDescribable>(x => (IDescribable)x));
                    break;
                case Perk.PerkType.Talent:
                    SelectedPerkOptions.CopyFrom(talentRepository.ArchetypeTalents[Archetype.Id].ConvertAll<IDescribable>(x => (IDescribable)x));
                    break;
                case Perk.PerkType.CommonTalent:
                    SelectedPerkOptions.CopyFrom(talentRepository.CommonTalents.ConvertAll<IDescribable>(x => (IDescribable)x));
                    break;
                case Perk.PerkType.SkillUpgrade:
                    SelectedPerkOptions.CopyFrom(skillRepository.Skills.ConvertAll<IDescribable>(x => (IDescribable)x));
                    break;
                case Perk.PerkType.CharacteristicUpgrade:
                    SelectedPerkOptions.CopyFrom(characteristicsRepository.Characteristics.ConvertAll<IDescribable>(x => (IDescribable)x));
                    break;
                case Perk.PerkType.UltimateUpgrade:
                    //TO DO
                    break;
                default:
                    break;
            }
        }

        public void SelectPerkOption(IDescribable perkOption)
        {
            if (SelectedPerk == null)
            {
                return;
            }

            if (!SelectedPerk.Perk.IsEditable)
            {
                return;
            }

            PerkUIO newPerk;

            switch (perkOption)
            {
                case Ability ability:
                    newPerk = new PerkUIO(ability.Id, ability.Description, ability.Id.ToString(), Perk.PerkType.Ability, true);
                    break;
                case Skill skill:
                    newPerk = new PerkUIO(skill.Id, skill.Description, skill.Id.ToString(), Perk.PerkType.SkillUpgrade, true);
                    break;
                case Characteristic characteristic:
                    newPerk = new PerkUIO(characteristic.Id, characteristic.Description, characteristic.Id.ToString(), Perk.PerkType.CharacteristicUpgrade, true);
                    break;
                case Talent talent:
                    newPerk = new PerkUIO(talent.Id, talent.Description, talent.Id.ToString(), SelectedPerk.Perk.Type, true);
                    break;
                case UltimateUpgrade ultimateUpgrade:
                    newPerk = new PerkUIO(ultimateUpgrade.Id, ultimateUpgrade.Description, ultimateUpgrade.Id.ToString(), Perk.PerkType.UltimateUpgrade, true);
                    break;
                default:
                    newPerk = SelectedPerk.Perk;
                    break;
            }

            ArchetypeLevelUIO level = Levels[SelectedPerk.Row];
            ArchetypeLevelUIO newLevel;

            switch (SelectedPerk.Col)
            {
                case 0:
                    newLevel = new ArchetypeLevelUIO(newPerk, level.Perk2, level.Perk3);
                    break;
                case 1:
                    newLevel = new ArchetypeLevelUIO(level.Perk1, newPerk, level.Perk3);
                    break;
                case 2:
                    newLevel = new ArchetypeLevelUIO(level.Perk1, level.Perk2, newPerk);
                    break;
                default:
                    newLevel = level;
                    break;
            }

            Levels.RemoveAt(SelectedPerk.Row);
            Levels.Insert(SelectedPerk.Row, newLevel);
        }

        public ObservableCollection<ArchetypeLevelUIO> Levels { get; } = new ObservableCollection<ArchetypeLevelUIO>();

        public ArchetypeViewModel(Archetype archetype) : this(AbilityRepository.Instance, TalentRepository.Instance, SkillRepository.Instance, CharacteristicsRepository.Instance, UltimateUpgradeRepository.Instance, DescriptionRepository.Instance, archetype) { }

        public ArchetypeViewModel(AbilityRepository abilityRepository, TalentRepository talentRepository, SkillRepository skillRepository, CharacteristicsRepository characteristicsRepository, UltimateUpgradeRepository ultimateUpgradeRepository, DescriptionRepository descriptionRepository, Archetype archetype)
        {
            this.abilityRepository = abilityRepository;
            this.talentRepository = talentRepository;
            this.skillRepository = skillRepository;
            this.characteristicsRepository = characteristicsRepository;
            this.ultimateUpgradeRepository = ultimateUpgradeRepository;
            this.descriptionRepository = descriptionRepository;
            Archetype = archetype;

            UpdateLevels();
        }

        private void UpdateLevels()
        {
            ArchetypeLevelUIOFactory factory = new ArchetypeLevelUIOFactory();

            Levels.CopyFrom(Archetype.Levels.Select(level => factory.fromArchetypeLevel(level, Archetype)).ToList());
        }

        /***
         * Description
         ***/
        #region Description
        public void StoreDescribable(Description description)
        {
            descriptionRepository.Description = description;
        }
        #endregion
    }
}
