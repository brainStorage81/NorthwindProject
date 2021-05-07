<p align="center">
  <a href="https://github.com/brainStorage81/NorthwindProject">
    <img src="https://github.com/brainStorage81/NorthwindProject/blob/42139e3fa65706b1a84dee6451a0e85f35be116e/northwind.jpg">
  </a>
  <h2 align="center">NorthwindProject</h2>
  <p align="center">
    E-commerce project with N-Layer Architecture.    
  </p>
</p>

<br />
<br />
    <p align="center"> In this project, we created a website backend for e-commerce using Asp.NET Core and Web API. Customers will be able to register on your site, log in with JWT and take action within their authority.
    </p>

<details open="open">
  <summary><strong>Techs</strong></summary>
  <ol>
    <li>
      <a href=" https://github.com/brainStorage81/NorthwindProject">Back-End</a>
      <ul>
        <li>Restful Web Api Vers. .Net Core 5.0.5</li>
      </ul>
      <ul>
        <li>Multi-Layer Architecture</li>
      </ul>
      <ul>
        <li>Interceptors</li>
      </ul>
	    <ul>
        <li>Helpers</li>
      </ul>
	      <ul>
        <li>IoC</li>
      </ul>
      <ul>
       <li>Exception Log Aspect</li>
      </ul>
      <ul>
        <li>Log Aspect</li>
      </ul>
      <ul>
        <li>Cache Aspect</li>
      </ul>
      <ul>
        <li>Transaction Aspect</li>
      </ul>
      <ul>
        <li>Performance Aspect</li>
      </ul>
      <ul>
        <li>Validation Aspect(Fluent Validation)</li>
      </ul>
      <ul>
        <li>Authorization</li>
      </ul>
      <ul>
        <li>Authentication</li>
      </ul>
      <ul>
        <li>Autofac</li>
      </ul>
      <ul>
        <li>Json Web Token Managment</li>
      </ul>
      <ul>
        <li>Async Programing</li>
      </ul>
      <ul>
        <li>Cross Cutting Concerns</li>
      </ul>
      <ul>
        <li>SOLID</li>
      </ul>      
   
## About The Project

### Built With

[![C-Sharp](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Asp-net](https://img.shields.io/badge/ASP.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet)
[![MSSQL](https://img.shields.io/badge/MSSQL-004880?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server/sql-server-2019?rtc=2)
[![Entity-Framework](https://img.shields.io/badge/Entity%20Framework-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://docs.microsoft.com/en-us/ef/)
[![Autofac](https://img.shields.io/badge/Autofac-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://autofac.org/)
[![Fluent-Validation](https://img.shields.io/badge/Fluent%20Validation-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://fluentvalidation.net/)
</br>

## Tables

<img src="https://github.com/brainStorage81/NorthwindProject/blob/572453b47ed51b6f99069fdc97afa9fb72123426/Database_Diagram.png">
  </a>

## Layers

### Business

We write our workloads on this layer. This layer is the layer that will process the data that has been pulled into the project by Data Access. We do not use the Data Access layer directly in our applications. By putting the Business layer together, we make Business do it for us. The data from the user first goes to the Business layer, and then is processed and transferred to the Data Access layer. In the business tier, we also specify who will access this data. Let's say we want the accounting staff to be able to add to the program database and pull data. however let's just say we want the Accounting Manager to update and delete data from the database. Here we make such distinctions in the Bussiness layer.

### Core

In this layer, we have base classes that all projects can use in common.

### DataAccess

Only database operations are performed in this layer. The task of this layer is to add, delete, update and extract data from the database. No other action is taken in this layer other than these operations.

### Entities

In this layer, we determine our main classes that we will use throughout the project, so this is where we determine our real objects. Here, we match the objects we have determined with the objects registered in the database.

### WebAPI

Web API Layer that opens the business layer to the internet.

</details>
<p></p>
