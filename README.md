**C# Microsoft SQL Azure**

This project involves designing and developing a SQL database and C# application that interact with the database, using Azure SQL and Azure Data Factory. The database is designed with four tables: Products, Categories, and Orders,OrdersProducts

**Getting Started**

To get started with the project, you will need to follow these steps:

Clone the repository to your local machine.
Open the solution file in Visual Studio.
Build the solution to ensure that all dependencies are installed.
Open the Program.cs file in the ConsoleApp project and update the Azure Cognitive Search endpoint and admin key with your own values.
Run the application and follow the prompts to search for products.
Data Migration
The project includes a script for the Azure SQL database, along with sample data files in CSV format. To migrate this data to the Azure SQL database, you can run the script and import the data files.

**Product View**
A view called 'Product_VW' consolidates products and categories. A cognitive search indexer is importing data from this view and using column RowVersion as a pivot to keep the database and cognitive service synchronized.

**Indexing and Performance**
The console application is accepting user input for product-related text and searches for it in Azure Cognitive Search. Azure Cognitive Search is hitting Product_VW every 5 minutes to track any changes. An SQL index is also created on RowVersion to improve performance, which is very important with huge data. However, for extremely large data volumes, cognitive search should not import data from the view but instead leverage CDC and a dedicated table to get itself updated.

**Change Data Capture/Data Replication** 
Azure CDC was used to capture specific changes to the data in the SQL database and write them out to another database.

**Dependencies**
The project has the following dependencies:

.NET Core 6
Microsoft.Azure.Search version 11.1.0
Microsoft.Azure.Services.AppAuthentication version 1.4.2
Microsoft.Data.SqlClient version 2.1.3


**Technical Decisions and Trade-offs:**

Azure Change Data Capture (CDC): Is a preview feature in Azure SQL Database that captures insert, update, and delete operations applied to tables and makes the details of the changes available to consumers. The reason for using Azure CDC is that it provides an efficient and low-latency way of propagating changes made to the database to other systems. It can be especially useful for systems that need to stay up to date with the latest changes in near real-time.


**Contributing**
Contributions to the project are welcome. If you find a bug or have an enhancement in mind, please open an issue or submit a pull request.


**Acknowledgments**
Microsoft SQL Server Data Generator, Azure Data Factory
