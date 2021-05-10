using AnimalFarm.Models;
using AnimalFarm.Models.Entities;
using AnimalFarm.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace AnimalFarm.ViewModels
{
    class TableAnimals : BaseViewModel
    {

        public TableAnimals()
        {

            SpeciesName = new ObservableCollection<string>(FarmContext._context.Specieses.Select(x => x.Name));
            sellectedSex = true;
            var gridAnimals = new ObservableCollection<Animal>(FarmContext._context.Animals.Include(x => x.Species));
            GridAnimals = CollectionViewSource.GetDefaultView(gridAnimals);

            CreateAnimal = new RelayCommand(obj =>
            {
                newAnimal = new() { Birthday = sellectedDay, SpeciesId = FarmContext._context.Specieses.Where(x => x.Name == SellectedSpecies).FirstOrDefault().Id, IsMasculine = sellectedSex };
                //Add animal
                if ((FarmContext._context.Add(newAnimal)).State != EntityState.Added)
                    throw new DbUpdateException($"\"{newAnimal}\" не удалось сохранить.");
                if (FarmContext._context.SaveChanges() < 1)
                    throw new DbUpdateException($"\"{newAnimal}\" не удалось сохранить в Базу.");
                //
                sellectedDay = null;
                SellectedSpecies = null;
                sellectedSex = true;
                gridAnimals.Add(newAnimal);
                newAnimal = null;
            }, _ => {
                if (sellectedDay == null) return false;
                return sellectedDay > new DateTime(1990, 1, 1) && sellectedSex != null && SellectedSpecies != null;
            });


            SosachParty = new RelayCommand(_ =>
            {
                if (GridAnimals.Filter == null)
                    GridAnimals.Filter = animal =>
                    {
                        var a = animal as Animal;
                        return a.IsMasculine ?? false;
                    };
                else GridAnimals.Filter = null;
            });
        }

        #region public field
        public DateTime? sellectedDay { get; set; }
        public bool? sellectedSex { get; set; }
        
        public Animal newAnimal;
        public string SellectedSpecies { get;set; }

        #endregion

        #region collections
        public ObservableCollection<string> SpeciesName { get; set; }
        public ICollectionView GridAnimals { get; }

        #endregion

        #region Metods
        public RelayCommand SosachParty { get; }
        public RelayCommand CreateAnimal { get; }
        #endregion
    }
}
