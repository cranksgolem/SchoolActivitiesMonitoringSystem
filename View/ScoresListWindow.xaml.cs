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
    /// Interaction logic for ScoresListWindow.xaml
    /// </summary>
    public partial class ScoresListWindow : Window
    {
        public ScoresListWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModelLocator.ScoresListViewModel;
            ViewModelLocator.ScoresListViewModel.GetAndDisplayScores();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.ScoresListViewModel.SelectedScore = null;
            DialogResult = true;
        }

        private void BtnAddActivity_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddScoreWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            SCORE newScore = new SCORE();
            newScore.Date = DateTime.Now;
            window.DataContext = newScore;

            var result = window.ShowDialog();

            if (result == true)
            {
                ViewModelLocator.ScoresListViewModel.AddNewScore(newScore);
                ViewModelLocator.ScoresListViewModel.ComputeGrade();
                ViewModelLocator.SelectedSubjectViewModel.SelectedActivity.Grade = ViewModelLocator.ScoresListViewModel.ComputeConvertedGrade();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModelLocator.ScoresListViewModel.SelectedScore != null)
            {
                var window = new AddScoreWindow();
                window.Owner = this;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                SCORE changedScore = ViewModelLocator.ScoresListViewModel.SelectedScore as SCORE;
                window.DataContext = changedScore;

                var result = window.ShowDialog();

                if (result == true)
                {
                    ViewModelLocator.ScoresListViewModel.EditScore(changedScore);
                    ViewModelLocator.ScoresListViewModel.ComputeGrade();
                    ViewModelLocator.SelectedSubjectViewModel.SelectedActivity.Grade = ViewModelLocator.ScoresListViewModel.ComputeConvertedGrade();
                }
            }
        }

        private void BtnRemoveActivity_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void LvActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LvActivities.SelectedItem != null)
            {
                ViewModelLocator.ScoresListViewModel.SelectedScore = LvActivities.SelectedItem as SCORE;
            }
        }
    }
}
