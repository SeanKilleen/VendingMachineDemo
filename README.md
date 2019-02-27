# Welcome to the Excella Vending Machine demo!
This demo shows a working example of a small project with unit tests at each level.

# How to Run this Application

## Prerequisites
To run the project, you'll need to have some basic items set up or installed.

* **Internet.** You'll need an internet connection so that you can restore nuget packages.
* **Visual Studio**. You'll need Visual Studio to run the examples
* **SQL Server**. The acceptance tests and web application use a database, which this example assumes is a SQL Server database.
* **Selenium Chrome Driver**. We'll need this to run instances of chrome on our machine.

Using Chocolatey (<http://chocolatey.org>) could be helpful in installing these prerequisites, e.g. then you can run `choco install chromedriver` to install ChromeDriver.
 
## Getting Started

### Adding the Selenium Chrome Driver to the PATH variable.


### Running the Migration to Deploy the Database

* Open the package management console
* Select `Excella.Vending.DAL` as the default project
* In the package management console, type `Update-Database` and run.

This should create the database and run the initial migration to set everything up.

### Adding the Initial Payment row to the Database

This is performed by the initial migration, but you can run the following SQL if there is no row in the `Payments` table.

```
  SET IDENTITY_INSERT dbo.Payment ON
  INSERT INTO dbo.Payment
    (ID, Value)
  VALUES 
    (1, 0)
  SET IDENTITY_INSERT dbo.Payment OFF
```

## Running the tests

You should be able to run tests in the test runner of your choice -- Visual Studio, ReSharper, NCrunch, etc.

### :warning: KNOWN ISSUE: Currently the Chrome-based AATs require Debugging

For some reason, the IIS Express setup appears to refuse connections unless the application is being actively debugged. So rather than running those tests, you may need to "Debug" those tests in order to get them to pass successfully.

### :warning: KNOWN ISSUE: AAT Cleanup

Currently there appears to be an issue where, when running AATs, IIS express is not cleaned up at the end of the tests. This is likely due to the static way we're managing the browser, etc.