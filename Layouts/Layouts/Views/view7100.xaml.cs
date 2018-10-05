using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Layouts.Models;

namespace Layouts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class view7100 : BaseContentPage
    {
        public Item Item { get; set; }

        public IList<string> CommOptions
        {
            get
            {
                return new List<String> { "Wifi", "Ethernet", "GPRS", "4G" };
            }
            set { }
        }

        public view7100()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}