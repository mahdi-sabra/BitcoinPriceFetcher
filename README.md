# BitcoinPriceFetcher
Overview
The Bitcoin Price Fetcher is a web API application built with ASP.NET Core that fetches the Bitcoin price (BTC/USD) from multiple 
sources (Bitstamp and Bitfinex) and presents them to users. The application stores the prices in a SQLite database and provides 
various endpoints to retrieve current and historical price data.

Features
-Fetch Bitcoin prices from multiple sources (Bitstamp, Bitfinex).
-Store and retrieve Bitcoin prices with timestamps.
-List all available sources.

Technologies Used
-ASP.NET Core 6
-SQLite for data storage
-Entity Framework Core for database access
-Swagger for API documentation and testing

Prerequisites
-.NET 6 SDK or higher
-SQLite (installed with the .NET runtime)
-An IDE such as Visual Studio or Visual Studio Code

Getting Started

1.Clone the Repository
git clone https://github.com/mahdi-sabra/BitcoinPriceFetcher.git
cd BitcoinPriceFetcher

2.Restore Dependencies 
dotnet restore

3.Apply Migrations and Update Database
dotnet ef migrations add InitialCreate
dotnet ef database update

4.Build and run the application 
dotnet build 
dotnet run 

The application will start and listen on http://localhost:5229.

5.Access Swagger UI
Navigate to http://localhost:5229/index.html to access the Swagger UI and test the API endpoints.

Data Storage:
Prices are stored in a SQLite database with the following schema:

Source: The name of the price source (e.g., Bitstamp, Bitfinex).
Price: The price of Bitcoin in USD, formatted to two decimal places.
Timestamp: The time when the price was fetched.

