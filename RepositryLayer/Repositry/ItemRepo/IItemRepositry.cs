using DataLayer.DTO;
using DataLayer.Models;

namespace RepositryLayer.Repositry.ItemRepo
{
    public interface IItemRepositry
    {
        Task DeleteItem(int Id);
        Task<List<ItemDTO>> GetItems();
        Item GetItemById(int id);
        bool validateItems(List<OrderDetailDTO> listOfInputs);
    }
}