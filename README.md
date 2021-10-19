# Demo project for Aspnet Core API Versioning

## Purpose

To provide an example for implementing concurrent versioning support to Web API.

## Description

It is an ASP.NET Core Web API project providing a basic architecture for showing several facets of versioning.

![image](https://user-images.githubusercontent.com/86602521/137952705-fcc79c92-a5ab-418b-8a2b-389ccf837546.png)

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

- It is marked as deprecated at class level
- The Get method is marked as Obsolete
- Uses a WeatherForecast model v1.1

#### v1.2 

- It is marked as deprecated at class level
- Uses a WeatherForecast model v1.1
- The Get method has a patched version of processing the WeatherForecast

#### v2.0

- Uses a WeatherForecast model v2.0
- The Get method has an improved version

### Model versions

The model versions does not directly influence the version of the API and are not mandatory to have versions related to the API. For example, a model can stay forever as 1.0 and in the meantime other models to evolve to greater versions. The dependency could be better seen as "the changes in the models push the API version evolution".

