using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PerfTest.DataGen.Services;
using PerfTest.Grpc;

namespace PerfTest.Grpc.Services;

public class OrderServiceApp : OrderService.OrderServiceBase
{
    private readonly IOrderServiceDataGen _orderServiceDataGen;
    private readonly IMapper _mapper;
    public OrderServiceApp(IOrderServiceDataGen logger, IMapper mapper)
    {
        _orderServiceDataGen = logger;
        _mapper = mapper;
    }

    public override async Task<OrderReply> GetOrders(Empty request, ServerCallContext context)
    {
        var data = _orderServiceDataGen.GetOrders(10000);

         var response = _mapper.Map<OrderReply>(data);

        return await Task.FromResult(response);
    }
}
