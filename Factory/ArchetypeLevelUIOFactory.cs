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

        public ArchetypeLevelUIO fromArchetypeLevel(ArchetypeLevel level)
        {
            switch (level.Perks.Count)
            {
                case >= 3:
                    return new ArchetypeLevelUIO(perkFactory.fromPerk(level.Perks[0]), perkFactory.fromPerk(level.Perks[1]), perkFactory.fromPerk(level.Perks[2]));
                case 2:
                    return new ArchetypeLevelUIO(perkFactory.fromPerk(level.Perks[0]), perkFactory.fromPerk(level.Perks[1]), null);
                case 1:
                    return new ArchetypeLevelUIO(perkFactory.fromPerk(level.Perks[0]), null, null);
                default:
                    return new ArchetypeLevelUIO(perkFactory.fromPerk(new Perk(Perk.PerkType.Other)), null, null);
            }
        }
    }
}
