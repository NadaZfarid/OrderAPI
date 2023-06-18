using RepositryLayer.Repositry.OrderRepo;
using RepositryLayer.Repositry.OrderDetails;
using RepositryLayer.Repositry.ItemRepo;

namespace RepositryLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IOrderRepositry orderRepositry { get; }
        IOrderDetailsRepositry orderDetailsRepositry { get; }
        IItemRepositry itemRepositry { get; }


        Task<int> SaveChangesAsync();
    }
}