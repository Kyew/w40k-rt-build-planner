using System;
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

    public class ArchetypeViewModel : ViewModelBase
    {
        private AbilityRepository abilityRepository;
        private TalentRepository talentRepository;
        private SkillRepository skillRepository;
        private CharacteristicsRepository characteristicsRepository;
        private UltimateUpgradeRepository ultimateUpgradeRepository;

        public Archetype Archetype { get; }

        private PerkUIO? selectedPerk;
        public PerkUIO? SelectedPerk
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

            if (!selectedPerk.IsEditable)
            {
                return;
            }

            switch (selectedPerk.Type)
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

        public ObservableCollection<ArchetypeLevelUIO> Levels { get; } = new ObservableCollection<ArchetypeLevelUIO>();

        public ArchetypeViewModel(Archetype archetype) : this(AbilityRepository.Instance, TalentRepository.Instance, SkillRepository.Instance, CharacteristicsRepository.Instance, UltimateUpgradeRepository.Instance, archetype) { }

        public ArchetypeViewModel(AbilityRepository abilityRepository, TalentRepository talentRepository, SkillRepository skillRepository, CharacteristicsRepository characteristicsRepository, UltimateUpgradeRepository ultimateUpgradeRepository, Archetype archetype)
        {
            this.abilityRepository = abilityRepository;
            this.talentRepository = talentRepository;
            this.skillRepository = skillRepository;
            this.characteristicsRepository = characteristicsRepository;
            this.ultimateUpgradeRepository = ultimateUpgradeRepository;
            Archetype = archetype;

            updateLevels();
        }

        private void updateLevels()
        {
            ArchetypeLevelUIOFactory factory = new ArchetypeLevelUIOFactory();

            Levels.CopyFrom(Archetype.Levels.Select(level => factory.fromArchetypeLevel(level)).ToList());
        }
    }
}
