using System.Collections.Generic;

namespace Northland.Net.Application.Order.Queries.GetOrderList
{
public class OrderListVm{
    public IList<OrderListDto> Orders { get; set; }
}
}