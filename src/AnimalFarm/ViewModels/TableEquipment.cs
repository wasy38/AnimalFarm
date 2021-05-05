using AnimalFarm.Models;
using AnimalFarm.Models.Entities;
using AnimalFarm.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace AnimalFarm.ViewModels
{
    class TableEquipment : BaseViewModel
        {

            public TableEquipment()
            {
                var gridEquipment = new ObservableCollection<Equipment>(FarmContext._context.Equipments);
                GridEquipment = CollectionViewSource.GetDefaultView(gridEquipment);

                CreateEquipment = new RelayCommand(obj =>
                {
                    newEquipment = new() { Name=sellectedName };
                    if ((FarmContext._context.Add(newEquipment)).State != EntityState.Added)
                        throw new DbUpdateException($"\"{newEquipment}\" не удалось сохранить.");

                    if (FarmContext._context.SaveChanges() < 1)
                        throw new DbUpdateException($"\"{newEquipment}\" не удалось сохранить в Базу.");
                    sellectedName = null;
                    gridEquipment.Add(newEquipment);
                    newEquipment = null;
                }, _ =>
                {
                    return sellectedName!=null;
                });


                SosachParty = new RelayCommand(_ =>
                {
                    if (GridEquipment.Filter == null)
                        GridEquipment.Filter = animal =>
                        {
                            var a = animal as Animal;
                            return a.IsMasculine ?? false;
                        };
                    else GridEquipment.Filter = null;
                });
            }

            #region public field
            public string sellectedName { get; set; }

        public Equipment newEquipment;

            #endregion

            #region collections
            public ICollectionView GridEquipment { get; }

            #endregion

            #region Metods
            public RelayCommand SosachParty { get; }
            public RelayCommand CreateEquipment { get; }
            #endregion
        }
}
