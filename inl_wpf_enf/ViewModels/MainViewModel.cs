using inl_wpf_enf.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inl_wpf_enf.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        //ta hand om att byta vyerna
        private object _currentView;

        public MainViewModel()
        {
            CostumerViewModel = new CostumerViewModel();
            NewCostumerViewModel = new NewCostumerViewModel();
            ErrandViewModel = new ErrandViewModel();
            NewErrandViewModel= new NewErrendViewModel();
            UpdateErrandViewModel = new UpdateErrandViewModel();

            CurrentView = CostumerViewModel; //vad applikationen ska starta på vid start

            CostumerViewCommand = new RelayCommand(x => CurrentView = CostumerViewModel);
            NewCostumerViewCommand = new RelayCommand(x => CurrentView = NewCostumerViewModel);

            ErrandViewCommand = new RelayCommand(x => CurrentView = ErrandViewModel);
            NewErrandViewCommand = new RelayCommand(x => CurrentView = NewErrandViewModel);
            UpdateErrandViewCommand = new RelayCommand(x => CurrentView = UpdateErrandViewModel);
        }
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanges();
            }
        }

        //Gör dett för alla vyer vi kommer ha!
        public RelayCommand CostumerViewCommand { get; set; }
        public CostumerViewModel CostumerViewModel { get; set; }


        public RelayCommand NewCostumerViewCommand { get; set; }
        public NewCostumerViewModel NewCostumerViewModel { get; set; }

        public RelayCommand ErrandViewCommand { get; set; }
        public ErrandViewModel ErrandViewModel { get; set; }


        public RelayCommand NewErrandViewCommand { get; set; }
        public NewErrendViewModel NewErrandViewModel { get; set; }

        public RelayCommand UpdateErrandViewCommand { get; set; }
        public UpdateErrandViewModel UpdateErrandViewModel { get; set; }


       

    }
}
