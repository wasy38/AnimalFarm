using System.Collections.ObjectModel;
using System.Windows.Controls;
using AnimalFarm.Models.Entities;

namespace AnimalFarm.ViewModels

{
    class MainWindowViewModel: Base.BaseViewModel
    {
        public MainWindowViewModel()
        {

            CloseFrame = new RelayCommand(obj=>
            {
                CurrentTable = null;
                TableCreate = null;
            });

            OpenFrame = new RelayCommand(obj =>
            {
                switch (obj as string)
                {
                    case "1":
                        CurrentTable = new Views.TableAnimals();
                        TableCreate = new Views.AddAnimal();
                        break;
                    case "2":
                        CurrentTable = new Views.TableEmployee();
                        TableCreate = new Views.AddEmployee();
                        break;

                }

            });
        }
        #region Metods
        public RelayCommand OpenFrame { get; }
        public RelayCommand CloseFrame { get; }
        #endregion
        public UserControl CurrentTable { get; set; }
        public UserControl TableCreate { get; set; }
    }
}
