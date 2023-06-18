using DataLayer;
using DataLayer.DTO;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;



namespace RepositryLayer.Repositry.ItemRepo
{
    public class ItemRepositry : IItemRepositry
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemRepositry(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<ItemDTO>> GetItems()
        {
            var items = await _dbContext.Items.ToListAsync();
            var listOfItems = new List<ItemDTO>();

            foreach (Item item in items)
            {
                ItemDTO itemDTO = new ItemDTO()
                {
                    Code = item.Code,
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                };

                listOfItems.Add(itemDTO);
            }

            return listOfItems;
        }

        public Item GetItemById(int id)
        {
            Item itemById = _dbContext.Items.AsNoTracking().FirstOrDefault(o => o.Id == id);
            return itemById;
        }

        public async Task DeleteItem(int Id)
        {
            Item item = await _dbContext.Items.FindAsync(Id);
            _dbContext.Items.Remove(item);
        }

        public bool validateItems(List<OrderDetailDTO> listOfInputs)
        {
            int correctItem = 0;
            foreach (var item in listOfInputs)
            {
               if (GetItemById(item.ItemId)!=null)
                {
                    correctItem++;
                }

            }

            if (listOfInputs.Count == correctItem)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        

    }
}
