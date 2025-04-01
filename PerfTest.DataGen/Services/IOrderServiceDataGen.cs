using PerfTest.DataGen.DomainModels;

namespace PerfTest.DataGen.Services;

public interface IOrderServiceDataGen
{
    Order GetOrders(int count = 10000);
}
