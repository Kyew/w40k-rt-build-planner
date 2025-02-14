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
            /*
            //Level 3 archetypes
            Archetype exemplar = new Archetype(Archetype.ArchetypeId.Exemplar, Archetype.ArchetypeType.Final, "");
            Lvl3Archetypes = new List<Archetype> { exemplar };

            //Level 2 archetypes
            Archetype assassin = new Archetype(Archetype.ArchetypeId.Assassin, Archetype.ArchetypeType.Intermediate, "", Lvl3Archetypes);
            Archetype vanguard = new Archetype(Archetype.ArchetypeId.Vanguard, Archetype.ArchetypeType.Intermediate, "", Lvl3Archetypes);
            Archetype bountyHunter = new Archetype(Archetype.ArchetypeId.Bounty_Hunter, Archetype.ArchetypeType.Intermediate, "", Lvl3Archetypes);
            Archetype masterTactician = new Archetype(Archetype.ArchetypeId.Master_Tactician, Archetype.ArchetypeType.Intermediate, "", Lvl3Archetypes);
            Archetype grandStrategist = new Archetype(Archetype.ArchetypeId.Grand_Strategist, Archetype.ArchetypeType.Intermediate, "", Lvl3Archetypes);
            Archetype archMilitant = new Archetype(Archetype.ArchetypeId.Arch_Militant, Archetype.ArchetypeType.Intermediate, "", Lvl3Archetypes);
            Archetype executioner = new Archetype(Archetype.ArchetypeId.Executioner, Archetype.ArchetypeType.Intermediate, "", Lvl3Archetypes);
            Lvl2Archetypes = new List<Archetype> { assassin, vanguard, bountyHunter, masterTactician, grandStrategist, archMilitant, executioner };*/

            //Level 1 archetypes
            List<ArchetypeLevel> levels = new List<ArchetypeLevel> { new ArchetypeLevel(1, new List<Perk> { new Perk(Ability.AbilityId.Charge) }),
                                                                     new ArchetypeLevel(2, new List<Perk> { new Perk(Perk.PerkType.SkillUpgrade) }),
                                                                     new ArchetypeLevel(3, new List<Perk> { new Perk(Ability.AbilityId.Endure) }),
                                                                     new ArchetypeLevel(4, new List<Perk> { new Perk(Perk.PerkType.Other), new Perk(Perk.PerkType.Talent) }),
                                                                     new ArchetypeLevel(5, new List<Perk> { new Perk(Perk.PerkType.Talent), new Perk(Perk.PerkType.CharacteristicUpgrade) }),
                                                                     new ArchetypeLevel(6, new List<Perk> { new Perk(Perk.PerkType.Ability), new Perk(Perk.PerkType.SkillUpgrade) }),
                                                                     new ArchetypeLevel(7, new List<Perk> { new Perk(Perk.PerkType.CharacteristicUpgrade), new Perk(Perk.PerkType.CommonTalent) }),
                                                                     new ArchetypeLevel(8, new List<Perk> { new Perk(Perk.PerkType.SkillUpgrade), new Perk(Perk.PerkType.Talent) }),
                                                                     new ArchetypeLevel(9, new List<Perk> { new Perk(Perk.PerkType.UltimateUpgrade) }),
                                                                     new ArchetypeLevel(10, new List<Perk> { new Perk(Perk.PerkType.Talent), new Perk(Perk.PerkType.CharacteristicUpgrade) }),
                                                                     new ArchetypeLevel(11, new List<Perk> { new Perk(Perk.PerkType.Ability), new Perk(Perk.PerkType.CommonTalent) }),
                                                                     new ArchetypeLevel(12, new List<Perk> { new Perk(Perk.PerkType.CharacteristicUpgrade), new Perk(Perk.PerkType.SkillUpgrade) }),
                                                                     new ArchetypeLevel(13, new List<Perk> { new Perk(Perk.PerkType.Talent), new Perk(Perk.PerkType.SkillUpgrade) }),
                                                                     new ArchetypeLevel(14, new List<Perk> { new Perk(Perk.PerkType.CharacteristicUpgrade), new Perk(Perk.PerkType.CommonTalent) }),
                                                                     new ArchetypeLevel(15, new List<Perk> { new Perk(Perk.PerkType.UltimateUpgrade)}) };
            Archetype warrior = new Archetype(Archetype.ArchetypeId.Warrior, Archetype.ArchetypeType.Base, levels, "", new List<Archetype> {  });
            /*Archetype officer = new Archetype(Archetype.ArchetypeId.Officer, Archetype.ArchetypeType.Base, "", new List<Archetype> { vanguard, masterTactician, grandStrategist });
            Archetype operative = new Archetype(Archetype.ArchetypeId.Operative, Archetype.ArchetypeType.Base, "", new List<Archetype> { assassin, bountyHunter, grandStrategist, executioner });
            Archetype soldier = new Archetype(Archetype.ArchetypeId.Soldier, Archetype.ArchetypeType.Base, "", new List<Archetype> { bountyHunter, archMilitant, masterTactician });
            Archetype bladeDancer = new Archetype(Archetype.ArchetypeId.Blade_Dancer, Archetype.ArchetypeType.Base, "", new List<Archetype> { assassin, masterTactician, archMilitant, executioner });*/
            Lvl1Archetypes = new List<Archetype> { warrior/*, officer, operative, soldier, bladeDancer */};
        }
    }
}
