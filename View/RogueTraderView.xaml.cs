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
using W40KRogueTrader_BuildPlanner.Model;
using W40KRogueTrader_BuildPlanner.ViewModel;

namespace W40KRogueTrader_BuildPlanner.View
{
    /// <summary>
    /// Interaction logic for RogueTraderView.xaml
    /// </summary>
    public partial class RogueTraderView : Page
    {
        public RogueTraderView()
        {
            InitializeComponent();
            viewModel = new RogueTraderViewModel();
            DataContext = viewModel;

            populateHomeworldCombobox();
            RTHomeworld.SelectionChanged += RTHomeworld_SelectionChanged;
            populateHomeworldArgCombobox();
            RTHomeworldArg.SelectionChanged += RTHomeworldArg_SelectionChanged;
            populateOriginCombobox();
            RTOrigin.SelectionChanged += RTOrigin_SelectionChanged;
            populateOriginArgCombobox();
            RTOriginArg.SelectionChanged += RTOriginArg_SelectionChanged;
            populateTriumphCombobox();
            RTTriumph.SelectionChanged += RTTriumph_SelectionChanged;
            populateDarkestHourCombobox();
            RTDarkestHour.SelectionChanged += RTDarkestHour_SelectionChanged;
            populateArchetype1Combobox();
            RTArchetype1.SelectionChanged += RTArchetype1_SelectionChanged;
            populateArchetype2Combobox();
            RTArchetype2.SelectionChanged += RTArchetype2_SelectionChanged;
            populateArchetype3Combobox();
            RTArchetype3.SelectionChanged += RTArchetype3_SelectionChanged;

            populateCharacteristicsDG();
            populateSkillsDG();
        }

        private void populateHomeworldCombobox()
        {
            RTHomeworld.ItemsSource = viewModel.HomeWorlds;
            RTHomeworld.DisplayMemberPath = "Name";
        }

        private void populateHomeworldArgCombobox()
        {
            if (viewModel.RTHomeWorld == null)
            {
                RTHomeworldArg.ItemsSource = null;
                RTHomeworldArg.Visibility = Visibility.Hidden;
            }
            else
            {
                RTHomeworldArg.ItemsSource = viewModel.RTHomeWorld.PossibleArgs;
                RTHomeworldArg.DisplayMemberPath = "Name";
                RTHomeworldArg.Visibility = viewModel.RTHomeWorld.PossibleArgs != null ? Visibility.Visible : Visibility.Hidden;
            }
        }

