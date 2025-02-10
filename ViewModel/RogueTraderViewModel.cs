using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Factory;
using W40KRogueTrader_BuildPlanner.Model;
using W40KRogueTrader_BuildPlanner.Repository;
using W40KRogueTrader_BuildPlanner.Utils.Extensions;


namespace W40KRogueTrader_BuildPlanner.ViewModel
{
    public class SkillUIO : IDescribable
    {
        public Skill.SkillId Id { get; }
        public Description Description { get; }
        public int BaseValue { get; }
        public int Modifiers { get; }
        public int TotalValue { get; }

        public SkillUIO(Skill.SkillId id, Description description, int baseValue, int modifiers)
        {
            Id = id;
            Description = description;
            BaseValue = baseValue;
            Modifiers = modifiers;
            TotalValue = baseValue + modifiers;
        }
    }


    public class RogueTraderViewModel : ViewModelBase
    {
        /***
         * Repositories
         ***/
        #region Repositories
        private readonly ArchetypeRepository archetypeRepository;
        private readonly CharacteristicsRepository characteristicsRepository;
        private readonly HomeWorldRepository homeWorldRepository;
        private readonly OriginRepository originRepository;
        private readonly SkillRepository skillRepository;
        private DescriptionRepository descriptionRepository;
        #endregion

        /***
         * Name
         ***/
        #region Name
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
        #endregion

        /***
         * HomeWorld
         ***/
        #region HomeWorld
        public List<HomeWorld> HomeWorlds => homeWorldRepository.HomeWorlds;

        private HomeWorld? rtHomeWorld;
        public HomeWorld? RTHomeWorld
        {
            get => rtHomeWorld;
            set
            {
                if (rtHomeWorld != value)
                {
                    rtHomeWorld = value;
                    updateHomeWorldArgs();
                }
            }
        }
        private void updateHomeWorldArgs()
        {
            if (RTHomeWorld == null)
            {
                HomeWorldArgs.Clear();
                return;
            }

            if (RTHomeWorld.PossibleArgs == null)
            {
                HomeWorldArgs.Clear();
                return;
            }

            HomeWorldArgs.CopyFrom(RTHomeWorld.PossibleArgs);
        }

        public ObservableCollection<HomeWorldArg> HomeWorldArgs = new ObservableCollection<HomeWorldArg>();
        public HomeWorldArg? RTHomeWorldArg { get; set; }
        #endregion

        /***
         * Origin
         ***/
        #region Origin
        public List<Origin> Origins => originRepository.Origins;

        private Origin? rtOrigin;
        public Origin? RTOrigin
        {
            get => rtOrigin;
            set
            {
                if (rtOrigin != value)
                {
                    rtOrigin = value;
                    updateTriumphs();
                    updateDarkestHours();
                    updateOriginArgs();
                }
            }
        }
        public ObservableCollection<OriginArg> OriginArgs { get; private set; } = new ObservableCollection<OriginArg>();
        public OriginArg? RTOriginArg { get; set; }

        private void updateOriginArgs()
        {
            if (RTOrigin == null)
            {
                OriginArgs.Clear();
                return;
            }

            if (RTOrigin.PossibleArgs == null)
            {
                OriginArgs.Clear();
                return;
            }

            OriginArgs.CopyFrom(RTOrigin.PossibleArgs);
        }
        #endregion

        /***
         * Triumph
         ***/
        #region Triumph
        public ObservableCollection<Triumph> Triumphs { get; private set; } = new ObservableCollection<Triumph>();
        private Triumph? rtTriumph;
        public Triumph? RTTriumph
        {
            get => rtTriumph;
            set
            {
                if (rtTriumph != value)
                {
                    rtTriumph = value;
                    updateSkills();
                }
            }
        }

        private void updateTriumphs()
        {
            if (RTOrigin == null)
            {
                Triumphs.Clear();
                return;
            }

            if (RTOrigin.PossibleTriumphs == null)
            {
                Triumphs.Clear();
                return;
            }

            Triumphs.CopyFrom(RTOrigin.PossibleTriumphs);
        }
        #endregion

