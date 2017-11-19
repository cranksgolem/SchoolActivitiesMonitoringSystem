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

namespace I_Need_That_A
{
    /// <summary>
    /// Interaction logic for ComponentWindow.xaml
    /// </summary>
    public partial class ComponentWindow : Window
    {
        public ComponentWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAddActivity_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.StartMenuViewModel.AddNewGradedActivity();
            ViewModelLocator.StartMenuViewModel.GetTotalItemsActivity();
            ViewModelLocator.StartMenuViewModel.GetTotalScoreActivity();
            ViewModelLocator.StartMenuViewModel.GetComponentFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetConvertedGrade();
            ViewModelLocator.StartMenuViewModel.GetGradingPeriodGrade();
            ViewModelLocator.StartMenuViewModel.GetLetterGrade();
            ViewModelLocator.StartMenuViewModel.GetFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
            ViewModelLocator.StartMenuViewModel.GetQPIComponent();
            ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
        }

        private void BtnRemoveActivity_Click(object sender, RoutedEventArgs e)
        {
            if (LvActivities.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.RemoveGradedActivity();
                ViewModelLocator.StartMenuViewModel.GetTotalItemsActivity();
                ViewModelLocator.StartMenuViewModel.GetTotalScoreActivity();
                ViewModelLocator.StartMenuViewModel.GetComponentFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetConvertedGrade();
                ViewModelLocator.StartMenuViewModel.GetGradingPeriodGrade();
                ViewModelLocator.StartMenuViewModel.GetLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetQPIComponent();
                ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvActivities.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.EditGradedActivity();
                ViewModelLocator.StartMenuViewModel.GetTotalItemsActivity();
                ViewModelLocator.StartMenuViewModel.GetTotalScoreActivity();
                ViewModelLocator.StartMenuViewModel.GetComponentFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetConvertedGrade();
                ViewModelLocator.StartMenuViewModel.GetGradingPeriodGrade();
                ViewModelLocator.StartMenuViewModel.GetLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetQPIComponent();
                ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
            }
        }
    }
}
