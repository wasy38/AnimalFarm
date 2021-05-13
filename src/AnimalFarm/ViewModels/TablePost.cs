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
    class TablePost : BaseViewModel
    {

        public TablePost()
        {
            var gridPost = new ObservableCollection<Post>(FarmContext._context.Posts);
            GridPost = CollectionViewSource.GetDefaultView(gridPost);

            CreatePost = new RelayCommand(obj =>
            {
                newPost = new() { Name = sellectedName };
                if ((FarmContext._context.Add(newPost)).State != EntityState.Added)
                    throw new DbUpdateException($"\"{newPost}\" не удалось сохранить.");

                if (FarmContext._context.SaveChanges() < 1)
                    throw new DbUpdateException($"\"{newPost}\" не удалось сохранить в Базу.");
                sellectedName = null;
                gridPost.Add(newPost);
                newPost = null;
            }, _ =>
            {
                return sellectedName != null;
            });


            SosachParty = new RelayCommand(_ =>
            {
                if (GridPost.Filter == null)
                    GridPost.Filter = animal =>
                    {
                        var a = animal as Animal;
                        return a.IsMasculine ?? false;
                    };
                else GridPost.Filter = null;
            });
        }

        #region public field
        public string sellectedName { get; set; }

        public Post newPost;

        #endregion

        #region collections
        public ICollectionView GridPost { get; }

        #endregion

        #region Metods
        public RelayCommand SosachParty { get; }
        public RelayCommand CreatePost { get; }
        #endregion
    }
}