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
            var _Places = new ObservableCollection<AnimalPlace>(FarmContext._context.AnimalPlaces.Include(x => x.Place).Include(x => x.Animal));
            var _AnimalPlaces = new ObservableCollection<AnimalPlaceProcess>(FarmContext._context.AnimalPlaceProcesses.Include(x => x.AnimalPlace).Include(x => x.Process));
            var _Employee = new ObservableCollection<EmployeeProcess>(FarmContext._context.EmployeeProcesses.Include(x => x.Employee).Include(x => x.Process));
            var _Equipment = new ObservableCollection<EquipmentProcess>(FarmContext._context.EquipmentProcesses.Include(x => x.Equipment).Include(x => x.Process));
            var _Feed = new ObservableCollection<FeedProcess>(FarmContext._context.FeedProcesses.Include(x => x.Feed).Include(x => x.Process));

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

           

        }

        #region collections


        public ObservableCollection<supportClass> supportCollection { get; set; }      

        #endregion

    }
}