        private void RTHomeworld_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTHomeWorld = RTHomeworld.SelectedItem as HomeWorld;
            viewModel.RTHomeWorldArg = null;
            populateHomeworldArgCombobox();
        }
        private void RTHomeworldArg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTHomeWorldArg = RTHomeworldArg.SelectedItem as HomeWorldArg;
        }

        private void populateOriginCombobox()
        {
            RTOrigin.ItemsSource = viewModel.Origins;
            RTOrigin.DisplayMemberPath = "Name";
        }

        private void populateOriginArgCombobox()
        {
            if (viewModel.RTOrigin == null)
            {
                RTOriginArg.ItemsSource = null;
                RTOriginArg.Visibility = Visibility.Hidden;
            }
            else
            {
                RTOriginArg.ItemsSource = viewModel.RTOrigin.PossibleArgs;
                RTOriginArg.DisplayMemberPath = "Name";
                RTOriginArg.Visibility = viewModel.RTOrigin.PossibleArgs == null ? Visibility.Hidden : Visibility.Visible;
            }
        }
        private void RTOrigin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTOrigin = RTOrigin.SelectedItem as Origin;
            viewModel.RTOriginArg = null;
            populateOriginArgCombobox();
            populateTriumphCombobox();
            populateDarkestHourCombobox();
        }

        private void RTOriginArg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTOriginArg = RTOriginArg.SelectedItem as OriginArg;
        }

        private void populateTriumphCombobox()
        {
            if (viewModel.RTOrigin == null)
            {
                RTTriumph.ItemsSource = null;
                RTTriumph.Visibility = Visibility.Hidden;
            }
            else
            {
                RTTriumph.ItemsSource = viewModel.RTOrigin.PossibleTriumphs;
                RTTriumph.DisplayMemberPath = "Name";
                RTTriumph.Visibility = viewModel.RTOrigin.PossibleTriumphs == null ? Visibility.Hidden : Visibility.Visible;
            }
        }

        private void RTTriumph_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTTriumph = RTTriumph.SelectedItem as Triumph;
        }

        private void populateDarkestHourCombobox()
        {
            if (viewModel.RTOrigin == null)
            {
                RTDarkestHour.ItemsSource = null;
                RTDarkestHour.Visibility = Visibility.Hidden;
            }
            else
            {
                RTDarkestHour.ItemsSource = viewModel.RTOrigin.PossibleDarkestHours;
                RTDarkestHour.DisplayMemberPath = "Name";
                RTDarkestHour.Visibility = viewModel.RTOrigin.PossibleDarkestHours == null ? Visibility.Hidden : Visibility.Visible;
            }
        }
        private void RTDarkestHour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTDarkestHour = RTDarkestHour.SelectedItem as DarkestHour;
        }

        private void populateArchetype1Combobox()
        {
            RTArchetype1.ItemsSource = viewModel.Lvl1Archetypes;
            RTArchetype1.DisplayMemberPath = "Name";
        }

        private void RTArchetype1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTLvl1Archetype = RTArchetype1.SelectedItem as Archetype;
            viewModel.RTLvl2Archetype = null;
            viewModel.RTLvl3Archetype = null;
            populateArchetype2Combobox();
            populateArchetype3Combobox();
        }

        private void populateArchetype2Combobox()
        {
            if (viewModel.RTLvl1Archetype == null)
            {
                RTArchetype2.ItemsSource = null;
                RTArchetype2.Visibility = Visibility.Hidden;
            }
            else
            {
                RTArchetype2.ItemsSource = viewModel.RTLvl1Archetype.PossibleNextArchetypes;
                RTArchetype2.DisplayMemberPath = "Name";
                RTArchetype2.Visibility = Visibility.Visible;
            }
        }

        private void RTArchetype2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTLvl2Archetype = RTArchetype2.SelectedItem as Archetype;
            viewModel.RTLvl3Archetype = null;
            populateArchetype3Combobox();
        }

        private void populateArchetype3Combobox()
        {
            if (viewModel.RTLvl2Archetype == null)
            {
                RTArchetype3.ItemsSource = null;
                RTArchetype3.Visibility = Visibility.Hidden;
            }
            else
            {
                RTArchetype3.ItemsSource = viewModel.RTLvl2Archetype.PossibleNextArchetypes;
                RTArchetype3.DisplayMemberPath = "Name";
                RTArchetype3.Visibility = Visibility.Visible;
            }
        }
        private void RTArchetype3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTLvl3Archetype = RTArchetype3.SelectedItem as Archetype;
        }

        private void populateCharacteristicsDG()
        {
            CharacteristicsDG.ItemsSource = viewModel.Characteristics;
        }

        private void populateSkillsDG()
        {
            SkillsDG.ItemsSource = viewModel.Skills;
        }

        private void DescribableCBI_MouseMove(object sender, RoutedEventArgs e)
        {
            ComboBoxItem? item = sender as ComboBoxItem;

            if (item == null)
            {
                return;
            }

            ADescribable? describable = item.Content as ADescribable;

            if (describable == null)
            {
                return;
            }

            viewModel.storeDescribable(describable);
        }

        private void DescribableDGR_MouseMove(object sender, RoutedEventArgs e)
        {
            DataGridRow? item = sender as DataGridRow;

            if (item == null)
            {
                return;
            }

            ADescribable? describable = item.DataContext as ADescribable;

            if (describable == null)
            {
                return;
            }

            viewModel.storeDescribable(describable);
        }

        private RogueTraderViewModel viewModel;
    }
}
