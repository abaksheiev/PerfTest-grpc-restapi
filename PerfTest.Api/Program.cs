

using AutoMapper;
using PerfTest.Api.Dtos;
using PerfTest.Api.Mapping;
using PerfTest.DataGen;
using PerfTest.DataGen.Services;

var builder = WebApplication.CreateBuilder(args);

// Register AutoMapper and services
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDataGenServices();


var app = builder.Build();


// Define minimal API endpoints

// Get Orders endpoint
app.MapGet("/orders", async (IOrderServiceDataGen orderServiceDataGen, IMapper mapper) =>
{
    var orders = orderServiceDataGen.GetOrders(10000); 
    var orderDto = mapper.Map<OrderDto>(orders);
    
    return Results.Ok(orderDto);
})
.WithName("GetOrders");

app.Run();
