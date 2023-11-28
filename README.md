**C# Microsoft SQL Architect Task**

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

**Search Method**
The C# application implements a search method for products that allows the user to search using all available parameters, including product name, category, price, description, and date added. The search method uses Azure Cognitive Search to provide enhanced search capabilities for products.

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
Azure SQL and Azure Data Factory: The decision to use Azure SQL and Azure Data Factory was made due to their compatibility with each other and ease of use. These technologies are also scalable and can handle large volumes of data, which is important for a project with a search function.

Search Method: The decision to implement a search method that allows the user to search using all available parameters was made to provide a powerful search function that is easy to use and accurate.

Azure Cognitive Search: The decision to use Azure Cognitive Search was made to provide enhanced search capabilities for products, which improves the user experience.

Data Migration: One of the challenges encountered was migrating sample data in CSV format to the Azure SQL database. To overcome this, a script for the Azure SQL database was created, along with the sample data files in the repository.

Synchronization: Another challenge encountered was keeping the database and cognitive service synchronized. To overcome this, a cognitive search indexer was created that imports data from a view, using column RowVersion as a pivot to track changes.

Performance: The final challenge encountered was the performance of the search function, especially with large data volumes. To overcome this, an SQL index was created on RowVersion, and CDC can be leveraged later for extremely large data volumes.

Azure Change Data Capture (CDC): Is a preview feature in Azure SQL Database that captures insert, update, and delete operations applied to tables and makes the details of the changes available to consumers. The reason for using Azure CDC is that it provides an efficient and low-latency way of propagating changes made to the database to other systems. It can be especially useful for systems that need to stay up to date with the latest changes in near real-time.


**Contributing**
Contributions to the project are welcome. If you find a bug or have an enhancement in mind, please open an issue or submit a pull request.


**Acknowledgments**
Microsoft SQL Server Data Generator, Azure Data Factory,  Azure Cognitive Search
