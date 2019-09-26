using I_Need_That_A;
using SAMS.ViewModels;
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
using System.Windows.Shapes;

namespace SAMS.View
{
    /// <summary>
    /// Interaction logic for SelectedSubjectWindow.xaml
    /// </summary>
    public partial class SelectedSubjectWindow : Window
    {
        public SelectedSubjectWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModelLocator.SelectedSubjectViewModel;
            ViewModelLocator.SelectedSubjectViewModel.SetPercentages();
            ViewModelLocator.SelectedSubjectViewModel.GetAndDisplayActivities();

            //CmbGradingPeriodFrom.Items.Clear();
            //CmbGradingPeriodFrom.Items.Add("Prelim");
            //CmbGradingPeriodFrom.Items.Add("Midterm");
            //CmbGradingPeriodFrom.Items.Add("Prefi");
        }

        private void BtnChangePercentEffectPrelim_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 0;
            var window = new ChangePercentageWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            var result = window.ShowDialog();
            
            if (result == true)
            {

            }
        }

        private void BtnAddComponent_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddActivityWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 0;
            ViewModelLocator.SelectedSubjectViewModel.IsEdit = false;

            ACTIVITY newActivity = new ACTIVITY();
            window.DataContext = newActivity;

            var result = window.ShowDialog();

            if (result == true)
            {
                ViewModelLocator.SelectedSubjectViewModel.AddActivity(newActivity);
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvPrelimComponents.SelectedItem != null)
            {
                ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 0;
                ViewModelLocator.SelectedSubjectViewModel.IsEdit = true;
                var window = new AddActivityWindow();
                window.Owner = this;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                ACTIVITY changedActivity = ViewModelLocator.SelectedSubjectViewModel.SelectedActivity as ACTIVITY;
                window.DataContext = changedActivity;

                var result = window.ShowDialog();
                if (result == true)
                {
                    ViewModelLocator.SelectedSubjectViewModel.EditActivity(changedActivity);
                }
            }
        }

        private void BtnRemoveComponent_Click(object sender, RoutedEventArgs e)
        {
            if (LvPrelimComponents.SelectedItem != null)
            {
                ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 0;
                ViewModelLocator.SelectedSubjectViewModel.RemoveActivity();
            }
        }

        private void LvPrelimComponents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 0 && LvPrelimComponents.SelectedItem != null)
            {
                var window = new ScoresListWindow();
                window.Owner = this;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                var result = window.ShowDialog();

                if (result == true)
                {

                }
            }
        }

        private void LvPrelimComponents_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (LvPrelimComponents.SelectedItem != null)
            {
                LvPrelimComponents.SelectedItem = null;
                ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = -1;
            }
        }

        private void BtnChangePercentEffectMidterm_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 1;
            var window = new ChangePercentageWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            var result = window.ShowDialog();

            if (result == true)
            {

            }
        }

        private void BtnAddComponentMidterm_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddActivityWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 1;
            ViewModelLocator.SelectedSubjectViewModel.IsEdit = false;

            ACTIVITY newActivity = new ACTIVITY();
            window.DataContext = newActivity;

            var result = window.ShowDialog();

            if (result == true)
            {
                ViewModelLocator.SelectedSubjectViewModel.AddActivity(newActivity);
            }
        }

        private void BtnEditMidterm_Click(object sender, RoutedEventArgs e)
        {
            if (LvMidtermComponents.SelectedItem != null)
            {
                ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 1;
                ViewModelLocator.SelectedSubjectViewModel.IsEdit = true;
                var window = new AddActivityWindow();
                window.Owner = this;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                ACTIVITY changedActivity = ViewModelLocator.SelectedSubjectViewModel.SelectedActivity as ACTIVITY;
                window.DataContext = changedActivity;

                var result = window.ShowDialog();
                if (result == true)
                {
                    ViewModelLocator.SelectedSubjectViewModel.EditActivity(changedActivity);
                }
            }
        }

        private void BtnRemoveComponentMidterm_Click(object sender, RoutedEventArgs e)
        {
            if (LvMidtermComponents.SelectedItem != null)
            {
                ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 1;
                ViewModelLocator.SelectedSubjectViewModel.RemoveActivity();
            }
        }

        private void LvMidtermComponents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 1 && LvMidtermComponents.SelectedItem != null)
            {
                var window = new ScoresListWindow();
                window.Owner = this;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                var result = window.ShowDialog();

                if (result == true)
                {
                    
                }
            }
        }

        private void LvMidtermComponents_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (LvMidtermComponents.SelectedItem != null)
            {
                ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = -1;
                LvMidtermComponents.SelectedItem = null;
            }
        }

        private void BtnChangePercentEffectPrefinal_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 2;
            var window = new ChangePercentageWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            var result = window.ShowDialog();

            if (result == true)
            {

            }
        }

        private void BtnAddComponentPrefinal_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddActivityWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 2;
            ViewModelLocator.SelectedSubjectViewModel.IsEdit = false;

            ACTIVITY newActivity = new ACTIVITY();
            window.DataContext = newActivity;

            var result = window.ShowDialog();

            if (result == true)
            {
                ViewModelLocator.SelectedSubjectViewModel.AddActivity(newActivity);
            }
        }

        private void BtnEditPrefinal_Click(object sender, RoutedEventArgs e)
        {
            if (LvPrefinalComponents.SelectedItem != null)
            {
                ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 2;
                ViewModelLocator.SelectedSubjectViewModel.IsEdit = true;
                var window = new AddActivityWindow();
                window.Owner = this;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                ACTIVITY changedActivity = ViewModelLocator.SelectedSubjectViewModel.SelectedActivity as ACTIVITY;
                window.DataContext = changedActivity;

                var result = window.ShowDialog();
                if (result == true)
                {
                    ViewModelLocator.SelectedSubjectViewModel.EditActivity(changedActivity);
                }
            }
        }

        private void BtnRemoveComponentPrefinal_Click(object sender, RoutedEventArgs e)
        {
            if (LvPrefinalComponents.SelectedItem != null)
            {
                ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 2;
                ViewModelLocator.SelectedSubjectViewModel.RemoveActivity();
            }
        }

        private void LvPrefinalComponents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 2 && LvPrefinalComponents.SelectedItem != null)
            {
                var window = new ScoresListWindow();
                window.Owner = this;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                var result = window.ShowDialog();

                if (result == true)
                {

                }
            }
        }

        private void LvPrefinalComponents_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (LvPrefinalComponents.SelectedItem != null)
            {
                LvPrefinalComponents.SelectedItem = null;
                ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = -1;
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            _prevWindow.Show();
            this.Hide();
        }

        SubjectsListWindow _prevWindow = new SubjectsListWindow();

        private void LvPrelimComponents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LvPrelimComponents.SelectedItem != null)
            {
                ViewModelLocator.SelectedSubjectViewModel.SelectedActivity = LvPrelimComponents.SelectedItem as ACTIVITY;
                LvMidtermComponents.SelectedItem = null;
                LvPrefinalComponents.SelectedItem = null;
                ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 0;
            }
        }

        private void LvMidtermComponents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LvMidtermComponents.SelectedItem != null)
            {
                ViewModelLocator.SelectedSubjectViewModel.SelectedActivity = LvMidtermComponents.SelectedItem as ACTIVITY;
                LvPrelimComponents.SelectedItem = null;
                LvPrefinalComponents.SelectedItem = null;
                ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 1;
            }
        }

        private void LvPrefinalComponents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LvPrefinalComponents.SelectedItem != null)
            {
                ViewModelLocator.SelectedSubjectViewModel.SelectedActivity = LvPrefinalComponents.SelectedItem as ACTIVITY;
                LvPrelimComponents.SelectedItem = null;
                LvMidtermComponents.SelectedItem = null;
                ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod = 2;
            }
        }

        private void CmbGradingPeriodFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //CmbGradingPeriodTo.Items.Clear();
            //if (CmbGradingPeriodFrom.SelectedItem.ToString() == "Prelim")
            //{
            //    CmbGradingPeriodTo.Items.Add("Midterm");
            //    CmbGradingPeriodTo.Items.Add("Prefi");
            //}

            //if (CmbGradingPeriodFrom.SelectedItem.ToString() == "Midterm")
            //{
            //    CmbGradingPeriodTo.Items.Add("Prelim");
            //    CmbGradingPeriodTo.Items.Add("Prefi");
            //}

            //if (CmbGradingPeriodFrom.SelectedItem.ToString() == "Prefi")
            //{
            //    CmbGradingPeriodTo.Items.Add("Prelim");
            //    CmbGradingPeriodTo.Items.Add("Midterm");
            //}
        }

        private void BtnGo_Click(object sender, RoutedEventArgs e)
        {
            //if (RbEveryOther.IsChecked == true)
            //{
            //    ViewModelLocator.SelectedSubjectViewModel.CopyComponents(CmbGradingPeriodFrom.SelectedItem.ToString(), "both");
            //}

            //if (RbTo.IsChecked == true)
            //{
            //    ViewModelLocator.SelectedSubjectViewModel.CopyComponents(CmbGradingPeriodFrom.SelectedItem.ToString(), CmbGradingPeriodTo.SelectedItem.ToString());
            //}
        }
    }
}
