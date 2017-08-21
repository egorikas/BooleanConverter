# BooleanConverter
[![Build status](https://ci.appveyor.com/api/projects/status/67obru497wcyxc6q?svg=true)](https://ci.appveyor.com/project/EgorGrishechko/booleanconverter)
[![NuGet](https://img.shields.io/nuget/v/BooleanConverter.svg)](https://www.nuget.org/packages/BooleanConverter)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

Integer to Boolean converter for Json.NET

## Installation

`Install-Package BooleanConverter`

## Usage

```csharp
namespace UsageExample
{
    public class ApiData
    {
        [JsonConverter(typeof(BooleanConverter))]
        public bool Field { get; set; }
    }

    public class ConverterTest
    {
        [Fact]
        public void SerializeHappyPath()
        {
            //Arrange
            var apiJson = "{ Field : 1}";

            //Act
            var result = JsonConvert.DeserializeObject<ApiData>(apiJson);

            //Assert
            Assert.Equal(true, result.Field);
        }
    }
}
```

## Build

Install [.NET Core SDK](https://www.microsoft.com/net/download/core "official site")

Open `src` folder in the command prompt.
Then 
```
    dotnet restore
    dotnet build
```
## Tests
Open `src\JsonNetConvertersTest` folder in the command prompt.
Then
```
    dotnet test
```

## .NET Standart compatibility
Library was created with supporting for **.NET Standart 1.3**

## Contributing
Don't be shy to ask a question or offer something :)
