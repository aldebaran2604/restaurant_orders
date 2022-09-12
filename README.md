
# Restaurant Web Orders

It is an application with api rest with .net core 6 technology in the backend and javascript with jquery in the frontend.

## Instructions for install and running the service. .NET 6

1. Installation: 
- Install  [.NET SDK 6](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.400-windows-x64-installer) in windows
- Install  [.NET SDK 6](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#dependencies) in linux
2. Run the service:
- Open the terminal corresponding to the system
- Enter from the terminal to the directory where the project is located with the command **"cd [directory_path]"**
- Run the command **"dotnet run"** which will compile the project and run it

## Test Service rest examples
In the .json files that have to be uploaded to postman are the requests to the respective ulrs of each service.

1. Install Postman
2. Import the files to postman:
* Products.postman_collection.json
* Orders.postman_collection.json
* Stock.postman_collection.json

## Instructions for run the web site

While running the service in the terminal
open the browser, copy the path where the **"index.html"** file is located and paste it in the browser url.
Examples:
- Linux directory: **file:///home/aldebaran/Projects/GitHub/restaurant_orders/restaurant-website/indext.html**
- Windows directory: **file:C://Projects/GitHub/restaurant_orders/restaurant-website/indext.html**

## Technologies used on the web.
* HTML 5
* JQuery 3.6.1
* bootstrap 4.0.0
* sweetalert2