using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebOrder.Models;

namespace WebOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DbContextOrder _context;
        private readonly IMapper _map;
        public OrderController(DbContextOrder context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        [HttpGet]
        [Route(nameof(FindAll))]
        public async Task<object> FindAll()
        {
            return await Task.FromResult(_context.orders.ToList());
        }


        [HttpPost]
        [Route(nameof(Add))]
        public async Task<ActionResult<OrderViewModel>> Add(OrderViewModel orderViewModel)
        {
            var data = _map.Map<OrderViewModel, OrderTbl>(orderViewModel);

            _context.orders.Add(data);
            if(await _context.SaveChangesAsync() > 0)
            {
                return await Task.FromResult(orderViewModel);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route(nameof(Edit))]
        public async Task<ActionResult<OrderViewModel>> Edit(int id, OrderViewModel orderViewModel)
        {
            var checkData = _context.orders.Where(x => x.ItemCode == id).FirstOrDefault();
            if(checkData == null)
            {
                return NotFound();
            }

            checkData.PhoneNumber = orderViewModel.PhoneNumber;
            checkData.OrderAddress = orderViewModel.OrderAddress;
            checkData.OrderDelivery = orderViewModel.OrderDelivery;
            checkData.ItemQty = orderViewModel.ItemQty;
            checkData.ItemName = orderViewModel.ItemName;

            _context.orders.Update(checkData);

            if (await _context.SaveChangesAsync() > 0)
            {
                return await Task.FromResult(orderViewModel);
            }

            return BadRequest();
        }

    }
}
