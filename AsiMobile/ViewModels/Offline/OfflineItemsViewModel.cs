using Asi.Client.V2.Interfaces;
using Asi.Mobile.LocalData.Interface;
using Asi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AsiMobile.ViewModels.Offline
{
    public class OfflineItemsViewModel
    {
        private readonly ILocalData _localData;

        public ObservableCollection<ItemModel> Items { get; set; }

        public OfflineItemsViewModel()
        {
            _localData = App.ServiceProvider.GetService(typeof(ILocalData)) as ILocalData;
            List<ItemModel> itemModels = _localData.Items.GetAll();
            itemModels.ForEach(x => Items.Add(x));
        }
    }
}
