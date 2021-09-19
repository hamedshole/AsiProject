using Asi.Mobile.Application.Interfaces;
using Asi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AsiMobile.ViewModels.Offline
{
  public  class LinkViewModel
    {
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public ObservableCollection<LinkModel> Links{ get; set; }
        public Command AddLink{ get; set; }
        IApplicationUnit _unit;
        public LinkViewModel()
        {
            _unit = App.ServiceProvider.GetService(typeof(IApplicationUnit)) as IApplicationUnit;
            Links = new ObservableCollection<LinkModel>();
            List<LinkModel> linkModels =Task.Run(async()=>await _unit.Links.GetAll(0)).Result;
            linkModels.ForEach(x => Links.Add(x));
            AddLink = new Command(AddLinkMethod);
        }

        private async void AddLinkMethod(object obj)
        {
            LinkModel link = new LinkModel()
            {
                Fullname = this.Fullname,
                PhoneNumber = this.PhoneNumber
            };
           await _unit.Links.Create(link);
            List<LinkModel> linkModels = Task.Run(async () => await _unit.Links.GetAll(0)).Result;
            linkModels.Clear();
            linkModels.ForEach(x => Links.Add(x));

        }
    }
}
