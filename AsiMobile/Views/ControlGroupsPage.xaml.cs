using Asi.Model;
using Asi.Shared.Model;
using AsiMobile.ViewModel;
using AsiMobile.ViewModels;
using Syncfusion.XForms.Buttons;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsiMobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlGroupsPage : ContentPage
    {
        private readonly FormGroupsViewModel formGroupsViewModel;
        private RequetControlListViewModel _RequestViewModel;
        public ControlGroupsPage(FormDataModel formData,RequetControlListViewModel requetControlListView)
        {
            this._RequestViewModel = requetControlListView;
            InitializeComponent();
            CarouselView groups = this.FindByName<CarouselView>("GroupsListView");
            BindingContext  = formGroupsViewModel= new FormGroupsViewModel(groups,formData,this,_RequestViewModel);
            
        }


        private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Picker firstanswerpicker = (sender as Picker);
            CarouselView carousel = (((sender as Picker).Parent.Parent as StackLayout).Parent as StackLayout).Parent as CarouselView;
            Picker missmatchpicker = ((sender as Picker).Parent as StackLayout).Children[1] as Picker;
            StackLayout warner = (((sender as Picker).Parent as StackLayout).Parent as StackLayout).Children[0] as StackLayout;
            FormDataRowModel formDataRow =missmatchpicker.BindingContext as FormDataRowModel;
            var t = this.formGroupsViewModel.Items;
            if ((sender as Picker).SelectedItem == null)
            {
                warner.BackgroundColor = Color.Red;
                missmatchpicker.IsVisible = false;
            }
                
            if (carousel!=null)
            {
                    string checkboxtext = (sender as Picker).SelectedItem.ToString();
                   // int c = carousel.Position;
                //StackLayout warner = (((sender as Picker).Parent as StackLayout).Parent as StackLayout).Children[0] as StackLayout;
               
               
               
                if (string.Equals(checkboxtext, "Ok"))
                {
                    missmatchpicker.IsVisible = false;
                    warner.BackgroundColor = Color.Green;
                    this.formGroupsViewModel.NexxtRowCommand(carousel);

                }

                if (string.Equals(checkboxtext, "NotOk"))
                {
                    StackLayout missmatchstack = missmatchpicker.Parent as StackLayout;
                    if((missmatchstack.BindingContext as FormDataRowModel)==null)
                        missmatchpicker.ItemsSource = new List<string>() { "جمله 1" };
                    else
                        missmatchpicker.ItemsSource= (missmatchstack.BindingContext as FormDataRowModel).MissMatchWords;
                    missmatchpicker.IsVisible = true;
                    warner.BackgroundColor = Color.Yellow;
                }
                if (string.Equals(checkboxtext, "Null"))
                {
                    missmatchpicker.IsVisible = false;
                    warner.BackgroundColor = Color.Yellow;
                    this.formGroupsViewModel.NexxtRowCommand(carousel);
                }

            }
            
            

        }

     

        private void Picker_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
            CarouselView carousel = (((sender as Picker).Parent.Parent as StackLayout).Parent as StackLayout).Parent as CarouselView;
            if(carousel!=null)
                this.formGroupsViewModel.NexxtRowCommand(carousel);
        }

        private void SfSegmentedControlFirstAnswer_SelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            
            SfSegmentedControl button = sender as SfSegmentedControl;
            
            List<string> f =(List<string>) button.ItemsSource;
            string value = f[e.Index];
            
          
            //button.SelectionChanged -= SfSegmentedControlFirstAnswer_SelectionChanged;
          //  button.SelectedIndex = 0;
           // button.SelectionChanged += SfSegmentedControlFirstAnswer_SelectionChanged;
            FormDataRowModel context = button.BindingContext as FormDataRowModel;
            context.FirstAnswer = value;
            this.PageNavigation(sender, value);
            context.FirstAnswer = value;
        }
        private void SfSegmentedControlSecondAnswer_SelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            SfSegmentedControl button = sender as SfSegmentedControl;
            List<string> f = (List<string>)button.ItemsSource;
            string value = f[e.Index];
            FormDataRowModel context = button.BindingContext as FormDataRowModel;
            context.SecondAnswer = value;
            this.PageNavigation(sender, value);
        }
        private void SfSegmentedControlThirdAnswer_SelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            SfSegmentedControl button = sender as SfSegmentedControl;
            List<string> f = (List<string>)button.ItemsSource;
            string value = f[e.Index];
            FormDataRowModel context = button.BindingContext as FormDataRowModel;
            context.ThirdAnswer = value;
            this.PageNavigation(sender, value);
        }
        private void SfSegmentedControlForthAnswer_SelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            SfSegmentedControl button = sender as SfSegmentedControl;
            List<string> f = (List<string>)button.ItemsSource;
            string value = f[e.Index];
            FormDataRowModel context = button.BindingContext as FormDataRowModel;
            context.ForthAnswer = value;
            this.PageNavigation(sender, value);
        }
        private void PageNavigation(object sender,string value)
        {
            CarouselView carousel = (((sender as SfSegmentedControl).Parent.Parent as StackLayout).Parent as StackLayout).Parent as CarouselView;
            Picker missmatchpicker = ((sender as SfSegmentedControl).Parent as StackLayout).Children[1] as Picker;
            StackLayout warner = (((sender as SfSegmentedControl).Parent as StackLayout).Parent as StackLayout).Children[0] as StackLayout;
            FormDataRowModel formDataRow = missmatchpicker.BindingContext as FormDataRowModel;
            // var t = this.formGroupsViewModel.Items;
            //if ((sender as Picker).SelectedItem == null)
            //{
            //    warner.BackgroundColor = Color.Red;
            //    missmatchpicker.IsVisible = false;
            //}

            if (carousel != null)
            {
                // int c = carousel.Position;
                //StackLayout warner = (((sender as Picker).Parent as StackLayout).Parent as StackLayout).Children[0] as StackLayout;



                if (string.Equals(value, "Ok"))
                {
                    missmatchpicker.IsVisible = false;
                    warner.BackgroundColor = Color.Green;
                    this.formGroupsViewModel.NexxtRowCommand(carousel);

                }

                if (string.Equals(value, "NotOk"))
                {
                    StackLayout missmatchstack = missmatchpicker.Parent as StackLayout;
                    if ((missmatchstack.BindingContext as FormDataRowModel) == null)
                        missmatchpicker.ItemsSource = new List<string>() { "جمله 1" };
                    else
                        missmatchpicker.ItemsSource = (missmatchstack.BindingContext as FormDataRowModel).MissMatchWords;
                    missmatchpicker.IsVisible = true;
                    warner.BackgroundColor = Color.Red;
                }
                if (string.Equals(value, "Null"))
                {
                    missmatchpicker.IsVisible = false;
                    warner.BackgroundColor = Color.Yellow;
                    this.formGroupsViewModel.NexxtRowCommand(carousel);
                }
               

            }
        }
    }
}