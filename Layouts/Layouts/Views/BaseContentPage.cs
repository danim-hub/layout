using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Layouts.Views
{
    public class BaseContentPage : ContentPage
    {

        public BaseContentPage()
        {
            base.ControlTemplate = (ControlTemplate)Application.Current.Resources["MainPageTemplate"];
            this.PageCommand = new Command<string>(PageAction);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            foreach(var i in this.ToolbarItems){
                if (i.Command == null)
                {
                    i.Command = this.PageCommand;
                }
            }
        }

        protected void PageAction(string s)
        {
            DisplayAlert("Title", "Action " + s, "Dismiss");
        }

        public string VersionLegendOnFooter
        {
            get
            {
                return "B-Route 2018-10-05";
            }
        }

        public string ViewCode
        {
            get { return (string)GetValue(ViewCodeProperty); }
            set { SetValue(ViewCodeProperty, value); }
        }

        public static readonly BindableProperty ViewCodeProperty =
            BindableProperty.Create("ViewCode", typeof(string), typeof(BaseContentPage), "----");

        public StackOrientation ContentOrientation
        {
            get { return (StackOrientation)GetValue(ContentOrientationProperty); }
            set { SetValue(ContentOrientationProperty, value); }
        }

        public static readonly BindableProperty ContentOrientationProperty =
            BindableProperty.Create("ContentOrientation", typeof(StackOrientation), typeof(BaseContentPage),
            StackOrientation.Vertical);

        private double ContentOrientationWidth = 0;
        private double ContentOrientationHeight = 0;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called
            if (this.ContentOrientationWidth != width || this.ContentOrientationHeight != height)
            {
                this.ContentOrientationWidth = width;
                this.ContentOrientationHeight = height;
                if (width > height)
                {
                    ContentOrientation = StackOrientation.Horizontal;
                }
                else
                {
                    ContentOrientation = StackOrientation.Vertical;
                }
            }
        }
        protected override bool OnBackButtonPressed()
        {
            //Device.BeginInvokeOnMainThread(async () => {
            //    var result = await this.DisplayAlert("title", "messegge?", "yes", "no");
            //    if (result)
            //        this.Navigation.PopAsync();
            //});
            return true;
            //return base.OnBackButtonPressed();
        }

        public ICommand PageCommand { get; set; }
    }
}
