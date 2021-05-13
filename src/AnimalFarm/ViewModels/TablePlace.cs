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
    class TablePlace : BaseViewModel
    {

        public TablePlace()
        {
            var gridPlace = new ObservableCollection<Place>(FarmContext._context.Places);
            GridPlace = CollectionViewSource.GetDefaultView(gridPlace);

            CreatePlace = new RelayCommand(obj =>
            {
                newPlace = new() { Name = sellectedName };
                if ((FarmContext._context.Add(newPlace)).State != EntityState.Added)
                    throw new DbUpdateException($"\"{newPlace}\" не удалось сохранить.");

                if (FarmContext._context.SaveChanges() < 1)
                    throw new DbUpdateException($"\"{newPlace}\" не удалось сохранить в Базу.");
                sellectedName = null;
                gridPlace.Add(newPlace);
                newPlace = null;
            }, _ =>
            {
                return sellectedName != null;
            });


            SosachParty = new RelayCommand(_ =>
            {
                if (GridPlace.Filter == null)
                    GridPlace.Filter = animal =>
                    {
                        var a = animal as Animal;
                        return a.IsMasculine ?? false;
                    };
                else GridPlace.Filter = null;
            });
        }

        #region public field
        public string sellectedName { get; set; }

        public Place newPlace;

        #endregion

        #region collections
        public ICollectionView GridPlace { get; }

        #endregion

        #region Metods
        public RelayCommand SosachParty { get; }
        public RelayCommand CreatePlace { get; }
        #endregion
    }
}