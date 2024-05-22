# The Scouts 

# About the project
The definition of the name "scout" is "a soldier or other person sent out ahead of a main force to gather information about the enemy's position, strength, or movements. The project is named "The Scouts" as it represents a group of individuals working together to scout and identify qualified, and good-fit candidates and is often used as a term in the recruitment context.

# Installation 
Build the project with the following steps:
1. Clone the repository
2. Open the project in your IDE (Visual Studio recommended)
3. Make sure you are using the C# programming language, version 11.0, and ASP.NET Core MVC framework, version 7.0
4. To integrate the Entity Framework Core, make sure the NuGet packages are installed: 
    - Microsoft.EntityFrameworkCore, version 7.0.0
    - Microsoft.EntityFrameworkCore.Tools, version 7.0.0
    - Npgsql.EntityFrameworkCore.PostgreSQL, version 7.0.0
    - Microsoft.AspNetCore.Identity.EntityFrameworkCore, version 7.0.0
5. Configure the database connection in the `appsettings.json` file (check the [Database](#database) section below for more info)
6. Run the migrations (check the [Migrations](#migrations) section below for more info)
7. Run the project

# Database
The database used for this project is PostgreSQL. Prior to configuring the database connection you have to create a database. The database connection can be configured in the appsettings.json file, with the appropriate values for the following properties:
```
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost; Database=RecruitmentManagementSystem; Username=postgres; Password=admin;"
},
```
The Host parameter specifies the location of the database server. For a local PostgreSQL server, the host is usually specified as `localhost`.  
Prior to adding this connection string in the appsettings.json file, I created the `RecruitmentManagementSystem` database.  
Lastly, configure the username and password parameters based on your database management system.

# Migrations
For the tables to be created in the database, you need to run the migrations of the project.  
 
Run the migrations of the project with the following steps:
1. Open terminal 
2. Navigate to the project directory
    - `cd TheScouts`
3. Run the following command to create the initial migration:
    - `dotnet ef migrations add InitialCreate`
5. Run the following command to update the database:
    - `dotnet ef database update`  

Once completed the above steps, you should have the required tables in your database. Refresh the database and check for the table creations. 

# Collaborators
Meet the contributors of the project:
- [Alba Adili](https://gitlab.com/albaadili)
- [Endrit Jakupi](https://gitlab.com/endritjakupi)
- [Ermira Bexheti](https://gitlab.com/ermirab)

# Contributing
If you want to contribute to the project and make it better, your help is very welcome. Please follow the below steps in order to contribute to the project:
1.  Fork the repository
2. Create a new branch for your feature
3. Make your changes, commit them and push your changes to your forked repository
4. Open a pull request

Make sure to test your changes thoroughly. Provide tests if applicable and ensure that existing tests pass.  
If you encounter any issues or have suggestions for improvements, please [open an issue](../../issues) on the repository.

Thank you for contributing to our project!

# Contact
Feel free to get in touch if you have questions, feedback, or just want to say hello. We welcome contributions and discussions related to the project.

Thank you for your interest!

