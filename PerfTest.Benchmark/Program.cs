using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using PerfTest.Api.Dtos;
using PerfTest.Grpc; // Import your gRPC client
using System.Net.Http.Json;



public class PerformanceTests
{
    private readonly Empty EmptyRequest = new Empty();

    private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5000") };
    private readonly GrpcChannel _grpcChannel = GrpcChannel.ForAddress("http://localhost:5001");
    private readonly OrderService.OrderServiceClient _grpcClient;

    public PerformanceTests()
    {
        _grpcClient = new OrderService.OrderServiceClient(_grpcChannel);

        var config = DefaultConfig.Instance.WithOptions(ConfigOptions.DisableOptimizationsValidator);
        BenchmarkRunner.Run<PerformanceTests>(config);
    }

   
    [Benchmark]
    public async Task TestRestApi()
    {
        var response = await _httpClient.GetFromJsonAsync<OrderDto>("/orders");
    }

    
    [Benchmark]
    public async Task TestGrpc()
    {
        
        await _grpcClient.GetOrdersAsync(EmptyRequest);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<PerformanceTests>();
    }
}
