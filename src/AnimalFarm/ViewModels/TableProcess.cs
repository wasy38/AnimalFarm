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
    class supportClass : BaseViewModel
    {
        public AnimalPlaceProcess needed_AnimalPlaceProcess { get; set; }
        public EmployeeProcess needed_EmployeeProcess { get; set; }
        public EquipmentProcess needed_EquipmentProcess { get; set; }
        public FeedProcess needed_FeedProcess { get; set; }
    }

    class TableProcess : BaseViewModel
    {
        public TableProcess()
        {
            var _AnimalPlacesProcess = new ObservableCollection<AnimalPlaceProcess>(FarmContext._context.AnimalPlaceProcesses.Include(x => x.AnimalPlace).Include(x => x.Process));
            var _EmployeeProcess = new ObservableCollection<EmployeeProcess>(FarmContext._context.EmployeeProcesses.Include(x => x.Employee).Include(x => x.Process));
            var _EquipmentProcess = new ObservableCollection<EquipmentProcess>(FarmContext._context.EquipmentProcesses.Include(x => x.Equipment).Include(x => x.Process));
            var _FeedProcess = new ObservableCollection<FeedProcess>(FarmContext._context.FeedProcesses.Include(x => x.Feed).Include(x => x.Process));
            _Process = new ObservableCollection<Process>(FarmContext._context.Processes);
            _Employee = new ObservableCollection<Employee>(FarmContext._context.Employees);
            _Equipment = new ObservableCollection<Equipment>(FarmContext._context.Equipments);
            _Feed = new ObservableCollection<Feed>(FarmContext._context.Feeds);
            _AnimalPlace = new ObservableCollection<AnimalPlace>(FarmContext._context.AnimalPlaces.Include(x => x.Place).Include(x => x.Animal));

            var grid = from AnimalPlaceProcess in FarmContext._context.AnimalPlaceProcesses
                       join EmployeeProcess in FarmContext._context.EmployeeProcesses on new { AnimalPlaceProcess.Process, AnimalPlaceProcess.Date } equals new { EmployeeProcess.Process, EmployeeProcess.Date } into a
                       from EmployeeProcess in a.DefaultIfEmpty()
                       join EquipmentProcess in FarmContext._context.EquipmentProcesses on new { AnimalPlaceProcess.Process, AnimalPlaceProcess.Date } equals new { EquipmentProcess.Process, EquipmentProcess.Date } into b
                       from EquipmentProcess in b.DefaultIfEmpty()
                       join FeedProcess in FarmContext._context.FeedProcesses on new { AnimalPlaceProcess.Process, AnimalPlaceProcess.Date } equals new { FeedProcess.Process, FeedProcess.Date } into c
                       from FeedProcess in c.DefaultIfEmpty()
                       select new supportClass
                       {
                           needed_EmployeeProcess = EmployeeProcess,
                           needed_AnimalPlaceProcess = AnimalPlaceProcess,
                           needed_EquipmentProcess = EquipmentProcess,
                           needed_FeedProcess = FeedProcess
                       };
            supportCollection = new ObservableCollection<supportClass>(grid);

            CreateProcess = new RelayCommand(obj =>
            {
                DateTime nowDate = DateTime.Now;
                if (sellectedEmploy != null)
                {
                    newEmployeeProcess = new() { Date= nowDate, Employee=sellectedEmploy, Process= sellectedProcess, EmployeeId=sellectedEmploy.Id, ProcessId=sellectedProcess.Id};
                    if ((FarmContext._context.Add(newEmployeeProcess)).State != EntityState.Added)
                        throw new DbUpdateException($"\"{newEmployeeProcess}\" не удалось сохранить.");

                    if (FarmContext._context.SaveChanges() < 1)
                        throw new DbUpdateException($"\"{newEmployeeProcess}\" не удалось сохранить в Базу.");
                }
                if (sellectedEquipment != null)
                {
                    newEquipmentProcess = new() { Date = nowDate, Equipment = sellectedEquipment, Process = sellectedProcess, EquipmentId = sellectedEquipment.Id, ProcessId = sellectedProcess.Id };
                    if ((FarmContext._context.Add(newEquipmentProcess)).State != EntityState.Added)
                        throw new DbUpdateException($"\"{newEquipmentProcess}\" не удалось сохранить.");

                    if (FarmContext._context.SaveChanges() < 1)
                        throw new DbUpdateException($"\"{newEquipmentProcess}\" не удалось сохранить в Базу.");
                }
                if (sellectedFeed != null)
                {
                    newFeedProcess = new() { Date = nowDate, Feed = sellectedFeed, Process = sellectedProcess, FeedId = sellectedFeed.Id, ProcessId = sellectedProcess.Id };
                    if ((FarmContext._context.Add(newFeedProcess)).State != EntityState.Added)
                        throw new DbUpdateException($"\"{newFeedProcess}\" не удалось сохранить.");

                    if (FarmContext._context.SaveChanges() < 1)
                        throw new DbUpdateException($"\"{newFeedProcess}\" не удалось сохранить в Базу.");
                }
                if (sellectedAnimalPlace != null)
                {
                    newAnimalPlaceProcess = new() { Date = nowDate, AnimalPlace = sellectedAnimalPlace, Process = sellectedProcess, AnimalPlaceId = sellectedAnimalPlace.Id, ProcessId = sellectedProcess.Id };
                    if ((FarmContext._context.Add(newAnimalPlaceProcess)).State != EntityState.Added)
                        throw new DbUpdateException($"\"{newAnimalPlaceProcess}\" не удалось сохранить.");

                    if (FarmContext._context.SaveChanges() < 1)
                        throw new DbUpdateException($"\"{newAnimalPlaceProcess}\" не удалось сохранить в Базу.");
                }
            }, _ =>
            {
                return sellectedProcess!=null && (sellectedAnimalPlace!=null || sellectedEmploy!=null || sellectedEquipment != null || sellectedFeed!=null);
            });


            SosachParty = new RelayCommand(_ =>
            {
                //if (GridAnimalPlace.Filter == null)
                //    GridAnimalPlace.Filter = animal =>
                //    {
                //        var a = animal as Animal;
                //        return a.IsMasculine ?? false;
                //    };
                //else GridAnimalPlace.Filter = null;
            });

        }

        #region public field

        public EmployeeProcess newEmployeeProcess { get; set; }
        public EquipmentProcess newEquipmentProcess { get; set; }
        public FeedProcess newFeedProcess { get; set; }
        public AnimalPlaceProcess newAnimalPlaceProcess { get; set; }
        public AnimalPlace sellectedAnimalPlace { get; set; }
        public Feed sellectedFeed { get; set; }
        public Equipment sellectedEquipment { get; set; }
        public Employee sellectedEmploy { get; set; }
        public Process sellectedProcess { get; set; }

        #endregion

        #region Collections

        public ObservableCollection<AnimalPlace> _AnimalPlace { get; set; }
        public ObservableCollection<Feed> _Feed { get; set; }
        public ObservableCollection<Equipment> _Equipment { get; set; }
        public ObservableCollection<Employee> _Employee { get; set; }
        public ObservableCollection<Process> _Process { get; set; }
        public ObservableCollection<supportClass> supportCollection { get; set; }

        #endregion


        #region Metods

        public RelayCommand SosachParty { get; }
        public RelayCommand CreateProcess { get; }

        #endregion
    }
}
