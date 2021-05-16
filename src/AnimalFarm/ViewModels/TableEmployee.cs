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
                    GridEmployee.Filter = employee =>
                    {
                        var e = employee as Employee;
                        return ((firstDate == default) ? true : e.Birthday >= firstDate) &&
                        ((secondDate == default) ? true : e.Birthday <= secondDate) &&
                        (findPost == null ? true : (e.PostId == FarmContext._context.Places.Where(x => x.Name == findPost).FirstOrDefault().Id)) &&
                        (findStatus == null ? true : (e.IsWork == findStatus))&&
                        (findFName == null ? true : (e.FirstName == findFName)) &&
                        (findSName == null ? true : (e.SecondName == findSName)) &&
                        (findPan == null ? true : (e.Patronymic == findPan));
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

        //
        public DateTime? firstDate { get; set; }
        public DateTime? secondDate { get; set; }
        public bool? findStatus { get; set; }
        public string findPost { get; set; }
        public string findFName { get; set; }
        public string findSName { get; set; }
        public string findPan { get; set; }

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
