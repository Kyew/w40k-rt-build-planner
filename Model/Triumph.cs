using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class Triumph : ADescribable
    {
        public enum TriumphId
        {
            Apex_Of_Brilliance,
            Illustrious_Glory,
            Feat_of_Greatness
        }

        public TriumphId Id { get; }

        public Triumph(TriumphId id, String description = "") : base(Enum.GetName(id).Replace('_', ' '), description)
        {
            Id = id;
        }
    }
}
