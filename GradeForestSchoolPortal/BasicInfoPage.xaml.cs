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
    public sealed partial class BasicInfoPage : Page
    {
        public BasicInfoPage()
        {
            this.InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            AzureStorageHelper.UpdateBasicInfoAsync(this.NameTbx.Text, this.LocTbx.Text, this.DescriptionTbx.Text, this.ImgBox.Text, this.StaTbx.Text);
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var data = await AzureStorageHelper.GetBasicInfoAsync();
            this.NameTbx.Text = data.Name;
            this.LocTbx.Text = data.Location;
            this.DescriptionTbx.Text = data.Description;
            this.ImgBox.Text = data.Image;
            this.StaTbx.Text = data.StationCode ?? "";
        }
    }
}
