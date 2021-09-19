using AsiMobile.Views.Offline;
using Syncfusion.SfGauge.XForms;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AsiMobile.ViewModels.Offline
{
    public class DashboardViewModel
    {
        public ObservableCollection<Pointer> Pointers { get; set; }
        public Command ItemsPage { get; private set; }
        public Command CertificatesPage { get; private set; }
        public Command CompaniesPage { get; private set; }
        public Command LinksPage { get; private set; }
        public double ScaleEndValue { get; set; }
        private double ScaleStart = 0;
        public DashboardViewModel()
        {
            ItemsPage = new Command(GoToItemsPageMethod);
            CompaniesPage = new Command(GoToCompaniesPage);
            LinksPage = new Command(GoToLInksPage);
            CertificatesPage = new Command(GoToCertificatesPage);
            var ranges = new ObservableCollection<Pointer>();
           // Pointer
            RangePointer range = new RangePointer()
            {
               // RangeStart = ScaleStart,
                Value = 25,
                Offset = 1,
                Thickness = 12,
                EnableAnimation = true,
                Color = Color.Red,
            };
            RangePointer range1 = new RangePointer()
            {
              
                RangeStart = 25,
                Value = 50,
                Offset = 1,
                Thickness = 12,
                EnableAnimation = true,
                Color = Color.Green,
            };
            RangePointer range2 = new RangePointer()
            {
                RangeStart = 50,
                Value = 75,
                Offset = 1,
                Thickness = 12,
                EnableAnimation = true,
                Color = Color.HotPink,
            };
            RangePointer range3 = new RangePointer()
            {
                RangeStart = 75,
                Value = 100,
                Offset = 1,
                Thickness = 12,
                EnableAnimation = true,
                Color = Color.Yellow,
            };
            this.ScaleEndValue = 100;
            ranges.Add(range);
            ranges.Add(range1);
            ranges.Add(range2);
            ranges.Add(range3);
            this.Pointers = ranges;
            //Pointers = new ObservableCollection<Pointer>
            //{
            //    new Pointer
            //    {
            //        Color=Color.Red,
            //        Value=25
            //    },
            //    new Pointer
            //    {
            //        Color=Color.Red,
            //        Value=25
            //    }, new Pointer
            //    {
            //        Color=Color.Red,
            //        Value=25
            //    }, new Pointer
            //    {
            //        Color=Color.Red,
            //        Value=25
            //    }
            //};
            ScaleEndValue = 100;
        }

        private void GoToCertificatesPage(object obj)
        {
            throw new NotImplementedException();
        }

        private void GoToLInksPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new LinksView());
        }

        private void GoToCompaniesPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new CompaniesView());
        }

        private void GoToItemsPageMethod(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
