using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;
using W40KRogueTrader_BuildPlanner.Repository;
using W40KRogueTrader_BuildPlanner.ViewModel.RogueTraderViewModel;

namespace W40KRogueTrader_BuildPlanner.Factory
{
    public sealed class SkillUIOFactory
    {
        public SkillUIOFactory()
        {
        }

        public SkillUIO fromSkill(Skill skill, List<SkillModifier> skillModifiers, List<CharacteristicUIO> characteristics)
        {

            CharacteristicUIO? charateristic = characteristics.Find(x => x.Characteristic.Id == skill.BaseCharacteristic);

            if (charateristic == null)
            {
                throw new Exception("Characteristic with id '" + skill.BaseCharacteristic.ToString() + "' not found");
            }

            int totalModifier = 0;
            foreach (SkillModifier mod in skillModifiers)
            {
                if (mod.Id == skill.Id)
                {
                    totalModifier += mod.Value;
                }
            }

            return new SkillUIO(skill.Id, skill.Description, charateristic.TotalValue, totalModifier);
        }
    }
}
