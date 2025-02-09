using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class Origin : ADescribable
    {
        public enum OriginId
        {
            Astra_Militarum_Commander,
            Comissar,
            Crime_Lord,
            Ministorum_Priest,
            Navy_Officer,
            Noble,
            Sanctionned_Psyker
        }

        public OriginId Id { get; }

        public List<OriginArg>? PossibleArgs { get; }

        public List<DarkestHour>? PossibleDarkestHours { get; }
        public List<Triumph>? PossibleTriumphs { get; }

        public Origin(OriginId id,
                      String description = "",
                      List<OriginArg>? possibleArgs = null,
                      List<Triumph>? possibleTriumphs = null,
                      List<DarkestHour>? darkestHours = null) : base(Enum.GetName(id).Replace('_', ' '), description)
        {
            Id = id;
            PossibleArgs = possibleArgs;
            PossibleTriumphs = possibleTriumphs;
            PossibleDarkestHours = darkestHours;
        } 
    }
}
