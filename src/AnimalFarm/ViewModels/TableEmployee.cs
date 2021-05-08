﻿using AnimalFarm.Models;
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
    class TableEmployee : BaseViewModel
    {

        public TableEmployee()
        {

            PostName = new ObservableCollection<string>(FarmContext._context.Posts.Select(x => x.Name));
            sellectedStatus = true;
            var gridEmployee = new ObservableCollection<Employee>(FarmContext._context.Employees.Include(x => x.Post));
            GridEmployee = CollectionViewSource.GetDefaultView(gridEmployee);

            CreateEmployee = new RelayCommand(obj =>
            {
                newEmployee = new() {FirstName=sellectedFirst, SecondName=sellectedSecond, Patronymic=sellectedPatronymic, Birthday=sellectedDay, Email=sellectedEmail, Phone=sellectedPhone, PostId=FarmContext._context.Posts.Where(x => x.Name == sellectedPost).FirstOrDefault().Id, IsWork=sellectedStatus };
                if ((FarmContext._context.Add(newEmployee)).State != EntityState.Added)
                    throw new DbUpdateException($"\"{newEmployee}\" не удалось сохранить.");

                if (FarmContext._context.SaveChanges() < 1)
                    throw new DbUpdateException($"\"{newEmployee}\" не удалось сохранить в Базу.");
                sellectedDay = null;
                sellectedEmail = null;
                sellectedFirst = null;
                sellectedPatronymic = null;
                sellectedPhone = null;
                sellectedPost = null;
                sellectedSecond = null;
                sellectedStatus = true;
                gridEmployee.Add(newEmployee);
                newEmployee = null;
            }, _ => {
                if (sellectedDay == null) return false;
                return sellectedDay > new DateTime(1900, 1, 1) && sellectedStatus != null && sellectedPost != null && sellectedFirst != null && sellectedSecond != null && sellectedPatronymic != null && sellectedPhone != null && sellectedEmail != null;
            });


            SosachParty = new RelayCommand(_ =>
            {
                if (GridEmployee.Filter == null)
                    GridEmployee.Filter = animal =>
                    {
                        var a = animal as Animal;
                        return a.IsMasculine ?? false;
                    };
                else GridEmployee.Filter = null;
            });
        }

        #region public field
        public string sellectedFirst { get; set; }
        public string sellectedSecond { get; set; }
        public string sellectedPatronymic { get; set; }
        public DateTime? sellectedDay { get; set; }
        public string sellectedPost { get; set; }
        public string sellectedEmail { get; set; }
        public string sellectedPhone { get; set; }
        public bool? sellectedStatus { get; set; }

        public Employee newEmployee;

        #endregion

        #region collections
        public ObservableCollection<string> PostName { get; set; }
        public ICollectionView GridEmployee { get; }

        #endregion

        #region Metods
        public RelayCommand SosachParty { get; }
        public RelayCommand CreateEmployee { get; }
        #endregion
    }
}