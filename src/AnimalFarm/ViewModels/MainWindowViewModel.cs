using System.Collections.ObjectModel;
using System.Windows.Controls;
using AnimalFarm.Models.Entities;

namespace AnimalFarm.ViewModels

{
    class MainWindowViewModel: Base.BaseViewModel
    {
        public MainWindowViewModel()
        {

            CloseFrame = new RelayCommand(_=>
            {
                CurrentTable = null;
                TableCreate = null;
                Value = 0;
            });

            RefreshFrame = new RelayCommand(_=>
            {
                CurrentTable = null;
                switch (Value)
                {
                    case 1:
                        CurrentTable = new Views.TableAnimals();
                        break;
                    case 2:
                        CurrentTable = new Views.TableEmployee();
                        break;
                    case 3:
                        CurrentTable = new Views.TableEquipment();
                        break;
                    case 4:
                        CurrentTable = new Views.TableAnimalPlace();
                        break;

                }
            });

            OpenFrame = new RelayCommand(obj =>
            {
                switch (obj as string)
                {
                    case "1":
                        Value = 1;
                        CurrentTable = new Views.TableAnimals();
                        TableCreate = new Views.AddAnimal();
                        break;
                    case "2":
                        Value = 2;
                        CurrentTable = new Views.TableEmployee();
                        TableCreate = new Views.AddEmployee();
                        break;
                    case "3":
                        Value = 3;
                        CurrentTable = new Views.TableEquipment();
                        TableCreate = new Views.AddEquipment();
                        break;
                    case "4":
                        Value = 4;
                        CurrentTable = new Views.TableAnimalPlace();
                        TableCreate = new Views.AddAnimalPlace();
                        break;
                }

            });
        }

        #region Metods
        public RelayCommand OpenFrame { get; }
        public RelayCommand CloseFrame { get; }
        public RelayCommand RefreshFrame { get; }
        #endregion

        int Value = 0;
        public UserControl CurrentTable { get; set; }
        public UserControl TableCreate { get; set; }
    }
}
