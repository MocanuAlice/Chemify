using Chemify.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Chemify.MVVM.ViewModel
{
    class MainViewModel:ObservableObject
    {
        public RelayCommand PeriodicTableViewCommand {  get; set; }
        public RelayCommand AtomulViewCommand { get; set; }
        public RelayCommand Quiz1ViewCommand { get; set; }
        public RelayCommand InvelisulDeElectroniCommand { get; set; }
        public PeriodicTableViewModel periodicVM { get; set; }
        public Lectia1ViewModel lectia1VM{ get; set; }
        public Quiz1ViewModel quiz1VM { get; set; }
        public InvelisulDeElectroniViewModel invelisVM { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set 
            {   _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            periodicVM = new PeriodicTableViewModel();
            lectia1VM = new Lectia1ViewModel();
            quiz1VM = new Quiz1ViewModel();

            CurrentView = periodicVM;

            PeriodicTableViewCommand = new RelayCommand(o => 
            { 
                CurrentView= periodicVM;
            });
            AtomulViewCommand = new RelayCommand(o =>
            {
                CurrentView = lectia1VM;
            });
            Quiz1ViewCommand = new RelayCommand(o =>
            {
                CurrentView = quiz1VM;
            });
            Quiz1ViewCommand = new RelayCommand(o =>
            {
                CurrentView = invelisVM;
            });
        }
    }
}
