using GradeForestSchoolPortal.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GradeForestSchoolPortal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NavigationViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer;
            switch(item.Tag)
            {
                case "home":
                    
                    break;
                case "basicinfo":
                    this.NavViewFrame.Navigate(typeof(BasicInfoPage));
                    break;
                case "menu":
                    this.NavViewFrame.Navigate(typeof(MenuPage));
                    break;
                case "faculty":
                    this.NavViewFrame.Navigate(typeof(FacultyDirectoryPage));
                    break;
                case "announcement":
                    this.NavViewFrame.Navigate(typeof(AnnouncementPage));
                    break;
                default:
                    break;
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!await WindowsHelloHelper.Auth())
            {
                App.Current.Exit();
            }
        }
    }
}
