using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Factory;
using W40KRogueTrader_BuildPlanner.Model;
using W40KRogueTrader_BuildPlanner.Repository;

namespace W40KRogueTrader_BuildPlanner.ViewModel
{
    public class SkillUIO : ADescribable
    {
        public Skill.SkillId Id { get; }
        public int BaseValue { get; }
        public int Modifiers { get; }
        public int TotalValue { get; }

        public SkillUIO(Skill.SkillId id, String name, String description, int baseValue, int modifiers) : base(name, description)
        {
            Id = id;
            BaseValue = baseValue;
            Modifiers = modifiers;
            TotalValue = baseValue + modifiers;
        }
    }


    public class RogueTraderViewModel : ViewModelBase
    {
        private readonly ArchetypeRepository archetypeRepository;
        private readonly CharacteristicsRepository characteristicsRepository;
        private readonly HomeWorldRepository homeWorldRepository;
        private readonly OriginRepository originRepository;
        private readonly SkillRepository skillRepository;
        private DescriptionRepository descriptionRepository;


        private String rtName;
        public String RTName
        {
            set
            {
                if (rtName != value)
                {
                    rtName = value;
                    OnPropertyChanged("RTName");
                }
            }
            get => rtName;
        }

        public List<HomeWorld> HomeWorlds => homeWorldRepository.HomeWorlds;

        public HomeWorld? RTHomeWorld { get; set; }
        public HomeWorldArg? RTHomeWorldArg { get; set; }

        public List<Origin> Origins => originRepository.Origins;

        public Origin? RTOrigin { get; set; }
        public OriginArg? RTOriginArg { get; set; } 

        public Triumph? RTTriumph { get; set; }
        public DarkestHour? RTDarkestHour { get; set; }

        public List<Archetype> Lvl1Archetypes => archetypeRepository.Lvl1Archetypes;
        public List<Archetype> Lvl2Archetypes => archetypeRepository.Lvl2Archetypes;
        public List<Archetype> Lvl3Archetypes => archetypeRepository.Lvl3Archetypes;

        public Archetype? RTLvl1Archetype { get; set; }
        public Archetype? RTLvl2Archetype { get; set; }
        public Archetype? RTLvl3Archetype { get; set; }

        public List<Characteristic> Characteristics => characteristicsRepository.Characteristics;
        public List<SkillUIO> Skills
        {
            get
            {
                List<Skill> skills = skillRepository.Skills;
                SkillUIOFactory factory = new SkillUIOFactory(skillRepository, characteristicsRepository);

                try
                {
                    return skills.Select(skill => factory.fromSkill(skill.Id)).ToList();
                }
                catch (Exception)
                {
                    return new List<SkillUIO>();
                }
            }
        }

        public void storeDescribable(ADescribable describable)
        {
            descriptionRepository.Describable = describable;
        }

        public RogueTraderViewModel() : this(ArchetypeRepository.Instance,
                                             CharacteristicsRepository.Instance,
                                             HomeWorldRepository.Instance,
                                             OriginRepository.Instance,
                                             SkillRepository.Instance,
                                             DescriptionRepository.Instance) { }

        public RogueTraderViewModel(ArchetypeRepository archetypeRepository,
                                    CharacteristicsRepository characteristicsRepository,
                                    HomeWorldRepository homeWorldRepository,
                                    OriginRepository originRepository,
                                    SkillRepository skillRepository,
                                    DescriptionRepository descriptionRepository)
        {
            rtName = "Jean Trader";
            this.archetypeRepository = archetypeRepository;
            this.characteristicsRepository = characteristicsRepository;
            this.homeWorldRepository = homeWorldRepository;
            this.originRepository = originRepository;
            this.skillRepository = skillRepository;
            this.descriptionRepository = descriptionRepository;
        }
    }
}
