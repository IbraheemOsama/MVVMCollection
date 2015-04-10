# Introduction
You're tired of create an observableCollection for UI and another list for your DB Model (SQlite, Azure Mobile Service,..) in  Windows Store App , Windows Phone or WPF application that uses MVVM and when add or remove item you do the action in both lists

# MVVM Collection

MVVM is a collection that implements the complete MVVM pattern with a DB Model, MVVM Collection inherits ObservableCollection which notify the UI once a change happens in the Collection and uses Dependency Injection for the DB Model when adding or removing data from the Collection.
To start using MVVM Collection in a project.

1)	Create new Repository Class of your DB Model that Implements IModelRepository.

2)	Create new MVVMCollectionFactory object with passing the created Repository type as a Generic type and the factory will auto create the Repository.

3)	From MVVMCollectionFactory create new MVVMCollection of any class type that exist in your DB Model.


