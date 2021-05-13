using AnimalFarm.Models;
using AnimalFarm.Models.Entities;
using AnimalFarm.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AnimalFarm.ViewModels
{
    class TableSpecies : BaseViewModel
    {

        public TableSpecies()
        {
            var gridSpecies = new ObservableCollection<Species>(FarmContext._context.Specieses);
            GridSpecies = CollectionViewSource.GetDefaultView(gridSpecies);

            CreateSpecies = new RelayCommand(obj =>
            {
                newSpecies = new() { Name = sellectedName };
                if ((FarmContext._context.Add(newSpecies)).State != EntityState.Added)
                    throw new DbUpdateException($"\"{newSpecies}\" не удалось сохранить.");

                if (FarmContext._context.SaveChanges() < 1)
                    throw new DbUpdateException($"\"{newSpecies}\" не удалось сохранить в Базу.");
                sellectedName = null;
                gridSpecies.Add(newSpecies);
                newSpecies = null;
            }, _ =>
            {
                return sellectedName != null;
            });


            SosachParty = new RelayCommand(_ =>
            {
                if (GridSpecies.Filter == null)
                    GridSpecies.Filter = animal =>
                    {
                        var a = animal as Animal;
                        return a.IsMasculine ?? false;
                    };
                else GridSpecies.Filter = null;
            });
        }

        #region public field
        public string sellectedName { get; set; }

        public Species newSpecies;

        #endregion

        #region collections
        public ICollectionView GridSpecies { get; }

        #endregion

        #region Metods
        public RelayCommand SosachParty { get; }
        public RelayCommand CreateSpecies { get; }
        #endregion
    }
}