namespace Core.Interfaces;
using Core.Entities;


public interface IProductoRepository : IGenericRepository<Producto> {


    Task<IEnumerable<Producto>> GetMoreExpensiveProducts(int cantidad); // Ej quiero los 30 productos mas caros


}