using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;
using W40KRogueTrader_BuildPlanner.ViewModel.ArchetypeViewModel;

namespace W40KRogueTrader_BuildPlanner.Factory
{
    public class ArchetypeLevelUIOFactory
    {
        private PerkUIOFactory perkFactory;

        public ArchetypeLevelUIOFactory()
        {
            perkFactory = new PerkUIOFactory();
        }

        public ArchetypeLevelUIO fromArchetypeLevel(ArchetypeLevel level, Archetype archetype)
        {
            switch (level.Perks.Count)
            {
                case >= 3:
                    return new ArchetypeLevelUIO(perkFactory.fromPerk(level.Perks[0], archetype), perkFactory.fromPerk(level.Perks[1], archetype), perkFactory.fromPerk(level.Perks[2], archetype));
                case 2:
                    return new ArchetypeLevelUIO(perkFactory.fromPerk(level.Perks[0], archetype), perkFactory.fromPerk(level.Perks[1], archetype), null);
                case 1:
                    return new ArchetypeLevelUIO(perkFactory.fromPerk(level.Perks[0], archetype), null, null);
                default:
                    return new ArchetypeLevelUIO(perkFactory.fromPerk(new Perk(Perk.PerkType.Other), archetype), null, null);
            }
        }
    }
}
