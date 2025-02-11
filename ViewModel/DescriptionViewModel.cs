using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;
using W40KRogueTrader_BuildPlanner.Repository;
using W40KRogueTrader_BuildPlanner.Utils.Extensions;

namespace W40KRogueTrader_BuildPlanner.ViewModel
{
    public class DescriptionViewModel : ViewModelBase
    {
        private readonly DescriptionRepository descriptionRepository;

        private Description? description;
        public Description? Description
        {
            get => description;
            private set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public ObservableCollection<SkillModifier> SkillModifiers { get; set; } = new ObservableCollection<SkillModifier>();
        public ObservableCollection<CharacteristicModifier> CharacteristicModifiers { get; set; } = new ObservableCollection<CharacteristicModifier>();

        public DescriptionViewModel() : this(DescriptionRepository.Instance)
        {

        }

        public DescriptionViewModel(DescriptionRepository descriptionRepository)
        {
            this.descriptionRepository = descriptionRepository;
            this.descriptionRepository.DescribableChanged += DescriptionRepository_DescribableChanged;
        }

        private void DescriptionRepository_DescribableChanged(object? sender, EventArgs e)
        {
            Description = descriptionRepository.Description;

            if (Description == null)
            {
                SkillModifiers.Clear();
                CharacteristicModifiers.Clear();
                return;
            }

            if (Description.SkillModifiers == null)
            {
                SkillModifiers.Clear();
            }
            else
            {
                SkillModifiers.CopyFrom(Description.SkillModifiers);
            }

            if (Description.CharacteristicModifiers == null)
            {
                CharacteristicModifiers.Clear();
            }
            else
            {
                CharacteristicModifiers.CopyFrom(Description.CharacteristicModifiers);
            }
        }
    }
}
