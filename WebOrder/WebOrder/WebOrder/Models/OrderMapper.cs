using AutoMapper;

namespace WebOrder.Models
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<OrderViewModel, OrderTbl>()
                .ForMember(x => x.ItemCode, dto => dto.Ignore());

            CreateMap<OrderTbl, OrderViewModel>();
        }
    }
}
