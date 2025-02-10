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
        private RogueTraderViewModel viewModel;

        public RogueTraderView()
        {
            InitializeComponent();
            viewModel = new RogueTraderViewModel();
            DataContext = viewModel;

            populateHomeworldCombobox();
            RTHomeworld.SelectionChanged += RTHomeworld_SelectionChanged;

            populateHomeworldArgCombobox();
            RTHomeworldArg.SelectionChanged += RTHomeworldArg_SelectionChanged;
            viewModel.HomeWorldArgs.CollectionChanged += HomeWorldArgs_CollectionChanged;

            populateOriginCombobox();
            RTOrigin.SelectionChanged += RTOrigin_SelectionChanged;

            populateOriginArgCombobox();
            RTOriginArg.SelectionChanged += RTOriginArg_SelectionChanged;
            viewModel.OriginArgs.CollectionChanged += OriginArgs_CollectionChanged;

            populateTriumphCombobox();
            RTTriumph.SelectionChanged += RTTriumph_SelectionChanged;
            viewModel.Triumphs.CollectionChanged += Triumphs_CollectionChanged;

            populateDarkestHourCombobox();
            RTDarkestHour.SelectionChanged += RTDarkestHour_SelectionChanged;
            viewModel.DarkestHours.CollectionChanged += DarkestHours_CollectionChanged;

            populateArchetype1Combobox();
            RTArchetype1.SelectionChanged += RTArchetype1_SelectionChanged;
            populateArchetype2Combobox();
            RTArchetype2.SelectionChanged += RTArchetype2_SelectionChanged;
            viewModel.Lvl2Archetypes.CollectionChanged += Lvl2Archetypes_CollectionChanged;
            populateArchetype3Combobox();
            RTArchetype3.SelectionChanged += RTArchetype3_SelectionChanged;
            viewModel.Lvl3Archetypes.CollectionChanged += Lvl3Archetypes_CollectionChanged;

            populateCharacteristicsDG();
            populateSkillsDG();
        }

        /***
         * HomeWorld
         ***/
        #region HomeWorld
        private void populateHomeworldCombobox()
        {
            RTHomeworld.ItemsSource = viewModel.HomeWorlds;
            RTHomeworld.DisplayMemberPath = "Description.Name";
        }

        private void populateHomeworldArgCombobox()
        {
            RTHomeworldArg.ItemsSource = viewModel.HomeWorldArgs;
            RTHomeworldArg.DisplayMemberPath = "Description.Name";
            RTHomeworldArg.Visibility = viewModel.HomeWorldArgs.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }

        private void RTHomeworld_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTHomeWorld = RTHomeworld.SelectedItem as HomeWorld;
            viewModel.RTHomeWorldArg = null;
        }

        private void RTHomeworldArg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTHomeWorldArg = RTHomeworldArg.SelectedItem as HomeWorldArg;
        }

        private void HomeWorldArgs_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RTHomeworldArg.Visibility = viewModel.HomeWorldArgs.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }
        #endregion

        /***
         * Origin
         ***/
        #region Origin
        private void populateOriginCombobox()
        {
            RTOrigin.ItemsSource = viewModel.Origins;
            RTOrigin.DisplayMemberPath = "Description.Name";
        }

        private void populateOriginArgCombobox()
        {
            RTOriginArg.ItemsSource = viewModel.OriginArgs;
            RTOriginArg.DisplayMemberPath = "Description.Name";
            RTOriginArg.Visibility = viewModel.OriginArgs.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }
        private void RTOrigin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTOrigin = RTOrigin.SelectedItem as Origin;
            viewModel.RTOriginArg = null;
        }

        private void RTOriginArg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTOriginArg = RTOriginArg.SelectedItem as OriginArg;
        }

        private void OriginArgs_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RTOriginArg.Visibility = viewModel.OriginArgs.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }
        #endregion 

        /***
         * Triumph
         ***/
        #region Triumph
        private void populateTriumphCombobox()
        {
            RTTriumph.ItemsSource = viewModel.Triumphs;
            RTTriumph.DisplayMemberPath = "Description.Name";
            RTTriumph.Visibility = viewModel.Triumphs.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }

        private void RTTriumph_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTTriumph = RTTriumph.SelectedItem as Triumph;
        }

        private void Triumphs_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RTTriumph.Visibility = viewModel.Triumphs.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }
        #endregion 

        /***
         * DarkestHour
         ***/
        #region DarkestHour
        private void populateDarkestHourCombobox()
        {
            RTDarkestHour.ItemsSource = viewModel.DarkestHours;
            RTDarkestHour.DisplayMemberPath = "Description.Name";
            RTDarkestHour.Visibility = viewModel.DarkestHours.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }

        private void RTDarkestHour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTDarkestHour = RTDarkestHour.SelectedItem as DarkestHour;
        }

        private void DarkestHours_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RTDarkestHour.Visibility = viewModel.DarkestHours.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }
        #endregion 

        /***
         * Archetypes
         ***/
        #region Archetypes
        private void populateArchetype1Combobox()
        {
            RTArchetype1.ItemsSource = viewModel.Lvl1Archetypes;
            RTArchetype1.DisplayMemberPath = "Description.Name";
        }

        private void RTArchetype1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTLvl1Archetype = RTArchetype1.SelectedItem as Archetype;
        }

        private void populateArchetype2Combobox()
        {
            RTArchetype2.ItemsSource = viewModel.Lvl2Archetypes;
            RTArchetype2.DisplayMemberPath = "Description.Name";
            RTArchetype2.Visibility = viewModel.Lvl2Archetypes.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }

        private void RTArchetype2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTLvl2Archetype = RTArchetype2.SelectedItem as Archetype;
        }
        private void Lvl2Archetypes_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RTArchetype2.Visibility = viewModel.Lvl2Archetypes.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }

        private void populateArchetype3Combobox()
        {
            RTArchetype3.ItemsSource = viewModel.Lvl3Archetypes;
            RTArchetype3.DisplayMemberPath = "Description.Name";
            RTArchetype3.Visibility = viewModel.Lvl3Archetypes.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }

        private void RTArchetype3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.RTLvl3Archetype = RTArchetype3.SelectedItem as Archetype;
        }

        private void Lvl3Archetypes_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RTArchetype3.Visibility = viewModel.Lvl3Archetypes.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }
        #endregion

        /***
         * Characteristics
         ***/
        #region Characteristics
        private void populateCharacteristicsDG()
        {
            CharacteristicsDG.ItemsSource = viewModel.Characteristics;
        }
        #endregion

        /***
         * Skills
         ***/
        #region Skills
        private void populateSkillsDG()
        {
            SkillsDG.ItemsSource = viewModel.Skills;
        }
        #endregion

        /***
         * Descriptions
         ***/
        #region Descriptions
        private void DescribableCBI_MouseMove(object sender, RoutedEventArgs e)
        {
            ComboBoxItem? item = sender as ComboBoxItem;

            if (item == null)
            {
                return;
            }

            IDescribable? describable = item.Content as IDescribable;

            if (describable == null)
            {
                return;
            }

            viewModel.storeDescribable(describable.Description);
        }

        private void DescribableDGR_MouseMove(object sender, RoutedEventArgs e)
        {
            DataGridRow? item = sender as DataGridRow;

            if (item == null)
            {
                return;
            }

            IDescribable? describable = item.DataContext as IDescribable;

            if (describable == null)
            {
                return;
            }

            viewModel.storeDescribable(describable.Description);
        }
        #endregion
    }
}
