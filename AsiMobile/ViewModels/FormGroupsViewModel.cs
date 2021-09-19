using Asi.Model;
using AsiMobile.ViewModels;
using AsiMobile.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AsiMobile.ViewModel
{
    public class FormGroupsViewModel 
    {
        private RequetControlListViewModel _requestControlViewModel;
        private FormDataModel _formDataModel;
        public Command<FormDataModel> SubmitForm { get; set; }
        public CarouselView groupsview { get; set; }
        public List<string> Selections { get; set; }
        public Command<CarouselView> Next { get; }
        public Command<CarouselView> Prev { get; }
        private ContentPage contentPage;

        public ObservableCollection<FormDataGroupModel> Items { get; }


        private  void SubmitForMethod(FormDataModel obj)
        {
            RequestCertificateControlModel certificateControlModel = new RequestCertificateControlModel();
            App.Current.MainPage.Navigation.PushAsync(new ControlDetailView(this));
            certificateControlModel.ControlForm = _formDataModel;
           
        }

        public void SubmitCertificateControl(RequestCertificateControlModel requestCertificateControlModel)
        {
            requestCertificateControlModel.ControlForm = this._formDataModel;
            
             _requestControlViewModel.SubmitForm(requestCertificateControlModel);
            App.Current.MainPage.SendBackButtonPressed();
            App.Current.MainPage.SendBackButtonPressed();
        }

        public FormGroupsViewModel(CarouselView groupsview, FormDataModel formData,ContentPage page,RequetControlListViewModel requetControlListView)
        {
            this._requestControlViewModel = requetControlListView;
            SubmitForm = new Command<FormDataModel>(SubmitForMethod);
            this._formDataModel = formData;
            this.groupsview = groupsview;
            this.contentPage = page;
            this.Selections = new List<string>
            {
                "Ok",
                "Not Ok",
                "Null"
            };
            Next = new Command<CarouselView>(NexxtRowCommand);
            Prev = new Command<CarouselView>(PreviousRowCommand);
            Items = new ObservableCollection<FormDataGroupModel>();

            for (int i = 0; i < formData.Groups.Count; i++)
            {
                Items.Add(formData.Groups[i]);
            }
           

           
        }

        private void PreviousRowCommand(CarouselView obj)
        {
            obj.ScrollTo(obj.Position --);
        }

        public void NexxtRowCommand(CarouselView obj)

        {

            if (!((obj.Position == this.Items[this.groupsview.Position].Questions.Count - 1) && (this.groupsview.Position == this.Items.Count - 1)))
            {
                if (obj.Position == this.Items[this.groupsview.Position].Questions.Count - 1)
                {
                    this.groupsview.Position++;
                    obj.Position = 0;
                    obj.ScrollTo(obj.Position);
                }
                else
                {
                    obj.Position++;
                    obj.ScrollTo(obj.Position);
                }
            }


        }

        private void Obj_PositionChanged(object sender, PositionChangedEventArgs e)
        {
           
        }
    }
}




