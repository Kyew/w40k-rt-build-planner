using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public record Description(String Name, String Details, List<SkillModifier>? SkillModifiers = null, List<CharacteristicModifier>? CharacteristicModifiers = null);
}
