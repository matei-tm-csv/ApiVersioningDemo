# Demo project for Aspnet Core API Versioning

- [Demo project for Aspnet Core API Versioning](#demo-project-for-aspnet-core-api-versioning)
  - [Purpose](#purpose)
  - [Description](#description)
    - [API Versions](#api-versions)
  - [Controllers](#controllers)
    - [NeutralActor Controller versions characteristics](#neutralactor-controller-versions-characteristics)
    - [MultiSkilledActor Controller versions characteristics](#multiskilledactor-controller-versions-characteristics)
    - [WeatherForecast Controller versions characteristics](#weatherforecast-controller-versions-characteristics)
      - [v1.1](#v11)
      - [v1.2](#v12)
      - [v2.0](#v20)
    - [Model versions](#model-versions)
  - [Credits](#credits)

## Purpose

To provide an example for implementing concurrent versioning support to Web API.

## Description

It is an ASP.NET Core Web API project providing a basic architecture for showing several facets of versioning. It is focused on URL segment routing.

![image](https://user-images.githubusercontent.com/86602521/137997215-091045b8-7d9b-4f22-8812-58234905d778.png)

### API Versions

The demo implements three concurrent versions (1.1, 1.2, 2.0) that are exposed by collecting ApiVersionAttribute from controllers.
Three types of controllers are showing different approaches on versioning:

- ApiVersionAttribute - used to apply explicit version
- ApiVersionNeutralAttribute - used for version independent
- ApiInheritableVersionAttribute - used for create a base class with a range of versions inheritable by child classes 

## Controllers

### NeutralActor Controller versions characteristics

It uses the ApiVersionNeutral attribute and it is independent from versions (i.e. it is exposes accross all versions)

### MultiSkilledActor Controller versions characteristics

It inherits the versions placed on a base class decorated with ApiInheritableVersion

### WeatherForecast Controller versions characteristics

They are derived from an abstract base controller that keeps the common characteristics across supported versions.

#### v1.1 

- It is marked as deprecated at class level (as result, VERSION IS DEPRECATED is displayed)
- The Get method is marked as Obsolete (as result, the endpoint is grayed out)
- Uses a WeatherForecast model v1.1

![image](https://user-images.githubusercontent.com/86602521/137956161-45671ad1-d558-40e5-90c7-5005038e3bc2.png)

#### v1.2 

- It is marked as deprecated at class level (as result, VERSION IS DEPRECATED will be displayed only if MultiSkilledActor will be marked as well)
- Uses a WeatherForecast model v1.1
- The Get method has a patched version of processing the WeatherForecast

![image](https://user-images.githubusercontent.com/86602521/137957109-37f48b16-4de1-43b1-a0f0-a3d3ea1a56eb.png)

#### v2.0

- Uses a WeatherForecast model v2.0
- The Get method has an improved version

![image](https://user-images.githubusercontent.com/86602521/137956341-9e3cc1df-4c38-45e2-b0a3-8e6bafb8c892.png)

### Model versions

The model versions does not directly influence the version of the API and are not mandatory to have versions related to the API. For example, a model can stay forever as 1.0 and in the meantime other models to evolve to greater versions. The dependency could be better seen as "the changes in the models push the API version evolution".

## Credits

- Mark Heath: Pluralsight course  [
Versioning and Evolving Microservices in ASP.NET Core](https://app.pluralsight.com/library/courses/versioning-evolving-microservices-asp-dot-net-core/exercise-files)
- ASP.NET API Versioning [samples](https://github.com/dotnet/aspnet-api-versioning/tree/master/samples)

