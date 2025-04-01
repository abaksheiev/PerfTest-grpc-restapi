
Projects:
The solution consists of four projects:
- PerfTest.Benchmark - A project dedicated to performance testing using BenchmarkDotNet. It runs benchmarks on both REST and gRPC APIs, measuring response times and system resource usage to compare their performance.
- PerfTest.Api - A simple REST API built with ASP.NET Core. It exposes HTTP endpoints for managing orders and other data, using standard request-response mechanisms over HTTP.
- PerfTest.Grpc - A gRPC API that provides similar functionality to the REST API but optimized for high-performance communication. It utilizes protocol buffers (protobuf) for efficient serialization and supports bi-directional streaming.
- PerfTest.DataGen - A data generator that populates the database with sample data. This project ensures realistic performance testing by generating a sufficient amount of test data to simulate real-world scenarios.

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
