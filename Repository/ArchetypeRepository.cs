using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;

namespace W40KRogueTrader_BuildPlanner.Repository
{
    public sealed class ArchetypeRepository
    {
        private static ArchetypeRepository? instance = null;

        public static ArchetypeRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ArchetypeRepository();
                }
                return instance;
            }
        }

        public List<Archetype> Lvl1Archetypes { get; }
        public List<Archetype> Lvl2Archetypes { get; }
        public List<Archetype> Lvl3Archetypes { get; }

        public ArchetypeRepository()
        {
            //Level 3 archetypes
            Archetype exemplar = new Archetype(Archetype.ArchetypeId.Exemplar, "");
            Lvl3Archetypes = new List<Archetype> { exemplar };

            //Level 2 archetypes
            Archetype assassin = new Archetype(Archetype.ArchetypeId.Assassin, "", Lvl3Archetypes);
            Archetype vanguard = new Archetype(Archetype.ArchetypeId.Vanguard, "", Lvl3Archetypes);
            Archetype bountyHunter = new Archetype(Archetype.ArchetypeId.Bounty_Hunter, "", Lvl3Archetypes);
            Archetype masterTactician = new Archetype(Archetype.ArchetypeId.Master_Tactician, "", Lvl3Archetypes);
            Archetype grandStrategist = new Archetype(Archetype.ArchetypeId.Grand_Strategist, "", Lvl3Archetypes);
            Archetype archMilitant = new Archetype(Archetype.ArchetypeId.Arch_Militant, "", Lvl3Archetypes);
            Archetype executioner = new Archetype(Archetype.ArchetypeId.Executioner, "", Lvl3Archetypes);
            Lvl2Archetypes = new List<Archetype> { assassin, vanguard, bountyHunter, masterTactician, grandStrategist, archMilitant, executioner };

            //Level 1 archetypes
            Archetype warrior = new Archetype(Archetype.ArchetypeId.Warrior, "", new List<Archetype> { assassin, vanguard, archMilitant, executioner });
            Archetype officer = new Archetype(Archetype.ArchetypeId.Officer, "", new List<Archetype> { vanguard, masterTactician, grandStrategist });
            Archetype operative = new Archetype(Archetype.ArchetypeId.Operative, "", new List<Archetype> { assassin, bountyHunter, grandStrategist, executioner });
            Archetype soldier = new Archetype(Archetype.ArchetypeId.Soldier, "", new List<Archetype> { bountyHunter, archMilitant, masterTactician });
            Archetype bladeDancer = new Archetype(Archetype.ArchetypeId.Blade_Dancer, "", new List<Archetype> { assassin, masterTactician, archMilitant, executioner });
            Lvl1Archetypes = new List<Archetype> { warrior, officer, operative, soldier, bladeDancer };
        }
    }
}
