using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;
using W40KRogueTrader_BuildPlanner.Repository;

namespace W40KRogueTrader_BuildPlanner.ViewModel
{
    public class DescriptionViewModel : ViewModelBase
    {
        private readonly DescriptionRepository descriptionRepository;

        private ADescribable? describable;
        public ADescribable? Describable
        {
            get => describable;
            private set
            {
                if (describable != value)
                {
                    describable = value;
                    OnPropertyChanged("Describable");
                }
            }
        }

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
            Describable = descriptionRepository.Describable;
        }
    }
}
