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

            _context = new FarmContext();
            SpeciesName = new ObservableCollection<string>(_context.Specieses.Select(x => x.Name));
            newAnimal.IsMasculine = true;
            var gridAnimals = new ObservableCollection<Animal>(_context.Animals.Include(x => x.Species));
            GridAnimals = CollectionViewSource.GetDefaultView(gridAnimals);

            CreateAnimal = new RelayCommand(obj =>
            {
                newAnimal.SpeciesId = _context.Specieses.Where(x => x.Name == SellectedSpecies).FirstOrDefault().Id;          
                if ((_context.Add(newAnimal)).State != EntityState.Added)
                    throw new DbUpdateException($"\"{newAnimal}\" не удалось сохранить.");

                if (_context.SaveChanges() < 1)
                    throw new DbUpdateException($"\"{newAnimal}\" не удалось сохранить в Базу.");
                newAnimal = null;
                gridAnimals.Add(newAnimal);
             },_=> {
                 if (newAnimal.Birthday == null) return false;
                return newAnimal.Birthday > new DateTime(1990, 1, 1) && newAnimal.IsMasculine != null && SellectedSpecies != null; 
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

        public Animal newAnimal = new Animal();
        public string SellectedSpecies
        {
            get;set;
        }

        #endregion

        #region collections
        public ObservableCollection<bool> SexName { get; set; }
        public ObservableCollection<string> SpeciesName { get; set; }
        public ICollectionView GridAnimals { get; }

        #endregion

        #region private field
        private FarmContext _context;
        #endregion

        #region Metods
        public RelayCommand SosachParty { get; }
        public RelayCommand CreateAnimal { get; }
        #endregion
    }
}
