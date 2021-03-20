using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenRoads.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfileTabbedView : TabbedPage
    {
        public MyProfileTabbedView()
        {
            InitializeComponent();

            TabbedPage.BarBackgroundColor = Color.White;
            TabbedPage.BarTextColor = Color.Black;
            TabbedPage.BackgroundColor = Color.DodgerBlue;
            
        }
    }
}