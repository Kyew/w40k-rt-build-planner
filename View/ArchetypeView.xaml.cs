﻿using System;
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
using W40KRogueTrader_BuildPlanner.ViewModel.ArchetypeViewModel;

namespace W40KRogueTrader_BuildPlanner.View
{
    /// <summary>
    /// Interaction logic for ArchetypeView.xaml
    /// </summary>
    public partial class ArchetypeView : Page
    {
        private ArchetypeViewModel viewModel;

        public ArchetypeView(ArchetypeViewModel viewModel)
        {
            this.viewModel = viewModel;

            InitializeComponent();
            DataContext = viewModel;

            PerkChoices.ItemsSource = viewModel.SelectedPerkOptions;

            BackButton.Click += BackButton_Click;

            LevelsDG.SelectedCellsChanged += LevelsDG_SelectedCellsChanged;

            populateLevelsDG();
        }

        private void LevelsDG_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (e.AddedCells.Count == 0)
            {
                return;
            }

            PerkUIO? perk;
            ArchetypeLevelUIO? level = e.AddedCells[0].Item as ArchetypeLevelUIO;
            
            if (level == null)
            {
                return;
            }

            int row = LevelsDG.Items.IndexOf(e.AddedCells[0].Item);
            int col = e.AddedCells[0].Column.DisplayIndex;

            switch (e.AddedCells[0].Column.DisplayIndex)
            {
                case 0:
                    perk = level.Perk1;
                    break;
                case 1:
                    perk = level.Perk2;
                    break;
                case 2:
                    perk = level.Perk3;
                    break;
                default:
                    perk = null;
                    break;
            }

            if (perk != null)
            {
                viewModel.SelectedPerk = new SelectedPerkUIO(row, col, perk);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void populateLevelsDG()
        {
            LevelsDG.ItemsSource = viewModel.Levels;
        }

        private void PerkChoices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                return;
            }
            
            IDescribable? perkOption = e.AddedItems[0] as IDescribable;

            if (perkOption == null)
            {
                return;
            }

            viewModel.SelectPerkOption(perkOption);
        }

        /***
         * Descriptions
         ***/
        #region Descriptions
        private void DescribableDGC_MouseMove(object sender, RoutedEventArgs e)
        {
            DataGridCell? item = sender as DataGridCell;

            if (item == null)
            {
                return;
            }

            ArchetypeLevelUIO? archetypeLevelUIO = item.DataContext as ArchetypeLevelUIO;

            if (archetypeLevelUIO == null)
            {
                return;
            }

            IDescribable? describable;

            switch(item.Column.DisplayIndex)
            {
                case 0:
                    describable = archetypeLevelUIO.Perk1;
                    break;
                case 1:
                    describable = archetypeLevelUIO.Perk2;
                    break;
                case 2:
                    describable = archetypeLevelUIO.Perk3;
                    break;
                default:
                    describable = null;
                    break;
            }

            if (describable == null)
            {
                return;
            }

            viewModel.StoreDescribable(describable.Description);
        }

        private void DescribableLVI_MouseMove(object sender, RoutedEventArgs e)
        {
            ListViewItem? item = sender as ListViewItem;

            if (item == null)
            {
                return;
            }

            IDescribable? describable = item.DataContext as IDescribable;

            if (describable == null)
            {
                return;
            }

            viewModel.StoreDescribable(describable.Description);
        }
        #endregion
    }
}
