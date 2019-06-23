using GradeForestSchoolPortal.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeForestSchoolPortal.Helpers
{
    class AzureStorageHelper
    {
        const string CONNECTION_STRING = "REPLACE WITH CONNECTION STRING FOR AZURE STORAGE ACCOUNT";
        public static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the application.");
                throw;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                Console.ReadLine();
                throw;
            }

            return storageAccount;
        }
        public static async Task<CloudTable> CreateTableAsync(string tableName)
        {
            // Retrieve storage account information from connection string.
            CloudStorageAccount storageAccount = CreateStorageAccountFromConnectionString(CONNECTION_STRING);

            // Create a table client for interacting with the table service
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();


            // Create a table client for interacting with the table service 
            CloudTable table = tableClient.GetTableReference(tableName);
            if (await table.CreateIfNotExistsAsync())
            {
                Debug.WriteLine("Created Table named: {0}", tableName);
            }
            else
            {
                Debug.WriteLine("Table {0} already exists", tableName);
            }

            return table;
        }
        public static async void UpdateBasicInfoAsync(string name, string loc, string description, string image, string stationCode)
        {
            try
            {
                CloudTable table = await CreateTableAsync("BasicInformation");
                TableOperation tableOperation = TableOperation.InsertOrMerge(new BasicInformation("School", name, loc, description, image, stationCode));
                TableResult tableResult = await table.ExecuteAsync(tableOperation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<BasicInformation> GetBasicInfoAsync()
        {
            try
            {
                CloudTable table = await CreateTableAsync("BasicInformation");
                TableOperation retrieveOperation = TableOperation.Retrieve<BasicInformation>("BasicInfo", "School");
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                BasicInformation info = result.Result as BasicInformation;
                if (info != null)
                {
                    return info;
                }
                else
                {
                    return new BasicInformation("School", "Error", "Error", "Error", "https://3.files.edl.io/26ba/18/12/07/184007-50217c07-a14a-4b23-8fb5-0b59a2b3146d.jpg", "41490");
                }
            }
            catch (StorageException e)
            {
                Debug.WriteLine(e.Message);
                return new BasicInformation("School", "Error", "Error", "Error", "https://3.files.edl.io/26ba/18/12/07/184007-50217c07-a14a-4b23-8fb5-0b59a2b3146d.jpg", "41490");
            }
        }
        public static async void UpdateLunchMenu(string day, string main, string side, double cal)
        {
            try
            {
                CloudTable table = await CreateTableAsync("LunchMenu");
                TableOperation tableOperation = TableOperation.InsertOrMerge(new LunchMenuItem(day, main, side, cal));
                TableResult tableResult = await table.ExecuteAsync(tableOperation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<LunchMenuItem> GetLunchMenuAsync(string day)
        {
            try
            {
                CloudTable table = await CreateTableAsync("LunchMenu");
                TableOperation retrieveOperation = TableOperation.Retrieve<LunchMenuItem>("Lunch", day);
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                LunchMenuItem info = result.Result as LunchMenuItem;
                if (info != null)
                {
                    return info;
                }
                else
                {
                    return new LunchMenuItem("Error", "Error", "Error", 0);
                }
            }
            catch (StorageException e)
            {
                Debug.WriteLine(e.Message);
                return new LunchMenuItem("Error", "Error", "Error", 0);
            }
        }
        public static async void AddFacultyList(IList<Faculty> list)
        {
            try
            {
                CloudTable table = await CreateTableAsync("Faculty");
                TableBatchOperation tableOperations = new TableBatchOperation();
                foreach (var i in list)
                {
                    tableOperations.Add(TableOperation.InsertOrMerge(i));
                }
                IList<TableResult> tableResult = await table.ExecuteBatchAsync(tableOperations);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async static void PostAnnouncement(string key, string title, string poster, string date, string content, string image)
        {
            try
            {
                CloudTable table = await CreateTableAsync("Announcement");
                TableOperation tableOperation = TableOperation.InsertOrMerge(new Announcement(title, poster, content, image, DateTime.Now));
                TableResult tableResult = await table.ExecuteAsync(tableOperation);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
