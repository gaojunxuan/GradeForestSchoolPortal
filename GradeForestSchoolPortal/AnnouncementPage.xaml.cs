using GradeForestSchoolPortal.Helpers;
using GradeForestSchoolPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GradeForestSchoolPortal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AnnouncementPage : Page
    {
        public AnnouncementPage()
        {
            this.InitializeComponent();
        }

        private async void PostBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AzureStorageHelper.PostAnnouncement(DateTime.Now.ToString(), TitleTbx.Text, PosterTbx.Text, "a", ContentTbx.Text, ImgBox.Text);
                await new MessageDialog("Successfully posted.").ShowAsync();
            }
            catch
            {
                await new MessageDialog("Error").ShowAsync();
            }
        }
    }
}
