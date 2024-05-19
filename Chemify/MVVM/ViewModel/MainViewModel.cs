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
        public RelayCommand ChemBotViewCommand {  get; set; }
        public RelayCommand AtomulViewCommand { get; set; }
        public RelayCommand Quiz1ViewCommand { get; set; }
        public RelayCommand InvelisulDeElectroniViewCommand { get; set; }
        public RelayCommand Quiz2ViewCommand { get; set; }
        public ChemBotViewModel chembotVM { get; set; }
        public Lectia1ViewModel lectia1VM{ get; set; }
        public Quiz1ViewModel quiz1VM { get; set; }
        public InvelisulDeElectroniViewModel invelisVM { get; set; }
        public Quiz2ViewModel quiz2VM { get; set; }

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
            chembotVM = new ChemBotViewModel();
            lectia1VM = new Lectia1ViewModel();
            quiz1VM = new Quiz1ViewModel();
            quiz2VM = new Quiz2ViewModel();
            invelisVM= new InvelisulDeElectroniViewModel();

            CurrentView = chembotVM;

            ChemBotViewCommand = new RelayCommand(o => 
            { 
                CurrentView= chembotVM;
            });
            AtomulViewCommand = new RelayCommand(o =>
            {
                CurrentView = lectia1VM;
            });
            Quiz1ViewCommand = new RelayCommand(o =>
            {
                CurrentView = quiz1VM;
            });
            InvelisulDeElectroniViewCommand = new RelayCommand(o =>
            {
                CurrentView = invelisVM;
            });
            Quiz2ViewCommand = new RelayCommand(o =>
            {
                CurrentView = quiz2VM;
            });
        }
    }
}
