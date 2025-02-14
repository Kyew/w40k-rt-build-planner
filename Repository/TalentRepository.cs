using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;

namespace W40KRogueTrader_BuildPlanner.Repository
{
    public class TalentRepository
    {
        private static TalentRepository? instance = null;

        public static TalentRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TalentRepository();
                }
                return instance;
            }
        }

        public List<Talent> CommonTalents { get; private set; } = new List<Talent>();
        public Dictionary<Archetype.ArchetypeId, List<Talent>> ArchetypeTalents = new Dictionary<Archetype.ArchetypeId, List<Talent>>();
        public Dictionary<Origin.OriginId, List<Talent>> OriginTalents = new Dictionary<Origin.OriginId, List<Talent>>();
        public Dictionary<HomeWorld.HomeWorldId, List<Talent>> HomeWorldTalents = new Dictionary<HomeWorld.HomeWorldId, List<Talent>>();

        public TalentRepository()
        {
            initCommonTalents();
            initOriginTalents();
            initHomeWorldTalents();
            initArchetypeTalents();
        }

        /***
         * Common Talents
         ***/
        #region Common Talents
        private void initCommonTalents()
        {
            CommonTalents.Add(new Talent(Talent.TalentId.Common_SwiftMovements,"Swift Movements", "Grants +2 movement points."));
            CommonTalents.Add(new Talent(Talent.TalentId.Common_BaseSkillAthletics, "Base Skill: Athletics", "", new List<SkillModifier> { new SkillModifier(Skill.SkillId.Athletics, 7) }));
        }
        #endregion

        /***
         * Origin Talents
         ***/
        #region Origin Talents
        private void initOriginTalents()
        {
            OriginTalents.Add(Origin.OriginId.Astra_Militarum_Commander, new List<Talent>());
            OriginTalents[Origin.OriginId.Astra_Militarum_Commander].Add(new Talent(Talent.TalentId.AMC_FieldOfFire, "Field of Fire", "", null, null, null, Origin.OriginId.Astra_Militarum_Commander));
            OriginTalents[Origin.OriginId.Astra_Militarum_Commander].Add(new Talent(Talent.TalentId.AMC_ShouldToShoulder, "Shoulder to Shoulder", "", null, null, null, Origin.OriginId.Astra_Militarum_Commander));
            OriginTalents.Add(Origin.OriginId.Comissar, new List<Talent>());
            OriginTalents[Origin.OriginId.Comissar].Add(new Talent(Talent.TalentId.Com_Motivation, "Motivation", "", null, null, null, Origin.OriginId.Comissar));
            OriginTalents[Origin.OriginId.Comissar].Add(new Talent(Talent.TalentId.Com_DutyAndHonour, "Duty and Honour !", "", null, null, null, Origin.OriginId.Comissar));
        }
        #endregion

        /***
         * HomeWorld Talents
         ***/
        #region HomeWorld Talents
        private void initHomeWorldTalents()
        {
            HomeWorldTalents.Add(HomeWorld.HomeWorldId.Death_World, new List<Talent>());
            HomeWorldTalents[HomeWorld.HomeWorldId.Death_World].Add(new Talent(Talent.TalentId.DW_BrutalHunter, "Brutal Hunter", "", null, null, HomeWorld.HomeWorldId.Death_World));
        }
        #endregion

        /***
         * Archetype Talents
         ***/
        #region ArchetypeTalents Talents
        private void initArchetypeTalents()
        {
            initWarriorTalents();
        }

        private void initWarriorTalents()
        {
            ArchetypeTalents.Add(Archetype.ArchetypeId.Warrior, new List<Talent>());
            ArchetypeTalents[Archetype.ArchetypeId.Warrior].Add(new Talent(Talent.TalentId.War_Impetus, "Impetus", "", null, null, null, null, Archetype.ArchetypeId.Warrior));
            ArchetypeTalents[Archetype.ArchetypeId.Warrior].Add(new Talent(Talent.TalentId.War_RammingSpeed, "Ramming Speed", "", null, null, null, null, Archetype.ArchetypeId.Warrior));
            ArchetypeTalents[Archetype.ArchetypeId.Warrior].Add(new Talent(Talent.TalentId.War_RigorousTraining, "Rigorous Training", "", null, null, null, null, Archetype.ArchetypeId.Warrior));
        }
        #endregion
    }
}
