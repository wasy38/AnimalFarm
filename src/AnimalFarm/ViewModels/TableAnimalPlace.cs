using AnimalFarm.Models;
using AnimalFarm.Models.Entities;
using AnimalFarm.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace AnimalFarm.ViewModels
{
    class TableAnimalPlace : BaseViewModel
    {

        public TableAnimalPlace()
        {
            PlaceName = new ObservableCollection<string>(FarmContext._context.Places.Select(x => x.Name));
            IdAnimal = new ObservableCollection<int>(FarmContext._context.Animals.Select(x => x.Id));
            var gridAnimalPlace = new ObservableCollection<AnimalPlace>(FarmContext._context.AnimalPlaces);
            GridAnimalPlace = CollectionViewSource.GetDefaultView(gridAnimalPlace);

            CreateAnimalPlace = new RelayCommand(obj =>
            {
                newAnimalPlace = new() { };
                if ((FarmContext._context.Add(newAnimalPlace)).State != EntityState.Added)
                    throw new DbUpdateException($"\"{newAnimalPlace}\" не удалось сохранить.");

                if (FarmContext._context.SaveChanges() < 1)
                    throw new DbUpdateException($"\"{newAnimalPlace}\" не удалось сохранить в Базу.");
                // = sellectedName null;
                gridAnimalPlace.Add(newAnimalPlace);
                newAnimalPlace = null;
            }, _ =>
            {
                return true; //sellectedName != null;
            });


            SosachParty = new RelayCommand(_ =>
            {
                if (GridAnimalPlace.Filter == null)
                    GridAnimalPlace.Filter = animal =>
                    {
                        var a = animal as Animal;
                        return a.IsMasculine ?? false;
                    };
                else GridAnimalPlace.Filter = null;
            });
        }

        #region public field

        public AnimalPlace newAnimalPlace;
        public string sellectedPlace { get; set; }
        public int sellectedAnimal {get;set;}

        #endregion

        #region collections

        public ICollectionView GridAnimalPlace { get; }
        public ObservableCollection<string> PlaceName { get; set; }
        public ObservableCollection<int> IdAnimal { get; set; }

        #endregion

        #region Metods
        public RelayCommand SosachParty { get; }
        public RelayCommand CreateAnimalPlace { get; }
        #endregion
    }
}
