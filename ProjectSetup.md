# BuberDinner Project Configuration

This document outlines the steps to set up the BuberDinner project using Clean Architecture and Domain-Driven Design (DDD).

## Project Structure Creation

1. Create a new .NET solution file:
    ```
    dotnet new sln -o BuberDinner
    cd .\BuberDinner
    ```

2. Create a new ASP.NET Core Web API project:
    ```
    dotnet new webapi --use-controllers -o BuberDinner.Api
    ```

3. Create a class library for interfaces and DTOs:
    ```
    dotnet new classlib -o BuberDinner.Contracts
    ```

4. Create a class library for data persistence and external integrations:
    ```
    dotnet new classlib -o BuberDinner.Infrastructure
    ```

5. Create a class library for application logic and domain models:
    ```
    dotnet new classlib -o BuberDinner.Application
    ```

6. Create a class library for entities and business rules:
    ```
    dotnet new classlib -o BuberDinner.Domain
    ```

## Compilation and Project References

1. Add all projects to the solution file:
    ```
    dotnet sln add (ls -r **\\*.csproj)
    ```

2. Set project references to establish the dependency structure between layers:
    ```
    dotnet add .\BuberDinner.Api reference .\BuberDinner.Contracts .\BuberDinner.Application
    dotnet add .\BuberDinner.Infrastructure reference .\BuberDinner.Application
    dotnet add .\BuberDinner.Application reference .\BuberDinner.Domain
    dotnet add .\BuberDinner.Api reference .\BuberDinner.Infrastructure
    ```

3. Build all projects within the solution:
    ```
    dotnet build
    ```