        /***
         * DarkestHour
         ***/
        #region DarkestHour
        public ObservableCollection<DarkestHour> DarkestHours { get; private set; } = new ObservableCollection<DarkestHour>();
        private DarkestHour? rtDarkestHour;
        public DarkestHour? RTDarkestHour
        {
            get => rtDarkestHour;
            set
            {
                if (rtDarkestHour != value)
                {
                    rtDarkestHour = value;
                    updateSkills();
                }
            }
        }

        private void updateDarkestHours()
        {
            if (RTOrigin == null)
            {
                DarkestHours.Clear();
                return;
            }

            if (RTOrigin.PossibleDarkestHours == null)
            {
                DarkestHours.Clear();
                return;
            }

            DarkestHours.CopyFrom(RTOrigin.PossibleDarkestHours);
        }
        #endregion

        /***
         * Archetypes
         ***/
        #region Archetypes
        public List<Archetype> Lvl1Archetypes => archetypeRepository.Lvl1Archetypes;
        public ObservableCollection<Archetype> Lvl2Archetypes { get; private set; } = new ObservableCollection<Archetype>();
        public ObservableCollection<Archetype> Lvl3Archetypes { get; private set; } = new ObservableCollection<Archetype>();

        private Archetype? rtLvl1Archetype;
        public Archetype? RTLvl1Archetype
        {
            get => rtLvl1Archetype;
            set
            {
                if (rtLvl1Archetype != value)
                {
                    rtLvl1Archetype = value;
                    RTLvl2Archetype = null;
                    updateLvl2Archetypes();
                }
            }
        }

        private Archetype? rtLvl2Archetype;
        public Archetype? RTLvl2Archetype
        {
            get => rtLvl2Archetype;
            set
            {
                if (rtLvl2Archetype != value)
                {
                    rtLvl2Archetype = value;
                    RTLvl3Archetype = null;
                    updateLvl3Archetypes();
                }
            }
        }

        public Archetype? RTLvl3Archetype { get; set; } 

        private void updateLvl2Archetypes()
        {
            if (RTLvl1Archetype == null)
            {
                Lvl2Archetypes.Clear();
                return;
            }

            if (RTLvl1Archetype.PossibleNextArchetypes == null)
            {
                Lvl2Archetypes.Clear();
                return;
            }

            Lvl2Archetypes.CopyFrom(RTLvl1Archetype.PossibleNextArchetypes);
        }

        private void updateLvl3Archetypes()
        {
            if (RTLvl2Archetype == null)
            {
                Lvl3Archetypes.Clear();
                return;
            }

            if (RTLvl2Archetype.PossibleNextArchetypes == null)
            {
                Lvl3Archetypes.Clear();
                return;
            }

            Lvl3Archetypes.CopyFrom(RTLvl2Archetype.PossibleNextArchetypes);
        }
        #endregion

        /***
         * Characteristics
         ***/
        #region Characteristics
        public ObservableCollection<Characteristic> Characteristics { get; private set; } = new ObservableCollection<Characteristic>();

        private void updateCharacteristics()
        {
            Characteristics.CopyFrom(characteristicsRepository.Characteristics);
        }
        #endregion

        /***
         * Skills
         ***/
        #region Skills
        public ObservableCollection<SkillUIO> Skills { get; private set; } = new ObservableCollection<SkillUIO>();

        private void updateSkills()
        {
            List<Skill> skills = skillRepository.Skills;
            SkillUIOFactory factory = new SkillUIOFactory(skillRepository, characteristicsRepository);

            List<SkillModifier> skillModifiers = new List<SkillModifier>();
            if (RTTriumph != null)
            {
                skillModifiers.Add(RTTriumph.SkillModifier);
            }
            if (RTDarkestHour != null)
            {
                skillModifiers.Add(RTDarkestHour.SkillModifier);
            }

            Skills.CopyFrom(skills.Select(skill => factory.fromSkill(skill.Id, skillModifiers)).ToList());
        }
        #endregion

        /***
         * Description
         ***/
        #region Description
        public void storeDescribable(Description description)
        {
            descriptionRepository.Description = description;
        }
        #endregion

        /***
         * Constructors
         ***/
        #region Constructors
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

            updateSkills();
            updateCharacteristics();
            updateTriumphs();
            updateDarkestHours();
            updateOriginArgs();
            updateHomeWorldArgs();
            updateLvl2Archetypes();
            updateLvl3Archetypes();
        }
        #endregion
    }
}
