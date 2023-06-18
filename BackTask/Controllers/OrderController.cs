using DataLayer;
using DataLayer.DTO;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositryLayer.Repositry;
using RepositryLayer.UnitOfWork;

namespace BackTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {

            var orders = await _unitOfWork.orderRepositry.GetOrders();
            return Ok(orders);

        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderDTO input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    if (!_unitOfWork.itemRepositry.validateItems(input.orderDetails))
                    {
                        return NotFound("Item Not Found");
                    }

                    if (input.orderDetails is { Count: > 0 })
                    {
                        Order order = await _unitOfWork.orderRepositry.AddOrder(input);
                        await _unitOfWork.SaveChangesAsync();
                        
                        await _unitOfWork.orderDetailsRepositry.AddOrderDetails(input,order);
                        await _unitOfWork.SaveChangesAsync();
                        return Ok();

                    }
                    else
                    {
                        return NotFound("Invalid Order");
                    }
                       
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(int id, OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                try
                {
                    if (_unitOfWork.orderRepositry.GetOrderById(id) == null)
                    {
                        return NotFound ("Order Does not Exist !!");
                    }

                    if (id != orderDTO.Id)
                    {
                        return BadRequest();
                    }
                    else
                    {

                        Order order = await _unitOfWork.orderRepositry.UpdateOrder(orderDTO);
                        await _unitOfWork.orderDetailsRepositry.UpdateOrderDetails(orderDTO, order);
                        await _unitOfWork.SaveChangesAsync();

                        return Ok();

                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
        }

        [HttpDelete]
        public async Task <IActionResult> DeleteOrder(int id)
        {
            if (_unitOfWork.orderRepositry.GetOrderById(id) == null)
            {
                return NotFound();
            }

           await _unitOfWork.orderRepositry.DeleteOrder(id);
           await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
