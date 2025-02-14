using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;

namespace W40KRogueTrader_BuildPlanner.Repository
{
    public class UltimateUpgradeRepository
    {
        private static UltimateUpgradeRepository? instance = null;

        public static UltimateUpgradeRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UltimateUpgradeRepository();
                }
                return instance;
            }
        }

        public Dictionary<Archetype.ArchetypeType, List<UltimateUpgrade>> UltimateUpgrades;

        public UltimateUpgradeRepository()
        {
            UltimateUpgrades = new Dictionary<Archetype.ArchetypeType, List<UltimateUpgrade>>();
        }
    }
}
