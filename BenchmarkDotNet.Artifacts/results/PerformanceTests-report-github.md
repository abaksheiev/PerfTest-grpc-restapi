```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3403)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 10.0.100-preview.2.25164.34
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2


```
| Method      | Mean     | Error   | StdDev   | Median   |
|------------ |---------:|--------:|---------:|---------:|
| TestRestApi | 217.8 μs | 6.58 μs | 19.41 μs | 213.2 μs |
| TestGrpc    | 226.3 μs | 9.43 μs | 26.44 μs | 217.2 μs |
