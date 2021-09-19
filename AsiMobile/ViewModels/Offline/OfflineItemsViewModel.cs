using Asi.Client.V2.Interfaces;
using Asi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AsiMobile.ViewModels.Offline
{
   public class OfflineItemsViewModel
    {
        private readonly IV2BusinessUnit _unit;

        public ObservableCollection<ItemModel> Items{ get; set; }

        public OfflineItemsViewModel()
        {
          _unit=  App.ServiceProvider.GetService(typeof(IV2BusinessUnit)) as IV2BusinessUnit;
            List<ItemModel> itemModels = _unit.Items.GetAll(0);
            itemModels.ForEach(x => Items.Add(x));
        }
    }
}
