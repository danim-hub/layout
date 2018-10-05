using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Layouts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class view3000 : BaseContentPage
    {
        public string Route
        {
            get { return (string)GetValue(RouteProperty); }
            set { SetValue(RouteProperty, value); }
        }

        public static readonly BindableProperty RouteProperty =
            BindableProperty.Create("Route", typeof(string), typeof(view3000), "rrrr");

        public view3000()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            if (sender == this.txtCeve)
            {
                txtRuta.Focus();
            }
            else if (sender == this.txtRuta)
            {
                txtNIP.Focus();
            }
            else if (sender == this.txtNIP)
            {
            }
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {

        }
    }
}