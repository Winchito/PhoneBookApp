# Phone Book Console App


This App was based on the C# Academy Phone project, consists in a simple Phone Book to store contacts in a SQL Server Database

![image](https://github.com/user-attachments/assets/7749d3a7-e345-42c4-83b4-f3ee7cc5940c)

It performs CRUD (Create, Read, Update and Delete) actions, you can watch the CRUD actions on ContactController.cs

The Database was created using EntityFramework (Core, Design and Tools packages) by creating a Contact model and then making a DatabaseManager Class with DBContext to set the database tables on the connection, you can see it on DatabaseManager.cs

![image](https://github.com/user-attachments/assets/2c5b9edf-5370-4c7f-894a-c6734c05a217)


The string credentials are in App.config 


To validate Email in UserInput.cs i decided to use ReGex and validate it from there.

I think thats all


# Additional Links

- https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/store-custom-information-config-file (To get Strings from App.config
- https://stackoverflow.com/questions/1279613/what-is-an-orm-how-does-it-work-and-how-should-i-use-one (What is an ORM)
- https://learn.microsoft.com/en-us/ef/core/ (EntityFramework Core)
- https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli (Getting started with EntityFramework)
- https://www.geeksforgeeks.org/basic-crud-create-read-update-delete-in-asp-net-mvc-using-c-sharp-and-entity-framework/ (CRUD with ASP, i didnt make a ASP.NET Core project but it help me to solve some CRUD operations)
- https://stackoverflow.com/questions/748062/return-multiple-values-to-a-method-caller (Return multiple values (Tuple))
- https://www.learnentityframeworkcore.com/dbset/querying-data (Queryin data with EF)
- https://stackoverflow.com/questions/16167983/best-regular-expression-for-email-validation-in-c-sharp (Regular Expressions to validate Email)
