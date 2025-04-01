
Projects:
- PerfTest.Benchmark - tests
- PerfTest.Api - simple rest api
- PerfTest.Grpc - grpc api
- PerfTest.DataGen - data generator

Stucture:
```html
├───BenchmarkDotNet.Artifacts
├───PerfTest.Api
│   ├───Dtos
│   ├───Mapping
│   └───Properties
├───PerfTest.Benchmark
├───PerfTest.DataGen
│   ├───DatraGens
│   ├───DomainModels
│   └───Services
│       └───Impl
└───PerfTest.Grpc
    ├───Mapping
    ├───Properties
    ├───Protos
    └───Services
```

How to run everything at once:

dotnet run --configuration Release --project PerfTest.Api
dotnet run --configuration Release --project PerfTest.Grpc

dotnet run --configuration Release --project PerfTest.Benchmark
