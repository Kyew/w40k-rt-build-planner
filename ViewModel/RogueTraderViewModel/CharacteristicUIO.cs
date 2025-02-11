using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using W40KRogueTrader_BuildPlanner.Model;

namespace W40KRogueTrader_BuildPlanner.ViewModel.RogueTraderViewModel
{
    public class CharacteristicUIO : IDescribable
    {
        public Characteristic Characteristic { get; }
        public Description Description => Characteristic.Description;
        public int Modifiers { get; }
        public int TotalValue => Characteristic.StartingValue + Modifiers;
        public Brush Foreground { get; }

        public CharacteristicUIO(Characteristic characteristic, int modifiers)
        {
            Characteristic = characteristic;
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
