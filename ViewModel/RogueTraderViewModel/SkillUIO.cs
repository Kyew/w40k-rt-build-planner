using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using W40KRogueTrader_BuildPlanner.Model;

namespace W40KRogueTrader_BuildPlanner.ViewModel.RogueTraderViewModel
{
    public class SkillUIO : IDescribable
    {
        public Skill Skill { get; }
        public Description Description => Skill.Description;
        public int BaseValue { get; }
        public int Modifiers { get; }
        public int TotalValue => BaseValue + Modifiers;
        public Brush Foreground { get; }

        public SkillUIO(Skill skill, int baseValue, int modifiers)
        {
            Skill = skill;
            BaseValue = baseValue;
            Modifiers = modifiers;

            if (Modifiers == 0)
            {
                Foreground = RogueTraderViewModel.NullModifierBrush;
            }
            else if (Modifiers > 0)
            {
                Foreground = RogueTraderViewModel.PositiveModifierBrush;
            }
            else
            {
                Foreground = RogueTraderViewModel.NegativeModifierBrush;
            }
        }
    }
}
