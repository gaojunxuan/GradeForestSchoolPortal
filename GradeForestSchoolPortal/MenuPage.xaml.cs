using GradeForestSchoolPortal.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GradeForestSchoolPortal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuPage : Page
    {
        public MenuPage()
        {
            this.InitializeComponent();
        }
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < 5; i++)
            {
                switch(i)
                {
                    case 0:
                        AzureStorageHelper.UpdateLunchMenu(days[i], MainMonTbx.Text, SideMonTbx.Text, double.Parse(CalMonTbx.Text));
                        break;
                    case 1:
                        AzureStorageHelper.UpdateLunchMenu(days[i], MainTuesTbx.Text, SideTuesTbx.Text, double.Parse(CalTuesTbx.Text));
                        break;
                    case 2:
                        AzureStorageHelper.UpdateLunchMenu(days[i], MainWedTbx.Text, SideWedTbx.Text, double.Parse(CalWedTbx.Text));
                        break;
                    case 3:
                        AzureStorageHelper.UpdateLunchMenu(days[i], MainThurTbx.Text, SideThurTbx.Text, double.Parse(CalThurTbx.Text));
                        break;
                    case 4:
                        AzureStorageHelper.UpdateLunchMenu(days[i], MainFriTbx.Text, SideFriTbx.Text, double.Parse(CalFriTbx.Text));
                        break;
                }
            }
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < 5; i++)
            {
                var item = await AzureStorageHelper.GetLunchMenuAsync(days[i]);
                switch(i)
                {
                    case 0:
                        this.MainMonTbx.Text = item.Main;
                        this.SideMonTbx.Text = item.Side;
                        this.CalMonTbx.Text = item.Calories.ToString();
                        break;
                    case 1:
                        this.MainTuesTbx.Text = item.Main;
                        this.SideTuesTbx.Text = item.Side;
                        this.CalTuesTbx.Text = item.Calories.ToString();
                        break;
                    case 2:
                        this.MainWedTbx.Text = item.Main;
                        this.SideWedTbx.Text = item.Side;
                        this.CalWedTbx.Text = item.Calories.ToString();
                        break;
                    case 3:
                        this.MainThurTbx.Text = item.Main;
                        this.SideThurTbx.Text = item.Side;
                        this.CalThurTbx.Text = item.Calories.ToString();
                        break;
                    case 4:
                        this.MainFriTbx.Text = item.Main;
                        this.SideFriTbx.Text = item.Side;
                        this.CalFriTbx.Text = item.Calories.ToString();
                        break;
                }
            }
        }
    }
}
