# MVVM Collection
MVVM is a collection that implements the complete MVVM pattern with a DB Model, MVVM Collection inherits ObservableCollection which notify and UI once a change happens in the Collection and uses Dependency Injection for the DB Model when adding or removing data from the Collection.
To start using MVVM Collection in a project.
1)	Create new Repository Class of your DB Model that Implements IModelRepository
2)	Create new MVVMCollectionFactory object with passing the Repository type as a Generic type
3)	From MVVMCollectionFactory create new MVVMCollection of any class type that exist in your DB Model

