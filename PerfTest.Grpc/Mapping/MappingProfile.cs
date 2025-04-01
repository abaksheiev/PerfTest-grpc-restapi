namespace PerfTest.Grpc.Mapping;

using AutoMapper;
using PerfTest.DataGen.DomainModels;
using PerfTest.Grpc;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapping from Order to OrderReply
        CreateMap<Order, OrderReply>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(src.CreatedAt.ToUniversalTime())));

        // Mapping for Customer, OrderItem, and Address (nested mappings)
        CreateMap<Customer, CustomerReply>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.ShippingAddress));

        CreateMap<Address, AddressReply>()
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.PostalCode))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));

        CreateMap<OrderItem, OrderItemReply>()
            .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
    }
}
