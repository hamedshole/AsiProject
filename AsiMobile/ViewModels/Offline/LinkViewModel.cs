using Asi.Mobile.LocalData.Interface;
using Asi.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AsiMobile.ViewModels.Offline
{
    public class LinkViewModel
    {
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public ObservableCollection<LinkModel> Links { get; set; }
        public Command AddLink { get; set; }
        ILocalData _unit;
        public LinkViewModel()
        {
            _unit = App.ServiceProvider.GetService(typeof(ILocalData)) as ILocalData;
            Links = new ObservableCollection<LinkModel>();
            List<LinkModel> linkModels = _unit.Links.GetAll();
            linkModels.ForEach(x => Links.Add(x));
            AddLink = new Command(AddLinkMethod);
        }

        private void AddLinkMethod(object obj)
        {
            LinkModel link = new LinkModel()
            {
                Fullname = this.Fullname,
                PhoneNumber = this.PhoneNumber
            };
            _unit.Links.Create(link);
            List<LinkModel> linkModels = _unit.Links.GetAll();
            linkModels.Clear();
            linkModels.ForEach(x => Links.Add(x));

        }
    }
}
