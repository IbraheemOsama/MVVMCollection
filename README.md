# Introduction
You're tired of create an observableCollection for UI and another list for your DB Model (SQlite, Azure Mobile Service,..) in  Windows Store App , Windows Phone or WPF application that uses MVVM and when add or remove item you do the action in both lists

# MVVM Collection

MVVM is a collection that implements the complete MVVM pattern with a DB Model, MVVM Collection inherits ObservableCollection which notify the UI once a change happens in the Collection and uses Dependency Injection for the DB Model when adding or removing data from the Collection.
To start using MVVM Collection in a project.

1)	Create new Repository Class of your DB Model that Implements IModelRepository.

2)	Create new MVVMCollectionFactory object with passing the created Repository type as a Generic type and the factory will auto create the Repository.

3)	From MVVMCollectionFactory create new MVVMCollection of any class type that exist in your DB Model and bind it to any list.

# Detailed code steps

1) Create Repository that implements IModelRepository

    public class SQLiteMVVMRepository : IModelRepository
    {
        public async Task Add<T>(T itemToAdd) where T : new()
        {
            await DBServices.SQLiteConnector.InsertAsync(itemToAdd);

        }

        public async Task Remove<T>(T itemToDelete) where T : new()
        {
            await DBServices.SQLiteConnector.DeleteAsync(itemToDelete);
        }

        public async Task<IList<T>> RetrieveAll<T>() where T : new()
        {
            return await DBServices.SQLiteConnector.Table<T>().ToListAsync();
        }

        public async Task<IList<T>> RetrievePredicate<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : new()
        {
            return await DBServices.SQLiteConnector.Table<T>().Where(predicate).ToListAsync();
        }
    }

2) Create new MVVMCollectionFactory with injecting the repository

            MVVMCollectionFactory<SQLiteMVVMRepository> SQLiteCollectionFacotry;
            SQLiteCollectionFacotry = new MVVMCollectionFactory<SQLiteMVVMRepository>();

3) Create MVVMCollection for the Created MVVMCollectionFactory and bind it to any List

            CompanyMVVMCollection = SQLiteCollectionFacotry.NewMVVMCollection<Company>();
            DeveloperCompanyComboBox.ItemsSource = await CompanyMVVMCollection.LoadAllModelData();

4) Add or Remove any items and it will be reflected in the DB

            await CompanyMVVMCollection.Add(newCompany);
            await CompanyMVVMCollection.Remove(DeveloperCompanyComboBox.SelectedItem as Company);


# MVVM Collection Settings
You have 2 options will creating a new MVVM Collection
1) Add item to Model First then update the view ( Default option )
2) Add to view first then update the model

and to change the settings all you have to do is passing MVVMCollectionSettings to the NewMVVMCollection function

            MVVMCollectionSettings settings = new MVVMCollectionSettings(MVVMCollectionActionSettings.UpdateViewFirst);
            CompanyMVVMCollection = SQLiteCollectionFacotry.NewMVVMCollection<Company>(settings);
            

# Missing Features
1) IOC Container for registering and resolving MVVMCollections of a certain Model Type
2) Any great feature that you see it needs to be implemented :)

# Motivation
I think it worth your effort to make a lot of developers happier, why MVVM Collection because in every project I developed I wasted a lot of time syncing between the UI and the Model. Thats why I start to think about MVVMCollection.

# Contributors

1) Ibraheem Osama Mohamed
2) MVVM Collection can't wait to see your name is written here :)

