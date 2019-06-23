using GradeForestSchoolPortal.Helpers;
using GradeForestSchoolPortal.Models;
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
    public sealed partial class FacultyDirectoryPage : Page
    {
        public FacultyDirectoryPage()
        {
            this.InitializeComponent();

        }

        private async void UploadBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Faculty> list = new List<Faculty>();
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            picker.FileTypeFilter.Add(".csv");

            var file = await picker.PickSingleFileAsync();

            using (CsvFileReader csvReader = new CsvFileReader(await file.OpenStreamForReadAsync()))
            {
                CsvRow row = new CsvRow();
                while (csvReader.ReadRow(row))
                {
                    if (row.Count >= 4)
                    {
                        list.Add(new Faculty(row[0], row[1], row[2], row[3]));
                    }
                }
            }
            AzureStorageHelper.AddFacultyList(list);
        }
    }
}
