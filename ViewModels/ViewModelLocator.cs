using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMS.ViewModels
{
    public static class ViewModelLocator
    {
        private static MainWindowViewModel _mainWindowViewModel;
        private static SemesterSelectViewModel _semesterSelectViewModel;
        private static SubjectsListViewModel _subjectsListViewModel;
        private static SelectedSubjectViewModel _selectedSubjectViewModel;
        private static ScoresListViewModel _scoresListViewModel;
        private static GradesWindowViewModel _gradesWindowViewModel;

        public static GradesWindowViewModel GradesWindowViewModel
        {
            get
            {
                if (_gradesWindowViewModel == null)
                {
                    _gradesWindowViewModel = new GradesWindowViewModel();
                }
                return _gradesWindowViewModel;
            }
        }

        public static ScoresListViewModel ScoresListViewModel
        {
            get
            {
                if (_scoresListViewModel == null)
                {
                    _scoresListViewModel = new ScoresListViewModel();
                }
                return _scoresListViewModel;
            }
        }

        public static SelectedSubjectViewModel SelectedSubjectViewModel
        {
            get
            {
                if (_selectedSubjectViewModel == null)
                {
                    _selectedSubjectViewModel = new SelectedSubjectViewModel();
                }
                return _selectedSubjectViewModel;
            }
        }

        public static SubjectsListViewModel SubjectsListViewModel
        {
            get
            {
                if (_subjectsListViewModel == null)
                {
                    _subjectsListViewModel = new SubjectsListViewModel();
                }
                return _subjectsListViewModel;
            }
        }

        public static SemesterSelectViewModel SemesterSelectViewModel
        {
            get
            {
                if (_semesterSelectViewModel == null)
                {
                    _semesterSelectViewModel = new SemesterSelectViewModel();
                }
                return _semesterSelectViewModel;
            }
        }

        public static MainWindowViewModel MainWindowViewModel
        {
            get
            {
                if (_mainWindowViewModel == null)
                {
                    _mainWindowViewModel = new MainWindowViewModel();
                }
                return _mainWindowViewModel;
            }
        }
    }
}
