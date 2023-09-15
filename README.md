# BasicBilling.API
An API for managing the company's client billing.
- Create and List categories.
- Create and manage Client's information
- List pending bills from an specific client.
- Pay bills.

The project was built based on clean architecture principles. You can see different Layers and each layer has its own purpose.
![CleanArchitecture](https://github.com/klbraguilar/NurBNB.User/assets/19180334/43d8d7fa-0f02-48e2-80f8-b89936ad1e07)

**How to use it**
You can clone the repo by using:
```
git clone https://github.com/klbraguilar/Payment.ServiceApp.git
```
then, move to the folder where you have the project:
```
cd your_local_path/Payment.ServiceApp/Payment.Service.WebAPI/
```
Execute the following commands to build and run the project:
```
dotnet restore
dotnet build
dotnet run
```
once the project is running you can check the APIs:
```
https://localhost:7164/swagger/index.html
```

it has some data inserted so you can test it.
