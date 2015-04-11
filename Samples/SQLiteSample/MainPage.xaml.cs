using MVVMHandler;
using SQLiteSample.DB_Model;
using SQLiteSample.Services;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SQLiteSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MVVMCollection<Company> CompanyMVVMCollection;
        MVVMCollectionFactory<SQLiteMVVMRepository> SQLiteCollectionFacotry;
        public MainPage()
        {
            this.InitializeComponent();
            

            SQLiteCollectionFacotry = new MVVMCollectionFactory<SQLiteMVVMRepository>();
            this.Loaded += MainPage_Loaded;
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await SQLiteSample.Services.DBServices.CreateTables();
            MVVMCollectionSettings settings = new MVVMCollectionSettings(MVVMCollectionActionSettings.UpdateViewFirst);
            CompanyMVVMCollection = SQLiteCollectionFacotry.NewMVVMCollection<Company>(settings);
            DeveloperCompanyComboBox.ItemsSource = await CompanyMVVMCollection.LoadAllModelData();
            //DeveloperCompanyComboBox.ItemsSource = await CompanyMVVMCollection.Where(i => i.Name == "test");
        }

        private async void AddCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            Company newCompany = new Company();
            newCompany.Name = CompanyNameTextbox.Text;
            await CompanyMVVMCollection.Add(newCompany);
            CompanyNameTextbox.Text = string.Empty;

        }

        private async void RemoveCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            await CompanyMVVMCollection.Remove(DeveloperCompanyComboBox.SelectedItem as Company);
        }
    }
}
