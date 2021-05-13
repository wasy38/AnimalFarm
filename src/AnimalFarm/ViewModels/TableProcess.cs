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
        //public AnimalPlaceProcess APP { get; set; }
        //public EmployeeProcess EP { get; set; }
        //public EquipmentProcess EQP { get; set; }
        //public FeedProcess FP { get; set; }

        public int AnimalId { get; set; }
        public int PlaceId { get; set; }
        public DateTime Date { get; set; }
        public int ProcessId { get; set; }
        

    }

    class TableProcess : BaseViewModel
    {
        public TableProcess()
        {

            var grid = from AnimalPlaceProcess in FarmContext._context.AnimalPlaceProcesses
                       join AnimalPlace in FarmContext._context.AnimalPlaces on AnimalPlaceProcess.AnimalPlaceId equals AnimalPlace.Id
                       join Process in FarmContext._context.Processes on AnimalPlaceProcess.ProcessId equals Process.Id
                       select new supportClass
                       {
                           AnimalId = AnimalPlace.AnimalId,
                           PlaceId = AnimalPlace.PlaceId,
                           Date = AnimalPlaceProcess.Date,
                           ProcessId = Process.Id
                       };
            supportCollection = new ObservableCollection<supportClass>(grid);

            //foreach (var app in FarmContext._context.AnimalPlaceProcesses)
            //{
            //    app.AnimalPlace = FarmContext._context.AnimalPlaces.Find(app.AnimalPlaceId);
            //    app.Process = FarmContext._context.Processes.Find(app.ProcessId);
            //}
            //foreach (var ep in FarmContext._context.EmployeeProcesses)
            //{
            //    ep.Employee = FarmContext._context.Employees.Find(ep.EmployeeId);
            //    ep.Process = FarmContext._context.Processes.Find(ep.ProcessId);
            //}
            //foreach (var eqp in FarmContext._context.EquipmentProcesses)
            //{
            //    eqp.Equipment = FarmContext._context.Equipments.Find(eqp.EquipmentId);
            //    eqp.Process = FarmContext._context.Processes.Find(eqp.ProcessId);
            //}
            //foreach (var fp in FarmContext._context.FeedProcesses)
            //{
            //    fp.Feed = FarmContext._context.Feeds.Find(fp.FeedId);
            //    fp.Process = FarmContext._context.Processes.Find(fp.ProcessId);
            //}

        }

        #region collections

        public ObservableCollection<supportClass> supportCollection { get; set; }      

        #endregion

    }
}
