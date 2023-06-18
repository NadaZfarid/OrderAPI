using DataLayer.Models;
using RepositryLayer.Repositry.OrderRepo;
using RepositryLayer.Repositry.OrderDetails;
using RepositryLayer.Repositry.ItemRepo;

namespace RepositryLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IOrderRepositry orderRepositry => new OrderRepositry(dbContext);

        public IOrderDetailsRepositry orderDetailsRepositry => new OrderDetailsRepositry(dbContext);

        public IItemRepositry itemRepositry => new ItemRepositry(dbContext);

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
