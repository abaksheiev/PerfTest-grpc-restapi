using PerfTest.Grpc.Services;
using PerfTest.DataGen;
using PerfTest.Grpc.Mapping;

namespace PerfTest.Grpc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.WebHost.ConfigureKestrel(options =>
            {
                // Force Kestrel to use HTTP/2 (required for gRPC)
                options.ListenAnyIP(5001, listenOptions =>
                {
                    listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;  // Ensure HTTP/2 is enabled
                });
                //  options.Limits.Http2.MaxStreamsPerConnection = 512;  // Ограничение количества потоков в HTTP/2 (gRPC использует HTTP/2)
                //  options.Limits.Http2.KeepAlivePingDelay = TimeSpan.FromSeconds(30);
                //  options.Limits.Http2.KeepAlivePingTimeout = TimeSpan.FromSeconds(10);
            });

            builder.Services.AddGrpc(options => {
                // Настройка параметров gRPC
               // options.EnableDetailedErrors = false;
            });
            // Register AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddDataGenServices();


            var app = builder.Build();
           

            // Configure the HTTP request pipeline.
            app.MapGrpcService<OrderServiceApp>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}