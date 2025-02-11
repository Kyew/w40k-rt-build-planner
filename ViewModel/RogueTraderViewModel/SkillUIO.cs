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
        public Skill.SkillId Id { get; }
        public Description Description { get; }
        public int BaseValue { get; }
        public int Modifiers { get; }
        public int TotalValue => BaseValue + Modifiers;
        public Brush Foreground { get; }

        public SkillUIO(Skill.SkillId id, Description description, int baseValue, int modifiers)
        {
            Id = id;
            Description = description;
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
