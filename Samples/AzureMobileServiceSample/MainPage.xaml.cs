using AzureMobileServiceSample.DB_Model;
using AzureMobileServiceSample.Services;
using MVVMHandler;
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

namespace AzureMobileServiceSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       
        MVVMCollection<Company> CompanyMVVMCollection;
        MVVMCollectionFactory<MobileServiceRepository> SQLiteCollectionFacotry;
        public MainPage()
        {
            this.InitializeComponent();
            SQLiteCollectionFacotry = new MVVMCollectionFactory<MobileServiceRepository>();
            this.Loaded += MainPage_Loaded;
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            CompanyMVVMCollection = SQLiteCollectionFacotry.NewMVVMCollection<Company>();
            DeveloperCompanyComboBox.ItemsSource = await CompanyMVVMCollection.Where(i => i.Name == "test");
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
