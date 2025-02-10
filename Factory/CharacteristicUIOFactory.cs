using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;
using W40KRogueTrader_BuildPlanner.ViewModel;

namespace W40KRogueTrader_BuildPlanner.Factory
{
    public sealed class CharacteristicUIOFactory
    {
        public CharacteristicUIOFactory() { }

        public CharacteristicUIO fromCharateristic(Characteristic characteristic, HomeWorld? homeWorld = null, HomeWorldArg? homeWorldArg = null)
        {
            int totalModifier = 0;
            if (homeWorld != null)
            {
                if (homeWorld.CharacteristicModifiers != null)
                {
                    foreach (CharacteristicModifier modifier in homeWorld.CharacteristicModifiers)
                    {
                        if (modifier.Id == characteristic.Id)
                        {
                            totalModifier += modifier.Value;
                        }
                    }
                }
                if (homeWorldArg != null)
                {
                    if (homeWorldArg.CharacteristicModifiers != null)
                    {
                        foreach (CharacteristicModifier modifier in homeWorldArg.CharacteristicModifiers)
                        {
                            if (modifier.Id == characteristic.Id)
                            {
                                totalModifier += modifier.Value;
                            }
                        }
                    }
                }
            }
            return new CharacteristicUIO(characteristic, totalModifier);
        }
    }
}
