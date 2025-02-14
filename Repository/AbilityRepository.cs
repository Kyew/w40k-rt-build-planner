using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;

namespace W40KRogueTrader_BuildPlanner.Repository
{
    public sealed class AbilityRepository
    {
        private static AbilityRepository? instance = null;

        public static AbilityRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AbilityRepository();
                }
                return instance;
            }
        }

        public List<Ability> Abilities { get; private set; }

        private AbilityRepository() 
        {
            Abilities = new List<Ability>();

            //Warrior skills
            Abilities.Add(new Ability(Ability.AbilityId.Charge, "", Archetype.ArchetypeId.Warrior));
            Abilities.Add(new Ability(Ability.AbilityId.Endure, "", Archetype.ArchetypeId.Warrior));
            Abilities.Add(new Ability(Ability.AbilityId.Reckless_Strike, "", Archetype.ArchetypeId.Warrior));
            Abilities.Add(new Ability(Ability.AbilityId.Sworn_Ennemy, "", Archetype.ArchetypeId.Warrior));
            Abilities.Add(new Ability(Ability.AbilityId.Break_Through, "", Archetype.ArchetypeId.Warrior));
            Abilities.Add(new Ability(Ability.AbilityId.Forceful_Strike, "", Archetype.ArchetypeId.Warrior));
            Abilities.Add(new Ability(Ability.AbilityId.Taunting_Scream, "", Archetype.ArchetypeId.Warrior));
        }
    }
}
