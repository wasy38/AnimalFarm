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
    class TableProc : BaseViewModel
    {

        public TableProc()
        {
            var gridPost = new ObservableCollection<Process>(FarmContext._context.Processes);
            GridProc = CollectionViewSource.GetDefaultView(gridPost);

            CreateProc = new RelayCommand(obj =>
            {
                newProc = new() { Name = sellectedName };
                if ((FarmContext._context.Add(newProc)).State != EntityState.Added)
                    throw new DbUpdateException($"\"{newProc}\" не удалось сохранить.");

                if (FarmContext._context.SaveChanges() < 1)
                    throw new DbUpdateException($"\"{newProc}\" не удалось сохранить в Базу.");
                sellectedName = null;
                gridPost.Add(newProc);
                newProc = null;
            }, _ =>
            {
                return sellectedName != null;
            });
        }

        #region public field
        public string sellectedName { get; set; }

        public Process newProc;

        #endregion

        #region collections
        public ICollectionView GridProc { get; }

        #endregion

        #region Metods
        public RelayCommand CreateProc { get; }
        #endregion
    }
}