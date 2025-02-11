using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using W40KRogueTrader_BuildPlanner.ViewModel;

namespace W40KRogueTrader_BuildPlanner.View
{
    /// <summary>
    /// Interaction logic for DescriptionView.xaml
    /// </summary>
    public partial class DescriptionView : Page
    {
        private DescriptionViewModel viewModel;

        public DescriptionView()
        {
            InitializeComponent();
            viewModel = new DescriptionViewModel();
            DataContext = viewModel;

            populateSkillModifiersDG();
            viewModel.SkillModifiers.CollectionChanged += SkillModifiers_CollectionChanged;
            populateCharacteristicModifiersDG();
            viewModel.CharacteristicModifiers.CollectionChanged += CharacteristicModifiers_CollectionChanged;
        }

        /***
         * Skills
         ***/
        #region Skills
        private void populateSkillModifiersDG()
        {
            SkillModifiers.ItemsSource = viewModel.SkillModifiers;
            SkillModifiers.Visibility = viewModel.SkillModifiers.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }

        private void SkillModifiers_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SkillModifiers.Visibility = viewModel.SkillModifiers.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }
        #endregion

        /***
         * Characteristics
         ***/
        #region Characteristics
        private void populateCharacteristicModifiersDG()
        {
            CharacteristicModifiers.ItemsSource = viewModel.CharacteristicModifiers;
            CharacteristicModifiers.Visibility = viewModel.CharacteristicModifiers.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }
        private void CharacteristicModifiers_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CharacteristicModifiers.Visibility = viewModel.CharacteristicModifiers.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }
        #endregion
    }
}
