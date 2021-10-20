# Demo project for Aspnet Core API Versioning

- [Demo project for Aspnet Core API Versioning](#demo-project-for-aspnet-core-api-versioning)
  - [Purpose](#purpose)
  - [Description](#description)
    - [API Versions](#api-versions)
    - [Pinpoints](#pinpoints)
  - [Controllers](#controllers)
    - [NeutralActor Controller versions characteristics](#neutralactor-controller-versions-characteristics)
    - [MultiSkilledActor Controller versions characteristics](#multiskilledactor-controller-versions-characteristics)
    - [SafeSkilledActor Controller versions characteristics](#safeskilledactor-controller-versions-characteristics)
    - [WeatherForecast Controller versions characteristics](#weatherforecast-controller-versions-characteristics)
      - [v1.1](#v11)
      - [v1.2](#v12)
      - [v2.0](#v20)
    - [Model versions](#model-versions)
  - [Credits](#credits)
  - [Further reading](#further-reading)
    - [Opinionated convention](#opinionated-convention)

## Purpose

To provide an example for implementing concurrent versioning support to Web API.

## Description

It is an ASP.NET Core Web API project providing a basic architecture for showing several facets of versioning. It is focused on URL segment routing.

![image](https://user-images.githubusercontent.com/86602521/138067822-f8029716-4216-4821-bb04-6ba435cfd5fa.png)

### API Versions

The demo implements three concurrent versions (1.1, 1.2, 2.0) that are exposed by collecting ApiVersionAttribute from controllers.
Four types of controllers are showing different approaches on versioning:

- ApiVersionAttribute - used to apply explicit version
- ApiVersionNeutralAttribute - used for version independent
- ApiInheritableVersionAttribute - used for create a base class with a range of versions inheritable by child classes (custom)
- ApiRangeV1m2V2m0Attribute - used to apply a fixed subset of versions (custom)

### Pinpoints

- Convention based, generic routing ```[Route("api/v{api-version:apiVersion}/[controller]")]```
- Model Binding for ApiVersion in controllers action signature
- Different options on signaling the versions

## Controllers

### NeutralActor Controller versions characteristics

It uses the ApiVersionNeutral attribute and it is independent from versions (i.e. it is exposes accross all versions)

### MultiSkilledActor Controller versions characteristics

A demo class that presents a usecase with a controller with a limited lifetime between v1.2 and v2.0.
It inherits the versions placed on a base class decorated with ApiInheritableVersion


### SafeSkilledActor Controller versions characteristics

Another demo class that presents a usecase with a controller with a limited lifetime between v1.2 and v2.0.
It is decorated with a custom attribute (ApiRangeV1m2V2m0) that covers a subset of versions


### WeatherForecast Controller versions characteristics

They are derived from an abstract base controller that keeps the common characteristics across supported versions.

#### v1.1 

- It is marked as deprecated at class level (as result, VERSION IS DEPRECATED is displayed)
- The Get method is marked as Obsolete (as result, the action endpoint is grayed out in SwaggerUI)
- Uses a WeatherForecast model v1.1

![image](https://user-images.githubusercontent.com/86602521/137956161-45671ad1-d558-40e5-90c7-5005038e3bc2.png)

#### v1.2 

- It is marked as deprecated at class level (as result, VERSION IS DEPRECATED will be displayed only if MultiSkilledActor will be marked as well)
- Uses a WeatherForecast model v1.1
- The Get method has a patched version of processing the WeatherForecast

![image](https://user-images.githubusercontent.com/86602521/138076984-2be8fe6d-09f4-48df-8119-d0474127c758.png)

#### v2.0

- the version is signaled with a custom attribute
- Uses a WeatherForecast model v2.0
- The Get method has an improved version

![image](https://user-images.githubusercontent.com/86602521/138077042-52c564fc-bb91-4583-b641-9f7b67f1bf24.png)

### Model versions

The model versions does not directly influence the version of the API, and it is not mandatory to have versions matched with the API. For example, a model can stay forever as 1.0 and in the meantime other models to evolve to greater versions. The dependency could be better seen as "the latest changes to the models push the API version evolution".

## Credits

- Mark Heath: Pluralsight course  [
Versioning and Evolving Microservices in ASP.NET Core](https://app.pluralsight.com/library/courses/versioning-evolving-microservices-asp-dot-net-core/exercise-files)
- ASP.NET API Versioning [samples](https://github.com/dotnet/aspnet-api-versioning/tree/master/samples)

## Further reading

### Opinionated convention

On the same topic [purplebricks](https://github.com/purplebricks/PB.ITOps.AspNetCore.Versioning) propose an interesting approach.
Source repo: https://github.com/purplebricks/PB.ITOps.AspNetCore.Versioning  
Description: "It extends Microsoft ASP.Net API Versioning by introducing a new convention and attributes."  

Quotes from the repo documentation:

  - There is only 1 supported API version at any given time (the latest). All other versions are deprecated.
  - Only numbered major versions allowed (e.g `V1`, `V2`, `V3`, etc.)
  - When a new API version is introduced, all actions are automatically added to the new API version (unless explicitly marked as removed).
  - Simplified api developer story - we only need to make changes where there are differences between versions. Previously we would need to manually add attributes to multiple classes and methods that have not had any changes.
  - Less error prone - Less chance of making a mistake when introducing a new api version.
